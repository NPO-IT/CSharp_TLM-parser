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
                            body[(i - startPtr) / 2] = (body[(i - startPtr) / 2] >> 1) & 0x3F;
                        }
                        lbCycles.Items.Add(String.Format("Cycle #{0}", bigDataIn.Count + 1));
                        bigDataIn.Add(body);
                        startPtr = endPtr + 32;
                        endPtr += tlmBlockSize + 32;
                        for (int i = 0; i < 32; i++)
                            fsSource.ReadByte();
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
                {
                    rtbMemoshka.AppendText("\r\n");
                }
                rtbMemoshka.AppendText(bigDataIn[index][i].ToString() + "\t");
                progress += step;
                pbMain.Value = (int)progress;
            }
            pbMain.Value = 100;
            lbCycles.Enabled = true;
            btnPick.Enabled = true;
        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            int index;
            int shift;
            int.TryParse(lbCycles.GetItemText(lbCycles.SelectedItem).Split('#')[1], out index);
            int.TryParse(tbShift.Text, out shift);
            rtbMemoshka.Clear();
            for (int i = shift + 16; i < bigDataIn[index].Length; i+=32)
            {
                if (((i - (shift + 16)) % 256 == 0) && (i != (shift + 16)))
                {
                    rtbMemoshka.AppendText("\r\n");
                }
                rtbMemoshka.AppendText(bigDataIn[index][i].ToString() + "\t");
            }

        }
    }
}
