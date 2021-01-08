namespace ruishen.实时监测
{
    partial class VibrationMonitor
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Vibration_WaveformGraph3 = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.waveformPlot4 = new NationalInstruments.UI.WaveformPlot();
            this.xAxis4 = new NationalInstruments.UI.XAxis();
            this.yAxis4 = new NationalInstruments.UI.YAxis();
            this.Vibration_WaveformGraph4 = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.waveformPlot3 = new NationalInstruments.UI.WaveformPlot();
            this.xAxis3 = new NationalInstruments.UI.XAxis();
            this.yAxis3 = new NationalInstruments.UI.YAxis();
            this.Vibration_WaveformGraph1 = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.waveformPlot1 = new NationalInstruments.UI.WaveformPlot();
            this.xAxis1 = new NationalInstruments.UI.XAxis();
            this.yAxis1 = new NationalInstruments.UI.YAxis();
            this.Vibration_WaveformGraph2 = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.waveformPlot2 = new NationalInstruments.UI.WaveformPlot();
            this.xAxis2 = new NationalInstruments.UI.XAxis();
            this.yAxis2 = new NationalInstruments.UI.YAxis();
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_statistical = new DevComponents.DotNetBar.ButtonX();
            this.B_FrequencySpectrum = new DevComponents.DotNetBar.ButtonX();
            this.B_Displacement = new DevComponents.DotNetBar.ButtonX();
            this.B_Velocity = new DevComponents.DotNetBar.ButtonX();
            this.B_AcceleratedSpeed = new DevComponents.DotNetBar.ButtonX();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Vibration_WaveformGraph3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vibration_WaveformGraph4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vibration_WaveformGraph1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vibration_WaveformGraph2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Vibration_WaveformGraph3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Vibration_WaveformGraph4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Vibration_WaveformGraph1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Vibration_WaveformGraph2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(289, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1230, 972);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // Vibration_WaveformGraph3
            // 
            this.Vibration_WaveformGraph3.Border = NationalInstruments.UI.Border.ThickFrame3D;
            this.Vibration_WaveformGraph3.Caption = "振动信号（通道3）";
            this.Vibration_WaveformGraph3.CaptionFont = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Vibration_WaveformGraph3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Vibration_WaveformGraph3.Location = new System.Drawing.Point(4, 490);
            this.Vibration_WaveformGraph3.Margin = new System.Windows.Forms.Padding(4);
            this.Vibration_WaveformGraph3.Name = "Vibration_WaveformGraph3";
            this.Vibration_WaveformGraph3.PlotAreaBorder = NationalInstruments.UI.Border.ThinFrame3D;
            this.Vibration_WaveformGraph3.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot4});
            this.Vibration_WaveformGraph3.Size = new System.Drawing.Size(607, 478);
            this.Vibration_WaveformGraph3.TabIndex = 12;
            this.Vibration_WaveformGraph3.UseColorGenerator = true;
            this.Vibration_WaveformGraph3.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis4});
            this.Vibration_WaveformGraph3.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis4});
            // 
            // waveformPlot4
            // 
            this.waveformPlot4.XAxis = this.xAxis4;
            this.waveformPlot4.YAxis = this.yAxis4;
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
            this.yAxis4.Caption = "acceleration/g";
            this.yAxis4.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // Vibration_WaveformGraph4
            // 
            this.Vibration_WaveformGraph4.Border = NationalInstruments.UI.Border.ThickFrame3D;
            this.Vibration_WaveformGraph4.Caption = "振动信号（通道4）";
            this.Vibration_WaveformGraph4.CaptionFont = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Vibration_WaveformGraph4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Vibration_WaveformGraph4.Location = new System.Drawing.Point(619, 490);
            this.Vibration_WaveformGraph4.Margin = new System.Windows.Forms.Padding(4);
            this.Vibration_WaveformGraph4.Name = "Vibration_WaveformGraph4";
            this.Vibration_WaveformGraph4.PlotAreaBorder = NationalInstruments.UI.Border.ThinFrame3D;
            this.Vibration_WaveformGraph4.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot3});
            this.Vibration_WaveformGraph4.Size = new System.Drawing.Size(607, 478);
            this.Vibration_WaveformGraph4.TabIndex = 11;
            this.Vibration_WaveformGraph4.UseColorGenerator = true;
            this.Vibration_WaveformGraph4.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis3});
            this.Vibration_WaveformGraph4.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis3});
            // 
            // waveformPlot3
            // 
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
            this.yAxis3.Caption = "acceleration/g";
            this.yAxis3.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // Vibration_WaveformGraph1
            // 
            this.Vibration_WaveformGraph1.Border = NationalInstruments.UI.Border.ThickFrame3D;
            this.Vibration_WaveformGraph1.Caption = "振动信号（通道1）";
            this.Vibration_WaveformGraph1.CaptionFont = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Vibration_WaveformGraph1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Vibration_WaveformGraph1.Location = new System.Drawing.Point(4, 4);
            this.Vibration_WaveformGraph1.Margin = new System.Windows.Forms.Padding(4);
            this.Vibration_WaveformGraph1.Name = "Vibration_WaveformGraph1";
            this.Vibration_WaveformGraph1.PlotAreaBorder = NationalInstruments.UI.Border.ThinFrame3D;
            this.Vibration_WaveformGraph1.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot1});
            this.Vibration_WaveformGraph1.Size = new System.Drawing.Size(607, 478);
            this.Vibration_WaveformGraph1.TabIndex = 9;
            this.Vibration_WaveformGraph1.UseColorGenerator = true;
            this.Vibration_WaveformGraph1.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis1});
            this.Vibration_WaveformGraph1.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis1});
            // 
            // waveformPlot1
            // 
            this.waveformPlot1.XAxis = this.xAxis1;
            this.waveformPlot1.YAxis = this.yAxis1;
            // 
            // xAxis1
            // 
            this.xAxis1.BaseLineVisible = true;
            this.xAxis1.Caption = "Time/s";
            this.xAxis1.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xAxis1.Range = new NationalInstruments.UI.Range(0D, 1D);
            // 
            // yAxis1
            // 
            this.yAxis1.BaseLineVisible = true;
            this.yAxis1.Caption = "acceleration/g";
            this.yAxis1.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yAxis1.Range = new NationalInstruments.UI.Range(0D, 100D);
            // 
            // Vibration_WaveformGraph2
            // 
            this.Vibration_WaveformGraph2.Border = NationalInstruments.UI.Border.ThickFrame3D;
            this.Vibration_WaveformGraph2.Caption = "振动信号（通道2）";
            this.Vibration_WaveformGraph2.CaptionFont = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Vibration_WaveformGraph2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Vibration_WaveformGraph2.ImmediateUpdates = true;
            this.Vibration_WaveformGraph2.Location = new System.Drawing.Point(619, 4);
            this.Vibration_WaveformGraph2.Margin = new System.Windows.Forms.Padding(4);
            this.Vibration_WaveformGraph2.Name = "Vibration_WaveformGraph2";
            this.Vibration_WaveformGraph2.PlotAreaBorder = NationalInstruments.UI.Border.ThinFrame3D;
            this.Vibration_WaveformGraph2.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot2});
            this.Vibration_WaveformGraph2.Size = new System.Drawing.Size(607, 478);
            this.Vibration_WaveformGraph2.TabIndex = 10;
            this.Vibration_WaveformGraph2.UseColorGenerator = true;
            this.Vibration_WaveformGraph2.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis2});
            this.Vibration_WaveformGraph2.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis2});
            // 
            // waveformPlot2
            // 
            this.waveformPlot2.XAxis = this.xAxis2;
            this.waveformPlot2.YAxis = this.yAxis2;
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
            this.yAxis2.Caption = "acceleration/g";
            this.yAxis2.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.B_statistical);
            this.panel1.Controls.Add(this.B_FrequencySpectrum);
            this.panel1.Controls.Add(this.B_Displacement);
            this.panel1.Controls.Add(this.B_Velocity);
            this.panel1.Controls.Add(this.B_AcceleratedSpeed);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 972);
            this.panel1.TabIndex = 0;
            // 
            // B_statistical
            // 
            this.B_statistical.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.B_statistical.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.B_statistical.Font = new System.Drawing.Font("华文中宋", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.B_statistical.Location = new System.Drawing.Point(16, 536);
            this.B_statistical.Margin = new System.Windows.Forms.Padding(4);
            this.B_statistical.Name = "B_statistical";
            this.B_statistical.Size = new System.Drawing.Size(245, 62);
            this.B_statistical.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.B_statistical.TabIndex = 1;
            this.B_statistical.Text = "统计";
            this.B_statistical.TextColor = System.Drawing.Color.Black;
            this.B_statistical.Click += new System.EventHandler(this.B_statistical_Click);
            // 
            // B_FrequencySpectrum
            // 
            this.B_FrequencySpectrum.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.B_FrequencySpectrum.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.B_FrequencySpectrum.Font = new System.Drawing.Font("华文中宋", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.B_FrequencySpectrum.Location = new System.Drawing.Point(16, 420);
            this.B_FrequencySpectrum.Margin = new System.Windows.Forms.Padding(4);
            this.B_FrequencySpectrum.Name = "B_FrequencySpectrum";
            this.B_FrequencySpectrum.Size = new System.Drawing.Size(245, 62);
            this.B_FrequencySpectrum.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.B_FrequencySpectrum.TabIndex = 0;
            this.B_FrequencySpectrum.Text = "频谱";
            this.B_FrequencySpectrum.TextColor = System.Drawing.Color.Black;
            this.B_FrequencySpectrum.Click += new System.EventHandler(this.B_FrequencySpectrum_Click);
            // 
            // B_Displacement
            // 
            this.B_Displacement.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.B_Displacement.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.B_Displacement.Enabled = false;
            this.B_Displacement.Font = new System.Drawing.Font("华文中宋", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.B_Displacement.Location = new System.Drawing.Point(16, 301);
            this.B_Displacement.Margin = new System.Windows.Forms.Padding(4);
            this.B_Displacement.Name = "B_Displacement";
            this.B_Displacement.Size = new System.Drawing.Size(245, 62);
            this.B_Displacement.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.B_Displacement.TabIndex = 0;
            this.B_Displacement.Text = "位移";
            this.B_Displacement.TextColor = System.Drawing.Color.Black;
            this.B_Displacement.Click += new System.EventHandler(this.B_Displacement_Click);
            // 
            // B_Velocity
            // 
            this.B_Velocity.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.B_Velocity.BackColor = System.Drawing.Color.Silver;
            this.B_Velocity.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.B_Velocity.Enabled = false;
            this.B_Velocity.Font = new System.Drawing.Font("华文中宋", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.B_Velocity.Location = new System.Drawing.Point(16, 184);
            this.B_Velocity.Margin = new System.Windows.Forms.Padding(4);
            this.B_Velocity.Name = "B_Velocity";
            this.B_Velocity.Size = new System.Drawing.Size(245, 62);
            this.B_Velocity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.B_Velocity.TabIndex = 0;
            this.B_Velocity.Text = "速度";
            this.B_Velocity.TextColor = System.Drawing.Color.Black;
            this.B_Velocity.Click += new System.EventHandler(this.B_Velocity_Click);
            // 
            // B_AcceleratedSpeed
            // 
            this.B_AcceleratedSpeed.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.B_AcceleratedSpeed.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.B_AcceleratedSpeed.Font = new System.Drawing.Font("华文中宋", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.B_AcceleratedSpeed.Location = new System.Drawing.Point(16, 66);
            this.B_AcceleratedSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.B_AcceleratedSpeed.Name = "B_AcceleratedSpeed";
            this.B_AcceleratedSpeed.Size = new System.Drawing.Size(245, 62);
            this.B_AcceleratedSpeed.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.B_AcceleratedSpeed.TabIndex = 0;
            this.B_AcceleratedSpeed.Text = "加速度";
            this.B_AcceleratedSpeed.TextColor = System.Drawing.Color.Black;
            this.B_AcceleratedSpeed.Click += new System.EventHandler(this.B_AcceleratedSpeed_Click);
            // 
            // VibrationMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1519, 972);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VibrationMonitor";
            this.Text = "振动监测";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Vibration_WaveformGraph3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vibration_WaveformGraph4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vibration_WaveformGraph1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vibration_WaveformGraph2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX B_FrequencySpectrum;
        private DevComponents.DotNetBar.ButtonX B_Displacement;
        private DevComponents.DotNetBar.ButtonX B_Velocity;
        private DevComponents.DotNetBar.ButtonX B_AcceleratedSpeed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private NationalInstruments.UI.WaveformPlot waveformPlot4;
        private NationalInstruments.UI.XAxis xAxis4;
        private NationalInstruments.UI.YAxis yAxis4;
        private NationalInstruments.UI.WaveformPlot waveformPlot3;
        private NationalInstruments.UI.XAxis xAxis3;
        private NationalInstruments.UI.YAxis yAxis3;
        private NationalInstruments.UI.WaveformPlot waveformPlot1;
        private NationalInstruments.UI.XAxis xAxis1;
        private NationalInstruments.UI.YAxis yAxis1;
        private NationalInstruments.UI.WaveformPlot waveformPlot2;
        private NationalInstruments.UI.XAxis xAxis2;
        private NationalInstruments.UI.YAxis yAxis2;
        public NationalInstruments.UI.WindowsForms.WaveformGraph Vibration_WaveformGraph1;
        public NationalInstruments.UI.WindowsForms.WaveformGraph Vibration_WaveformGraph3;
        public NationalInstruments.UI.WindowsForms.WaveformGraph Vibration_WaveformGraph4;
        public NationalInstruments.UI.WindowsForms.WaveformGraph Vibration_WaveformGraph2;
        private DevComponents.DotNetBar.ButtonX B_statistical;
    }
}