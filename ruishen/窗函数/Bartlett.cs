using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruishen.窗函数
{
    //三角窗函数
    class Bartlett
    {
        public int N = 0;
        public Bartlett(double Wp, double Ws)
        {
            int i;
            double n = (2.1 * 2 * Math.PI) / (Ws - Wp);
            for (i = 0; i < n; i++) ;
            N = i;
        }
        
        public double[] GetWin()
        {
            int n;
            double[] wd = new double[N];
            for (n = 0; n < N; n++)
            {
                if (n <= ((N - 1) / 2))
                {
                    wd[n] = (double)(2 * (double)n / ((double)N - 1));
                }
                if (n > ((N - 1) / 2))
                {
                    wd[n] = 2 * ((double)N - 1 - n) / ((double)N - 1);
                }
            }
            return wd;
        }
    }
}
