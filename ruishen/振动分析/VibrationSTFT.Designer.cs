namespace ruishen.振动分析
{
    partial class VibrationSTFT
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.intensityGraph2 = new NationalInstruments.UI.WindowsForms.IntensityGraph();
            this.colorScale1 = new NationalInstruments.UI.ColorScale();
            this.intensityPlot1 = new NationalInstruments.UI.IntensityPlot();
            this.intensityXAxis1 = new NationalInstruments.UI.IntensityXAxis();
            this.intensityYAxis1 = new NationalInstruments.UI.IntensityYAxis();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.slide1 = new NationalInstruments.UI.WindowsForms.Slide();
            this.slide2 = new NationalInstruments.UI.WindowsForms.Slide();
            this.slide3 = new NationalInstruments.UI.WindowsForms.Slide();
            this.Transfer = new DevComponents.DotNetBar.ButtonX();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intensityGraph2)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slide1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slide2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slide3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.intensityGraph2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(258, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(886, 740);
            this.panel1.TabIndex = 1;
            // 
            // intensityGraph2
            // 
            this.intensityGraph2.Border = NationalInstruments.UI.Border.Etched;
            this.intensityGraph2.Caption = "瀑布图";
            this.intensityGraph2.ColorScales.AddRange(new NationalInstruments.UI.ColorScale[] {
            this.colorScale1});
            this.intensityGraph2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.intensityGraph2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.intensityGraph2.Location = new System.Drawing.Point(0, 0);
            this.intensityGraph2.Name = "intensityGraph2";
            this.intensityGraph2.Plots.AddRange(new NationalInstruments.UI.IntensityPlot[] {
            this.intensityPlot1});
            this.intensityGraph2.Size = new System.Drawing.Size(886, 740);
            this.intensityGraph2.TabIndex = 2;
            this.intensityGraph2.XAxes.AddRange(new NationalInstruments.UI.IntensityXAxis[] {
            this.intensityXAxis1});
            this.intensityGraph2.YAxes.AddRange(new NationalInstruments.UI.IntensityYAxis[] {
            this.intensityYAxis1});
            // 
            // colorScale1
            // 
            this.colorScale1.ColorMap.AddRange(new NationalInstruments.UI.ColorMapEntry[] {
            new NationalInstruments.UI.ColorMapEntry(2.5D, System.Drawing.Color.Aqua),
            new NationalInstruments.UI.ColorMapEntry(5D, System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(64)))))),
            new NationalInstruments.UI.ColorMapEntry(7.5D, System.Drawing.Color.Yellow)});
            this.colorScale1.HighColor = System.Drawing.Color.Red;
            this.colorScale1.LowColor = System.Drawing.Color.Blue;
            // 
            // intensityPlot1
            // 
            this.intensityPlot1.ColorScale = this.colorScale1;
            this.intensityPlot1.SmoothUpdates = true;
            this.intensityPlot1.XAxis = this.intensityXAxis1;
            this.intensityPlot1.YAxis = this.intensityYAxis1;
            // 
            // intensityXAxis1
            // 
            this.intensityXAxis1.Caption = "Time(s)";
            this.intensityXAxis1.Mode = NationalInstruments.UI.IntensityAxisMode.Fixed;
            // 
            // intensityYAxis1
            // 
            this.intensityYAxis1.Caption = "Frequency（Hz）";
            this.intensityYAxis1.Mode = NationalInstruments.UI.IntensityAxisMode.Fixed;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.slide1);
            this.flowLayoutPanel1.Controls.Add(this.slide2);
            this.flowLayoutPanel1.Controls.Add(this.slide3);
            this.flowLayoutPanel1.Controls.Add(this.Transfer);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(258, 740);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // slide1
            // 
            this.slide1.Caption = "Time";
            this.slide1.Location = new System.Drawing.Point(3, 3);
            this.slide1.Name = "slide1";
            this.slide1.Size = new System.Drawing.Size(93, 350);
            this.slide1.TabIndex = 0;
            // 
            // slide2
            // 
            this.slide2.Caption = "Frequency";
            this.slide2.Location = new System.Drawing.Point(102, 3);
            this.slide2.Name = "slide2";
            this.slide2.Size = new System.Drawing.Size(93, 350);
            this.slide2.TabIndex = 1;
            // 
            // slide3
            // 
            this.slide3.Caption = "Z";
            this.slide3.Location = new System.Drawing.Point(3, 359);
            this.slide3.Name = "slide3";
            this.slide3.Size = new System.Drawing.Size(92, 397);
            this.slide3.TabIndex = 2;
            // 
            // Transfer
            // 
            this.Transfer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Transfer.BackColor = System.Drawing.Color.Cyan;
            this.Transfer.Location = new System.Drawing.Point(101, 359);
            this.Transfer.Name = "Transfer";
            this.Transfer.Size = new System.Drawing.Size(75, 190);
            this.Transfer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Transfer.TabIndex = 3;
            this.Transfer.Text = "转换";
            this.Transfer.Click += new System.EventHandler(this.Transfer_Click);
            // 
            // VibrationSTFT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 740);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "VibrationSTFT";
            this.Text = "STFT";
            this.Load += new System.EventHandler(this.STFT_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.intensityGraph2)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.slide1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slide2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slide3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private NationalInstruments.UI.WindowsForms.IntensityGraph intensityGraph2;
        private NationalInstruments.UI.ColorScale colorScale1;
        private NationalInstruments.UI.IntensityPlot intensityPlot1;
        private NationalInstruments.UI.IntensityXAxis intensityXAxis1;
        private NationalInstruments.UI.IntensityYAxis intensityYAxis1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private NationalInstruments.UI.WindowsForms.Slide slide1;
        private NationalInstruments.UI.WindowsForms.Slide slide2;
        private NationalInstruments.UI.WindowsForms.Slide slide3;
        private DevComponents.DotNetBar.ButtonX Transfer;
    }
}