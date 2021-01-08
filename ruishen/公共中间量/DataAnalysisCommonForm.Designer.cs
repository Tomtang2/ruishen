namespace ruishen.公共中间量
{
    partial class DataAnalysisCommonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataAnalysisCommonForm));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.sampleWaveformGraph = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.cursor = new NationalInstruments.UI.XYCursor();
            this.plot = new NationalInstruments.UI.WaveformPlot();
            this.xAxis = new NationalInstruments.UI.XAxis();
            this.yAxis = new NationalInstruments.UI.YAxis();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.cursorFreeLabel = new System.Windows.Forms.Label();
            this.cursorLockedLabel = new System.Windows.Forms.Label();
            this.cursorModeSwitch = new NationalInstruments.UI.WindowsForms.Switch();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.changeCursorIndexGroupBox = new System.Windows.Forms.GroupBox();
            this.changeCursorIndexLabel = new System.Windows.Forms.Label();
            this.cursorMoveNextButton = new System.Windows.Forms.Button();
            this.cursorMoveBackButton = new System.Windows.Forms.Button();
            this.changeCursorIndexNumericEdit = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.changeCursorPositionGroupBox = new System.Windows.Forms.GroupBox();
            this.changeYPositionLabel = new System.Windows.Forms.Label();
            this.changeXPositionLabel = new System.Windows.Forms.Label();
            this.setPositionButton = new System.Windows.Forms.Button();
            this.changeXPositionNumericEdit = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.changeYPositionNumericEdit = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.MusicPlayProcess = new System.Windows.Forms.Timer(this.components);
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampleWaveformGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cursor)).BeginInit();
            this.LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cursorModeSwitch)).BeginInit();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.changeCursorIndexGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changeCursorIndexNumericEdit)).BeginInit();
            this.changeCursorPositionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changeXPositionNumericEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeYPositionNumericEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.sampleWaveformGraph);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(930, 377);
            this.TopPanel.TabIndex = 0;
            // 
            // sampleWaveformGraph
            // 
            this.sampleWaveformGraph.Border = NationalInstruments.UI.Border.ThickFrame3D;
            this.sampleWaveformGraph.Caption = "Generated Data";
            this.sampleWaveformGraph.CaptionBackColor = System.Drawing.Color.Transparent;
            this.sampleWaveformGraph.Cursors.AddRange(new NationalInstruments.UI.XYCursor[] {
            this.cursor});
            this.sampleWaveformGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sampleWaveformGraph.Font = new System.Drawing.Font("华文中宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sampleWaveformGraph.Location = new System.Drawing.Point(0, 0);
            this.sampleWaveformGraph.Name = "sampleWaveformGraph";
            this.sampleWaveformGraph.PlotAreaBorder = NationalInstruments.UI.Border.ThinFrame3D;
            this.sampleWaveformGraph.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.plot});
            this.sampleWaveformGraph.Size = new System.Drawing.Size(930, 377);
            this.sampleWaveformGraph.TabIndex = 1;
            this.sampleWaveformGraph.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis});
            this.sampleWaveformGraph.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis});
            // 
            // cursor
            // 
            this.cursor.Plot = this.plot;
            this.cursor.AfterMove += new NationalInstruments.UI.AfterMoveXYCursorEventHandler(this.cursor_AfterMove);
            // 
            // plot
            // 
            this.plot.XAxis = this.xAxis;
            this.plot.YAxis = this.yAxis;
            // 
            // xAxis
            // 
            this.xAxis.Caption = "Time/s";
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.cursorFreeLabel);
            this.LeftPanel.Controls.Add(this.cursorLockedLabel);
            this.LeftPanel.Controls.Add(this.cursorModeSwitch);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 377);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(200, 379);
            this.LeftPanel.TabIndex = 1;
            // 
            // cursorFreeLabel
            // 
            this.cursorFreeLabel.Location = new System.Drawing.Point(60, 152);
            this.cursorFreeLabel.Name = "cursorFreeLabel";
            this.cursorFreeLabel.Size = new System.Drawing.Size(80, 23);
            this.cursorFreeLabel.TabIndex = 6;
            this.cursorFreeLabel.Text = "禁用光标索引";
            this.cursorFreeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cursorLockedLabel
            // 
            this.cursorLockedLabel.Location = new System.Drawing.Point(60, 16);
            this.cursorLockedLabel.Name = "cursorLockedLabel";
            this.cursorLockedLabel.Size = new System.Drawing.Size(80, 23);
            this.cursorLockedLabel.TabIndex = 5;
            this.cursorLockedLabel.Text = "自由";
            this.cursorLockedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cursorModeSwitch
            // 
            this.cursorModeSwitch.Location = new System.Drawing.Point(60, 40);
            this.cursorModeSwitch.Name = "cursorModeSwitch";
            this.cursorModeSwitch.Size = new System.Drawing.Size(80, 112);
            this.cursorModeSwitch.SwitchStyle = NationalInstruments.UI.SwitchStyle.VerticalToggle3D;
            this.cursorModeSwitch.TabIndex = 4;
            this.cursorModeSwitch.Value = true;
            this.cursorModeSwitch.StateChanged += new NationalInstruments.UI.ActionEventHandler(this.cursorModeSwitch_StateChanged);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.axWindowsMediaPlayer1);
            this.MainPanel.Controls.Add(this.changeCursorIndexGroupBox);
            this.MainPanel.Controls.Add(this.changeCursorPositionGroupBox);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(200, 377);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(730, 379);
            this.MainPanel.TabIndex = 2;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(34, 168);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(236, 32);
            this.axWindowsMediaPlayer1.TabIndex = 8;
            this.axWindowsMediaPlayer1.Enter += new System.EventHandler(this.axWindowsMediaPlayer1_Enter);
            // 
            // changeCursorIndexGroupBox
            // 
            this.changeCursorIndexGroupBox.Controls.Add(this.changeCursorIndexLabel);
            this.changeCursorIndexGroupBox.Controls.Add(this.cursorMoveNextButton);
            this.changeCursorIndexGroupBox.Controls.Add(this.cursorMoveBackButton);
            this.changeCursorIndexGroupBox.Controls.Add(this.changeCursorIndexNumericEdit);
            this.changeCursorIndexGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.changeCursorIndexGroupBox.Location = new System.Drawing.Point(365, 53);
            this.changeCursorIndexGroupBox.Name = "changeCursorIndexGroupBox";
            this.changeCursorIndexGroupBox.Size = new System.Drawing.Size(312, 64);
            this.changeCursorIndexGroupBox.TabIndex = 6;
            this.changeCursorIndexGroupBox.TabStop = false;
            this.changeCursorIndexGroupBox.Text = "改变光标索引";
            // 
            // changeCursorIndexLabel
            // 
            this.changeCursorIndexLabel.Location = new System.Drawing.Point(16, 24);
            this.changeCursorIndexLabel.Name = "changeCursorIndexLabel";
            this.changeCursorIndexLabel.Size = new System.Drawing.Size(64, 23);
            this.changeCursorIndexLabel.TabIndex = 2;
            this.changeCursorIndexLabel.Text = "Index:";
            this.changeCursorIndexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cursorMoveNextButton
            // 
            this.cursorMoveNextButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cursorMoveNextButton.Location = new System.Drawing.Point(240, 24);
            this.cursorMoveNextButton.Name = "cursorMoveNextButton";
            this.cursorMoveNextButton.Size = new System.Drawing.Size(64, 23);
            this.cursorMoveNextButton.TabIndex = 2;
            this.cursorMoveNextButton.Text = "下一个 >>";
            this.cursorMoveNextButton.Click += new System.EventHandler(this.cursorMoveNextButton_Click);
            // 
            // cursorMoveBackButton
            // 
            this.cursorMoveBackButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cursorMoveBackButton.Location = new System.Drawing.Point(168, 24);
            this.cursorMoveBackButton.Name = "cursorMoveBackButton";
            this.cursorMoveBackButton.Size = new System.Drawing.Size(64, 23);
            this.cursorMoveBackButton.TabIndex = 1;
            this.cursorMoveBackButton.Text = "<< 上一个";
            this.cursorMoveBackButton.Click += new System.EventHandler(this.cursorMoveBackButton_Click);
            // 
            // changeCursorIndexNumericEdit
            // 
            this.changeCursorIndexNumericEdit.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(0);
            this.changeCursorIndexNumericEdit.Location = new System.Drawing.Point(88, 24);
            this.changeCursorIndexNumericEdit.Name = "changeCursorIndexNumericEdit";
            this.changeCursorIndexNumericEdit.OutOfRangeMode = NationalInstruments.UI.NumericOutOfRangeMode.CoerceToRange;
            this.changeCursorIndexNumericEdit.Size = new System.Drawing.Size(72, 21);
            this.changeCursorIndexNumericEdit.TabIndex = 0;
            this.changeCursorIndexNumericEdit.Value = 1D;
            this.changeCursorIndexNumericEdit.AfterChangeValue += new NationalInstruments.UI.AfterChangeNumericValueEventHandler(this.changeCursorIndexNumericEdit_AfterChangeValue);
            // 
            // changeCursorPositionGroupBox
            // 
            this.changeCursorPositionGroupBox.Controls.Add(this.changeYPositionLabel);
            this.changeCursorPositionGroupBox.Controls.Add(this.changeXPositionLabel);
            this.changeCursorPositionGroupBox.Controls.Add(this.setPositionButton);
            this.changeCursorPositionGroupBox.Controls.Add(this.changeXPositionNumericEdit);
            this.changeCursorPositionGroupBox.Controls.Add(this.changeYPositionNumericEdit);
            this.changeCursorPositionGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.changeCursorPositionGroupBox.Location = new System.Drawing.Point(34, 40);
            this.changeCursorPositionGroupBox.Name = "changeCursorPositionGroupBox";
            this.changeCursorPositionGroupBox.Size = new System.Drawing.Size(312, 88);
            this.changeCursorPositionGroupBox.TabIndex = 5;
            this.changeCursorPositionGroupBox.TabStop = false;
            this.changeCursorPositionGroupBox.Text = "更改光标位置";
            // 
            // changeYPositionLabel
            // 
            this.changeYPositionLabel.Location = new System.Drawing.Point(16, 56);
            this.changeYPositionLabel.Name = "changeYPositionLabel";
            this.changeYPositionLabel.Size = new System.Drawing.Size(64, 23);
            this.changeYPositionLabel.TabIndex = 3;
            this.changeYPositionLabel.Text = "Y Position:";
            this.changeYPositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // changeXPositionLabel
            // 
            this.changeXPositionLabel.Location = new System.Drawing.Point(16, 24);
            this.changeXPositionLabel.Name = "changeXPositionLabel";
            this.changeXPositionLabel.Size = new System.Drawing.Size(64, 23);
            this.changeXPositionLabel.TabIndex = 2;
            this.changeXPositionLabel.Text = "X Position:";
            this.changeXPositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // setPositionButton
            // 
            this.setPositionButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.setPositionButton.Location = new System.Drawing.Point(168, 40);
            this.setPositionButton.Name = "setPositionButton";
            this.setPositionButton.Size = new System.Drawing.Size(136, 23);
            this.setPositionButton.TabIndex = 2;
            this.setPositionButton.Text = "放置光标";
            this.setPositionButton.Click += new System.EventHandler(this.setPositionButton_Click);
            // 
            // changeXPositionNumericEdit
            // 
            this.changeXPositionNumericEdit.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(3);
            this.changeXPositionNumericEdit.Location = new System.Drawing.Point(88, 24);
            this.changeXPositionNumericEdit.Name = "changeXPositionNumericEdit";
            this.changeXPositionNumericEdit.OutOfRangeMode = NationalInstruments.UI.NumericOutOfRangeMode.CoerceToRange;
            this.changeXPositionNumericEdit.Size = new System.Drawing.Size(72, 21);
            this.changeXPositionNumericEdit.TabIndex = 0;
            // 
            // changeYPositionNumericEdit
            // 
            this.changeYPositionNumericEdit.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(3);
            this.changeYPositionNumericEdit.Location = new System.Drawing.Point(88, 56);
            this.changeYPositionNumericEdit.Name = "changeYPositionNumericEdit";
            this.changeYPositionNumericEdit.OutOfRangeMode = NationalInstruments.UI.NumericOutOfRangeMode.CoerceToRange;
            this.changeYPositionNumericEdit.Size = new System.Drawing.Size(72, 21);
            this.changeYPositionNumericEdit.TabIndex = 1;
            // 
            // MusicPlayProcess
            // 
            this.MusicPlayProcess.Tick += new System.EventHandler(this.MusicPlayProcess_Tick);
            // 
            // DataAnalysisCommonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 756);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.TopPanel);
            this.Name = "DataAnalysisCommonForm";
            this.Text = "DataAnalysisCommonForm";
            this.Load += new System.EventHandler(this.DataAnalysisCommonForm_Load);
            this.TopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sampleWaveformGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cursor)).EndInit();
            this.LeftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cursorModeSwitch)).EndInit();
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.changeCursorIndexGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.changeCursorIndexNumericEdit)).EndInit();
            this.changeCursorPositionGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.changeXPositionNumericEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeYPositionNumericEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private NationalInstruments.UI.XYCursor cursor;
        private NationalInstruments.UI.YAxis yAxis;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Label cursorFreeLabel;
        private System.Windows.Forms.Label cursorLockedLabel;
        private NationalInstruments.UI.WindowsForms.Switch cursorModeSwitch;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.GroupBox changeCursorIndexGroupBox;
        private System.Windows.Forms.Label changeCursorIndexLabel;
        private System.Windows.Forms.Button cursorMoveNextButton;
        private System.Windows.Forms.Button cursorMoveBackButton;
        private NationalInstruments.UI.WindowsForms.NumericEdit changeCursorIndexNumericEdit;
        private System.Windows.Forms.GroupBox changeCursorPositionGroupBox;
        private System.Windows.Forms.Label changeYPositionLabel;
        private System.Windows.Forms.Label changeXPositionLabel;
        private System.Windows.Forms.Button setPositionButton;
        private NationalInstruments.UI.WindowsForms.NumericEdit changeXPositionNumericEdit;
        private NationalInstruments.UI.WindowsForms.NumericEdit changeYPositionNumericEdit;
        public NationalInstruments.UI.WindowsForms.WaveformGraph sampleWaveformGraph;
        public NationalInstruments.UI.WaveformPlot plot;
        public NationalInstruments.UI.XAxis xAxis;
        private System.Windows.Forms.Timer MusicPlayProcess;
        public AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}