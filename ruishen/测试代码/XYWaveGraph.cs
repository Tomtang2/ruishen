using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ruishen.测试代码
{
    public partial class XYWaveGraph : Form
    {
        public XYWaveGraph()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const int pointCount = 50;
            const int divisor = pointCount - 1;
            double[] dataX = new double[pointCount];
            double[] dataY = new double[pointCount];

            for (int i = 0; i < pointCount; ++i)
            {
                double current = ((double)i / divisor) ;
                dataX[i] = Math.Cos(current) ;
                dataY[i] = Math.Sin(current) ;
            }
            scatterGraph1.PlotXY(dataX,dataY);
        }
    }
}
