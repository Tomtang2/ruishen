using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DigitalSignalProcessing;
using System.Collections;
using ruishen.傅里叶变换;

namespace ruishen.声音算法代码
{
    class VoiceOctave
    {
        /// <summary>
        /// 完成fft运算
        /// </summary>
        /// <param name="mydata">输入数据</param>
        /// <param name="Fs">采样频率</param>
        /// <returns>FFT后的离散数组的一半</returns>
        public static double[] myfft(double[] input, double Fs)
        {
            //傅里叶变换，求频率
            int N =Norm(input.Length);  //信号mydata的长度
            double []mydata=new double[N];
            for (int i = 0; i < N;i++ )
            {
                mydata[i]=input[i];
            }
            Complex[] mydata_FFT = FFT_IFFT.FFT(mydata,false); 
            //DigitalSignalProcessing.NiSignalProcessing.i
            double[] mydata_Modul = new double[mydata.Length];
            for (int j = 0; j < mydata_FFT.Length; j++)
            {
                mydata_Modul[j] = mydata_FFT[j].ToModul();  //取模
            }
            double[] mydata_Normalization = new double[mydata.Length];
            for (int j = 0; j < mydata.Length; j++)
            {
                mydata_Normalization[j] = mydata_Modul[j] * 2 / N;  //归一化
            }

            double[] result = new double[mydata.Length/2];
            for (int j = 0; j < mydata.Length / 2; j++)
            {
                result[j] = mydata_Normalization[j];
            }

            return result;
        }
        /// <summary>
        /// 求解倍频程
        /// </summary>
        /// <param name="mydata">原始数据</param>
        /// <param name="fs">采样频率</param>
        /// <param name="oct_2">输出值</param>
        public static void octave(double[] mydata, double fs, out ArrayList oct_1, out ArrayList oct_2)
        {
            int m = 1;
            double G = 1.995262314968880;
            double[] nn = { -12.3333333333333, -12, -11.6666666666667, -11.3333333333333, -11, -10.6666666666667, -10.3333333333333, -10, -9.66666666666667, -9.33333333333333, -9, -8.66666666666667, -8.33333333333333, -8, -7.66666666666667, -7.33333333333333, -7, -6.66666666666667, -6.33333333333333, -6, -5.66666666666667, -5.33333333333333, -5, -4.66666666666667, -4.33333333333333, -4, -3.66666666666667, -3.33333333333333, -3, -2.66666666666667, -2.33333333333333, -2, -1.66666666666667, -1.33333333333333, -1, -0.666666666666667, -0.333333333333333, 0, 0.333333333333333, 0.666666666666667, 1, 1.33333333333333, 1.66666666666667, 2, 2.33333333333333, 2.66666666666667, 3, 3.33333333333333, 3.66666666666667, 4, 4.33333333333333 };
            double[] f_center = new double[51];
            double[] f_low = new double[51];
            double[] f_up = new double[51];
            double OctRatio = 1.122018454301963;

            for (int i = 0; i < 51; i++)
            {
                f_center[i] = 1000 * Math.Pow(G, nn[i]);
                f_low[i] = (1 / OctRatio) * f_center[i];
                f_up[i] = OctRatio * f_center[i];
            }
            double[] f_base = { 0.2, 0.25, 0.315, 0.4, 0.5, 0.63, 0.8, 1, 1.25, 1.6 };
            double[] f_norm = { 0.200000000000000, 0.250000000000000, 0.315000000000000, 0.400000000000000, 0.500000000000000, 0.630000000000000, 0.800000000000000, 1, 1.25000000000000, 1.60000000000000, 2, 2.50000000000000, 3.15000000000000, 4, 5, 6.30000000000000, 8, 10, 12.5000000000000, 16, 20, 25, 31.5000000000000, 40, 50, 63, 80, 100, 125, 160, 200, 250, 315, 400, 500, 630, 800, 1000, 1250, 1600, 2000, 2500, 3150, 4000, 5000, 6300, 8000, 10000, 12500, 16000, 20000 };

            double[] fy = myfft(mydata, fs);
            int N = Norm(mydata.Length);  //信号x的长度
            double[] f = new double[N/2];
            
            //double[] A = new double[64];
            for (int j = 0; j < f.Length; j++)
            {
                f[j] = j * fs / N;
            }

            double A1000 = 0.794346395802295;
            double[] A = new double[mydata.Length/2];
            for (int j = 0; j < f.Length; j++)
            {
                A[j] = Math.Pow(12200, 2) * Math.Pow(f[j], 4) / (((Math.Pow(f[j], 2) + Math.Pow(20.6, 2))) * ((Math.Pow(f[j], 2) + Math.Pow(12200, 2))) * (Math.Sqrt((Math.Pow(f[j], 2) + Math.Pow(107.7, 2)))) * (Math.Sqrt((Math.Pow(f[j], 2)) + (Math.Pow(737.9, 2)))));
                A[j] = A[j] / A1000;
            }

            double[] xA = new double[N/2];
            for (int j = 0; j < f.Length; j++)
            {
                xA[j] = fy[j] * A[j];
            }

            int nd = 0;
            int a = 0;
            while (f_up[a] < f[f.Length - 1])
            {
                nd = nd + 1;
                a = a + 1;
                if(a>=f_up.Length){
                    break;
                }
            }

            ArrayList al = new ArrayList();
            ArrayList f_oct = new ArrayList();
            ArrayList y_oct = new ArrayList();
            double winenbw = 1.4999;
            for (int j = 0; j < nd; j++)
            {
                al.Clear();
                for (int i = 0; i < f.Length; i++)
                {
                    if (f[i] > f_low[j] & f[i] < f_up[j])
                    {
                        al.Add(i);
                    }
                }
                if (m == 1 && al.Count < 3)
                {
                    al.Clear();

                    continue;
                }

                else
                {
                    double re = 0;
                    f_oct.Add(f_norm[j]);
                    foreach (int v in al)
                    {
                        re = re + (xA[v] * xA[v]);
                    }
                    y_oct.Add(Math.Sqrt(re / winenbw));
                    m = m + 1;
                }
            }
            oct_1 = f_oct;

            oct_2 = y_oct;
        }

        public static double octave(double[] mydata, double fs,double CenterFrequency)
        {
            int m = 1;
            double G = 1.995262314968880;
            double[] nn = { -12.3333333333333, -12, -11.6666666666667, -11.3333333333333, -11, -10.6666666666667, -10.3333333333333, -10, -9.66666666666667, -9.33333333333333, -9, -8.66666666666667, -8.33333333333333, -8, -7.66666666666667, -7.33333333333333, -7, -6.66666666666667, -6.33333333333333, -6, -5.66666666666667, -5.33333333333333, -5, -4.66666666666667, -4.33333333333333, -4, -3.66666666666667, -3.33333333333333, -3, -2.66666666666667, -2.33333333333333, -2, -1.66666666666667, -1.33333333333333, -1, -0.666666666666667, -0.333333333333333, 0, 0.333333333333333, 0.666666666666667, 1, 1.33333333333333, 1.66666666666667, 2, 2.33333333333333, 2.66666666666667, 3, 3.33333333333333, 3.66666666666667, 4, 4.33333333333333 };
            double[] f_center = new double[51];
            double[] f_low = new double[51];
            double[] f_up = new double[51];
            double OctRatio = 1.122018454301963;

            for (int i = 0; i < 51; i++)
            {
                f_center[i] = 1000 * Math.Pow(G, nn[i]);
                f_low[i] = (1 / OctRatio) * f_center[i];
                f_up[i] = OctRatio * f_center[i];
            }
            double[] f_base = { 0.2, 0.25, 0.315, 0.4, 0.5, 0.63, 0.8, 1, 1.25, 1.6 };
            double[] f_norm = { 0.200000000000000, 0.250000000000000, 0.315000000000000, 0.400000000000000, 0.500000000000000, 0.630000000000000, 0.800000000000000, 1, 1.25000000000000, 1.60000000000000, 2, 2.50000000000000, 3.15000000000000, 4, 5, 6.30000000000000, 8, 10, 12.5000000000000, 16, 20, 25, 31.5000000000000, 40, 50, 63, 80, 100, 125, 160, 200, 250, 315, 400, 500, 630, 800, 1000, 1250, 1600, 2000, 2500, 3150, 4000, 5000, 6300, 8000, 10000, 12500, 16000, 20000 };

            double[] fy = myfft(mydata, fs);
            int N = Norm(mydata.Length);  //信号x的长度
            double[] f = new double[N / 2];

            //double[] A = new double[64];
            for (int j = 0; j < f.Length; j++)
            {
                f[j] = j * fs / N;
            }

            double A1000 = 0.794346395802295;
            double[] A = new double[mydata.Length / 2];
            for (int j = 0; j < f.Length; j++)
            {
                A[j] = Math.Pow(12200, 2) * Math.Pow(f[j], 4) / (((Math.Pow(f[j], 2) + Math.Pow(20.6, 2))) * ((Math.Pow(f[j], 2) + Math.Pow(12200, 2))) * (Math.Sqrt((Math.Pow(f[j], 2) + Math.Pow(107.7, 2)))) * (Math.Sqrt((Math.Pow(f[j], 2)) + (Math.Pow(737.9, 2)))));
                A[j] = A[j] / A1000;
            }

            double[] xA = new double[N / 2];
            for (int j = 0; j < f.Length; j++)
            {
                xA[j] = fy[j] * A[j];
            }

            int nd = 0;
            int a = 0;
            while (f_up[a] < f[f.Length - 1])
            {
                nd = nd + 1;
                a = a + 1;
                if (a >= f_up.Length)
                {
                    break;
                }
            }

            ArrayList al = new ArrayList();
            ArrayList f_oct = new ArrayList();
            ArrayList y_oct = new ArrayList();
            double winenbw = 1.4999;
            for (int j = 0; j < nd; j++)
            {
                al.Clear();
                for (int i = 0; i < f.Length; i++)
                {
                    if (f[i] > f_low[j] & f[i] < f_up[j])
                    {
                        al.Add(i);
                    }
                }
                if (m == 1 && al.Count < 3)
                {
                    al.Clear();

                    continue;
                }

                else
                {
                    double re = 0;
                    f_oct.Add(f_norm[j]);
                    foreach (int v in al)
                    {
                        re = re + (xA[v] * xA[v]);
                    }
                    y_oct.Add(Math.Sqrt(re / winenbw));
                    m = m + 1;
                }
            }

            for (int i = 0; i < f_oct.Count;i++ )
            {
                if(((double)f_oct[i])==CenterFrequency){
                    double cc = 0;
                        cc=(double)y_oct[i];
                       
                    return (double)y_oct[i];
                }
            }
            return 0;
        }



        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="n">数组长度</param>
        /// <returns>最接近n的2的次幂</returns>
        public static int Norm(int n)
        {
            return (int)Math.Pow(2, Math.Floor(Math.Log((double)n) / Math.Log((double)2)));
        }



        /// <summary>
        /// 求噪声的A计权
        /// </summary>
        /// <param name="x">信号数据</param>
        /// <param name="fs">采样频率</param>
        /// <param name="t_frame">默认数值</param>
        /// <returns>double型数组</returns>
        public static double[] awdgn2(double[] mydata, double fs, double t_frame = 0.02)
        {
           // double[] x = { 1,-1.00000000000000, 1.00000000000000, -1.00000000000000, 0.999999999999999, -1.00000000000000, 0.999999999999999, -1.00000000000000, 0.999999999999998, -1.00000000000000, 0.999999999999998, -0.999999999999996, 0.999999999999997, -0.999999999999996, 0.999999999999997, -0.999999999999997, 0.999999999999996, -1.00000000000001, 0.999999999999996, -0.999999999999998, 0.999999999999995, -1.00000000000003, 1.00000000000001, -0.999999999999984, 0.999999999999994, -1.00000000000003, 1.00000000000001, -0.999999999999985, 0.999999999999993, -1.00000000000003, 1.00000000000001, -0.999999999999986, 0.999999999999992, -1.00000000000003, 0.999999999999978, -0.999999999999987, 0.999999999999991, -1.00000000000003, 1.00000000000000, -0.999999999999988, 0.999999999999990, -1.00000000000003, 0.999999999999947, -1.00000000000002, 1.00000000000002, -1.00000000000000, 1.00000000000003, -0.999999999999990, 0.999999999999988, -1.00000000000003, 0.999999999999945, -1.00000000000002, 1.00000000000002, -1.00000000000001, 1.00000000000003, -0.999999999999992, 0.999999999999986, -1.00000000000004, 0.999999999999943, -1.00000000000002, 1.00000000000001, -1.00000000000001, 1.00000000000003, -0.999999999999994, 0.999999999999984, -1.00000000000004, 0.999999999999941, -1.00000000000002, 0.999999999999955, -0.999999999999953, 1.00000000000003, -0.999999999999996, 0.999999999999982, -1.00000000000004, 1.00000000000005, -0.999999999999969, 1.00000000000001, -0.999999999999955, 1.00000000000002, -0.999999999999998, 0.999999999999981, -1.00000000000004, 0.999999999999937, -1.00000000000008, 0.999999999999894, -1.00000000000001, 0.999999999999965, -1.00000000000006, 1.00000000000004, -0.999999999999986, 1.00000000000011, -0.999999999999916, 1.00000000000006, -0.999999999999959, 1.00000000000002, -1.00000000000000, 0.999999999999977, -1.00000000000005, 0.999999999999933, -1.00000000000009, 0.999999999999890, -1.00000000000002, 0.999999999999961, -1.00000000000006, 1.00000000000003, -0.999999999999990, 1.00000000000010, -0.999999999999920, 1.00000000000006, -0.999999999999963, 1.00000000000002, -1.00000000000001, 0.999999999999973, -1.00000000000005, 0.999999999999930, -1.00000000000009, 1, -1.00000000000002, 0.999999999999957, -1.00000000000006, 1.00000000000003, -0.999999999999994, 0.999999999999984, -0.999999999999924, 1.00000000000005, -0.999999999999967, 1.00000000000001, -1.00000000000001 };
            // double[] x = { 1, -1.00000000000000, 1.00000000000000, -1.00000000000000, 0.999999999999999, -1.00000000000000, 0.999999999999999, -1.00000000000000, 0.999999999999998, -1.00000000000000, 0.999999999999998, -1.00000000000001, 0.999999999999997, -1.00000000000001, 0.999999999999997, -1.00000000000001, 0.999999999999996, -1.00000000000001, 0.999999999999996, -1.00000000000001, 0.999999999999995, -0.999999999999998, 0.999999999999980, -1.00000000000001, 0.999999999999994, -0.999999999999999, 0.999999999999980, -1.00000000000001, 0.999999999999993, -1, 0.999999999999979, -1.00000000000001, 0.999999999999992, -0.999999999999973, 1.00000000000003, -0.999999999999987, 0.999999999999991, -0.999999999999974, 1.00000000000003, -0.999999999999988, 0.999999999999990, -0.999999999999975, 1.00000000000006, -0.999999999999961, 0.999999999999961, -1.00000000000000, 1.00000000000003, -0.999999999999990, 0.999999999999988, -0.999999999999977, 1.00000000000006, -0.999999999999963, 0.999999999999959, -1.00000000000001, 1.00000000000003, -0.999999999999992, 0.999999999999986, -0.999999999999979, 1.00000000000006, -0.999999999999965, 0.999999999999957, -1.00000000000001, 1.00000000000003, -0.999999999999994 };

            //int n = mydata.Length;
            int n = Norm(mydata.Length);
            double[] x=new double [n];
            for (int i = 0; i < n;i++ )
            {
                x[i] = mydata[i];
            }
            double t_const = 0.125;
          //  double p0 = 2 * Math.Pow(10, -5);
            double p0 = 0.00002;
            double[] t = new double[n];


            fs = fs - 1;       // 

            for (int i = 0; i < n; i++)
            {
                t[i] = (i) * (1 / fs);

            }

            int xlen = n;               //14

            double NumUniquePts_tem = (double)((xlen + 1) / 2.0);

            int NumUniquePts = (int)Math.Ceiling(NumUniquePts_tem);
            Complex[] X = FFT_IFFT.FFT(x,false);
            double[] f = new double[NumUniquePts];
            for (int i = 0; i < NumUniquePts; i++)
            {
                f[i] = (i) * (fs / xlen);

            }
           
            double A1000 = (Math.Pow(12200, 2) * Math.Pow(1000, 4)) / ((1000000 + 424.36) * (1000000 + (Math.Pow(12200, 2)) * Math.Pow((1000000 + 11599.29), 0.5) * Math.Pow((1000000 + 544496.41), 0.5)));     //A1000=0.794346395802295
            double[] A = new double[NumUniquePts];
            double[] W = new double[NumUniquePts];
            Complex[] XA = new Complex[NumUniquePts];

            for (int i = 0; i < f.Length; i++)
            {
               
                A[i] = (Math.Pow(12200, 2)) * (Math.Pow(f[i], 4)) / (((Math.Pow(f[i], 2)) + 424.36) * ((Math.Pow(f[i], 2)) + (Math.Pow(12200, 2))) * Math.Pow(((Math.Pow(f[i], 2)) + 11599.29), 0.5) * Math.Pow(((Math.Pow(f[i], 2)) + 544496.41), 0.5));
                W[i] = A[i] / A1000;
                Complex cc = new Complex(W[i], 0);
                cc = X[i] * cc;
                XA[i] = cc;      //complex 乘法
            }

            double[] xA = new double[n];
            Complex[] XA_tem1 = new Complex[NumUniquePts - 1];
            Complex[] XA_tem2 = new Complex[NumUniquePts - 2];
            Complex[] XA_final = new Complex[n];
            if (xlen % 2 == 1)                   //37
            {
                for (int j = 0, i = NumUniquePts; i >= 3; i--, j++)          //求conj(XA(end:-1:2))
                {
                    XA_tem1[j] = XA[i - 1];
                    XA_tem1[j].Image = -XA_tem1[j].Image;
                }

                for (int i = 0; i < XA.Length; i++)            //求XA
                {
                    XA_final[i] = XA[i];
                }

                for (int i = 0; i + XA.Length < XA_final.Length; i++)
                {
                    XA_final[XA.Length + i] = XA_tem1[i];
                }

                Complex[] X1 =FFT_IFFT.FFT(XA_final, true);

                for (int i = 0; i < n; i++)
                {

                    xA[i] = X1[i].Real / X1.Length;

                }

            }
            else
            {

                for (int j = 0, i = NumUniquePts; i >= 3; i--, j++)          //求conj(XA(end-1:-1:2))
                {
                    XA_tem2[j] = XA[i - 2];

                    XA_tem2[j].Image = -XA_tem2[j].Image;

                }

                for (int i = 0; i < XA.Length; i++)                //求XA
                {
                    XA_final[i] = XA[i];
                }
                for (int i = 0; i + XA.Length < XA_final.Length; i++)
                {
                    XA_final[XA.Length + i] = XA_tem2[i];
                }

                Complex[] X1 = FFT_IFFT.FFT(XA_final, true);            //求xA

                for (int i = 0; i < n; i++)
                {

                    xA[i] = X1[i].Real / X1.Length;

                }

            }
            double n_frame = t_frame * fs;
            double n_const = t_const * fs;

            int k = 0;                    //算s1的长度            ***
            for (int i = 0; ; i++)
            {

                double tem = 0;

                tem = 1 + i * n_frame;

                k = k + 1;


                if (tem > Math.Floor((double)n - n_const))
                {

                    break;
                }

            }
            k = k - 1;                                        //******

            double[] s1 = new double[k];                //计算s1

            for (int i = 0; k >= i + 1; i++)
            {

                double tem = 0;

                tem = 1 + i * n_frame;

                s1[i] = tem;
                if (s1[i] > Math.Floor(n - n_const))
                {              //****

                    break;
                }

            }

            double[] t_dB = new double[s1.Length];

            for (int i = 0; i < t_dB.Length; i++)
            {

                t_dB[i] = t[(int)(s1[i] - 1)];       //*/*/             正常情况不需要（int）
            }

            double alpha = 1 / (1 + t_const * fs);             //57
            double[] y_A2 = new double[xA.Length];
            for (int i = 0; i < y_A2.Length; i++)
            {

                y_A2[i] = Math.Pow(xA[i], 2);
            }

            double[] y_ATao2 = new double[n];


            y_ATao2[0] = alpha * y_A2[0] + (1 - alpha) * 0;         //60

            for (int i = 1; i < y_ATao2.Length; i++)
            {
                y_ATao2[i] = alpha * y_A2[i] + (1 - alpha) * y_ATao2[i - 1];

            }


            double[] yA_dB = new double[s1.Length];
           
            for (int i = 0; i < s1.Length; i++)                //求rms
            {

                double ind0 = s1[i];
                double indt = s1[i] + n_const - 1;

                if (indt > n)
                {
                    indt = n;
                }

                double rms_tem = 0;
                for (int j = (int)ind0 - 1; j < Math.Ceiling(indt); j++)
                {

                    rms_tem += Math.Pow(y_ATao2[j], 2);

                }
                double rms_tem1 = 0;

                rms_tem1 = Math.Pow(rms_tem, 0.5) / (Math.Ceiling(indt) - ind0 + 1);

                rms_tem1 = rms_tem1 / Math.Pow(p0, 2);

                yA_dB[i] = 10 * Math.Log10(rms_tem1);

            }
            

            return yA_dB;

        }

    }
  

}
