namespace Project41.HomeWork1
{
    partial class Forecast
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.lblNumberOfTournaments = new System.Windows.Forms.Label();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.checkBox_updateCoordinateGrid = new System.Windows.Forms.CheckBox();
            this.btnLoseAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(12, 12);
            this.trackBar.Maximum = 70;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(184, 45);
            this.trackBar.TabIndex = 0;
            this.trackBar.Value = 5;
            this.trackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            this.trackBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trackBar_KeyDown);
            // 
            // rtb
            // 
            this.rtb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb.Location = new System.Drawing.Point(12, 283);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(583, 107);
            this.rtb.TabIndex = 2;
            this.rtb.Text = "";
            // 
            // lblNumberOfTournaments
            // 
            this.lblNumberOfTournaments.AutoSize = true;
            this.lblNumberOfTournaments.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumberOfTournaments.Location = new System.Drawing.Point(202, 11);
            this.lblNumberOfTournaments.Name = "lblNumberOfTournaments";
            this.lblNumberOfTournaments.Size = new System.Drawing.Size(181, 18);
            this.lblNumberOfTournaments.TabIndex = 2;
            this.lblNumberOfTournaments.Text = "Number of tournaments: 5";
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Area3DStyle.WallWidth = 0;
            chartArea2.CursorX.LineColor = System.Drawing.Color.DarkGray;
            chartArea2.CursorY.LineColor = System.Drawing.Color.DarkGray;
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 89F;
            chartArea2.InnerPlotPosition.Width = 89F;
            chartArea2.InnerPlotPosition.X = 6F;
            chartArea2.InnerPlotPosition.Y = 6F;
            chartArea2.Name = "ChartArea1";
            chartArea2.ShadowColor = System.Drawing.Color.Silver;
            this.chart.ChartAreas.Add(chartArea2);
            this.chart.Location = new System.Drawing.Point(12, 33);
            this.chart.Name = "chart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Name = "Series1";
            series3.YValuesPerPoint = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Red;
            series4.Name = "Series2";
            this.chart.Series.Add(series3);
            this.chart.Series.Add(series4);
            this.chart.Size = new System.Drawing.Size(583, 244);
            this.chart.TabIndex = 1;
            this.chart.TabStop = false;
            // 
            // checkBox_updateCoordinateGrid
            // 
            this.checkBox_updateCoordinateGrid.AutoSize = true;
            this.checkBox_updateCoordinateGrid.Checked = true;
            this.checkBox_updateCoordinateGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_updateCoordinateGrid.Location = new System.Drawing.Point(389, 12);
            this.checkBox_updateCoordinateGrid.Name = "checkBox_updateCoordinateGrid";
            this.checkBox_updateCoordinateGrid.Size = new System.Drawing.Size(134, 17);
            this.checkBox_updateCoordinateGrid.TabIndex = 3;
            this.checkBox_updateCoordinateGrid.Text = "Update coordinate grid";
            this.checkBox_updateCoordinateGrid.UseVisualStyleBackColor = true;
            // 
            // btnLoseAll
            // 
            this.btnLoseAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoseAll.Location = new System.Drawing.Point(521, 4);
            this.btnLoseAll.Name = "btnLoseAll";
            this.btnLoseAll.Size = new System.Drawing.Size(75, 23);
            this.btnLoseAll.TabIndex = 4;
            this.btnLoseAll.Text = "Lose all";
            this.btnLoseAll.UseVisualStyleBackColor = true;
            this.btnLoseAll.Click += new System.EventHandler(this.btnLoseAll_Click);
            // 
            // Forecast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 402);
            this.Controls.Add(this.btnLoseAll);
            this.Controls.Add(this.checkBox_updateCoordinateGrid);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.lblNumberOfTournaments);
            this.Controls.Add(this.rtb);
            this.Controls.Add(this.trackBar);
            this.Name = "Forecast";
            this.Text = "Prognostication";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.Label lblNumberOfTournaments;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.CheckBox checkBox_updateCoordinateGrid;
        private System.Windows.Forms.Button btnLoseAll;
    }
}