using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruishen.Entity
{
    class ThresholdUpDownValue
    {
        private static double upQuartile_Up = 0;//上四分位上限

        public static double UpQuartile_Up
        {
            get { return ThresholdUpDownValue.upQuartile_Up; }
            set { ThresholdUpDownValue.upQuartile_Up = value; }
        }

        private static double upQuartile_Down = 0;//上四分位下限

        public static double UpQuartile_Down
        {
            get { return ThresholdUpDownValue.upQuartile_Down; }
            set { ThresholdUpDownValue.upQuartile_Down = value; }
        }

        private static double downQuartile_Up = 0;//下四分位上限

        public static double DownQuartile_Up
        {
            get { return ThresholdUpDownValue.downQuartile_Up; }
            set { ThresholdUpDownValue.downQuartile_Up = value; }
        }

        private static double downQuartile_Down=0;//下四分位下限

        public static double DownQuartile_Down
        {
            get { return ThresholdUpDownValue.downQuartile_Down; }
            set { ThresholdUpDownValue.downQuartile_Down = value; }
        }

        private static double Median_Up = 0;//中位数上限

        public static double Median_Up1
        {
            get { return ThresholdUpDownValue.Median_Up; }
            set { ThresholdUpDownValue.Median_Up = value; }
        }

        private static double Median_Down = 0;//中位数下限

        public static double Median_Down1
        {
            get { return ThresholdUpDownValue.Median_Down; }
            set { ThresholdUpDownValue.Median_Down = value; }
        }

        private static double distanceQuartile_Up = 0;//四分位距上限

        public static double DistanceQuartile_Up
        {
            get { return ThresholdUpDownValue.distanceQuartile_Up; }
            set { ThresholdUpDownValue.distanceQuartile_Up = value; }
        }
        private static double distanceQuartile_Down = 0;//四分位距下限

        public static double DistanceQuartile_Down
        {
            get { return ThresholdUpDownValue.distanceQuartile_Down; }
            set { ThresholdUpDownValue.distanceQuartile_Down = value; }
        }

        private static double upperbound_Up = 0;//上界上限

        public static double Upperbound_Up
        {
            get { return ThresholdUpDownValue.upperbound_Up; }
            set { ThresholdUpDownValue.upperbound_Up = value; }
        }

        private static double upperbound_Down = 0;//上界下限

        public static double Upperbound_Down
        {
            get { return ThresholdUpDownValue.upperbound_Down; }
            set { ThresholdUpDownValue.upperbound_Down = value; }
        }

        private static double downbound_Up = 0;//下界上限

        public static double Downbound_Up
        {
            get { return ThresholdUpDownValue.downbound_Up; }
            set { ThresholdUpDownValue.downbound_Up = value; }
        }
        private static double downbound_Down = 0;//下界下限

        public static double Downbound_Down
        {
            get { return ThresholdUpDownValue.downbound_Down; }
            set { ThresholdUpDownValue.downbound_Down = value; }
        }

        private static double average_Up = 0;//平均值上限

        public static double Average_Up
        {
            get { return ThresholdUpDownValue.average_Up; }
            set { ThresholdUpDownValue.average_Up = value; }
        }

        private static double average_Down = 0;//平均值下限

        public static double Average_Down
        {
            get { return ThresholdUpDownValue.average_Down; }
            set { ThresholdUpDownValue.average_Down = value; }
        }

        private static double variance_Up = 0;//方差上限

        public static double Variance_Up
        {
            get { return ThresholdUpDownValue.variance_Up; }
            set { ThresholdUpDownValue.variance_Up = value; }
        }

        private static double variance_Down = 0;//方差下限

        public static double Variance_Down
        {
            get { return ThresholdUpDownValue.variance_Down; }
            set { ThresholdUpDownValue.variance_Down = value; }
        }

        private static double RMS_Value_Up = 0;//均方根值上限

        public static double RMS_Value_Up1
        {
            get { return ThresholdUpDownValue.RMS_Value_Up; }
            set { ThresholdUpDownValue.RMS_Value_Up = value; }
        }

        

        private static double RMS_Value_Down = 0;//均方根值下限

        public static double RMS_Value_Down1
        {
            get { return ThresholdUpDownValue.RMS_Value_Down; }
            set { ThresholdUpDownValue.RMS_Value_Down = value; }
        }
        private static double skewness_Up = 0;//歪度上限

        public static double Skewness_Up
        {
            get { return ThresholdUpDownValue.skewness_Up; }
            set { ThresholdUpDownValue.skewness_Up = value; }
        }
        private static double skewness_Down = 0;//歪度下限

        public static double Skewness_Down
        {
            get { return ThresholdUpDownValue.skewness_Down; }
            set { ThresholdUpDownValue.skewness_Down = value; }
        }

        private static double kurtosis_Up = 0;//峭度上限

        public static double Kurtosis_Up
        {
            get { return ThresholdUpDownValue.kurtosis_Up; }
            set { ThresholdUpDownValue.kurtosis_Up = value; }
        }

        private static double kurtosis_Down = 0;//峭度下限

        public static double Kurtosis_Down
        {
            get { return ThresholdUpDownValue.kurtosis_Down; }
            set { ThresholdUpDownValue.kurtosis_Down = value; }
        }

        private static double peak_Up = 0;//峰度上限

        public static double Peak_Up
        {
            get { return ThresholdUpDownValue.peak_Up; }
            set { ThresholdUpDownValue.peak_Up = value; }
        }

        private static double peak_Down = 0;//峰度下限

        public static double Peak_Down
        {
            get { return ThresholdUpDownValue.peak_Down; }
            set { ThresholdUpDownValue.peak_Down = value; }
        }

        private static double frequency_Up = 0;//峰值频率上限

        public static double Frequency_Up
        {
            get { return ThresholdUpDownValue.frequency_Up; }
            set { ThresholdUpDownValue.frequency_Up = value; }
        }

        private static double frequency_Down = 0;//峰值频率下限

        public static double Frequency_Down
        {
            get { return ThresholdUpDownValue.frequency_Down; }
            set { ThresholdUpDownValue.frequency_Down = value; }
        }

        private static double frequencyA_Up = 0;//频率幅值上限

        public static double FrequencyA_Up
        {
            get { return ThresholdUpDownValue.frequencyA_Up; }
            set { ThresholdUpDownValue.frequencyA_Up = value; }
        }

        private static double frequencyA_Down = 0;//频率幅值下限

        public static double FrequencyA_Down
        {
            get { return ThresholdUpDownValue.frequencyA_Down; }
            set { ThresholdUpDownValue.frequencyA_Down = value; }
        }

        private static double octaveValue_Up = 0;//中心频率上限

        public static double OctaveValue_Up
        {
            get { return ThresholdUpDownValue.octaveValue_Up; }
            set { ThresholdUpDownValue.octaveValue_Up = value; }
        }

        private static double octaveValue_Down = 0;//中心频率下限

        public static double OctaveValue_Down
        {
            get { return ThresholdUpDownValue.octaveValue_Down; }
            set { ThresholdUpDownValue.octaveValue_Down = value; }
        }

       

    }
}
