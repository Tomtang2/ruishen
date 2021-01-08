using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.UI.Internal;

namespace ruishen.实时监测
{
    public partial class NoisyMonitor : Form
    {
        private int NoisyDispalyStatus = 1;//NoisyDispalyStatus=1代表声音信号，NoisyDispalyStatus=2代表频谱信号，NoisyDispalyStatus=3代表倍频程信号，NoisyDispalyStatus=4代表A计权信号

        public int NoisyDispalyStatus1
        {
            get { return NoisyDispalyStatus; }
            set { NoisyDispalyStatus = value; }
        }
        public NoisyMonitor()
        {
            InitializeComponent();
            N_Vioce.TextColor = Color.Red;

            #region 坐标轴标题初始化设置
            this.xAxis1.Caption = "Time/s";
            this.xAxis2.Caption = "Time/s";
            this.xAxis3.Caption = "Time/s";
            this.xAxis4.Caption = "Time/s";
            this.yAxis1.Caption = "SoundPressure/Pa";
            this.yAxis2.Caption = "SoundPressure/Pa";
            this.yAxis3.Caption = "SoundPressure/Pa";
            this.yAxis4.Caption = "SoundPressure/Pa";
            this.ScatterGraph_tableLayoutpanel.Visible = false;
            #endregion

        }
        #region 声音监控界面按钮
        //声音监测界面
        private void N_Vioce_Click(object sender, EventArgs e)
        {
            this.ScatterGraph_tableLayoutpanel.Visible = false;
            N_MainPanel.Dock = DockStyle.Fill;
            this.waveformPlot1.ClearData();
            this.waveformPlot2.ClearData();
            this.waveformPlot3.ClearData();
            this.waveformPlot4.ClearData();
            
            N_Vioce.TextColor = Color.Red;
            N_Octave.TextColor = Color.Black;
            N_Frequency.TextColor = Color.Black;
            N_AWeighting.TextColor = Color.Black;
            this.yAxis1.Mode = NationalInstruments.UI.AxisMode.AutoScaleLoose;
            this.yAxis2.Mode = NationalInstruments.UI.AxisMode.AutoScaleLoose;
            this.yAxis3.Mode = NationalInstruments.UI.AxisMode.AutoScaleLoose;
            this.yAxis4.Mode = NationalInstruments.UI.AxisMode.AutoScaleLoose;

            #region 坐标轴标题初始化设置
            this.xAxis1.Caption = "Time/s";
            this.xAxis2.Caption = "Time/s";
            this.xAxis3.Caption = "Time/s";
            this.xAxis4.Caption = "Time/s";
            this.yAxis1.Caption = "SoundPressure/Pa";
            this.yAxis2.Caption = "SoundPressure/Pa";
            this.yAxis3.Caption = "SoundPressure/Pa";
            this.yAxis4.Caption = "SoundPressure/Pa";
            this.waveformPlot1.FillMode = NationalInstruments.UI.PlotFillMode.None;
            this.waveformPlot1.LineStep = NationalInstruments.UI.LineStep.None;
            this.waveformPlot2.FillMode = NationalInstruments.UI.PlotFillMode.None;
            this.waveformPlot2.LineStep = NationalInstruments.UI.LineStep.None;
            this.waveformPlot3.FillMode = NationalInstruments.UI.PlotFillMode.None;
            this.waveformPlot3.LineStep = NationalInstruments.UI.LineStep.None;
            this.waveformPlot4.FillMode = NationalInstruments.UI.PlotFillMode.None;
            this.waveformPlot4.LineStep = NationalInstruments.UI.LineStep.None;
            NoisyDispalyStatus = 1;
            #endregion
        }
        //频谱界面
        private void N_Frequency_Click(object sender, EventArgs e)
        {
            this.ScatterGraph_tableLayoutpanel.Visible = false;
            N_MainPanel.Dock = DockStyle.Fill;
            this.waveformPlot1.ClearData();
            this.waveformPlot2.ClearData();
            this.waveformPlot3.ClearData();
            this.waveformPlot4.ClearData();

            this.waveformPlot1.FillMode = NationalInstruments.UI.PlotFillMode.None;
            this.waveformPlot1.LineStep = NationalInstruments.UI.LineStep.None;
            this.waveformPlot2.FillMode = NationalInstruments.UI.PlotFillMode.None;
            this.waveformPlot2.LineStep = NationalInstruments.UI.LineStep.None;
            this.waveformPlot3.FillMode = NationalInstruments.UI.PlotFillMode.None;
            this.waveformPlot3.LineStep = NationalInstruments.UI.LineStep.None;
            this.waveformPlot4.FillMode = NationalInstruments.UI.PlotFillMode.None;
            this.waveformPlot4.LineStep = NationalInstruments.UI.LineStep.None;
            N_Vioce.TextColor = Color.Black;
            N_Octave.TextColor = Color.Black;
            N_Frequency.TextColor = Color.Red;
            N_AWeighting.TextColor = Color.Black;
           
          //  this.waveformPlot1.PlotY.yAxis1.Range = new NationalInstruments.UI.Range(0D, 100D);
            this.yAxis1.Range = new NationalInstruments.UI.Range(0D, 200D);
            this.yAxis2.Range = new NationalInstruments.UI.Range(0D, 200D);
            this.yAxis3.Range = new NationalInstruments.UI.Range(0D, 200D);
            this.yAxis4.Range = new NationalInstruments.UI.Range(0D, 200D);
            this.yAxis1.Mode = NationalInstruments.UI.AxisMode.AutoScaleVisibleExact;
            this.yAxis2.Mode = NationalInstruments.UI.AxisMode.AutoScaleVisibleExact;
            this.yAxis3.Mode = NationalInstruments.UI.AxisMode.AutoScaleVisibleExact;
            this.yAxis4.Mode = NationalInstruments.UI.AxisMode.AutoScaleVisibleExact;
            #region 坐标轴标题初始化设置
            this.xAxis1.Caption = "Frequency/(Hz)";
            this.xAxis2.Caption = "Frequency/(Hz)";
            this.xAxis3.Caption = "Frequency/(Hz)";
            this.xAxis4.Caption = "Frequency/(Hz)";
            this.yAxis1.Caption = "SoundPressure/Pa";
            this.yAxis2.Caption = "SoundPressure/Pa";
            this.yAxis3.Caption = "SoundPressure/Pa";
            this.yAxis4.Caption = "SoundPressure/Pa";
            NoisyDispalyStatus = 2;
            #endregion
        }
        //倍频程界面
        private void N_Octave_Click(object sender, EventArgs e)
        {
            this.ScatterGraph_tableLayoutpanel.Dock = DockStyle.Fill;
            this.ScatterGraph_tableLayoutpanel.Visible = true;
            //this.waveformPlot1.ClearData();
            //this.waveformPlot2.ClearData();
            //this.waveformPlot3.ClearData();
            //this.waveformPlot4.ClearData();
            //this.waveformPlot1.FillMode = NationalInstruments.UI.PlotFillMode.FillAndLines;
            //this.waveformPlot1.LineStep = NationalInstruments.UI.LineStep.XYStep;
            //this.waveformPlot2.FillMode = NationalInstruments.UI.PlotFillMode.FillAndLines;
            //this.waveformPlot2.LineStep = NationalInstruments.UI.LineStep.XYStep;
            //this.waveformPlot3.FillMode = NationalInstruments.UI.PlotFillMode.FillAndLines;
            //this.waveformPlot3.LineStep = NationalInstruments.UI.LineStep.XYStep;
            //this.waveformPlot4.FillMode = NationalInstruments.UI.PlotFillMode.FillAndLines;
            //this.waveformPlot4.LineStep = NationalInstruments.UI.LineStep.XYStep;

            N_Vioce.TextColor = Color.Black;
            N_Octave.TextColor = Color.Red;
            N_Frequency.TextColor = Color.Black;
            N_AWeighting.TextColor = Color.Black;
            //this.yAxis1.Mode = NationalInstruments.UI.AxisMode.AutoScaleLoose;
            //this.yAxis2.Mode = NationalInstruments.UI.AxisMode.AutoScaleLoose;
            //this.yAxis3.Mode = NationalInstruments.UI.AxisMode.AutoScaleLoose;
            //this.yAxis4.Mode = NationalInstruments.UI.AxisMode.AutoScaleLoose;
            
            //#region 坐标轴标题初始化设置
            //this.xAxis1.Caption = "Frequency/(Hz)";
            //this.xAxis2.Caption = "Frequency/(Hz)";
            //this.xAxis3.Caption = "Frequency/(Hz)";
            //this.xAxis4.Caption = "Frequency/(Hz)";
            //this.yAxis1.Caption = "SPL/dB";
            //this.yAxis2.Caption = "SPL/dB";
            //this.yAxis3.Caption = "SPL/dB";
            //this.yAxis4.Caption = "SPL/dB";
            NoisyDispalyStatus = 3;
            #endregion
        }
        //A计权界面
        private void N_AWeighting_Click(object sender, EventArgs e)
        {
            this.ScatterGraph_tableLayoutpanel.Visible = false;
            N_MainPanel.Dock = DockStyle.Fill;
            this.waveformPlot1.ClearData();
            this.waveformPlot2.ClearData();
            this.waveformPlot3.ClearData();
            this.waveformPlot4.ClearData();
            this.waveformPlot1.FillMode = NationalInstruments.UI.PlotFillMode.FillAndLines;
            this.waveformPlot1.LineStep = NationalInstruments.UI.LineStep.XYStep;
            this.waveformPlot2.FillMode = NationalInstruments.UI.PlotFillMode.FillAndLines;
            this.waveformPlot2.LineStep = NationalInstruments.UI.LineStep.XYStep;
            this.waveformPlot3.FillMode = NationalInstruments.UI.PlotFillMode.FillAndLines;
            this.waveformPlot3.LineStep = NationalInstruments.UI.LineStep.XYStep;
            this.waveformPlot4.FillMode = NationalInstruments.UI.PlotFillMode.FillAndLines;
            this.waveformPlot4.LineStep = NationalInstruments.UI.LineStep.XYStep;
            
            N_Vioce.TextColor = Color.Black;
            N_Octave.TextColor = Color.Black;
            N_Frequency.TextColor = Color.Black;
            N_AWeighting.TextColor = Color.Red;

            #region 坐标轴标题初始化设置
            this.xAxis1.Caption = "Time/s";
            this.xAxis2.Caption = "Time/s";
            this.xAxis3.Caption = "Time/s";
            this.xAxis4.Caption = "Time/s";
            this.yAxis1.Caption = "SPL/dBA";
            this.yAxis2.Caption = "SPL/dBA";
            this.yAxis3.Caption = "SPL/dBA";
            this.yAxis4.Caption = "SPL/dBA";
            #endregion
            this.yAxis1.Mode = NationalInstruments.UI.AxisMode.Fixed;
            this.yAxis1.Range=new NationalInstruments.UI.Range(0,180);
            this.yAxis2.Mode = NationalInstruments.UI.AxisMode.Fixed;
            this.yAxis2.Range = new NationalInstruments.UI.Range(0, 180);
            this.yAxis3.Mode = NationalInstruments.UI.AxisMode.Fixed;
            this.yAxis3.Range = new NationalInstruments.UI.Range(0, 180);
            this.yAxis4.Mode = NationalInstruments.UI.AxisMode.Fixed;
            this.yAxis4.Range = new NationalInstruments.UI.Range(0, 180);

            NoisyDispalyStatus = 4;
        }
        //#endregion

        private void N_statistical_Click(object sender, EventArgs e)
        {
            VibrationStatistical vibrationStatistical = GenericSingleton<VibrationStatistical>.CreateInstrance();
            vibrationStatistical.Show();
        }


    }
}
