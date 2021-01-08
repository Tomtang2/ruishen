namespace ruishen.实时监测
{
    partial class RealFilter
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
            this.F_MainPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // F_MainPanel
            // 
            this.F_MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.F_MainPanel.Location = new System.Drawing.Point(0, 0);
            this.F_MainPanel.Name = "F_MainPanel";
            this.F_MainPanel.Size = new System.Drawing.Size(752, 467);
            this.F_MainPanel.TabIndex = 0;
            // 
            // RealFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 467);
            this.Controls.Add(this.F_MainPanel);
            this.Name = "RealFilter";
            this.Text = "实时滤波";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel F_MainPanel;
    }
}