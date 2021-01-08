using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruishen.窗函数
{
    //布莱克曼窗函数
    class Blackman
    {
        public static double[] getBlackMan(int Length)
        {
            int n;
            double[] wd = new double[Length];
            for (n = 0; n < Length; n++)
            {
                double a = Math.Cos((2 * (double)n * Math.PI) / ((double)Length - 1));
                double b = Math.Cos((4 * (double)n * Math.PI) / ((double)Length - 1));
                double res = (0.42 - 0.5 * a + 0.08 * b);
                wd[n] = res;
            }
            return wd;
        }
       
    }
}
