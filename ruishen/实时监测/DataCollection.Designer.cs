namespace ruishen.实时监测
{
    partial class DataCollection
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
            this.DC_MainPanel = new System.Windows.Forms.Panel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.DC_MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DC_MainPanel
            // 
            this.DC_MainPanel.BackColor = System.Drawing.Color.Silver;
            this.DC_MainPanel.Controls.Add(this.labelX1);
            this.DC_MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DC_MainPanel.Location = new System.Drawing.Point(0, 0);
            this.DC_MainPanel.Name = "DC_MainPanel";
            this.DC_MainPanel.Size = new System.Drawing.Size(1044, 513);
            this.DC_MainPanel.TabIndex = 0;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX1.Font = new System.Drawing.Font("宋体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.ForeColor = System.Drawing.Color.DarkRed;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(1044, 513);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "数据采集中，请等待......";
            // 
            // DataCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 513);
            this.Controls.Add(this.DC_MainPanel);
            this.Name = "DataCollection";
            this.Text = "DataCollection";
            this.DC_MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DC_MainPanel;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}