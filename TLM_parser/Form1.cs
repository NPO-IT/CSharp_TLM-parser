using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TLM_parser
{
    public partial class frmMain : Form
    {
        private List<int[]> bigDataIn = new List<int[]>();
        private List<uint[]> bigDigitalInfo = new List<uint[]>();
        private List<int> words = new List<int>();
        private int tlmBlockSize = 65536;
        String fileName = "d:/digital.bin";
        private int oldX;

        private int HISTO_MIN = 0;
        private int HISTO_YMAX = 4095;
        private int HISTO_XMAX = 18;
        private int HISTO_YINT = 256;
        private int HISTO_XINT = 1;
        private int GRAPH_MIN = 0;
        private int GRAPH_YMAX = 4095;
        private int GRAPH_XMAX = 1023;
        private int GRAPH_YINT = 512;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            tmrDelay.Enabled = false;

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

                    if (File.Exists(fileName))
                    {
                        using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                        {
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
                                    digitalFrame[digitalCount] = 0;
                                    digitalFrame[digitalCount - 1] = 0;
                                    digitalFrame[digitalCount - 2] = 0;
                                    digitalFrame[digitalCount - 3] = 0;
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
                                if (digitalCount == 299) digitalCount = 0;
                            }
                        }
                    }
                }
            }
        }

        private void lbCycles_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmrDelay.Enabled = false;
            cDia.Visible = false;
            cHisto.Visible = false;
            rtbMemoshka.Clear();
            rtbD0.Clear();
            rtbD1.Clear();
            rtbD2.Clear();
            rtbD3.Clear();
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
            tmrDelay.Enabled = false;
            cDia.Visible = false;
            cHisto.Visible = false;
            rtbMemoshka.Clear();
            rtbD0.Clear();
            rtbD1.Clear();
            rtbD2.Clear();
            rtbD3.Clear();
            rtbMemoshka.Visible = false;
            rtbD0.Visible = true;
            rtbD1.Visible = true;
            rtbD2.Visible = true;
            rtbD3.Visible = true;
            lbDigital.Enabled = false;
            int index;
            pbMain.Value = 0;
            int.TryParse(lbDigital.GetItemText(lbDigital.SelectedItem).Split(',')[0].Split('#')[1], out index);
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
        }

        private void Chart_Init()
        {
            int[] histogramEnum = new int[HISTO_XMAX + 1];
            int[] graphicEnum = new int[GRAPH_XMAX + 1];

            cHisto.ChartAreas[0].AxisY.Minimum = HISTO_MIN;
            cHisto.ChartAreas[0].AxisY.Maximum = HISTO_YMAX + 1;
            cHisto.ChartAreas[0].AxisY.Interval = HISTO_YINT;
            cHisto.ChartAreas[0].AxisX.Minimum = HISTO_MIN;
            cHisto.ChartAreas[0].AxisX.Maximum = HISTO_XMAX;
            cHisto.ChartAreas[0].AxisX.Interval = HISTO_XINT;

            cDia.ChartAreas[0].AxisY.Minimum = GRAPH_MIN;
            cDia.ChartAreas[0].AxisY.Maximum = GRAPH_YMAX + 1;
            cDia.ChartAreas[0].AxisY.Interval = GRAPH_YINT;
            cDia.ChartAreas[0].AxisX.Minimum = GRAPH_MIN;
            cDia.ChartAreas[0].AxisX.Maximum = GRAPH_XMAX;
            cDia.ChartAreas[0].AxisX.Interval = GRAPH_YINT;

            cHisto.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            cHisto.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            cHisto.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            cHisto.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

            cDia.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            cDia.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            cDia.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            cDia.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

            cHisto.ChartAreas[0].CursorX.IsUserEnabled = true;
            cHisto.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            cHisto.ChartAreas[0].CursorX.SelectionColor = Color.LightGray;

            cDia.ChartAreas[0].CursorX.IsUserEnabled = true;
            cDia.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            cDia.ChartAreas[0].CursorX.SelectionColor = Color.Azure;

            cDia.Series["Series12"].Points.Clear();
            cDia.Series["Series8"].Points.Clear();
            cHisto.Series["s12"].Points.Clear();
            cHisto.Series["s08"].Points.Clear();
            cHisto.Series["Series"].Points.Clear();

            for (int i = 0; i < HISTO_XMAX + 1; i++)
            {
                histogramEnum[i] = i;
                cHisto.Series["s12"].Points.AddXY(histogramEnum[i], 0);
                cHisto.Series["s08"].Points.AddXY(histogramEnum[i], 0);
                cHisto.Series["Series"].Points.AddXY(histogramEnum[i], 0);
            }
            for (int i = 0; i < GRAPH_XMAX + 1; i++)
            {
                cDia.Series["Series12"].Points.AddXY(graphicEnum[i], 0);
                cDia.Series["Series8"].Points.AddXY(graphicEnum[i], 0);
            }
        }

        private void btnShowGraphic_Click(object sender, EventArgs e)
        {
            cDia.Visible = true;
            cHisto.Visible = true;
            rtbMemoshka.Visible = false;
            rtbD0.Visible = false;
            rtbD1.Visible = false;
            rtbD2.Visible = false;
            rtbD3.Visible = false;
            Chart_Init();
            tmrDelay.Enabled = true;
            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    uint digitalCount = 0;
                    uint dat = 0;
                    uint[] digitalFrame = new uint[300];

                    while (reader.BaseStream.Position != reader.BaseStream.Length)
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
                            digitalFrame[digitalCount] = 0;
                            digitalFrame[digitalCount - 1] = 0;
                            digitalFrame[digitalCount - 2] = 0;
                            digitalFrame[digitalCount - 3] = 0;
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
                        if (digitalCount == 299) digitalCount = 0;
                    }
                }
                StringBuilder newbigstring = new StringBuilder();
                for (int i = 1; i < bigDigitalInfo.Count; i++)
                {
                    uint[] work = bigDigitalInfo[i];
                    for (int j = 4; j < work.Length; j++)
                    {
                        newbigstring.Append(Convert.ToString((work[j]), 2).PadLeft(11, '0'));
                        if (newbigstring.Length > 16)
                        {
                            char[] arr = new char[16];
                            newbigstring.CopyTo(0, arr, 0, 16);
                            words.Add(Convert.ToInt32(new String(arr), 2) );
                            newbigstring.Remove(0, 16);
                        }
                    }
                }
            }
        }

        private void tmrDelay_Tick(object sender, EventArgs e)
        {
            cHisto.Series["s12"].Points.Clear();
            cHisto.Series["s08"].Points.Clear();
            cHisto.Series["Series"].Points.Clear();

            cHisto.Series["s12"].Points.AddXY(0, words[oldX + 1] >> 4);
            cHisto.Series["s12"].Points.AddXY(1, words[oldX + 2] >> 4);
            cHisto.Series["s12"].Points.AddXY(2, words[oldX + 3] >> 4);
            cHisto.Series["s12"].Points.AddXY(3, words[oldX + 4] >> 4);
            cHisto.Series["s12"].Points.AddXY(4, words[oldX + 5] >> 4);
            cHisto.Series["s12"].Points.AddXY(5, words[oldX + 6] >> 4);
            cHisto.Series["s12"].Points.AddXY(6, words[oldX + 7] >> 4);
            cHisto.Series["s12"].Points.AddXY(7, words[oldX + 8] >> 4);
            cHisto.Series["s12"].Points.AddXY(8, words[oldX + 9] >> 4);

            cHisto.Series["s12"].Points.AddXY(9, words[oldX + 11] >> 4);
            cHisto.Series["s12"].Points.AddXY(10, words[oldX + 12] >> 4);
            cHisto.Series["s12"].Points.AddXY(11, words[oldX + 13] >> 4);
            cHisto.Series["s12"].Points.AddXY(12, words[oldX + 14] >> 4);
            cHisto.Series["s12"].Points.AddXY(13, words[oldX + 15] >> 4);
            cHisto.Series["s12"].Points.AddXY(14, words[oldX + 16] >> 4);
            cHisto.Series["s12"].Points.AddXY(15, words[oldX + 17] >> 4);
            cHisto.Series["s12"].Points.AddXY(16, words[oldX + 18] >> 4);
            cHisto.Series["s12"].Points.AddXY(17, words[oldX + 19] >> 4);

            cHisto.Series["s08"].Points.AddXY(0, (words[oldX + 11] & 0xF) + ((words[oldX + 1] & 0xF) << 4));
            cHisto.Series["s08"].Points.AddXY(1, (words[oldX + 12] & 0xF) + ((words[oldX + 2] & 0xF) << 4));
            cHisto.Series["s08"].Points.AddXY(2, (words[oldX + 13] & 0xF) + ((words[oldX + 3] & 0xF) << 4));
            cHisto.Series["s08"].Points.AddXY(3, (words[oldX + 14] & 0xF) + ((words[oldX + 4] & 0xF) << 4));
            cHisto.Series["s08"].Points.AddXY(4, (words[oldX + 15] & 0xF) + ((words[oldX + 5] & 0xF) << 4));
            cHisto.Series["s08"].Points.AddXY(5, (words[oldX + 16] & 0xF) + ((words[oldX + 6] & 0xF) << 4));
            cHisto.Series["s08"].Points.AddXY(6, (words[oldX + 17] & 0xF) + ((words[oldX + 7] & 0xF) << 4));

            cHisto.Series["Series"].Points.AddXY(0, (words[oldX] >> 1) & 0x3F);
            cHisto.Series["Series"].Points.AddXY(1, (words[oldX] >> 6));

            cHisto.Series["Series"].Points.AddXY(9, (words[oldX + 10] >> 1) & 0x3F);
            cHisto.Series["Series"].Points.AddXY(10, (words[oldX + 10] >> 6));
            oldX += 10;

            if (oldX > words.Count) tmrDelay.Enabled = false;
        }
    }
}
