using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ruishen.声音算法代码;

namespace ruishen.测试代码
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] m={1.2,2,3,4,5};
            textBox4.Text = NoiseCharacterValue.RMSPlus(m).ToString();
        }
    }
}
