using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruishen.Entity
{
    class DataInformation
    {
        #region 数据存储实体类
        private int Id;//主键ID

        public int Id1
        {
            get { return Id; }
            set { Id = value; }
        }
        private string DeviceNumber;//设备编号

        public string DeviceNumber1
        {
            get { return DeviceNumber; }
            set { DeviceNumber = value; }
        }
        private string FactoryNumber;//工厂编号

        public string FactoryNumber1
        {
            get { return FactoryNumber; }
            set { FactoryNumber = value; }
        }
        private string MeasurePoint;//测点

        public string MeasurePoint1
        {
            get { return MeasurePoint; }
            set { MeasurePoint = value; }
        }
        private int SampleFrequency;//采样频率

        public int SampleFrequency1
        {
            get { return SampleFrequency; }
            set { SampleFrequency = value; }
        }
        private string DataStatus;//数据状态

        public string DataStatus1
        {
            get { return DataStatus; }
            set { DataStatus = value; }
        }
        private DateTime DataTime;//采样的当前时间

        public DateTime DataTime1
        {
            get { return DataTime; }
            set { DataTime = value; }
        }

        private byte[] DataValue;

        public byte[] DataValue1//采样的数据
        {
            get { return DataValue; }
            set { DataValue = value; }
        }
        #endregion

    }
}
