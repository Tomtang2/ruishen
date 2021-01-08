namespace ruishen.声音分析
{
    partial class NoiseDataSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NDS_MainPanel = new System.Windows.Forms.Panel();
            this.NDS_RightPanel = new System.Windows.Forms.Panel();
            this.bdnInfo = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.gong = new System.Windows.Forms.ToolStripLabel();
            this.TotalPage = new System.Windows.Forms.ToolStripLabel();
            this.tiao = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.Page = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelPage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.DataSearchDataGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NDS_LeftPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.DS_Load = new DevComponents.DotNetBar.ButtonX();
            this.DS_Query = new DevComponents.DotNetBar.ButtonX();
            this.DS_EndTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.DS_StartTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.bdsInfo = new System.Windows.Forms.BindingSource(this.components);
            this.NDS_MainPanel.SuspendLayout();
            this.NDS_RightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdnInfo)).BeginInit();
            this.bdnInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSearchDataGrid)).BeginInit();
            this.NDS_LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_EndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_StartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // NDS_MainPanel
            // 
            this.NDS_MainPanel.Controls.Add(this.NDS_RightPanel);
            this.NDS_MainPanel.Controls.Add(this.NDS_LeftPanel);
            this.NDS_MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NDS_MainPanel.Location = new System.Drawing.Point(0, 0);
            this.NDS_MainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.NDS_MainPanel.Name = "NDS_MainPanel";
            this.NDS_MainPanel.Size = new System.Drawing.Size(1375, 1055);
            this.NDS_MainPanel.TabIndex = 0;
            // 
            // NDS_RightPanel
            // 
            this.NDS_RightPanel.BackColor = System.Drawing.Color.LightGray;
            this.NDS_RightPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NDS_RightPanel.Controls.Add(this.bdnInfo);
            this.NDS_RightPanel.Controls.Add(this.DataSearchDataGrid);
            this.NDS_RightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NDS_RightPanel.Location = new System.Drawing.Point(469, 0);
            this.NDS_RightPanel.Margin = new System.Windows.Forms.Padding(4);
            this.NDS_RightPanel.Name = "NDS_RightPanel";
            this.NDS_RightPanel.Size = new System.Drawing.Size(906, 1055);
            this.NDS_RightPanel.TabIndex = 1;
            // 
            // bdnInfo
            // 
            this.bdnInfo.AddNewItem = null;
            this.bdnInfo.CountItem = null;
            this.bdnInfo.DeleteItem = null;
            this.bdnInfo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bdnInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.toolStripTextBox1,
            this.toolStripLabel3,
            this.gong,
            this.TotalPage,
            this.tiao,
            this.toolStripLabel4,
            this.Page,
            this.toolStripLabel5,
            this.toolStripLabel6,
            this.toolStripLabelPage,
            this.toolStripLabel7});
            this.bdnInfo.Location = new System.Drawing.Point(0, 532);
            this.bdnInfo.MoveFirstItem = null;
            this.bdnInfo.MoveLastItem = null;
            this.bdnInfo.MoveNextItem = null;
            this.bdnInfo.MovePreviousItem = null;
            this.bdnInfo.Name = "bdnInfo";
            this.bdnInfo.PositionItem = null;
            this.bdnInfo.Size = new System.Drawing.Size(907, 28);
            this.bdnInfo.TabIndex = 1;
            this.bdnInfo.Text = "bindingNavigator1";
            this.bdnInfo.Visible = false;
            this.bdnInfo.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.bdnInfo_ItemClicked);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(54, 25);
            this.toolStripLabel1.Text = "上一页";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(54, 25);
            this.toolStripLabel2.Text = "下一页";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(133, 28);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(39, 25);
            this.toolStripLabel3.Text = "跳转";
            // 
            // gong
            // 
            this.gong.Name = "gong";
            this.gong.Size = new System.Drawing.Size(24, 25);
            this.gong.Text = "共";
            // 
            // TotalPage
            // 
            this.TotalPage.Name = "TotalPage";
            this.TotalPage.Size = new System.Drawing.Size(18, 25);
            this.TotalPage.Text = "0";
            // 
            // tiao
            // 
            this.tiao.Name = "tiao";
            this.tiao.Size = new System.Drawing.Size(24, 25);
            this.tiao.Text = "条";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(24, 25);
            this.toolStripLabel4.Text = "第";
            // 
            // Page
            // 
            this.Page.Name = "Page";
            this.Page.Size = new System.Drawing.Size(18, 25);
            this.Page.Text = "0";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(24, 25);
            this.toolStripLabel5.Text = "页";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(24, 25);
            this.toolStripLabel6.Text = "共";
            // 
            // toolStripLabelPage
            // 
            this.toolStripLabelPage.Name = "toolStripLabelPage";
            this.toolStripLabelPage.Size = new System.Drawing.Size(18, 25);
            this.toolStripLabelPage.Text = "0";
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(24, 25);
            this.toolStripLabel7.Text = "页";
            // 
            // DataSearchDataGrid
            // 
            this.DataSearchDataGrid.AllowUserToAddRows = false;
            this.DataSearchDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataSearchDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.DataSearchDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataSearchDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataSearchDataGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.DataSearchDataGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.DataSearchDataGrid.Location = new System.Drawing.Point(0, 0);
            this.DataSearchDataGrid.Margin = new System.Windows.Forms.Padding(4);
            this.DataSearchDataGrid.Name = "DataSearchDataGrid";
            this.DataSearchDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.DataSearchDataGrid.RowTemplate.Height = 23;
            this.DataSearchDataGrid.Size = new System.Drawing.Size(902, 624);
            this.DataSearchDataGrid.TabIndex = 0;
            this.DataSearchDataGrid.Visible = false;
            this.DataSearchDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataSearchDataGrid_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "选择项";
            this.Column1.Name = "Column1";
            this.Column1.Width = 58;
            // 
            // NDS_LeftPanel
            // 
            this.NDS_LeftPanel.BackColor = System.Drawing.Color.LightGray;
            this.NDS_LeftPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NDS_LeftPanel.Controls.Add(this.label1);
            this.NDS_LeftPanel.Controls.Add(this.comboBox1);
            this.NDS_LeftPanel.Controls.Add(this.DS_Load);
            this.NDS_LeftPanel.Controls.Add(this.DS_Query);
            this.NDS_LeftPanel.Controls.Add(this.DS_EndTime);
            this.NDS_LeftPanel.Controls.Add(this.DS_StartTime);
            this.NDS_LeftPanel.Controls.Add(this.labelX2);
            this.NDS_LeftPanel.Controls.Add(this.labelX1);
            this.NDS_LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.NDS_LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.NDS_LeftPanel.Margin = new System.Windows.Forms.Padding(4);
            this.NDS_LeftPanel.Name = "NDS_LeftPanel";
            this.NDS_LeftPanel.Size = new System.Drawing.Size(469, 1055);
            this.NDS_LeftPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "声音检测";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "5-左前轴承",
            "6-右前轴承",
            "7-左后轴承",
            "8-右后轴承"});
            this.comboBox1.Location = new System.Drawing.Point(132, 26);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(328, 31);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.Text = "5-左前轴承";
            // 
            // DS_Load
            // 
            this.DS_Load.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.DS_Load.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.DS_Load.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DS_Load.Location = new System.Drawing.Point(231, 450);
            this.DS_Load.Margin = new System.Windows.Forms.Padding(4);
            this.DS_Load.Name = "DS_Load";
            this.DS_Load.Size = new System.Drawing.Size(160, 60);
            this.DS_Load.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.DS_Load.TabIndex = 11;
            this.DS_Load.Text = "加载";
            this.DS_Load.Click += new System.EventHandler(this.DS_Load_Click);
            // 
            // DS_Query
            // 
            this.DS_Query.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.DS_Query.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.DS_Query.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DS_Query.Location = new System.Drawing.Point(37, 450);
            this.DS_Query.Margin = new System.Windows.Forms.Padding(4);
            this.DS_Query.Name = "DS_Query";
            this.DS_Query.Size = new System.Drawing.Size(160, 60);
            this.DS_Query.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.DS_Query.TabIndex = 10;
            this.DS_Query.Text = "查询";
            this.DS_Query.Click += new System.EventHandler(this.DS_Query_Click);
            // 
            // DS_EndTime
            // 
            this.DS_EndTime.AutoSelectDate = true;
            // 
            // 
            // 
            this.DS_EndTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.DS_EndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DS_EndTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.DS_EndTime.ButtonDropDown.Visible = true;
            this.DS_EndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DS_EndTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DS_EndTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.DS_EndTime.IsPopupCalendarOpen = false;
            this.DS_EndTime.Location = new System.Drawing.Point(116, 221);
            this.DS_EndTime.Margin = new System.Windows.Forms.Padding(4);
            // 
            // 
            // 
            // 
            // 
            // 
            this.DS_EndTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DS_EndTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.DS_EndTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.DS_EndTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.DS_EndTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.DS_EndTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.DS_EndTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.DS_EndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.DS_EndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.DS_EndTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DS_EndTime.MonthCalendar.DisplayMonth = new System.DateTime(2020, 9, 1, 0, 0, 0, 0);
            this.DS_EndTime.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.DS_EndTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.DS_EndTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.DS_EndTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.DS_EndTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DS_EndTime.MonthCalendar.TodayButtonVisible = true;
            this.DS_EndTime.Name = "DS_EndTime";
            this.DS_EndTime.Size = new System.Drawing.Size(345, 30);
            this.DS_EndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.DS_EndTime.TabIndex = 9;
            this.DS_EndTime.Value = new System.DateTime(2020, 9, 8, 17, 22, 0, 0);
            // 
            // DS_StartTime
            // 
            // 
            // 
            // 
            this.DS_StartTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.DS_StartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DS_StartTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.DS_StartTime.ButtonDropDown.Visible = true;
            this.DS_StartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DS_StartTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DS_StartTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.DS_StartTime.IsPopupCalendarOpen = false;
            this.DS_StartTime.Location = new System.Drawing.Point(115, 126);
            this.DS_StartTime.Margin = new System.Windows.Forms.Padding(4);
            // 
            // 
            // 
            // 
            // 
            // 
            this.DS_StartTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DS_StartTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.DS_StartTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.DS_StartTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.DS_StartTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.DS_StartTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.DS_StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.DS_StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.DS_StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.DS_StartTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DS_StartTime.MonthCalendar.DisplayMonth = new System.DateTime(2020, 9, 1, 0, 0, 0, 0);
            this.DS_StartTime.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.DS_StartTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.DS_StartTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.DS_StartTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.DS_StartTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DS_StartTime.MonthCalendar.TodayButtonVisible = true;
            this.DS_StartTime.Name = "DS_StartTime";
            this.DS_StartTime.Size = new System.Drawing.Size(345, 30);
            this.DS_StartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.DS_StartTime.TabIndex = 8;
            this.DS_StartTime.Value = new System.DateTime(2020, 9, 1, 17, 22, 32, 0);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(4, 222);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(129, 29);
            this.labelX2.TabIndex = 7;
            this.labelX2.Text = "结束时间";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX1.Location = new System.Drawing.Point(3, 128);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(123, 29);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "起始时间";
            // 
            // NoiseDataSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 1055);
            this.Controls.Add(this.NDS_MainPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NoiseDataSearch";
            this.Text = "NoiseDataSearch";
            this.Load += new System.EventHandler(this.NoiseDataSearch_Load);
            this.Resize += new System.EventHandler(this.NoiseDataSearch_Resize);
            this.NDS_MainPanel.ResumeLayout(false);
            this.NDS_RightPanel.ResumeLayout(false);
            this.NDS_RightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdnInfo)).EndInit();
            this.bdnInfo.ResumeLayout(false);
            this.bdnInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSearchDataGrid)).EndInit();
            this.NDS_LeftPanel.ResumeLayout(false);
            this.NDS_LeftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_EndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_StartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel NDS_MainPanel;
        private System.Windows.Forms.Panel NDS_RightPanel;
        private System.Windows.Forms.Panel NDS_LeftPanel;
        private System.Windows.Forms.DataGridView DataSearchDataGrid;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput DS_StartTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput DS_EndTime;
        private DevComponents.DotNetBar.ButtonX DS_Query;
        private DevComponents.DotNetBar.ButtonX DS_Load;
        private System.Windows.Forms.BindingNavigator bdnInfo;
        private System.Windows.Forms.BindingSource bdsInfo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel gong;
        private System.Windows.Forms.ToolStripLabel TotalPage;
        private System.Windows.Forms.ToolStripLabel tiao;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel Page;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripLabel toolStripLabelPage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}