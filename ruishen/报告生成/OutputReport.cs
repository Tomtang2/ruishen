using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ruishen.报告生成
{
    public partial class OutputReport : Form
    {
        public OutputReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try{

                string filePath = @"..//..//报告日志\OutputReport.log";

            if (!File.Exists(filePath))
            {
                // 不存在则先创建文件 
                File.Create(filePath).Close();
            }

            // 用流输出日志 
            StreamWriter sw = File.AppendText(filePath);
            sw.WriteLine("=============================日志文件============================");
            sw.WriteLine("编号：" + OR_Index.Text.ToString());                 //***
            sw.WriteLine("轴承类型：" + OR_BearingType.Text.ToString());                 //***
            sw.WriteLine("入厂时间：" + OR_Index.Text.ToString() + "            " + "诊断时间：" +OR_dateTimeToday.Text.ToString() + "            " + "操作员：" + OR_User.Text.ToString());


            sw.WriteLine("-----------------------------参数设置----------------------------");

            /*判断开启的通道*/
            sw.WriteLine("频带宽：" + "                                    " + "采样时间：");
            sw.WriteLine("频带宽：" + "                                    " + "采样时间：");
            sw.WriteLine("频带宽：" + "                                    " + "采样时间：");
            sw.WriteLine("频带宽：" + "                                    " + "采样时间：");
            sw.WriteLine("频带宽：" + "                                    " + "采样时间：");


            sw.WriteLine("-----------------------------初步判断----------------------------");
            sw.WriteLine("所选方法：");
            sw.WriteLine("双轮判断：");

            //增加判断*
            sw.WriteLine("                  存在故障");
            //*********

            sw.WriteLine("  ");
            sw.WriteLine("单论故障：");

            //增加判断*
            sw.WriteLine("                 左轮存在故障");
            sw.WriteLine("                 右轮存在故障");
            //*********



            sw.WriteLine("-----------------------------参数设置---------------------------");
            sw.WriteLine("签字");
            sw.WriteLine("主管 ：" + "                   " + "操作员：");
            sw.WriteLine(" ");
            sw.WriteLine(" ");
            sw.WriteLine(" ");
            sw.WriteLine(" ");
            sw.Flush();
            sw.Close();
            sw.Dispose();


            MessageBox.Show("输出成功！");
            }
            catch(Exception ex){
                MessageBox.Show("输出失败！");


            }

            



        }
    }
}
