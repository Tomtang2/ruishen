using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ruishen.报告生成;

namespace ruishen.测试代码
{
    public partial class Paging : Form
    {
        public Paging()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(StatusInformationDisplay.statusInformation.自学习中.ToString());
        }
    }
}
