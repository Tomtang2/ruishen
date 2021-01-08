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
using System.Collections;
using ruishen.数据库公告类;
using ruishen.公共中间量;

namespace ruishen.参数配置
{
    public partial class ChannelParameterSetForm : Form
    {
        #region 基础变量
        double AnalysisBandWidthValue = 0;//分析带宽值
        double FrequencyGraphValue = 0;//谱线图值
        double ResolutionValue = 0;//分辨率值
        MysqlHelper my;

        #endregion
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // 用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }

        public ChannelParameterSetForm()
        {
            InitializeComponent();
            AcquisitionTime.Visible = false;
            NumericAcquisitionTime.Visible = false;
            AverageNumber.Visible = false; 
            NumericAverageNumber.Visible = false;
            ComboBoxResolution.Items.Clear(); 
            ComboBoxResolution.Items.AddRange(new Object[] { "1", "0.5", "0.25", "0.125", "0.0625", "0.03125" });
            SelectedAxleAndSide();
        }
        /// <summary>
        /// 加载按钮点击执行，完成读取初始值
        /// </summary>
        public void SelectedAxleAndSide()
        {
            ComboBoxAnalysisBandWidth.SelectedIndex = 0;
            ComboBoxFrequencyGraph.SelectedIndex = 0;
            ComboBoxResolution.SelectedIndex = 0;
            ComboBoxWindowsFunction.SelectedIndex = 0;
            ComboBoxAverageWay.SelectedIndex = 0;
            ComboBoxAcquisitionMode.SelectedIndex = 0;
            string selectedAxleAndSide = "select * from diagnosis_ttb_channelparameterset where ChannelNumber=@ChannelNumber";

            //try
            //{
                #region 一通道
                ArrayList point1 = new ArrayList();
                    my = new MysqlHelper();
                    Dictionary<string, object> dic1 = new Dictionary<string, object>();
                    dic1.Add("@ChannelNumber", (int)(1));
                    point1 = my.SelectInfo(selectedAxleAndSide, dic1);
                    foreach (Object[] obj in point1)
                    {
                        if ((int)obj[1] == 1)
                        {
                            Switch1.CheckState = CheckState.Checked;
                        }
                        else {
                            Switch1.CheckState = CheckState.Unchecked;
                        }
                        WheelAndAxle1.Text = (string)obj[2];
                        Coupling1.Text=(string)obj[3];
                        Unit1.Text=(string)obj[4];
                        Sensitivity1.Value = (decimal)((double)obj[5]);
                        Range1.Text = (string)obj[6];
                        WheelSide1.Text=(string)obj[7];
                        ComboBoxAnalysisBandWidth.Text = ((int)obj[8]).ToString();
                        ComboBoxFrequencyGraph.Text = ((int)obj[9]).ToString();
                        ComboBoxResolution.Text=((double)obj[10]).ToString();
                        ComboBoxWindowsFunction.Text = (string)obj[11];
                        ComboBoxAverageWay.Text = (string)obj[12];
                        NumericAverageNumber.Value = (decimal)((int)obj[13]);
                        ComboBoxAcquisitionMode.Text = (string)obj[14];
                        NumericAcquisitionTime.Value = (decimal)((double)obj[15]);

                    }
                #endregion
                #region 二通道

                    ArrayList point2 = new ArrayList();
                    my = new MysqlHelper();
                    Dictionary<string, object> dic2 = new Dictionary<string, object>();
                    dic2 = new Dictionary<string, object>();
                    dic2.Add("@ChannelNumber", (int)(2));
                    point2 = my.SelectInfo(selectedAxleAndSide, dic2);
                    foreach (Object[] obj in point2)
                    {
                        if ((int)obj[1] == 1)
                        {
                            Switch2.CheckState = CheckState.Checked;
                        }
                        else
                        {
                            Switch2.CheckState = CheckState.Unchecked;
                        }
                        WheelAndAxle2.Text = (string)obj[2];
                        Coupling2.Text = (string)obj[3];
                        Unit2.Text = (string)obj[4];
                        Sensitivity2.Value = (decimal)((double)obj[5]);
                        Range2.Text = (string)obj[6];
                        WheelSide2.Text = (string)obj[7];

                    }
                    #endregion
                #region 三通道
                    ArrayList point3 = new ArrayList();
                    my = new MysqlHelper();
                    Dictionary<string, object> dic3 = new Dictionary<string, object>();
                    dic3.Add("@ChannelNumber", (int)(3));
                    point3 = my.SelectInfo(selectedAxleAndSide, dic3);
                    foreach (Object[] obj in point3)
                    {
                        if ((int)obj[1] == 1)
                        {
                            Switch3.CheckState = CheckState.Checked;
                        }
                        else
                        {
                            Switch3.CheckState = CheckState.Unchecked;
                        }
                        WheelAndAxle3.Text = (string)obj[2];
                        Coupling3.Text = (string)obj[3];
                        Unit3.Text = (string)obj[4];
                        Sensitivity3.Value = (decimal)((double)obj[5]);
                        Range3.Text = (string)obj[6];
                        WheelSide3.Text = (string)obj[7];
                    }
                #endregion
                #region 四通道
                    ArrayList point4 = new ArrayList();
                    my = new MysqlHelper();
                    Dictionary<string, object> dic4 = new Dictionary<string, object>();
                    dic4.Add("@ChannelNumber", (int)(4));
                    point4 = my.SelectInfo(selectedAxleAndSide, dic4);
                    foreach (Object[] obj in point4)
                    {
                        if ((int)obj[1] == 1)
                        {
                            Switch4.CheckState = CheckState.Checked;
                        }
                        else
                        {
                            Switch4.CheckState = CheckState.Unchecked;
                        }
                        WheelAndAxle4.Text = (string)obj[2];
                        Coupling4.Text = (string)obj[3];
                        Unit4.Text = (string)obj[4];
                        Sensitivity4.Value = (decimal)((double)obj[5]);
                        Range4.Text = (string)obj[6];
                        WheelSide4.Text = (string)obj[7];
                    }
                    #endregion
                    #region 五通道
                    ArrayList point5 = new ArrayList();
                    my = new MysqlHelper();
                    Dictionary<string, object> dic5 = new Dictionary<string, object>();
                    dic5.Add("@ChannelNumber", (int)(5));
                    point5 = my.SelectInfo(selectedAxleAndSide, dic5);
                    foreach (Object[] obj in point5)
                    {
                        if ((int)obj[1] == 1)
                        {
                            Switch5.CheckState = CheckState.Checked;
                        }
                        else
                        {
                            Switch5.CheckState = CheckState.Unchecked;
                        }
                        WheelAndAxle5.Text = (string)obj[2];
                        Coupling5.Text = (string)obj[3];
                        Unit5.Text = (string)obj[4];
                        Sensitivity5.Value = (decimal)((double)obj[5]);
                        Range5.Text = (string)obj[6];
                        WheelSide5.Text = (string)obj[7];
                    }
                    #endregion

                    #region 六通道
                    ArrayList point6 = new ArrayList();
                    my = new MysqlHelper();
                    Dictionary<string, object> dic6 = new Dictionary<string, object>();
                    dic6.Add("@ChannelNumber", (int)(6));
                    point6 = my.SelectInfo(selectedAxleAndSide, dic6);
                    foreach (Object[] obj in point6)
                    {
                        if ((int)obj[1] == 1)
                        {
                            Switch6.CheckState = CheckState.Checked;
                        }
                        else
                        {
                            Switch6.CheckState = CheckState.Unchecked;
                        }
                        WheelAndAxle6.Text = (string)obj[2];
                        Coupling6.Text = (string)obj[3];
                        Unit6.Text = (string)obj[4];
                        Sensitivity6.Value = (decimal)((double)obj[5]);
                        Range6.Text = (string)obj[6];
                        WheelSide6.Text = (string)obj[7];
                    }
                    #endregion

                    #region 七通道
                    ArrayList point7 = new ArrayList();
                    my = new MysqlHelper();
                    Dictionary<string, object> dic7 = new Dictionary<string, object>();
                    dic7.Add("@ChannelNumber", (int)(7));
                    point7 = my.SelectInfo(selectedAxleAndSide, dic7);
                    foreach (Object[] obj in point7)
                    {
                        if ((int)obj[1] == 1)
                        {
                            Switch7.CheckState = CheckState.Checked;
                        }
                        else
                        {
                            Switch7.CheckState = CheckState.Unchecked;
                        }
                        WheelAndAxle7.Text = (string)obj[2];
                        Coupling7.Text = (string)obj[3];
                        Unit7.Text = (string)obj[4];
                        Sensitivity7.Value = (decimal)((double)obj[5]);
                        Range7.Text = (string)obj[6];
                        WheelSide7.Text = (string)obj[7];
                    }
                    #endregion

                    #region 八通道
                    ArrayList point8 = new ArrayList();
                    my = new MysqlHelper();
                    Dictionary<string, object> dic8 = new Dictionary<string, object>();
                    dic8.Add("@ChannelNumber", (int)(8));
                    point8 = my.SelectInfo(selectedAxleAndSide, dic8);
                    foreach (Object[] obj in point8)
                    {
                        if ((int)obj[1] == 1)
                        {
                            Switch8.CheckState = CheckState.Checked;
                        }
                        else
                        {
                            Switch8.CheckState = CheckState.Unchecked;
                        }
                        WheelAndAxle8.Text = (string)obj[2];
                        Coupling8.Text = (string)obj[3];
                        Unit8.Text = (string)obj[4];
                        Sensitivity8.Value = (decimal)((double)obj[5]);
                        Range8.Text = (string)obj[6];
                        WheelSide8.Text = (string)obj[7];
                    }
                    #endregion

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("查询失败");
            //}
        }
        private void CPS_Load_Click(object sender, EventArgs e)
        {
           // timer1.Enabled = true;
            SelectedAxleAndSide();
            MessageBox.Show("加载成功!", "加载", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        /// <summary>
        /// 实现报警闪烁提醒
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CPS_FlashingLight.BackColor == Color.Blue)
            {
                CPS_FlashingLight.BackColor = Color.Red;
            }
            else {
                CPS_FlashingLight.BackColor = Color.Blue;
            }
        }

        private void ComboBoxAnalysisBandWidth_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ComboBoxAnalysisBandWidth.Text !="" && ComboBoxFrequencyGraph.Text!="")
            {
                AnalysisBandWidthValue = Double.Parse(ComboBoxAnalysisBandWidth.Text);
                FrequencyGraphValue = Double.Parse(ComboBoxFrequencyGraph.Text);
                SelectedComboBoxResolutionValue();

                ComboBoxResolution.Text = (AnalysisBandWidthValue / FrequencyGraphValue).ToString();
            }
           
        }

        private void ComboBoxFrequencyGraph_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ComboBoxAnalysisBandWidth.Text != "" && ComboBoxFrequencyGraph.Text!="")
            {
                AnalysisBandWidthValue = Double.Parse(ComboBoxAnalysisBandWidth.Text);
            FrequencyGraphValue = Double.Parse(ComboBoxFrequencyGraph.Text);
            ComboBoxResolution.Text = (AnalysisBandWidthValue / FrequencyGraphValue).ToString();
            }
            
        }

        private void ComboBoxResolution_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ComboBoxAnalysisBandWidth.Text != "" && ComboBoxResolution.Text!="")
            {
                AnalysisBandWidthValue = Double.Parse(ComboBoxAnalysisBandWidth.Text);
            ResolutionValue = Double.Parse(ComboBoxResolution.Text);
            ComboBoxFrequencyGraph.Text = (AnalysisBandWidthValue / ResolutionValue).ToString();
            }
            AnalysisBandWidthValue = Double.Parse(ComboBoxAnalysisBandWidth.Text);
            ResolutionValue = Double.Parse(ComboBoxResolution.Text);
            ComboBoxFrequencyGraph.Text = (AnalysisBandWidthValue / ResolutionValue).ToString();
            if (ComboBoxAverageWay.Text == "线性平均")
            {
                NumericAcquisitionTime.Value = (decimal)(Convert.ToDouble(NumericAverageNumber.Value) * (double)1 / (Convert.ToDouble(ComboBoxResolution.Text)));
                NumericAcquisitionTime.Enabled = false;
            }
        }
        /// <summary>
        /// 分析带宽可供选择，决定采样频率
        /// 分析带宽 = 采样频率/2.5
        /// 谱线数 = 采样率/2.5
        /// 频率分辨率 = 分析带宽/谱线数
        /// </summary>
        public void SelectedComboBoxResolutionValue() {
            switch (ComboBoxAnalysisBandWidth.Text)
            {
                case "512": ComboBoxResolution.Items.Clear(); ComboBoxResolution.Items.AddRange(new Object[] { "1", "0.5", "0.25", "0.125", "0.0625", "0.03125" }); break;
                case "640": ComboBoxResolution.Items.Clear(); ComboBoxResolution.Items.AddRange(new Object[] { "1.25", "0.625", "0.3125", "0.15625", "0.078125", "0.0390625" }); break;
                case "1024": ComboBoxResolution.Items.Clear(); ComboBoxResolution.Items.AddRange(new Object[] { "2", "1", "0.5", "0.25", "0.125", "0.0625" }); break;
                case "1280": ComboBoxResolution.Items.Clear(); ComboBoxResolution.Items.AddRange(new Object[] { "2.5", "1.25", "0.625", "0.3125", "0.15625", "0.078125" }); break;
                case "2048": ComboBoxResolution.Items.Clear(); ComboBoxResolution.Items.AddRange(new Object[] { "4", "2", "1", "0.5", "0.25", "0.125" }); break;
                case "2560": ComboBoxResolution.Items.Clear(); ComboBoxResolution.Items.AddRange(new Object[] { "5", "2.5", "1.25", "0.625", "0.3125", "0.15625" }); break;
                case "5120": ComboBoxResolution.Items.Clear(); ComboBoxResolution.Items.AddRange(new Object[] { "10", "5", "2.5", "1.25", "0.625", "0.3125" }); break;
                case "8192": ComboBoxResolution.Items.Clear(); ComboBoxResolution.Items.AddRange(new Object[] { "16", "8", "4", "2", "1", "0.5" }); break;
                case "10240": ComboBoxResolution.Items.Clear(); ComboBoxResolution.Items.AddRange(new Object[] { "20", "10", "5", "2.5", "1.25", "0.625" }); break;
                case "20480": ComboBoxResolution.Items.Clear(); ComboBoxResolution.Items.AddRange(new Object[] { "40", "20", "10", "5", "2.5", "1.25" }); break;
            }
        }

        private void ComboBoxAcquisitionMode_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (ComboBoxAcquisitionMode.Text)
            {
                case "连续采样": AcquisitionTime.Visible = false; NumericAcquisitionTime.Visible = false; NumericAcquisitionTime.Value=0; break;
                case "定时采样": AcquisitionTime.Visible = true; NumericAcquisitionTime.Visible = true; ; break;
                   
            }
        }

        private void ComboBoxAverageWay_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (ComboBoxAverageWay.Text)
            {
                case "无平均": AverageNumber.Visible = false; NumericAverageNumber.Visible = false; ComboBoxAcquisitionMode.Enabled = true; ComboBoxAcquisitionMode.Text = "连续采样"; NumericAcquisitionTime.Enabled = true; break;
                case "线性平均": AverageNumber.Visible = true; NumericAverageNumber.Visible = true; NumericAverageNumber.Value = 10; AcquisitionTime.Visible = true; ComboBoxAcquisitionMode.Text = "定时采样"; ComboBoxAcquisitionMode.Enabled = false; NumericAcquisitionTime.Visible = true; NumericAcquisitionTime.Value = (decimal)(Convert.ToDouble(NumericAverageNumber.Value) * (double)1 / (Convert.ToDouble(ComboBoxResolution.Text))); NumericAcquisitionTime.Enabled = false; break;
                case "指数平均": AverageNumber.Visible = true; NumericAverageNumber.Visible = true; NumericAverageNumber.Value = 10; ComboBoxAcquisitionMode.Enabled = true; ComboBoxAcquisitionMode.Text = "定时采样"; AcquisitionTime.Visible = true; NumericAcquisitionTime.Enabled = true; break;
                case "峰值保持": AverageNumber.Visible = false; NumericAverageNumber.Visible = false; ComboBoxAcquisitionMode.Enabled = true; ComboBoxAcquisitionMode.Text = "连续采样"; NumericAcquisitionTime.Enabled = true; break;
            }
        }
        private int isChecked(CheckBox checkbox) { 
            if(checkbox.CheckState==CheckState.Checked){
                return 1;
            }
            return 0;
        }
        private void CPS_Save_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("仅保留最新配置，确认保存吗？", "配置参数", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK) {
                DataTempStorage.AnalysisBandWidth1 = ComboBoxAnalysisBandWidth.Text;
                DataTempStorage.FrequencyGraph1 = ComboBoxFrequencyGraph.Text;
                DataTempStorage.Resolutio1 = ComboBoxResolution.Text;
                DataTempStorage.SampleWay1 = ComboBoxAcquisitionMode.Text;
                DataTempStorage.WindowFunction1 = ComboBoxWindowsFunction.Text;
                DataTempStorage.AverageMode1 = ComboBoxAverageWay.Text;
                DataTempStorage.AverageNumber1 =(int) NumericAverageNumber.Value;
                DataTempStorage.AcquisitionTime1 = (double)NumericAcquisitionTime.Value;

                MysqlHelper my = new MysqlHelper();

                string update_sql = "update diagnosis_ttb_channelparameterset set  ChannelNumber=@ChannelNumber, Switch=@Switch,WheelAndAxle=@WheelAndAxle,Coupling=@Coupling,Unit=@Unit,Sensitivity=@Sensitivity,SensorRange=@SensorRange,WheelSide=@WheelSide,AnalysisBandWidth=@AnalysisBandWidth,FrequencyGraph=@FrequencyGraph,Resolution=@Resolution,WindowsFunction=@WindowsFunction,AverageWay=@AverageWay,AverageNumber=@AverageNumber,AcquisitionMode=@AcquisitionMode,AcquisitionTime=@AcquisitionTime,SampleRate=@SampleRate,SampleNumber=@SampleNumber where  ChannelNumber=@ChannelNumber";

                #region 一通道
                Dictionary<string, object> dic1 = new Dictionary<string, object>();
                dic1.Add("@ChannelNumber", (int)1);
                dic1.Add("@Switch", isChecked(Switch1));	//将其放入字典（类似JSON，采用键值对的方式传递）
                dic1.Add("@WheelAndAxle", WheelAndAxle1.Text);
                dic1.Add("@Coupling", Coupling1.Text);
                dic1.Add("@Unit", Unit1.Text);
                dic1.Add("@Sensitivity", (double)Sensitivity1.Value);

                dic1.Add("@SensorRange", Range1.Text);
                dic1.Add("@WheelSide", WheelSide1.Text);
                dic1.Add("@AnalysisBandWidth", Convert.ToInt32(ComboBoxAnalysisBandWidth.Text));
                dic1.Add("@FrequencyGraph", Convert.ToInt32(ComboBoxFrequencyGraph.Text));
                dic1.Add("@Resolution", Convert.ToDouble(ComboBoxResolution.Text));
                dic1.Add("@WindowsFunction", ComboBoxWindowsFunction.Text);
                dic1.Add("@AverageWay", ComboBoxAverageWay.Text);
                dic1.Add("@AverageNumber", (int)NumericAverageNumber.Value);
                dic1.Add("@AcquisitionMode", ComboBoxAcquisitionMode.Text);
                dic1.Add("@AcquisitionTime", (double)NumericAcquisitionTime.Value);
                dic1.Add("@SampleRate", (int)(Convert.ToInt32(ComboBoxAnalysisBandWidth.Text)*2.5));
                dic1.Add("@SampleNumber", (int)( Convert.ToInt32(ComboBoxFrequencyGraph.Text)) * 2.5);

                if (!my.MySqlPour(update_sql, dic1)) { MessageBox.Show("一通道失败"); };
                #endregion

                #region 二通道
                Dictionary<string, object> dic2 = new Dictionary<string, object>();
                dic2.Add("@ChannelNumber", (int)2);
                dic2.Add("@Switch", isChecked(Switch2));	//将其放入字典（类似JSON，采用键值对的方式传递）
                dic2.Add("@WheelAndAxle", WheelAndAxle2.Text);
                dic2.Add("@Coupling", Coupling2.Text);
                dic2.Add("@Unit", Unit2.Text);
                dic2.Add("@Sensitivity", (double)Sensitivity2.Value);

                dic2.Add("@SensorRange", Range2.Text);
                dic2.Add("@WheelSide", WheelSide2.Text);
                dic2.Add("@AnalysisBandWidth", Convert.ToInt32(ComboBoxAnalysisBandWidth.Text));
                dic2.Add("@FrequencyGraph", Convert.ToInt32(ComboBoxFrequencyGraph.Text));
                dic2.Add("@Resolution", Convert.ToDouble(ComboBoxResolution.Text));
                dic2.Add("@WindowsFunction", ComboBoxWindowsFunction.Text);
                dic2.Add("@AverageWay", ComboBoxAverageWay.Text);
                dic2.Add("@AverageNumber", (int)NumericAverageNumber.Value);
                dic2.Add("@AcquisitionMode", ComboBoxAcquisitionMode.Text);
                dic2.Add("@AcquisitionTime", (double)NumericAcquisitionTime.Value);
                dic2.Add("@SampleRate", (int)(Convert.ToInt32(ComboBoxAnalysisBandWidth.Text) * 2.5));
                dic2.Add("@SampleNumber", (int)(Convert.ToInt32(ComboBoxFrequencyGraph.Text)) * 2.5);
                if (!my.MySqlPour(update_sql, dic2)) { MessageBox.Show("二通道失败"); };
                #endregion

                #region 三通道
                Dictionary<string, object> dic3 = new Dictionary<string, object>();
                dic3.Add("@ChannelNumber", (int)3);
                dic3.Add("@Switch", isChecked(Switch3));	//将其放入字典（类似JSON，采用键值对的方式传递）
                dic3.Add("@WheelAndAxle", WheelAndAxle3.Text);
                dic3.Add("@Coupling", Coupling3.Text);
                dic3.Add("@Unit", Unit3.Text);
                dic3.Add("@Sensitivity", (double)Sensitivity3.Value);

                dic3.Add("@SensorRange", Range3.Text);
                dic3.Add("@WheelSide", WheelSide3.Text);
                dic3.Add("@AnalysisBandWidth", Convert.ToInt32(ComboBoxAnalysisBandWidth.Text));
                dic3.Add("@FrequencyGraph", Convert.ToInt32(ComboBoxFrequencyGraph.Text));
                dic3.Add("@Resolution", Convert.ToDouble(ComboBoxResolution.Text));
                dic3.Add("@WindowsFunction", ComboBoxWindowsFunction.Text);
                dic3.Add("@AverageWay", ComboBoxAverageWay.Text);
                dic3.Add("@AverageNumber", (int)NumericAverageNumber.Value);
                dic3.Add("@AcquisitionMode", ComboBoxAcquisitionMode.Text);
                dic3.Add("@AcquisitionTime", (double)NumericAcquisitionTime.Value);
                dic3.Add("@SampleRate", (int)(Convert.ToInt32(ComboBoxAnalysisBandWidth.Text) * 2.5));
                dic3.Add("@SampleNumber", (int)(Convert.ToInt32(ComboBoxFrequencyGraph.Text)) * 2.5);
                if (!my.MySqlPour(update_sql, dic3)) { MessageBox.Show("三通道失败"); };
                #endregion

                #region 四通道
                Dictionary<string, object> dic4 = new Dictionary<string, object>();
                dic4.Add("@ChannelNumber", (int)4);
                dic4.Add("@Switch", isChecked(Switch4));	//将其放入字典（类似JSON，采用键值对的方式传递）
                dic4.Add("@WheelAndAxle", WheelAndAxle4.Text);
                dic4.Add("@Coupling", Coupling4.Text);
                dic4.Add("@Unit", Unit4.Text);
                dic4.Add("@Sensitivity", (double)Sensitivity4.Value);

                dic4.Add("@SensorRange", Range4.Text);
                dic4.Add("@WheelSide", WheelSide4.Text);
                dic4.Add("@AnalysisBandWidth", Convert.ToInt32(ComboBoxAnalysisBandWidth.Text));
                dic4.Add("@FrequencyGraph", Convert.ToInt32(ComboBoxFrequencyGraph.Text));
                dic4.Add("@Resolution", Convert.ToDouble(ComboBoxResolution.Text));
                dic4.Add("@WindowsFunction", ComboBoxWindowsFunction.Text);
                dic4.Add("@AverageWay", ComboBoxAverageWay.Text);
                dic4.Add("@AverageNumber", (int)NumericAverageNumber.Value);
                dic4.Add("@AcquisitionMode", ComboBoxAcquisitionMode.Text);
                dic4.Add("@AcquisitionTime", (double)NumericAcquisitionTime.Value);
                dic4.Add("@SampleRate", (int)(Convert.ToInt32(ComboBoxAnalysisBandWidth.Text) * 2.5));
                dic4.Add("@SampleNumber", (int)(Convert.ToInt32(ComboBoxFrequencyGraph.Text)) * 2.5);
                if (!my.MySqlPour(update_sql, dic4)) { MessageBox.Show("四通道失败"); };
                #endregion

                #region 五通道
                Dictionary<string, object> dic5 = new Dictionary<string, object>();
                dic5.Add("@ChannelNumber", (int)5);
                dic5.Add("@Switch", isChecked(Switch5));	//将其放入字典（类似JSON，采用键值对的方式传递）
                dic5.Add("@WheelAndAxle", WheelAndAxle5.Text);
                dic5.Add("@Coupling", Coupling5.Text);
                dic5.Add("@Unit", Unit5.Text);
                dic5.Add("@Sensitivity", (double)Sensitivity5.Value);

                dic5.Add("@SensorRange", Range5.Text);
                dic5.Add("@WheelSide", WheelSide5.Text);
                dic5.Add("@AnalysisBandWidth", Convert.ToInt32(ComboBoxAnalysisBandWidth.Text));
                dic5.Add("@FrequencyGraph", Convert.ToInt32(ComboBoxFrequencyGraph.Text));
                dic5.Add("@Resolution", Convert.ToDouble(ComboBoxResolution.Text));
                dic5.Add("@WindowsFunction", ComboBoxWindowsFunction.Text);
                dic5.Add("@AverageWay", ComboBoxAverageWay.Text);
                dic5.Add("@AverageNumber", (int)NumericAverageNumber.Value);
                dic5.Add("@AcquisitionMode", ComboBoxAcquisitionMode.Text);
                dic5.Add("@AcquisitionTime", (double)NumericAcquisitionTime.Value);
                dic5.Add("@SampleRate", (int)(Convert.ToInt32(ComboBoxAnalysisBandWidth.Text) * 2.5));
                dic5.Add("@SampleNumber", (int)(Convert.ToInt32(ComboBoxFrequencyGraph.Text)) * 2.5);
                if (!my.MySqlPour(update_sql, dic5)) { MessageBox.Show("五通道失败"); };
                #endregion

                #region 六通道
                Dictionary<string, object> dic6 = new Dictionary<string, object>();
                dic6.Add("@ChannelNumber", (int)6);
                dic6.Add("@Switch", isChecked(Switch6));	//将其放入字典（类似JSON，采用键值对的方式传递）
                dic6.Add("@WheelAndAxle", WheelAndAxle6.Text);
                dic6.Add("@Coupling", Coupling6.Text);
                dic6.Add("@Unit", Unit6.Text);
                dic6.Add("@Sensitivity", (double)Sensitivity6.Value);

                dic6.Add("@SensorRange", Range6.Text);
                dic6.Add("@WheelSide", WheelSide6.Text);
                dic6.Add("@AnalysisBandWidth", Convert.ToInt32(ComboBoxAnalysisBandWidth.Text));
                dic6.Add("@FrequencyGraph", Convert.ToInt32(ComboBoxFrequencyGraph.Text));
                dic6.Add("@Resolution", Convert.ToDouble(ComboBoxResolution.Text));
                dic6.Add("@WindowsFunction", ComboBoxWindowsFunction.Text);
                dic6.Add("@AverageWay", ComboBoxAverageWay.Text);
                dic6.Add("@AverageNumber", (int)NumericAverageNumber.Value);
                dic6.Add("@AcquisitionMode", ComboBoxAcquisitionMode.Text);
                dic6.Add("@AcquisitionTime", (double)NumericAcquisitionTime.Value);
                dic6.Add("@SampleRate", (int)(Convert.ToInt32(ComboBoxAnalysisBandWidth.Text) * 2.5));
                dic6.Add("@SampleNumber", (int)(Convert.ToInt32(ComboBoxFrequencyGraph.Text)) * 2.5);
                if (!my.MySqlPour(update_sql, dic6)) { MessageBox.Show("六通道失败"); };
                #endregion

                #region 七通道
                Dictionary<string, object> dic7 = new Dictionary<string, object>();
                dic7.Add("@ChannelNumber", (int)7);
                dic7.Add("@Switch", isChecked(Switch7));	//将其放入字典（类似JSON，采用键值对的方式传递）
                dic7.Add("@WheelAndAxle", WheelAndAxle7.Text);
                dic7.Add("@Coupling", Coupling7.Text);
                dic7.Add("@Unit", Unit7.Text);
                dic7.Add("@Sensitivity", (double)Sensitivity7.Value);

                dic7.Add("@SensorRange", Range7.Text);
                dic7.Add("@WheelSide", WheelSide7.Text);
                dic7.Add("@AnalysisBandWidth", Convert.ToInt32(ComboBoxAnalysisBandWidth.Text));
                dic7.Add("@FrequencyGraph", Convert.ToInt32(ComboBoxFrequencyGraph.Text));
                dic7.Add("@Resolution", Convert.ToDouble(ComboBoxResolution.Text));
                dic7.Add("@WindowsFunction", ComboBoxWindowsFunction.Text);
                dic7.Add("@AverageWay", ComboBoxAverageWay.Text);
                dic7.Add("@AverageNumber", (int)NumericAverageNumber.Value);
                dic7.Add("@AcquisitionMode", ComboBoxAcquisitionMode.Text);
                dic7.Add("@AcquisitionTime", (double)NumericAcquisitionTime.Value);
                dic7.Add("@SampleRate", (int)(Convert.ToInt32(ComboBoxAnalysisBandWidth.Text) * 2.5));
                dic7.Add("@SampleNumber", (int)(Convert.ToInt32(ComboBoxFrequencyGraph.Text)) * 2.5);
                if (!my.MySqlPour(update_sql, dic7)) { MessageBox.Show("七通道失败"); };
                #endregion

                #region 八通道
                Dictionary<string, object> dic8 = new Dictionary<string, object>();
                dic8.Add("@ChannelNumber", (int)8);
                dic8.Add("@Switch", isChecked(Switch8));	//将其放入字典（类似JSON，采用键值对的方式传递）
                dic8.Add("@WheelAndAxle", WheelAndAxle8.Text);
                dic8.Add("@Coupling", Coupling8.Text);
                dic8.Add("@Unit", Unit8.Text);
                dic8.Add("@Sensitivity", (double)Sensitivity8.Value);

                dic8.Add("@SensorRange", Range8.Text);
                dic8.Add("@WheelSide", WheelSide8.Text);
                dic8.Add("@AnalysisBandWidth", Convert.ToInt32(ComboBoxAnalysisBandWidth.Text));
                dic8.Add("@FrequencyGraph", Convert.ToInt32(ComboBoxFrequencyGraph.Text));
                dic8.Add("@Resolution", Convert.ToDouble(ComboBoxResolution.Text));
                dic8.Add("@WindowsFunction", ComboBoxWindowsFunction.Text);
                dic8.Add("@AverageWay", ComboBoxAverageWay.Text);
                dic8.Add("@AverageNumber", (int)NumericAverageNumber.Value);
                dic8.Add("@AcquisitionMode", ComboBoxAcquisitionMode.Text);
                dic8.Add("@AcquisitionTime", (double)NumericAcquisitionTime.Value);
                dic8.Add("@SampleRate", (int)(Convert.ToInt32(ComboBoxAnalysisBandWidth.Text) * 2.5));
                dic8.Add("@SampleNumber", (int)(Convert.ToInt32(ComboBoxFrequencyGraph.Text)) * 2.5);
                if (!my.MySqlPour(update_sql, dic8)) { MessageBox.Show("八通道失败"); };
                #endregion
                this.Close();
            }
        }

        private void ChannelParameterSetForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void NumericAverageNumber_ValueChanged(object sender, EventArgs e)
        {
            if (ComboBoxAverageWay.Text=="线性平均")
            {
                NumericAcquisitionTime.Value = (decimal)(Convert.ToDouble(NumericAverageNumber.Value) * (double)1 / (Convert.ToDouble(ComboBoxResolution.Text)));
                NumericAcquisitionTime.Enabled = false;
            }
        }

       
      
    }
}
