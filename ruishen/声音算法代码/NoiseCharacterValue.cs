using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DigitalSignalProcessing;


namespace ruishen.声音算法代码
{
    class NoiseCharacterValue
    {
        //冒泡排序算法
        public static double[] sort(double[] input_sort)         //sort
        {
            double median = 0;
            for (int i = 0; i < input_sort.Length - 1; i++)
            {
                for (int j = i + 1; j < input_sort.Length; j++)
                {
                    if (input_sort[i] > input_sort[j])
                    {
                        median = input_sort[i];
                        input_sort[i] = input_sort[j];
                        input_sort[j] = median;
                    }
                }
            }
            return input_sort;
        }

        //快速排序算法
        public static void QuickSort(double[] array, int low, int high)
        {
            if (low >= high)
                return;
            //完成一次单元排序
            int index = SortUnit(array, low, high);
            //递归调用，对左边部分的数组进行单元排序
            QuickSort(array, low, index - 1);
            //递归调用，对右边部分的数组进行单元排序
            QuickSort(array, index + 1, high);

        }

         /// <summary>
        /// 单元排序
        /// </summary>
        /// <param name="array">要排序的数组</param>
        /// <param name="low">下标开始位置，向右查找</param>
        /// <param name="high">下标开始位置，向右查找</param>
        /// <returns>每次单元排序的停止下标</returns>
        public static int SortUnit(double[] array, int low, int high)
        {
            double key = array[low];//基准数
            while (low < high)
            {
                //从high往前找小于或等于key的值
                while (low < high && array[high] > key)
                    high--;
                //比key小开等的放左边
                array[low] = array[high];
                //从low往后找大于key的值
                while (low < high && array[low] <= key)
                    low++;
                //比key大的放右边
                array[high] = array[low];
           }
            //结束循环时，此时low等于high，左边都小于或等于key，右边都大于key。将key放在游标当前位置。 
            array[low] = key;
            return high;
        }


        //上四分位数计算方法
        public static double up_Quartile(double[] input_sort)  
        {
            double output_upQuartile = 0.0;
         

          //  int point_Quartile = Convert.ToInt16(input_sort.Length * 0.75);

            output_upQuartile = input_sort[Convert.ToInt16(input_sort.Length * 0.75)];

            return output_upQuartile;

        }
        //下四分位数计算方法
        public static double down_Quartile(double[] input_sort)  
        {
            double output_DownQuartile = 0.0;
            //sort(input_sort);


          //  int point_Quartile = Convert.ToInt16(input_sort.Length * 0.25);

            output_DownQuartile = input_sort[Convert.ToInt16(input_sort.Length * 0.25)];

            return output_DownQuartile;

        }
        //中位数计算方法
        public static double Median(double[] input_sort)      
        {
            double output_Median = 0.0;
          //  sort(input_sort);


          //  int point_Quartile = Convert.ToInt16(input_sort.Length * 0.5);

            output_Median = input_sort[Convert.ToInt16(input_sort.Length * 0.5)];

            return output_Median;

        }
        // 四分位距计算方法
        public static double distance_Quartile(double[] input_sort)  
        {
            double distance = 0.0;
            distance = up_Quartile(input_sort) - down_Quartile(input_sort);
            return distance;

        }

        //上界计算方法
        public static double upper_bound(double[] input_sort)    
        {
            double upperbound = 0.0;
            upperbound = up_Quartile(input_sort) + 1.5 * distance_Quartile(input_sort);
            return upperbound;

        }

        //下界计算方法
        public static double lower_bound(double[] input_sort)      
        {
            double lowerbound = 0.0;
            lowerbound = down_Quartile(input_sort) - 1.5 * distance_Quartile(input_sort);
            return lowerbound;

        }

        //离群计算方法
        public static int number_outbound(double[] input)
        {

            int number = 0;
            for (int i = 0; i < input.Length; i++)
            {


                if (input[i] > upper_bound(input) || input[i] < lower_bound(input))
                {
                    number += number;
                }


            }

            return number;
        }

        //
        public static double pre_outbound(double[] input)
        {

            double pre = 0.0;
            pre = (double)(number_outbound(input) / input.Length);
            return pre;
        }

        public static double PeakFrequency(double[] input,double Frequency) 
        {
            double[] result = new double[input.Length ];
            Complex[] Results = new Complex[input.Length];
            Results = DigitalSignalProcessing.NiSignalProcessing.FFT(input);
            for (int i = 0; i < input.Length ; i++)
            {
                result[i] = Results[i].GetModul() / input.Length;
            }
          return MaxIndex(result,Frequency);
        }

        //传入一个数组,求出一个数组的最大值的位置
        public static double MaxIndex<T>(T[] arr,double Frequency) where T : IComparable<T>
        {
            var i_Pos = 1;
            var value = arr[1];
            for (var i = 2; i < arr.Length; ++i)
            {
                var _value = arr[i];
                if (_value.CompareTo(value) > 0)
                {
                    value = _value;
                    i_Pos = i;
                }
            }
            return ((double)i_Pos*Frequency/arr.Length);
        }

        public static double RMSPlus(double [] input)
        {
            int length = input.Length;
            double sum = 0;
            double result = 0;
            for (int i = 0; i < length;i++ )
            {
                sum += input[i];
            }
            double average = (double)sum / length;
            for (int i = 0; i < length; i++)
            {
               result+= Math.Pow(input[i]-average,2);
            }
            return Math.Sqrt(result/length);
        }


    }
}
