using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ruishen.数据库公告类;
using ruishen.公共中间量;
using MySql.Data.MySqlClient;
using ruishen.Entity;

namespace ruishen.报告生成
{
    public partial class TestResultGeneration : Form
    {
        public TestResultGeneration()
        {
            InitializeComponent();
        }

        private void Remeasure_Click(object sender, EventArgs e)
        {
            StatusInformationDisplay.FirstWheelLeft1 = "正常";
            StatusInformationDisplay.FirstWheelRight1 = "正常";
            StatusInformationDisplay.SecondWheelLeft1 = "正常";
            StatusInformationDisplay.SecondWheelRight1 = "正常";
            this.Close();
        }

        private void TestResultGeneration_Load(object sender, EventArgs e)
        {
            string firstText = "";
            string secondText = "";
            string thirdText = "";
            string fourthText = "";
            try
            {
                if (DataTempStorage.AlgorithmList1.Count == 1)
                {
                    LeftFirstOne.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    RightFirstOne.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    LeftSecondOne.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    RightSecondOne.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    LeftFirstTwo.Text = "";
                    RightFirstTwo.Text = "";
                    LeftSecondTwo.Text = "";
                    RightSecondTwo.Text = "";

                    LeftFirstOneValue.Text = DataTempStorage.FirstChannelCharacterOneResult.ToString("0.000000");
                    RightFirstOneValue.Text = DataTempStorage.SecondChannelCharacterOneResult.ToString("0.000000");
                    LeftSecondOneValue.Text = DataTempStorage.ThreeChannelCharacterOneResult.ToString("0.000000");
                    RightSecondOneValue.Text = DataTempStorage.FourChannelCharacterOneResult.ToString("0.000000");

                    LeftFirstTwoValue.Text = "";
                    RightFirstTwoValue.Text = "";
                    LeftSecondTwoValue.Text = "";
                    RightSecondTwoValue.Text = "";
                }
                else
                {
                    LeftFirstOne.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    RightFirstOne.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    LeftSecondOne.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    RightSecondOne.Text = DataTempStorage.AlgorithmList1[0].ToString();

                    LeftFirstTwo.Text = DataTempStorage.AlgorithmList1[1].ToString();
                    RightFirstTwo.Text = DataTempStorage.AlgorithmList1[1].ToString();
                    LeftSecondTwo.Text = DataTempStorage.AlgorithmList1[1].ToString();
                    RightSecondTwo.Text = DataTempStorage.AlgorithmList1[1].ToString();

                    LeftFirstOneValue.Text = DataTempStorage.FirstChannelCharacterOneResult.ToString("0.000000");//左前轮特征值一
                    RightFirstOneValue.Text = DataTempStorage.SecondChannelCharacterOneResult.ToString("0.000000");//右前轮特征值一
                    LeftSecondOneValue.Text = DataTempStorage.ThreeChannelCharacterOneResult.ToString("0.000000");//左后轮特征值一
                    RightSecondOneValue.Text = DataTempStorage.FourChannelCharacterOneResult.ToString("0.000000");//右后轮特征值一

                    LeftFirstTwoValue.Text = DataTempStorage.FirstChannelCharacterTwoResult.ToString("0.000000");//左前轮特征值二
                    RightFirstTwoValue.Text = DataTempStorage.SecondChannelCharacterTwoResult.ToString("0.000000");//右前轮特征值二
                    LeftSecondTwoValue.Text = DataTempStorage.ThreeChannelCharacterTwoResult.ToString("0.000000");//左后轮特征值二
                    RightSecondTwoValue.Text = DataTempStorage.FourChannelCharacterTwoResult.ToString("0.000000");//右后轮特征值二
                }
                
                switch (StatusInformationDisplay.FirstWheelLeft1)
                {
                    case "正常": FirstWheelLeft.BackColor = Color.Green; FirstWheelLeft.ForeColor = System.Drawing.Color.White; break;
                    case "超标": FirstWheelLeft.BackColor = Color.Red; break;
                    case "不判断": FirstWheelLeft.BackColor = Color.Blue; FirstWheelLeft.ForeColor = System.Drawing.Color.White; break;
                }
                switch (StatusInformationDisplay.FirstWheelRight1)
                {
                    case "正常": FirstWheelRight.BackColor = Color.Green; FirstWheelRight.ForeColor = System.Drawing.Color.White; break;
                    case "超标": FirstWheelRight.BackColor = Color.Red; break;
                    case "不判断": FirstWheelRight.BackColor = Color.Blue; FirstWheelRight.ForeColor = System.Drawing.Color.White; break;
                }
                switch (StatusInformationDisplay.SecondWheelLeft1)
                {
                    case "正常": SecondWheelLeft.BackColor = Color.Green; SecondWheelLeft.ForeColor = System.Drawing.Color.White; break;
                    case "超标": SecondWheelLeft.BackColor = Color.Red; break;
                    case "不判断": SecondWheelLeft.BackColor = Color.Blue; SecondWheelLeft.ForeColor = System.Drawing.Color.White; break;
                }
                switch (StatusInformationDisplay.SecondWheelRight1)
                {
                    case "正常": SecondWheelRight.BackColor = Color.Green; SecondWheelRight.ForeColor = System.Drawing.Color.White; break;
                    case "超标": SecondWheelRight.BackColor = Color.Red; break;
                    case "不判断": SecondWheelRight.BackColor = Color.Blue; SecondWheelRight.ForeColor = System.Drawing.Color.White; break;
                }
                if (ProductStyle.SelectedWheel1 == "1号轮对")
                {
                  //  FirstWheel.Text = DataTempStorage.FirstSet.ElementAt(DataTempStorage.CurrentForwardWheelNumber).ToString();
                    panel2.Visible = false;
                    firstText = StatusInformationDisplay.OneChannelOneCharacterValueHigh1 + StatusInformationDisplay.OneChannelTwoCharacterValueHigh1 + StatusInformationDisplay.FirstWheelLeft1;
                    secondText = StatusInformationDisplay.TwoChannelOneCharacterValueHigh1 + StatusInformationDisplay.TwoChannelTwoCharacterValueHigh1 + StatusInformationDisplay.FirstWheelRight1;
                    //firstText = "前轮对左侧轴承" + StatusInformationDisplay.FirstCharacterValueHigh1 + StatusInformationDisplay.SecondCharacterValueHigh1 + StatusInformationDisplay.FirstWheelLeft1;
                    //secondText = "前轮对右侧轴承" + StatusInformationDisplay.FirstCharacterValueHigh1 + StatusInformationDisplay.SecondCharacterValueHigh1 + StatusInformationDisplay.FirstWheelRight1;
                    FirstWheelLeft.Text = firstText;
                    FirstWheelRight.Text = secondText;
                    Rich_Information.Text ="前轮对左侧轴承: "+ firstText + System.Environment.NewLine +"前轮对右侧轴承: "+secondText ;
                }
                else if (ProductStyle.SelectedWheel1 == "2号轮对")
                {
                  //  SecondWheel.Text = DataTempStorage.SecondSet.ElementAt(DataTempStorage.CurrentBehindWheelNumber).ToString();
                    panel1.Visible = false;
                    thirdText = StatusInformationDisplay.ThreeChannelOneCharacterValueHigh1 + StatusInformationDisplay.ThreeChannelTwoCharacterValueHigh1 + StatusInformationDisplay.SecondWheelLeft1;
                    fourthText = StatusInformationDisplay.FourChannelOneCharacterValueHigh1 + StatusInformationDisplay.FourChannelTwoCharacterValueHigh1 + StatusInformationDisplay.SecondWheelRight1;
                    //thirdText = "后轮对左侧轴承" + StatusInformationDisplay.FirstCharacterValueHigh1 + StatusInformationDisplay.SecondCharacterValueHigh1 + StatusInformationDisplay.SecondWheelLeft1;
                    //fourthText = "后轮对右侧轴承" + StatusInformationDisplay.FirstCharacterValueHigh1 + StatusInformationDisplay.SecondCharacterValueHigh1 + StatusInformationDisplay.SecondWheelRight1;
                    SecondWheelLeft.Text = thirdText;
                    SecondWheelRight.Text = fourthText;
                    Rich_Information.Text ="后轮对左侧轴承: "+ thirdText + System.Environment.NewLine +"后轮对右侧轴承: "+ fourthText;
                }
                else
                {

                   // FirstWheel.Text = DataTempStorage.FirstSet.ElementAt(DataTempStorage.CurrentForwardWheelNumber).ToString();
                   // SecondWheel.Text = DataTempStorage.SecondSet.ElementAt(DataTempStorage.CurrentBehindWheelNumber).ToString();
                    firstText = StatusInformationDisplay.OneChannelOneCharacterValueHigh1 + StatusInformationDisplay.OneChannelTwoCharacterValueHigh1 + StatusInformationDisplay.FirstWheelLeft1;
                    secondText = StatusInformationDisplay.TwoChannelOneCharacterValueHigh1 + StatusInformationDisplay.TwoChannelTwoCharacterValueHigh1 + StatusInformationDisplay.FirstWheelRight1;
                    thirdText = StatusInformationDisplay.ThreeChannelOneCharacterValueHigh1 + StatusInformationDisplay.ThreeChannelTwoCharacterValueHigh1 + StatusInformationDisplay.SecondWheelLeft1;
                    fourthText =  StatusInformationDisplay.FourChannelOneCharacterValueHigh1 + StatusInformationDisplay.FourChannelTwoCharacterValueHigh1 + StatusInformationDisplay.SecondWheelRight1;

                    FirstWheelLeft.Text = firstText;
                    FirstWheelRight.Text = secondText;
                    SecondWheelLeft.Text = thirdText;
                    SecondWheelRight.Text = fourthText;
                    //FirstWheelLeft.Text = "前轮对左侧轴承" + StatusInformationDisplay.FirstCharacterValueHigh1 + StatusInformationDisplay.SecondCharacterValueHigh1 + StatusInformationDisplay.FirstWheelLeft1;
                    //FirstWheelRight.Text = "前轮对右侧轴承" + StatusInformationDisplay.FirstCharacterValueHigh1 + StatusInformationDisplay.SecondCharacterValueHigh1 + StatusInformationDisplay.FirstWheelRight1;
                    //SecondWheelLeft.Text = "后轮对左侧轴承" + StatusInformationDisplay.FirstCharacterValueHigh1 + StatusInformationDisplay.SecondCharacterValueHigh1 + StatusInformationDisplay.SecondWheelLeft1;
                    //SecondWheelRight.Text = "后轮对右侧轴承" + StatusInformationDisplay.FirstCharacterValueHigh1 + StatusInformationDisplay.SecondCharacterValueHigh1 + StatusInformationDisplay.SecondWheelRight1;
                    Rich_Information.Text = "前轮对左侧轴承: " + firstText + System.Environment.NewLine + "前轮对右侧轴承: " + secondText + System.Environment.NewLine + "后轮对左侧轴承: " + thirdText + System.Environment.NewLine + "后轮对右侧轴承: " + fourthText;
                }
                

            }
            catch (Exception)
            {
                StatusInformationDisplay.FirstWheelLeft1 = "正常";
                StatusInformationDisplay.FirstWheelRight1 = "正常";
                StatusInformationDisplay.SecondWheelLeft1 = "正常";
                StatusInformationDisplay.SecondWheelRight1 = "正常";
                MessageBox.Show("已经结束了！");
            }
          
            

           
        }
        MysqlHelper my = null;
        private void Makesure_Click(object sender, EventArgs e)
        {
          DialogResult dr=  MessageBox.Show("保存数据吗？","",MessageBoxButtons.OKCancel,MessageBoxIcon.None);
            if(dr==DialogResult.OK)
            {
                
                Dictionary<string, object> dic2 = new Dictionary<string, object>();
                Dictionary<string, object> dic3 = new Dictionary<string, object>();
                string insert_characterstatistical = "insert into diagnosis_ttb_characterstatistical values(@Id,@StartTime,@EndTime,@channeloneCharacterone,@channeltwoCharacterone,@channelthreeCharacterone,@channelfourCharacterone,@channeloneCharactertwo,@channeltwoCharactertwo,@channelthreeCharactertwo,@channelfourCharactertwo,@characterNameOne,@characterNameTwo)";
                string insert_testresult = "insert into diagnosis_ttb_testresult values(@Id,@StartTime,@WheelStyleOne,@WheelStyleTwo,@WheelSetSerialNumberOne,@WheelSetSerialNumberTwo,@ResultLeftOne,@ResultRightOne,@ResultLeftTwo,@ResultRightTwo,@User,@TestBench,@Factory)";
                my = new MysqlHelper();
                //diagnosis_ttb_testresult数据库操作
                if (ProductStyle.SelectedWheel1 == "双轮对")
                {
                    
                    dic3.Add("@StartTime", DataTempStorage.StartTime);
                    dic3.Add("@WheelStyleOne", ProductStyle.WheelModel11);
                    dic3.Add("@WheelStyleTwo", ProductStyle.WheelModel21);
                    dic3.Add("@WheelSetSerialNumberOne", DataTempStorage.FirstSet.ElementAt(DataTempStorage.CurrentForwardWheelNumber).ToString());
                    dic3.Add("@WheelSetSerialNumberTwo", DataTempStorage.SecondSet.ElementAt(DataTempStorage.CurrentBehindWheelNumber).ToString());
                   
                    dic3.Add("@ResultLeftOne", StatusInformationDisplay.FirstWheelLeft1);
                    dic3.Add("@ResultRightOne", StatusInformationDisplay.FirstWheelRight1);
                    dic3.Add("@ResultLeftTwo", StatusInformationDisplay.SecondWheelLeft1);
                    dic3.Add("@ResultRightTwo", StatusInformationDisplay.SecondWheelRight1);
                    dic3.Add("@User", ProductStyle.User1);
                    dic3.Add("@TestBench", ProductStyle.TestBench1);
                    dic3.Add("@Factory", ProductStyle.FactoryNumber1);
                    //DataTempStorage.CurrentForwardWheelNumber++;
                    //DataTempStorage.CurrentBehindWheelNumber++;
                    if (!my.MySqlPour(insert_testresult, dic3))
                    {
                        MessageBox.Show("插入结果失败！");
                    }
                    StatusInformationDisplay.FirstWheelLeft1 = "正常";
                    StatusInformationDisplay.FirstWheelRight1 = "正常";
                    StatusInformationDisplay.SecondWheelLeft1 = "正常";
                    StatusInformationDisplay.SecondWheelRight1 = "正常";
                   
                }
                else if (ProductStyle.SelectedWheel1 == "1号轮对")
                {
                    
                    dic3.Add("@StartTime", DataTempStorage.StartTime);
                    dic3.Add("@WheelStyleOne", ProductStyle.WheelModel11);
                    dic3.Add("@WheelStyleTwo", null);
                    dic3.Add("@WheelSetSerialNumberOne", DataTempStorage.FirstSet.ElementAt(DataTempStorage.CurrentForwardWheelNumber).ToString());
                    dic3.Add("@WheelSetSerialNumberTwo", null);
                    
                    dic3.Add("@BearingTwoLeftSerial", null);
                    dic3.Add("@BearingTwoRightSerial", null);
                    dic3.Add("@ResultLeftOne", StatusInformationDisplay.FirstWheelLeft1);
                    dic3.Add("@ResultRightOne", StatusInformationDisplay.FirstWheelRight1);
                    dic3.Add("@ResultLeftTwo", null);
                    dic3.Add("@ResultRightTwo", null);
                    dic3.Add("@User", ProductStyle.User1);
                    dic3.Add("@TestBench", ProductStyle.TestBench1);
                    dic3.Add("@Factory", ProductStyle.FactoryNumber1);
                    //DataTempStorage.CurrentForwardWheelNumber++;
                    if (!my.MySqlPour(insert_testresult, dic3))
                    {
                        MessageBox.Show("插入结果失败！");
                    }
                    StatusInformationDisplay.FirstWheelLeft1 = "正常";
                    StatusInformationDisplay.FirstWheelRight1 = "正常";
                    StatusInformationDisplay.SecondWheelLeft1 = "正常";
                    StatusInformationDisplay.SecondWheelRight1 = "正常";
                }
                else if (ProductStyle.SelectedWheel1 == "2号轮对")
                {
                   
                    dic3.Add("@StartTime", DataTempStorage.StartTime);
                    dic3.Add("@WheelStyleOne", null);
                    dic3.Add("@WheelStyleTwo", ProductStyle.WheelModel21);
                    dic3.Add("@WheelSetSerialNumberOne", null);
                    dic3.Add("@WheelSetSerialNumberTwo", DataTempStorage.SecondSet.ElementAt(DataTempStorage.CurrentBehindWheelNumber).ToString());
                   
                    
                    dic3.Add("@ResultLeftOne", null);
                    dic3.Add("@ResultRightOne", null);
                    dic3.Add("@ResultLeftTwo", StatusInformationDisplay.SecondWheelLeft1);
                    dic3.Add("@ResultRightTwo", StatusInformationDisplay.SecondWheelRight1);
                    dic3.Add("@User", ProductStyle.User1);
                    dic3.Add("@TestBench", ProductStyle.TestBench1);
                    dic3.Add("@Factory", ProductStyle.FactoryNumber1);
                    //DataTempStorage.CurrentBehindWheelNumber++;
                    if (!my.MySqlPour(insert_testresult, dic3))
                    {
                        MessageBox.Show("插入结果失败！");
                    }
                    StatusInformationDisplay.FirstWheelLeft1 = "正常";
                    StatusInformationDisplay.FirstWheelRight1 = "正常";
                    StatusInformationDisplay.SecondWheelLeft1 = "正常";
                    StatusInformationDisplay.SecondWheelRight1 = "正常";
                }
                //diagnosis_ttb_characterstatistical数据库操作
                if (DataTempStorage.AlgorithmList1 == null || DataTempStorage.AlgorithmList1.Count == 0)
                {

                }
                else if (DataTempStorage.AlgorithmList1.Count == 1)
                {
                    if (ProductStyle.SelectedWheel1 == "双轮对")
                    {
                        dic2.Add("@StartTime", DataTempStorage.StartTime);
                        dic2.Add("@EndTime", DataTempStorage.EndTime);
                       
                        dic2.Add("@channeloneCharacterone", DataTempStorage.FirstChannelCharacterOneResult);
                        dic2.Add("@channeltwoCharacterone", DataTempStorage.SecondChannelCharacterOneResult);
                        dic2.Add("@channelthreeCharacterone", DataTempStorage.ThreeChannelCharacterOneResult);
                        dic2.Add("@channelfourCharacterone", DataTempStorage.FourChannelCharacterOneResult);
                        dic2.Add("@channeloneCharactertwo", null);
                        dic2.Add("@channeltwoCharactertwo", null);
                        dic2.Add("@channelthreeCharactertwo", null);
                        dic2.Add("@channelfourCharactertwo", null);
                        dic2.Add("@characterNameOne", DataTempStorage.AlgorithmList1[0].ToString());
                        dic2.Add("@characterNameTwo", null);

                   
                    }
                    else if (ProductStyle.SelectedWheel1 == "1号轮对")
                    {
                        dic2.Add("@StartTime", DataTempStorage.StartTime);
                        dic2.Add("@EndTime", DataTempStorage.EndTime);
                        
                        dic2.Add("@channeloneCharacterone", DataTempStorage.FirstChannelCharacterOneResult);
                        dic2.Add("@channeltwoCharacterone", DataTempStorage.SecondChannelCharacterOneResult);
                        dic2.Add("@channelthreeCharacterone",null);
                        dic2.Add("@channelfourCharacterone", null);
                        dic2.Add("@channeloneCharactertwo", null);
                        dic2.Add("@channeltwoCharactertwo", null);
                        dic2.Add("@channelthreeCharactertwo", null);
                        dic2.Add("@channelfourCharactertwo", null);
                        dic2.Add("@characterNameOne", DataTempStorage.AlgorithmList1[0].ToString());
                        dic2.Add("@characterNameTwo", null);

                    }
                    else if (ProductStyle.SelectedWheel1 == "2号轮对")
                    {
                        dic2.Add("@StartTime", DataTempStorage.StartTime);
                        dic2.Add("@EndTime", DataTempStorage.EndTime);
                       
                        dic2.Add("@channeloneCharacterone",null);
                        dic2.Add("@channeltwoCharacterone",null);
                        dic2.Add("@channelthreeCharacterone", DataTempStorage.ThreeChannelCharacterOneResult);
                        dic2.Add("@channelfourCharacterone", DataTempStorage.FourChannelCharacterOneResult);
                        dic2.Add("@channeloneCharactertwo", null);
                        dic2.Add("@channeltwoCharactertwo", null);
                        dic2.Add("@channelthreeCharactertwo", null);
                        dic2.Add("@channelfourCharactertwo", null);
                        dic2.Add("@characterNameOne", DataTempStorage.AlgorithmList1[0].ToString());
                        dic2.Add("@characterNameTwo", null);
                    }

                    if (!my.MySqlPour(insert_characterstatistical, dic2))
                    {
                        MessageBox.Show("插入统计数据失败");
                    }
                    
                }
                else
                {
                    if (ProductStyle.SelectedWheel1 == "双轮对")
                    {
                        dic2.Add("@StartTime", DataTempStorage.StartTime);
                        dic2.Add("@EndTime", DataTempStorage.EndTime);
                        
                        dic2.Add("@channeloneCharacterone", DataTempStorage.FirstChannelCharacterOneResult);
                        dic2.Add("@channeltwoCharacterone", DataTempStorage.SecondChannelCharacterOneResult);
                        dic2.Add("@channelthreeCharacterone", DataTempStorage.ThreeChannelCharacterOneResult);
                        dic2.Add("@channelfourCharacterone", DataTempStorage.FourChannelCharacterOneResult);
                        dic2.Add("@channeloneCharactertwo", DataTempStorage.FirstChannelCharacterTwoResult);
                        dic2.Add("@channeltwoCharactertwo", DataTempStorage.SecondChannelCharacterTwoResult);
                        dic2.Add("@channelthreeCharactertwo", DataTempStorage.ThreeChannelCharacterTwoResult);
                        dic2.Add("@channelfourCharactertwo", DataTempStorage.FourChannelCharacterTwoResult);
                        dic2.Add("@characterNameOne", DataTempStorage.AlgorithmList1[0].ToString());
                        dic2.Add("@characterNameTwo", DataTempStorage.AlgorithmList1[1].ToString());
                    }
                    else if (ProductStyle.SelectedWheel1 == "1号轮对")
                    {
                        dic2.Add("@StartTime", DataTempStorage.StartTime);
                        dic2.Add("@EndTime", DataTempStorage.EndTime);
                        
                        dic2.Add("@channeloneCharacterone", DataTempStorage.FirstChannelCharacterOneResult);
                        dic2.Add("@channeltwoCharacterone", DataTempStorage.SecondChannelCharacterOneResult);
                        dic2.Add("@channelthreeCharacterone", null);
                        dic2.Add("@channelfourCharacterone", null);
                        dic2.Add("@channeloneCharactertwo", DataTempStorage.FirstChannelCharacterTwoResult);
                        dic2.Add("@channeltwoCharactertwo", DataTempStorage.SecondChannelCharacterTwoResult);
                        dic2.Add("@channelthreeCharactertwo", null);
                        dic2.Add("@channelfourCharactertwo", null);
                        dic2.Add("@characterNameOne", DataTempStorage.AlgorithmList1[0].ToString());
                        dic2.Add("@characterNameTwo", DataTempStorage.AlgorithmList1[1].ToString());
                    }
                    else if (ProductStyle.SelectedWheel1 == "2号轮对")
                    {
                        dic2.Add("@StartTime", DataTempStorage.StartTime);
                        dic2.Add("@EndTime", DataTempStorage.EndTime);

                        dic2.Add("@channeloneCharacterone", null);
                        dic2.Add("@channeltwoCharacterone", null);
                        dic2.Add("@channelthreeCharacterone", DataTempStorage.ThreeChannelCharacterOneResult);
                        dic2.Add("@channelfourCharacterone", DataTempStorage.FourChannelCharacterOneResult);
                        dic2.Add("@channeloneCharactertwo", null);
                        dic2.Add("@channeltwoCharactertwo", null);
                        dic2.Add("@channelthreeCharactertwo", DataTempStorage.ThreeChannelCharacterTwoResult);
                        dic2.Add("@channelfourCharactertwo", DataTempStorage.FourChannelCharacterTwoResult);
                        dic2.Add("@characterNameOne", DataTempStorage.AlgorithmList1[0].ToString());
                        dic2.Add("@characterNameTwo", DataTempStorage.AlgorithmList1[1].ToString());
                    }
                    
                    if (!my.MySqlPour(insert_characterstatistical, dic2))
                    {
                        MessageBox.Show("插入统计数据失败");
                    }
                }
                this.Close();
            }
        }

        private void TestResultGeneration_FormClosed(object sender, FormClosedEventArgs e)
        {
            StatusInformationDisplay.FirstWheelLeft1 = "正常";
            StatusInformationDisplay.FirstWheelRight1 = "正常";
            StatusInformationDisplay.SecondWheelLeft1 = "正常";
            StatusInformationDisplay.SecondWheelRight1 = "正常";
        }
    }
}
