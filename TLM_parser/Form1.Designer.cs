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
            this.SuspendLayout();
            // 
            // rtbMemoshka
            // 
            this.rtbMemoshka.Location = new System.Drawing.Point(12, 41);
            this.rtbMemoshka.Name = "rtbMemoshka";
            this.rtbMemoshka.Size = new System.Drawing.Size(824, 587);
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
            this.tbHeader.Location = new System.Drawing.Point(93, 14);
            this.tbHeader.Name = "tbHeader";
            this.tbHeader.Size = new System.Drawing.Size(739, 20);
            this.tbHeader.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 640);
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
    }
}

