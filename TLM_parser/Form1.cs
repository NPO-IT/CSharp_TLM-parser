using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TLM_parser
{
    public partial class frmMain : Form
    {
        private List<int[]> bigDataIn = new List<int[]>();
        private int chartWidth = 128;
        private int chartHeight = 4096;
        private int tlmBlockSize = 65536;

        private void chartInit()
        {
            int[] chartEnum = new int[128];

            chartShow.ChartAreas[0].AxisY.Minimum = 0;
            chartShow.ChartAreas[0].AxisY.Maximum = chartHeight;
            chartShow.ChartAreas[0].AxisY.Interval = 128;
            chartShow.ChartAreas[0].AxisX.Minimum = 0;
            chartShow.ChartAreas[0].AxisX.Maximum = chartWidth;
            chartShow.ChartAreas[0].AxisX.Interval = 16;
            chartShow.Series["Series1"].IsVisibleInLegend = false;
            chartShow.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartShow.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartShow.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartShow.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chartShow.ChartAreas[0].CursorX.IsUserEnabled = true;
            chartShow.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chartShow.ChartAreas[0].CursorX.SelectionColor = Color.LightGray;
            for (int i = 0; i < chartWidth; i++)
            {
                chartEnum[i] = i;
                chartShow.Series["Series1"].Points.AddXY(chartEnum[i], 0);
            }

        }
        public frmMain()
        {
            InitializeComponent();
            chartInit();
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
                using (FileStream fsSource = new FileStream(ofdSelectTLM.FileName, FileMode.Open, FileAccess.Read))
                {
                    /*
                     * Get file header
                     */
                    byte[] header = new byte[256];
                    for (int i = 0; i < 256; i++)
                    header[i] = (byte)fsSource.ReadByte();
                    string[] args;
                    args = Encoding.Default.GetString(header).Split('.');
                    foreach (var item in args)
                    {
                        tbHeader.AppendText(item + "\r\n");
                    }

                    /*
                     * Get cycle values (without 32 byte header)
                     */
                    int startPtr = 256 + 32;
                    int endPtr = tlmBlockSize + startPtr;

                    while (endPtr < fsSource.Length)
                    {
                        int[] body = new int[tlmBlockSize / 2];
                        for (int i = startPtr; i < endPtr; i += 2)
                        {
                            body[(i - startPtr) / 2] = (byte)fsSource.ReadByte();
                            body[(i - startPtr) / 2] += ((byte)fsSource.ReadByte() << 8);
                        }
                        bigDataIn.Add(body);
                        startPtr = endPtr + 32;
                        endPtr += tlmBlockSize + 32;
                        for (int i = 0; i < 32; i++)
                            fsSource.ReadByte();
                    }
                    /*
                     * enable timer to show values
                     */
                    for (int i = 16; i < bigDataIn[0].Length; i++)
                    {
                        if ((i % 8 == 0) && (i != 16))
                        {
                            rtbMemoshka.AppendText("\r\n");
                        }
                        rtbMemoshka.AppendText(bigDataIn[0][i].ToString() + "\t");
                    }
                    tmrShow.Enabled = true;

                }
            }
        }

        private void tmrShow_Tick(object sender, EventArgs e)
        {
            //foreach (var cycle in bigDataIn)
            //{
                int cntGrp = 0;
                int[] chartEnum = new int[1024];
                int[] group = new int[1024];

                for (int i = 0; i < group.Length; i++)
                {
                    group[i] = bigDataIn[0][i*cntGrp];// cycle[i*cntGrp];
                }
                cntGrp++;

                for (int i = 0; i < 128; i++)
                {
                    chartEnum[i] = i;
                    chartShow.Series["Series1"].Points.AddXY(chartEnum[i], group[i]);
                }
            //}
        }
    }
}
