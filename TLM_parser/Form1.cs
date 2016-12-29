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
        private List<int[]> bigDigitalInfo = new List<int[]>();
        private int tlmBlockSize = 65536;

        private String Mh = "11111001101";    //1997
        private String Mm = "00100001010";    //266
        private String Ml = "11101100011";    //1891
        private String B  = "11100110101";    //1845


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



                    //pick digital info
                    int[] digitalFrame = new int[32768];
                    foreach (var arr in bigDataIn)
                    {
                        int digitalCounter = 0;
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if ((i % 4) != 0)
                            {
                                if ((arr[i] == Convert.ToInt32(Mh, 2)) 
                                    && (arr[i + 1] == Convert.ToInt32(Mm, 2)) 
                                    && ((arr[i + 2]) == Convert.ToInt32(Ml, 2))
                                    // && ((arr[i + 3]) == Convert.ToInt32(B, 2))
                                    )
                                {
                                    lbDigital.Items.Add(String.Format("Frame #{0}, {1}", bigDigitalInfo.Count + 1, digitalCounter));
                                    digitalFrame[0] = digitalCounter;
                                    bigDigitalInfo.Add(digitalFrame);
                                    digitalFrame = new int[32768];
                                    digitalCounter = 1;
                                }
                                digitalFrame[digitalCounter] = arr[i];
                                digitalCounter++;
                            }
                        }
                        bigDigitalInfo.Add(digitalFrame);

                    }
                }
            }
        }

        private void lbCycles_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbMemoshka.Clear();
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
                
                //if (i % 4 != 0)
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
            lbDigital.Enabled = false;
            int index;
            pbMain.Value = 0;
            int.TryParse(lbDigital.GetItemText(lbDigital.SelectedItem).Split(',')[0].Split('#')[1], out index);
            double progress = 0.0f;
            double step = 100.0f / (bigDigitalInfo[index][0]);

            for (int i = 0; i < bigDigitalInfo[index][0]; i++)
            {
                if (i % 6 == 0)
                    rtbMemoshka.AppendText("\r\n");
                rtbMemoshka.AppendText(Convert.ToString(bigDigitalInfo[index][i]).PadLeft(4, '0') + "\t");
            }
            pbMain.Value = 100;
            lbDigital.Enabled = true;
            Clipboard.SetText(rtbMemoshka.Text);
        }
    }
}
