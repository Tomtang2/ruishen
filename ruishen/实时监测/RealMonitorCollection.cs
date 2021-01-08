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
    public partial class RealMonitorCollection : Form
    {

        public RealMonitorCollection()
        {
            InitializeComponent();
            this.RMC_ProgressBar.Value=(int)DataTempStorage.SampleTime1;
            BearNumberLeftone.Text = "左轮轴";
            BearNumberRightone.Text = "右轮轴";
            BearNumberLefTwo.Text = "左轮轴";
            BearNumberRightTwo.Text = "右轮轴";
            this.RMC_ProgressBar.Visible = false;
            ProgressBarSave.Visible = false;
            RMC_Time.Visible = false;
        }

        private void RealMonitorCollection_Load(object sender, EventArgs e)
        {
            if(ProductStyle.SelectedWheel1=="1号轮对")
            {
                panel2.Visible = true;
                panel3.Visible = true;
                ForwardWheelDisplay.Visible = true;
                panel5.Visible = false;
                panel6.Visible = false;
                LastWheelDisplay.Visible = false;
                ForwardWheelDisplay.Text ="前轮对: "+ DataTempStorage.FirstSet.ElementAt(DataTempStorage.CurrentForwardWheelNumber).ToString();
            }
            else if (ProductStyle.SelectedWheel1 == "2号轮对")
            {
                panel2.Visible = false;
                panel3.Visible = false;
                ForwardWheelDisplay.Visible = false;
                panel5.Visible = true;
                panel6.Visible = true;
                LastWheelDisplay.Visible = true;
                LastWheelDisplay.Text ="后轮对: "+  DataTempStorage.SecondSet.ElementAt(DataTempStorage.CurrentBehindWheelNumber).ToString();
            }
            else
            {
                panel2.Visible = true;
                panel3.Visible = true;
                ForwardWheelDisplay.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                LastWheelDisplay.Visible = true;

                try
                {
                    ForwardWheelDisplay.Text ="前轮对: "+ DataTempStorage.FirstSet.ElementAt(DataTempStorage.CurrentForwardWheelNumber).ToString();
                    LastWheelDisplay.Text ="后轮对: "+  DataTempStorage.SecondSet.ElementAt(DataTempStorage.CurrentBehindWheelNumber).ToString();
                }
                catch (Exception)
                {
                    
                    
                }
                
               
            }

            if (DataTempStorage.AlgorithmList1 != null)
            {
                if (DataTempStorage.AlgorithmList1.Count == 2)
                {
                    waveformGraph1.Visible = true;
                    waveformGraph2.Visible = true;
                    waveformGraph3.Visible = true;
                    waveformGraph4.Visible = true;
                    waveformGraph5.Visible = true;
                    waveformGraph6.Visible = true;
                    waveformGraph7.Visible = true;
                    waveformGraph8.Visible = true;
                    this.LeftFrontFirst.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    this.LeftFrontSecond.Text = DataTempStorage.AlgorithmList1[1].ToString();


                    this.RightFrontFirst.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    this.RightFrontSecond.Text = DataTempStorage.AlgorithmList1[1].ToString();


                    this.LeftBehindFirst.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    this.LeftBehindSecond.Text = DataTempStorage.AlgorithmList1[1].ToString();


                    this.RightBehindFirst.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    this.RightBehindSecond.Text = DataTempStorage.AlgorithmList1[1].ToString();


                }
                else if (DataTempStorage.AlgorithmList1.Count == 1)
                {
                    waveformGraph2.Visible = false;
                    waveformGraph4.Visible = false;
                    waveformGraph6.Visible = false;
                    waveformGraph8.Visible = false;
                    this.LeftFrontFirst.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    this.LeftFrontSecond.Text = "";


                    this.RightFrontFirst.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    this.RightFrontSecond.Text = "";


                    this.LeftBehindFirst.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    this.LeftBehindSecond.Text = "";


                    this.RightBehindFirst.Text = DataTempStorage.AlgorithmList1[0].ToString();
                    this.RightBehindSecond.Text = "";

                }

                else
                {
                    waveformGraph1.Visible = false;
                    waveformGraph2.Visible = false;
                    waveformGraph3.Visible = false;
                    waveformGraph4.Visible = false;
                    waveformGraph5.Visible = false;
                    waveformGraph6.Visible = false;
                    waveformGraph7.Visible = false;
                    waveformGraph8.Visible = false;
                    this.LeftFrontFirst.Text = "";
                    this.LeftFrontSecond.Text = "";

                    this.RightFrontFirst.Text = "";
                    this.RightFrontSecond.Text = "";

                    this.LeftBehindFirst.Text = "";
                    this.LeftBehindSecond.Text = "";

                    this.RightBehindFirst.Text = "";
                    this.RightBehindSecond.Text = "";

                }
            }
        }
        //左前轮声音播放
        private void button1_Click(object sender, EventArgs e)
        {
            if(SoundPlayOne.BackColor==Color.LightGray){
                SoundPlayPointer.PlaySound = 1;
                SoundPlayOne.BackColor = Color.Green;
            }
            else
            {
                SoundPlayPointer.PlaySound = 0;
                SoundPlayOne.BackColor = Color.LightGray;
            }
            
        }
        //右前轮声音播放
        private void button2_Click(object sender, EventArgs e)
        {
            if (SoundPlayTwo.BackColor == Color.LightGray)
            {
                SoundPlayPointer.PlaySound = 2;
                SoundPlayTwo.BackColor = Color.Green;
            }
            else
            {
                SoundPlayPointer.PlaySound = 0;
                SoundPlayTwo.BackColor = Color.LightGray;
            }
        }
        //左后轮声音播放
        private void button3_Click(object sender, EventArgs e)
        {
            if (SoundPlayThree.BackColor == Color.LightGray)
            {
                SoundPlayPointer.PlaySound = 3;
                SoundPlayThree.BackColor = Color.Green;
            }
            else
            {
                SoundPlayPointer.PlaySound = 0;
                SoundPlayThree.BackColor = Color.LightGray;
            }
        }
        //右后轮声音播放
        private void button4_Click(object sender, EventArgs e)
        {
            if (SoundPlayFour.BackColor == Color.LightGray)
            {
                SoundPlayPointer.PlaySound = 4;
                SoundPlayFour.BackColor = Color.Green;
            }
            else
            {
                SoundPlayPointer.PlaySound = 0;
                SoundPlayFour.BackColor = Color.LightGray;
            }
        }
    }
}
