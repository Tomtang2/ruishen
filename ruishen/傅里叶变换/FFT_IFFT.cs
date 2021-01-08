using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruishen.傅里叶变换
{
    class FFT_IFFT
    {
        #region 求复数complex数组的模modul数组
        /// <summary>
        /// 求复数complex数组的模modul数组
        /// </summary>
        /// <param name="input">复数数组</param>
        /// <returns>模数组</returns>
        public static double[] Cmp2Mdl(Complex[] input)
        {
            ///有输入数组的长度确定输出数组的长度
            double[] output = new double[input.Length];

            ///对所有输入复数求模
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Real > 0)
                {
                    output[i] = -input[i].ToModul();
                }
                else
                {
                    output[i] = input[i].ToModul();
                }
            }
            ///返回模数组
            return output;
        }
        #endregion

        #region 实数做傅里叶变换或反变换
        /// <summary>
        /// 傅立叶变换或反变换，递归实现多级蝶形运算
        /// 作为反变换输出需要再除以序列的长度
        /// </summary>
        /// <param name="input">输入实序列</param>
        /// <param name="invert">false=正变换，true=反变换</param>
        /// <returns>傅立叶变换或反变换后的序列</returns>
        public static Complex[] FFT(double[] input, bool invert)
        {
            int n = NextPow2(input);

            ///由输入序列确定输出序列的长度
            Complex[] output = new Complex[n];

            if (n == input.Length)
            {
                ///将输入的实数转为复数
                for (int i = 0; i < input.Length; i++)
                {
                    output[i] = new Complex(input[i]);
                }
            }
            else
            {
                List<double> list = input.ToList();
                for (int i = 0; i < n - input.Length; i++)
                {
                    list.Add(0);
                }

                double[] newinput = list.ToArray();
                for (int i = 0; i < n; i++)
                {
                    output[i] = new Complex(newinput[i]);
                }
            }

            ///返回FFT或IFFT后的序列
            return output = FFT(output, invert);
        }
        #endregion

        #region 复数傅里叶变换或反变换
        /// <summary>
        /// 傅立叶变换或反变换，递归实现多级蝶形运算
        /// 作为反变换输出需要再除以序列的长度
        /// ！注意：输入此类的序列长度必须是2^n
        /// </summary>
        /// <param name="input">复数输入序列</param>
        /// <param name="invert">false=正变换，true=反变换</param>
        /// <returns>傅立叶变换或反变换后的序列</returns>
        public static Complex[] FFT(Complex[] input, bool invert)
        {
            ///输入序列只有一个元素，输出这个元素并返回
            if (input.Length == 1)
            {
                return new Complex[] { input[0] };
            }

            ///输入序列的长度
            int length = input.Length;

            ///输入序列的长度的一半
            int half = length / 2;

            ///有输入序列的长度确定输出序列的长度
            Complex[] output = new Complex[length];

            ///正变换旋转因子的基数
            double fac = -2.0 * Math.PI / length;

            ///反变换旋转因子的基数是正变换的相反数
            if (invert)
            {
                fac = -fac;
            }

            ///序列中下标为偶数的点
            Complex[] evens = new Complex[half];

            for (int i = 0; i < half; i++)
            {
                evens[i] = input[2 * i];
            }

            ///求偶数点FFT或IFFT的结果，递归实现多级蝶形运算
            Complex[] evenResult = FFT(evens, invert);

            ///序列中下标为奇数的点
            Complex[] odds = new Complex[half];

            for (int i = 0; i < half; i++)
            {
                odds[i] = input[2 * i + 1];
            }

            ///求偶数点FFT或IFFT的结果，递归实现多级蝶形运算
            Complex[] oddResult = FFT(odds, invert);

            for (int k = 0; k < half; k++)
            {
                ///旋转因子
                double fack = fac * k;

                ///进行蝶形运算
                Complex oddPart = oddResult[k] * new Complex(Math.Cos(fack), Math.Sin(fack));
                output[k] = evenResult[k] + oddPart;
                output[k + half] = evenResult[k] - oddPart;
            }

            ///返回FFT或IFFT的结果
            return output;
        }
        #endregion

        #region 获得不超过输入数据长度的最小2^n
        /// <summary>
        /// 获得不超过输入数据长度的最小2^n
        /// </summary>
        /// <param name="doubleArray"></param>
        /// <returns></returns>
        public static int NextPow2(double[] doubleArray)
        {
            return (int)Math.Pow(2, Math.Ceiling(Math.Log(doubleArray.Length, 2)));
        }
        #endregion

        #region 计算FFT,得到傅里叶变换数据的一半,用于实时显示
        /// <summary>
        /// 计算FFT,得到傅里叶变换数据的一半
        /// </summary>
        /// <param name="doubleArray"></param>
        /// <param name="nfft"></param>
        /// <returns></returns>
        public static double[] GetHalfFFTValue(double[] doubleArray, int nfft)
        {
            double[] doubleArray1 = new double[nfft / 2];
            Complex[] mFreData = FFT_IFFT.FFT(doubleArray, false);
            //double[] data = Cmp2Mdl(mFreData);
            //for (int i = 0; i < nfft / 2; i++)
            //{
            //    doubleArray1[i] = data[i];
            //}
            for (int i = 0; i < nfft / 2; i++)
            {
                doubleArray1[i] =Math.Pow((Math.Pow(mFreData[i].Real, 2) + Math.Pow(mFreData[i].Image, 2)) / Math.Pow(doubleArray.Length, 2),0.5);
            }
            //doubleArray1[0] = 0;//去除直流分量
            return doubleArray1;
        }
        #endregion

        #region 计算FFT,得到傅里叶变换数据的一半
        /// <summary>
        /// 计算FFT,得到傅里叶变换数据的一半
        /// </summary>
        /// <param name="doubleArray"></param>
        /// <param name="nfft"></param>
        /// <returns></returns>
        public static double[] GetHalfFFTValue1(double[] doubleArray, int nfft)
        {
            double[] doubleArray1 = new double[nfft / 2];
            Complex[] mFreData = FFT_IFFT.FFT(doubleArray, false);
            double[] data = Cmp2Mdl(mFreData);
            for (int i = 0; i < nfft / 2; i++)
            {
                doubleArray1[i] = 2 * (Math.Pow(mFreData[i].Real, 2) + Math.Pow(mFreData[i].Image, 2)) / doubleArray.Length;
            }
            doubleArray1[0] = 0;//去除直流分量
            return doubleArray1;
        }
        #endregion

        #region 计算FFT,得到傅里叶变换数据的全部
        public static double[] GetFFTValue1(double[] doubleArray, int nfft)
        {
            double[] doubleArray1 = new double[nfft];
            Complex[] mFreData = FFT_IFFT.FFT(doubleArray, false);
            double[] data = Cmp2Mdl(mFreData);
            for (int i = 0; i < nfft; i++)
            {
                doubleArray1[i] = data[i];
            }
            return doubleArray1;
        }
        #endregion

        #region 将FFT后的数据进行IFFT计算
        /// <summary>
        /// 将FFT后的数据进行IFFT计算
        /// </summary>
        /// <param name="doubleArray"></param>
        /// <param name="nfft"></param>
        /// <returns></returns>
        public static double[] GetIFFTValue(double[] doubleArray, int nfft)
        {
            Complex[] mFreData = FFT_IFFT.FFT(doubleArray, true);
            double[] data = Cmp2Mdl(mFreData);
            double[] doubleArray1 = new double[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                doubleArray1[i] = data[i] / nfft;

            }
            return doubleArray1;
        }
        #endregion

        #region 进行一半数据功率谱计算
        public static double[] GetPowerSpectrum(double[] doubleArray, int nfft)
        {
            double[] doubleArray1 = new double[nfft / 2];
            Complex[] mFreData = FFT_IFFT.FFT(doubleArray, false);
            for (int i = 0; i < nfft / 2; i++)
            {
                doubleArray1[i] = (Math.Pow(mFreData[i].Real, 2) + Math.Pow(mFreData[i].Image, 2)) / (nfft / 2);
            }
            return doubleArray1;
        }
        #endregion

        #region 进行全部数据功率谱计算
        public static double[] GetPowerSpectrum1(double[] doubleArray, int nfft)
        {
            double[] doubleArray1 = new double[nfft];
            Complex[] mFreData = FFT_IFFT.FFT(doubleArray, false);
            for (int i = 0; i < nfft; i++)
            {
                doubleArray1[i] = (Math.Pow(mFreData[i].Real, 2) + Math.Pow(mFreData[i].Image, 2)) / (nfft / 2);
            }
            return doubleArray1;
        }
        #endregion

        #region 进行复数的共轭计算
        public static Complex[] GetConjugate(Complex[] input)
        {
            int n = input.Length;
            Complex[] output = new Complex[n];
            for (int i = 0; i < n; i++)
            {
                output[i] = input[i].Conjugate();
            }
            return output;
        }
        #endregion
    }
}
