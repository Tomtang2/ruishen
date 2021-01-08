namespace ruishen.数据管理
{
    partial class DataSearch
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.DataSearchDataGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bdnInfo = new System.Windows.Forms.BindingNavigator(this.components);
            this.FirstPage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.LastPage = new System.Windows.Forms.ToolStripLabel();
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
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.Result = new DevComponents.DotNetBar.ButtonX();
            this.DS_Query = new DevComponents.DotNetBar.ButtonX();
            this.DS_EndTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.DS_StartTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.bdsInfo = new System.Windows.Forms.BindingSource(this.components);
            this.MainPanel.SuspendLayout();
            this.RightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSearchDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdnInfo)).BeginInit();
            this.bdnInfo.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_EndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_StartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.RightPanel);
            this.MainPanel.Controls.Add(this.LeftPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1109, 1055);
            this.MainPanel.TabIndex = 0;
            // 
            // RightPanel
            // 
            this.RightPanel.Controls.Add(this.DataSearchDataGrid);
            this.RightPanel.Controls.Add(this.bdnInfo);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPanel.Location = new System.Drawing.Point(432, 0);
            this.RightPanel.Margin = new System.Windows.Forms.Padding(4);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(677, 1055);
            this.RightPanel.TabIndex = 1;
            // 
            // DataSearchDataGrid
            // 
            this.DataSearchDataGrid.AllowUserToAddRows = false;
            this.DataSearchDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataSearchDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataSearchDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.DataSearchDataGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.DataSearchDataGrid.Location = new System.Drawing.Point(0, 0);
            this.DataSearchDataGrid.Margin = new System.Windows.Forms.Padding(4);
            this.DataSearchDataGrid.Name = "DataSearchDataGrid";
            this.DataSearchDataGrid.RowTemplate.Height = 23;
            this.DataSearchDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataSearchDataGrid.Size = new System.Drawing.Size(677, 619);
            this.DataSearchDataGrid.TabIndex = 3;
            this.DataSearchDataGrid.Visible = false;
            this.DataSearchDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataSearchDataGrid_CellContentClick_1);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "选择项";
            this.Column1.Name = "Column1";
            // 
            // bdnInfo
            // 
            this.bdnInfo.AddNewItem = null;
            this.bdnInfo.CountItem = null;
            this.bdnInfo.DeleteItem = null;
            this.bdnInfo.Dock = System.Windows.Forms.DockStyle.None;
            this.bdnInfo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bdnInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FirstPage,
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.LastPage,
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
            this.bdnInfo.Location = new System.Drawing.Point(4, 623);
            this.bdnInfo.MoveFirstItem = null;
            this.bdnInfo.MoveLastItem = null;
            this.bdnInfo.MoveNextItem = null;
            this.bdnInfo.MovePreviousItem = null;
            this.bdnInfo.Name = "bdnInfo";
            this.bdnInfo.PositionItem = null;
            this.bdnInfo.Size = new System.Drawing.Size(608, 27);
            this.bdnInfo.TabIndex = 2;
            this.bdnInfo.Text = "bindingNavigator1";
            this.bdnInfo.Visible = false;
            this.bdnInfo.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.bdnInfo_ItemClicked);
            // 
            // FirstPage
            // 
            this.FirstPage.Name = "FirstPage";
            this.FirstPage.Size = new System.Drawing.Size(39, 24);
            this.FirstPage.Text = "首页";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(54, 24);
            this.toolStripLabel1.Text = "上一页";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(54, 24);
            this.toolStripLabel2.Text = "下一页";
            // 
            // LastPage
            // 
            this.LastPage.Name = "LastPage";
            this.LastPage.Size = new System.Drawing.Size(39, 24);
            this.LastPage.Text = "尾页";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(132, 27);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(39, 24);
            this.toolStripLabel3.Text = "跳转";
            // 
            // gong
            // 
            this.gong.Name = "gong";
            this.gong.Size = new System.Drawing.Size(24, 24);
            this.gong.Text = "共";
            // 
            // TotalPage
            // 
            this.TotalPage.Name = "TotalPage";
            this.TotalPage.Size = new System.Drawing.Size(18, 24);
            this.TotalPage.Text = "0";
            // 
            // tiao
            // 
            this.tiao.Name = "tiao";
            this.tiao.Size = new System.Drawing.Size(24, 24);
            this.tiao.Text = "条";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(24, 24);
            this.toolStripLabel4.Text = "第";
            // 
            // Page
            // 
            this.Page.Name = "Page";
            this.Page.Size = new System.Drawing.Size(18, 24);
            this.Page.Text = "0";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(24, 24);
            this.toolStripLabel5.Text = "页";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(24, 24);
            this.toolStripLabel6.Text = "共";
            // 
            // toolStripLabelPage
            // 
            this.toolStripLabelPage.Name = "toolStripLabelPage";
            this.toolStripLabelPage.Size = new System.Drawing.Size(18, 24);
            this.toolStripLabelPage.Text = "0";
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(24, 24);
            this.toolStripLabel7.Text = "页";
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.SystemColors.GrayText;
            this.LeftPanel.Controls.Add(this.Result);
            this.LeftPanel.Controls.Add(this.DS_Query);
            this.LeftPanel.Controls.Add(this.DS_EndTime);
            this.LeftPanel.Controls.Add(this.labelX2);
            this.LeftPanel.Controls.Add(this.DS_StartTime);
            this.LeftPanel.Controls.Add(this.labelX1);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Margin = new System.Windows.Forms.Padding(4);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(432, 1055);
            this.LeftPanel.TabIndex = 0;
            // 
            // Result
            // 
            this.Result.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Result.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Result.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Result.Location = new System.Drawing.Point(281, 215);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(111, 37);
            this.Result.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Result.TabIndex = 13;
            this.Result.Text = "结果";
            this.Result.Click += new System.EventHandler(this.Result_Click);
            // 
            // DS_Query
            // 
            this.DS_Query.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.DS_Query.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.DS_Query.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DS_Query.Location = new System.Drawing.Point(107, 215);
            this.DS_Query.Margin = new System.Windows.Forms.Padding(4);
            this.DS_Query.Name = "DS_Query";
            this.DS_Query.Size = new System.Drawing.Size(116, 38);
            this.DS_Query.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.DS_Query.TabIndex = 12;
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
            this.DS_EndTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.DS_EndTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DS_EndTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.DS_EndTime.IsPopupCalendarOpen = false;
            this.DS_EndTime.Location = new System.Drawing.Point(107, 104);
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
            this.DS_EndTime.Size = new System.Drawing.Size(294, 30);
            this.DS_EndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.DS_EndTime.TabIndex = 11;
            this.DS_EndTime.Value = new System.DateTime(2020, 9, 8, 17, 22, 0, 0);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.ForeColor = System.Drawing.Color.White;
            this.labelX2.Location = new System.Drawing.Point(4, 104);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(106, 29);
            this.labelX2.TabIndex = 10;
            this.labelX2.Text = "结束时间";
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
            this.DS_StartTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.DS_StartTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DS_StartTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.DS_StartTime.IsPopupCalendarOpen = false;
            this.DS_StartTime.Location = new System.Drawing.Point(107, 45);
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
            this.DS_StartTime.Size = new System.Drawing.Size(294, 30);
            this.DS_StartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.DS_StartTime.TabIndex = 9;
            this.DS_StartTime.Value = new System.DateTime(2020, 9, 1, 17, 22, 32, 0);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelX1.Location = new System.Drawing.Point(4, 45);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(130, 29);
            this.labelX1.TabIndex = 7;
            this.labelX1.Text = "起始时间";
            // 
            // DataSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 1055);
            this.Controls.Add(this.MainPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DataSearch";
            this.Text = "DataSearch";
            this.Load += new System.EventHandler(this.DataSearch_Load);
            this.MainPanel.ResumeLayout(false);
            this.RightPanel.ResumeLayout(false);
            this.RightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSearchDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdnInfo)).EndInit();
            this.bdnInfo.ResumeLayout(false);
            this.bdnInfo.PerformLayout();
            this.LeftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS_EndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_StartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.Panel LeftPanel;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput DS_StartTime;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput DS_EndTime;
        private DevComponents.DotNetBar.ButtonX DS_Query;
        private System.Windows.Forms.BindingNavigator bdnInfo;
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
        private System.Windows.Forms.BindingSource bdsInfo;
        private System.Windows.Forms.DataGridView DataSearchDataGrid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.ToolStripLabel FirstPage;
        private System.Windows.Forms.ToolStripLabel LastPage;
        private DevComponents.DotNetBar.ButtonX Result;
    }
}