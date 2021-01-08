using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruishen.Entity
{
    class VibrationTimeCount
    {
        private int Id;

        public int Id1
        {
            get { return Id; }
            set { Id = value; }
        }
        private string MeasurePoint;

        public string MeasurePoint1
        {
            get { return MeasurePoint; }
            set { MeasurePoint = value; }
        }
        private int SampleFrequency;

        public int SampleFrequency1
        {
            get { return SampleFrequency; }
            set { SampleFrequency = value; }
        }
        private int DownId;

        public int DownId1
        {
            get { return DownId; }
            set { DownId = value; }
        }
        private int UpId;

        public int UpId1
        {
            get { return UpId; }
            set { UpId = value; }
        }
        private DateTime DataTime;

        public DateTime DataTime1
        {
            get { return DataTime; }
            set { DataTime = value; }
        }
    }
}
