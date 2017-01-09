using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TLM_parser
{
    public partial class frmMain : Form
    {
        private List<int[]> bigDataIn = new List<int[]>();
        private List<uint[]> bigDigitalInfo = new List<uint[]>();
        private int tlmBlockSize = 65536;

        private String M = "1111100110100100001010111011000";
        private String B = "1111100110101";

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSelectTLM = new OpenFileDialog();

            //ofdSelectTLM.InitialDirectory = "c:\\";
            ofdSelectTLM.Filter = "TLM file (*.tlm)|*.tlm";
            ofdSelectTLM.FilterIndex = 2;
            ofdSelectTLM.RestoreDirectory = true;

            if (ofdSelectTLM.ShowDialog() == DialogResult.OK)
            {
                rtbMemoshka.Clear();
                using (FileStream sourceFile = new FileStream(ofdSelectTLM.FileName, FileMode.Open, FileAccess.Read))
                {
                    // Get header
                    byte[] header = new byte[256];
                    for (int i = 0; i < 256; i++)
                    header[i] = (byte)sourceFile.ReadByte();
                    string[] args;
                    args = Encoding.Default.GetString(header).Split('.');
                    foreach (var item in args)
                        tbHeader.AppendText(item + "\r\n");
                    

                    // get values
                    int dataStart = 256 + 32;
                    int dataEnd = tlmBlockSize + dataStart;

                    while (dataEnd < sourceFile.Length)
                    {
                        int checkMarkerL = 0;
                        int checkMarkerM = 0;
                        int checkMarkerH = 0;
                        bool writeDigital = false;
                        int digitalCounter = 0;

                        int[] body = new int[tlmBlockSize / 2];
                        for (int i = dataStart; i < dataEnd; i += 2)
                        {
                            body[(i - dataStart) / 2] = (byte)sourceFile.ReadByte();
                            body[(i - dataStart) / 2] += ((byte)sourceFile.ReadByte() << 8);
                            body[(i - dataStart) / 2] = (body[(i - dataStart) / 2] & 0xFFF) >> 1;
                        }
                        lbCycles.Items.Add(String.Format("Cycle #{0}", bigDataIn.Count + 1));
                        bigDataIn.Add(body);
                        dataStart = dataEnd + 32;
                        dataEnd += tlmBlockSize + 32;
                        for (int i = 0; i < 32; i++)
                            sourceFile.ReadByte();
                    }

                    BinaryWriter dataOut;
                    String fileName = "d:/digital.bin";
                    try
                    {
                        dataOut = new BinaryWriter(new FileStream(fileName, FileMode.Create));
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine("Ошибка открытия файла: " + ex.Message);
                        return;
                    }
                    try
                    {
                        bool go = false;
                        int newi = 0;
                        foreach (var arr in bigDataIn)
                        {
                            for (int i = 0; i < arr.Length; i++)
                            {
                                if ((i < 128) && (arr[i + 3] == 508)) go = true;
                                if (go)
                                {
                                    newi++;
                                    if (newi % 4 != 0)
                                    {
                                        dataOut.Write((byte)(arr[i] >> 8));
                                        dataOut.Write((byte)arr[i]);
                                    }
                                    if ((i>1000) && (arr[i] ==0 && arr[i-1] == 0))
                                    {
                                        newi = 3;
                                    }
                                }
                            }
                        }
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine("Ошибка ввода-вывода файла: " + ex.Message);
                        return;
                    }
                    dataOut.Close();

                    double progress = 0.0f;
                    double step = 100.0f / (65535);
                    if (File.Exists(fileName))
                    {
                        using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                        {
                            uint count = 0;
                            uint digitalCount = 0;
                            uint dat = 0;
                            uint[] digitalFrame = new uint[300];

                            while (reader.BaseStream.Position < 65535)//!= reader.BaseStream.Length)
                            {
                                dat = (uint)(reader.ReadByte() << 8);
                                dat += (uint)(reader.ReadByte());
                                uint marker0 = 0;
                                uint marker1 = 0;
                                uint marker2 = 0;
                                uint marker3 = 0;
                                digitalFrame[digitalCount] = dat;
                                if ((digitalFrame[digitalCount] == 0x00CA)                                 //M ~B
                                    && (digitalFrame[digitalCount - 1] == 0x0760) 
                                    && (digitalFrame[digitalCount - 2] == 0x010A)
                                    && (digitalFrame[digitalCount - 3] == 0x07CD) ||
                                    (digitalFrame[digitalCount] == 0x0735)                                 //M B
                                    && (digitalFrame[digitalCount - 1] == 0x0763)
                                    && (digitalFrame[digitalCount - 2] == 0x010A)
                                    && (digitalFrame[digitalCount - 3] == 0x07CD) ||
                                    (digitalFrame[digitalCount] == 0x0735)                                 //~M B
                                    && (digitalFrame[digitalCount - 1] == 0x009F)
                                    && (digitalFrame[digitalCount - 2] == 0x06F5)
                                    && (digitalFrame[digitalCount - 3] == 0x0032) ||
                                    (digitalFrame[digitalCount] == 0x00CA)                                 //~M ~B
                                    && (digitalFrame[digitalCount - 1] == 0x009C)
                                    && (digitalFrame[digitalCount - 2] == 0x06F5)
                                    && (digitalFrame[digitalCount - 3] == 0x0032)
                                    )
                                {
                                    marker3 = digitalFrame[digitalCount];
                                    marker2 = digitalFrame[digitalCount - 1];
                                    marker1 = digitalFrame[digitalCount - 2];
                                    marker0 = digitalFrame[digitalCount - 3];
                                    bigDigitalInfo.Add(digitalFrame);
                                    digitalFrame = new uint[300];
                                    lbDigital.Items.Add(String.Format("Frame #{0}", bigDigitalInfo.Count));
                                    digitalFrame[0] = marker0;
                                    digitalFrame[1] = marker1;
                                    digitalFrame[2] = marker2;
                                    digitalFrame[3] = marker3;
                                    digitalCount = 3;
                                }
                                digitalCount++;
                            }
                        }
                    }
                }
            }
        }

        private void lbCycles_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbMemoshka.Clear();
            rtbMemoshka.Visible = true;
            rtbD0.Visible = false;
            rtbD1.Visible = false;
            rtbD2.Visible = false;
            rtbD3.Visible = false;
            lbCycles.Enabled = false;
            int index;
            pbMain.Value = 0;
            int.TryParse(lbCycles.GetItemText(lbCycles.SelectedItem).Split('#')[1], out index);
            double progress = 0.0f;
            double step = 100.0f / (bigDataIn[index].Length - 16);

            for (int i = 16; i < bigDataIn[index].Length; i++)
            {
                if ((i % 8 == 0) && (i != 16))
                    rtbMemoshka.AppendText("\r\n");
                    rtbMemoshka.AppendText(Convert.ToString(bigDataIn[index][i]/*, 2*/).PadLeft(4, '0') + "\t");
                progress += step;
                pbMain.Value = (int)progress;
            }
            pbMain.Value = 100;
            lbCycles.Enabled = true;
            Clipboard.SetText(rtbMemoshka.Text);
        }

        private void lbDigital_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbMemoshka.Clear();
            rtbMemoshka.Visible = false;
            rtbD0.Visible = true;
            rtbD1.Visible = true;
            rtbD2.Visible = true;
            rtbD3.Visible = true;
            lbDigital.Enabled = false;
            int index;
            pbMain.Value = 0;
            int.TryParse(lbDigital.GetItemText(lbDigital.SelectedItem).Split(',')[0].Split('#')[1], out index);
            double progress = 0.0f;
            double step = 100.0f / (bigDigitalInfo[index][0]);

            for (int i = 0; i < bigDigitalInfo[index].Length; i++)
            {
                if (i % 10 == 0)
                {
                    rtbD0.AppendText("\r\n");
                    rtbD1.AppendText("\r\n");
                    rtbD2.AppendText("\r\n");
                    rtbD3.AppendText("\r\n");
                }
                rtbD0.AppendText(Convert.ToString(bigDigitalInfo[index][i]).PadLeft(4, '0') + "\t");
                rtbD1.AppendText(Convert.ToString(bigDigitalInfo[index + 1][i]).PadLeft(4, '0') + "\t");
                rtbD2.AppendText(Convert.ToString(bigDigitalInfo[index + 2][i]).PadLeft(4, '0') + "\t");
                rtbD3.AppendText(Convert.ToString(bigDigitalInfo[index + 3][i]).PadLeft(4, '0') + "\t");
            }
            pbMain.Value = 100;
            lbDigital.Enabled = true;
//            Clipboard.SetText(rtbMemoshka.Text);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            M.PadLeft(32, '0');
            uint i;
            i = Convert.ToUInt32(M);

            tbTest.Text = i.ToString() + "\r\n";
            tbTest.AppendText((~i).ToString());
        }
    }
}
