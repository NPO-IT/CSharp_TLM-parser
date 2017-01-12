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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.rtbMemoshka = new System.Windows.Forms.RichTextBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.tbHeader = new System.Windows.Forms.TextBox();
            this.lbCycles = new System.Windows.Forms.ListBox();
            this.pbMain = new System.Windows.Forms.ProgressBar();
            this.lbDigital = new System.Windows.Forms.ListBox();
            this.rtbD0 = new System.Windows.Forms.RichTextBox();
            this.rtbD1 = new System.Windows.Forms.RichTextBox();
            this.rtbD2 = new System.Windows.Forms.RichTextBox();
            this.rtbD3 = new System.Windows.Forms.RichTextBox();
            this.cHisto = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cDia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnShowGraphic = new System.Windows.Forms.Button();
            this.tmrDelay = new System.Windows.Forms.Timer(this.components);
            this.tbTest = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cHisto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cDia)).BeginInit();
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
            // cHisto
            // 
            chartArea5.Name = "ChartArea1";
            this.cHisto.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.cHisto.Legends.Add(legend5);
            this.cHisto.Location = new System.Drawing.Point(12, 41);
            this.cHisto.Name = "cHisto";
            this.cHisto.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series11.ChartArea = "ChartArea1";
            series11.IsValueShownAsLabel = true;
            series11.Legend = "Legend1";
            series11.LegendText = "12 bit data";
            series11.Name = "s12";
            series12.ChartArea = "ChartArea1";
            series12.IsValueShownAsLabel = true;
            series12.Legend = "Legend1";
            series12.LegendText = "8 bit data";
            series12.Name = "s08";
            series13.ChartArea = "ChartArea1";
            series13.IsValueShownAsLabel = true;
            series13.Legend = "Legend1";
            series13.LegendText = "Counters";
            series13.Name = "Series";
            this.cHisto.Series.Add(series11);
            this.cHisto.Series.Add(series12);
            this.cHisto.Series.Add(series13);
            this.cHisto.Size = new System.Drawing.Size(1155, 290);
            this.cHisto.TabIndex = 12;
            this.cHisto.Text = "histo";
            this.cHisto.Visible = false;
            // 
            // cDia
            // 
            chartArea6.Name = "ChartArea1";
            this.cDia.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.cDia.Legends.Add(legend6);
            this.cDia.Location = new System.Drawing.Point(12, 337);
            this.cDia.Name = "cDia";
            this.cDia.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series14.Legend = "Legend1";
            series14.Name = "Series12";
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series15.Legend = "Legend1";
            series15.Name = "Series8";
            this.cDia.Series.Add(series14);
            this.cDia.Series.Add(series15);
            this.cDia.Size = new System.Drawing.Size(1155, 300);
            this.cDia.TabIndex = 13;
            this.cDia.Text = "dia";
            this.cDia.Visible = false;
            // 
            // btnShowGraphic
            // 
            this.btnShowGraphic.Location = new System.Drawing.Point(1173, 337);
            this.btnShowGraphic.Name = "btnShowGraphic";
            this.btnShowGraphic.Size = new System.Drawing.Size(166, 79);
            this.btnShowGraphic.TabIndex = 14;
            this.btnShowGraphic.Text = "Show digital info sequentially";
            this.btnShowGraphic.UseVisualStyleBackColor = true;
            this.btnShowGraphic.Click += new System.EventHandler(this.btnShowGraphic_Click);
            // 
            // tmrDelay
            // 
            this.tmrDelay.Tick += new System.EventHandler(this.tmrDelay_Tick);
            // 
            // tbTest
            // 
            this.tbTest.Location = new System.Drawing.Point(1173, 290);
            this.tbTest.Name = "tbTest";
            this.tbTest.Size = new System.Drawing.Size(166, 20);
            this.tbTest.TabIndex = 15;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 640);
            this.Controls.Add(this.tbTest);
            this.Controls.Add(this.btnShowGraphic);
            this.Controls.Add(this.cDia);
            this.Controls.Add(this.cHisto);
            this.Controls.Add(this.rtbD3);
            this.Controls.Add(this.rtbD2);
            this.Controls.Add(this.rtbD1);
            this.Controls.Add(this.rtbD0);
            this.Controls.Add(this.lbDigital);
            this.Controls.Add(this.pbMain);
            this.Controls.Add(this.lbCycles);
            this.Controls.Add(this.tbHeader);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.rtbMemoshka);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMain";
            this.Text = "TLM Parser";
            ((System.ComponentModel.ISupportInitialize)(this.cHisto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cDia)).EndInit();
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
        private System.Windows.Forms.RichTextBox rtbD0;
        private System.Windows.Forms.RichTextBox rtbD1;
        private System.Windows.Forms.RichTextBox rtbD2;
        private System.Windows.Forms.RichTextBox rtbD3;
        private System.Windows.Forms.DataVisualization.Charting.Chart cHisto;
        private System.Windows.Forms.DataVisualization.Charting.Chart cDia;
        private System.Windows.Forms.Button btnShowGraphic;
        private System.Windows.Forms.Timer tmrDelay;
        private System.Windows.Forms.TextBox tbTest;
    }
}

