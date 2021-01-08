using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ruishen.Entity;

namespace ruishen.公共中间量
{
    public partial class ThresholdSetWindows1 : Form
    {
        public ThresholdSetWindows1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ManualThreshold.Checked)
            {
                switch (this.Text)
            {
                case "上四分位": ThresholdUpDownValue.UpQuartile_Up = numericEdit1.Value; ThresholdUpDownValue.UpQuartile_Down = numericEdit2.Value; AddJudge("上四分位",1); break;
                case "下四分位": ThresholdUpDownValue.DownQuartile_Up = numericEdit1.Value; ThresholdUpDownValue.DownQuartile_Down = numericEdit2.Value; AddJudge("下四分位",1); break;
                case "中位数": ThresholdUpDownValue.Median_Up1 = numericEdit1.Value; ThresholdUpDownValue.Median_Down1 = numericEdit2.Value; AddJudge("中位数",1); break;
                case "四分位距": ThresholdUpDownValue.DistanceQuartile_Up = numericEdit1.Value; ThresholdUpDownValue.DistanceQuartile_Down = numericEdit2.Value; AddJudge("四分位距",1); break;
                case "上界": ThresholdUpDownValue.Upperbound_Up = numericEdit1.Value; ThresholdUpDownValue.Upperbound_Down = numericEdit2.Value; AddJudge("上界",1); break;
                case "下界": ThresholdUpDownValue.Downbound_Up = numericEdit1.Value; ThresholdUpDownValue.Downbound_Down = numericEdit2.Value; AddJudge("下界",1); break;
                case "均值": ThresholdUpDownValue.Average_Up = numericEdit1.Value; ThresholdUpDownValue.Average_Down = numericEdit2.Value; AddJudge("均值",1); break;
                case "方差": ThresholdUpDownValue.Variance_Up = numericEdit1.Value; ThresholdUpDownValue.Variance_Down = numericEdit2.Value; AddJudge("方差",1); break;
                case "均方根值": ThresholdUpDownValue.RMS_Value_Up1 = numericEdit1.Value; ThresholdUpDownValue.RMS_Value_Down1 = numericEdit2.Value; AddJudge("均方根值",1); break;
                case "歪度": ThresholdUpDownValue.Skewness_Up = numericEdit1.Value; ThresholdUpDownValue.Skewness_Down = numericEdit2.Value; AddJudge("歪度",1); break;
                case "峭度": ThresholdUpDownValue.Kurtosis_Up = numericEdit1.Value; ThresholdUpDownValue.Kurtosis_Down = numericEdit2.Value; AddJudge("峭度",1); break;
                case "峰度": ThresholdUpDownValue.Peak_Up = numericEdit1.Value; ThresholdUpDownValue.Peak_Down = numericEdit2.Value; AddJudge("峰度",1); break;
                case "峰值频率": ThresholdUpDownValue.Frequency_Up = numericEdit1.Value; ThresholdUpDownValue.Frequency_Down = numericEdit2.Value; AddJudge("峰值频率",1); break;
                case "频率幅值": ThresholdUpDownValue.FrequencyA_Up = numericEdit1.Value; ThresholdUpDownValue.FrequencyA_Down = numericEdit2.Value; AddJudge("频率幅值",1); break;
                case "中心频率": ThresholdUpDownValue.OctaveValue_Up = numericEdit1.Value; ThresholdUpDownValue.OctaveValue_Down = numericEdit2.Value; AddJudge("中心频率",1); break;
            }
                
            }
            else if (NoThreshold.Checked)
            {
                switch (this.Text)
                {
                    case "上四分位": ThresholdUpDownValue.UpQuartile_Up = 0; ThresholdUpDownValue.UpQuartile_Down = 0; AddJudge("上四分位", 0); break;
                    case "下四分位": ThresholdUpDownValue.DownQuartile_Up = 0; ThresholdUpDownValue.DownQuartile_Down = 0; AddJudge("下四分位", 0); break;
                    case "中位数": ThresholdUpDownValue.Median_Up1 = 0; ThresholdUpDownValue.Median_Down1 = 0; AddJudge("中位数", 0); break;
                    case "四分位距": ThresholdUpDownValue.DistanceQuartile_Up = 0; ThresholdUpDownValue.DistanceQuartile_Down = 0; AddJudge("四分位距", 0); break;
                    case "上界": ThresholdUpDownValue.Upperbound_Up = 0; ThresholdUpDownValue.Upperbound_Down = 0; AddJudge("上界", 0); break;
                    case "下界": ThresholdUpDownValue.Downbound_Up = 0; ThresholdUpDownValue.Downbound_Down = 0; AddJudge("下界", 0); break;
                    case "均值": ThresholdUpDownValue.Average_Up = 0; ThresholdUpDownValue.Average_Down = 0; AddJudge("均值", 0); break;
                    case "方差": ThresholdUpDownValue.Variance_Up = 0; ThresholdUpDownValue.Variance_Down = 0; AddJudge("方差", 0); break;
                    case "均方根值": ThresholdUpDownValue.RMS_Value_Up1 = 0; ThresholdUpDownValue.RMS_Value_Down1 = 0; AddJudge("均方根值", 0); break;
                    case "歪度": ThresholdUpDownValue.Skewness_Up = 0; ThresholdUpDownValue.Skewness_Down = 0; AddJudge("歪度", 0); break;
                    case "峭度": ThresholdUpDownValue.Kurtosis_Up = 0; ThresholdUpDownValue.Kurtosis_Down = 0; AddJudge("峭度", 0); break;
                    case "峰度": ThresholdUpDownValue.Peak_Up = 0; ThresholdUpDownValue.Peak_Down = 0; AddJudge("峰度", 0); break;
                    case "峰值频率": ThresholdUpDownValue.Frequency_Up = 0; ThresholdUpDownValue.Frequency_Down = 0; AddJudge("峰值频率", 0); break;
                    case "频率幅值": ThresholdUpDownValue.FrequencyA_Up = 0; ThresholdUpDownValue.FrequencyA_Down = 0; AddJudge("频率幅值", 0); break;
                    case "中心频率": ThresholdUpDownValue.OctaveValue_Up = 0; ThresholdUpDownValue.OctaveValue_Down = 0; AddJudge("中心频率", 0); break;
                }
            }
            else if (SelfLearningThreshold.Checked)
            {
            }
            DialogResult dr = MessageBox.Show(this.Text + "阈值设置完成", "", MessageBoxButtons.OKCancel, MessageBoxIcon.None);

            if (dr == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void AddJudge(string ParameterStyle,int isJudge)
        {
            if (DataTempStorage.IsJudge.ContainsKey(ParameterStyle)) DataTempStorage.IsJudge.Remove(ParameterStyle);
            DataTempStorage.IsJudge.Add(ParameterStyle, isJudge);
        }
        private void SelfLearningThreshold_CheckedChanged(object sender, EventArgs e)
        {
                panel2.Visible = true;
                numericEdit1.Enabled = false;
                numericEdit2.Enabled = false;
                numericEdit3.Enabled = false;
           
        }

        private void ManualThreshold_CheckedChanged(object sender, EventArgs e)
        {
                panel2.Visible = true;
                numericEdit1.Enabled = true;
                numericEdit2.Enabled = true;
                numericEdit3.Enabled = false;
         
        }

        private void NoThreshold_CheckedChanged(object sender, EventArgs e)
        {
                panel2.Visible = false;
        }

        private void ThresholdSetWindows1_Load(object sender, EventArgs e)
        {
           
                switch (this.Text)
                {
                    case "上四分位": numericEdit1.Value = ThresholdUpDownValue.UpQuartile_Up; numericEdit2.Value = ThresholdUpDownValue.UpQuartile_Down; break;
                    case "下四分位": numericEdit1.Value = ThresholdUpDownValue.DownQuartile_Up; numericEdit2.Value = ThresholdUpDownValue.DownQuartile_Down; break;
                    case "中位数": numericEdit1.Value = ThresholdUpDownValue.Median_Up1; numericEdit2.Value = ThresholdUpDownValue.Median_Down1; break;
                    case "四分位距": numericEdit1.Value = ThresholdUpDownValue.DistanceQuartile_Up; numericEdit2.Value = ThresholdUpDownValue.DistanceQuartile_Down; break;
                    case "上界": numericEdit1.Value = ThresholdUpDownValue.Upperbound_Up; numericEdit2.Value = ThresholdUpDownValue.Upperbound_Down; break;
                    case "下界": numericEdit1.Value = ThresholdUpDownValue.Downbound_Up; numericEdit2.Value = ThresholdUpDownValue.Downbound_Down; break;
                    case "均值": numericEdit1.Value = ThresholdUpDownValue.Average_Up; numericEdit2.Value = ThresholdUpDownValue.Average_Down; break;
                    case "方差": numericEdit1.Value = ThresholdUpDownValue.Variance_Up; numericEdit2.Value = ThresholdUpDownValue.Variance_Down; break;
                    case "均方根值": numericEdit1.Value = ThresholdUpDownValue.RMS_Value_Up1; numericEdit2.Value = ThresholdUpDownValue.RMS_Value_Down1; break;
                    case "歪度": numericEdit1.Value = ThresholdUpDownValue.Skewness_Up; numericEdit2.Value = ThresholdUpDownValue.Skewness_Down; break;
                    case "峭度": numericEdit1.Value = ThresholdUpDownValue.Kurtosis_Up; numericEdit2.Value = ThresholdUpDownValue.Kurtosis_Down; break;
                    case "峰度": numericEdit1.Value = ThresholdUpDownValue.Peak_Up; numericEdit2.Value = ThresholdUpDownValue.Peak_Down; break;
                    case "峰值频率": numericEdit1.Value = ThresholdUpDownValue.Frequency_Up; numericEdit2.Value = ThresholdUpDownValue.Frequency_Down; break;
                    case "频率幅值": numericEdit1.Value = ThresholdUpDownValue.FrequencyA_Up; numericEdit2.Value = ThresholdUpDownValue.FrequencyA_Down; break;
                    case "中心频率": numericEdit1.Value = ThresholdUpDownValue.OctaveValue_Up; numericEdit2.Value = ThresholdUpDownValue.OctaveValue_Down; break;
                }
           
        }
    }
}
