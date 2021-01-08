using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruishen.窗函数
{
    class Hanning
    {
        //public int N = 0;
        //public Hanning(double Wp, double Ws)//wp,ws以π为单位
        //{
        //    int i;
        //    double n = (3.1 * 2 * Math.PI) / (Ws - Wp);
        //    for (i = 0; i < n; i++) ;
        //    N = i;
        //}

        //public double[] GetWin()
        //{
        //    int n;
        //    double[] wd = new double[N];
        //    for (n = 0; n < N; n++)
        //    {
        //        double b = Math.Cos((2 * Math.PI * (double)n) / ((double)N - 1));
        //        double res = (0.5 - 0.5 * b);
        //        wd[n] = res;
        //    }
        //    return wd;
        //}

        public static double[] getHanning(int Length) 
        {
            int n;
            double[] wd = new double[Length];
            for (n = 0; n < Length; n++)
            {
                double b = Math.Cos((2 * Math.PI * (double)n) / ((double)Length - 1));
                double res = (0.5 - 0.5 * b);
                wd[n] = res;
            }
            return wd;
        }
    }
}
