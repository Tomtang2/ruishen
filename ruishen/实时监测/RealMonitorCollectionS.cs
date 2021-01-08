using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ruishen.公共中间量;
using ruishen.数据库公告类;
using System.Collections;
using ruishen.Entity;

namespace ruishen.实时监测
{
    public partial class RealMonitorCollectionS : Form
    {
        MysqlHelper my;
        Dictionary<string, object> dic1;
        ArrayList al;
        ChannelParameterConfig channelParameterConfig;//通道参数配置
        string find_sql = "select * from diagnosis_ttb_channelparameterset where ChannelNumber=@ChannelNumber";
        public RealMonitorCollectionS()
        {
            
            InitializeComponent();
            label5.Visible = false;
            RMC_ProgressBar.Visible = false;
            RMC_TotalTime.Visible = false;
            my = new MysqlHelper();
            dic1 = new Dictionary<string, object>();
            dic1.Add("@ChannelNumber", (int)1);
            al = my.SelectInfo(find_sql, dic1);
            channelParameterConfig = new ChannelParameterConfig();

            foreach (Object[] obj in al)
            {
                channelParameterConfig.ChanneNumber1 = (int)obj[0];
                channelParameterConfig.Switch1 = (int)obj[1];
                channelParameterConfig.WheelAndAxle1 = (string)obj[2];
                channelParameterConfig.Coupling1 = (string)obj[3];
                channelParameterConfig.Unit1 = (string)obj[4];
                channelParameterConfig.Sensitivity1 = (double)obj[5];
                channelParameterConfig.SensorRange1 = (string)obj[6];
                channelParameterConfig.WheelSide1 = (string)obj[7];
                channelParameterConfig.AnalysisBandWidth1 = (int)obj[8];
                channelParameterConfig.FrequencyGraph1 = (int)obj[9];
                channelParameterConfig.Resolution1 = (double)obj[10];
                channelParameterConfig.WindowsFunction1 = (string)obj[11];
                channelParameterConfig.AverageWay1 = (string)obj[12];
                channelParameterConfig.AverageNumber1 = (int)obj[13];
                channelParameterConfig.AcquisitionMode1 = (string)obj[14];
                channelParameterConfig.AcquisitionTime1 = (int)obj[15];
                channelParameterConfig.SampleRate1 = (int)obj[16];
                channelParameterConfig.SampleNumber1 = (int)obj[17];
            }
            RMC_TotalTime.Text = (((double)channelParameterConfig.SampleNumber1 / (double)channelParameterConfig.SampleRate1)).ToString() + "s";
        }

        private void RMC_VibrationButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void RealMonitorCollectionS_Load(object sender, EventArgs e)
        {
            if(DataTempStorage.AlgorithmList1!=null){
                if (DataTempStorage.AlgorithmList1.Count == 3)
                {
                    this.LeftFrontFirst.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    this.LeftFrontSecond.Text = DataTempStorage.AlgorithmList1[1].ToString();
                    this.LeftFrontThird.Text = DataTempStorage.AlgorithmList1[2].ToString();
                    this.RightFrontFirst.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    this.RightFrontSecond.Text = DataTempStorage.AlgorithmList1[1].ToString();
                    this.RightFrontThird.Text = DataTempStorage.AlgorithmList1[2].ToString();
                    this.LeftBehindFirst.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    this.LeftBehindSecond.Text = DataTempStorage.AlgorithmList1[1].ToString();
                    this.LeftBehindThird.Text = DataTempStorage.AlgorithmList1[2].ToString();
                    this.RightBehindFirst.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    this.RightBehindSecond.Text = DataTempStorage.AlgorithmList1[1].ToString();
                    this.RightBehindThird.Text = DataTempStorage.AlgorithmList1[2].ToString();
                }
                else if (DataTempStorage.AlgorithmList1.Count == 2)
                {
                    this.LeftFrontFirst.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    this.LeftFrontSecond.Text = DataTempStorage.AlgorithmList1[1].ToString();
                    this.LeftFrontThird.Text = "";

                    this.RightFrontFirst.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    this.RightFrontSecond.Text = DataTempStorage.AlgorithmList1[1].ToString();
                    this.RightFrontThird.Text = "";

                    this.LeftBehindFirst.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    this.LeftBehindSecond.Text = DataTempStorage.AlgorithmList1[1].ToString();
                    this.LeftBehindThird.Text = "";

                    this.RightBehindFirst.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    this.RightBehindSecond.Text=DataTempStorage.AlgorithmList1[1].ToString();
                    this.RightBehindThird.Text ="";

                }
                else if (DataTempStorage.AlgorithmList1.Count == 1)
                {
                    this.LeftFrontFirst.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    this.LeftFrontSecond.Text = "";
                    this.LeftFrontThird.Text = "";

                    this.RightFrontFirst.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    this.RightFrontSecond.Text = "";
                    this.RightFrontThird.Text = "";

                    this.LeftBehindFirst.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    this.LeftBehindSecond.Text = "";
                    this.LeftBehindThird.Text = "";

                    this.RightBehindFirst.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    this.RightBehindSecond.Text = "";
                    this.RightBehindThird.Text = "";
                }
            }
           
            else {
                this.LeftFrontFirst.Text ="";
                this.LeftFrontSecond.Text = "";
                this.LeftFrontThird.Text = "";
                this.RightFrontFirst.Text = "";
                this.RightFrontSecond.Text = "";
                this.RightFrontThird.Text = "";
                this.LeftBehindFirst.Text = "";
                this.LeftBehindSecond.Text = "";
                this.LeftBehindThird.Text = "";
                this.RightBehindFirst.Text = "";
                this.RightBehindSecond.Text = "";
                this.RightBehindThird.Text = "";


            }

        }

        private void RMC_VibrationButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void RMC_VibrationButton3_Click(object sender, EventArgs e)
        {
           
        }

        private void RMC_VibrationButton4_Click(object sender, EventArgs e)
        {
           
        }
    }
}
