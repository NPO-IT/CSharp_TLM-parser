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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.rtbMemoshka = new System.Windows.Forms.RichTextBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.tbHeader = new System.Windows.Forms.TextBox();
            this.tmrShow = new System.Windows.Forms.Timer(this.components);
            this.chartShow = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartShow)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbMemoshka
            // 
            this.rtbMemoshka.Location = new System.Drawing.Point(12, 380);
            this.rtbMemoshka.Name = "rtbMemoshka";
            this.rtbMemoshka.Size = new System.Drawing.Size(424, 248);
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
            this.tbHeader.Location = new System.Drawing.Point(442, 380);
            this.tbHeader.Multiline = true;
            this.tbHeader.Name = "tbHeader";
            this.tbHeader.Size = new System.Drawing.Size(189, 248);
            this.tbHeader.TabIndex = 2;
            // 
            // tmrShow
            // 
            this.tmrShow.Interval = 30;
            this.tmrShow.Tick += new System.EventHandler(this.tmrShow_Tick);
            // 
            // chartShow
            // 
            chartArea1.Name = "ChartArea1";
            this.chartShow.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartShow.Legends.Add(legend1);
            this.chartShow.Location = new System.Drawing.Point(12, 41);
            this.chartShow.Name = "chartShow";
            series1.ChartArea = "ChartArea1";
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartShow.Series.Add(series1);
            this.chartShow.Size = new System.Drawing.Size(619, 333);
            this.chartShow.TabIndex = 3;
            this.chartShow.Text = "chart1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 640);
            this.Controls.Add(this.chartShow);
            this.Controls.Add(this.tbHeader);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.rtbMemoshka);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMain";
            this.Text = "TLM Parser";
            ((System.ComponentModel.ISupportInitialize)(this.chartShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbMemoshka;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.TextBox tbHeader;
        private System.Windows.Forms.Timer tmrShow;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartShow;
    }
}

