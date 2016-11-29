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
                using (FileStream fsSource = new FileStream(ofdSelectTLM.FileName, FileMode.Open, FileAccess.Read))
                {
                    /*
                     * Get file header
                     */
                    byte[] header = new byte[256];
                    for (int i = 0; i < 256; i++)
                        header[i] = (byte)fsSource.ReadByte();
                    tbHeader.Text = Encoding.Default.GetString(header);

                    int startPtr = 256;
                    int endPtr = 65792;
                    int[] body = new int[32768];
                    /*
                     * Get first cycle values (with 32 byte header)
                     */
                    for (int i = startPtr; i < endPtr; i+=2)
                    {
                        body[(i - startPtr)/2] = (byte)fsSource.ReadByte();
                        body[(i - startPtr)/2] += ((byte)fsSource.ReadByte() << 8);
                    }
                    /*
                     * Print first cycle values (without 32 byte header)
                     */
                    for (int i = 16; i < body.Length; i++)
                    {
                        if ((i % 16 == 0) && (i != 16))
                        {
                            rtbMemoshka.AppendText("\r\n");
                        }
                        rtbMemoshka.AppendText(body[i].ToString() + "\t");
                    }


                }
            }
        }
    }
}
