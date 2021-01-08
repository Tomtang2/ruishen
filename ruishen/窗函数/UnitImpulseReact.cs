using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruishen.窗函数
{
    class UnitImpulseReact
    {
        private double Wc;
        private int alpha;
        private int N;

        public UnitImpulseReact(double Wp, double Ws, int N)
        {
            this.Wc = 0.5 * (Wp + Ws);
            if (N % 2 != 0)
            {
                this.alpha = (N - 1) / 2;
            }
            else
            {
                this.alpha = N / 2;
            }
            this.N = N;
        }

        //低通
        public double[] GetUIR()
        {
            double[] hd = new double[N];
            for (int n = 0; n < N; n++)
            {
                double numerator = Math.Sin(Wc * (n - alpha));
                double denominator = Math.PI * (n - alpha);
                if (n == alpha)
                {
                    hd[n] = Wc / Math.PI;
                }
                else
                {
                    hd[n] = numerator / denominator;
                }
            }
            return hd;
        }

        //高通，测试通过
        public double[] GetHigh()
        {
            double[] hd = new double[N];
            for (int n = 0; n < N; n++)
            {
                double numerator = Math.Sin(Math.PI * (n - alpha)) - Math.Sin((n - alpha) * Wc);
                double denominator = Math.PI * (n - alpha);
                if (n == alpha)
                {
                    hd[n] = (Math.PI - Wc) / Math.PI;
                }
                else
                {
                    hd[n] = numerator / denominator;
                }
            }
            return hd;
        }

        //带通，测试通过
        public double[] GetDaiTong(double Wl, double Wh)
        {
            double[] hd = new double[N];
            for (int n = 0; n < N; n++)
            {
                double numerator = Math.Sin((n - alpha) * Wh) - Math.Sin((n - alpha) * Wl);
                double denominator = Math.PI * (n - alpha);
                if (n == alpha)
                {
                    hd[n] = (Wh - Wl) / Math.PI;
                }
                else
                {
                    hd[n] = numerator / denominator;
                }
            }
            return hd;
        }

        public double[] GetDaiZu(double Wl, double Wh)
        {
            double[] hd = new double[N];
            for (int n = 0; n < N; n++)
            {
                double numerator = Math.Sin((n - alpha) * Wl) + Math.Sin(Math.PI * (n - alpha)) - Math.Sin((n - alpha) * Wh);
                double denominator = Math.PI * ((double)n - alpha);
                if (n == alpha)
                {
                    hd[n] = (Math.PI - Wh) / Math.PI + Wl / Math.PI;
                }
                else
                {
                    hd[n] = numerator / denominator;
                }
            }
            return hd;
        }
    }
}
