namespace ruishen.振动分析
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.DS_EndTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.DS_StartTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.DS_Load = new DevComponents.DotNetBar.ButtonX();
            this.DS_Query = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.DS_MainPanel = new System.Windows.Forms.Panel();
            this.DataSearchDataGrid = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_EndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_StartTime)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.DS_MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSearchDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Controls.Add(this.DS_EndTime);
            this.panel1.Controls.Add(this.DS_StartTime);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.DS_Load);
            this.panel1.Controls.Add(this.DS_Query);
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 737);
            this.panel1.TabIndex = 0;
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
            this.DS_EndTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.DS_EndTime.IsPopupCalendarOpen = false;
            this.DS_EndTime.Location = new System.Drawing.Point(115, 158);
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
            this.DS_EndTime.Size = new System.Drawing.Size(200, 21);
            this.DS_EndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.DS_EndTime.TabIndex = 5;
            this.DS_EndTime.Value = new System.DateTime(2020, 9, 1, 17, 22, 40, 0);
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
            this.DS_StartTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.DS_StartTime.IsPopupCalendarOpen = false;
            this.DS_StartTime.Location = new System.Drawing.Point(115, 94);
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
            this.DS_StartTime.Size = new System.Drawing.Size(200, 21);
            this.DS_StartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.DS_StartTime.TabIndex = 5;
            this.DS_StartTime.Value = new System.DateTime(2020, 9, 1, 17, 22, 32, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxX1);
            this.groupBox1.Controls.Add(this.checkBoxX2);
            this.groupBox1.Controls.Add(this.checkBoxX3);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(34, 290);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 207);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "传感器类型";
            // 
            // checkBoxX1
            // 
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxX1.Location = new System.Drawing.Point(20, 32);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(141, 23);
            this.checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX1.TabIndex = 3;
            this.checkBoxX1.Text = "加速度传感器";
            this.checkBoxX1.TextColor = System.Drawing.Color.White;
            // 
            // checkBoxX2
            // 
            // 
            // 
            // 
            this.checkBoxX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxX2.Location = new System.Drawing.Point(20, 71);
            this.checkBoxX2.Name = "checkBoxX2";
            this.checkBoxX2.Size = new System.Drawing.Size(141, 23);
            this.checkBoxX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX2.TabIndex = 3;
            this.checkBoxX2.Text = "位移传感器";
            this.checkBoxX2.TextColor = System.Drawing.Color.White;
            // 
            // checkBoxX3
            // 
            // 
            // 
            // 
            this.checkBoxX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxX3.Location = new System.Drawing.Point(20, 111);
            this.checkBoxX3.Name = "checkBoxX3";
            this.checkBoxX3.Size = new System.Drawing.Size(110, 23);
            this.checkBoxX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX3.TabIndex = 3;
            this.checkBoxX3.Text = "速度传感器";
            this.checkBoxX3.TextColor = System.Drawing.Color.White;
            // 
            // DS_Load
            // 
            this.DS_Load.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.DS_Load.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.DS_Load.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DS_Load.Location = new System.Drawing.Point(166, 541);
            this.DS_Load.Name = "DS_Load";
            this.DS_Load.Size = new System.Drawing.Size(92, 30);
            this.DS_Load.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.DS_Load.TabIndex = 2;
            this.DS_Load.Text = "加载";
            // 
            // DS_Query
            // 
            this.DS_Query.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.DS_Query.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.DS_Query.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DS_Query.Location = new System.Drawing.Point(34, 541);
            this.DS_Query.Name = "DS_Query";
            this.DS_Query.Size = new System.Drawing.Size(87, 30);
            this.DS_Query.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
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
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.ForeColor = System.Drawing.Color.White;
            this.labelX2.Location = new System.Drawing.Point(34, 158);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(104, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "结束时间";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelX1.Location = new System.Drawing.Point(34, 92);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "起始时间";
            // 
            // DS_MainPanel
            // 
            this.DS_MainPanel.Controls.Add(this.DataSearchDataGrid);
            this.DS_MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DS_MainPanel.Location = new System.Drawing.Point(352, 0);
            this.DS_MainPanel.Name = "DS_MainPanel";
            this.DS_MainPanel.Size = new System.Drawing.Size(566, 737);
            this.DS_MainPanel.TabIndex = 1;
            // 
            // DataSearchDataGrid
            // 
            this.DataSearchDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataSearchDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataSearchDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataSearchDataGrid.Location = new System.Drawing.Point(0, 0);
            this.DataSearchDataGrid.Name = "DataSearchDataGrid";
            this.DataSearchDataGrid.RowTemplate.Height = 23;
            this.DataSearchDataGrid.Size = new System.Drawing.Size(566, 737);
            this.DataSearchDataGrid.TabIndex = 0;
            // 
            // DataSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 737);
            this.Controls.Add(this.DS_MainPanel);
            this.Controls.Add(this.panel1);
            this.Name = "DataSearch";
            this.Text = "数据检索";
            this.Load += new System.EventHandler(this.DataSearch_Load);
            this.Resize += new System.EventHandler(this.DataSearch_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS_EndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_StartTime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.DS_MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataSearchDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX3;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX2;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private DevComponents.DotNetBar.ButtonX DS_Load;
        private DevComponents.DotNetBar.ButtonX DS_Query;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput DS_StartTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput DS_EndTime;
        private System.Windows.Forms.Panel DS_MainPanel;
        private System.Windows.Forms.DataGridView DataSearchDataGrid;
    }
}