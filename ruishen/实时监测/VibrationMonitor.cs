using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace ruishen.实时监测
{
    public partial class VibrationMonitor : Form
    {
        private int VibrationDisplayStatus = 1;//VibrationDisplayStatus=1代表加速度信号,VibrationDisplayStatus=2代表速度信号,VibrationDisplayStatus=3代表位移信号,VibrationDisplayStatus=4代表频谱信号

        public int VibrationDisplayStatus1
        {
            get { return VibrationDisplayStatus; }
            set { VibrationDisplayStatus = value; }
        }

        public VibrationMonitor()
        {
            InitializeComponent();
            
            B_AcceleratedSpeed.TextColor = Color.Red;
            #region 坐标轴标题初始化设置
            this.xAxis1.Caption = "Time/s";
            this.xAxis2.Caption = "Time/s";
            this.xAxis3.Caption = "Time/s";
            this.xAxis4.Caption = "Time/s";
            this.yAxis1.Caption = "Acceleration/g";
            this.yAxis2.Caption = "Acceleration/g";
            this.yAxis3.Caption = "Acceleration/g";
            this.yAxis4.Caption = "Acceleration/g";
            #endregion
        }
        //加速度按钮
        private void B_AcceleratedSpeed_Click(object sender, EventArgs e)
        {
            
            this.waveformPlot1.ClearData();
            this.waveformPlot2.ClearData();
            this.waveformPlot3.ClearData();
            this.waveformPlot4.ClearData();

            //按钮单击字体颜色设置
            B_AcceleratedSpeed.TextColor = Color.Red;
            B_Displacement.TextColor = Color.Black;
            B_FrequencySpectrum.TextColor = Color.Black;
            B_Velocity.TextColor = Color.Black;

            //坐标轴名称设置
            this.xAxis1.Caption = "Time/s";
            this.xAxis2.Caption = "Time/s";
            this.xAxis3.Caption = "Time/s";
            this.xAxis4.Caption = "Time/s";
            this.yAxis1.Caption = "Acceleration/g";
            this.yAxis2.Caption = "Acceleration/g";
            this.yAxis3.Caption = "Acceleration/g";
            this.yAxis4.Caption = "Acceleration/g";

            VibrationDisplayStatus = 1;
        }
        //速度按钮
        private void B_Velocity_Click(object sender, EventArgs e)
        {
            this.waveformPlot1.ClearData();
            this.waveformPlot2.ClearData();
            this.waveformPlot3.ClearData();
            this.waveformPlot4.ClearData();
            
            B_AcceleratedSpeed.TextColor = Color.Black;
            B_Displacement.TextColor = Color.Black;
            B_FrequencySpectrum.TextColor = Color.Black;
            B_Velocity.TextColor = Color.Red;

            //坐标轴名称设置
            this.xAxis1.Caption = "Time/s";
            this.xAxis2.Caption = "Time/s";
            this.xAxis3.Caption = "Time/s";
            this.xAxis4.Caption = "Time/s";
            // this.yAxis1.Caption.
            this.yAxis1.Caption = "Velocity/(m/s)";
            this.yAxis2.Caption = "Velocity/(m/s)";
            this.yAxis3.Caption = "Velocity/(m/s)";
            this.yAxis4.Caption = "Velocity/(m/s)";

            VibrationDisplayStatus = 2;
        }
        //位移按钮
        private void B_Displacement_Click(object sender, EventArgs e)
        {
            this.waveformPlot1.ClearData();
            this.waveformPlot2.ClearData();
            this.waveformPlot3.ClearData();
            this.waveformPlot4.ClearData();
            
            B_AcceleratedSpeed.TextColor = Color.Black;
            B_Displacement.TextColor = Color.Red;
            B_FrequencySpectrum.TextColor = Color.Black;
            B_Velocity.TextColor = Color.Black;

            //坐标轴名称设置
            this.xAxis1.Caption = "Time/s";
            this.xAxis2.Caption = "Time/s";
            this.xAxis3.Caption = "Time/s";
            this.xAxis4.Caption = "Time/s";
            // this.yAxis1.Caption
            this.yAxis1.Caption = "Displacement/mm";
            this.yAxis2.Caption = "Displacement/mm";
            this.yAxis3.Caption = "Displacement/mm";
            this.yAxis4.Caption = "Displacement/mm";

            VibrationDisplayStatus = 3;
        }
        //频谱按钮
        private void B_FrequencySpectrum_Click(object sender, EventArgs e)
        {
            this.waveformPlot1.ClearData();
            this.waveformPlot2.ClearData();
            this.waveformPlot3.ClearData();
            this.waveformPlot4.ClearData();
            
            B_AcceleratedSpeed.TextColor = Color.Black;
            B_Displacement.TextColor = Color.Black;
            B_FrequencySpectrum.TextColor = Color.Red;
            B_Velocity.TextColor = Color.Black;

            this.xAxis1.Caption = "Frequency/Hz";
            this.xAxis2.Caption = "Frequency/Hz";
            this.xAxis3.Caption = "Frequency/Hz";
            this.xAxis4.Caption = "Frequency/Hz";
            // this.yAxis1.Caption
            this.yAxis1.Caption = "Amplitude/g";
            this.yAxis2.Caption = "Amplitude/g";
            this.yAxis3.Caption = "Amplitude/g";
            this.yAxis4.Caption = "Amplitude/g";
            this.yAxis1.Range = new NationalInstruments.UI.Range(0D, 200D);
            this.yAxis2.Range = new NationalInstruments.UI.Range(0D, 200D);
            this.yAxis3.Range = new NationalInstruments.UI.Range(0D, 200D);
            this.yAxis4.Range = new NationalInstruments.UI.Range(0D, 200D);

            VibrationDisplayStatus = 4;
        }
        //统计按钮
        private void B_statistical_Click(object sender, EventArgs e)
        {
            vibrationStatisticalInit();
           
        }
        public void vibrationStatisticalInit() {
            VibrationStatistical vibrationStatistical = GenericSingleton<VibrationStatistical>.CreateInstrance();
            vibrationStatistical.Show();
        }
    }
}
