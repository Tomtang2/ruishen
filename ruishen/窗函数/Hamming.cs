using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruishen.窗函数
{
    class Hamming
    {
        //public int N = 0;
        //public Hamming(double Wp, double Ws)
        //{
        //    int i;
        //    double n = (3.3 * 2 * Math.PI) / (Ws - Wp);
        //    for (i = 0; i < n; i++) ;
        //    N = i;
        //}

        //public double[] GetWin()
        //{
        //    int n;
        //    double[] wd = new double[N];
        //    for (n = 0; n < N; n++)
        //    {
        //        double b = (double)Math.Cos((2 * (double)n * Math.PI) / ((double)N - 1));
        //        double res = (0.54 - 0.46 * b);
        //        wd[n] = res;
        //    }
        //    return wd;
        //}
        public static double[] getHamming(int Length) 
        {
            int n;
            double[] wd = new double[Length];
            for (n = 0; n < Length; n++)
            {
                double b = (double)Math.Cos((2 * (double)n * Math.PI) / ((double)Length - 1));
                double res = (0.54 - 0.46 * b);
                wd[n] = res;
            }
            return wd;
        }

    }
}
