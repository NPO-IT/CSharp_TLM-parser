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
            this.btnPick = new System.Windows.Forms.Button();
            this.tbShift = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbMemoshka
            // 
            this.rtbMemoshka.Location = new System.Drawing.Point(44, 41);
            this.rtbMemoshka.Name = "rtbMemoshka";
            this.rtbMemoshka.Size = new System.Drawing.Size(449, 587);
            this.rtbMemoshka.TabIndex = 0;
            this.rtbMemoshka.Text = "";
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(44, 12);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 23);
            this.btnParse.TabIndex = 1;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // tbHeader
            // 
            this.tbHeader.Location = new System.Drawing.Point(499, 115);
            this.tbHeader.Multiline = true;
            this.tbHeader.Name = "tbHeader";
            this.tbHeader.Size = new System.Drawing.Size(166, 206);
            this.tbHeader.TabIndex = 2;
            // 
            // lbCycles
            // 
            this.lbCycles.FormattingEnabled = true;
            this.lbCycles.Location = new System.Drawing.Point(499, 12);
            this.lbCycles.Name = "lbCycles";
            this.lbCycles.Size = new System.Drawing.Size(166, 95);
            this.lbCycles.TabIndex = 3;
            this.lbCycles.SelectedIndexChanged += new System.EventHandler(this.lbCycles_SelectedIndexChanged);
            // 
            // pbMain
            // 
            this.pbMain.Location = new System.Drawing.Point(125, 12);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(368, 23);
            this.pbMain.TabIndex = 4;
            // 
            // btnPick
            // 
            this.btnPick.Enabled = false;
            this.btnPick.Location = new System.Drawing.Point(499, 325);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(100, 23);
            this.btnPick.TabIndex = 5;
            this.btnPick.Text = "Show N-th words";
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // tbShift
            // 
            this.tbShift.Location = new System.Drawing.Point(605, 328);
            this.tbShift.Name = "tbShift";
            this.tbShift.Size = new System.Drawing.Size(60, 20);
            this.tbShift.TabIndex = 6;
            this.tbShift.Text = "0";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 584);
            this.label1.TabIndex = 7;
            this.label1.Text = "1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 " +
    "31 32 33 34 35 36 37 38 39";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 640);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbShift);
            this.Controls.Add(this.btnPick);
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
        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.TextBox tbShift;
        private System.Windows.Forms.Label label1;
    }
}

