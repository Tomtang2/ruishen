namespace ruishen.振动分析
{
    partial class VirbratiomFrequencySpectrum
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
            this.VFS_MainPanel = new System.Windows.Forms.Panel();
            this.VFS_LeftPanel = new System.Windows.Forms.Panel();
            this.VFS_RightPanel = new System.Windows.Forms.Panel();
            this.VFS_DispalyWaveformGraph = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.waveformPlot1 = new NationalInstruments.UI.WaveformPlot();
            this.xAxis1 = new NationalInstruments.UI.XAxis();
            this.yAxis1 = new NationalInstruments.UI.YAxis();
            this.VFS_MainPanel.SuspendLayout();
            this.VFS_RightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VFS_DispalyWaveformGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // VFS_MainPanel
            // 
            this.VFS_MainPanel.Controls.Add(this.VFS_RightPanel);
            this.VFS_MainPanel.Controls.Add(this.VFS_LeftPanel);
            this.VFS_MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VFS_MainPanel.Location = new System.Drawing.Point(0, 0);
            this.VFS_MainPanel.Name = "VFS_MainPanel";
            this.VFS_MainPanel.Size = new System.Drawing.Size(891, 564);
            this.VFS_MainPanel.TabIndex = 0;
            // 
            // VFS_LeftPanel
            // 
            this.VFS_LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.VFS_LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.VFS_LeftPanel.Name = "VFS_LeftPanel";
            this.VFS_LeftPanel.Size = new System.Drawing.Size(262, 564);
            this.VFS_LeftPanel.TabIndex = 0;
            // 
            // VFS_RightPanel
            // 
            this.VFS_RightPanel.Controls.Add(this.VFS_DispalyWaveformGraph);
            this.VFS_RightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VFS_RightPanel.Location = new System.Drawing.Point(262, 0);
            this.VFS_RightPanel.Name = "VFS_RightPanel";
            this.VFS_RightPanel.Size = new System.Drawing.Size(629, 564);
            this.VFS_RightPanel.TabIndex = 1;
            // 
            // VFS_DispalyWaveformGraph
            // 
            this.VFS_DispalyWaveformGraph.Border = NationalInstruments.UI.Border.Etched;
            this.VFS_DispalyWaveformGraph.Caption = "数据展示";
            this.VFS_DispalyWaveformGraph.CaptionBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.VFS_DispalyWaveformGraph.CaptionFont = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VFS_DispalyWaveformGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VFS_DispalyWaveformGraph.Location = new System.Drawing.Point(0, 0);
            this.VFS_DispalyWaveformGraph.Name = "VFS_DispalyWaveformGraph";
            this.VFS_DispalyWaveformGraph.PlotAreaColor = System.Drawing.Color.White;
            this.VFS_DispalyWaveformGraph.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot1});
            this.VFS_DispalyWaveformGraph.Size = new System.Drawing.Size(629, 564);
            this.VFS_DispalyWaveformGraph.TabIndex = 11;
            this.VFS_DispalyWaveformGraph.UseColorGenerator = true;
            this.VFS_DispalyWaveformGraph.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis1});
            this.VFS_DispalyWaveformGraph.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis1});
            // 
            // waveformPlot1
            // 
            this.waveformPlot1.XAxis = this.xAxis1;
            this.waveformPlot1.YAxis = this.yAxis1;
            // 
            // xAxis1
            // 
            this.xAxis1.Caption = "Frequency/Hz";
            this.xAxis1.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xAxis1.Range = new NationalInstruments.UI.Range(0D, 1D);
            // 
            // yAxis1
            // 
            this.yAxis1.Caption = "acceleration/g";
            this.yAxis1.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // VirbratiomFrequencySpectrum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 564);
            this.Controls.Add(this.VFS_MainPanel);
            this.Name = "VirbratiomFrequencySpectrum";
            this.VFS_MainPanel.ResumeLayout(false);
            this.VFS_RightPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VFS_DispalyWaveformGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel VFS_MainPanel;
        private System.Windows.Forms.Panel VFS_RightPanel;
        private System.Windows.Forms.Panel VFS_LeftPanel;
        private NationalInstruments.UI.WaveformPlot waveformPlot1;
        private NationalInstruments.UI.XAxis xAxis1;
        private NationalInstruments.UI.YAxis yAxis1;
        public NationalInstruments.UI.WindowsForms.WaveformGraph VFS_DispalyWaveformGraph;
    }
}