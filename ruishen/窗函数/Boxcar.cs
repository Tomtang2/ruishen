using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruishen.窗函数
{
    //矩形窗
    class Boxcar
    {
        //public int N = 0;
        //public Boxcar(double Wp, double Ws)
        //{
        //    int i;
        //    double n = (0.9 * 2 * Math.PI) / (Ws - Wp);
        //    for (i = 0; i < n; i++) ;
        //    N = i;
        //}

        //public double[] GetWin()
        //{
        //    int n;
        //    double[] wd = new double[N];
        //    for (n = 0; n < N; n++)
        //    {
        //        wd[n] = 1;
        //    }
        //    return wd;
        //}

        public static double[] getBoxCar(int Length) 
        {
            int n;
            double[] wd = new double[Length];
            for (n = 0; n < Length; n++)
            {
                wd[n] = 1;
            }
            return wd;
        }
    }
}
