namespace TLM_parser
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbMemoshka = new System.Windows.Forms.RichTextBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.tbHeader = new System.Windows.Forms.TextBox();
            this.lbCycles = new System.Windows.Forms.ListBox();
            this.pbMain = new System.Windows.Forms.ProgressBar();
            this.lbDigital = new System.Windows.Forms.ListBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.tbTest = new System.Windows.Forms.TextBox();
            this.rtbD0 = new System.Windows.Forms.RichTextBox();
            this.rtbD1 = new System.Windows.Forms.RichTextBox();
            this.rtbD2 = new System.Windows.Forms.RichTextBox();
            this.rtbD3 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbMemoshka
            // 
            this.rtbMemoshka.Location = new System.Drawing.Point(12, 41);
            this.rtbMemoshka.Name = "rtbMemoshka";
            this.rtbMemoshka.Size = new System.Drawing.Size(1155, 587);
            this.rtbMemoshka.TabIndex = 0;
            this.rtbMemoshka.Text = "";
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(12, 12);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 23);
            this.btnParse.TabIndex = 1;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // tbHeader
            // 
            this.tbHeader.Location = new System.Drawing.Point(1173, 422);
            this.tbHeader.Multiline = true;
            this.tbHeader.Name = "tbHeader";
            this.tbHeader.Size = new System.Drawing.Size(166, 206);
            this.tbHeader.TabIndex = 2;
            // 
            // lbCycles
            // 
            this.lbCycles.FormattingEnabled = true;
            this.lbCycles.Location = new System.Drawing.Point(1173, 12);
            this.lbCycles.Name = "lbCycles";
            this.lbCycles.Size = new System.Drawing.Size(166, 95);
            this.lbCycles.TabIndex = 3;
            this.lbCycles.SelectedIndexChanged += new System.EventHandler(this.lbCycles_SelectedIndexChanged);
            // 
            // pbMain
            // 
            this.pbMain.Location = new System.Drawing.Point(93, 12);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(1074, 23);
            this.pbMain.TabIndex = 4;
            // 
            // lbDigital
            // 
            this.lbDigital.FormattingEnabled = true;
            this.lbDigital.Location = new System.Drawing.Point(1173, 113);
            this.lbDigital.Name = "lbDigital";
            this.lbDigital.Size = new System.Drawing.Size(166, 147);
            this.lbDigital.TabIndex = 5;
            this.lbDigital.SelectedIndexChanged += new System.EventHandler(this.lbDigital_SelectedIndexChanged);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(1173, 266);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // tbTest
            // 
            this.tbTest.Location = new System.Drawing.Point(1173, 295);
            this.tbTest.Multiline = true;
            this.tbTest.Name = "tbTest";
            this.tbTest.Size = new System.Drawing.Size(166, 52);
            this.tbTest.TabIndex = 7;
            // 
            // rtbD0
            // 
            this.rtbD0.Location = new System.Drawing.Point(12, 41);
            this.rtbD0.Name = "rtbD0";
            this.rtbD0.Size = new System.Drawing.Size(578, 290);
            this.rtbD0.TabIndex = 8;
            this.rtbD0.Text = "";
            this.rtbD0.Visible = false;
            // 
            // rtbD1
            // 
            this.rtbD1.Location = new System.Drawing.Point(596, 41);
            this.rtbD1.Name = "rtbD1";
            this.rtbD1.Size = new System.Drawing.Size(571, 290);
            this.rtbD1.TabIndex = 9;
            this.rtbD1.Text = "";
            this.rtbD1.Visible = false;
            // 
            // rtbD2
            // 
            this.rtbD2.Location = new System.Drawing.Point(12, 337);
            this.rtbD2.Name = "rtbD2";
            this.rtbD2.Size = new System.Drawing.Size(578, 291);
            this.rtbD2.TabIndex = 10;
            this.rtbD2.Text = "";
            this.rtbD2.Visible = false;
            // 
            // rtbD3
            // 
            this.rtbD3.Location = new System.Drawing.Point(596, 337);
            this.rtbD3.Name = "rtbD3";
            this.rtbD3.Size = new System.Drawing.Size(571, 291);
            this.rtbD3.TabIndex = 11;
            this.rtbD3.Text = "";
            this.rtbD3.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 640);
            this.Controls.Add(this.rtbD3);
            this.Controls.Add(this.rtbD2);
            this.Controls.Add(this.rtbD1);
            this.Controls.Add(this.rtbD0);
            this.Controls.Add(this.tbTest);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lbDigital);
            this.Controls.Add(this.pbMain);
            this.Controls.Add(this.lbCycles);
            this.Controls.Add(this.tbHeader);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.rtbMemoshka);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMain";
            this.Text = "TLM Parser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbMemoshka;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.TextBox tbHeader;
        private System.Windows.Forms.ListBox lbCycles;
        private System.Windows.Forms.ProgressBar pbMain;
        private System.Windows.Forms.ListBox lbDigital;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox tbTest;
        private System.Windows.Forms.RichTextBox rtbD0;
        private System.Windows.Forms.RichTextBox rtbD1;
        private System.Windows.Forms.RichTextBox rtbD2;
        private System.Windows.Forms.RichTextBox rtbD3;
    }
}

