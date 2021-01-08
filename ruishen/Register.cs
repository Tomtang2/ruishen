using ruishen.数据库公告类;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ruishen
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_SureButton1_Click(object sender, EventArgs e)
        {



            MysqlHelper mysql = null;
            Dictionary<string, object> dic = null;

            string R_userid = Register_UserTextBox1.Text.Trim();//登录名
            string R_pwd = Register_PswTextBox2.Text.Trim();//密码
            string R_Rpwd = Register_PswReTextBox3.Text.Trim();//重复密码


            #region 验证账号
            if (Register_UserTextBox1.Text.Trim() == "" || Register_UserTextBox1.Text.Length > 14)
            {

                MessageBox.Show("账号不能为空或大于14！请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Register_UserTextBox1.Focus();
                return;

            }

            #endregion


            #region 验证密码
            if (Register_PswTextBox2.Text.Trim() == "" || Register_PswTextBox2.Text.Length > 14)
            {

                MessageBox.Show("密码不能为空或大于14！请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Register_PswTextBox2.Focus();
                return;

            }


            if (Register_PswReTextBox3.Text.Trim() != Register_PswTextBox2.Text.Trim())
            {

                MessageBox.Show("两次输入的密码不一样", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Register_PswReTextBox3.Focus();
                return;

            }


            #endregion



            #region 验证码
            if(VerificationCodeHelper_text.Text!=VerificationCode_Text.Text){

                MessageBox.Show("请输入正确的验证码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                VerificationCode_Text.Focus();
                return;

            }




            #endregion


            #region 实现注册
            mysql = new MysqlHelper();




            String into_sql = "insert into diagnosis_ttb_user (username,password) VALUES (@R_userid,@R_pwd)";  //SELECT @@Identity from diagnosis_ttb_user
            dic = new Dictionary<string, object>();
            dic.Add("@R_userid", R_userid.ToString());
            dic.Add("@R_pwd", R_pwd.ToString());
            if (!mysql.MySqlPour(into_sql, dic))
            {
                MessageBox.Show("注册失败");
            }
            else
            {
                MessageBox.Show("注册成功!");
            }


            #endregion



        }


        private void Helper_pictureBox1_Click(object sender, EventArgs e)
        {
            
                
        }

        private void Register_Load(object sender, EventArgs e)
        {

            VerificationCodeHelper_text.Text = CheckCode().ToString();
            //string AuthCode = VerificationCodeHelper_text.Text.ToString();
        }

        private void Re_linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

           
           
            VerificationCodeHelper_text.Text = CheckCode().ToString();
        }



        #region 产生验证码
        public  string  CheckCode()
        {

            int number;

            char code;

            //空字符串且为只读属性

            string checkCode = String.Empty;

            //新建一个随机数产生器

            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {

                //随机产生一个整数

                number = random.Next();

                //如果随机数是偶数 取余

                if (number % 2 == 0)

                    code = (char)('0' + (char)(number % 10));

                else

                    //如果随机数是奇数 选择从[A-Z]

                    code = (char)('A' + (char)(number % 26));

                //4个字符的组合

                checkCode += "" + code.ToString();

            }
           
            return checkCode;
        }
        #endregion



    }
}
