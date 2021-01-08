namespace ruishen.振动分析
{
    partial class VibrationDataSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.DS_EndTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.DS_StartTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.DS_Load = new DevComponents.DotNetBar.ButtonX();
            this.DS_Query = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.DS_MainPanel = new System.Windows.Forms.Panel();
            this.bdnInfo = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.Gong = new System.Windows.Forms.ToolStripLabel();
            this.TotalPage = new System.Windows.Forms.ToolStripLabel();
            this.Tiao = new System.Windows.Forms.ToolStripLabel();
            this.ToTal = new System.Windows.Forms.ToolStripLabel();
            this.Page = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelPage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.DataSearchDataGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bdsInfo = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_EndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_StartTime)).BeginInit();
            this.DS_MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdnInfo)).BeginInit();
            this.bdnInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSearchDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.DS_EndTime);
            this.panel1.Controls.Add(this.DS_StartTime);
            this.panel1.Controls.Add(this.DS_Load);
            this.panel1.Controls.Add(this.DS_Query);
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 749);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(11, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "振动检测";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1-左前轴承",
            "2-右前轴承",
            "3-左后轴承",
            "4-右后轴承"});
            this.comboBox1.Location = new System.Drawing.Point(132, 46);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(328, 31);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Text = "1-左前轴承";
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
            this.DS_EndTime.Location = new System.Drawing.Point(121, 198);
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
            this.DS_EndTime.Size = new System.Drawing.Size(328, 30);
            this.DS_EndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.DS_EndTime.TabIndex = 5;
            this.DS_EndTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
            this.DS_EndTime.Value = new System.DateTime(2020, 9, 18, 17, 22, 0, 0);
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
            this.DS_StartTime.Location = new System.Drawing.Point(121, 118);
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
            this.DS_StartTime.Size = new System.Drawing.Size(328, 30);
            this.DS_StartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.DS_StartTime.TabIndex = 5;
            this.DS_StartTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
            this.DS_StartTime.Value = new System.DateTime(2020, 9, 1, 17, 22, 0, 0);
            // 
            // DS_Load
            // 
            this.DS_Load.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.DS_Load.BackColor = System.Drawing.Color.LightGray;
            this.DS_Load.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.DS_Load.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DS_Load.Location = new System.Drawing.Point(279, 324);
            this.DS_Load.Margin = new System.Windows.Forms.Padding(4);
            this.DS_Load.Name = "DS_Load";
            this.DS_Load.Size = new System.Drawing.Size(160, 60);
            this.DS_Load.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.DS_Load.TabIndex = 2;
            this.DS_Load.Text = "加载";
            this.DS_Load.Click += new System.EventHandler(this.DS_Load_Click);
            // 
            // DS_Query
            // 
            this.DS_Query.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.DS_Query.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.DS_Query.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DS_Query.Location = new System.Drawing.Point(45, 324);
            this.DS_Query.Margin = new System.Windows.Forms.Padding(4);
            this.DS_Query.Name = "DS_Query";
            this.DS_Query.Size = new System.Drawing.Size(160, 60);
            this.DS_Query.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.DS_Query.TabIndex = 1;
            this.DS_Query.Text = "查询";
            this.DS_Query.Click += new System.EventHandler(this.DS_Query_Click);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(4, 198);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(139, 29);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "结束时间";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(4, 119);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(123, 29);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "起始时间";
            // 
            // DS_MainPanel
            // 
            this.DS_MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DS_MainPanel.Controls.Add(this.bdnInfo);
            this.DS_MainPanel.Controls.Add(this.DataSearchDataGrid);
            this.DS_MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DS_MainPanel.Location = new System.Drawing.Point(469, 0);
            this.DS_MainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.DS_MainPanel.Name = "DS_MainPanel";
            this.DS_MainPanel.Size = new System.Drawing.Size(755, 749);
            this.DS_MainPanel.TabIndex = 1;
            // 
            // bdnInfo
            // 
            this.bdnInfo.AddNewItem = null;
            this.bdnInfo.CountItem = null;
            this.bdnInfo.DeleteItem = null;
            this.bdnInfo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bdnInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSeparator2,
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.toolStripTextBox1,
            this.toolStripLabel3,
            this.Gong,
            this.TotalPage,
            this.Tiao,
            this.ToTal,
            this.Page,
            this.toolStripLabel4,
            this.toolStripLabel5,
            this.toolStripLabelPage,
            this.toolStripLabel6});
            this.bdnInfo.Location = new System.Drawing.Point(0, 598);
            this.bdnInfo.MoveFirstItem = null;
            this.bdnInfo.MoveLastItem = null;
            this.bdnInfo.MoveNextItem = null;
            this.bdnInfo.MovePreviousItem = null;
            this.bdnInfo.Name = "bdnInfo";
            this.bdnInfo.PositionItem = null;
            this.bdnInfo.Size = new System.Drawing.Size(755, 28);
            this.bdnInfo.TabIndex = 1;
            this.bdnInfo.Text = "bindingNavigator1";
            this.bdnInfo.Visible = false;
            this.bdnInfo.RefreshItems += new System.EventHandler(this.bdnInfo_RefreshItems);
            this.bdnInfo.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.bdnInfo_ItemClicked);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 28);
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
            // Gong
            // 
            this.Gong.Name = "Gong";
            this.Gong.Size = new System.Drawing.Size(24, 25);
            this.Gong.Text = "共";
            // 
            // TotalPage
            // 
            this.TotalPage.Name = "TotalPage";
            this.TotalPage.Size = new System.Drawing.Size(18, 25);
            this.TotalPage.Text = "0";
            // 
            // Tiao
            // 
            this.Tiao.Name = "Tiao";
            this.Tiao.Size = new System.Drawing.Size(24, 25);
            this.Tiao.Text = "条";
            // 
            // ToTal
            // 
            this.ToTal.Name = "ToTal";
            this.ToTal.Size = new System.Drawing.Size(24, 25);
            this.ToTal.Text = "第";
            // 
            // Page
            // 
            this.Page.Name = "Page";
            this.Page.Size = new System.Drawing.Size(18, 25);
            this.Page.Text = "0";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(24, 25);
            this.toolStripLabel4.Text = "页";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(24, 25);
            this.toolStripLabel5.Text = "共";
            // 
            // toolStripLabelPage
            // 
            this.toolStripLabelPage.Name = "toolStripLabelPage";
            this.toolStripLabelPage.Size = new System.Drawing.Size(18, 25);
            this.toolStripLabelPage.Text = "0";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(24, 25);
            this.toolStripLabel6.Text = "页";
            // 
            // DataSearchDataGrid
            // 
            this.DataSearchDataGrid.AllowUserToAddRows = false;
            this.DataSearchDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataSearchDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataSearchDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataSearchDataGrid.RowHeadersWidth = 40;
            this.DataSearchDataGrid.RowTemplate.Height = 23;
            this.DataSearchDataGrid.Size = new System.Drawing.Size(751, 624);
            this.DataSearchDataGrid.TabIndex = 0;
            this.DataSearchDataGrid.Visible = false;
            this.DataSearchDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataSearchDataGrid_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 20F;
            this.Column1.HeaderText = "选择项";
            this.Column1.Name = "Column1";
            this.Column1.Width = 58;
            // 
            // VibrationDataSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 749);
            this.Controls.Add(this.DS_MainPanel);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VibrationDataSearch";
            this.Text = "数据检索";
            this.Load += new System.EventHandler(this.DataSearch_Load);
            this.Resize += new System.EventHandler(this.DataSearch_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_EndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_StartTime)).EndInit();
            this.DS_MainPanel.ResumeLayout(false);
            this.DS_MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdnInfo)).EndInit();
            this.bdnInfo.ResumeLayout(false);
            this.bdnInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSearchDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX DS_Load;
        private DevComponents.DotNetBar.ButtonX DS_Query;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput DS_StartTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput DS_EndTime;
        private System.Windows.Forms.Panel DS_MainPanel;
        private System.Windows.Forms.DataGridView DataSearchDataGrid;
        private System.Windows.Forms.BindingNavigator bdnInfo;
        private System.Windows.Forms.BindingSource bdsInfo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripLabel Gong;
        private System.Windows.Forms.ToolStripLabel TotalPage;
        private System.Windows.Forms.ToolStripLabel Tiao;
        private System.Windows.Forms.ToolStripLabel ToTal;
        private System.Windows.Forms.ToolStripLabel Page;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripLabel toolStripLabelPage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
    }
}