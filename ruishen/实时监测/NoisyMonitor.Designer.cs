namespace ruishen.实时监测
{
    partial class NoisyMonitor
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
            this.N_MainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Noisy_WaveformGraph2 = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.waveformPlot4 = new NationalInstruments.UI.WaveformPlot();
            this.xAxis2 = new NationalInstruments.UI.XAxis();
            this.yAxis2 = new NationalInstruments.UI.YAxis();
            this.Noisy_WaveformGraph3 = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.waveformPlot3 = new NationalInstruments.UI.WaveformPlot();
            this.xAxis3 = new NationalInstruments.UI.XAxis();
            this.yAxis3 = new NationalInstruments.UI.YAxis();
            this.Noisy_WaveformGraph1 = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.waveformPlot1 = new NationalInstruments.UI.WaveformPlot();
            this.xAxis1 = new NationalInstruments.UI.XAxis();
            this.yAxis1 = new NationalInstruments.UI.YAxis();
            this.Noisy_WaveformGraph4 = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.waveformPlot2 = new NationalInstruments.UI.WaveformPlot();
            this.xAxis4 = new NationalInstruments.UI.XAxis();
            this.yAxis4 = new NationalInstruments.UI.YAxis();
            this.ScatterGraph_tableLayoutpanel = new System.Windows.Forms.TableLayoutPanel();
            this.scatterGraph1 = new NationalInstruments.UI.WindowsForms.ScatterGraph();
            this.scatterPlot1 = new NationalInstruments.UI.ScatterPlot();
            this.xAxis5 = new NationalInstruments.UI.XAxis();
            this.yAxis5 = new NationalInstruments.UI.YAxis();
            this.scatterGraph2 = new NationalInstruments.UI.WindowsForms.ScatterGraph();
            this.scatterPlot2 = new NationalInstruments.UI.ScatterPlot();
            this.xAxis6 = new NationalInstruments.UI.XAxis();
            this.yAxis6 = new NationalInstruments.UI.YAxis();
            this.scatterGraph3 = new NationalInstruments.UI.WindowsForms.ScatterGraph();
            this.scatterPlot3 = new NationalInstruments.UI.ScatterPlot();
            this.xAxis7 = new NationalInstruments.UI.XAxis();
            this.yAxis7 = new NationalInstruments.UI.YAxis();
            this.scatterGraph4 = new NationalInstruments.UI.WindowsForms.ScatterGraph();
            this.scatterPlot4 = new NationalInstruments.UI.ScatterPlot();
            this.xAxis8 = new NationalInstruments.UI.XAxis();
            this.yAxis8 = new NationalInstruments.UI.YAxis();
            this.panel1 = new System.Windows.Forms.Panel();
            this.N_statistical = new DevComponents.DotNetBar.ButtonX();
            this.N_AWeighting = new DevComponents.DotNetBar.ButtonX();
            this.N_Octave = new DevComponents.DotNetBar.ButtonX();
            this.N_Frequency = new DevComponents.DotNetBar.ButtonX();
            this.N_Vioce = new DevComponents.DotNetBar.ButtonX();
            this.N_MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Noisy_WaveformGraph2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Noisy_WaveformGraph3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Noisy_WaveformGraph1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Noisy_WaveformGraph4)).BeginInit();
            this.ScatterGraph_tableLayoutpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scatterGraph1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scatterGraph2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scatterGraph3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scatterGraph4)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // N_MainPanel
            // 
            this.N_MainPanel.ColumnCount = 2;
            this.N_MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.N_MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.N_MainPanel.Controls.Add(this.Noisy_WaveformGraph2, 1, 0);
            this.N_MainPanel.Controls.Add(this.Noisy_WaveformGraph3, 0, 1);
            this.N_MainPanel.Controls.Add(this.Noisy_WaveformGraph1, 0, 0);
            this.N_MainPanel.Controls.Add(this.Noisy_WaveformGraph4, 1, 1);
            this.N_MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.N_MainPanel.Location = new System.Drawing.Point(289, 0);
            this.N_MainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.N_MainPanel.Name = "N_MainPanel";
            this.N_MainPanel.RowCount = 2;
            this.N_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.N_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.N_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.N_MainPanel.Size = new System.Drawing.Size(902, 785);
            this.N_MainPanel.TabIndex = 2;
            // 
            // Noisy_WaveformGraph2
            // 
            this.Noisy_WaveformGraph2.Border = NationalInstruments.UI.Border.ThickFrame3D;
            this.Noisy_WaveformGraph2.Caption = "声音信号(通道6)";
            this.Noisy_WaveformGraph2.CaptionFont = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Noisy_WaveformGraph2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Noisy_WaveformGraph2.Location = new System.Drawing.Point(455, 4);
            this.Noisy_WaveformGraph2.Margin = new System.Windows.Forms.Padding(4);
            this.Noisy_WaveformGraph2.Name = "Noisy_WaveformGraph2";
            this.Noisy_WaveformGraph2.PlotAreaBorder = NationalInstruments.UI.Border.ThinFrame3D;
            this.Noisy_WaveformGraph2.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot4});
            this.Noisy_WaveformGraph2.Size = new System.Drawing.Size(443, 384);
            this.Noisy_WaveformGraph2.TabIndex = 13;
            this.Noisy_WaveformGraph2.UseColorGenerator = true;
            this.Noisy_WaveformGraph2.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis2});
            this.Noisy_WaveformGraph2.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis2});
            // 
            // waveformPlot4
            // 
            this.waveformPlot4.FillToBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.waveformPlot4.XAxis = this.xAxis2;
            this.waveformPlot4.YAxis = this.yAxis2;
            // 
            // xAxis2
            // 
            this.xAxis2.BaseLineVisible = true;
            this.xAxis2.Caption = "Time/s";
            this.xAxis2.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // yAxis2
            // 
            this.yAxis2.BaseLineVisible = true;
            this.yAxis2.Caption = "Acceleration/g";
            this.yAxis2.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yAxis2.Range = new NationalInstruments.UI.Range(0D, 100D);
            // 
            // Noisy_WaveformGraph3
            // 
            this.Noisy_WaveformGraph3.Border = NationalInstruments.UI.Border.ThickFrame3D;
            this.Noisy_WaveformGraph3.Caption = "声音信号(通道7)";
            this.Noisy_WaveformGraph3.CaptionFont = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Noisy_WaveformGraph3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Noisy_WaveformGraph3.Location = new System.Drawing.Point(4, 396);
            this.Noisy_WaveformGraph3.Margin = new System.Windows.Forms.Padding(4);
            this.Noisy_WaveformGraph3.Name = "Noisy_WaveformGraph3";
            this.Noisy_WaveformGraph3.PlotAreaBorder = NationalInstruments.UI.Border.ThinFrame3D;
            this.Noisy_WaveformGraph3.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot3});
            this.Noisy_WaveformGraph3.Size = new System.Drawing.Size(443, 385);
            this.Noisy_WaveformGraph3.TabIndex = 12;
            this.Noisy_WaveformGraph3.UseColorGenerator = true;
            this.Noisy_WaveformGraph3.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis3});
            this.Noisy_WaveformGraph3.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis3});
            // 
            // waveformPlot3
            // 
            this.waveformPlot3.FillToBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.waveformPlot3.XAxis = this.xAxis3;
            this.waveformPlot3.YAxis = this.yAxis3;
            // 
            // xAxis3
            // 
            this.xAxis3.BaseLineVisible = true;
            this.xAxis3.Caption = "Time/s";
            this.xAxis3.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // yAxis3
            // 
            this.yAxis3.BaseLineVisible = true;
            this.yAxis3.Caption = "Acceleration/g";
            this.yAxis3.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yAxis3.Range = new NationalInstruments.UI.Range(0D, 120D);
            // 
            // Noisy_WaveformGraph1
            // 
            this.Noisy_WaveformGraph1.Border = NationalInstruments.UI.Border.ThickFrame3D;
            this.Noisy_WaveformGraph1.Caption = "声音信号(通道5)";
            this.Noisy_WaveformGraph1.CaptionFont = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Noisy_WaveformGraph1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Noisy_WaveformGraph1.Location = new System.Drawing.Point(4, 4);
            this.Noisy_WaveformGraph1.Margin = new System.Windows.Forms.Padding(4);
            this.Noisy_WaveformGraph1.Name = "Noisy_WaveformGraph1";
            this.Noisy_WaveformGraph1.PlotAreaBorder = NationalInstruments.UI.Border.ThinFrame3D;
            this.Noisy_WaveformGraph1.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot1});
            this.Noisy_WaveformGraph1.Size = new System.Drawing.Size(443, 384);
            this.Noisy_WaveformGraph1.TabIndex = 10;
            this.Noisy_WaveformGraph1.UseColorGenerator = true;
            this.Noisy_WaveformGraph1.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis1});
            this.Noisy_WaveformGraph1.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis1});
            // 
            // waveformPlot1
            // 
            this.waveformPlot1.FillToBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.waveformPlot1.XAxis = this.xAxis1;
            this.waveformPlot1.YAxis = this.yAxis1;
            // 
            // xAxis1
            // 
            this.xAxis1.BaseLineVisible = true;
            this.xAxis1.Caption = "Time/s";
            this.xAxis1.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // yAxis1
            // 
            this.yAxis1.BaseLineVisible = true;
            this.yAxis1.Caption = "Acceleration/g";
            this.yAxis1.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yAxis1.Range = new NationalInstruments.UI.Range(0D, 200D);
            // 
            // Noisy_WaveformGraph4
            // 
            this.Noisy_WaveformGraph4.Border = NationalInstruments.UI.Border.ThickFrame3D;
            this.Noisy_WaveformGraph4.Caption = "声音信号(通道8)";
            this.Noisy_WaveformGraph4.CaptionFont = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Noisy_WaveformGraph4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Noisy_WaveformGraph4.Location = new System.Drawing.Point(455, 396);
            this.Noisy_WaveformGraph4.Margin = new System.Windows.Forms.Padding(4);
            this.Noisy_WaveformGraph4.Name = "Noisy_WaveformGraph4";
            this.Noisy_WaveformGraph4.PlotAreaBorder = NationalInstruments.UI.Border.ThinFrame3D;
            this.Noisy_WaveformGraph4.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot2});
            this.Noisy_WaveformGraph4.Size = new System.Drawing.Size(443, 385);
            this.Noisy_WaveformGraph4.TabIndex = 11;
            this.Noisy_WaveformGraph4.UseColorGenerator = true;
            this.Noisy_WaveformGraph4.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis4});
            this.Noisy_WaveformGraph4.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis4});
            // 
            // waveformPlot2
            // 
            this.waveformPlot2.FillToBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.waveformPlot2.XAxis = this.xAxis4;
            this.waveformPlot2.YAxis = this.yAxis4;
            // 
            // xAxis4
            // 
            this.xAxis4.BaseLineVisible = true;
            this.xAxis4.Caption = "Time/s";
            this.xAxis4.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // yAxis4
            // 
            this.yAxis4.BaseLineVisible = true;
            this.yAxis4.Caption = "Acceleration/g";
            this.yAxis4.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yAxis4.Range = new NationalInstruments.UI.Range(0D, 120D);
            // 
            // ScatterGraph_tableLayoutpanel
            // 
            this.ScatterGraph_tableLayoutpanel.ColumnCount = 2;
            this.ScatterGraph_tableLayoutpanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ScatterGraph_tableLayoutpanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ScatterGraph_tableLayoutpanel.Controls.Add(this.scatterGraph1, 0, 0);
            this.ScatterGraph_tableLayoutpanel.Controls.Add(this.scatterGraph2, 1, 0);
            this.ScatterGraph_tableLayoutpanel.Controls.Add(this.scatterGraph3, 0, 1);
            this.ScatterGraph_tableLayoutpanel.Controls.Add(this.scatterGraph4, 1, 1);
            this.ScatterGraph_tableLayoutpanel.Location = new System.Drawing.Point(344, 28);
            this.ScatterGraph_tableLayoutpanel.Name = "ScatterGraph_tableLayoutpanel";
            this.ScatterGraph_tableLayoutpanel.RowCount = 2;
            this.ScatterGraph_tableLayoutpanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ScatterGraph_tableLayoutpanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ScatterGraph_tableLayoutpanel.Size = new System.Drawing.Size(311, 187);
            this.ScatterGraph_tableLayoutpanel.TabIndex = 3;
            this.ScatterGraph_tableLayoutpanel.Visible = false;
            // 
            // scatterGraph1
            // 
            this.scatterGraph1.Border = NationalInstruments.UI.Border.ThickFrame3D;
            this.scatterGraph1.Caption = "声音信号(通道5)";
            this.scatterGraph1.CaptionFont = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scatterGraph1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scatterGraph1.Location = new System.Drawing.Point(3, 3);
            this.scatterGraph1.Name = "scatterGraph1";
            this.scatterGraph1.PlotAreaBorder = NationalInstruments.UI.Border.ThinFrame3D;
            this.scatterGraph1.Plots.AddRange(new NationalInstruments.UI.ScatterPlot[] {
            this.scatterPlot1});
            this.scatterGraph1.Size = new System.Drawing.Size(149, 87);
            this.scatterGraph1.TabIndex = 0;
            this.scatterGraph1.UseColorGenerator = true;
            this.scatterGraph1.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis5});
            this.scatterGraph1.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis5});
            // 
            // scatterPlot1
            // 
            this.scatterPlot1.FillMode = NationalInstruments.UI.PlotFillMode.FillAndLines;
            this.scatterPlot1.LineStep = NationalInstruments.UI.LineStep.XYStep;
            this.scatterPlot1.XAxis = this.xAxis5;
            this.scatterPlot1.YAxis = this.yAxis5;
            // 
            // xAxis5
            // 
            this.xAxis5.BaseLineVisible = true;
            this.xAxis5.Caption = "Frequency/(Hz)";
            this.xAxis5.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xAxis5.ScaleType = NationalInstruments.UI.ScaleType.Logarithmic;
            // 
            // yAxis5
            // 
            this.yAxis5.BaseLineVisible = true;
            this.yAxis5.Caption = "SPL/dBA";
            this.yAxis5.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // scatterGraph2
            // 
            this.scatterGraph2.Border = NationalInstruments.UI.Border.ThickFrame3D;
            this.scatterGraph2.Caption = "声音信号(通道6)";
            this.scatterGraph2.CaptionFont = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scatterGraph2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scatterGraph2.Location = new System.Drawing.Point(158, 3);
            this.scatterGraph2.Name = "scatterGraph2";
            this.scatterGraph2.PlotAreaBorder = NationalInstruments.UI.Border.ThinFrame3D;
            this.scatterGraph2.Plots.AddRange(new NationalInstruments.UI.ScatterPlot[] {
            this.scatterPlot2});
            this.scatterGraph2.Size = new System.Drawing.Size(150, 87);
            this.scatterGraph2.TabIndex = 1;
            this.scatterGraph2.UseColorGenerator = true;
            this.scatterGraph2.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis6});
            this.scatterGraph2.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis6});
            // 
            // scatterPlot2
            // 
            this.scatterPlot2.FillMode = NationalInstruments.UI.PlotFillMode.FillAndLines;
            this.scatterPlot2.LineStep = NationalInstruments.UI.LineStep.XYStep;
            this.scatterPlot2.XAxis = this.xAxis6;
            this.scatterPlot2.YAxis = this.yAxis6;
            // 
            // xAxis6
            // 
            this.xAxis6.BaseLineVisible = true;
            this.xAxis6.Caption = "Frequency/(Hz)";
            this.xAxis6.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xAxis6.OriginLineVisible = true;
            this.xAxis6.ScaleType = NationalInstruments.UI.ScaleType.Logarithmic;
            // 
            // yAxis6
            // 
            this.yAxis6.BaseLineVisible = true;
            this.yAxis6.Caption = "SPL/dBA";
            this.yAxis6.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // scatterGraph3
            // 
            this.scatterGraph3.Border = NationalInstruments.UI.Border.ThickFrame3D;
            this.scatterGraph3.Caption = "声音信号(通道7)";
            this.scatterGraph3.CaptionFont = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scatterGraph3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scatterGraph3.Location = new System.Drawing.Point(3, 96);
            this.scatterGraph3.Name = "scatterGraph3";
            this.scatterGraph3.PlotAreaBorder = NationalInstruments.UI.Border.ThinFrame3D;
            this.scatterGraph3.Plots.AddRange(new NationalInstruments.UI.ScatterPlot[] {
            this.scatterPlot3});
            this.scatterGraph3.Size = new System.Drawing.Size(149, 88);
            this.scatterGraph3.TabIndex = 2;
            this.scatterGraph3.UseColorGenerator = true;
            this.scatterGraph3.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis7});
            this.scatterGraph3.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis7});
            // 
            // scatterPlot3
            // 
            this.scatterPlot3.FillMode = NationalInstruments.UI.PlotFillMode.FillAndLines;
            this.scatterPlot3.LineStep = NationalInstruments.UI.LineStep.XYStep;
            this.scatterPlot3.XAxis = this.xAxis7;
            this.scatterPlot3.YAxis = this.yAxis7;
            // 
            // xAxis7
            // 
            this.xAxis7.BaseLineVisible = true;
            this.xAxis7.Caption = "Frequency/(Hz)";
            this.xAxis7.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xAxis7.ScaleType = NationalInstruments.UI.ScaleType.Logarithmic;
            // 
            // yAxis7
            // 
            this.yAxis7.BaseLineVisible = true;
            this.yAxis7.Caption = "SPL/dBA";
            this.yAxis7.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // scatterGraph4
            // 
            this.scatterGraph4.Border = NationalInstruments.UI.Border.ThickFrame3D;
            this.scatterGraph4.Caption = "声音信号(通道8)";
            this.scatterGraph4.CaptionFont = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scatterGraph4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scatterGraph4.Location = new System.Drawing.Point(158, 96);
            this.scatterGraph4.Name = "scatterGraph4";
            this.scatterGraph4.PlotAreaBorder = NationalInstruments.UI.Border.ThinFrame3D;
            this.scatterGraph4.Plots.AddRange(new NationalInstruments.UI.ScatterPlot[] {
            this.scatterPlot4});
            this.scatterGraph4.Size = new System.Drawing.Size(150, 88);
            this.scatterGraph4.TabIndex = 3;
            this.scatterGraph4.UseColorGenerator = true;
            this.scatterGraph4.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis8});
            this.scatterGraph4.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis8});
            // 
            // scatterPlot4
            // 
            this.scatterPlot4.FillMode = NationalInstruments.UI.PlotFillMode.FillAndLines;
            this.scatterPlot4.LineStep = NationalInstruments.UI.LineStep.XYStep;
            this.scatterPlot4.XAxis = this.xAxis8;
            this.scatterPlot4.YAxis = this.yAxis8;
            // 
            // xAxis8
            // 
            this.xAxis8.BaseLineVisible = true;
            this.xAxis8.Caption = "Frequency/(Hz)";
            this.xAxis8.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xAxis8.ScaleType = NationalInstruments.UI.ScaleType.Logarithmic;
            // 
            // yAxis8
            // 
            this.yAxis8.BaseLineVisible = true;
            this.yAxis8.Caption = "SPL/dBA";
            this.yAxis8.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.N_statistical);
            this.panel1.Controls.Add(this.N_AWeighting);
            this.panel1.Controls.Add(this.N_Octave);
            this.panel1.Controls.Add(this.N_Frequency);
            this.panel1.Controls.Add(this.N_Vioce);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 785);
            this.panel1.TabIndex = 1;
            // 
            // N_statistical
            // 
            this.N_statistical.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.N_statistical.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.N_statistical.Font = new System.Drawing.Font("华文中宋", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.N_statistical.Location = new System.Drawing.Point(16, 541);
            this.N_statistical.Margin = new System.Windows.Forms.Padding(4);
            this.N_statistical.Name = "N_statistical";
            this.N_statistical.Size = new System.Drawing.Size(245, 62);
            this.N_statistical.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.N_statistical.TabIndex = 0;
            this.N_statistical.Text = "统计";
            this.N_statistical.TextColor = System.Drawing.Color.Black;
            this.N_statistical.Click += new System.EventHandler(this.N_statistical_Click);
            // 
            // N_AWeighting
            // 
            this.N_AWeighting.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.N_AWeighting.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.N_AWeighting.Font = new System.Drawing.Font("华文中宋", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.N_AWeighting.Location = new System.Drawing.Point(16, 420);
            this.N_AWeighting.Margin = new System.Windows.Forms.Padding(4);
            this.N_AWeighting.Name = "N_AWeighting";
            this.N_AWeighting.Size = new System.Drawing.Size(245, 62);
            this.N_AWeighting.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.N_AWeighting.TabIndex = 0;
            this.N_AWeighting.Text = "A计权";
            this.N_AWeighting.TextColor = System.Drawing.Color.Black;
            this.N_AWeighting.Click += new System.EventHandler(this.N_AWeighting_Click);
            // 
            // N_Octave
            // 
            this.N_Octave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.N_Octave.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.N_Octave.Font = new System.Drawing.Font("华文中宋", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.N_Octave.Location = new System.Drawing.Point(12, 303);
            this.N_Octave.Margin = new System.Windows.Forms.Padding(4);
            this.N_Octave.Name = "N_Octave";
            this.N_Octave.Size = new System.Drawing.Size(245, 62);
            this.N_Octave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.N_Octave.TabIndex = 0;
            this.N_Octave.Text = "倍频程";
            this.N_Octave.TextColor = System.Drawing.Color.Black;
            this.N_Octave.Click += new System.EventHandler(this.N_Octave_Click);
            // 
            // N_Frequency
            // 
            this.N_Frequency.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.N_Frequency.BackColor = System.Drawing.Color.Silver;
            this.N_Frequency.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.N_Frequency.Font = new System.Drawing.Font("华文中宋", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.N_Frequency.Location = new System.Drawing.Point(16, 184);
            this.N_Frequency.Margin = new System.Windows.Forms.Padding(4);
            this.N_Frequency.Name = "N_Frequency";
            this.N_Frequency.Size = new System.Drawing.Size(245, 62);
            this.N_Frequency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.N_Frequency.TabIndex = 0;
            this.N_Frequency.Text = "频谱";
            this.N_Frequency.TextColor = System.Drawing.Color.Black;
            this.N_Frequency.Click += new System.EventHandler(this.N_Frequency_Click);
            // 
            // N_Vioce
            // 
            this.N_Vioce.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.N_Vioce.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.N_Vioce.Font = new System.Drawing.Font("华文中宋", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.N_Vioce.Location = new System.Drawing.Point(16, 66);
            this.N_Vioce.Margin = new System.Windows.Forms.Padding(4);
            this.N_Vioce.Name = "N_Vioce";
            this.N_Vioce.Size = new System.Drawing.Size(245, 62);
            this.N_Vioce.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.N_Vioce.TabIndex = 0;
            this.N_Vioce.Text = "声音";
            this.N_Vioce.TextColor = System.Drawing.Color.Black;
            this.N_Vioce.Click += new System.EventHandler(this.N_Vioce_Click);
            // 
            // NoisyMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 785);
            this.Controls.Add(this.ScatterGraph_tableLayoutpanel);
            this.Controls.Add(this.N_MainPanel);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NoisyMonitor";
            this.Text = "NoisyMonitor";
            this.N_MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Noisy_WaveformGraph2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Noisy_WaveformGraph3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Noisy_WaveformGraph1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Noisy_WaveformGraph4)).EndInit();
            this.ScatterGraph_tableLayoutpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scatterGraph1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scatterGraph2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scatterGraph3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scatterGraph4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX N_AWeighting;
        private DevComponents.DotNetBar.ButtonX N_Octave;
        private DevComponents.DotNetBar.ButtonX N_Frequency;
        private DevComponents.DotNetBar.ButtonX N_Vioce;
        private System.Windows.Forms.TableLayoutPanel N_MainPanel;
        private NationalInstruments.UI.XAxis xAxis1;
        private NationalInstruments.UI.YAxis yAxis1;
        private NationalInstruments.UI.WaveformPlot waveformPlot3;
        private NationalInstruments.UI.XAxis xAxis3;
        private NationalInstruments.UI.YAxis yAxis3;
        private NationalInstruments.UI.WaveformPlot waveformPlot4;
        private NationalInstruments.UI.XAxis xAxis2;
        private NationalInstruments.UI.YAxis yAxis2;
        public NationalInstruments.UI.WindowsForms.WaveformGraph Noisy_WaveformGraph1;
        public NationalInstruments.UI.WindowsForms.WaveformGraph Noisy_WaveformGraph3;
        public NationalInstruments.UI.WindowsForms.WaveformGraph Noisy_WaveformGraph2;
        private NationalInstruments.UI.WaveformPlot waveformPlot1;
        public NationalInstruments.UI.WindowsForms.WaveformGraph Noisy_WaveformGraph4;
        private NationalInstruments.UI.WaveformPlot waveformPlot2;
        private NationalInstruments.UI.XAxis xAxis4;
        private NationalInstruments.UI.YAxis yAxis4;
        private DevComponents.DotNetBar.ButtonX N_statistical;
        private System.Windows.Forms.TableLayoutPanel ScatterGraph_tableLayoutpanel;
        public NationalInstruments.UI.WindowsForms.ScatterGraph scatterGraph1;
        private NationalInstruments.UI.ScatterPlot scatterPlot1;
        private NationalInstruments.UI.XAxis xAxis5;
        private NationalInstruments.UI.YAxis yAxis5;
        public NationalInstruments.UI.WindowsForms.ScatterGraph scatterGraph2;
        private NationalInstruments.UI.ScatterPlot scatterPlot2;
        private NationalInstruments.UI.XAxis xAxis6;
        private NationalInstruments.UI.YAxis yAxis6;
        public NationalInstruments.UI.WindowsForms.ScatterGraph scatterGraph3;
        private NationalInstruments.UI.ScatterPlot scatterPlot3;
        private NationalInstruments.UI.XAxis xAxis7;
        private NationalInstruments.UI.YAxis yAxis7;
        public NationalInstruments.UI.WindowsForms.ScatterGraph scatterGraph4;
        private NationalInstruments.UI.ScatterPlot scatterPlot4;
        private NationalInstruments.UI.XAxis xAxis8;
        private NationalInstruments.UI.YAxis yAxis8;
    }
}