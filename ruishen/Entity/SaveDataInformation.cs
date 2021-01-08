using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruishen.Entity
{
    class SaveDataInformation
    {
        private int Id;//

        public int Id1
        {
            get { return Id; }
            set { Id = value; }
        }

        private string ProductModel;//产品型号

        public string ProductModel1
        {
            get { return ProductModel; }
            set { ProductModel = value; }
        }

        private string WheelSetSerialNumber;//轮对序列号

        public string WheelSetSerialNumber1
        {
            get { return WheelSetSerialNumber; }
            set { WheelSetSerialNumber = value; }
        }

        private string BearingType;//轴承类型

        public string BearingType1
        {
            get { return BearingType; }
            set { BearingType = value; }
        }

        private string BearingNumber;//轴承编号

        public string BearingNumber1
        {
            get { return BearingNumber; }
            set { BearingNumber = value; }
        }

        private string TestBench;//试验台

        public string TestBench1
        {
            get { return TestBench; }
            set { TestBench = value; }
        }

        private string Factory;//工厂

        public string Factory1
        {
            get { return Factory; }
            set { Factory = value; }
        }

        private DateTime TestTime;//测试时间

        public DateTime TestTime1
        {
            get { return TestTime; }
            set { TestTime = value; }
        }

        private string Users;//操作员

        public string Users1
        {
            get { return Users; }
            set { Users = value; }
        }

        private int SamplingFrequency;//采样频率

        public int SamplingFrequency1
        {
            get { return SamplingFrequency; }
            set { SamplingFrequency = value; }
        }

        private double SamplingDuration;//采样时长

        public double SamplingDuration1
        {
            get { return SamplingDuration; }
            set { SamplingDuration = value; }
        }

        private string WindowType;//窗类型

        public string WindowType1
        {
            get { return WindowType; }
            set { WindowType = value; }
        }

        private string AverageMode;//平均方式

        public string AverageMode1
        {
            get { return AverageMode; }
            set { AverageMode = value; }
        }

        private byte[] DataValue;//数据

        public byte[] DataValue1
        {
            get { return DataValue; }
            set { DataValue = value; }
        }
        private string TestStatus;//测试状态

        public string TestStatus1
        {
            get { return TestStatus; }
            set { TestStatus = value; }
        }

        private string ResultStatus;//结果状态

        public string ResultStatus1
        {
            get { return ResultStatus; }
            set { ResultStatus = value; }
        }

        private string StasticOne;//统计量名称1

        public string StasticOne1
        {
            get { return StasticOne; }
            set { StasticOne = value; }
        }

        private byte[] StasticDataOne;//统计量数据1

        public byte[] StasticDataOne1
        {
            get { return StasticDataOne; }
            set { StasticDataOne = value; }
        }

        private string StasticSecond;//统计量名称2

        public string StasticSecond1
        {
            get { return StasticSecond; }
            set { StasticSecond = value; }
        }

        private byte[] StasticDataSecond;//统计量数据2

        public byte[] StasticDataSecond1
        {
            get { return StasticDataSecond; }
            set { StasticDataSecond = value; }
        }

    }
}
