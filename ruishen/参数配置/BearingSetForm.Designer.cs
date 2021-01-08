namespace ruishen.参数配置
{
    partial class BearingSetForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("轴承参数");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BearingSetForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SelectedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BS_LeftPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.B_BearingDelete = new DevComponents.DotNetBar.ButtonX();
            this.B_BearingInsert = new DevComponents.DotNetBar.ButtonX();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.BS_LeftPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.BS_LeftPanel);
            this.panel1.Controls.Add(this.buttonX3);
            this.panel1.Controls.Add(this.B_BearingDelete);
            this.panel1.Controls.Add(this.B_BearingInsert);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1423, 912);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(345, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1078, 728);
            this.panel3.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectedColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1078, 728);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // SelectedColumn
            // 
            this.SelectedColumn.HeaderText = "勾选";
            this.SelectedColumn.Name = "SelectedColumn";
            // 
            // BS_LeftPanel
            // 
            this.BS_LeftPanel.Controls.Add(this.panel2);
            this.BS_LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.BS_LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.BS_LeftPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BS_LeftPanel.Name = "BS_LeftPanel";
            this.BS_LeftPanel.Size = new System.Drawing.Size(345, 912);
            this.BS_LeftPanel.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(345, 912);
            this.panel2.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.Silver;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点0";
            treeNode1.Text = "轴承参数";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(345, 912);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX3.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX3.Location = new System.Drawing.Point(1069, 749);
            this.buttonX3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(245, 62);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.buttonX3.TabIndex = 1;
            this.buttonX3.Text = "轴承配置";
            this.buttonX3.TextColor = System.Drawing.Color.Black;
            // 
            // B_BearingDelete
            // 
            this.B_BearingDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.B_BearingDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.B_BearingDelete.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.B_BearingDelete.Location = new System.Drawing.Point(423, 749);
            this.B_BearingDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_BearingDelete.Name = "B_BearingDelete";
            this.B_BearingDelete.Size = new System.Drawing.Size(245, 62);
            this.B_BearingDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.B_BearingDelete.TabIndex = 1;
            this.B_BearingDelete.Text = "轴承删除";
            this.B_BearingDelete.TextColor = System.Drawing.Color.Black;
            this.B_BearingDelete.Click += new System.EventHandler(this.B_BearingDelete_Click);
            // 
            // B_BearingInsert
            // 
            this.B_BearingInsert.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.B_BearingInsert.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.B_BearingInsert.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.B_BearingInsert.Location = new System.Drawing.Point(740, 749);
            this.B_BearingInsert.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_BearingInsert.Name = "B_BearingInsert";
            this.B_BearingInsert.Size = new System.Drawing.Size(245, 62);
            this.B_BearingInsert.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.B_BearingInsert.TabIndex = 1;
            this.B_BearingInsert.Text = "轴承添加";
            this.B_BearingInsert.TextColor = System.Drawing.Color.Black;
            // 
            // BearingSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1423, 912);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BearingSetForm";
            this.Text = "轴承参数配置";
            this.Resize += new System.EventHandler(this.BearingSetForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.BS_LeftPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel BS_LeftPanel;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX B_BearingInsert;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevComponents.DotNetBar.ButtonX B_BearingDelete;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectedColumn;
    }
}