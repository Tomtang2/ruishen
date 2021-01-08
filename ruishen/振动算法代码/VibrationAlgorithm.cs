using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruishen.振动算法代码
{
    class VibrationAlgorithm
    {
        #region 计算趋势分析图和特征参量表特征值的方法
        /// <summary>
        /// 求取特征参数
        /// </summary>
        /// <param name="doubleArray1">输入数组</param>
        /// <returns>P[0]:均值 P[1]:均方根值 P[2]:波形率 P[3]:峰值 P[4]:峰峰值 P[5]:歪度 P[6]:峭度 P[7]:方差 </returns>
        public static double[] CalculateParasQuShi(double[] doubleArray1)
        {
            double[] doubleArray = new double[doubleArray1.Length];
            for (int i = 0; i < doubleArray1.Length; i++)
            {
                doubleArray[i] = doubleArray1[i];
            }

            double[] P = new double[8];
            int n = doubleArray.Length;
            double[] y = new double[n];
            double xm = 0.0; double xs = 0.0;
            double variance = 0;
            for (int j = 0; j < n; j++)
            {
                xm += doubleArray[j] / n;
                xs += doubleArray[j] * doubleArray[j] / n;
                y[j] = doubleArray[j];
              
            }
           
            P[0] = xm;//均值
            P[1] = Math.Sqrt(xs);//均方根值(方均根值)
            for (int j = 0; j < n; j++)
            {
               variance+= Math.Pow((doubleArray[j] - xm), 2)/n;
            }
            P[7] = variance;
            //P[7] = GetAbsMax(doubleArray) / GetAbsMean(doubleArray);//脉冲指标
            //P[8] = GetYuDu(doubleArray);//裕度指标

            xs = Math.Sqrt(Math.Abs(xs - xm * xm));
            int Np = n / 50; double xx;
            for (int k = 0; k < Np; k++)
            {
                for (int j = k; j < n; j++)
                {
                    if (Math.Abs(y[k]) < Math.Abs(y[j]))
                    {
                        xx = y[k];
                        y[k] = y[j];
                        y[j] = xx;
                    }
                }
            }
            for (int j = 0; j < Np; j++)
            {
                P[2] += Math.Abs(y[j]) / Np;
            }
            for (int j = 0; j < n; j++)
            {
                doubleArray[j] = (doubleArray[j] - xm) / xs;
            }

            double waa = 0.0; double wbb = 0.0;
            for (int j = 0; j < n; j++)
            {
                waa += doubleArray[j] * doubleArray[j] * doubleArray[j];
                wbb += doubleArray[j] * doubleArray[j] * doubleArray[j] * doubleArray[j];
            }
            P[2] = P[2] / xs;//波形率
            P[5] = Math.Abs(waa / (n - 1));//歪度
            P[6] = wbb / (n - 1);//峭度 
            //计算峰峰值
            double maxPeak = GetMax(doubleArray);
            double minPeak = GetMin(doubleArray);
            P[4] = maxPeak - minPeak;
            //计算峰值
            P[3] = P[4] / 2;

            return P;
        }
        #endregion

        #region 求振动数据的裕度指标
        private static double GetYuDu(double[] data)
        {
            double AbsMax = Math.Abs(data[0]);
            for (int i = 0; i < data.Length; i++)
            {
                if (AbsMax < Math.Abs(data[i]))
                {
                    AbsMax = Math.Abs(data[i]);
                }
            }
            double[] AbsValue = new double[data.Length];
            double xm = 0.0;
            double xr = 0.0;//方根幅值
            double c1 = 0.0;//裕度
            for (int i = 0; i < data.Length; i++)
            {
                AbsValue[i] = Math.Abs(data[i]);
                xm = xm + Math.Sqrt(AbsValue[i]) / data.Length;
            }
            xr = Math.Pow(xm, 2);
            c1 = AbsMax / xr;
            return c1;
        }

        #endregion

        #region 求振动数据绝对值的均值
        private static double GetAbsMean(double[] data)
        {
            double AbsMean = 0.0;
            double[] AbsValue = new double[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                AbsValue[i] = Math.Abs(data[i]);
                AbsMean = AbsMean + AbsValue[i] / data.Length;
            }
            return AbsMean;
        }

        #endregion

        #region 求振动数据绝对值的最大值
        private static double GetAbsMax(double[] data)
        {
            double AbsMax = Math.Abs(data[0]);
            for (int i = 0; i < data.Length; i++)
            {
                if (AbsMax < Math.Abs(data[i]))
                {
                    AbsMax = Math.Abs(data[i]);
                }
            }
            return AbsMax;
        }
        #endregion

        #region 求振动数据的最大值
        private static double GetMax(double[] data)
        {
            double max = data[0];
            for (int i = 0; i < data.Length; i++)
            {
                if (max < data[i])
                {
                    max = data[i];
                }
            }
            return max;
        }
        #endregion

        #region 振动数据的最小值
        private static double GetMin(double[] data)
        {
            double min = data[0];
            for (int i = 0; i < data.Length; i++)
            {
                if (min > data[i])
                {
                    min = data[i];
                }
            }
            return min;
        }
        #endregion
    }
}
