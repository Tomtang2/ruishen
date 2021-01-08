namespace ruishen.公共中间量
{
    partial class ThresholdSetWindows1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NoThreshold = new System.Windows.Forms.RadioButton();
            this.ManualThreshold = new System.Windows.Forms.RadioButton();
            this.SelfLearningThreshold = new System.Windows.Forms.RadioButton();
            this.numericEdit1 = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.UpThresholdValue = new System.Windows.Forms.Label();
            this.numericEdit2 = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.DownThresholdValue = new System.Windows.Forms.Label();
            this.ChangeValue = new System.Windows.Forms.Label();
            this.numericEdit3 = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit3)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 185);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NoThreshold);
            this.groupBox1.Controls.Add(this.ManualThreshold);
            this.groupBox1.Controls.Add(this.SelfLearningThreshold);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(435, 185);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置方式";
            // 
            // NoThreshold
            // 
            this.NoThreshold.AutoSize = true;
            this.NoThreshold.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NoThreshold.Location = new System.Drawing.Point(131, 141);
            this.NoThreshold.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NoThreshold.Name = "NoThreshold";
            this.NoThreshold.Size = new System.Drawing.Size(108, 29);
            this.NoThreshold.TabIndex = 0;
            this.NoThreshold.TabStop = true;
            this.NoThreshold.Text = "无阈值";
            this.NoThreshold.UseVisualStyleBackColor = true;
            this.NoThreshold.CheckedChanged += new System.EventHandler(this.NoThreshold_CheckedChanged);
            // 
            // ManualThreshold
            // 
            this.ManualThreshold.AutoSize = true;
            this.ManualThreshold.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ManualThreshold.Location = new System.Drawing.Point(131, 91);
            this.ManualThreshold.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ManualThreshold.Name = "ManualThreshold";
            this.ManualThreshold.Size = new System.Drawing.Size(133, 29);
            this.ManualThreshold.TabIndex = 0;
            this.ManualThreshold.TabStop = true;
            this.ManualThreshold.Text = "手动阈值";
            this.ManualThreshold.UseVisualStyleBackColor = true;
            this.ManualThreshold.CheckedChanged += new System.EventHandler(this.ManualThreshold_CheckedChanged);
            // 
            // SelfLearningThreshold
            // 
            this.SelfLearningThreshold.AutoSize = true;
            this.SelfLearningThreshold.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelfLearningThreshold.Location = new System.Drawing.Point(131, 40);
            this.SelfLearningThreshold.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SelfLearningThreshold.Name = "SelfLearningThreshold";
            this.SelfLearningThreshold.Size = new System.Drawing.Size(158, 29);
            this.SelfLearningThreshold.TabIndex = 0;
            this.SelfLearningThreshold.TabStop = true;
            this.SelfLearningThreshold.Text = "自学习阈值";
            this.SelfLearningThreshold.UseVisualStyleBackColor = true;
            this.SelfLearningThreshold.CheckedChanged += new System.EventHandler(this.SelfLearningThreshold_CheckedChanged);
            // 
            // numericEdit1
            // 
            this.numericEdit1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericEdit1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericEdit1.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(7);
            this.numericEdit1.Location = new System.Drawing.Point(227, 26);
            this.numericEdit1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericEdit1.Name = "numericEdit1";
            this.numericEdit1.Size = new System.Drawing.Size(160, 36);
            this.numericEdit1.TabIndex = 5;
            this.numericEdit1.Value = 1.5D;
            // 
            // UpThresholdValue
            // 
            this.UpThresholdValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpThresholdValue.AutoSize = true;
            this.UpThresholdValue.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UpThresholdValue.Location = new System.Drawing.Point(80, 32);
            this.UpThresholdValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UpThresholdValue.Name = "UpThresholdValue";
            this.UpThresholdValue.Size = new System.Drawing.Size(75, 25);
            this.UpThresholdValue.TabIndex = 6;
            this.UpThresholdValue.Text = "上限:";
            this.UpThresholdValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // numericEdit2
            // 
            this.numericEdit2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericEdit2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericEdit2.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(4);
            this.numericEdit2.Location = new System.Drawing.Point(227, 82);
            this.numericEdit2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericEdit2.Name = "numericEdit2";
            this.numericEdit2.Size = new System.Drawing.Size(160, 36);
            this.numericEdit2.TabIndex = 7;
            // 
            // DownThresholdValue
            // 
            this.DownThresholdValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DownThresholdValue.AutoSize = true;
            this.DownThresholdValue.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DownThresholdValue.Location = new System.Drawing.Point(80, 89);
            this.DownThresholdValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DownThresholdValue.Name = "DownThresholdValue";
            this.DownThresholdValue.Size = new System.Drawing.Size(75, 25);
            this.DownThresholdValue.TabIndex = 8;
            this.DownThresholdValue.Text = "下限:";
            this.DownThresholdValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ChangeValue
            // 
            this.ChangeValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChangeValue.AutoSize = true;
            this.ChangeValue.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChangeValue.Location = new System.Drawing.Point(80, 155);
            this.ChangeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ChangeValue.Name = "ChangeValue";
            this.ChangeValue.Size = new System.Drawing.Size(100, 25);
            this.ChangeValue.TabIndex = 8;
            this.ChangeValue.Text = "切换值:";
            this.ChangeValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // numericEdit3
            // 
            this.numericEdit3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericEdit3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericEdit3.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(4);
            this.numericEdit3.Location = new System.Drawing.Point(227, 149);
            this.numericEdit3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericEdit3.Name = "numericEdit3";
            this.numericEdit3.Size = new System.Drawing.Size(160, 36);
            this.numericEdit3.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.UpThresholdValue);
            this.panel2.Controls.Add(this.ChangeValue);
            this.panel2.Controls.Add(this.numericEdit1);
            this.panel2.Controls.Add(this.numericEdit3);
            this.panel2.Controls.Add(this.DownThresholdValue);
            this.panel2.Controls.Add(this.numericEdit2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 185);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(435, 231);
            this.panel2.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(85, 472);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 45);
            this.button1.TabIndex = 10;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(268, 472);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 45);
            this.button2.TabIndex = 11;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ThresholdSetWindows1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 596);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ThresholdSetWindows1";
            this.Text = "阈值设置界面";
            this.Load += new System.EventHandler(this.ThresholdSetWindows1_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton NoThreshold;
        private System.Windows.Forms.RadioButton ManualThreshold;
        private System.Windows.Forms.RadioButton SelfLearningThreshold;
        private NationalInstruments.UI.WindowsForms.NumericEdit numericEdit1;
        public System.Windows.Forms.Label UpThresholdValue;
        private NationalInstruments.UI.WindowsForms.NumericEdit numericEdit2;
        public System.Windows.Forms.Label DownThresholdValue;
        public System.Windows.Forms.Label ChangeValue;
        private NationalInstruments.UI.WindowsForms.NumericEdit numericEdit3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}