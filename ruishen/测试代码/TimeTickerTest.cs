using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ruishen.测试代码
{
    public partial class TimeTickerTest : Form
    {
        public TimeTickerTest()
        {
            InitializeComponent();
        }
        private bool open = false;
        int count = 0;
        public void timeCount() {
            DateTime dt1 = DateTime.Now;
            while ((DateTime.Now - dt1).TotalMilliseconds < 10000)
            {
                continue;
            };
            open = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            //textBox1.Text = "年后";
           
            //    textBox1.Text = "岁月";
                timer1.Enabled = true;
            
           
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = count.ToString();
            count++;
        }
    }
}
