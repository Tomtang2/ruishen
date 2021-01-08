namespace ruishen.数据管理
{
    partial class UserManage
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
            this.UserManage_panel1 = new System.Windows.Forms.Panel();
            this.UserManage_RightPanel1 = new System.Windows.Forms.Panel();
            this.UserManage_DataGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UserManage_LeftPanel1 = new System.Windows.Forms.Panel();
            this.UserManage_refrush = new System.Windows.Forms.Button();
            this.UserManage_delete = new System.Windows.Forms.Button();
            this.UserManage_find = new System.Windows.Forms.Button();
            this.UserManage_panel1.SuspendLayout();
            this.UserManage_RightPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserManage_DataGrid)).BeginInit();
            this.UserManage_LeftPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserManage_panel1
            // 
            this.UserManage_panel1.Controls.Add(this.UserManage_RightPanel1);
            this.UserManage_panel1.Controls.Add(this.UserManage_LeftPanel1);
            this.UserManage_panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserManage_panel1.Location = new System.Drawing.Point(0, 0);
            this.UserManage_panel1.Name = "UserManage_panel1";
            this.UserManage_panel1.Size = new System.Drawing.Size(997, 640);
            this.UserManage_panel1.TabIndex = 0;
            // 
            // UserManage_RightPanel1
            // 
            this.UserManage_RightPanel1.Controls.Add(this.UserManage_DataGrid);
            this.UserManage_RightPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserManage_RightPanel1.Location = new System.Drawing.Point(200, 0);
            this.UserManage_RightPanel1.Name = "UserManage_RightPanel1";
            this.UserManage_RightPanel1.Size = new System.Drawing.Size(797, 640);
            this.UserManage_RightPanel1.TabIndex = 1;
            // 
            // UserManage_DataGrid
            // 
            this.UserManage_DataGrid.AllowUserToAddRows = false;
            this.UserManage_DataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UserManage_DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserManage_DataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.UserManage_DataGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserManage_DataGrid.Location = new System.Drawing.Point(0, 0);
            this.UserManage_DataGrid.Name = "UserManage_DataGrid";
            this.UserManage_DataGrid.RowTemplate.Height = 23;
            this.UserManage_DataGrid.Size = new System.Drawing.Size(797, 804);
            this.UserManage_DataGrid.TabIndex = 4;
            this.UserManage_DataGrid.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "选择项";
            this.Column1.Name = "Column1";
            // 
            // UserManage_LeftPanel1
            // 
            this.UserManage_LeftPanel1.Controls.Add(this.UserManage_refrush);
            this.UserManage_LeftPanel1.Controls.Add(this.UserManage_delete);
            this.UserManage_LeftPanel1.Controls.Add(this.UserManage_find);
            this.UserManage_LeftPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.UserManage_LeftPanel1.Location = new System.Drawing.Point(0, 0);
            this.UserManage_LeftPanel1.Name = "UserManage_LeftPanel1";
            this.UserManage_LeftPanel1.Size = new System.Drawing.Size(200, 640);
            this.UserManage_LeftPanel1.TabIndex = 0;
            // 
            // UserManage_refrush
            // 
            this.UserManage_refrush.BackColor = System.Drawing.Color.DarkGray;
            this.UserManage_refrush.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserManage_refrush.Location = new System.Drawing.Point(36, 237);
            this.UserManage_refrush.Name = "UserManage_refrush";
            this.UserManage_refrush.Size = new System.Drawing.Size(117, 44);
            this.UserManage_refrush.TabIndex = 2;
            this.UserManage_refrush.Text = "注册";
            this.UserManage_refrush.UseVisualStyleBackColor = false;
            this.UserManage_refrush.Click += new System.EventHandler(this.UserManage_refrush_Click);
            // 
            // UserManage_delete
            // 
            this.UserManage_delete.BackColor = System.Drawing.Color.DarkGray;
            this.UserManage_delete.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserManage_delete.Location = new System.Drawing.Point(36, 152);
            this.UserManage_delete.Name = "UserManage_delete";
            this.UserManage_delete.Size = new System.Drawing.Size(117, 44);
            this.UserManage_delete.TabIndex = 1;
            this.UserManage_delete.Text = "删除";
            this.UserManage_delete.UseVisualStyleBackColor = false;
            this.UserManage_delete.Click += new System.EventHandler(this.UserManage_delete_Click);
            // 
            // UserManage_find
            // 
            this.UserManage_find.BackColor = System.Drawing.Color.DarkGray;
            this.UserManage_find.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserManage_find.Location = new System.Drawing.Point(36, 65);
            this.UserManage_find.Name = "UserManage_find";
            this.UserManage_find.Size = new System.Drawing.Size(117, 44);
            this.UserManage_find.TabIndex = 0;
            this.UserManage_find.Text = "查询";
            this.UserManage_find.UseVisualStyleBackColor = false;
            this.UserManage_find.Click += new System.EventHandler(this.UserManage_find_Click);
            // 
            // UserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 640);
            this.Controls.Add(this.UserManage_panel1);
            this.Name = "UserManage";
            this.Text = "UserManage";
            this.UserManage_panel1.ResumeLayout(false);
            this.UserManage_RightPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserManage_DataGrid)).EndInit();
            this.UserManage_LeftPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel UserManage_panel1;
        private System.Windows.Forms.Panel UserManage_RightPanel1;
        private System.Windows.Forms.Panel UserManage_LeftPanel1;
        private System.Windows.Forms.Button UserManage_refrush;
        private System.Windows.Forms.Button UserManage_delete;
        private System.Windows.Forms.Button UserManage_find;
        private System.Windows.Forms.DataGridView UserManage_DataGrid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
    }
}