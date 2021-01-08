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
using ruishen.数据库公告类;
using System.Collections;
using ruishen.Entity;
using ruishen.公共中间量;

namespace ruishen.参数配置
{
    public partial class ThresholdSetForm : Form
    {
        MysqlHelper my;
        Dictionary<string, object> dic1;
        Dictionary<string, object> dic2;
        HashSet<string> firstSet = new HashSet<string>();
        HashSet<string> secondSet = new HashSet<string>();
        string update_sql = "update diagnosis_ttb_productstyle set Id=@Id,SetTitle=@SetTitle,SelectedWheel=@SelectedWheel, WheelModel1=@WheelModel1,WheelSetSerialNumber1=@WheelSetSerialNumber1,WheelModel2=@WheelModel2,WheelSetSerialNumber2=@WheelSetSerialNumber2,User=@User,TestBench=@TestBench,FactoryNumber=@FactoryNumber,Comment=@Comment where  Id=@Id";
      //  string find_sql = "select Title,SelectedWheel,WheelModel1,WheelSetSerialNumber1,BearModel1,BearSerialLeft1,BearSerialRight1, WheelModel2,WheelSetSerialNumber2,BearModel2,BearSerialLeft2,BearSerialRight2,User,TestBench,FactoryNumber,Comment from diagnosis_ttb_productstyle where id=1";
        string find_sql = "select * from diagnosis_ttb_productstyle where id=1";
        string insert_wheelstyle_sql = "insert into diagnosis_ttb_wheelstyle values(@Id,@WheelOneStyle,@WheelTwoStyle)";
        public ThresholdSetForm()
        {
            InitializeComponent();
        }

        private void SelectedWheel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedWheel.Text == "双轮对")
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
            }
            else if (SelectedWheel.Text == "1号轮对")
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;

                ProductStyle.WheelModel21 ="";
                ProductStyle.WheelSetSerialNumber21 = "";
                
            }
            else 
            {
                groupBox1.Visible = false;
                groupBox2.Visible = true;
                ProductStyle.SelectedWheel1 = "";
                ProductStyle.WheelModel11 = "";
                ProductStyle.WheelSetSerialNumber11 = "";
                
            }
        }
        
        private void Makesure_Click(object sender, EventArgs e)
        {
            DataTempStorage.FirstSet = firstSet;
            DataTempStorage.SecondSet = secondSet;
            if (SelectedWheel.Text == "1号轮对")
            {
                WheelModel2.Text ="";
                WheelSetSerialNumber2.Text = "";

                my = new MysqlHelper();
                dic1 = new Dictionary<string, object>();

                dic1.Add("@Id", 1);
                dic1.Add("@SetTitle", Title.Text);
                dic1.Add("@SelectedWheel", SelectedWheel.Text);
                dic1.Add("@WheelModel1", WheelModel1.Text);
                dic1.Add("@WheelSetSerialNumber1", WheelSetSerialNumber1.Text);

                dic1.Add("@WheelModel2", null);
                dic1.Add("@WheelSetSerialNumber2", null);

                dic1.Add("@User", User.Text);
                dic1.Add("@TestBench", TestBench.Text);
                dic1.Add("@FactoryNumber", FactoryNumber.Text);
                dic1.Add("@Comment", Comment.Text);
                if (my.MySqlPour(update_sql, dic1)) { MessageBox.Show("保存成功"); };
                ProductStyle.Id1 = 1;
                ProductStyle.Title1 = Title.Text;
                ProductStyle.SelectedWheel1 = SelectedWheel.Text;
                ProductStyle.WheelModel11 = WheelModel1.Text;
                ProductStyle.WheelSetSerialNumber11 = WheelSetSerialNumber1.Text;
                //ProductStyle.BearModel11 = BearModel1.Text;
                //ProductStyle.BearSerialLeft11 = BearSerialLeft1.Text;
                //ProductStyle.BearSerialRight11 = BearSerialRight1.Text;
                ProductStyle.WheelModel21 = null;
                ProductStyle.WheelSetSerialNumber21 = null;
                //ProductStyle.BearModel21 = BearModel2.Text;
                //ProductStyle.BearSerialLeft21 = BearSerialLeft2.Text;
                //ProductStyle.BearSerialRight21 = BearSerialRight2.Text;
                ProductStyle.User1 = User.Text;
                ProductStyle.TestBench1 = TestBench.Text;
                ProductStyle.FactoryNumber1 = FactoryNumber.Text;
                ProductStyle.Comment1 = Comment.Text;

                for (int i = 0; i < firstSet.Count; i++)
                {
                    dic2 = new Dictionary<string, object>();
                    dic2.Add("@WheelOneStyle", firstSet.ElementAt(i));
                    dic2.Add("@WheelTwoStyle", null);
                    if (!my.MySqlPour(insert_wheelstyle_sql, dic2))
                    {
                        MessageBox.Show("插入失败！");
                    }
                }

                this.Visible = false;
                
            }
            else if (SelectedWheel.Text == "2号轮对")
            {
                WheelModel1.Text = "";
                WheelSetSerialNumber1.Text = "";

                my = new MysqlHelper();
                dic1 = new Dictionary<string, object>();

                dic1.Add("@Id", 1);
                dic1.Add("@SetTitle", Title.Text);
                dic1.Add("@SelectedWheel", SelectedWheel.Text);
                dic1.Add("@WheelModel1", null);
                dic1.Add("@WheelSetSerialNumber1",null);

                dic1.Add("@WheelModel2", WheelModel2.Text);
                dic1.Add("@WheelSetSerialNumber2", WheelSetSerialNumber2.Text);

                dic1.Add("@User", User.Text);
                dic1.Add("@TestBench", TestBench.Text);
                dic1.Add("@FactoryNumber", FactoryNumber.Text);
                dic1.Add("@Comment", Comment.Text);
                if (my.MySqlPour(update_sql, dic1)) { MessageBox.Show("保存成功"); };
                ProductStyle.Id1 = 1;
                ProductStyle.Title1 = Title.Text;
                ProductStyle.SelectedWheel1 = SelectedWheel.Text;
                ProductStyle.WheelModel11 ="";
                ProductStyle.WheelSetSerialNumber11 = "";
                //ProductStyle.BearModel11 = BearModel1.Text;
                //ProductStyle.BearSerialLeft11 = BearSerialLeft1.Text;
                //ProductStyle.BearSerialRight11 = BearSerialRight1.Text;
                ProductStyle.WheelModel21 = WheelModel2.Text;
                ProductStyle.WheelSetSerialNumber21 = WheelSetSerialNumber2.Text;
                //ProductStyle.BearModel21 = BearModel2.Text;
                //ProductStyle.BearSerialLeft21 = BearSerialLeft2.Text;
                //ProductStyle.BearSerialRight21 = BearSerialRight2.Text;
                ProductStyle.User1 = User.Text;
                ProductStyle.TestBench1 = TestBench.Text;
                ProductStyle.FactoryNumber1 = FactoryNumber.Text;
                ProductStyle.Comment1 = Comment.Text;

                for (int i = 0; i < secondSet.Count; i++)
                {
                    dic2 = new Dictionary<string, object>();
                    dic2.Add("@WheelOneStyle", null);
                    dic2.Add("@WheelTwoStyle", secondSet.ElementAt(i));
                    if (!my.MySqlPour(insert_wheelstyle_sql, dic2))
                    {
                        MessageBox.Show("插入失败！");
                    }
                }

                this.Visible = false;
            }
           
            else
            {
                if (firstSet.Count != secondSet.Count)
                {
                    MessageBox.Show("轴对型号输入错误，前轮和后轮数目不匹配!");
                }
                else
                {
                    my = new MysqlHelper();
                    dic1 = new Dictionary<string, object>();

                    dic1.Add("@Id", 1);
                    dic1.Add("@SetTitle", Title.Text);
                    dic1.Add("@SelectedWheel", SelectedWheel.Text);
                    dic1.Add("@WheelModel1", WheelModel1.Text);
                    dic1.Add("@WheelSetSerialNumber1", WheelSetSerialNumber1.Text);

                    dic1.Add("@WheelModel2", WheelModel2.Text);
                    dic1.Add("@WheelSetSerialNumber2", WheelSetSerialNumber2.Text);

                    dic1.Add("@User", User.Text);
                    dic1.Add("@TestBench", TestBench.Text);
                    dic1.Add("@FactoryNumber", FactoryNumber.Text);
                    dic1.Add("@Comment", Comment.Text);
                    if (my.MySqlPour(update_sql, dic1)) { MessageBox.Show("保存成功"); };
                    ProductStyle.Id1 = 1;
                    ProductStyle.Title1 = Title.Text;
                    ProductStyle.SelectedWheel1 = SelectedWheel.Text;
                    ProductStyle.WheelModel11 = WheelModel1.Text;
                    ProductStyle.WheelSetSerialNumber11 = WheelSetSerialNumber1.Text;
                    //ProductStyle.BearModel11 = BearModel1.Text;
                    //ProductStyle.BearSerialLeft11 = BearSerialLeft1.Text;
                    //ProductStyle.BearSerialRight11 = BearSerialRight1.Text;
                    ProductStyle.WheelModel21 = WheelModel2.Text;
                    ProductStyle.WheelSetSerialNumber21 = WheelSetSerialNumber2.Text;
                    //ProductStyle.BearModel21 = BearModel2.Text;
                    //ProductStyle.BearSerialLeft21 = BearSerialLeft2.Text;
                    //ProductStyle.BearSerialRight21 = BearSerialRight2.Text;
                    ProductStyle.User1 = User.Text;
                    ProductStyle.TestBench1 = TestBench.Text;
                    ProductStyle.FactoryNumber1 = FactoryNumber.Text;
                    ProductStyle.Comment1 = Comment.Text;

                    for (int i = 0; i < firstSet.Count; i++)
                    {
                        dic2 = new Dictionary<string, object>();
                        dic2.Add("@WheelOneStyle", firstSet.ElementAt(i));
                        dic2.Add("@WheelTwoStyle", secondSet.ElementAt(i));
                        if (!my.MySqlPour(insert_wheelstyle_sql, dic2))
                        {
                            MessageBox.Show("插入失败！");
                        }
                    }


                    this.Visible = false;
                }
                
            }
                
        }

        private void ThresholdSetForm_Load(object sender, EventArgs e)
        {
           
            try
            {
                MysqlHelper yy = new MysqlHelper();
                ArrayList al = new ArrayList();
             
                al = yy.SelectInfo(find_sql, null);

                foreach (Object[] obj in al)
                {
                    Title.Text =Convert.ToString( obj[1]);
                    SelectedWheel.Text = obj[2].ToString();
                    WheelModel1.Text = obj[3].ToString();
                  //  WheelSetSerialNumber1.Text=obj[4].ToString();
                   
                    WheelModel2.Text = obj[5].ToString();
                  //  WheelSetSerialNumber2.Text = obj[6].ToString();
                    //BearModel2.Text = obj[10].ToString();
                    //BearSerialLeft2.Text = obj[11].ToString();
                    //BearSerialRight2.Text = obj[12].ToString();
                    User.Text = obj[7].ToString();
                    TestBench.Text = obj[8].ToString();
                    FactoryNumber.Text = obj[9].ToString();
                    Comment.Text = obj[10].ToString();
                 //   richTextBox1.Text = WheelSetSerialNumber1.Text;
                //    firstSet.Add(WheelSetSerialNumber1.Text);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("配置参数查询出错，请重新配置");
            }
        }
        //添加前轮轴
        private void AddForwardWheelBearing_Click(object sender, EventArgs e)
        {
            if (WheelSetSerialNumber1.Text == null || WheelSetSerialNumber1.Text=="")
            {
                MessageBox.Show("轮对轴号不能为空！");
               
            }
            else if (!firstSet.Add(WheelSetSerialNumber1.Text))
           {
               MessageBox.Show("重复轮轴号！");
           }
            else
            {
                //richTextBox1.Text = richTextBox1.Text + firstSet.Last().ToString() + "\r\n";
                WheelSetSerialNumber1.Text = "";
                DataGridViewRow dr = new DataGridViewRow();
                dr.CreateCells(ForwardWheelDataGridView);
                dr.Cells[0].Value = (ForwardWheelDataGridView.Rows.Count+1).ToString();
                dr.Cells[1].Value = firstSet.Last().ToString();
                ForwardWheelDataGridView.Rows.Insert(ForwardWheelDataGridView.Rows.Count,dr);
            }
            
        }

        private void AddLastWheelBearing_Click(object sender, EventArgs e)
        {
            if (WheelSetSerialNumber2.Text == null || WheelSetSerialNumber2.Text == "")
            {
                MessageBox.Show("轮对轴号不能为空！");
            }
            else if (!secondSet.Add(WheelSetSerialNumber2.Text))
            {
                MessageBox.Show("重复轮轴号！");
            }
            else
            {
                //richTextBox2.Text = richTextBox2.Text + secondSet.Last().ToString() + "\r\n";
                WheelSetSerialNumber2.Text = "";
                DataGridViewRow dr = new DataGridViewRow();
                dr.CreateCells(LastWheelDataGridView);
                dr.Cells[0].Value = (LastWheelDataGridView.Rows.Count+1).ToString();
                dr.Cells[1].Value = secondSet.Last().ToString();
                LastWheelDataGridView.Rows.Insert(LastWheelDataGridView.Rows.Count, dr);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
          DialogResult dr=  MessageBox.Show("确认清空吗？","",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if(dr==DialogResult.OK)
            {
                firstSet.Clear();
                secondSet.Clear();
                ForwardWheelDataGridView.Rows.Clear();
                LastWheelDataGridView.Rows.Clear();
                DataTempStorage.CurrentBehindWheelNumber = 0;
                DataTempStorage.CurrentForwardWheelNumber = 0;
            }
           
        }
    }
}
