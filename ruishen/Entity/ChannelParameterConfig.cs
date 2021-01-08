using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruishen.Entity
{
    class ChannelParameterConfig
    {
        #region 通道参数设置界面参数类型
        private int ChanneNumber;//通道号

        public int ChanneNumber1
        {
            get { return ChanneNumber; }
            set { ChanneNumber = value; }
        }
        private int Switch;//开关

        public int Switch1
        {
            get { return Switch; }
            set { Switch = value; }
        }
        private string WheelAndAxle;//轮轴编号

        public string WheelAndAxle1
        {
            get { return WheelAndAxle; }
            set { WheelAndAxle = value; }
        }
        private string Coupling;//耦合方式

        public string Coupling1
        {
            get { return Coupling; }
            set { Coupling = value; }
        }
        private string Unit;//单位

        public string Unit1
        {
            get { return Unit; }
            set { Unit = value; }
        }
        private double Sensitivity;//灵敏度

        public double Sensitivity1
        {
            get { return Sensitivity; }
            set { Sensitivity = value; }
        }
        private string SensorRange;//量程

        public string SensorRange1
        {
            get { return SensorRange; }
            set { SensorRange = value; }
        }

        
        private string WheelSide;//轮侧

        public string WheelSide1
        {
            get { return WheelSide; }
            set { WheelSide = value; }
        }
        private int AnalysisBandWidth;//分析带宽

        public int AnalysisBandWidth1
        {
            get { return AnalysisBandWidth; }
            set { AnalysisBandWidth = value; }
        }
        private int FrequencyGraph;//谱线图

        public int FrequencyGraph1
        {
            get { return FrequencyGraph; }
            set { FrequencyGraph = value; }
        }
        private double Resolution;//分辨率

        public double Resolution1
        {
            get { return Resolution; }
            set { Resolution = value; }
        }
        private string WindowsFunction;//窗函数

        public string WindowsFunction1
        {
            get { return WindowsFunction; }
            set { WindowsFunction = value; }
        }
        private string AverageWay;//平均方式

        public string AverageWay1
        {
            get { return AverageWay; }
            set { AverageWay = value; }
        }
        private int AverageNumber;//平均次数

        public int AverageNumber1
        {
            get { return AverageNumber; }
            set { AverageNumber = value; }
        }
        private string AcquisitionMode;//采集模式

        public string AcquisitionMode1
        {
            get { return AcquisitionMode; }
            set { AcquisitionMode = value; }
        }
        private double AcquisitionTime;//采样时间

        public double AcquisitionTime1
        {
            get { return AcquisitionTime; }
            set { AcquisitionTime = value; }
        }

       

        private int SampleRate;//采样频率

        public int SampleRate1
        {
            get { return SampleRate; }
            set { SampleRate = value; }
        }

        private int SampleNumber;//采样点数

        public int SampleNumber1
        {
            get { return SampleNumber; }
            set { SampleNumber = value; }
        }
        #endregion
    }
}
