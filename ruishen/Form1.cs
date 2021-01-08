using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;
using ruishen.数据库公告类;
using ruishen.公共中间量;

namespace ruishen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MysqlHelper my;
        private void buttonX1_Click(object sender, EventArgs e)
        {

            string userid = txtID.Text.Trim();//登录名
            string pwd = txtPwd.Text.Trim();//登陆密码
           // string jur = cboxJur.Text;
           // string IPAdress = txtIP.Text.Trim();
            if (userid.Equals("") || pwd.Equals(""))
            {
                MessageBox.Show("用户名及密码和IP地址不能为空!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //用户名和密码验证正确，提示成功，跳转到主界面

                //连接数据库
                string strcon = "server=localhost;database=faultdiagnosis;uid=root;pwd=ttb1996;charset=utf8";
                MySqlConnection con = new MySqlConnection(strcon);
                try
                {
                    con.Open();//打开数据库
                    string sqlSel = "select count(*) from diagnosis_ttb_user where username = '" + userid + "' and password = '" + pwd + "'";
                    MySqlCommand com = new MySqlCommand(sqlSel, con);
                    //4.判断executeScalar方法返回的参数是否大于0，大于0表示查找有数据
                    if (Convert.ToInt32(com.ExecuteScalar()) > 0)
                    {
                      //  MessageBox.Show("登陆成功！");
                        string selectedAxleAndSide = "select AnalysisBandWidth,FrequencyGraph,Resolution,WindowsFunction,AverageWay,AcquisitionMode,AcquisitionTime from diagnosis_ttb_channelparameterset where ChannelNumber=1";
                        ArrayList point1 = new ArrayList();
                        my = new MysqlHelper();
                        point1 = my.SelectInfo(selectedAxleAndSide, null);
                        foreach (Object[] obj in point1)
                        {
                            DataTempStorage.AnalysisBandWidth1 = obj[0].ToString();//分析带宽
                            DataTempStorage.FrequencyGraph1 = obj[1].ToString();//谱线图
                            DataTempStorage.Resolutio1 = obj[2].ToString();//分辨率
                            DataTempStorage.WindowFunction1 = obj[3].ToString();//窗函数

                            DataTempStorage.AverageMode1 = obj[4].ToString();
                            DataTempStorage.SampleWay1 = obj[5].ToString();
                            DataTempStorage.AcquisitionTime1=(double)obj[6];

                        }
                        //主界面显示
                        this.DialogResult = DialogResult.OK;
                        this.Visible = false;
                        FrmMain frmmain = new FrmMain();
                        frmmain.WindowState = FormWindowState.Maximized;
                        frmmain.ShowDialog();//Show()和ShowDialog()区别

                     
                        this.Close();//隐藏登录窗口
                        this.Dispose();
                        Application.Exit();

                        
                    }
                    //用户名和密码错误，提示错误。
                    else
                    {
                        MessageBox.Show("用户名或密码错误！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
                }


            }


        }



       
    }
}
