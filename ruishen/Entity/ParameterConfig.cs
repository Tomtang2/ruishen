using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruishen.Entity
{
    class ParameterConfig
    {
        #region 参数配置属性
        private int ChannelNumber;
        private string PhysicalChannel;
        private int MinimumValue;
        private int MaximumValue;
        private int SampleRate;
        private int SampleNumber;
        private string Coupling;
        private double Sensitivity;
        private string Unit;
        public int ChannelNumber1
        {
            get { return ChannelNumber; }
            set { ChannelNumber = value; }
        }
       
        public string PhysicalChannel1
        {
            get { return PhysicalChannel; }
            set { PhysicalChannel = value; }
        }
      
        public int MinimumValue1
        {
            get { return MinimumValue; }
            set { MinimumValue = value; }
        }

        public int MaximumValue1
        {
            get { return MaximumValue; }
            set { MaximumValue = value; }
        }

        public int SampleRate1
        {
            get { return SampleRate; }
            set { SampleRate = value; }
        }

        public int SampleNumber1
        {
            get { return SampleNumber; }
            set { SampleNumber = value; }
        }

        public string Coupling1
        {
            get { return Coupling; }
            set { Coupling = value; }
        }

        public double Sensitivity1
        {
            get { return Sensitivity; }
            set { Sensitivity = value; }
        }

        public string Unit1
        {
            get { return Unit; }
            set { Unit = value; }
        }
        #endregion
    }
}
