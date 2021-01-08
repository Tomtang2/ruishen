using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruishen.Entity
{
    class AlgorithmConfig
    {
        private string ParameterClassify;//参数所属类型

        public string ParameterClassify1
        {
            get { return ParameterClassify; }
            set { ParameterClassify = value; }
        }
        private string ParameterName;//参数名称

        public string ParameterName1
        {
            get { return ParameterName; }
            set { ParameterName = value; }
        }


        private int IsDisplay;//是否显示

        public int IsDisplay1
        {
            get { return IsDisplay; }
            set { IsDisplay = value; }
        }

        private int IsStandard;//是否作为判断标准

        public int IsStandard1
        {
            get { return IsStandard; }
            set { IsStandard = value; }
        }

        private double ThresholdConfig;//阈值设置

        public double ThresholdConfig1
        {
            get { return ThresholdConfig; }
            set { ThresholdConfig = value; }
        }
    }
}
