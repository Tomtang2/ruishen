using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.DAQmx;
using ruishen.序列化和反序列化;
using DigitalSignalProcessing;
using System.Collections;
using ruishen.数据库公告类;
using ruishen.Entity;
using ruishen.公共中间量;
using ruishen.声音算法代码;
using System.Threading;
using ruishen.窗函数;
using MySql.Data.MySqlClient;
using NationalInstruments;
using NationalInstruments.Analysis.Math;
using NationalInstruments.Analysis;
using ruishen.振动算法代码;
using ruishen.报告生成;


namespace ruishen
{
    public partial class FrmMain : Form
    {
        #region 采集器初始化
        string constr = "server=localhost;database=faultdiagnosis;uid=root;pwd=ttb1996;charset=utf8;Allow User Variables=True";
        private AnalogMultiChannelReader analogInReader;
        private AIAccelerometerSensitivityUnits sensitivityUnits;//振动灵敏度
        private AISoundPressureUnits soundUnits;//声压灵敏度
        private AICoupling inputCoupling;//耦合方式
        private AnalogWaveform<double>[] analogWaveformData;//模拟波形
        private Task myTask = null;
        private Task runningTask = null;
        private AsyncCallback analogCallback;

        MysqlHelper my;
        Dictionary<string, object> dic1;
        ArrayList al;
      
        ChannelParameterConfig channelParameterConfig;//通道参数配置
       
        string find_sql = "select * from diagnosis_ttb_channelparameterset where ChannelNumber=@ChannelNumber";
        ruishen.实时监测.VibrationMonitor vibrationMonitor=GenericSingleton<ruishen.实时监测.VibrationMonitor>.CreateInstrance();
        ruishen.实时监测.NoisyMonitor noisyMonitor = GenericSingleton<ruishen.实时监测.NoisyMonitor>.CreateInstrance();
        ruishen.实时监测.RealFilter realFilter = GenericSingleton<ruishen.实时监测.RealFilter>.CreateInstrance();
        ruishen.公共中间量.DataAnalysisCommonForm dataAnalysisCommonForm = null;
    
        ruishen.实时监测.RealMonitorCollection realMonitorCollection = null;
        
        string [] MeasuringPoint=new string[8];//记录1#左，1#右...
     
        int setChannelCount = 8;//打开的通道数
        double SensorVoltageValue = (double)0;//传感器供电激励
        System.Media.SoundPlayer sndPlayer;
        private MySqlConnection conn = null;
        private MySqlCommand command;
        private MySqlDataReader sdr;
       
        Thread timeThread=null;
        private bool SaveCharacterValue = false;

        private double[] FrequencyA = new double[4];
        string[] TableName = new string[8];
      
        MysqlHelper helper = new MysqlHelper();

       private DateTime starTime ;
       private DateTime endTime;

       private static bool isDisplayCharacterValue=true;//是否展示特征值

       private static int continuesSaveTime = 1;
       
        #endregion
        public FrmMain()
        {
            InitializeComponent();
        }
        //解决闪屏问题
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }


        private void buttonItem5_Click(object sender, EventArgs e)
        {
            //进行窗体添加，把窗体加载到MainPanel中进行显示
            MainPanel.Controls.Clear();
            ruishen.振动分析.VibrationDataSearch dataSearch = GenericSingleton<ruishen.振动分析.VibrationDataSearch>.CreateInstrance();
            dataSearch.Dock = DockStyle.Fill;
            dataSearch.TopLevel = false;
            dataSearch.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MainPanel.Controls.Add(dataSearch);
            dataSearch.Show();
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            ruishen.振动分析.FilterForm filterForm = GenericSingleton<ruishen.振动分析.FilterForm>.CreateInstrance();
            filterForm.Dock = DockStyle.Fill;
            filterForm.TopLevel = false;
            filterForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MainPanel.Controls.Add(filterForm);
            filterForm.Show();
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            #region 频谱窗体基础设置
            MainPanel.Controls.Clear();
            dataAnalysisCommonForm = GenericSingleton<ruishen.公共中间量.DataAnalysisCommonForm>.CreateInstrance();
            dataAnalysisCommonForm.Dock = DockStyle.Fill;
            dataAnalysisCommonForm.TopLevel = false;
            dataAnalysisCommonForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            
            
            #endregion
            #region 算法处理，进行傅里叶变换
            try
            {
                dataAnalysisCommonForm.sampleWaveformGraph.ClearData();
                double[] FrequencyData;
                FrequencyData = Signal_FrequencySpectrum(DataTempStorage.TempVibrationData1);
                dataAnalysisCommonForm.sampleWaveformGraph.PlotY(FrequencyData, 0,(((double)DataTempStorage.TempVibrationSampleFrequency1))/FrequencyData.Length/2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据不能为空，请加载数据后再处理");
            }
            #endregion
            MainPanel.Controls.Add(dataAnalysisCommonForm);
            dataAnalysisCommonForm.sampleWaveformGraph.Caption = "频谱图";
            dataAnalysisCommonForm.sampleWaveformGraph.XAxes[0].Caption = "Frequency/Hz";
            dataAnalysisCommonForm.sampleWaveformGraph.YAxes[0].Caption = "Amplitude/g";
            dataAnalysisCommonForm.Show();

        }
        //阈值设置窗体
        private void buttonItem2_Click(object sender, EventArgs e)
        {
          
            ruishen.参数配置.ThresholdSetForm thresholdSetForm = GenericSingleton<ruishen.参数配置.ThresholdSetForm>.CreateInstrance();
            
            thresholdSetForm.TopMost = true;
            thresholdSetForm.Show();
           
           
        }
        //采样设置窗体
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            //MainPanel.Controls.Clear();
            ruishen.参数配置.ChannelParameterSetForm channelParameterSetForm = GenericSingleton<ruishen.参数配置.ChannelParameterSetForm>.CreateInstrance();
           
            channelParameterSetForm.TopMost = true;
            channelParameterSetForm.Show();

           
        }
        //轴承设置窗体
        private void buttonItem4_Click(object sender, EventArgs e)
        {
           
            ruishen.参数配置.BearingSetForm bearingSetForm = GenericSingleton<ruishen.参数配置.BearingSetForm>.CreateInstrance();
           
            bearingSetForm.ShowDialog();

        }
        //实时振动监测按钮
        private void Real_VibrationMonitor_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            vibrationMonitor.Dock = DockStyle.Fill;
            vibrationMonitor.TopLevel = false;
            vibrationMonitor.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MainPanel.Controls.Add(vibrationMonitor);
            Real_VibrationMonitor.Image=global::ruishen.Properties.Resources.振动点击;
            Real_NoisyMonitor.Image = global::ruishen.Properties.Resources.声音;
            Real_GlobalMonitoring.Image = global::ruishen.Properties.Resources.全局监测;
            vibrationMonitor.Show();
        }
        //噪音监测界面
        private void Real_NoisyMonitor_Click(object sender, EventArgs e)
        {
           
            MainPanel.Controls.Clear();
            noisyMonitor.Dock = DockStyle.Fill;
            noisyMonitor.TopLevel = false;
            noisyMonitor.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MainPanel.Controls.Add(noisyMonitor);
            Real_NoisyMonitor.Image = global::ruishen.Properties.Resources.声音点击;
            Real_VibrationMonitor.Image = global::ruishen.Properties.Resources.振动;
            Real_GlobalMonitoring.Image = global::ruishen.Properties.Resources.全局监测;
            noisyMonitor.Show();
        }
       

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Real_VibrationMonitor.Enabled = false;
            this.Real_NoisyMonitor.Enabled = false;
            this.Real_GlobalMonitoring.Enabled = false;
            this.Real_DataSave.Enabled = false;
            SystemCurrentTime.Enabled = true;
            
        }

        private void Real_DataCollection_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            if (realMonitorCollection != null)
            {

                realMonitorCollection.Close();

            }
           if(DataTempStorage.SampleWay1=="定时采样")
           {
               SaveTimeCount.Visible = false;
           }
            try
            {

                if (ribbonBar6.Text == "数据预览")
                {
                    OneChannnelCharacterOne.Clear();
                    OneChannnelCharacterTwo.Clear();
                    TwoChannnelCharacterOne.Clear();
                    ThreeChannnelCharacterTwo.Clear();
                    ThreeChannnelCharacterOne.Clear();
                    ThreeChannnelCharacterTwo.Clear();
                    FourChannnelCharacterOne.Clear();
                    FourChannnelCharacterTwo.Clear();

                   

                    ProductInformationCheckForm productInformationCheckForm = new ProductInformationCheckForm();
                    productInformationCheckForm.ShowDialog();
                    isDisplayCharacterValue = true;
                    if ((DataTempStorage.FirstSet.Count - DataTempStorage.CurrentForwardWheelNumber) == 0)
                    {
                        MessageBox.Show("轮对测量结束");
                    }
                    else
                    {

                    
                    if(DataTempStorage.IsCollectData1)
                    {
                        //不允许后期操作
                        ribbonTabItem4.Enabled = false;
                        ribbonTabItem5.Enabled = false;
                        ribbonTabItem6.Enabled = false;
                        //
                        realMonitorCollection = GenericSingleton<ruishen.实时监测.RealMonitorCollection>.CreateInstrance();
                        realMonitorCollection.Dock = DockStyle.Fill;
                        realMonitorCollection.TopLevel = false;
                        realMonitorCollection.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        MainPanel.Controls.Add(realMonitorCollection);
                        Real_NoisyMonitor.Image = global::ruishen.Properties.Resources.声音;
                        Real_VibrationMonitor.Image = global::ruishen.Properties.Resources.振动;
                        realMonitorCollection.Show();

                        labelAnalysisBandWidth.Text = DataTempStorage.AnalysisBandWidth1;
                        labelFrequencyGraph.Text = DataTempStorage.FrequencyGraph1;
                        labelResolutio.Text = DataTempStorage.Resolutio1;
                        labelWindowFunction.Text = DataTempStorage.WindowFunction1;
                        labelAverageMode.Text = DataTempStorage.AverageMode1;
                        labelSampleWay.Text = DataTempStorage.SampleWay1;
                        if (DataTempStorage.FirstSet == null)
                        {
                        }
                        else 
                        {
                            int ForwardWheelSetCount=DataTempStorage.FirstSet.Count- DataTempStorage.CurrentForwardWheelNumber-1;
                            if (ForwardWheelSetCount<=0)
                            {
                                ForwardLeft.Text = "0";
                            }
                            else
                            {
                                ForwardLeft.Text = ForwardWheelSetCount.ToString();
                            }
                            
                         
                        }
                        if (DataTempStorage.SecondSet == null)
                        {
                            
                        }
                        else
                        {
                            int BehindWheelSetCount = DataTempStorage.SecondSet.Count - DataTempStorage.CurrentBehindWheelNumber - 1;
                            if (BehindWheelSetCount<=0)
                            {
                                BehindLeft.Text = "0";
                            }
                            else
                            {
                                BehindLeft.Text = BehindWheelSetCount.ToString();
                            }

                          
                        }
                        
                        if (dataAnalysisCommonForm != null)
                        {
                            dataAnalysisCommonForm.axWindowsMediaPlayer1.Ctlcontrols.stop();
                        }

                        continuesSaveTime = 1;
                        TotalTimeCount.Visible = false;
                        MeasuringPoint = SelectedAxleAndSide();
                        this.Real_VibrationMonitor.Enabled = true;
                        this.Real_NoisyMonitor.Enabled = true;
                        this.Real_GlobalMonitoring.Enabled = true;
                        this.Real_DataSave.Enabled = true;

                        buttonItem3.Enabled = false;
                        buttonItem4.Enabled = false;
                        buttonItem6.Enabled = false;
                        buttonItem2.Enabled = false;
                        analogWaveformData = new AnalogWaveform<double>[8];
                        ribbonBar6.Text = "停止";
                        this.Real_DataCollection.Image = global::ruishen.Properties.Resources.启动;
                        Real_GlobalMonitoring.Image = global::ruishen.Properties.Resources.全局监测中;
                       
                        myTask = new Task();
                        #region 设置通道参数

                        for (int i = 1; i <= setChannelCount; i++)
                        {
                            try
                            {
                                my = new MysqlHelper();
                                dic1 = new Dictionary<string, object>();
                                dic1.Add("@ChannelNumber", i);
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
                                    channelParameterConfig.AcquisitionTime1 = (double)obj[15];
                                    channelParameterConfig.SampleRate1 = (int)obj[16];
                                    channelParameterConfig.SampleNumber1 = (int)obj[17];

                                    DataTempStorage.SampleTime1 = channelParameterConfig.AcquisitionTime1;//设置采样时间，若是为0，默认连续采样。采样时间单位/s
                                }
                                if (i <= setChannelCount / 2)
                                {
                                    // 灵敏度单位
                                    switch (channelParameterConfig.Unit1)
                                    {
                                        case "mVolts/g": // Units mVolts/G
                                            sensitivityUnits = AIAccelerometerSensitivityUnits.MillivoltsPerG;
                                            break;
                                        case "Volts/g":
                                        default: // Units Volts/G
                                            sensitivityUnits = AIAccelerometerSensitivityUnits.VoltsPerG;
                                            break;
                                    }
                                }
                                else
                                {
                                    switch (channelParameterConfig.Unit1)
                                    {
                                        //case "g": 
                                        //    soundUnits = AISoundPressureUnits.FromCustomScale;
                                        //    break;
                                        case "mV/Pa":
                                        default:
                                            soundUnits = AISoundPressureUnits.Pascals;
                                            break;
                                    }
                                }

                                // 耦合方式
                                switch (channelParameterConfig.Coupling1)
                                {
                                    case "AC":
                                        inputCoupling = AICoupling.AC;
                                        SensorVoltageValue = 0;
                                        break;
                                    case "DC":
                                        inputCoupling = AICoupling.DC;
                                        SensorVoltageValue = 0;
                                        break;
                                    case "ICP":
                                        inputCoupling = AICoupling.AC;
                                        SensorVoltageValue = 0.002;//传感器激励电流0.002A
                                        break;

                                }
                                AIChannel aiChannel;
                                try
                                {
                                    if (i <= setChannelCount / 2)
                                    {
                                        // 创建虚拟通道
                                        aiChannel = myTask.AIChannels.CreateAccelerometerChannel(DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External)[i - 1], "",
                                            AITerminalConfiguration.Pseudodifferential, -5, 5,
                                            Convert.ToDouble(channelParameterConfig.Sensitivity1), sensitivityUnits, AIExcitationSource.Internal,
                                            SensorVoltageValue, AIAccelerationUnits.G);
                                        aiChannel.Coupling = inputCoupling;
                                    }
                                    else
                                    {

                                        aiChannel = myTask.AIChannels.CreateMicrophoneChannel(DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External)[i - 1], "",
                                        Convert.ToDouble(channelParameterConfig.Sensitivity1), Convert.ToDouble(120),
                                           AITerminalConfiguration.Pseudodifferential, AIExcitationSource.Internal, SensorVoltageValue, soundUnits);
                                        aiChannel.Coupling = inputCoupling;

                                    }
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("通道配置错误!");
                                }


                                // 耦合方式

                                // Configure the timing parameters
                                myTask.Timing.ConfigureSampleClock("", Convert.ToDouble(channelParameterConfig.SampleRate1),
                                    SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples, channelParameterConfig.SampleNumber1);                         // Verify the Task
                                myTask.Control(TaskAction.Verify);

                                analogInReader = new AnalogMultiChannelReader(myTask.Stream);
                                analogInReader.SynchronizeCallbacks = true;

                            }
                            catch (DaqException exception)
                            {
                                MessageBox.Show(exception.Message);
                                runningTask = null;
                                myTask.Dispose();
                            }
                        }
                        #endregion 开启线程
                        analogCallback = new AsyncCallback(AnalogInCallback);
                        runningTask = myTask;

                        analogInReader.BeginReadMultiSample(channelParameterConfig.SampleNumber1, analogCallback, myTask);
                        if (labelSampleWay.Text == "定时采样")
                        {
                            labelAcquisitionTime.Text = channelParameterConfig.AcquisitionTime1.ToString();
                        }
                        else if (labelSampleWay.Text == "连续采样")
                        {
                            labelAcquisitionTime.Text = "";
                        }
                    }
                 
                }
                }
                else
                {
                    //dataCollection.Visible = false;
                    this.Real_VibrationMonitor.Enabled = false;
                    this.Real_NoisyMonitor.Enabled = false;
                    this.Real_GlobalMonitoring.Enabled = false;
                    this.Real_DataSave.Enabled = false;
                    DataTempStorage.IsCollectData1 = false;

                    buttonItem3.Enabled = true;
                    buttonItem4.Enabled = true;
                    buttonItem6.Enabled = true;
                    buttonItem2.Enabled = true;

                    //打开后期操作
                    ribbonTabItem4.Enabled = true;
                    ribbonTabItem5.Enabled = true;
                    ribbonTabItem6.Enabled = true;
                    //清空队列数据
                    q1.Clear();
                    q2.Clear();
                    q3.Clear();
                    q4.Clear();
                    q5.Clear();
                    q6.Clear();
                    q7.Clear();
                    q8.Clear();

                    DataTempStorage.CurrentForwardWheelNumber++;
                    DataTempStorage.CurrentBehindWheelNumber++;
                    ribbonBar6.Text = "数据预览";
                    ribbonBar21.Text = "保存数据";
                    this.Real_DataCollection.Image = global::ruishen.Properties.Resources.数据采集_48;
                    runningTask = null;
                    if(myTask!=null){
                        myTask.Dispose();
                    }
                   
                }
                 }
          catch (Exception)
                     {
               
                        this.Real_VibrationMonitor.Enabled = false;
                        this.Real_NoisyMonitor.Enabled = false;
                        this.Real_GlobalMonitoring.Enabled = false;
                        this.Real_DataSave.Enabled = false;
                        DataTempStorage.IsCollectData1 = false;

                        buttonItem3.Enabled = true;
                        buttonItem4.Enabled = true;
                        buttonItem6.Enabled = true;
                        buttonItem2.Enabled = true;

                        //打开后期操作
                        ribbonTabItem4.Enabled = true;
                        ribbonTabItem5.Enabled = true;
                        ribbonTabItem6.Enabled = true;
                        //清空队列数据
                        q1.Clear();
                        q2.Clear();
                        q3.Clear();
                        q4.Clear();
                        q5.Clear();
                        q6.Clear();
                        q7.Clear();
                        q8.Clear();

                        ribbonBar6.Text = "数据预览";
                        this.Real_DataCollection.Image = global::ruishen.Properties.Resources.数据采集_48;
                        runningTask = null;
                        if (myTask != null)
                        {
                            myTask.Dispose();
                        }
                        MessageBox.Show("未连接采集通道!");
                    }
                 }
        public string[] SelectedAxleAndSide() {
            string selectedAxleAndSide = "select WheelAndAxle,WheelSide from diagnosis_ttb_channelparameterset where ChannelNumber=@ChannelNumber";
            string[] MeasuringPoint = new string[setChannelCount];//记录1#左，1#右...
            
            try
            {
                for (int i = 0; i < setChannelCount; i++)
                {
                    ArrayList point = new ArrayList();
                    my = new MysqlHelper();
                    dic1 = new Dictionary<string, object>();
                    dic1.Add("@ChannelNumber", (int)(i + 1));
                    point = my.SelectInfo(selectedAxleAndSide, dic1);
                    foreach (Object[] obj in point)
                    {
                        MeasuringPoint[i] = (string)obj[0] + (string)obj[1];
                    }
                }
            }
            catch (Exception )
            {
                MessageBox.Show("查询失败");
            }
           
            return MeasuringPoint;
        }
        #region //窗函数选择
       

        public double[][] WindowFunctionSelected(double[][] mydata, string WindowFunctionStyle,int n)
        {

            switch (WindowFunctionStyle)
            {
                case "汉宁窗":
                    //Hanning hanning = new Hanning(Wp, Ws);

                    //for (int i = 0; i < mydata.Length; i++)
                    //{
                    //    mydata[i] = firTool.Convolution(mydata[i], hanning.GetWin());
                    //}
                    return mydata;
                case "汉明窗":
                    //Hamming hamming = new Hamming(Wp, Ws);

                    //for (int i = 0; i < mydata.Length; i++)
                    //{
                    //    mydata[i] = firTool.Convolution(mydata[i], hamming.GetWin());
                    //}
                    return mydata;
                case "矩形窗":
                    //Boxcar boxcar = new Boxcar(Wp, Ws);

                    //for (int i = 0; i < mydata.Length; i++)
                    //{
                    //    mydata[i] = firTool.Convolution(mydata[i], boxcar.GetWin());
                    //}
                    return mydata;
                case "布莱克曼窗":
                    double[] blackmanWin = Blackman.getBlackMan(n);
                    System.Threading.Tasks.Parallel.For(0, n, j => mydata[0][j] = mydata[0][j] * blackmanWin[j]);
                    System.Threading.Tasks.Parallel.For(0, n, j => mydata[1][j] = mydata[1][j] * blackmanWin[j]);
                    System.Threading.Tasks.Parallel.For(0, n, j => mydata[2][j] = mydata[2][j] * blackmanWin[j]);
                    System.Threading.Tasks.Parallel.For(0, n, j => mydata[3][j] = mydata[3][j] * blackmanWin[j]);
                    return mydata;
                default: break;
            }
            return mydata;
        }
        #endregion
        double[][] mydata1;
        double[][] mydata2;

        List<double> OneChannnelCharacterOne=new List<double>();//一通道特征值1
        List<double> OneChannnelCharacterTwo=new List<double>();//一通道特征值2
        List<double> TwoChannnelCharacterOne=new List<double>();//二通道特征值1
        List<double> TwoChannnelCharacterTwo=new List<double>();//二通道特征值2
        List<double> ThreeChannnelCharacterOne=new List<double>();//三通道特征值1
        List<double> ThreeChannnelCharacterTwo=new List<double>();//三通道特征值2
        List<double> FourChannnelCharacterOne=new List<double>();//四通道特征值1
        List<double> FourChannnelCharacterTwo=new List<double>();//四通道特征值2
     
        double[,] mydata;//第一维是通道，第二维是数据
        int dataRow= 0 ;
        int dataColumn = 0;
        int displayStatus = 1;
        double dt_vibration = 0;//振动增量
        double dt_noise = 0;//噪音增量
        Queue queue = new Queue();
        double[,] readData;
        int oneCount = 0;
        public void ThreadSave() 
        {
            SaveSingleData1("insert into diagnosis_ttb_originvalue values(@id,@sampletime,@channelone,@channeltwo,@channelthree,@channelfour,@channelfive,@channelsix,@channelseven,@channeleight)", DateTime.Now, Serialization.SerializationObject(mydata1[0]), Serialization.SerializationObject(mydata1[1]), Serialization.SerializationObject(mydata1[2]), Serialization.SerializationObject(mydata1[3]), Serialization.SerializationObject(mydata2[0]), Serialization.SerializationObject(mydata2[1]), Serialization.SerializationObject(mydata2[2]), Serialization.SerializationObject(mydata2[3]));
        }

        #region//线程函数：
        private void AnalogInCallback(IAsyncResult ar)
        {
            try
            {
                if (runningTask != null && runningTask == ar.AsyncState)
                {
                   
                    displayStatus = vibrationMonitor.VibrationDisplayStatus1;
               
                    readData = analogInReader.EndReadMultiSample(ar);
                    mydata = readData;
             
                    dataRow = mydata.GetLength(0);
                    dataColumn = mydata.GetLength(1);
                    //*********************************************************************************************//
                    //前四组振动数据
                    mydata1 = new double[dataRow / 2][];
                    for (int i = 0; i < dataRow / 2; i++)
                    {
                        mydata1[i] = new double[dataColumn];
                        for (int j = 0; j < dataColumn; j++)
                            mydata1[i][j] = mydata[i, j];

                    }
                    //********************************************************************************************//
                    // 后四组声音数据
                    mydata2 = new double[dataRow / 2][];

                    for (int i = 0; i < dataRow / 2; i++)
                    {
                        mydata2[i] = new double[dataColumn];

                        for (int j = 0; j < dataColumn; j++)

                            mydata2[i][j] = mydata[i + setChannelCount/2, j];
                    }

                    if (DataTempStorage.IsSaveData)
                    {
                       
                        ThreadSave();
                    }


                  //  mydata1 = WindowFunctionSelected(mydata1, channelParameterConfig.WindowsFunction1, dataColumn);//加窗
                    switch (vibrationMonitor.VibrationDisplayStatus1)
                    {
                        case 1: dt_vibration = 1 / Convert.ToDouble(channelParameterConfig.SampleRate1); mydata1 = Signal_AcceleratedSpeed(mydata1); VibrationPlot(mydata1[0], mydata1[1], mydata1[2], mydata1[3], 0, dt_vibration,DataTempStorage.SmallFormSelected); break;             //加速度信号
                        case 2: dt_vibration = 1 / Convert.ToDouble(channelParameterConfig.SampleRate1); mydata1 = Signal_Velocity(mydata1, dt_vibration); VibrationPlot(mydata1[0], mydata1[1], mydata1[2], mydata1[3], 0, dt_vibration,DataTempStorage.SmallFormSelected); break;                    //速度信号
                        case 3: dt_vibration = 1 / Convert.ToDouble(channelParameterConfig.SampleRate1); mydata1 = Signal_Displacement(mydata1, dt_vibration); VibrationPlot(mydata1[0], mydata1[1], mydata1[2], mydata1[3], 0, dt_vibration,DataTempStorage.SmallFormSelected); break;                //位移信号
                        case 4: dt_vibration = Convert.ToDouble(channelParameterConfig.SampleRate1) / Convert.ToDouble(channelParameterConfig.SampleNumber1); mydata1 = Signal_FrequencySpectrum(mydata1); VibrationPlot(mydata1[0], mydata1[1], mydata1[2], mydata1[3], 0, dt_vibration,DataTempStorage.SmallFormSelected); break;           //频率信号
                    }
                  
                    //********************************************************************************************//

                    //switch(SoundPlayPointer.PlaySound){
                    //    case 0: ; break;//暂停
                    //    case 1: PlayNoise(mydata2[0], @"..//..//Resources//noise_one.wav"); break;//播放一通道
                    //    case 2: PlayNoise(mydata2[1], @"..//..//Resources//noise_two.wav"); break;//播放二通道
                    //    case 3: PlayNoise(mydata2[2], @"..//..//Resources//noise_three.wav"); break;//播放三通道
                    //    case 4: PlayNoise(mydata2[3], @"..//..//Resources//noise_four.wav"); break;//播放四通道
                    //}
                   
                    switch(SoundPlayPointer.PlaySound)
                    {
                        case 0: ; break;
                        case 1: SaveNoise(mydata2[0], @"..//..//Resources//TempNoise//noise_one" + oneCount + ".wav"); oneCount++; if (oneCount > 3) { PlayNoise(@"..//..//Resources//TempNoise//noise_one"+(oneCount-4)+".wav"); }; break;
                        case 2: SaveNoise(mydata2[1], @"..//..//Resources//TempNoise//noise_two.wav"); PlayNoise(@"..//..//Resources//TempNoise//noise_two.wav"); break;
                        case 3: SaveNoise(mydata2[2], @"..//..//Resources//TempNoise//noise_three.wav"); PlayNoise(@"..//..//Resources//TempNoise//noise_three.wav"); break;
                        case 4: SaveNoise(mydata2[3], @"..//..//Resources//TempNoise//noise_four.wav"); PlayNoise(@"..//..//Resources//TempNoise//noise_four.wav"); break;
                    }
                 //   mydata2 = WindowFunctionSelected(mydata2, channelParameterConfig.WindowsFunction1, dataColumn);//加窗
                    switch (noisyMonitor.NoisyDispalyStatus1)
                    {
                        case 1: dt_noise = 1 / Convert.ToDouble(channelParameterConfig.SampleRate1); Signal_N_Vioce(mydata2, dt_noise); break;                 //声音信号信号
                        case 2: dt_noise = Convert.ToDouble(channelParameterConfig.SampleRate1) / Convert.ToDouble(channelParameterConfig.SampleNumber1); Signal_N_Frequency(mydata2, dt_noise); break;             //频谱信号
                        case 3: dt_noise = Convert.ToDouble(channelParameterConfig.SampleRate1) / Convert.ToDouble(channelParameterConfig.SampleNumber1); Signal_N_Octave(mydata2, dt_noise); break;                //倍频程信号
                        case 4: Signal_N_AWeighting(mydata2); break;            //A计权信号
                    }

                    if (DataTempStorage.AlgorithmList1 != null && DataTempStorage.AlgorithmList1.Count != 0 && isDisplayCharacterValue)
                    {
                
                        CharacterValuePlot(mydata1);
                      
                    }
                   
                    //保存数据
                   
                    //********************************************************************************************//  
                    analogInReader.BeginReadMultiSample(Convert.ToInt32(channelParameterConfig.FrequencyGraph1*2.5), analogCallback, myTask);//重开采集
                }
            }
            catch (DaqException exception)
            {
                // Display Errors
                MessageBox.Show(exception.Message);
                runningTask = null;
                myTask.Dispose();

            }
        }
        Queue<double> q1 = new Queue<double>();
        Queue<double> q2 = new Queue<double>();
        Queue<double> q3 = new Queue<double>();
        Queue<double> q4 = new Queue<double>();
        Queue<double> q5 = new Queue<double>();
        Queue<double> q6 = new Queue<double>();
        Queue<double> q7 = new Queue<double>();
        Queue<double> q8 = new Queue<double>();
        public void CharacterValuePlot(double[][] mydata)
        {
                NoiseCharacterValue.QuickSort(mydata[3], 0, mydata[3].Length - 1);
                NoiseCharacterValue.QuickSort(mydata[2], 0, mydata[2].Length - 1);
                NoiseCharacterValue.QuickSort(mydata[1], 0, mydata[1].Length - 1);
                NoiseCharacterValue.QuickSort(mydata[0], 0, mydata[0].Length - 1);
                if (DataTempStorage.AlgorithmList1.Count == 0)
                {
                    //nothing to do
                }
                #region 只显示一个数据
                else if (DataTempStorage.AlgorithmList1.Count == 1)
                {
                    switch (DataTempStorage.AlgorithmList1[0].ToString())
                    {
                        case "上四分位":
                            double upQuartile1 = NoiseCharacterValue.up_Quartile(mydata[0]);
                            realMonitorCollection.LeftFrontFirstValue.Text = upQuartile1.ToString("f9");
                           // realMonitorCollection.waveformGraph1.PlotYAppend(upQuartile1);
                            double[,] temp_upQuartile1= { { upQuartile1 }, { ThresholdUpDownValue.UpQuartile_Up }, { ThresholdUpDownValue.UpQuartile_Down} };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_upQuartile1,0,1/channelParameterConfig.Resolution1);


                            double upQuartile2 = NoiseCharacterValue.up_Quartile(mydata[1]);
                            realMonitorCollection.RightFrontFirstValue.Text = upQuartile2.ToString("f9");
                         //   realMonitorCollection.waveformGraph3.PlotYAppend(upQuartile2);
                            double[,] temp_upQuartile3 = { { upQuartile2 }, { ThresholdUpDownValue.UpQuartile_Up }, { ThresholdUpDownValue.UpQuartile_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_upQuartile3, 0, 1 / channelParameterConfig.Resolution1);


                            double upQuartile3 = NoiseCharacterValue.up_Quartile(mydata[2]);
                            realMonitorCollection.LeftBehindFirstValue.Text = upQuartile3.ToString("f9");
                          //  realMonitorCollection.waveformGraph5.PlotYAppend(upQuartile3);
                            double[,] temp_upQuartile5 = { { upQuartile3 }, { ThresholdUpDownValue.UpQuartile_Up }, { ThresholdUpDownValue.UpQuartile_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_upQuartile5, 0, 1 / channelParameterConfig.Resolution1);


                            double upQuartile4 = NoiseCharacterValue.up_Quartile(mydata[3]);
                            realMonitorCollection.RightBehindFirstValue.Text = upQuartile4.ToString("f9");
                         //   realMonitorCollection.waveformGraph7.PlotYAppend(upQuartile4);
                            double[,] temp_upQuartile7 = { { upQuartile4 }, { ThresholdUpDownValue.UpQuartile_Up }, { ThresholdUpDownValue.UpQuartile_Down } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_upQuartile7, 0, 1 / channelParameterConfig.Resolution1);


                          
                            if(SaveCharacterValue){
                            OneChannnelCharacterOne.Add(upQuartile1);
                            TwoChannnelCharacterOne.Add(upQuartile2);
                            ThreeChannnelCharacterOne.Add(upQuartile3);
                            FourChannnelCharacterOne.Add(upQuartile4);
                            }
                            
                            break;

                            

                        case "下四分位":
                            double downQuartile1 = NoiseCharacterValue.down_Quartile(mydata[0]);
                            realMonitorCollection.LeftFrontFirstValue.Text = downQuartile1.ToString("f9");
                          //  realMonitorCollection.waveformGraph1.PlotYAppend(downQuartile1);
                            double[,] temp_downQuartile1 = { { downQuartile1 }, { ThresholdUpDownValue.DownQuartile_Up }, { ThresholdUpDownValue.DownQuartile_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_downQuartile1, 0, 1 / channelParameterConfig.Resolution1);

                            double downQuartile2 = NoiseCharacterValue.down_Quartile(mydata[1]);
                            realMonitorCollection.RightFrontFirstValue.Text = downQuartile2.ToString("f9");
                            double[,] temp_downQuartile3 = { { downQuartile2 }, { ThresholdUpDownValue.DownQuartile_Up }, { ThresholdUpDownValue.DownQuartile_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_downQuartile3, 0, 1 / channelParameterConfig.Resolution1);
                         //   realMonitorCollection.waveformGraph3.PlotYAppend(downQuartile2);

                            double downQuartile3 = NoiseCharacterValue.down_Quartile(mydata[2]);
                            realMonitorCollection.LeftBehindFirstValue.Text = downQuartile3.ToString("f9");
                            double[,] temp_downQuartile5 = { { downQuartile3 }, { ThresholdUpDownValue.DownQuartile_Up }, { ThresholdUpDownValue.DownQuartile_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_downQuartile5, 0, 1 / channelParameterConfig.Resolution1);

                            //realMonitorCollection.waveformGraph5.PlotYAppend(downQuartile3);
                            double downQuartile4 = NoiseCharacterValue.down_Quartile(mydata[3]);
                            realMonitorCollection.RightBehindFirstValue.Text = downQuartile4.ToString("f9");
                            double[,] temp_downQuartile7 = { { downQuartile4 }, { ThresholdUpDownValue.DownQuartile_Up }, { ThresholdUpDownValue.DownQuartile_Down } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_downQuartile7, 0, 1 / channelParameterConfig.Resolution1);
                       
                             if(SaveCharacterValue){
                            OneChannnelCharacterOne.Add(downQuartile1);
                            TwoChannnelCharacterOne.Add(downQuartile2);
                            ThreeChannnelCharacterOne.Add(downQuartile3);
                            FourChannnelCharacterOne.Add(downQuartile4);
                             }
                             break;
                        case "中位数":
                            double Median1 = NoiseCharacterValue.Median(mydata[0]);
                            realMonitorCollection.LeftFrontFirstValue.Text = Median1.ToString("f9");
                            double[,] temp_Median1 = { { Median1 }, { ThresholdUpDownValue.Median_Up1 }, { ThresholdUpDownValue.Median_Down1 } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_Median1, 0, 1 / channelParameterConfig.Resolution1);
                           // realMonitorCollection.waveformGraph1.PlotYAppend(Median1);

                            double Median2 = NoiseCharacterValue.Median(mydata[1]);
                            realMonitorCollection.RightFrontFirstValue.Text = Median2.ToString("f9");
                            double[,] temp_Median3 = { { Median2 }, { ThresholdUpDownValue.Median_Up1 }, { ThresholdUpDownValue.Median_Down1 } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_Median3, 0, 1 / channelParameterConfig.Resolution1);
                       //     realMonitorCollection.waveformGraph3.PlotYAppend(Median2);
                            double Median3 = NoiseCharacterValue.Median(mydata[2]);
                            realMonitorCollection.LeftBehindFirstValue.Text = Median3.ToString("f9");
                            double[,] temp_Median5 = { { Median3 }, { ThresholdUpDownValue.Median_Up1 }, { ThresholdUpDownValue.Median_Down1 } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_Median5, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph5.PlotYAppend(Median3);
                            double Median4 = NoiseCharacterValue.Median(mydata[3]);
                            realMonitorCollection.RightBehindFirstValue.Text = Median4.ToString("f9");
                            double[,] temp_Median7 = { { Median4 }, { ThresholdUpDownValue.Median_Up1 }, { ThresholdUpDownValue.Median_Down1 } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_Median7, 0, 1 / channelParameterConfig.Resolution1);
                        
                             if(SaveCharacterValue){
                            OneChannnelCharacterOne.Add(Median1);
                            TwoChannnelCharacterOne.Add(Median2);
                            ThreeChannnelCharacterOne.Add(Median3);
                            FourChannnelCharacterOne.Add(Median4);
                             }
                            break;
                        case "四分位距":
                            double distanceQuartile1 = NoiseCharacterValue.distance_Quartile(mydata[0]);
                            realMonitorCollection.LeftFrontFirstValue.Text = distanceQuartile1.ToString("f9");
                            double[,] temp_distanceQuartile1 = { { distanceQuartile1 }, { ThresholdUpDownValue.DistanceQuartile_Up }, { ThresholdUpDownValue.DistanceQuartile_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_distanceQuartile1, 0, 1 / channelParameterConfig.Resolution1);
                           // realMonitorCollection.waveformGraph1.PlotYAppend(distanceQuartile1);
                            double distanceQuartile2 = NoiseCharacterValue.distance_Quartile(mydata[1]);
                            realMonitorCollection.RightFrontFirstValue.Text = distanceQuartile2.ToString("f9");
                             double[,] temp_distanceQuartile3 = { { distanceQuartile2 }, { ThresholdUpDownValue.DistanceQuartile_Up }, { ThresholdUpDownValue.DistanceQuartile_Down } };
                             realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_distanceQuartile3, 0, 1 / channelParameterConfig.Resolution1);
                            //realMonitorCollection.waveformGraph3.PlotYAppend(distanceQuartile2);
                            double distanceQuartile3 = NoiseCharacterValue.distance_Quartile(mydata[2]);
                            realMonitorCollection.LeftBehindFirstValue.Text = distanceQuartile3.ToString("f9");
                             double[,] temp_distanceQuartile5 = { { distanceQuartile3 }, { ThresholdUpDownValue.DistanceQuartile_Up }, { ThresholdUpDownValue.DistanceQuartile_Down } };
                             realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_distanceQuartile5, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph5.PlotYAppend(distanceQuartile3);
                            double distanceQuartile4 = NoiseCharacterValue.distance_Quartile(mydata[3]);
                            realMonitorCollection.RightBehindFirstValue.Text = distanceQuartile4.ToString("f9");
                             double[,] temp_distanceQuartile7 = { { distanceQuartile4 }, { ThresholdUpDownValue.DistanceQuartile_Up }, { ThresholdUpDownValue.DistanceQuartile_Down } };
                             realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_distanceQuartile7, 0, 1 / channelParameterConfig.Resolution1);
                        
                             if(SaveCharacterValue)
                             {
                            OneChannnelCharacterOne.Add(distanceQuartile1);
                            TwoChannnelCharacterOne.Add(distanceQuartile2);
                            ThreeChannnelCharacterOne.Add(distanceQuartile3);
                            FourChannnelCharacterOne.Add(distanceQuartile4);
                             }
                             break;
                        case "上界":
                            double upperbound1 = NoiseCharacterValue.upper_bound(mydata[0]);
                            realMonitorCollection.LeftFrontFirstValue.Text = upperbound1.ToString("f9");
                            double[,] temp_upperbound1 = { { upperbound1 }, { ThresholdUpDownValue.Upperbound_Up }, { ThresholdUpDownValue.Upperbound_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_upperbound1, 0, 1 / channelParameterConfig.Resolution1);
                           // realMonitorCollection.waveformGraph1.PlotYAppend(upperbound1);

                            double upperbound2 = NoiseCharacterValue.upper_bound(mydata[1]);
                            realMonitorCollection.RightFrontFirstValue.Text = upperbound2.ToString("f9");
                            double[,] temp_upperbound3 = { { upperbound2 }, { ThresholdUpDownValue.Upperbound_Up }, { ThresholdUpDownValue.Upperbound_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_upperbound3, 0, 1 / channelParameterConfig.Resolution1);
                         //   realMonitorCollection.waveformGraph3.PlotYAppend(upperbound2);

                            double upperbound3 = NoiseCharacterValue.upper_bound(mydata[2]);
                            realMonitorCollection.LeftBehindFirstValue.Text = upperbound3.ToString("f9");
                            double[,] temp_upperbound5 = { { upperbound3 }, { ThresholdUpDownValue.Upperbound_Up }, { ThresholdUpDownValue.Upperbound_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_upperbound5, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph5.PlotYAppend(upperbound3);
                            double upperbound4 = NoiseCharacterValue.upper_bound(mydata[3]);
                            realMonitorCollection.RightBehindFirstValue.Text = upperbound4.ToString("f9");
                            double[,] temp_upperbound7 = { { upperbound4 }, { ThresholdUpDownValue.Upperbound_Up }, { ThresholdUpDownValue.Upperbound_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_upperbound7, 0, 1 / channelParameterConfig.Resolution1);
                           
                             if(SaveCharacterValue)
                             {
                            OneChannnelCharacterOne.Add(upperbound1);
                            TwoChannnelCharacterOne.Add(upperbound2);
                            ThreeChannnelCharacterOne.Add(upperbound3);
                            FourChannnelCharacterOne.Add(upperbound4);
                             }
                             break;
                        case "下界":
                            double downbound1 = NoiseCharacterValue.upper_bound(mydata[0]);
                            realMonitorCollection.LeftFrontFirstValue.Text = downbound1.ToString("f9");
                            double[,] temp_downbound1 = { { downbound1 }, { ThresholdUpDownValue.Downbound_Up }, { ThresholdUpDownValue.Downbound_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_downbound1, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph1.PlotYAppend(downbound1);
                            double downbound2 = NoiseCharacterValue.upper_bound(mydata[1]);
                            realMonitorCollection.RightFrontFirstValue.Text = downbound2.ToString("f9");
                            double[,] temp_downbound3 = { { downbound2 }, { ThresholdUpDownValue.Downbound_Up }, { ThresholdUpDownValue.Downbound_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_downbound3, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph3.PlotYAppend(downbound2);
                            double downbound3 = NoiseCharacterValue.upper_bound(mydata[2]);
                            realMonitorCollection.LeftBehindFirstValue.Text = downbound3.ToString("f9");
                            double[,] temp_downbound5 = { { downbound3 }, { ThresholdUpDownValue.Downbound_Up }, { ThresholdUpDownValue.Downbound_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_downbound5, 0, 1 / channelParameterConfig.Resolution1);
                           // realMonitorCollection.waveformGraph5.PlotYAppend(downbound3);
                            double downbound4 = NoiseCharacterValue.upper_bound(mydata[3]);
                            realMonitorCollection.RightBehindFirstValue.Text = downbound4.ToString("f9");
                            double[,] temp_downbound7 = { { downbound4 }, { ThresholdUpDownValue.Downbound_Up }, { ThresholdUpDownValue.Downbound_Down } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_downbound7, 0, 1 / channelParameterConfig.Resolution1);
                        
                             if(SaveCharacterValue){
                            OneChannnelCharacterOne.Add(downbound1);
                            TwoChannnelCharacterOne.Add(downbound2);
                            ThreeChannnelCharacterOne.Add(downbound3);
                            FourChannnelCharacterOne.Add(downbound4);
                             }
                             break;
                        case "均值":
                            double average1 = VibrationAlgorithm.CalculateParasQuShi(mydata[0])[0];
                            realMonitorCollection.LeftFrontFirstValue.Text = average1.ToString("f9");
                            double[,] temp_average1 = { { average1 }, { ThresholdUpDownValue.Average_Up }, { ThresholdUpDownValue.Average_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_average1, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph1.PlotYAppend(average1);
                            double average2 = VibrationAlgorithm.CalculateParasQuShi(mydata[1])[0];
                            realMonitorCollection.RightFrontFirstValue.Text = average2.ToString("f9");
                             double[,] temp_average3 = { { average2 }, { ThresholdUpDownValue.Average_Up }, { ThresholdUpDownValue.Average_Down } };
                             realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_average3, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph3.PlotYAppend(average2);
                            double average3 = VibrationAlgorithm.CalculateParasQuShi(mydata[2])[0];
                            realMonitorCollection.LeftBehindFirstValue.Text = average3.ToString("f9");
                             double[,] temp_average5 = { { average3 }, { ThresholdUpDownValue.Average_Up }, { ThresholdUpDownValue.Average_Down } };
                             realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_average5, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph5.PlotYAppend(average3);
                            double average4 = VibrationAlgorithm.CalculateParasQuShi(mydata[3])[0];
                            realMonitorCollection.RightBehindFirstValue.Text = average4.ToString("f9");
                             double[,] temp_average7 = { { average4 }, { ThresholdUpDownValue.Average_Up }, { ThresholdUpDownValue.Average_Down } };
                             realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_average7, 0, 1 / channelParameterConfig.Resolution1);
                         
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(average1);
                                TwoChannnelCharacterOne.Add(average2);
                                ThreeChannnelCharacterOne.Add(average3);
                                FourChannnelCharacterOne.Add(average4);
                            }
                            break;
                        case "方差":
                            double variance1 = VibrationAlgorithm.CalculateParasQuShi(mydata[0])[7];
                            realMonitorCollection.LeftFrontFirstValue.Text = variance1.ToString("f9");
                            double[,] temp_variance1 = { { variance1 }, { ThresholdUpDownValue.Variance_Up }, { ThresholdUpDownValue.Variance_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_variance1, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph1.PlotYAppend(variance1);
                            double variance2 = VibrationAlgorithm.CalculateParasQuShi(mydata[1])[7];
                            realMonitorCollection.RightFrontFirstValue.Text = variance2.ToString("f9");
                             double[,] temp_variance3 = { { variance2 }, { ThresholdUpDownValue.Variance_Up }, { ThresholdUpDownValue.Variance_Down } };
                             realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_variance3, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph3.PlotYAppend(variance2);
                            double variance3 = VibrationAlgorithm.CalculateParasQuShi(mydata[2])[7];
                            realMonitorCollection.LeftBehindFirstValue.Text = variance3.ToString("f9");
                             double[,] temp_variance5 = { { variance3 }, { ThresholdUpDownValue.Variance_Up }, { ThresholdUpDownValue.Variance_Down } };
                             realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_variance5, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph5.PlotYAppend(variance3);
                            double variance4 = VibrationAlgorithm.CalculateParasQuShi(mydata[3])[7];
                            realMonitorCollection.RightBehindFirstValue.Text = variance4.ToString("f9");
                             double[,] temp_variance7 = { { variance4 }, { ThresholdUpDownValue.Variance_Up }, { ThresholdUpDownValue.Variance_Down } };
                             realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_variance7, 0, 1 / channelParameterConfig.Resolution1);
                          
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(variance1);
                                TwoChannnelCharacterOne.Add(variance2);
                                ThreeChannnelCharacterOne.Add(variance3);
                                FourChannnelCharacterOne.Add(variance4);
                            }
                            break;
                        case "均方根值":
                            double RMS_Value1 = VibrationAlgorithm.CalculateParasQuShi(mydata[0])[1];
                            q1.Enqueue(RMS_Value1);
                            double[] array1;
                            if(q1.Count>12){
                                q1.Dequeue();
                                array1 = q1.ToArray();
                                NoiseCharacterValue.QuickSort(array1,0,array1.Length-1);
                                RMS_Value1 = (array1[3] + array1[4]) / 2;
                                realMonitorCollection.LeftFrontFirstValue.Text = RMS_Value1.ToString("f9");
                                double[,] temp_RMS_Value1 = { { RMS_Value1 }, { ThresholdUpDownValue.RMS_Value_Up1 }, { ThresholdUpDownValue.RMS_Value_Down1 } };
                                realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_RMS_Value1, 0, 1 / channelParameterConfig.Resolution1);
                            }
                           
                            
                           // realMonitorCollection.waveformGraph1.PlotYAppend(RMS_Value1);
                            double RMS_Value2 = VibrationAlgorithm.CalculateParasQuShi(mydata[1])[1];
                            q2.Enqueue(RMS_Value2);
                            double[] array2;
                            if(q2.Count>12)
                            {
                                q2.Dequeue();
                                array2 = q2.ToArray();
                                NoiseCharacterValue.QuickSort(array2, 0, array2.Length - 1);
                                RMS_Value2 = (array2[3] + array2[4]) / 2;
                                realMonitorCollection.RightFrontFirstValue.Text = RMS_Value2.ToString("f9");
                                double[,] temp_RMS_Value3 = { { RMS_Value2 }, { ThresholdUpDownValue.RMS_Value_Up1 }, { ThresholdUpDownValue.RMS_Value_Down1 } };
                                realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_RMS_Value3, 0, 1 / channelParameterConfig.Resolution1);
                            }
                            
                           // realMonitorCollection.waveformGraph3.PlotYAppend(RMS_Value2);
                            double RMS_Value3 = VibrationAlgorithm.CalculateParasQuShi(mydata[2])[1];
                            q3.Enqueue(RMS_Value3);
                            double[] array3;
                            if(q3.Count>12)
                            {
                                q3.Dequeue();
                                array3 = q3.ToArray();
                                NoiseCharacterValue.QuickSort(array3, 0, array3.Length - 1);
                                RMS_Value3 = (array3[3] + array3[4]) / 2;
                                realMonitorCollection.LeftBehindFirstValue.Text = RMS_Value3.ToString("f9");
                                double[,] temp_RMS_Value5 = { { RMS_Value3 }, { ThresholdUpDownValue.RMS_Value_Up1 }, { ThresholdUpDownValue.RMS_Value_Down1 } };
                                realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_RMS_Value5, 0, 1 / channelParameterConfig.Resolution1);
                            }
                            
                          //  realMonitorCollection.waveformGraph5.PlotYAppend(RMS_Value3);
                            double RMS_Value4 = VibrationAlgorithm.CalculateParasQuShi(mydata[3])[1];
                            q4.Enqueue(RMS_Value4);
                            double[] array4;
                            if(q4.Count>12)
                            {
                                q4.Dequeue();
                                array4 = q4.ToArray();
                                NoiseCharacterValue.QuickSort(array4, 0, array4.Length - 1);
                                RMS_Value4 = (array4[3] + array4[4]) / 2;
                                realMonitorCollection.RightBehindFirstValue.Text = RMS_Value4.ToString("f9");
                                double[,] temp_RMS_Value7 = { { RMS_Value4 }, { ThresholdUpDownValue.RMS_Value_Up1 }, { ThresholdUpDownValue.RMS_Value_Down1 } };
                                realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_RMS_Value7, 0, 1 / channelParameterConfig.Resolution1);
                            }
                            
                      
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(RMS_Value1);
                                TwoChannnelCharacterOne.Add(RMS_Value2);
                                ThreeChannnelCharacterOne.Add(RMS_Value3);
                                FourChannnelCharacterOne.Add(RMS_Value4);
                            }
                            break;

                        case "歪度":
                            double skewness1 = VibrationAlgorithm.CalculateParasQuShi(mydata[0])[5];
                            realMonitorCollection.LeftFrontFirstValue.Text = skewness1.ToString("f9");
                            double[,] temp_skewness1 = { { skewness1 }, { ThresholdUpDownValue.Skewness_Up }, { ThresholdUpDownValue.Skewness_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_skewness1, 0, 1 / channelParameterConfig.Resolution1);
                           // realMonitorCollection.waveformGraph1.PlotYAppend(skewness1);
                            double skewness2 = VibrationAlgorithm.CalculateParasQuShi(mydata[1])[5];
                            realMonitorCollection.RightFrontFirstValue.Text = skewness2.ToString("f9");
                            double[,] temp_skewness3 = { { skewness2 }, { ThresholdUpDownValue.Skewness_Up }, { ThresholdUpDownValue.Skewness_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_skewness3, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph3.PlotYAppend(skewness2);
                            double skewness3 = VibrationAlgorithm.CalculateParasQuShi(mydata[2])[5];
                            realMonitorCollection.LeftBehindFirstValue.Text = skewness3.ToString("f9");
                            double[,] temp_skewness5 = { { skewness3 }, { ThresholdUpDownValue.Skewness_Up }, { ThresholdUpDownValue.Skewness_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_skewness5, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph5.PlotYAppend(skewness3);
                            double skewness4 = VibrationAlgorithm.CalculateParasQuShi(mydata[3])[5];
                            realMonitorCollection.RightBehindFirstValue.Text = skewness4.ToString("f9");
                            double[,] temp_skewness7 = { { skewness4 }, { ThresholdUpDownValue.Skewness_Up }, { ThresholdUpDownValue.Skewness_Down } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_skewness7, 0, 1 / channelParameterConfig.Resolution1);
                         
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(skewness1);
                                TwoChannnelCharacterOne.Add(skewness2);
                                ThreeChannnelCharacterOne.Add(skewness3);
                                FourChannnelCharacterOne.Add(skewness4);
                            }
                            break;

                        case "峭度":
                            double kurtosis1 = VibrationAlgorithm.CalculateParasQuShi(mydata[0])[6];
                            realMonitorCollection.LeftFrontFirstValue.Text = kurtosis1.ToString("f9");
                            double[,] temp_kurtosis1 = { { kurtosis1 }, { ThresholdUpDownValue.Kurtosis_Up }, { ThresholdUpDownValue.Kurtosis_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_kurtosis1, 0, 1 / channelParameterConfig.Resolution1);
                           // realMonitorCollection.waveformGraph1.PlotYAppend(kurtosis1);
                            double kurtosis2 = VibrationAlgorithm.CalculateParasQuShi(mydata[1])[6];
                            realMonitorCollection.RightFrontFirstValue.Text = kurtosis2.ToString("f9");
                             double[,] temp_kurtosis3 = { { kurtosis2 }, { ThresholdUpDownValue.Kurtosis_Up }, { ThresholdUpDownValue.Kurtosis_Down } };
                             realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_kurtosis3, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph3.PlotYAppend(kurtosis2);
                            double kurtosis3 = VibrationAlgorithm.CalculateParasQuShi(mydata[2])[6];
                            realMonitorCollection.LeftBehindFirstValue.Text = kurtosis3.ToString("f9");
                             double[,] temp_kurtosis5 = { { kurtosis3 }, { ThresholdUpDownValue.Kurtosis_Up }, { ThresholdUpDownValue.Kurtosis_Down } };
                             realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_kurtosis5, 0, 1 / channelParameterConfig.Resolution1);
                         //   realMonitorCollection.waveformGraph5.PlotYAppend(kurtosis3);
                            double kurtosis4 = VibrationAlgorithm.CalculateParasQuShi(mydata[3])[6];
                            realMonitorCollection.RightBehindFirstValue.Text = kurtosis4.ToString("f9");
                             double[,] temp_kurtosis7 = { { kurtosis4 }, { ThresholdUpDownValue.Kurtosis_Up }, { ThresholdUpDownValue.Kurtosis_Down } };
                             realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_kurtosis7, 0, 1 / channelParameterConfig.Resolution1);
                         
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(kurtosis1);
                                TwoChannnelCharacterOne.Add(kurtosis2);
                                ThreeChannnelCharacterOne.Add(kurtosis3);
                                FourChannnelCharacterOne.Add(kurtosis4);
                            }
                            break;

                        case "峰度":
                            double peak1 = VibrationAlgorithm.CalculateParasQuShi(mydata[0])[3];
                            realMonitorCollection.LeftFrontFirstValue.Text = peak1.ToString("f9");
                            double[,] temp_peak1 = { { peak1 }, { ThresholdUpDownValue.Peak_Up }, { ThresholdUpDownValue.Peak_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_peak1, 0, 1 / channelParameterConfig.Resolution1);
                         //   realMonitorCollection.waveformGraph1.PlotYAppend(peak1);
                            double peak2 = VibrationAlgorithm.CalculateParasQuShi(mydata[1])[3];
                            realMonitorCollection.RightFrontFirstValue.Text = peak2.ToString("f9");
                            double[,] temp_peak3 = { { peak2 }, { ThresholdUpDownValue.Peak_Up }, { ThresholdUpDownValue.Peak_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_peak3, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph3.PlotYAppend(peak2);
                            double peak3 = VibrationAlgorithm.CalculateParasQuShi(mydata[2])[3];
                            realMonitorCollection.LeftBehindFirstValue.Text = peak3.ToString("f9");
                            double[,] temp_peak5 = { { peak3 }, { ThresholdUpDownValue.Peak_Up }, { ThresholdUpDownValue.Peak_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_peak5, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph5.PlotYAppend(peak3);
                            double peak4 = VibrationAlgorithm.CalculateParasQuShi(mydata[3])[3];
                            realMonitorCollection.RightBehindFirstValue.Text = peak4.ToString("f9");
                            double[,] temp_peak7 = { { peak4 }, { ThresholdUpDownValue.Peak_Up }, { ThresholdUpDownValue.Peak_Down } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_peak7, 0, 1 / channelParameterConfig.Resolution1);
                        
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(peak1);
                                TwoChannnelCharacterOne.Add(peak2);
                                ThreeChannnelCharacterOne.Add(peak3);
                                FourChannnelCharacterOne.Add(peak4);
                            }
                            break;

                        case "峰值频率":
                            double frequency1 = NoiseCharacterValue.PeakFrequency(mydata[0], channelParameterConfig.SampleRate1);
                            realMonitorCollection.LeftFrontFirstValue.Text = frequency1.ToString("f9");
                            double[,] temp_frequency1 = { { frequency1 }, { ThresholdUpDownValue.Frequency_Up }, { ThresholdUpDownValue.Frequency_Down} };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_frequency1, 0, 1 / channelParameterConfig.Resolution1);
                           // realMonitorCollection.waveformGraph1.PlotYAppend(frequency1);
                            double frequency2 = NoiseCharacterValue.PeakFrequency(mydata[1], channelParameterConfig.SampleRate1);
                            realMonitorCollection.RightFrontFirstValue.Text = frequency2.ToString("f9");
                            double[,] temp_frequency3 = { { frequency2 }, { ThresholdUpDownValue.Frequency_Up }, { ThresholdUpDownValue.Frequency_Down} };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_frequency3, 0, 1 / channelParameterConfig.Resolution1);
                           // realMonitorCollection.waveformGraph3.PlotYAppend(frequency2);
                            double frequency3 = NoiseCharacterValue.PeakFrequency(mydata[2], channelParameterConfig.SampleRate1);
                            realMonitorCollection.LeftBehindFirstValue.Text = frequency3.ToString("f9");
                            double[,] temp_frequency5 = { { frequency3 }, { ThresholdUpDownValue.Frequency_Up }, { ThresholdUpDownValue.Frequency_Down} };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_frequency5, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph5.PlotYAppend(frequency3);
                            double frequency4 = NoiseCharacterValue.PeakFrequency(mydata[3], channelParameterConfig.SampleRate1);
                            realMonitorCollection.RightBehindFirstValue.Text = frequency4.ToString("f9");
                            double[,] temp_frequency7 = { { frequency4 }, { ThresholdUpDownValue.Frequency_Up }, { ThresholdUpDownValue.Frequency_Down} };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_frequency7, 0, 1 / channelParameterConfig.Resolution1);
                         
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(frequency1);
                                TwoChannnelCharacterOne.Add(frequency2);
                                ThreeChannnelCharacterOne.Add(frequency3);
                                FourChannnelCharacterOne.Add(frequency4);
                            }
                            break;

                        case "频率幅值":
                            Signal_FrequencySpectrum(mydata);
                            double frequencyA1 = FrequencyA[0];
                            realMonitorCollection.LeftFrontFirstValue.Text = frequencyA1.ToString("f9");
                            double[,] temp_frequencyA1 = { { frequencyA1 }, { ThresholdUpDownValue.FrequencyA_Up }, { ThresholdUpDownValue.FrequencyA_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_frequencyA1, 0, 1 / channelParameterConfig.Resolution1);
                        //    realMonitorCollection.waveformGraph1.PlotYAppend(frequencyA1);
                            double frequencyA2 = FrequencyA[1];
                            realMonitorCollection.RightFrontFirstValue.Text = frequencyA2.ToString("f9");
                            double[,] temp_frequencyA3 = { { frequencyA2 }, { ThresholdUpDownValue.FrequencyA_Up }, { ThresholdUpDownValue.FrequencyA_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_frequencyA3, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph3.PlotYAppend(frequencyA2);
                            double frequencyA3 = FrequencyA[2];
                            realMonitorCollection.LeftBehindFirstValue.Text = frequencyA3.ToString("f9");
                            double[,] temp_frequencyA5 = { { frequencyA3 }, { ThresholdUpDownValue.FrequencyA_Up }, { ThresholdUpDownValue.FrequencyA_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_frequencyA5, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph5.PlotYAppend(frequencyA3);
                            double frequencyA4 = FrequencyA[3];
                            realMonitorCollection.RightBehindFirstValue.Text = frequencyA4.ToString("f9");
                            double[,] temp_frequencyA7 = { { frequencyA4 }, { ThresholdUpDownValue.FrequencyA_Up }, { ThresholdUpDownValue.FrequencyA_Down } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_frequencyA7, 0, 1 / channelParameterConfig.Resolution1);
                          
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(frequencyA1);
                                TwoChannnelCharacterOne.Add(frequencyA2);
                                ThreeChannnelCharacterOne.Add(frequencyA3);
                                FourChannnelCharacterOne.Add(frequencyA4);
                            }
                            break;

                        case "中心频率":
                            double octaveValue1 = VoiceOctave.octave(mydata[0], Convert.ToDouble(channelParameterConfig.SampleRate1), DataTempStorage.CenterFrequency1);
                            realMonitorCollection.LeftFrontFirstValue.Text = octaveValue1.ToString("f9");
                            double[,] temp_octaveValue1 = { { octaveValue1 }, { ThresholdUpDownValue.OctaveValue_Up }, { ThresholdUpDownValue.OctaveValue_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_octaveValue1, 0, 1 / channelParameterConfig.Resolution1);
                           // realMonitorCollection.waveformGraph1.PlotYAppend(octaveValue1);
                            double octaveValue2 = VoiceOctave.octave(mydata[1], Convert.ToDouble(channelParameterConfig.SampleRate1), DataTempStorage.CenterFrequency1);
                            realMonitorCollection.LeftFrontFirstValue.Text = octaveValue2.ToString("f9");
                            double[,] temp_octaveValue3 = { { octaveValue2 }, { ThresholdUpDownValue.OctaveValue_Up }, { ThresholdUpDownValue.OctaveValue_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_octaveValue3, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph3.PlotYAppend(octaveValue2);
                            double octaveValue3 = VoiceOctave.octave(mydata[2], Convert.ToDouble(channelParameterConfig.SampleRate1), DataTempStorage.CenterFrequency1);
                            realMonitorCollection.LeftFrontFirstValue.Text = octaveValue3.ToString("f9");
                            double[,] temp_octaveValue5 = { { octaveValue3 }, { ThresholdUpDownValue.OctaveValue_Up }, { ThresholdUpDownValue.OctaveValue_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_octaveValue5, 0, 1 / channelParameterConfig.Resolution1);
                         //   realMonitorCollection.waveformGraph5.PlotYAppend(octaveValue3);
                            double octaveValue4 = VoiceOctave.octave(mydata[3], Convert.ToDouble(channelParameterConfig.SampleRate1), DataTempStorage.CenterFrequency1);
                            realMonitorCollection.LeftFrontFirstValue.Text = octaveValue4.ToString("f9");
                            double[,] temp_octaveValue7 = { { octaveValue4 }, { ThresholdUpDownValue.OctaveValue_Up }, { ThresholdUpDownValue.OctaveValue_Down } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_octaveValue7, 0, 1 / channelParameterConfig.Resolution1);
                        
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(octaveValue1);
                                TwoChannnelCharacterOne.Add(octaveValue2);
                                ThreeChannnelCharacterOne.Add(octaveValue3);
                                FourChannnelCharacterOne.Add(octaveValue4);
                            }
                            break;
                    }
                }
                #endregion
                #region 显示两个数据
                else if (DataTempStorage.AlgorithmList1.Count == 2)
                {
                    switch (DataTempStorage.AlgorithmList1[0].ToString())
                    {
                        case "上四分位":
                            double upQuartile1 = NoiseCharacterValue.up_Quartile(mydata[0]);
                            realMonitorCollection.LeftFrontFirstValue.Text = upQuartile1.ToString("f9");
                            // realMonitorCollection.waveformGraph1.PlotYAppend(upQuartile1);
                            double[,] temp_upQuartile1 = { { upQuartile1 }, { ThresholdUpDownValue.UpQuartile_Up }, { ThresholdUpDownValue.UpQuartile_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_upQuartile1, 0, 1 / channelParameterConfig.Resolution1);


                            double upQuartile2 = NoiseCharacterValue.up_Quartile(mydata[1]);
                            realMonitorCollection.RightFrontFirstValue.Text = upQuartile2.ToString("f9");
                            //   realMonitorCollection.waveformGraph3.PlotYAppend(upQuartile2);
                            double[,] temp_upQuartile3 = { { upQuartile2 }, { ThresholdUpDownValue.UpQuartile_Up }, { ThresholdUpDownValue.UpQuartile_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_upQuartile3, 0, 1 / channelParameterConfig.Resolution1);


                            double upQuartile3 = NoiseCharacterValue.up_Quartile(mydata[2]);
                            realMonitorCollection.LeftBehindFirstValue.Text = upQuartile3.ToString("f9");
                            //  realMonitorCollection.waveformGraph5.PlotYAppend(upQuartile3);
                            double[,] temp_upQuartile5 = { { upQuartile3 }, { ThresholdUpDownValue.UpQuartile_Up }, { ThresholdUpDownValue.UpQuartile_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_upQuartile5, 0, 1 / channelParameterConfig.Resolution1);


                            double upQuartile4 = NoiseCharacterValue.up_Quartile(mydata[3]);
                            realMonitorCollection.RightBehindFirstValue.Text = upQuartile4.ToString("f9");
                            //   realMonitorCollection.waveformGraph7.PlotYAppend(upQuartile4);
                            double[,] temp_upQuartile7 = { { upQuartile4 }, { ThresholdUpDownValue.UpQuartile_Up }, { ThresholdUpDownValue.UpQuartile_Down } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_upQuartile7, 0, 1 / channelParameterConfig.Resolution1);


                            
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(upQuartile1);
                                TwoChannnelCharacterOne.Add(upQuartile2);
                                ThreeChannnelCharacterOne.Add(upQuartile3);
                                FourChannnelCharacterOne.Add(upQuartile4);
                            }

                            break;



                        case "下四分位":
                            double downQuartile1 = NoiseCharacterValue.down_Quartile(mydata[0]);
                            realMonitorCollection.LeftFrontFirstValue.Text = downQuartile1.ToString("f9");
                            //  realMonitorCollection.waveformGraph1.PlotYAppend(downQuartile1);
                            double[,] temp_downQuartile1 = { { downQuartile1 }, { ThresholdUpDownValue.DownQuartile_Up }, { ThresholdUpDownValue.DownQuartile_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_downQuartile1, 0, 1 / channelParameterConfig.Resolution1);

                            double downQuartile2 = NoiseCharacterValue.down_Quartile(mydata[1]);
                            realMonitorCollection.RightFrontFirstValue.Text = downQuartile2.ToString("f9");
                            double[,] temp_downQuartile3 = { { downQuartile2 }, { ThresholdUpDownValue.DownQuartile_Up }, { ThresholdUpDownValue.DownQuartile_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_downQuartile3, 0, 1 / channelParameterConfig.Resolution1);
                            //   realMonitorCollection.waveformGraph3.PlotYAppend(downQuartile2);

                            double downQuartile3 = NoiseCharacterValue.down_Quartile(mydata[2]);
                            realMonitorCollection.LeftBehindFirstValue.Text = downQuartile3.ToString("f9");
                            double[,] temp_downQuartile5 = { { downQuartile3 }, { ThresholdUpDownValue.DownQuartile_Up }, { ThresholdUpDownValue.DownQuartile_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_downQuartile5, 0, 1 / channelParameterConfig.Resolution1);

                            //realMonitorCollection.waveformGraph5.PlotYAppend(downQuartile3);
                            double downQuartile4 = NoiseCharacterValue.down_Quartile(mydata[3]);
                            realMonitorCollection.RightBehindFirstValue.Text = downQuartile4.ToString("f9");
                            double[,] temp_downQuartile7 = { { downQuartile4 }, { ThresholdUpDownValue.DownQuartile_Up }, { ThresholdUpDownValue.DownQuartile_Down } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_downQuartile7, 0, 1 / channelParameterConfig.Resolution1);
                            
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(downQuartile1);
                                TwoChannnelCharacterOne.Add(downQuartile2);
                                ThreeChannnelCharacterOne.Add(downQuartile3);
                                FourChannnelCharacterOne.Add(downQuartile4);
                            }
                            break;
                        case "中位数":
                            double Median1 = NoiseCharacterValue.Median(mydata[0]);
                            realMonitorCollection.LeftFrontFirstValue.Text = Median1.ToString("f9");
                            double[,] temp_Median1 = { { Median1 }, { ThresholdUpDownValue.Median_Up1 }, { ThresholdUpDownValue.Median_Down1 } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_Median1, 0, 1 / channelParameterConfig.Resolution1);
                            // realMonitorCollection.waveformGraph1.PlotYAppend(Median1);

                            double Median2 = NoiseCharacterValue.Median(mydata[1]);
                            realMonitorCollection.RightFrontFirstValue.Text = Median2.ToString("f9");
                            double[,] temp_Median3 = { { Median2 }, { ThresholdUpDownValue.Median_Up1 }, { ThresholdUpDownValue.Median_Down1 } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_Median3, 0, 1 / channelParameterConfig.Resolution1);
                            //     realMonitorCollection.waveformGraph3.PlotYAppend(Median2);
                            double Median3 = NoiseCharacterValue.Median(mydata[2]);
                            realMonitorCollection.LeftBehindFirstValue.Text = Median3.ToString("f9");
                            double[,] temp_Median5 = { { Median3 }, { ThresholdUpDownValue.Median_Up1 }, { ThresholdUpDownValue.Median_Down1 } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_Median5, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph5.PlotYAppend(Median3);
                            double Median4 = NoiseCharacterValue.Median(mydata[3]);
                            realMonitorCollection.RightBehindFirstValue.Text = Median4.ToString("f9");
                            double[,] temp_Median7 = { { Median4 }, { ThresholdUpDownValue.Median_Up1 }, { ThresholdUpDownValue.Median_Down1 } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_Median7, 0, 1 / channelParameterConfig.Resolution1);
                           

                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(Median1);
                                TwoChannnelCharacterOne.Add(Median2);
                                ThreeChannnelCharacterOne.Add(Median3);
                                FourChannnelCharacterOne.Add(Median4);
                            }
                            break;
                        case "四分位距":
                            double distanceQuartile1 = NoiseCharacterValue.distance_Quartile(mydata[0]);
                            realMonitorCollection.LeftFrontFirstValue.Text = distanceQuartile1.ToString("f9");
                            double[,] temp_distanceQuartile1 = { { distanceQuartile1 }, { ThresholdUpDownValue.DistanceQuartile_Up }, { ThresholdUpDownValue.DistanceQuartile_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_distanceQuartile1, 0, 1 / channelParameterConfig.Resolution1);
                            // realMonitorCollection.waveformGraph1.PlotYAppend(distanceQuartile1);
                            double distanceQuartile2 = NoiseCharacterValue.distance_Quartile(mydata[1]);
                            realMonitorCollection.RightFrontFirstValue.Text = distanceQuartile2.ToString("f9");
                            double[,] temp_distanceQuartile3 = { { distanceQuartile2 }, { ThresholdUpDownValue.DistanceQuartile_Up }, { ThresholdUpDownValue.DistanceQuartile_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_distanceQuartile3, 0, 1 / channelParameterConfig.Resolution1);
                            //realMonitorCollection.waveformGraph3.PlotYAppend(distanceQuartile2);
                            double distanceQuartile3 = NoiseCharacterValue.distance_Quartile(mydata[2]);
                            realMonitorCollection.LeftBehindFirstValue.Text = distanceQuartile3.ToString("f9");
                            double[,] temp_distanceQuartile5 = { { distanceQuartile3 }, { ThresholdUpDownValue.DistanceQuartile_Up }, { ThresholdUpDownValue.DistanceQuartile_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_distanceQuartile5, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph5.PlotYAppend(distanceQuartile3);
                            double distanceQuartile4 = NoiseCharacterValue.distance_Quartile(mydata[3]);
                            realMonitorCollection.RightBehindFirstValue.Text = distanceQuartile4.ToString("f9");
                            double[,] temp_distanceQuartile7 = { { distanceQuartile4 }, { ThresholdUpDownValue.DistanceQuartile_Up }, { ThresholdUpDownValue.DistanceQuartile_Down } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_distanceQuartile7, 0, 1 / channelParameterConfig.Resolution1);
                           
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(distanceQuartile1);
                                TwoChannnelCharacterOne.Add(distanceQuartile2);
                                ThreeChannnelCharacterOne.Add(distanceQuartile3);
                                FourChannnelCharacterOne.Add(distanceQuartile4);
                            }
                            break;
                        case "上界":
                            double upperbound1 = NoiseCharacterValue.upper_bound(mydata[0]);
                            realMonitorCollection.LeftFrontFirstValue.Text = upperbound1.ToString("f9");
                            double[,] temp_upperbound1 = { { upperbound1 }, { ThresholdUpDownValue.Upperbound_Up }, { ThresholdUpDownValue.Upperbound_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_upperbound1, 0, 1 / channelParameterConfig.Resolution1);
                            // realMonitorCollection.waveformGraph1.PlotYAppend(upperbound1);

                            double upperbound2 = NoiseCharacterValue.upper_bound(mydata[1]);
                            realMonitorCollection.RightFrontFirstValue.Text = upperbound2.ToString("f9");
                            double[,] temp_upperbound3 = { { upperbound2 }, { ThresholdUpDownValue.Upperbound_Up }, { ThresholdUpDownValue.Upperbound_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_upperbound3, 0, 1 / channelParameterConfig.Resolution1);
                            //   realMonitorCollection.waveformGraph3.PlotYAppend(upperbound2);

                            double upperbound3 = NoiseCharacterValue.upper_bound(mydata[2]);
                            realMonitorCollection.LeftBehindFirstValue.Text = upperbound3.ToString("f9");
                            double[,] temp_upperbound5 = { { upperbound3 }, { ThresholdUpDownValue.Upperbound_Up }, { ThresholdUpDownValue.Upperbound_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_upperbound5, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph5.PlotYAppend(upperbound3);
                            double upperbound4 = NoiseCharacterValue.upper_bound(mydata[3]);
                            realMonitorCollection.RightBehindFirstValue.Text = upperbound4.ToString("f9");
                            double[,] temp_upperbound7 = { { upperbound4 }, { ThresholdUpDownValue.Upperbound_Up }, { ThresholdUpDownValue.Upperbound_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_upperbound7, 0, 1 / channelParameterConfig.Resolution1);
                            
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(upperbound1);
                                TwoChannnelCharacterOne.Add(upperbound2);
                                ThreeChannnelCharacterOne.Add(upperbound3);
                                FourChannnelCharacterOne.Add(upperbound4);
                            }
                            break;
                        case "下界":
                            double downbound1 = NoiseCharacterValue.upper_bound(mydata[0]);
                            realMonitorCollection.LeftFrontFirstValue.Text = downbound1.ToString("f9");
                            double[,] temp_downbound1 = { { downbound1 }, { ThresholdUpDownValue.Downbound_Up }, { ThresholdUpDownValue.Downbound_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_downbound1, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph1.PlotYAppend(downbound1);
                            double downbound2 = NoiseCharacterValue.upper_bound(mydata[1]);
                            realMonitorCollection.RightFrontFirstValue.Text = downbound2.ToString("f9");
                            double[,] temp_downbound3 = { { downbound2 }, { ThresholdUpDownValue.Downbound_Up }, { ThresholdUpDownValue.Downbound_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_downbound3, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph3.PlotYAppend(downbound2);
                            double downbound3 = NoiseCharacterValue.upper_bound(mydata[2]);
                            realMonitorCollection.LeftBehindFirstValue.Text = downbound3.ToString("f9");
                            double[,] temp_downbound5 = { { downbound3 }, { ThresholdUpDownValue.Downbound_Up }, { ThresholdUpDownValue.Downbound_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_downbound5, 0, 1 / channelParameterConfig.Resolution1);
                            // realMonitorCollection.waveformGraph5.PlotYAppend(downbound3);
                            double downbound4 = NoiseCharacterValue.upper_bound(mydata[3]);
                            realMonitorCollection.RightBehindFirstValue.Text = downbound4.ToString("f9");
                            double[,] temp_downbound7 = { { downbound4 }, { ThresholdUpDownValue.Downbound_Up }, { ThresholdUpDownValue.Downbound_Down } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_downbound7, 0, 1 / channelParameterConfig.Resolution1);
                           
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(downbound1);
                                TwoChannnelCharacterOne.Add(downbound2);
                                ThreeChannnelCharacterOne.Add(downbound3);
                                FourChannnelCharacterOne.Add(downbound4);
                            }
                            break;
                        case "均值":
                            double average1 = VibrationAlgorithm.CalculateParasQuShi(mydata[0])[0];
                            realMonitorCollection.LeftFrontFirstValue.Text = average1.ToString("f9");
                            double[,] temp_average1 = { { average1 }, { ThresholdUpDownValue.Average_Up }, { ThresholdUpDownValue.Average_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_average1, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph1.PlotYAppend(average1);
                            double average2 = VibrationAlgorithm.CalculateParasQuShi(mydata[1])[0];
                            realMonitorCollection.RightFrontFirstValue.Text = average2.ToString("f9");
                            double[,] temp_average3 = { { average2 }, { ThresholdUpDownValue.Average_Up }, { ThresholdUpDownValue.Average_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_average3, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph3.PlotYAppend(average2);
                            double average3 = VibrationAlgorithm.CalculateParasQuShi(mydata[2])[0];
                            realMonitorCollection.LeftBehindFirstValue.Text = average3.ToString("f9");
                            double[,] temp_average5 = { { average3 }, { ThresholdUpDownValue.Average_Up }, { ThresholdUpDownValue.Average_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_average5, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph5.PlotYAppend(average3);
                            double average4 = VibrationAlgorithm.CalculateParasQuShi(mydata[3])[0];
                            realMonitorCollection.RightBehindFirstValue.Text = average4.ToString("f9");
                            double[,] temp_average7 = { { average4 }, { ThresholdUpDownValue.Average_Up }, { ThresholdUpDownValue.Average_Down } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_average7, 0, 1 / channelParameterConfig.Resolution1);
                            
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(average1);
                                TwoChannnelCharacterOne.Add(average2);
                                ThreeChannnelCharacterOne.Add(average3);
                                FourChannnelCharacterOne.Add(average4);
                            }
                            break;
                        case "方差":
                            double variance1 = VibrationAlgorithm.CalculateParasQuShi(mydata[0])[7];
                            realMonitorCollection.LeftFrontFirstValue.Text = variance1.ToString("f9");
                            double[,] temp_variance1 = { { variance1 }, { ThresholdUpDownValue.Variance_Up }, { ThresholdUpDownValue.Variance_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_variance1, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph1.PlotYAppend(variance1);
                            double variance2 = VibrationAlgorithm.CalculateParasQuShi(mydata[1])[7];
                            realMonitorCollection.RightFrontFirstValue.Text = variance2.ToString("f9");
                            double[,] temp_variance3 = { { variance2 }, { ThresholdUpDownValue.Variance_Up }, { ThresholdUpDownValue.Variance_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_variance3, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph3.PlotYAppend(variance2);
                            double variance3 = VibrationAlgorithm.CalculateParasQuShi(mydata[2])[7];
                            realMonitorCollection.LeftBehindFirstValue.Text = variance3.ToString("f9");
                            double[,] temp_variance5 = { { variance3 }, { ThresholdUpDownValue.Variance_Up }, { ThresholdUpDownValue.Variance_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_variance5, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph5.PlotYAppend(variance3);
                            double variance4 = VibrationAlgorithm.CalculateParasQuShi(mydata[3])[7];
                            realMonitorCollection.RightBehindFirstValue.Text = variance4.ToString("f9");
                            double[,] temp_variance7 = { { variance4 }, { ThresholdUpDownValue.Variance_Up }, { ThresholdUpDownValue.Variance_Down } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_variance7, 0, 1 / channelParameterConfig.Resolution1);
                            
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(variance1);
                                TwoChannnelCharacterOne.Add(variance2);
                                ThreeChannnelCharacterOne.Add(variance3);
                                FourChannnelCharacterOne.Add(variance4);
                            }
                            break;
                        case "均方根值":
                            double RMS_Value1 = VibrationAlgorithm.CalculateParasQuShi(mydata[0])[1];
                            q1.Enqueue(RMS_Value1);
                            double[] array1;
                            if (q1.Count > 12)
                            {
                                q1.Dequeue();
                                array1 = q1.ToArray();
                                NoiseCharacterValue.QuickSort(array1, 0, array1.Length - 1);
                                RMS_Value1 = (array1[3] + array1[4]) / 2;
                                realMonitorCollection.LeftFrontFirstValue.Text = RMS_Value1.ToString("f9");
                                double[,] temp_RMS_Value1 = { { RMS_Value1 }, { ThresholdUpDownValue.RMS_Value_Up1 }, { ThresholdUpDownValue.RMS_Value_Down1 } };
                                realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_RMS_Value1, 0, 1 / channelParameterConfig.Resolution1);
                            }


                            // realMonitorCollection.waveformGraph1.PlotYAppend(RMS_Value1);
                            double RMS_Value2 = VibrationAlgorithm.CalculateParasQuShi(mydata[1])[1];
                            q2.Enqueue(RMS_Value2);
                            double[] array2;
                            if (q2.Count > 12)
                            {
                                q2.Dequeue();
                                array2 = q2.ToArray();
                                NoiseCharacterValue.QuickSort(array2, 0, array2.Length - 1);
                                RMS_Value2 = (array2[3] + array2[4]) / 2;
                                realMonitorCollection.RightFrontFirstValue.Text = RMS_Value2.ToString("f9");
                                double[,] temp_RMS_Value3 = { { RMS_Value2 }, { ThresholdUpDownValue.RMS_Value_Up1 }, { ThresholdUpDownValue.RMS_Value_Down1 } };
                                realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_RMS_Value3, 0, 1 / channelParameterConfig.Resolution1);
                            }

                            // realMonitorCollection.waveformGraph3.PlotYAppend(RMS_Value2);
                            double RMS_Value3 = VibrationAlgorithm.CalculateParasQuShi(mydata[2])[1];
                            q3.Enqueue(RMS_Value3);
                            double[] array3;
                            if (q3.Count > 12)
                            {
                                q3.Dequeue();
                                array3 = q3.ToArray();
                                NoiseCharacterValue.QuickSort(array3, 0, array3.Length - 1);
                                RMS_Value3 = (array3[3] + array3[4]) / 2;
                                realMonitorCollection.LeftBehindFirstValue.Text = RMS_Value3.ToString("f9");
                                double[,] temp_RMS_Value5 = { { RMS_Value3 }, { ThresholdUpDownValue.RMS_Value_Up1 }, { ThresholdUpDownValue.RMS_Value_Down1 } };
                                realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_RMS_Value5, 0, 1 / channelParameterConfig.Resolution1);
                            }

                            //  realMonitorCollection.waveformGraph5.PlotYAppend(RMS_Value3);
                            double RMS_Value4 = VibrationAlgorithm.CalculateParasQuShi(mydata[3])[1];
                            q4.Enqueue(RMS_Value4);
                            double[] array4;
                            if (q4.Count > 12)
                            {
                                q4.Dequeue();
                                array4 = q4.ToArray();
                                NoiseCharacterValue.QuickSort(array4, 0, array4.Length - 1);
                                RMS_Value4 = (array4[3] + array4[4]) / 2;
                                realMonitorCollection.RightBehindFirstValue.Text = RMS_Value4.ToString("f9");
                                double[,] temp_RMS_Value7 = { { RMS_Value4 }, { ThresholdUpDownValue.RMS_Value_Up1 }, { ThresholdUpDownValue.RMS_Value_Down1 } };
                                realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_RMS_Value7, 0, 1 / channelParameterConfig.Resolution1);
                            }
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(RMS_Value1);
                                TwoChannnelCharacterOne.Add(RMS_Value2);
                                ThreeChannnelCharacterOne.Add(RMS_Value3);
                                FourChannnelCharacterOne.Add(RMS_Value4);
                            }
                            break;

                        case "歪度":
                            double skewness1 = VibrationAlgorithm.CalculateParasQuShi(mydata[0])[5];
                            realMonitorCollection.LeftFrontFirstValue.Text = skewness1.ToString("f9");
                            double[,] temp_skewness1 = { { skewness1 }, { ThresholdUpDownValue.Skewness_Up }, { ThresholdUpDownValue.Skewness_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_skewness1, 0, 1 / channelParameterConfig.Resolution1);
                            // realMonitorCollection.waveformGraph1.PlotYAppend(skewness1);
                            double skewness2 = VibrationAlgorithm.CalculateParasQuShi(mydata[1])[5];
                            realMonitorCollection.RightFrontFirstValue.Text = skewness2.ToString("f9");
                            double[,] temp_skewness3 = { { skewness2 }, { ThresholdUpDownValue.Skewness_Up }, { ThresholdUpDownValue.Skewness_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_skewness3, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph3.PlotYAppend(skewness2);
                            double skewness3 = VibrationAlgorithm.CalculateParasQuShi(mydata[2])[5];
                            realMonitorCollection.LeftBehindFirstValue.Text = skewness3.ToString("f9");
                            double[,] temp_skewness5 = { { skewness3 }, { ThresholdUpDownValue.Skewness_Up }, { ThresholdUpDownValue.Skewness_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_skewness5, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph5.PlotYAppend(skewness3);
                            double skewness4 = VibrationAlgorithm.CalculateParasQuShi(mydata[3])[5];
                            realMonitorCollection.RightBehindFirstValue.Text = skewness4.ToString("f9");
                            double[,] temp_skewness7 = { { skewness4 }, { ThresholdUpDownValue.Skewness_Up }, { ThresholdUpDownValue.Skewness_Down } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_skewness7, 0, 1 / channelParameterConfig.Resolution1);
                           
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(skewness1);
                                TwoChannnelCharacterOne.Add(skewness2);
                                ThreeChannnelCharacterOne.Add(skewness3);
                                FourChannnelCharacterOne.Add(skewness4);
                            }
                            break;

                        case "峭度":
                            double kurtosis1 = VibrationAlgorithm.CalculateParasQuShi(mydata[0])[6];
                            realMonitorCollection.LeftFrontFirstValue.Text = kurtosis1.ToString("f9");
                            double[,] temp_kurtosis1 = { { kurtosis1 }, { ThresholdUpDownValue.Kurtosis_Up }, { ThresholdUpDownValue.Kurtosis_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_kurtosis1, 0, 1 / channelParameterConfig.Resolution1);
                            // realMonitorCollection.waveformGraph1.PlotYAppend(kurtosis1);
                            double kurtosis2 = VibrationAlgorithm.CalculateParasQuShi(mydata[1])[6];
                            realMonitorCollection.RightFrontFirstValue.Text = kurtosis2.ToString("f9");
                            double[,] temp_kurtosis3 = { { kurtosis2 }, { ThresholdUpDownValue.Kurtosis_Up }, { ThresholdUpDownValue.Kurtosis_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_kurtosis3, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph3.PlotYAppend(kurtosis2);
                            double kurtosis3 = VibrationAlgorithm.CalculateParasQuShi(mydata[2])[6];
                            realMonitorCollection.LeftBehindFirstValue.Text = kurtosis3.ToString("f9");
                            double[,] temp_kurtosis5 = { { kurtosis3 }, { ThresholdUpDownValue.Kurtosis_Up }, { ThresholdUpDownValue.Kurtosis_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_kurtosis5, 0, 1 / channelParameterConfig.Resolution1);
                            //   realMonitorCollection.waveformGraph5.PlotYAppend(kurtosis3);
                            double kurtosis4 = VibrationAlgorithm.CalculateParasQuShi(mydata[3])[6];
                            realMonitorCollection.RightBehindFirstValue.Text = kurtosis4.ToString("f9");
                            double[,] temp_kurtosis7 = { { kurtosis4 }, { ThresholdUpDownValue.Kurtosis_Up }, { ThresholdUpDownValue.Kurtosis_Down } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_kurtosis7, 0, 1 / channelParameterConfig.Resolution1);
                           
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(kurtosis1);
                                TwoChannnelCharacterOne.Add(kurtosis2);
                                ThreeChannnelCharacterOne.Add(kurtosis3);
                                FourChannnelCharacterOne.Add(kurtosis4);
                            }
                            break;

                        case "峰度":
                            double peak1 = VibrationAlgorithm.CalculateParasQuShi(mydata[0])[3];
                            realMonitorCollection.LeftFrontFirstValue.Text = peak1.ToString("f9");
                            double[,] temp_peak1 = { { peak1 }, { ThresholdUpDownValue.Peak_Up }, { ThresholdUpDownValue.Peak_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_peak1, 0, 1 / channelParameterConfig.Resolution1);
                            //   realMonitorCollection.waveformGraph1.PlotYAppend(peak1);
                            double peak2 = VibrationAlgorithm.CalculateParasQuShi(mydata[1])[3];
                            realMonitorCollection.RightFrontFirstValue.Text = peak2.ToString("f9");
                            double[,] temp_peak3 = { { peak2 }, { ThresholdUpDownValue.Peak_Up }, { ThresholdUpDownValue.Peak_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_peak3, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph3.PlotYAppend(peak2);
                            double peak3 = VibrationAlgorithm.CalculateParasQuShi(mydata[2])[3];
                            realMonitorCollection.LeftBehindFirstValue.Text = peak3.ToString("f9");
                            double[,] temp_peak5 = { { peak3 }, { ThresholdUpDownValue.Peak_Up }, { ThresholdUpDownValue.Peak_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_peak5, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph5.PlotYAppend(peak3);
                            double peak4 = VibrationAlgorithm.CalculateParasQuShi(mydata[3])[3];
                            realMonitorCollection.RightBehindFirstValue.Text = peak4.ToString("f9");
                            double[,] temp_peak7 = { { peak4 }, { ThresholdUpDownValue.Peak_Up }, { ThresholdUpDownValue.Peak_Down } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_peak7, 0, 1 / channelParameterConfig.Resolution1);
                           
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(peak1);
                                TwoChannnelCharacterOne.Add(peak2);
                                ThreeChannnelCharacterOne.Add(peak3);
                                FourChannnelCharacterOne.Add(peak4);
                            }
                            break;

                        case "峰值频率":
                            double frequency1 = NoiseCharacterValue.PeakFrequency(mydata[0], channelParameterConfig.SampleRate1);
                            realMonitorCollection.LeftFrontFirstValue.Text = frequency1.ToString("f9");
                            double[,] temp_frequency1 = { { frequency1 }, { ThresholdUpDownValue.Frequency_Up }, { ThresholdUpDownValue.Frequency_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_frequency1, 0, 1 / channelParameterConfig.Resolution1);
                            // realMonitorCollection.waveformGraph1.PlotYAppend(frequency1);
                            double frequency2 = NoiseCharacterValue.PeakFrequency(mydata[1], channelParameterConfig.SampleRate1);
                            realMonitorCollection.RightFrontFirstValue.Text = frequency2.ToString("f9");
                            double[,] temp_frequency3 = { { frequency2 }, { ThresholdUpDownValue.Frequency_Up }, { ThresholdUpDownValue.Frequency_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_frequency3, 0, 1 / channelParameterConfig.Resolution1);
                            // realMonitorCollection.waveformGraph3.PlotYAppend(frequency2);
                            double frequency3 = NoiseCharacterValue.PeakFrequency(mydata[2], channelParameterConfig.SampleRate1);
                            realMonitorCollection.LeftBehindFirstValue.Text = frequency3.ToString("f9");
                            double[,] temp_frequency5 = { { frequency3 }, { ThresholdUpDownValue.Frequency_Up }, { ThresholdUpDownValue.Frequency_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_frequency5, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph5.PlotYAppend(frequency3);
                            double frequency4 = NoiseCharacterValue.PeakFrequency(mydata[3], channelParameterConfig.SampleRate1);
                            realMonitorCollection.RightBehindFirstValue.Text = frequency4.ToString("f9");
                            double[,] temp_frequency7 = { { frequency4 }, { ThresholdUpDownValue.Frequency_Up }, { ThresholdUpDownValue.Frequency_Down } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_frequency7, 0, 1 / channelParameterConfig.Resolution1);
                           
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(frequency1);
                                TwoChannnelCharacterOne.Add(frequency2);
                                ThreeChannnelCharacterOne.Add(frequency3);
                                FourChannnelCharacterOne.Add(frequency4);
                            }
                            break;

                        case "频率幅值":
                            Signal_FrequencySpectrum(mydata);
                            double frequencyA1 = FrequencyA[0];
                            realMonitorCollection.LeftFrontFirstValue.Text = frequencyA1.ToString("f9");
                            double[,] temp_frequencyA1 = { { frequencyA1 }, { ThresholdUpDownValue.FrequencyA_Up }, { ThresholdUpDownValue.FrequencyA_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_frequencyA1, 0, 1 / channelParameterConfig.Resolution1);
                            //    realMonitorCollection.waveformGraph1.PlotYAppend(frequencyA1);
                            double frequencyA2 = FrequencyA[1];
                            realMonitorCollection.RightFrontFirstValue.Text = frequencyA2.ToString("f9");
                            double[,] temp_frequencyA3 = { { frequencyA2 }, { ThresholdUpDownValue.FrequencyA_Up }, { ThresholdUpDownValue.FrequencyA_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_frequencyA3, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph3.PlotYAppend(frequencyA2);
                            double frequencyA3 = FrequencyA[2];
                            realMonitorCollection.LeftBehindFirstValue.Text = frequencyA3.ToString("f9");
                            double[,] temp_frequencyA5 = { { frequencyA3 }, { ThresholdUpDownValue.FrequencyA_Up }, { ThresholdUpDownValue.FrequencyA_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_frequencyA5, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph5.PlotYAppend(frequencyA3);
                            double frequencyA4 = FrequencyA[3];
                            realMonitorCollection.RightBehindFirstValue.Text = frequencyA4.ToString("f9");
                            double[,] temp_frequencyA7 = { { frequencyA4 }, { ThresholdUpDownValue.FrequencyA_Up }, { ThresholdUpDownValue.FrequencyA_Down } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_frequencyA7, 0, 1 / channelParameterConfig.Resolution1);
                            
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(frequencyA1);
                                TwoChannnelCharacterOne.Add(frequencyA2);
                                ThreeChannnelCharacterOne.Add(frequencyA3);
                                FourChannnelCharacterOne.Add(frequencyA4);
                            }
                            break;

                        case "中心频率":
                            double octaveValue1 = VoiceOctave.octave(mydata[0], Convert.ToDouble(channelParameterConfig.SampleRate1), DataTempStorage.CenterFrequency1);
                            realMonitorCollection.LeftFrontFirstValue.Text = octaveValue1.ToString("f9");
                            double[,] temp_octaveValue1 = { { octaveValue1 }, { ThresholdUpDownValue.OctaveValue_Up }, { ThresholdUpDownValue.OctaveValue_Down } };
                            realMonitorCollection.waveformGraph1.PlotYAppendMultiple(temp_octaveValue1, 0, 1 / channelParameterConfig.Resolution1);
                            // realMonitorCollection.waveformGraph1.PlotYAppend(octaveValue1);
                            double octaveValue2 = VoiceOctave.octave(mydata[1], Convert.ToDouble(channelParameterConfig.SampleRate1), DataTempStorage.CenterFrequency1);
                            realMonitorCollection.LeftFrontFirstValue.Text = octaveValue2.ToString("f9");
                            double[,] temp_octaveValue3 = { { octaveValue2 }, { ThresholdUpDownValue.OctaveValue_Up }, { ThresholdUpDownValue.OctaveValue_Down } };
                            realMonitorCollection.waveformGraph3.PlotYAppendMultiple(temp_octaveValue3, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph3.PlotYAppend(octaveValue2);
                            double octaveValue3 = VoiceOctave.octave(mydata[2], Convert.ToDouble(channelParameterConfig.SampleRate1), DataTempStorage.CenterFrequency1);
                            realMonitorCollection.LeftFrontFirstValue.Text = octaveValue3.ToString("f9");
                            double[,] temp_octaveValue5 = { { octaveValue3 }, { ThresholdUpDownValue.OctaveValue_Up }, { ThresholdUpDownValue.OctaveValue_Down } };
                            realMonitorCollection.waveformGraph5.PlotYAppendMultiple(temp_octaveValue5, 0, 1 / channelParameterConfig.Resolution1);
                            //   realMonitorCollection.waveformGraph5.PlotYAppend(octaveValue3);
                            double octaveValue4 = VoiceOctave.octave(mydata[3], Convert.ToDouble(channelParameterConfig.SampleRate1), DataTempStorage.CenterFrequency1);
                            realMonitorCollection.LeftFrontFirstValue.Text = octaveValue4.ToString("f9");
                            double[,] temp_octaveValue7 = { { octaveValue4 }, { ThresholdUpDownValue.OctaveValue_Up }, { ThresholdUpDownValue.OctaveValue_Down } };
                            realMonitorCollection.waveformGraph7.PlotYAppendMultiple(temp_octaveValue7, 0, 1 / channelParameterConfig.Resolution1);
                            
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterOne.Add(octaveValue1);
                                TwoChannnelCharacterOne.Add(octaveValue2);
                                ThreeChannnelCharacterOne.Add(octaveValue3);
                                FourChannnelCharacterOne.Add(octaveValue4);
                            }
                            break;
                    }


                    switch (DataTempStorage.AlgorithmList1[1].ToString())
                    {
                        case "上四分位":
                             double upQuartile5 = NoiseCharacterValue.up_Quartile(mydata[0]);
                            realMonitorCollection.LeftFrontSecondValue.Text = upQuartile5.ToString("f9");
                           // realMonitorCollection.waveformGraph1.PlotYAppend(upQuartile1);
                            double[,] temp_upQuartile1= { { upQuartile5 }, { ThresholdUpDownValue.UpQuartile_Up }, { ThresholdUpDownValue.UpQuartile_Down} };
                            realMonitorCollection.waveformGraph2.PlotYAppendMultiple(temp_upQuartile1, 0, 1 / channelParameterConfig.Resolution1);


                            double upQuartile6 = NoiseCharacterValue.up_Quartile(mydata[1]);
                            realMonitorCollection.RightFrontSecondValue.Text = upQuartile6.ToString("f9");
                         //   realMonitorCollection.waveformGraph3.PlotYAppend(upQuartile2);
                            double[,] temp_upQuartile3 = { { upQuartile6 }, { ThresholdUpDownValue.UpQuartile_Up }, { ThresholdUpDownValue.UpQuartile_Down } };
                            realMonitorCollection.waveformGraph4.PlotYAppendMultiple(temp_upQuartile3, 0, 1 / channelParameterConfig.Resolution1);


                            double upQuartile7 = NoiseCharacterValue.up_Quartile(mydata[2]);
                            realMonitorCollection.LeftBehindSecondValue.Text = upQuartile7.ToString("f9");
                          //  realMonitorCollection.waveformGraph5.PlotYAppend(upQuartile3);
                            double[,] temp_upQuartile5 = { { upQuartile7 }, { ThresholdUpDownValue.UpQuartile_Up }, { ThresholdUpDownValue.UpQuartile_Down } };
                            realMonitorCollection.waveformGraph6.PlotYAppendMultiple(temp_upQuartile5, 0, 1 / channelParameterConfig.Resolution1);


                            double upQuartile8 = NoiseCharacterValue.up_Quartile(mydata[3]);
                            realMonitorCollection.RightBehindSecondValue.Text = upQuartile8.ToString("f9");
                         //   realMonitorCollection.waveformGraph7.PlotYAppend(upQuartile4);
                            double[,] temp_upQuartile7 = { { upQuartile8 }, { ThresholdUpDownValue.UpQuartile_Up }, { ThresholdUpDownValue.UpQuartile_Down } };
                            realMonitorCollection.waveformGraph8.PlotYAppendMultiple(temp_upQuartile7, 0, 1 / channelParameterConfig.Resolution1);
                           
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterTwo.Add(upQuartile5);
                                TwoChannnelCharacterTwo.Add(upQuartile6);
                                ThreeChannnelCharacterTwo.Add(upQuartile7);
                                FourChannnelCharacterTwo.Add(upQuartile8);
                            }
                            break;
                        case "下四分位":
                            double downQuartile5 = NoiseCharacterValue.down_Quartile(mydata[0]);
                            realMonitorCollection.LeftFrontSecondValue.Text = downQuartile5.ToString("f9");
                          //  realMonitorCollection.waveformGraph1.PlotYAppend(downQuartile1);
                            double[,] temp_downQuartile1 = { { downQuartile5 }, { ThresholdUpDownValue.DownQuartile_Up }, { ThresholdUpDownValue.DownQuartile_Down } };
                            realMonitorCollection.waveformGraph2.PlotYAppendMultiple(temp_downQuartile1, 0, 1 / channelParameterConfig.Resolution1);

                            double downQuartile6 = NoiseCharacterValue.down_Quartile(mydata[1]);
                            realMonitorCollection.RightFrontSecondValue.Text = downQuartile6.ToString("f9");
                            double[,] temp_downQuartile3 = { { downQuartile6 }, { ThresholdUpDownValue.DownQuartile_Up }, { ThresholdUpDownValue.DownQuartile_Down } };
                            realMonitorCollection.waveformGraph4.PlotYAppendMultiple(temp_downQuartile3, 0, 1 / channelParameterConfig.Resolution1);
                         //   realMonitorCollection.waveformGraph3.PlotYAppend(downQuartile2);

                            double downQuartile7 = NoiseCharacterValue.down_Quartile(mydata[2]);
                            realMonitorCollection.LeftBehindSecondValue.Text = downQuartile7.ToString("f9");
                            double[,] temp_downQuartile5 = { { downQuartile7 }, { ThresholdUpDownValue.DownQuartile_Up }, { ThresholdUpDownValue.DownQuartile_Down } };
                            realMonitorCollection.waveformGraph6.PlotYAppendMultiple(temp_downQuartile5, 0, 1 / channelParameterConfig.Resolution1);

                            //realMonitorCollection.waveformGraph5.PlotYAppend(downQuartile3);
                            double downQuartile8 = NoiseCharacterValue.down_Quartile(mydata[3]);
                            realMonitorCollection.RightBehindSecondValue.Text = downQuartile8.ToString("f9");
                            double[,] temp_downQuartile7 = { { downQuartile8 }, { ThresholdUpDownValue.DownQuartile_Up }, { ThresholdUpDownValue.DownQuartile_Down } };
                            realMonitorCollection.waveformGraph8.PlotYAppendMultiple(temp_downQuartile7, 0, 1 / channelParameterConfig.Resolution1);
                       
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterTwo.Add(downQuartile5);
                                TwoChannnelCharacterTwo.Add(downQuartile6);
                                ThreeChannnelCharacterTwo.Add(downQuartile7);
                                FourChannnelCharacterTwo.Add(downQuartile8);
                            }
                            break;
                        case "中位数":
                            double Median5 = NoiseCharacterValue.Median(mydata[0]);
                            realMonitorCollection.LeftFrontSecondValue.Text = Median5.ToString("f9");
                            double[,] temp_Median1 = { { Median5 }, { ThresholdUpDownValue.Median_Up1 }, { ThresholdUpDownValue.Median_Down1 } };
                            realMonitorCollection.waveformGraph2.PlotYAppendMultiple(temp_Median1, 0, 1 / channelParameterConfig.Resolution1);
                           // realMonitorCollection.waveformGraph1.PlotYAppend(Median1);

                            double Median6 = NoiseCharacterValue.Median(mydata[1]);
                            realMonitorCollection.RightFrontSecondValue.Text = Median6.ToString("f9");
                            double[,] temp_Median3 = { { Median6 }, { ThresholdUpDownValue.Median_Up1 }, { ThresholdUpDownValue.Median_Down1 } };
                            realMonitorCollection.waveformGraph4.PlotYAppendMultiple(temp_Median3, 0, 1 / channelParameterConfig.Resolution1);
                       //     realMonitorCollection.waveformGraph3.PlotYAppend(Median2);
                            double Median7 = NoiseCharacterValue.Median(mydata[2]);
                            realMonitorCollection.LeftBehindSecondValue.Text = Median7.ToString("f9");
                            double[,] temp_Median5 = { { Median7 }, { ThresholdUpDownValue.Median_Up1 }, { ThresholdUpDownValue.Median_Down1 } };
                            realMonitorCollection.waveformGraph6.PlotYAppendMultiple(temp_Median5, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph5.PlotYAppend(Median3);
                            double Median8 = NoiseCharacterValue.Median(mydata[3]);
                            realMonitorCollection.RightBehindSecondValue.Text = Median8.ToString("f9");
                            double[,] temp_Median7 = { { Median8 }, { ThresholdUpDownValue.Median_Up1 }, { ThresholdUpDownValue.Median_Down1 } };
                            realMonitorCollection.waveformGraph8.PlotYAppendMultiple(temp_Median7, 0, 1 / channelParameterConfig.Resolution1);
                          
                             if (SaveCharacterValue)
                            {
                                OneChannnelCharacterTwo.Add(Median5);
                                TwoChannnelCharacterTwo.Add(Median6);
                                ThreeChannnelCharacterTwo.Add(Median7);
                                FourChannnelCharacterTwo.Add(Median8);
                            }
                            break;
                        case "四分位距":
                            double distanceQuartile5 = NoiseCharacterValue.distance_Quartile(mydata[0]);
                            realMonitorCollection.LeftFrontSecondValue.Text = distanceQuartile5.ToString("f9");
                            double[,] temp_distanceQuartile1 = { { distanceQuartile5 }, { ThresholdUpDownValue.DistanceQuartile_Up }, { ThresholdUpDownValue.DistanceQuartile_Down } };
                            realMonitorCollection.waveformGraph2.PlotYAppendMultiple(temp_distanceQuartile1, 0, 1 / channelParameterConfig.Resolution1);
                           // realMonitorCollection.waveformGraph1.PlotYAppend(distanceQuartile1);
                            double distanceQuartile6 = NoiseCharacterValue.distance_Quartile(mydata[1]);
                            realMonitorCollection.RightFrontSecondValue.Text = distanceQuartile6.ToString("f9");
                             double[,] temp_distanceQuartile3 = { { distanceQuartile6 }, { ThresholdUpDownValue.DistanceQuartile_Up }, { ThresholdUpDownValue.DistanceQuartile_Down } };
                             realMonitorCollection.waveformGraph4.PlotYAppendMultiple(temp_distanceQuartile3, 0, 1 / channelParameterConfig.Resolution1);
                            //realMonitorCollection.waveformGraph3.PlotYAppend(distanceQuartile2);
                            double distanceQuartile7 = NoiseCharacterValue.distance_Quartile(mydata[2]);
                            realMonitorCollection.LeftBehindSecondValue.Text = distanceQuartile7.ToString("f9");
                             double[,] temp_distanceQuartile5 = { { distanceQuartile7 }, { ThresholdUpDownValue.DistanceQuartile_Up }, { ThresholdUpDownValue.DistanceQuartile_Down } };
                             realMonitorCollection.waveformGraph6.PlotYAppendMultiple(temp_distanceQuartile5, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph5.PlotYAppend(distanceQuartile3);
                            double distanceQuartile8 = NoiseCharacterValue.distance_Quartile(mydata[3]);
                            realMonitorCollection.RightBehindSecondValue.Text = distanceQuartile8.ToString("f9");
                             double[,] temp_distanceQuartile7 = { { distanceQuartile8 }, { ThresholdUpDownValue.DistanceQuartile_Up }, { ThresholdUpDownValue.DistanceQuartile_Down } };
                             realMonitorCollection.waveformGraph8.PlotYAppendMultiple(temp_distanceQuartile7, 0, 1 / channelParameterConfig.Resolution1);
                           
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterTwo.Add(distanceQuartile5);
                                TwoChannnelCharacterTwo.Add(distanceQuartile6);
                                ThreeChannnelCharacterTwo.Add(distanceQuartile7);
                                FourChannnelCharacterTwo.Add(distanceQuartile8);
                            }
                            break;
                        case "上界":
                            double upperbound5 = NoiseCharacterValue.upper_bound(mydata[0]);
                            realMonitorCollection.LeftFrontSecondValue.Text = upperbound5.ToString("f9");
                            double[,] temp_upperbound1 = { { upperbound5 }, { ThresholdUpDownValue.Upperbound_Up }, { ThresholdUpDownValue.Upperbound_Down } };
                            realMonitorCollection.waveformGraph2.PlotYAppendMultiple(temp_upperbound1, 0, 1 / channelParameterConfig.Resolution1);
                           // realMonitorCollection.waveformGraph1.PlotYAppend(upperbound1);

                            double upperbound6 = NoiseCharacterValue.upper_bound(mydata[1]);
                            realMonitorCollection.RightFrontSecondValue.Text = upperbound6.ToString("f9");
                            double[,] temp_upperbound3 = { { upperbound6 }, { ThresholdUpDownValue.Upperbound_Up }, { ThresholdUpDownValue.Upperbound_Down } };
                            realMonitorCollection.waveformGraph4.PlotYAppendMultiple(temp_upperbound3, 0, 1 / channelParameterConfig.Resolution1);
                         //   realMonitorCollection.waveformGraph3.PlotYAppend(upperbound2);

                            double upperbound7 = NoiseCharacterValue.upper_bound(mydata[2]);
                            realMonitorCollection.LeftBehindSecondValue.Text = upperbound7.ToString("f9");
                            double[,] temp_upperbound5 = { { upperbound7 }, { ThresholdUpDownValue.Upperbound_Up }, { ThresholdUpDownValue.Upperbound_Down } };
                            realMonitorCollection.waveformGraph6.PlotYAppendMultiple(temp_upperbound5, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph5.PlotYAppend(upperbound3);
                            double upperbound8 = NoiseCharacterValue.upper_bound(mydata[3]);
                            realMonitorCollection.RightBehindSecondValue.Text = upperbound8.ToString("f9");
                            double[,] temp_upperbound7 = { { upperbound8 }, { ThresholdUpDownValue.Upperbound_Up }, { ThresholdUpDownValue.Upperbound_Down } };
                            realMonitorCollection.waveformGraph8.PlotYAppendMultiple(temp_upperbound7, 0, 1 / channelParameterConfig.Resolution1);
                           
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterTwo.Add(upperbound5);
                                TwoChannnelCharacterTwo.Add(upperbound6);
                                ThreeChannnelCharacterTwo.Add(upperbound7);
                                FourChannnelCharacterTwo.Add(upperbound8);
                            }
                            break;
                        case "下界":
                            double downbound5 = NoiseCharacterValue.upper_bound(mydata[0]);
                            realMonitorCollection.LeftFrontSecondValue.Text = downbound5.ToString("f9");
                            double[,] temp_downbound1 = { { downbound5 }, { ThresholdUpDownValue.Downbound_Up }, { ThresholdUpDownValue.Downbound_Down } };
                            realMonitorCollection.waveformGraph2.PlotYAppendMultiple(temp_downbound1, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph1.PlotYAppend(downbound1);
                            double downbound6 = NoiseCharacterValue.upper_bound(mydata[1]);
                            realMonitorCollection.RightFrontSecondValue.Text = downbound6.ToString("f9");
                            double[,] temp_downbound3 = { { downbound6 }, { ThresholdUpDownValue.Downbound_Up }, { ThresholdUpDownValue.Downbound_Down } };
                            realMonitorCollection.waveformGraph4.PlotYAppendMultiple(temp_downbound3, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph3.PlotYAppend(downbound2);
                            double downbound7 = NoiseCharacterValue.upper_bound(mydata[2]);
                            realMonitorCollection.LeftBehindSecondValue.Text = downbound7.ToString("f9");
                            double[,] temp_downbound5 = { { downbound7 }, { ThresholdUpDownValue.Downbound_Up }, { ThresholdUpDownValue.Downbound_Down } };
                            realMonitorCollection.waveformGraph6.PlotYAppendMultiple(temp_downbound5, 0, 1 / channelParameterConfig.Resolution1);
                           // realMonitorCollection.waveformGraph5.PlotYAppend(downbound3);
                            double downbound8 = NoiseCharacterValue.upper_bound(mydata[3]);
                            realMonitorCollection.RightBehindSecondValue.Text = downbound8.ToString("f9");
                            double[,] temp_downbound7 = { { downbound8 }, { ThresholdUpDownValue.Downbound_Up }, { ThresholdUpDownValue.Downbound_Down } };
                            realMonitorCollection.waveformGraph8.PlotYAppendMultiple(temp_downbound7, 0, 1 / channelParameterConfig.Resolution1);
                           
                             if (SaveCharacterValue)
                            {
                                OneChannnelCharacterTwo.Add(downbound5);
                                TwoChannnelCharacterTwo.Add(downbound6);
                                ThreeChannnelCharacterTwo.Add(downbound7);
                                FourChannnelCharacterTwo.Add(downbound8);
                            }
                            break;
                        case "均值":
                            double average5 = VibrationAlgorithm.CalculateParasQuShi(mydata[0])[0];
                            realMonitorCollection.LeftFrontSecondValue.Text = average5.ToString("f9");
                            double[,] temp_average1 = { { average5 }, { ThresholdUpDownValue.Average_Up }, { ThresholdUpDownValue.Average_Down } };
                            realMonitorCollection.waveformGraph2.PlotYAppendMultiple(temp_average1, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph1.PlotYAppend(average1);
                            double average6 = VibrationAlgorithm.CalculateParasQuShi(mydata[1])[0];
                            realMonitorCollection.RightFrontSecondValue.Text = average6.ToString("f9");
                             double[,] temp_average3 = { { average6 }, { ThresholdUpDownValue.Average_Up }, { ThresholdUpDownValue.Average_Down } };
                             realMonitorCollection.waveformGraph4.PlotYAppendMultiple(temp_average3, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph3.PlotYAppend(average2);
                            double average7 = VibrationAlgorithm.CalculateParasQuShi(mydata[2])[0];
                            realMonitorCollection.LeftBehindSecondValue.Text = average7.ToString("f9");
                             double[,] temp_average5 = { { average7 }, { ThresholdUpDownValue.Average_Up }, { ThresholdUpDownValue.Average_Down } };
                             realMonitorCollection.waveformGraph6.PlotYAppendMultiple(temp_average5, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph5.PlotYAppend(average3);
                            double average8 = VibrationAlgorithm.CalculateParasQuShi(mydata[3])[0];
                            realMonitorCollection.RightBehindSecondValue.Text = average8.ToString("f9");
                             double[,] temp_average7 = { { average8 }, { ThresholdUpDownValue.Average_Up }, { ThresholdUpDownValue.Average_Down } };
                             realMonitorCollection.waveformGraph8.PlotYAppendMultiple(temp_average7, 0, 1 / channelParameterConfig.Resolution1);
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterTwo.Add(average5);
                                TwoChannnelCharacterTwo.Add(average6);
                                ThreeChannnelCharacterTwo.Add(average7);
                                FourChannnelCharacterTwo.Add(average8);
                            }
                            break;
                        case "方差":
                            double variance5 = VibrationAlgorithm.CalculateParasQuShi(mydata[0])[7];
                            realMonitorCollection.LeftFrontSecondValue.Text = variance5.ToString("f9");
                            double[,] temp_variance1 = { { variance5 }, { ThresholdUpDownValue.Variance_Up }, { ThresholdUpDownValue.Variance_Down } };
                            realMonitorCollection.waveformGraph2.PlotYAppendMultiple(temp_variance1, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph1.PlotYAppend(variance1);
                            double variance6 = VibrationAlgorithm.CalculateParasQuShi(mydata[1])[7];
                            realMonitorCollection.RightFrontSecondValue.Text = variance6.ToString("f9");
                             double[,] temp_variance3 = { { variance6 }, { ThresholdUpDownValue.Variance_Up }, { ThresholdUpDownValue.Variance_Down } };
                             realMonitorCollection.waveformGraph4.PlotYAppendMultiple(temp_variance3, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph3.PlotYAppend(variance2);
                            double variance7 = VibrationAlgorithm.CalculateParasQuShi(mydata[2])[7];
                            realMonitorCollection.LeftBehindSecondValue.Text = variance7.ToString("f9");
                             double[,] temp_variance5 = { { variance7 }, { ThresholdUpDownValue.Variance_Up }, { ThresholdUpDownValue.Variance_Down } };
                             realMonitorCollection.waveformGraph6.PlotYAppendMultiple(temp_variance5, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph5.PlotYAppend(variance3);
                            double variance8 = VibrationAlgorithm.CalculateParasQuShi(mydata[3])[7];
                            realMonitorCollection.RightBehindSecondValue.Text = variance8.ToString("f9");
                             double[,] temp_variance7 = { { variance8 }, { ThresholdUpDownValue.Variance_Up }, { ThresholdUpDownValue.Variance_Down } };
                             realMonitorCollection.waveformGraph8.PlotYAppendMultiple(temp_variance7, 0, 1 / channelParameterConfig.Resolution1);
                         
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterTwo.Add(variance5);
                                TwoChannnelCharacterTwo.Add(variance6);
                                ThreeChannnelCharacterTwo.Add(variance7);
                                FourChannnelCharacterTwo.Add(variance8);
                            }
                            break;
                        case "均方根值":
                          //  double RMS_Value5 = VibrationAlgorithm.CalculateParasQuShi(mydata[0])[1];
                          //  realMonitorCollection.LeftFrontSecondValue.Text = RMS_Value5.ToString("f9");
                          //  double[,] temp_RMS_Value1 = { { RMS_Value5 }, { ThresholdUpDownValue.RMS_Value_Up1 }, { ThresholdUpDownValue.RMS_Value_Down1 } };
                          //  realMonitorCollection.waveformGraph2.PlotYAppendMultiple(temp_RMS_Value1);
                          // // realMonitorCollection.waveformGraph1.PlotYAppend(RMS_Value1);
                          //  double RMS_Value6 = VibrationAlgorithm.CalculateParasQuShi(mydata[1])[1];
                          //  realMonitorCollection.RightFrontSecondValue.Text = RMS_Value6.ToString("f9");
                          //  double[,] temp_RMS_Value3 = { { RMS_Value6 }, { ThresholdUpDownValue.RMS_Value_Up1 }, { ThresholdUpDownValue.RMS_Value_Down1 } };
                          //  realMonitorCollection.waveformGraph4.PlotYAppendMultiple(temp_RMS_Value3);
                          // // realMonitorCollection.waveformGraph3.PlotYAppend(RMS_Value2);
                          //  double RMS_Value7 = VibrationAlgorithm.CalculateParasQuShi(mydata[2])[1];
                          //  realMonitorCollection.LeftBehindSecondValue.Text = RMS_Value7.ToString("f9");
                          //  double[,] temp_RMS_Value5 = { { RMS_Value7 }, { ThresholdUpDownValue.RMS_Value_Up1 }, { ThresholdUpDownValue.RMS_Value_Down1 } };
                          //  realMonitorCollection.waveformGraph6.PlotYAppendMultiple(temp_RMS_Value5);
                          ////  realMonitorCollection.waveformGraph5.PlotYAppend(RMS_Value3);
                          //  double RMS_Value8 = VibrationAlgorithm.CalculateParasQuShi(mydata[3])[1];
                          //  realMonitorCollection.RightBehindSecondValue.Text = RMS_Value8.ToString("f9");
                          //  double[,] temp_RMS_Value7 = { { RMS_Value8 }, { ThresholdUpDownValue.RMS_Value_Up1 }, { ThresholdUpDownValue.RMS_Value_Down1 } };
                          //  realMonitorCollection.waveformGraph8.PlotYAppendMultiple(temp_RMS_Value7);

                        
                            double RMS_Value5 = VibrationAlgorithm.CalculateParasQuShi(mydata[0])[1];
                            q5.Enqueue(RMS_Value5);
                            double[] array5;
                            if (q5.Count > 12)
                            {
                                q5.Dequeue();
                                array5 = q5.ToArray();
                                NoiseCharacterValue.QuickSort(array5, 0, array5.Length - 1);
                                RMS_Value5 = (array5[3] + array5[4]) / 2;
                                realMonitorCollection.LeftFrontSecondValue.Text = RMS_Value5.ToString("f9");
                                double[,] temp_RMS_Value1 = { { RMS_Value5 }, { ThresholdUpDownValue.RMS_Value_Up1 }, { ThresholdUpDownValue.RMS_Value_Down1 } };
                                realMonitorCollection.waveformGraph2.PlotYAppendMultiple(temp_RMS_Value1, 0, 1 / channelParameterConfig.Resolution1);
                            }


                            // realMonitorCollection.waveformGraph1.PlotYAppend(RMS_Value1);
                            double RMS_Value6 = VibrationAlgorithm.CalculateParasQuShi(mydata[1])[1];
                            q6.Enqueue(RMS_Value6);
                            double[] array6;
                            if (q6.Count > 12)
                            {
                                q6.Dequeue();
                                array6 = q6.ToArray();
                                NoiseCharacterValue.QuickSort(array6, 0, array6.Length - 1);
                                RMS_Value6 = (array6[3] + array6[4]) / 2;
                                realMonitorCollection.RightFrontSecondValue.Text = RMS_Value6.ToString("f9");
                                double[,] temp_RMS_Value3 = { { RMS_Value6 }, { ThresholdUpDownValue.RMS_Value_Up1 }, { ThresholdUpDownValue.RMS_Value_Down1 } };
                                realMonitorCollection.waveformGraph4.PlotYAppendMultiple(temp_RMS_Value3, 0, 1 / channelParameterConfig.Resolution1);
                            }

                            // realMonitorCollection.waveformGraph3.PlotYAppend(RMS_Value2);
                            double RMS_Value7 = VibrationAlgorithm.CalculateParasQuShi(mydata[2])[1];
                            q7.Enqueue(RMS_Value7);
                            double[] array7;
                            if (q7.Count > 12)
                            {
                                q7.Dequeue();
                                array7 = q7.ToArray();
                                NoiseCharacterValue.QuickSort(array7, 0, array7.Length - 1);
                                RMS_Value7 = (array7[3] + array7[4]) / 2;
                                realMonitorCollection.LeftBehindSecondValue.Text = RMS_Value7.ToString("f9");
                                double[,] temp_RMS_Value5 = { { RMS_Value7 }, { ThresholdUpDownValue.RMS_Value_Up1 }, { ThresholdUpDownValue.RMS_Value_Down1 } };
                                realMonitorCollection.waveformGraph6.PlotYAppendMultiple(temp_RMS_Value5, 0, 1 / channelParameterConfig.Resolution1);
                            }

                            //  realMonitorCollection.waveformGraph5.PlotYAppend(RMS_Value3);
                            double RMS_Value8 = VibrationAlgorithm.CalculateParasQuShi(mydata[3])[1];
                            q8.Enqueue(RMS_Value8);
                            double[] array8;
                            if (q8.Count > 12)
                            {
                                q8.Dequeue();
                                array8 = q8.ToArray();
                                NoiseCharacterValue.QuickSort(array8, 0, array8.Length - 1);
                                RMS_Value8 = (array8[3] + array8[4]) / 2;
                                realMonitorCollection.RightBehindSecondValue.Text = RMS_Value8.ToString("f9");
                                double[,] temp_RMS_Value7 = { { RMS_Value8 }, { ThresholdUpDownValue.RMS_Value_Up1 }, { ThresholdUpDownValue.RMS_Value_Down1 } };
                                realMonitorCollection.waveformGraph8.PlotYAppendMultiple(temp_RMS_Value7, 0, 1 / channelParameterConfig.Resolution1);
                            }
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterTwo.Add(RMS_Value5);
                                TwoChannnelCharacterTwo.Add(RMS_Value6);
                                ThreeChannnelCharacterTwo.Add(RMS_Value7);
                                FourChannnelCharacterTwo.Add(RMS_Value8);
                            }
                            break;

                        case "歪度":
                            double skewness5 = VibrationAlgorithm.CalculateParasQuShi(mydata[0])[5];
                            realMonitorCollection.LeftFrontSecondValue.Text = skewness5.ToString("f9");
                            double[,] temp_skewness1 = { { skewness5 }, { ThresholdUpDownValue.Skewness_Up }, { ThresholdUpDownValue.Skewness_Down } };
                            realMonitorCollection.waveformGraph2.PlotYAppendMultiple(temp_skewness1, 0, 1 / channelParameterConfig.Resolution1);
                           // realMonitorCollection.waveformGraph1.PlotYAppend(skewness1);
                            double skewness6 = VibrationAlgorithm.CalculateParasQuShi(mydata[1])[5];
                            realMonitorCollection.RightFrontSecondValue.Text = skewness6.ToString("f9");
                            double[,] temp_skewness3 = { { skewness6 }, { ThresholdUpDownValue.Skewness_Up }, { ThresholdUpDownValue.Skewness_Down } };
                            realMonitorCollection.waveformGraph4.PlotYAppendMultiple(temp_skewness3, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph3.PlotYAppend(skewness2);
                            double skewness7 = VibrationAlgorithm.CalculateParasQuShi(mydata[2])[5];
                            realMonitorCollection.LeftBehindSecondValue.Text = skewness7.ToString("f9");
                            double[,] temp_skewness5 = { { skewness7 }, { ThresholdUpDownValue.Skewness_Up }, { ThresholdUpDownValue.Skewness_Down } };
                            realMonitorCollection.waveformGraph6.PlotYAppendMultiple(temp_skewness5, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph5.PlotYAppend(skewness3);
                            double skewness8 = VibrationAlgorithm.CalculateParasQuShi(mydata[3])[5];
                            realMonitorCollection.RightBehindSecondValue.Text = skewness8.ToString("f9");
                            double[,] temp_skewness7 = { { skewness8 }, { ThresholdUpDownValue.Skewness_Up }, { ThresholdUpDownValue.Skewness_Down } };
                            realMonitorCollection.waveformGraph8.PlotYAppendMultiple(temp_skewness7, 0, 1 / channelParameterConfig.Resolution1);
                         
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterTwo.Add(skewness5);
                                TwoChannnelCharacterTwo.Add(skewness6);
                                ThreeChannnelCharacterTwo.Add(skewness7);
                                FourChannnelCharacterTwo.Add(skewness8);
                            }
                            break;

                        case "峭度":
                            double kurtosis5 = VibrationAlgorithm.CalculateParasQuShi(mydata[0])[6];
                            realMonitorCollection.LeftFrontSecondValue.Text = kurtosis5.ToString("f9");
                            double[,] temp_kurtosis1 = { { kurtosis5 }, { ThresholdUpDownValue.Kurtosis_Up }, { ThresholdUpDownValue.Kurtosis_Down } };
                            realMonitorCollection.waveformGraph2.PlotYAppendMultiple(temp_kurtosis1, 0, 1 / channelParameterConfig.Resolution1);
                           // realMonitorCollection.waveformGraph1.PlotYAppend(kurtosis1);
                            double kurtosis6 = VibrationAlgorithm.CalculateParasQuShi(mydata[1])[6];
                            realMonitorCollection.RightFrontSecondValue.Text = kurtosis6.ToString("f9");
                             double[,] temp_kurtosis3 = { { kurtosis6 }, { ThresholdUpDownValue.Kurtosis_Up }, { ThresholdUpDownValue.Kurtosis_Down } };
                             realMonitorCollection.waveformGraph4.PlotYAppendMultiple(temp_kurtosis3, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph3.PlotYAppend(kurtosis2);
                            double kurtosis7 = VibrationAlgorithm.CalculateParasQuShi(mydata[2])[6];
                            realMonitorCollection.LeftBehindSecondValue.Text = kurtosis7.ToString("f9");
                             double[,] temp_kurtosis5 = { { kurtosis7 }, { ThresholdUpDownValue.Kurtosis_Up }, { ThresholdUpDownValue.Kurtosis_Down } };
                             realMonitorCollection.waveformGraph6.PlotYAppendMultiple(temp_kurtosis5, 0, 1 / channelParameterConfig.Resolution1);
                         //   realMonitorCollection.waveformGraph5.PlotYAppend(kurtosis3);
                            double kurtosis8 = VibrationAlgorithm.CalculateParasQuShi(mydata[3])[6];
                            realMonitorCollection.RightBehindSecondValue.Text = kurtosis8.ToString("f9");
                             double[,] temp_kurtosis7 = { { kurtosis8 }, { ThresholdUpDownValue.Kurtosis_Up }, { ThresholdUpDownValue.Kurtosis_Down } };
                             realMonitorCollection.waveformGraph8.PlotYAppendMultiple(temp_kurtosis7, 0, 1 / channelParameterConfig.Resolution1);
                          
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterTwo.Add(kurtosis5);
                                TwoChannnelCharacterTwo.Add(kurtosis6);
                                ThreeChannnelCharacterTwo.Add(kurtosis7);
                                FourChannnelCharacterTwo.Add(kurtosis8);
                            }
                            break;

                        case "峰度":
                            double peak5 = VibrationAlgorithm.CalculateParasQuShi(mydata[0])[3];
                            realMonitorCollection.LeftFrontSecondValue.Text = peak5.ToString("f9");
                            double[,] temp_peak1 = { { peak5 }, { ThresholdUpDownValue.Peak_Up }, { ThresholdUpDownValue.Peak_Down } };
                            realMonitorCollection.waveformGraph2.PlotYAppendMultiple(temp_peak1, 0, 1 / channelParameterConfig.Resolution1);
                         //   realMonitorCollection.waveformGraph1.PlotYAppend(peak1);
                            double peak6 = VibrationAlgorithm.CalculateParasQuShi(mydata[1])[3];
                            realMonitorCollection.RightFrontSecondValue.Text = peak6.ToString("f9");
                            double[,] temp_peak3 = { { peak6 }, { ThresholdUpDownValue.Peak_Up }, { ThresholdUpDownValue.Peak_Down } };
                            realMonitorCollection.waveformGraph4.PlotYAppendMultiple(temp_peak3, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph3.PlotYAppend(peak2);
                            double peak7 = VibrationAlgorithm.CalculateParasQuShi(mydata[2])[3];
                            realMonitorCollection.LeftBehindSecondValue.Text = peak7.ToString("f9");
                            double[,] temp_peak5 = { { peak7 }, { ThresholdUpDownValue.Peak_Up }, { ThresholdUpDownValue.Peak_Down } };
                            realMonitorCollection.waveformGraph6.PlotYAppendMultiple(temp_peak5, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph5.PlotYAppend(peak3);
                            double peak8 = VibrationAlgorithm.CalculateParasQuShi(mydata[3])[3];
                            realMonitorCollection.RightBehindSecondValue.Text = peak8.ToString("f9");
                            double[,] temp_peak7 = { { peak8 }, { ThresholdUpDownValue.Peak_Up }, { ThresholdUpDownValue.Peak_Down } };
                            realMonitorCollection.waveformGraph8.PlotYAppendMultiple(temp_peak7, 0, 1 / channelParameterConfig.Resolution1);
                          
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterTwo.Add(peak5);
                                TwoChannnelCharacterTwo.Add(peak6);
                                ThreeChannnelCharacterTwo.Add(peak7);
                                FourChannnelCharacterTwo.Add(peak8);
                            }
                            break;

                        case "峰值频率":
                            double frequency5 = NoiseCharacterValue.PeakFrequency(mydata[0], channelParameterConfig.SampleRate1);
                            realMonitorCollection.LeftFrontSecondValue.Text = frequency5.ToString("f9");
                            double[,] temp_frequency1 = { { frequency5 }, { ThresholdUpDownValue.Frequency_Up }, { ThresholdUpDownValue.Frequency_Down } };
                            realMonitorCollection.waveformGraph2.PlotYAppendMultiple(temp_frequency1, 0, 1 / channelParameterConfig.Resolution1);
                            // realMonitorCollection.waveformGraph1.PlotYAppend(frequency1);
                            double frequency6 = NoiseCharacterValue.PeakFrequency(mydata[1], channelParameterConfig.SampleRate1);
                            realMonitorCollection.RightFrontSecondValue.Text = frequency6.ToString("f9");
                            double[,] temp_frequency3 = { { frequency6 }, { ThresholdUpDownValue.Frequency_Up }, { ThresholdUpDownValue.Frequency_Down } };
                            realMonitorCollection.waveformGraph4.PlotYAppendMultiple(temp_frequency3, 0, 1 / channelParameterConfig.Resolution1);
                            // realMonitorCollection.waveformGraph3.PlotYAppend(frequency2);
                            double frequency7 = NoiseCharacterValue.PeakFrequency(mydata[2], channelParameterConfig.SampleRate1);
                            realMonitorCollection.LeftBehindSecondValue.Text = frequency7.ToString("f9");
                            double[,] temp_frequency5 = { { frequency7 }, { ThresholdUpDownValue.Frequency_Up }, { ThresholdUpDownValue.Frequency_Down } };
                            realMonitorCollection.waveformGraph6.PlotYAppendMultiple(temp_frequency5, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph5.PlotYAppend(frequency3);
                            double frequency8 = NoiseCharacterValue.PeakFrequency(mydata[3], channelParameterConfig.SampleRate1);
                            realMonitorCollection.RightBehindSecondValue.Text = frequency8.ToString("f9");
                            double[,] temp_frequency7 = { { frequency8 }, { ThresholdUpDownValue.Frequency_Up }, { ThresholdUpDownValue.Frequency_Down } };
                            realMonitorCollection.waveformGraph8.PlotYAppendMultiple(temp_frequency7, 0, 1 / channelParameterConfig.Resolution1);
                          
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterTwo.Add(frequency5);
                                TwoChannnelCharacterTwo.Add(frequency6);
                                ThreeChannnelCharacterTwo.Add(frequency7);
                                FourChannnelCharacterTwo.Add(frequency8);
                            }
                            break;

                        case "频率幅值":
                            Signal_FrequencySpectrum(mydata);
                            double frequencyA5 = FrequencyA[0];
                            realMonitorCollection.LeftFrontSecondValue.Text = frequencyA5.ToString("f9");
                            double[,] temp_frequencyA1 = { { frequencyA5 }, { ThresholdUpDownValue.FrequencyA_Up }, { ThresholdUpDownValue.FrequencyA_Down } };
                            realMonitorCollection.waveformGraph2.PlotYAppendMultiple(temp_frequencyA1, 0, 1 / channelParameterConfig.Resolution1);
                        //    realMonitorCollection.waveformGraph1.PlotYAppend(frequencyA1);
                            double frequencyA6 = FrequencyA[1];
                            realMonitorCollection.RightFrontSecondValue.Text = frequencyA6.ToString("f9");
                            double[,] temp_frequencyA3 = { { frequencyA6 }, { ThresholdUpDownValue.FrequencyA_Up }, { ThresholdUpDownValue.FrequencyA_Down } };
                            realMonitorCollection.waveformGraph4.PlotYAppendMultiple(temp_frequencyA3, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph3.PlotYAppend(frequencyA2);
                            double frequencyA7 = FrequencyA[2];
                            realMonitorCollection.LeftBehindSecondValue.Text = frequencyA7.ToString("f9");
                            double[,] temp_frequencyA5 = { { frequencyA7 }, { ThresholdUpDownValue.FrequencyA_Up }, { ThresholdUpDownValue.FrequencyA_Down } };
                            realMonitorCollection.waveformGraph6.PlotYAppendMultiple(temp_frequencyA5, 0, 1 / channelParameterConfig.Resolution1);
                          //  realMonitorCollection.waveformGraph5.PlotYAppend(frequencyA3);
                            double frequencyA8 = FrequencyA[3];
                            realMonitorCollection.RightBehindSecondValue.Text = frequencyA8.ToString("f9");
                            double[,] temp_frequencyA7 = { { frequencyA8 }, { ThresholdUpDownValue.FrequencyA_Up }, { ThresholdUpDownValue.FrequencyA_Down } };
                            realMonitorCollection.waveformGraph8.PlotYAppendMultiple(temp_frequencyA7, 0, 1 / channelParameterConfig.Resolution1);
                           
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterTwo.Add(frequencyA5);
                                TwoChannnelCharacterTwo.Add(frequencyA6);
                                ThreeChannnelCharacterTwo.Add(frequencyA7);
                                FourChannnelCharacterTwo.Add(frequencyA8);
                            }
                            break;

                        case "中心频率":
                            double octaveValue5 = VoiceOctave.octave(mydata[0], Convert.ToDouble(channelParameterConfig.SampleRate1), DataTempStorage.CenterFrequency1);
                            realMonitorCollection.LeftFrontSecondValue.Text = octaveValue5.ToString("f9");
                            double[,] temp_octaveValue1 = { { octaveValue5 }, { ThresholdUpDownValue.OctaveValue_Up }, { ThresholdUpDownValue.OctaveValue_Down } };
                            realMonitorCollection.waveformGraph2.PlotYAppendMultiple(temp_octaveValue1, 0, 1 / channelParameterConfig.Resolution1);
                            // realMonitorCollection.waveformGraph1.PlotYAppend(octaveValue1);
                            double octaveValue6 = VoiceOctave.octave(mydata[1], Convert.ToDouble(channelParameterConfig.SampleRate1), DataTempStorage.CenterFrequency1);
                            realMonitorCollection.LeftFrontSecondValue.Text = octaveValue6.ToString("f9");
                            double[,] temp_octaveValue3 = { { octaveValue6 }, { ThresholdUpDownValue.OctaveValue_Up }, { ThresholdUpDownValue.OctaveValue_Down } };
                            realMonitorCollection.waveformGraph4.PlotYAppendMultiple(temp_octaveValue3, 0, 1 / channelParameterConfig.Resolution1);
                            //  realMonitorCollection.waveformGraph3.PlotYAppend(octaveValue2);
                            double octaveValue7 = VoiceOctave.octave(mydata[2], Convert.ToDouble(channelParameterConfig.SampleRate1), DataTempStorage.CenterFrequency1);
                            realMonitorCollection.LeftFrontSecondValue.Text = octaveValue7.ToString("f9");
                            double[,] temp_octaveValue5 = { { octaveValue7 }, { ThresholdUpDownValue.OctaveValue_Up }, { ThresholdUpDownValue.OctaveValue_Down } };
                            realMonitorCollection.waveformGraph6.PlotYAppendMultiple(temp_octaveValue5, 0, 1 / channelParameterConfig.Resolution1);
                            //   realMonitorCollection.waveformGraph5.PlotYAppend(octaveValue3);
                            double octaveValue8 = VoiceOctave.octave(mydata[3], Convert.ToDouble(channelParameterConfig.SampleRate1), DataTempStorage.CenterFrequency1);
                            realMonitorCollection.LeftFrontSecondValue.Text = octaveValue8.ToString("f9");
                            double[,] temp_octaveValue7 = { { octaveValue8 }, { ThresholdUpDownValue.OctaveValue_Up }, { ThresholdUpDownValue.OctaveValue_Down } };
                            realMonitorCollection.waveformGraph8.PlotYAppendMultiple(temp_octaveValue7, 0, 1 / channelParameterConfig.Resolution1);
                            
                            if (SaveCharacterValue)
                            {
                                OneChannnelCharacterTwo.Add(octaveValue5);
                                TwoChannnelCharacterTwo.Add(octaveValue6);
                                ThreeChannnelCharacterTwo.Add(octaveValue7);
                                FourChannnelCharacterTwo.Add(octaveValue8);
                            }
                            break;
                    }
                }
                #endregion

          
            

        }
        #endregion
        private double[] ListToArray(List<double[]>list) {
            int length = list[0].GetLength(0);
            double[] result = new double[list.Count*length];
            int count=0;
            for (int i = 0; i < list.Count;i++ )
            {
                for (int j = 0; j < length; j++)
                {
                    result[count++] = list[i][j];
                }
            }
            return result;

        }

        public void SaveSingleData1(string insert_sql, DateTime sampletime, byte[] channelone, byte[] channeltwo, byte[] channelthree, byte[] channelfour, byte[] channelfive, byte[] channelsix, byte[] channelseven,byte[]channeleight)
        {
           // my = new MysqlHelper();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@sampletime", sampletime);
            dic.Add("@channelone", channelone);
            dic.Add("@channeltwo", channeltwo);
            dic.Add("@channelthree", channelthree);
            dic.Add("@channelfour", channelfour);
            dic.Add("@channelfive", channelfive);
            dic.Add("@channelsix", channelsix);
            dic.Add("@channelseven", channelseven);
            dic.Add("@channeleight", channeleight);
            if (!helper.MySqlPour(insert_sql, dic)) { MessageBox.Show("失败"); }
        }

        public void SaveCharacter(string insert_sql, DateTime sampletime, byte[] VibrationOneChannelCharacterOne, byte[] VibrationOneChannelCharacterTwo, byte[] VibrationTwoChannelCharacterOne, byte[] VibrationTwoChannelCharacterTwo, byte[] VibrationThreeChannelCharacterOne, byte[] VibrationThreeChannelCharacterTwo, byte[] VibrationFourChannelCharacterOne, byte[] VibrationFourChannelCharacterTwo) 
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@sampletime", sampletime);
            dic.Add("@VibrationOneChannelCharacterOne", VibrationOneChannelCharacterOne);
            dic.Add("@VibrationOneChannelCharacterTwo", VibrationOneChannelCharacterTwo);
            dic.Add("@VibrationTwoChannelCharacterOne", VibrationTwoChannelCharacterOne);
            dic.Add("@VibrationTwoChannelCharacterTwo", VibrationTwoChannelCharacterTwo);
            dic.Add("@VibrationThreeChannelCharacterOne", VibrationThreeChannelCharacterOne);
            dic.Add("@VibrationThreeChannelCharacterTwo", VibrationThreeChannelCharacterTwo);
            dic.Add("@VibrationFourChannelCharacterOne", VibrationFourChannelCharacterOne);
            dic.Add("@VibrationFourChannelCharacterTwo", VibrationFourChannelCharacterTwo);
           
            if (!helper.MySqlPour(insert_sql, dic)) { MessageBox.Show("失败"); }
        }

        


        public void SaveAllToMysql(string insert_sql, string ProductModel, string WheelSetSerialNumber, string BearingType, string BearingNumber, string TestBench, string Factory
            , DateTime TestTime, string Users, int SamplingFrequency, double SamplingDuration, string WindowType, string AverageMode, byte[] DataValue, string TestStatus, string ResultStatus
            , string StasticOne, byte[] StasticDataOne, string StasticSecond, byte[] StasticDataSecond) 
        {
            my = new MysqlHelper();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@ProductModel", ProductModel);
            dic.Add("@WheelSetSerialNumber", WheelSetSerialNumber);
            dic.Add("@BearingType", BearingType);
            dic.Add("@BearingNumber", BearingNumber);
            dic.Add("@TestBench", TestBench);
            dic.Add("@Factory", Factory);
            dic.Add("@TestTime", TestTime);
            dic.Add("@Users", Users);
            dic.Add("@SamplingFrequency", SamplingFrequency);
            dic.Add("@SamplingDuration", SamplingDuration);
            dic.Add("@WindowType", WindowType);
            dic.Add("@AverageMode", AverageMode);
            dic.Add("@DataValue", DataValue);
            dic.Add("@TestStatus", TestStatus);
            dic.Add("@ResultStatus", ResultStatus);
            dic.Add("@StasticOne", StasticOne);
            dic.Add("@StasticDataOne", StasticDataOne);
            dic.Add("@StasticSecond", StasticSecond);
            dic.Add("@StasticDataSecond", StasticDataSecond);
            if (!my.MySqlPour(insert_sql, dic)) { MessageBox.Show("失败"); }
        }

   
        #region
        /// <summary>
        /// 播放声音
        /// </summary>
        /// <param name="temp">一维声波数组</param>
        /// <param name="filePath">声音路径</param>
        public void PlayNoise(double[] temp,string filePath) {
          //  WaveGenerator wave = new WaveGenerator(temp,25600);
            WavGenerate.WaveGenerate(temp, filePath,Convert.ToDouble( DataTempStorage.AnalysisBandWidth1));
            try
            {
                sndPlayer = new System.Media.SoundPlayer(filePath);
                sndPlayer.Play();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
        //保存声音数据
        private void SaveNoise(double[] temp, string filePath)
        {
            WavGenerate.WaveGenerate(temp, filePath, Convert.ToDouble(DataTempStorage.AnalysisBandWidth1));
        }
        //播放声音数据
        private void PlayNoise(string filePath)
        {
            try
            {
                sndPlayer = new System.Media.SoundPlayer(filePath);
                sndPlayer.Play();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #region 振动信号方法区
        #region 加速度信号显示处理方法
        private double[][] Signal_AcceleratedSpeed(double[][] mydata)
        {
            double dt = 1 / Convert.ToDouble(channelParameterConfig.SampleRate1);
            return mydata;
        }
        #endregion

        #region 速度信号显示处理方法
        private double[][] Signal_Velocity(double[][] mydata,double dt)
        {
            double[][] result=new double[mydata.Length][];
            
            for (int i = 0; i < mydata.Length; i++)
            {
                result[i]=new double[mydata[0].Length];
                for (int j = 0; j < mydata[0].Length; j++)
                {
                    for (int k = 0; k <= j; k++)
                    {
                        result[i][j] +=  mydata[i][k] * dt ;
                    }
                }
            }
          
            return result;
        }

        private double[] Signal_Velocity(double[] mydata) 
        {
            double[] result = new double[mydata.Length];
            double dt = 1 / Convert.ToDouble(DataTempStorage.TempVibrationSampleFrequency1);
            for (int j = 0; j < mydata.Length; j++)
            {
                for (int k = 0; k <= j; k++)
                {
                    result[j] +=  mydata[k] * dt ;
                }
            }
            return result;
        }
        #endregion

        #region 位移信号显示处理方法
        private double[][] Signal_Displacement(double[][] mydata,double dt)
        {
            double[][] result = new double[mydata.Length][];
            for (int i = 0; i < mydata.Length; i++)
            {
               result[i]=new double[mydata[0].Length];
                for (int j = 0; j < mydata[0].Length; j++)
                {
                    for (int k = 0; k <= j; k++)
                    {
                        mydata[i][j] +=mydata[i][k] *dt *dt;
                    }
                }
            }
         
            return mydata;
        }

        private double[] Signal_Displacement(double[] mydata) {

            double[] result = new double[mydata.Length];
            double dt = 1 / Convert.ToDouble(DataTempStorage.TempVibrationSampleFrequency1);
            for (int j = 0; j < mydata.Length; j++)
            {
                for (int k = 0; k <= j; k++)
                {
                    result[j] += 0.5 * mydata[k] * dt * dt;
                }
            }
            return result;
        }
        #endregion

        #region 频谱信号显示处理方法
        private double[][] Signal_FrequencySpectrum(double[][] mydata)
        {
            int DisplayWidth=(int)(channelParameterConfig.AnalysisBandWidth1 / channelParameterConfig.Resolution1);
            Complex[] Results = new Complex[mydata[0].Length];
            double[][]result=new double[mydata.Length][];

            mydata = WindowFunctionSelected(mydata, channelParameterConfig.WindowsFunction1, mydata[0].Length);
            for (int i = 0; i < mydata.Length; i++)
            {
                result[i] = new double[DisplayWidth];
                Results = DigitalSignalProcessing.NiSignalProcessing.FFT(mydata[i]);
              //  System.Threading.Tasks.Parallel.For(0, DisplayWidth, j => result[i][j] = 2 * (Results[j].GetModul() / mydata[0].Length));

                for (int j = 0; j < DisplayWidth; j++)
                {
                    result[i][j] = 2 * (Results[j].GetModul() / mydata[0].Length);
                    if(j==DataTempStorage.FrequencyAmplitude1){
                        FrequencyA[i]=result[i][j];
                    }
                }
            }

            return result;
        }

        private double[] Signal_FrequencySpectrum(double [] mydata) {

            double[] result = new double[mydata.Length/2];
            Complex[] Results = new Complex[mydata.Length];
            Results = DigitalSignalProcessing.NiSignalProcessing.FFT(mydata);
            for (int i = 0; i < mydata.Length/2;i++ )
            {
                result[i] = Results[i].GetModul()/mydata.Length;
            }
            return result;
        }
        #endregion
        #endregion
        #region 声音信号方法区
        #region 原始声音信号
        private double[][] Signal_N_Vioce(double[][] mydata,double dt)
        {
            for (int i = 0; i < mydata.Length;i++ )
            {
                for (int j = 0; j < mydata[0].Length;j++ )
                {
                    mydata[i][j] = mydata[i][j]/channelParameterConfig.Sensitivity1;
                   // mydata[i][j] = mydata[i][j] / 40.9;

                }
            }
            NoisyPlot(mydata[0], mydata[1], mydata[2], mydata[3], 0, dt);
            
            return mydata;
        }
        #endregion
        #region 声音频谱信号
        private double[][] Signal_N_Frequency(double[][] mydata,double dt)
        {
            int DisplayWidth = (int)(channelParameterConfig.AnalysisBandWidth1 / channelParameterConfig.Resolution1);
            Complex[] Results = new Complex[mydata[0].Length];
            double[][] result = new double[mydata.Length][];
            mydata = WindowFunctionSelected(mydata, channelParameterConfig.WindowsFunction1, mydata[0].Length);
            for (int i = 0; i < mydata.Length;i++ )
            {
                for (int j = 0; j < mydata[0].Length;j++ )
                {
                    mydata[i][j] = mydata[i][j] / channelParameterConfig.Sensitivity1;
                }
            }

            for (int i = 0; i < mydata.Length; i++)
            {
                result[i] = new double[DisplayWidth];
                Results = DigitalSignalProcessing.NiSignalProcessing.FFT(mydata[i]);

              //  System.Threading.Tasks.Parallel.For(0,DisplayWidth,j=>result[i][j] =Math.Log10( 2 * (Results[j].GetModul() / mydata[0].Length)/0.00001));

                for (int j = 0; j < DisplayWidth; j++)
                {
                   // result[i][j] =2* Math.Log10( (Results[j].GetModul() / mydata[0].Length) / 0.00001);
                    result[i][j] =20*Math.Log10( 2 * (Results[j].GetModul() / mydata[0].Length)/0.00002);
                }
            }
            NoisyPlot(result[0], result[1], result[2], result[3], 0, dt);
            return mydata;
        }

        private double[] Signal_N_Frequency(double[] mydata) {
            Complex[] Results = new Complex[mydata.Length];
            Results = DigitalSignalProcessing.NiSignalProcessing.FFT(mydata);
            double [] result=new double[mydata.Length/2];
            for (int j = 0; j < mydata.Length/2; j++)
            {
                result[j] =20*Math.Log10(2*(Results[j].GetModul() / mydata.Length)/0.00002);
            }
            return result;
        }
        #endregion

        #region 声音倍频程信号
        private double[][] Signal_N_Octave(double[][] mydata,double dt)
        {
            //数据处理区
            //数据处理区
            ArrayList f_oct_1 = new ArrayList();
            ArrayList f_oct_2 = new ArrayList();
            ArrayList f_oct_3 = new ArrayList();
            ArrayList f_oct_4 = new ArrayList();

            ArrayList y_oct_1 = new ArrayList();
            ArrayList y_oct_2 = new ArrayList();
            ArrayList y_oct_3 = new ArrayList();
            ArrayList y_oct_4 = new ArrayList();
            ruishen.声音算法代码.VoiceOctave.octave(mydata[0], Convert.ToDouble(channelParameterConfig.SampleRate1),out f_oct_1,out y_oct_1);
            ruishen.声音算法代码.VoiceOctave.octave(mydata[1], Convert.ToDouble(channelParameterConfig.SampleRate1),out f_oct_2, out y_oct_2);
            ruishen.声音算法代码.VoiceOctave.octave(mydata[2], Convert.ToDouble(channelParameterConfig.SampleRate1), out f_oct_3,out y_oct_3);
            ruishen.声音算法代码.VoiceOctave.octave(mydata[3], Convert.ToDouble(channelParameterConfig.SampleRate1),out f_oct_4,out y_oct_4);
            double[] temp_1 = new double[y_oct_1.Count];
            double[] temp_2 = new double[y_oct_2.Count];
            double[] temp_3 = new double[y_oct_3.Count];
            double[] temp_4 = new double[y_oct_4.Count];

            double[] f_temp_1 = new double[f_oct_1.Count];
            double[] f_temp_2 = new double[f_oct_2.Count];
            double[] f_temp_3 = new double[f_oct_3.Count];
            double[] f_temp_4 = new double[f_oct_4.Count];
            for (int i = 0; i < y_oct_1.Count; i++)
            {
                temp_1[i] = (double)y_oct_1[i];
                temp_2[i] = (double)y_oct_2[i];
                temp_3[i] = (double)y_oct_3[i];
                temp_4[i] = (double)y_oct_4[i];

            }
            for (int i = 0; i < f_oct_1.Count; i++)
            {
                f_temp_1[i] = (double)f_oct_1[i];
                f_temp_2[i] = (double)f_oct_2[i];
                f_temp_3[i] = (double)f_oct_3[i];
                f_temp_4[i] = (double)f_oct_4[i];

            }
            NoisyPlot(temp_1, temp_2, temp_3, temp_4, 0, dt, f_temp_1);
            return mydata;
        }
        #endregion

        #region 声音A计权
        private double[][] Signal_N_AWeighting(double[][] mydata)
        {
            double dt=0.02;
            double[] temp_1 = ruishen.声音算法代码.VoiceOctave.awdgn2(mydata[0], channelParameterConfig.SampleRate1);
            double[] temp_2 = ruishen.声音算法代码.VoiceOctave.awdgn2(mydata[1], channelParameterConfig.SampleRate1);
            double[] temp_3 = ruishen.声音算法代码.VoiceOctave.awdgn2(mydata[2], channelParameterConfig.SampleRate1);
            double[] temp_4 = ruishen.声音算法代码.VoiceOctave.awdgn2(mydata[3], channelParameterConfig.SampleRate1);
           
            NoisyPlot(temp_1,temp_2,temp_3,temp_4,0,dt);
            return mydata;
        }
        #endregion

        private void Voice_dataSearch_Click(object sender, EventArgs e)
        {
            #region 进行窗体添加，把窗体加载到MainPanel中进行显示
            MainPanel.Controls.Clear();
            ruishen.声音分析.NoiseDataSearch dataSearch = GenericSingleton<ruishen.声音分析.NoiseDataSearch>.CreateInstrance();
            dataSearch.Dock = DockStyle.Fill;
            dataSearch.TopLevel = false;
            dataSearch.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MainPanel.Controls.Add(dataSearch);
            dataSearch.Show();
            #endregion

        }
        #endregion
        #region 频谱按钮点击
        private void Voice_FrequencySpectrum_Click(object sender, EventArgs e)
        {
            #region 声音频谱窗体基础设置
            MainPanel.Controls.Clear();
            dataAnalysisCommonForm = GenericSingleton<ruishen.公共中间量.DataAnalysisCommonForm>.CreateInstrance();
            dataAnalysisCommonForm.Dock = DockStyle.Fill;
            dataAnalysisCommonForm.TopLevel = false;
            dataAnalysisCommonForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            #endregion

            try
            {
                double[] noiseData = new double[DataTempStorage.TempNoiseData1.Length];
                noiseData = DataTempStorage.TempNoiseData1;
                noiseData = Signal_N_Frequency(noiseData);
                dataAnalysisCommonForm.sampleWaveformGraph.PlotY(noiseData, 0, ((double)DataTempStorage.TempNoiseSampleFrequency1)/noiseData.Length/2);
            }

            catch (Exception ex)
            {
                MessageBox.Show("数据不能为空，请加载数据后再处理");
            }
            dataAnalysisCommonForm.plot.FillMode = NationalInstruments.UI.PlotFillMode.None;
            dataAnalysisCommonForm.plot.LineStep = NationalInstruments.UI.LineStep.None;
            MainPanel.Controls.Add(dataAnalysisCommonForm);
            dataAnalysisCommonForm.sampleWaveformGraph.Caption = "频谱";
            dataAnalysisCommonForm.sampleWaveformGraph.XAxes[0].Caption = "Frequency/Hz";
            dataAnalysisCommonForm.sampleWaveformGraph.YAxes[0].Caption = "SoundPressure/Pa";
            dataAnalysisCommonForm.Show();
        }
        #endregion
        #region 画图
        //振动信号画图
        /*
         * DataTempStorage.ChannelNumber1=1 代表左前轮振动按钮点击
         * DataTempStorage.ChannelNumber1=2 代表右前轮振动按钮点击
         * DataTempStorage.ChannelNumber1=3 代表左后轮振动按钮点击
         * DataTempStorage.ChannelNumber1=4 代表右后轮振动按钮点击
         */
      
        private void VibrationPlot(double[] temp_1, double[] temp_2, double[] temp_3, double[] temp_4, double start, double dt, string algorithmStyle)
        {
          
            vibrationMonitor.Vibration_WaveformGraph4.PlotY(temp_4, 0, dt);
            vibrationMonitor.Vibration_WaveformGraph3.PlotY(temp_3, 0, dt);
            vibrationMonitor.Vibration_WaveformGraph2.PlotY(temp_2, 0, dt);
            vibrationMonitor.Vibration_WaveformGraph1.PlotY(temp_1, 0, dt);
        }
       
        private double smallFormInit(double[] temp, string algorithmStyle,int channelNumber)
        {
            double result = 0; ;
            switch (algorithmStyle)
            {
                case "": break;
                case "上四分位":result= NoiseCharacterValue.up_Quartile(temp); break;
                case "下四分位":result=NoiseCharacterValue.down_Quartile(temp) ; break;
                case "中位数":result=NoiseCharacterValue.Median(temp) ; break;
                case"四分位距":result=NoiseCharacterValue.distance_Quartile(temp);break;
                case "上界":result=NoiseCharacterValue.upper_bound(temp) ; break;
                case "下界": result=NoiseCharacterValue.down_Quartile(temp); break;
                case "均值": result = VibrationAlgorithm.CalculateParasQuShi(temp)[0]; break;
                case "方差": result = VibrationAlgorithm.CalculateParasQuShi(temp)[7]; ; break;
                case "均方根值": result = VibrationAlgorithm.CalculateParasQuShi(temp)[1]; ; break;
                case "歪度": result = VibrationAlgorithm.CalculateParasQuShi(temp)[5]; ; break;
                case "峭度": result = VibrationAlgorithm.CalculateParasQuShi(temp)[6]; ; break;
                case "峰度": result = VibrationAlgorithm.CalculateParasQuShi(temp)[3]; ; break;
                case "频率幅值":result=FrequencyA[channelNumber-1] ; break;
                case "频率重心": ; break;
                case "峰值频率": ; break;
                case "中心频率":result=VoiceOctave.octave(temp,channelParameterConfig.SampleRate1,DataTempStorage.CenterFrequency1) ; break;
            }
            return result;
        }
        //声音信号画图
        private void NoisyPlot(double[] temp_1, double[] temp_2, double[] temp_3, double[] temp_4,double start,double dt,double[] y) 
        {
           
          //  int count=1;
            noisyMonitor.scatterGraph1.PlotXY(y,temp_1);
          //  noisyMonitor.Noisy_WaveformGraph1.PlotY(temp_1,y[0],y[count++]);
          //  count = 1;
            noisyMonitor.scatterGraph2.PlotXY(y,temp_2);
          //  noisyMonitor.Noisy_WaveformGraph2.PlotY(temp_2, y[0], y[count++]);
          //  count = 1;
            noisyMonitor.scatterGraph3.PlotXY(y,temp_3);
           
           // noisyMonitor.Noisy_WaveformGraph3.PlotY(temp_3, y[0], y[count++]);
          //  count = 1;
            noisyMonitor.scatterGraph4.PlotXY(y,temp_4);
          
           // noisyMonitor.Noisy_WaveformGraph4.PlotY(temp_4, y[0], y[count++]);
          //  count = 1;
        }
        private void NoisyPlot(double[] temp_1, double[] temp_2, double[] temp_3, double[] temp_4, double start, double dt)
        {
            // noisyMonitor.Noisy_WaveformGraph1.PlotY(temp_1,start,dt);
           
            noisyMonitor.Noisy_WaveformGraph1.PlotY(temp_1,start,dt);
           
            // noisyMonitor.Noisy_WaveformGraph1.PlotXAppend();
            noisyMonitor.Noisy_WaveformGraph2.PlotY(temp_2, start, dt);
            noisyMonitor.Noisy_WaveformGraph3.PlotY(temp_3, start, dt);
            noisyMonitor.Noisy_WaveformGraph4.PlotY(temp_4, start, dt);
        }
        #endregion
        //振动加速度按钮点击事件
        private void Vibration_AcceleratedSpeed_Click(object sender, EventArgs e)
        {
            #region 加速度信号窗体基础设置
            MainPanel.Controls.Clear();
            dataAnalysisCommonForm = GenericSingleton<ruishen.公共中间量.DataAnalysisCommonForm>.CreateInstrance();
            dataAnalysisCommonForm.Dock = DockStyle.Fill;
            dataAnalysisCommonForm.TopLevel = false;
            dataAnalysisCommonForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            
            #endregion
            try
            {
               
                dataAnalysisCommonForm.sampleWaveformGraph.PlotY(DataTempStorage.TempVibrationData1, 0, (double)1 / DataTempStorage.TempVibrationSampleFrequency1);
            }
            catch (Exception)
            {
                MessageBox.Show("数据不能为空，请加载数据后再处理");
            }
            MainPanel.Controls.Add(dataAnalysisCommonForm);
            dataAnalysisCommonForm.sampleWaveformGraph.Caption = "加速度";
            dataAnalysisCommonForm.sampleWaveformGraph.XAxes[0].Caption = "Time/s";
            dataAnalysisCommonForm.sampleWaveformGraph.YAxes[0].Caption = "Acceleration/g";
            dataAnalysisCommonForm.Show();
           
        }
        //振动位移按钮点击
        private void Vibration_Displacement_Click(object sender, EventArgs e)
        {

            #region 位移信号窗体基础设置
            MainPanel.Controls.Clear();
            dataAnalysisCommonForm = GenericSingleton<ruishen.公共中间量.DataAnalysisCommonForm>.CreateInstrance();
            dataAnalysisCommonForm.Dock = DockStyle.Fill;
            dataAnalysisCommonForm.TopLevel = false;
            dataAnalysisCommonForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            #endregion

            try
            {
                double[] displacementData = new double[DataTempStorage.TempVibrationData1.Length];
                displacementData = DataTempStorage.TempVibrationData1;
                displacementData = Signal_Displacement(DataTempStorage.TempVibrationData1);
                dataAnalysisCommonForm.sampleWaveformGraph.PlotY(displacementData,0,1);
            }

            catch (Exception)
            {
                MessageBox.Show("数据不能为空，请加载数据后再处理");
            }

            MainPanel.Controls.Add(dataAnalysisCommonForm);
            dataAnalysisCommonForm.sampleWaveformGraph.Caption = "位移";
            dataAnalysisCommonForm.Show();
        }

        private void Vibration_Velocity_Click(object sender, EventArgs e)
        {
            #region 速度信号窗体基础设置
            MainPanel.Controls.Clear();
            dataAnalysisCommonForm = GenericSingleton<ruishen.公共中间量.DataAnalysisCommonForm>.CreateInstrance();
            dataAnalysisCommonForm.Dock = DockStyle.Fill;
            dataAnalysisCommonForm.TopLevel = false;
            dataAnalysisCommonForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
          
            #endregion
            #region 算法处理，进行傅里叶变换
            try
            {
                
                double[] velocityData = new double[DataTempStorage.TempVibrationData1.Length];
                velocityData = DataTempStorage.TempVibrationData1;
                velocityData = Signal_Velocity(velocityData);
                dataAnalysisCommonForm.sampleWaveformGraph.PlotY(velocityData,0,1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据不能为空，请加载数据后再处理");
            }
            #endregion
            
            MainPanel.Controls.Add(dataAnalysisCommonForm);
            dataAnalysisCommonForm.sampleWaveformGraph.Caption = "速度";
            dataAnalysisCommonForm.Show();
        }

        private void ribbonControl1_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
        #region 声音按钮点击
        private void Voice_voice_Click(object sender, EventArgs e)
        {
            #region 声音信号窗体基础设置
            MainPanel.Controls.Clear();
            dataAnalysisCommonForm = GenericSingleton<ruishen.公共中间量.DataAnalysisCommonForm>.CreateInstrance();
            dataAnalysisCommonForm.Dock = DockStyle.Fill;
            dataAnalysisCommonForm.TopLevel = false;
            dataAnalysisCommonForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            dataAnalysisCommonForm.axWindowsMediaPlayer1.Visible = false;
            dataAnalysisCommonForm.sampleWaveformGraph.XAxes[0].Caption = "Time/s";
            #endregion

            try
            {
                double[] noiseData = new double[DataTempStorage.TempNoiseData1.Length];
                noiseData = DataTempStorage.TempNoiseData1;
                double dt = 1 / Convert.ToDouble(DataTempStorage.TempNoiseSampleFrequency1);
                dataAnalysisCommonForm.sampleWaveformGraph.PlotY(noiseData, 0, dt);
            }

            catch (Exception ex)
            {
                MessageBox.Show("数据不能为空，请加载数据后再处理");
            }
            dataAnalysisCommonForm.plot.FillMode = NationalInstruments.UI.PlotFillMode.None;
            dataAnalysisCommonForm.plot.LineStep = NationalInstruments.UI.LineStep.None;
            MainPanel.Controls.Add(dataAnalysisCommonForm);
            dataAnalysisCommonForm.sampleWaveformGraph.Caption = "声音";
            dataAnalysisCommonForm.Show();
        }
        #endregion
        #region 声音倍频程按钮点击
        private void Voice_Multiplier_Click(object sender, EventArgs e)
        {
            #region 声音倍频程窗体基础设置
            MainPanel.Controls.Clear();
            dataAnalysisCommonForm = GenericSingleton<ruishen.公共中间量.DataAnalysisCommonForm>.CreateInstrance();
            dataAnalysisCommonForm.Dock = DockStyle.Fill;
            dataAnalysisCommonForm.TopLevel = false;
            dataAnalysisCommonForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            #endregion
           
            try
            {
                double[] noiseData = new double[DataTempStorage.TempNoiseData1.Length];
                noiseData = DataTempStorage.TempNoiseData1;
                ArrayList list_f_oct;
                ArrayList list_y_oct;
                VoiceOctave.octave(noiseData, (double)DataTempStorage.TempNoiseSampleFrequency1, out list_f_oct, out list_y_oct);
                double[] result_f = new double[list_f_oct.Count];  //中心频率
                for (int i = 0; i < result_f.Length; i++)
                {
                    result_f[i] =20*Math.Log10( (double)list_f_oct[i]/(2*Math.Pow(10,-5)));
                }
                double[] result_y = new double[list_f_oct.Count];  //中心频率对应的赋值
                for (int i = 0; i < result_y.Length; i++)
                {
                    result_y[i] = 20 * Math.Log10((double)list_f_oct[i] / (2 * Math.Pow(10, -5)));
                }
              // dataAnalysisCommonForm.sampleWaveformGraph.
              //  dataAnalysisCommonForm.sampleWaveformGraph.PlotY(result_y,result_f[0],result_f);
             
               // dataAnalysisCommonForm.sampleWaveformGraph.PlotX(result_f);
               // dataAnalysisCommonForm.plot.;

            }

            catch (Exception ex)
            {
                MessageBox.Show("数据不能为空，请加载数据后再处理");
            }
          
            dataAnalysisCommonForm.plot.FillMode = NationalInstruments.UI.PlotFillMode.FillAndLines;
            dataAnalysisCommonForm.plot.LineStep = NationalInstruments.UI.LineStep.XYStep;
            MainPanel.Controls.Add(dataAnalysisCommonForm);
            dataAnalysisCommonForm.sampleWaveformGraph.Caption = "倍频程";
            dataAnalysisCommonForm.Show();
        }
        #endregion
        #region 声音A计权按钮点击
        private void Voice_AWeighting_Click(object sender, EventArgs e)
        {
            #region A计权窗体基础设置
            MainPanel.Controls.Clear();
            dataAnalysisCommonForm = GenericSingleton<ruishen.公共中间量.DataAnalysisCommonForm>.CreateInstrance();
            dataAnalysisCommonForm.Dock = DockStyle.Fill;
            dataAnalysisCommonForm.TopLevel = false;
            dataAnalysisCommonForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            #endregion

            try
            {
                double[] noiseData = new double[DataTempStorage.TempNoiseData1.Length];
                noiseData = DataTempStorage.TempNoiseData1;
                double fs =(double) DataTempStorage.TempNoiseSampleFrequency1;
                double[] result =ruishen.声音算法代码.VoiceOctave.awdgn2(noiseData,fs);
                dataAnalysisCommonForm.sampleWaveformGraph.PlotY(result,0,0.02);
            }

            catch (Exception ex)
            {
                MessageBox.Show("数据不能为空，请加载数据后再处理");
            }

            dataAnalysisCommonForm.plot.FillMode = NationalInstruments.UI.PlotFillMode.FillAndLines;
            dataAnalysisCommonForm.plot.LineStep = NationalInstruments.UI.LineStep.XYStep;
            MainPanel.Controls.Add(dataAnalysisCommonForm);
            dataAnalysisCommonForm.sampleWaveformGraph.Caption = "A计权";
            dataAnalysisCommonForm.Show();

        }
        #endregion

        private void Vibration_TimeFrequencySpectrum_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            ruishen.振动分析.VibrationSTFT stft = new 振动分析.VibrationSTFT();
            stft.Dock = DockStyle.Fill;
            stft.TopLevel = false;
            stft.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MainPanel.Controls.Add(stft);
            stft.Show();
        }

        private void Voice_echo_Click(object sender, EventArgs e)
        {
            #region 声音回听窗体基础设置
            if (DataTempStorage.Recallcount1==0)
            {
                MainPanel.Controls.Clear();
                dataAnalysisCommonForm = GenericSingleton<ruishen.公共中间量.DataAnalysisCommonForm>.CreateInstrance();
                dataAnalysisCommonForm.Dock = DockStyle.Fill;
                dataAnalysisCommonForm.TopLevel = false;
                dataAnalysisCommonForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                dataAnalysisCommonForm.axWindowsMediaPlayer1.Visible = true;
                dataAnalysisCommonForm.sampleWaveformGraph.XAxes[0].Caption = "Time/s";
            #endregion

                try
                {
                    double[] noiseDataRecall = new double[DataTempStorage.TempNoiseData1.Length];
                    noiseDataRecall = DataTempStorage.TempNoiseData1;

                    double[] result = WavGenerate.WaveGenerate(noiseDataRecall, @"..//..//bin//Debug//music//" + DataTempStorage.MusicLoadId1.ToString() + ".wav", DataTempStorage.TempNoiseSampleFrequency1 / 2.5);
                    double dt = 1 / Convert.ToDouble(DataTempStorage.TempNoiseSampleFrequency1);
                    dataAnalysisCommonForm.sampleWaveformGraph.PlotY(result, 0, dt);
                    DataTempStorage.Recallcount1 = 1;
                }

                catch (Exception )
                {
                    MessageBox.Show("声音数据处理错误！");
                }
                dataAnalysisCommonForm.plot.FillMode = NationalInstruments.UI.PlotFillMode.None;
                dataAnalysisCommonForm.plot.LineStep = NationalInstruments.UI.LineStep.XYStep;
                MainPanel.Controls.Add(dataAnalysisCommonForm);
                dataAnalysisCommonForm.sampleWaveformGraph.Caption = "声音信号";
                dataAnalysisCommonForm.Show();

            }
            else
            {
                MainPanel.Controls.Clear();
                dataAnalysisCommonForm = GenericSingleton<ruishen.公共中间量.DataAnalysisCommonForm>.CreateInstrance();
                dataAnalysisCommonForm.Dock = DockStyle.Fill;
                dataAnalysisCommonForm.TopLevel = false;
                dataAnalysisCommonForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                dataAnalysisCommonForm.axWindowsMediaPlayer1.Visible = true;
                dataAnalysisCommonForm.sampleWaveformGraph.XAxes[0].Caption = "Time/s";
                dataAnalysisCommonForm.plot.FillMode = NationalInstruments.UI.PlotFillMode.None;
                dataAnalysisCommonForm.plot.LineStep = NationalInstruments.UI.LineStep.XYStep;
                MainPanel.Controls.Add(dataAnalysisCommonForm);
                dataAnalysisCommonForm.sampleWaveformGraph.Caption = "声音信号";
                double dt = 1 / Convert.ToDouble(DataTempStorage.TempNoiseSampleFrequency1);
                dataAnalysisCommonForm.sampleWaveformGraph.PlotY(DataTempStorage.TempNoiseData1, 0, dt);
                dataAnalysisCommonForm.Show();
            }
            
            
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            #region 进行窗体添加，把窗体加载到MainPanel中进行显示
            MainPanel.Controls.Clear();
            ruishen.数据管理.DataSearch dataSearch = GenericSingleton<ruishen.数据管理.DataSearch>.CreateInstrance();
            dataSearch.Dock = DockStyle.Fill;
            dataSearch.TopLevel = false;
            dataSearch.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MainPanel.Controls.Add(dataSearch);
            dataSearch.Show();
            #endregion
        }
        //声音的时频按钮
        private void Voice_TimeFrequencySpectrum_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            ruishen.声音分析.NoiseSTFT noisestft = new 声音分析.NoiseSTFT();
            noisestft.Dock = DockStyle.Fill;
            noisestft.TopLevel = false;
            noisestft.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MainPanel.Controls.Add(noisestft);
            noisestft.Show();
        }

        private void buttonItem31_Click(object sender, EventArgs e)
        {
            #region 进行窗体添加，把窗体加载到MainPanel中进行显示
            MainPanel.Controls.Clear();
            ruishen.数据管理.UserManage userManage = GenericSingleton<ruishen.数据管理.UserManage>.CreateInstrance();
            userManage.Dock = DockStyle.Fill;
            userManage.TopLevel = false;
            userManage.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MainPanel.Controls.Add(userManage);
            userManage.Show();
            #endregion
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            ruishen.算法类型.AlgorithmStyle algorithmStyle = GenericSingleton<ruishen.算法类型.AlgorithmStyle>.CreateInstrance();
            algorithmStyle.Visible = true;
            algorithmStyle.Show();
        }
        public void SaveDataToMysql() 
        {
            DataTempStorage.IsSaveData = false;
            endTime = DateTime.Now;
            
            string insert_Index = "insert into diagnosis_ttb_dataindex values(@Id,@Title,@StartTime,@EndTime,@WheelStyleOne,@WheelStyleTwo,@WheelSetSerialNumberOne,@WheelSetSerialNumberTwo,@User,@TestBench,@Factory,@Comment,@SampleFrequency)";
            string insert_character = "insert into diagnosis_ttb_character values(@Id,@StartTime,@VibrationOneChannelCharacterOne,@VibrationOneChannelCharacterTwo,@VibrationTwoChannelCharacterOne,@VibrationTwoChannelCharacterTwo,@VibrationThreeChannelCharacterOne,@VibrationThreeChannelCharacterTwo,@VibrationFourChannelCharacterOne,@VibrationFourChannelCharacterTwo,@characterNameOne,@characterNameTwo)";
       
            my = new MysqlHelper();
            if (ProductStyle.SelectedWheel1 == "1号轮对")
            {
                ProductStyle.WheelSetSerialNumber11 = DataTempStorage.FirstSet.ElementAt(DataTempStorage.CurrentForwardWheelNumber).ToString();
            }
            else if (ProductStyle.SelectedWheel1 == "2号轮对")
            {
                ProductStyle.WheelSetSerialNumber21 = DataTempStorage.SecondSet.ElementAt(DataTempStorage.CurrentBehindWheelNumber).ToString();
            }
            else
            {
                ProductStyle.WheelSetSerialNumber11 = DataTempStorage.FirstSet.ElementAt(DataTempStorage.CurrentForwardWheelNumber).ToString();
                ProductStyle.WheelSetSerialNumber21 = DataTempStorage.SecondSet.ElementAt(DataTempStorage.CurrentBehindWheelNumber).ToString();
            }
           
            Dictionary<string, object> dic = new Dictionary<string, object>();
            Dictionary<string, object> dic1 = new Dictionary<string, object>();
            dic.Add("@Title", ProductStyle.Title1);
            dic.Add("@StartTime", starTime);
            dic.Add("@EndTime", endTime);
            dic.Add("@WheelStyleOne", ProductStyle.WheelModel11);
            dic.Add("@WheelStyleTwo", ProductStyle.WheelModel21);
            dic.Add("@WheelSetSerialNumberOne", ProductStyle.WheelSetSerialNumber11);
            dic.Add("@WheelSetSerialNumberTwo", ProductStyle.WheelSetSerialNumber21);
          
            dic.Add("@User", ProductStyle.User1);
            dic.Add("@TestBench", ProductStyle.TestBench1);
            dic.Add("@Factory", ProductStyle.FactoryNumber1);
            dic.Add("@Comment", ProductStyle.Comment1);
            dic.Add("@SampleFrequency",channelParameterConfig.SampleRate1);
           
            if (!my.MySqlPour(insert_Index, dic))
            {
                MessageBox.Show("插入失败！");
            }
            if (DataTempStorage.AlgorithmList1==null||DataTempStorage.AlgorithmList1.Count == 0)
            {
                
            }
            else if (DataTempStorage.AlgorithmList1.Count==1)
            {
                dic1.Add("@StartTime", starTime);
                dic1.Add("@VibrationOneChannelCharacterOne", Serialization.SerializationObject(OneChannnelCharacterOne));
                dic1.Add("@VibrationOneChannelCharacterTwo", Serialization.SerializationObject(OneChannnelCharacterTwo));
                dic1.Add("@VibrationTwoChannelCharacterOne", Serialization.SerializationObject(TwoChannnelCharacterOne));
                dic1.Add("@VibrationTwoChannelCharacterTwo", Serialization.SerializationObject(TwoChannnelCharacterTwo));
                dic1.Add("@VibrationThreeChannelCharacterOne", Serialization.SerializationObject(ThreeChannnelCharacterOne));
                dic1.Add("@VibrationThreeChannelCharacterTwo", Serialization.SerializationObject(ThreeChannnelCharacterTwo));
                dic1.Add("@VibrationFourChannelCharacterOne", Serialization.SerializationObject(FourChannnelCharacterOne));
                dic1.Add("@VibrationFourChannelCharacterTwo", Serialization.SerializationObject(FourChannnelCharacterTwo));
                dic1.Add("@characterNameOne", DataTempStorage.AlgorithmList1[0].ToString());
                dic1.Add("@characterNameTwo", null);
                if (!my.MySqlPour(insert_character, dic1))
                {
                    MessageBox.Show("插入特征值失败！");
                }

            }
            else
            {
                dic1.Add("@StartTime", starTime);
                dic1.Add("@VibrationOneChannelCharacterOne", Serialization.SerializationObject(OneChannnelCharacterOne));
                dic1.Add("@VibrationOneChannelCharacterTwo", Serialization.SerializationObject(OneChannnelCharacterTwo));
                dic1.Add("@VibrationTwoChannelCharacterOne", Serialization.SerializationObject(TwoChannnelCharacterOne));
                dic1.Add("@VibrationTwoChannelCharacterTwo", Serialization.SerializationObject(TwoChannnelCharacterTwo));
                dic1.Add("@VibrationThreeChannelCharacterOne", Serialization.SerializationObject(ThreeChannnelCharacterOne));
                dic1.Add("@VibrationThreeChannelCharacterTwo", Serialization.SerializationObject(ThreeChannnelCharacterTwo));
                dic1.Add("@VibrationFourChannelCharacterOne", Serialization.SerializationObject(FourChannnelCharacterOne));
                dic1.Add("@VibrationFourChannelCharacterTwo", Serialization.SerializationObject(FourChannnelCharacterTwo));
                dic1.Add("@characterNameOne", DataTempStorage.AlgorithmList1[0].ToString());
                dic1.Add("@characterNameTwo", DataTempStorage.AlgorithmList1[1].ToString());
                if (!my.MySqlPour(insert_character, dic1))
                {
                    MessageBox.Show("插入特征值失败！");
                }

            }

            
        }
         int firstCharacterIsJudge  = 1;
         int secondCharacterIsJudge = 1;
        //定时采样，按照设定时间采样
        private void TimeStatistical() {
            DateTime dt1 = DateTime.Now;
            DataTempStorage.IsSaveData = true;
            while ((DateTime.Now - dt1).TotalSeconds <DataTempStorage.SampleTime1)
            {
                continue;
               
            };
            
            Thread.Sleep(1000);
            Real_DataSave.Image = global::ruishen.Properties.Resources.保存数据;
            ribbonBar21.Text = "保存数据";
            isDisplayCharacterValue = false;
            SaveDataToMysql();
            if (DataTempStorage.AlgorithmList1 == null || DataTempStorage.AlgorithmList1.Count == 0)
            {
                MessageBox.Show("未勾选判据，请重新选择判据");
            }
            else if (DataTempStorage.AlgorithmList1.Count == 1)
            {
                DataTempStorage.IsJudge.TryGetValue(DataTempStorage.AlgorithmList1[0].ToString(), out  firstCharacterIsJudge);
                if (firstCharacterIsJudge == 1)
                {
                    FirstCharacterDisplayResult();
                    PrintResult(DataTempStorage.FirstChannelCharacterOneResult, DataTempStorage.SecondChannelCharacterOneResult, DataTempStorage.ThreeChannelCharacterOneResult, DataTempStorage.FourChannelCharacterOneResult, DataTempStorage.AlgorithmList1[0].ToString());
                }
                TestResultGeneration testResultGeneration = new TestResultGeneration();
                testResultGeneration.ShowDialog();
            }
            else
            {
                DataTempStorage.IsJudge.TryGetValue(DataTempStorage.AlgorithmList1[0].ToString(), out  firstCharacterIsJudge);
                DataTempStorage.IsJudge.TryGetValue(DataTempStorage.AlgorithmList1[1].ToString(), out  secondCharacterIsJudge);

                if (firstCharacterIsJudge == 0 && secondCharacterIsJudge == 0)
                {
                    NotJudge();

                    FirstCharacterDisplayResult();
                    SecondCharacterDisplayResult();

                }
                else
                {
                    if (firstCharacterIsJudge == 1)
                    {

                        FirstCharacterDisplayResult();
                        PrintResult(DataTempStorage.FirstChannelCharacterOneResult, DataTempStorage.SecondChannelCharacterOneResult, DataTempStorage.ThreeChannelCharacterOneResult, DataTempStorage.FourChannelCharacterOneResult, DataTempStorage.AlgorithmList1[0].ToString());
                    }

                    if (secondCharacterIsJudge == 1)
                    {

                        SecondCharacterDisplayResult();
                        PrintResult1(DataTempStorage.FirstChannelCharacterTwoResult, DataTempStorage.SecondChannelCharacterTwoResult, DataTempStorage.ThreeChannelCharacterTwoResult, DataTempStorage.FourChannelCharacterTwoResult, DataTempStorage.AlgorithmList1[1].ToString());
                    }
                }
                TestResultGeneration testResultGeneration = new TestResultGeneration();
                testResultGeneration.ShowDialog();
            }

            //if(DataTempStorage.AlgorithmList1!=null&&DataTempStorage.AlgorithmList1.Count==1){

            //    DataTempStorage.IsJudge.TryGetValue(DataTempStorage.AlgorithmList1[0].ToString(), out  firstCharacterIsJudge);
            //    if(firstCharacterIsJudge==1)
            //    {
            //        FirstCharacterDisplayResult();
            //        PrintResult(DataTempStorage.FirstChannelCharacterOneResult, DataTempStorage.SecondChannelCharacterOneResult, DataTempStorage.ThreeChannelCharacterOneResult, DataTempStorage.FourChannelCharacterOneResult, DataTempStorage.AlgorithmList1[0].ToString());
            //    }
                
                
                
            //}
            //else if (DataTempStorage.AlgorithmList1 != null && DataTempStorage.AlgorithmList1.Count == 2)
            //{
            //    DataTempStorage.IsJudge.TryGetValue(DataTempStorage.AlgorithmList1[0].ToString(), out  firstCharacterIsJudge);
            //    DataTempStorage.IsJudge.TryGetValue(DataTempStorage.AlgorithmList1[1].ToString(), out  secondCharacterIsJudge);

            //    if(firstCharacterIsJudge==0&&secondCharacterIsJudge==0)
            //    {
            //        NotJudge();
                  
            //        FirstCharacterDisplayResult();
            //        SecondCharacterDisplayResult();
                    
            //    }
            //    else
            //    {
            //        if (firstCharacterIsJudge == 1)
            //        {
                        
            //            FirstCharacterDisplayResult();
            //            PrintResult(DataTempStorage.FirstChannelCharacterOneResult, DataTempStorage.SecondChannelCharacterOneResult, DataTempStorage.ThreeChannelCharacterOneResult, DataTempStorage.FourChannelCharacterOneResult, DataTempStorage.AlgorithmList1[0].ToString());
            //        }

            //        if (secondCharacterIsJudge == 1)
            //        {
                       
            //            SecondCharacterDisplayResult();
            //            PrintResult1(DataTempStorage.FirstChannelCharacterTwoResult, DataTempStorage.SecondChannelCharacterTwoResult, DataTempStorage.ThreeChannelCharacterTwoResult, DataTempStorage.FourChannelCharacterTwoResult, DataTempStorage.AlgorithmList1[1].ToString());
            //        }
            //    }
             
            //}
           // SaveDataToMysql();
            //if (DataTempStorage.AlgorithmList1==null||DataTempStorage.AlgorithmList1.Count==0)
            //{
            //    MessageBox.Show("未勾选判据，请重新选择判据");
            //}
            //else
            //{
            //    TestResultGeneration testResultGeneration = new TestResultGeneration();
            //    testResultGeneration.ShowDialog();
            //}
            
        }
        private void FirstCharacterDisplayResult()
        {
            if (DataTempStorage.AlgorithmList1[0].ToString() == "均方根值")
            {
                DataTempStorage.FirstChannelCharacterOneResult = OneChannnelCharacterOne.ToArray().Max();
                DataTempStorage.SecondChannelCharacterOneResult = TwoChannnelCharacterOne.ToArray().Max();
                DataTempStorage.ThreeChannelCharacterOneResult = ThreeChannnelCharacterOne.ToArray().Max();
                DataTempStorage.FourChannelCharacterOneResult = FourChannnelCharacterOne.ToArray().Max();
            }
            else
            {
                DataTempStorage.FirstChannelCharacterOneResult = NoiseCharacterValue.down_Quartile(OneChannnelCharacterOne.ToArray());
                DataTempStorage.SecondChannelCharacterOneResult = NoiseCharacterValue.down_Quartile(TwoChannnelCharacterOne.ToArray());
                DataTempStorage.ThreeChannelCharacterOneResult = NoiseCharacterValue.down_Quartile(ThreeChannnelCharacterOne.ToArray());
                DataTempStorage.FourChannelCharacterOneResult = NoiseCharacterValue.down_Quartile(FourChannnelCharacterOne.ToArray());
            }
        }

        private void SecondCharacterDisplayResult()
        {
            if (DataTempStorage.AlgorithmList1[1].ToString() == "均方根值")
            {
                DataTempStorage.FirstChannelCharacterTwoResult = OneChannnelCharacterTwo.ToArray().Max();
                DataTempStorage.SecondChannelCharacterTwoResult = TwoChannnelCharacterTwo.ToArray().Max();
                DataTempStorage.ThreeChannelCharacterTwoResult = ThreeChannnelCharacterTwo.ToArray().Max();
                DataTempStorage.FourChannelCharacterTwoResult = FourChannnelCharacterTwo.ToArray().Max();
            }
            else
            {
                DataTempStorage.FirstChannelCharacterTwoResult = NoiseCharacterValue.down_Quartile(OneChannnelCharacterTwo.ToArray());
                DataTempStorage.SecondChannelCharacterTwoResult = NoiseCharacterValue.down_Quartile(TwoChannnelCharacterTwo.ToArray());
                DataTempStorage.ThreeChannelCharacterTwoResult = NoiseCharacterValue.down_Quartile(ThreeChannnelCharacterTwo.ToArray());
                DataTempStorage.FourChannelCharacterTwoResult = NoiseCharacterValue.down_Quartile(FourChannnelCharacterTwo.ToArray());
            }
        }
        private void NotJudge()
        {
            StatusInformationDisplay.FirstWheelLeft1 = TestResult.不判断.ToString();
            StatusInformationDisplay.FirstWheelRight1 = TestResult.不判断.ToString();
            StatusInformationDisplay.SecondWheelLeft1 = TestResult.不判断.ToString();
            StatusInformationDisplay.SecondWheelRight1 = TestResult.不判断.ToString();
        }
        public static void PrintResult(double OneChannnelCharacterOneUp, double TwoChannnelCharacterOneUp, double ThreeChannnelCharacterOneUp, double FourChannnelCharacterOneUp,string CharacterValueStyle) 
        {
            double FirstCharacterValue=0;
            switch(CharacterValueStyle)
            {
                case "上四分位":FirstCharacterValue=ThresholdUpDownValue.UpQuartile_Up ; break;
                case "下四分位": FirstCharacterValue = ThresholdUpDownValue.DownQuartile_Up; break;
                case "中位数": FirstCharacterValue = ThresholdUpDownValue.Median_Up1; break;
                case "四分位距": FirstCharacterValue = ThresholdUpDownValue.DistanceQuartile_Up; break;
                case "上界": FirstCharacterValue = ThresholdUpDownValue.Upperbound_Up; break;
                case "下界": FirstCharacterValue = ThresholdUpDownValue.DownQuartile_Up; break;
                case "均值": FirstCharacterValue = ThresholdUpDownValue.Average_Up; break;
                case "方差": FirstCharacterValue = ThresholdUpDownValue.Variance_Up; break;
                case "均方根值": FirstCharacterValue = ThresholdUpDownValue.RMS_Value_Up1; break;
                case "歪度": FirstCharacterValue = ThresholdUpDownValue.Skewness_Up; break;
                case "峭度": FirstCharacterValue = ThresholdUpDownValue.Kurtosis_Up; break;
                case "峰度": FirstCharacterValue = ThresholdUpDownValue.Peak_Up; break;
                case "频率幅值": FirstCharacterValue = ThresholdUpDownValue.FrequencyA_Up; break;
                case "峰值频率": FirstCharacterValue = ThresholdUpDownValue.Frequency_Up; break;
                case "中心频率": FirstCharacterValue = ThresholdUpDownValue.OctaveValue_Up; break;
            }
            if (OneChannnelCharacterOneUp > FirstCharacterValue)
            {
                StatusInformationDisplay.FirstWheelLeft1 = TestResult.超标.ToString();
             //   StatusInformationDisplay.FirstCharacterValueHigh1 =DataTempStorage.AlgorithmList1[0].ToString();
                StatusInformationDisplay.OneChannelOneCharacterValueHigh1 = DataTempStorage.AlgorithmList1[0].ToString();
            }
            //else
            //{
            //    StatusInformationDisplay.FirstWheelLeft1 = TestResult.正常.ToString();
            //    StatusInformationDisplay.OneChannelOneCharacterValueHigh1 = "";
            //}
            if (TwoChannnelCharacterOneUp > FirstCharacterValue)
            {
                StatusInformationDisplay.FirstWheelRight1 = TestResult.超标.ToString();
            //    StatusInformationDisplay.FirstCharacterValueHigh1 = DataTempStorage.AlgorithmList1[0].ToString();
                StatusInformationDisplay.TwoChannelOneCharacterValueHigh1 = DataTempStorage.AlgorithmList1[0].ToString();
            }
            //else
            //{
            //    StatusInformationDisplay.FirstWheelRight1 = TestResult.正常.ToString();
            //    StatusInformationDisplay.TwoChannelOneCharacterValueHigh1 = "";
            //}
            if (ThreeChannnelCharacterOneUp>FirstCharacterValue)
            {
                StatusInformationDisplay.SecondWheelLeft1 = TestResult.超标.ToString();
             //   StatusInformationDisplay.FirstCharacterValueHigh1 = DataTempStorage.AlgorithmList1[0].ToString();
                StatusInformationDisplay.ThreeChannelOneCharacterValueHigh1 = DataTempStorage.AlgorithmList1[0].ToString();
            }
            //else
            //{
            //    StatusInformationDisplay.SecondWheelLeft1 = TestResult.正常.ToString();
            //    StatusInformationDisplay.ThreeChannelOneCharacterValueHigh1 = "";
            //}
            if(FourChannnelCharacterOneUp>FirstCharacterValue)
            {
                StatusInformationDisplay.SecondWheelRight1 = TestResult.超标.ToString();
              //  StatusInformationDisplay.FirstCharacterValueHigh1 = DataTempStorage.AlgorithmList1[0].ToString();
                StatusInformationDisplay.FourChannelOneCharacterValueHigh1 = DataTempStorage.AlgorithmList1[0].ToString();
            }
            //else
            //{
            //    StatusInformationDisplay.SecondWheelRight1 = TestResult.正常.ToString();
            //    StatusInformationDisplay.FourChannelOneCharacterValueHigh1 = "";
            //}
            
        }
        enum TestResult {
            超标 =0,
            正常=1,
            不判断=2
        }

        public static void PrintResult1(double OneChannnelCharacterTwoUp,double TwoChannnelCharacterTwoUp, double ThreeChannnelCharacterTwoUp,double FourChannnelCharacterTwoUp, string CharacterValueStyle)
        {
            double SecondCharacterValue = 0;
            switch (CharacterValueStyle)
            {
                case "上四分位": SecondCharacterValue = ThresholdUpDownValue.UpQuartile_Up; break;
                case "下四分位": SecondCharacterValue = ThresholdUpDownValue.DownQuartile_Up; break;
                case "中位数": SecondCharacterValue = ThresholdUpDownValue.Median_Up1; break;
                case "四分位距": SecondCharacterValue = ThresholdUpDownValue.DistanceQuartile_Up; break;
                case "上界": SecondCharacterValue = ThresholdUpDownValue.Upperbound_Up; break;
                case "下界": SecondCharacterValue = ThresholdUpDownValue.DownQuartile_Up; break;
                case "均值": SecondCharacterValue = ThresholdUpDownValue.Average_Up; break;
                case "方差": SecondCharacterValue = ThresholdUpDownValue.Variance_Up; break;
                case "均方根值": SecondCharacterValue = ThresholdUpDownValue.RMS_Value_Up1; break;
                case "歪度": SecondCharacterValue = ThresholdUpDownValue.Skewness_Up; break;
                case "峭度": SecondCharacterValue = ThresholdUpDownValue.Kurtosis_Up; break;
                case "峰度": SecondCharacterValue = ThresholdUpDownValue.Peak_Up; break;
                case "频率幅值": SecondCharacterValue = ThresholdUpDownValue.FrequencyA_Up; break;
                case "峰值频率": SecondCharacterValue = ThresholdUpDownValue.Frequency_Up; break;
                case "中心频率": SecondCharacterValue = ThresholdUpDownValue.OctaveValue_Up; break;
            }
            if (OneChannnelCharacterTwoUp > SecondCharacterValue)
            {
                StatusInformationDisplay.FirstWheelLeft1 = TestResult.超标.ToString();
               // StatusInformationDisplay.SecondCharacterValueHigh1 = DataTempStorage.AlgorithmList1[1].ToString();
                StatusInformationDisplay.OneChannelTwoCharacterValueHigh1 = DataTempStorage.AlgorithmList1[1].ToString();
            }
            //else
            //{
            //    StatusInformationDisplay.FirstWheelLeft1 = TestResult.正常.ToString();
            //    StatusInformationDisplay.OneChannelTwoCharacterValueHigh1 = "";
            //}
            if (TwoChannnelCharacterTwoUp > SecondCharacterValue)
            {
                StatusInformationDisplay.FirstWheelRight1 = TestResult.超标.ToString();
              //  StatusInformationDisplay.SecondCharacterValueHigh1 = DataTempStorage.AlgorithmList1[1].ToString();
                StatusInformationDisplay.TwoChannelTwoCharacterValueHigh1 = DataTempStorage.AlgorithmList1[1].ToString();
            }
            //else
            //{
            //    StatusInformationDisplay.FirstWheelRight1 = TestResult.正常.ToString();
            //    StatusInformationDisplay.TwoChannelTwoCharacterValueHigh1 = "";
            //}
            if(ThreeChannnelCharacterTwoUp>SecondCharacterValue)
            {
                StatusInformationDisplay.SecondWheelLeft1 = TestResult.超标.ToString();
               // StatusInformationDisplay.SecondCharacterValueHigh1 = DataTempStorage.AlgorithmList1[1].ToString();
                StatusInformationDisplay.ThreeChannelTwoCharacterValueHigh1 = DataTempStorage.AlgorithmList1[1].ToString();
            }
            //else
            //{
            //    StatusInformationDisplay.SecondWheelLeft1 = TestResult.正常.ToString();
            //    StatusInformationDisplay.ThreeChannelTwoCharacterValueHigh1 = "";
            //}
            if(FourChannnelCharacterTwoUp>SecondCharacterValue)
            {
                StatusInformationDisplay.SecondWheelRight1 = TestResult.超标.ToString();
              //  StatusInformationDisplay.SecondCharacterValueHigh1 = DataTempStorage.AlgorithmList1[1].ToString();
                StatusInformationDisplay.FourChannelTwoCharacterValueHigh1 = DataTempStorage.AlgorithmList1[1].ToString();

            }
            //else
            //{
            //    StatusInformationDisplay.SecondWheelRight1 = TestResult.正常.ToString();
            //    StatusInformationDisplay.FourChannelTwoCharacterValueHigh1 = "";
            //}
            

        }

      
        public string subString(string str) {

            return str = System.Text.RegularExpressions.Regex.Replace(str, @"[^0-9]+", "");

        }
        
        private void Real_DataSave_Click(object sender, EventArgs e)
        {
            StatusInformationDisplay.FirstWheelLeft1 = TestResult.正常.ToString();
            StatusInformationDisplay.FirstWheelRight1 = TestResult.正常.ToString();
            StatusInformationDisplay.SecondWheelLeft1 = TestResult.正常.ToString();
            StatusInformationDisplay.SecondWheelRight1 = TestResult.正常.ToString();
            //StatusInformationDisplay.FirstCharacterValueHigh1 = "";
            //StatusInformationDisplay.SecondCharacterValueHigh1 = "";
            StatusInformationDisplay.OneChannelOneCharacterValueHigh1 = "";
            StatusInformationDisplay.OneChannelTwoCharacterValueHigh1 = "";
            StatusInformationDisplay.TwoChannelOneCharacterValueHigh1 = "";
            StatusInformationDisplay.TwoChannelTwoCharacterValueHigh1 = "";
            StatusInformationDisplay.ThreeChannelOneCharacterValueHigh1 = "";
            StatusInformationDisplay.ThreeChannelTwoCharacterValueHigh1 = "";
            StatusInformationDisplay.FourChannelOneCharacterValueHigh1 = "";
            StatusInformationDisplay.FourChannelTwoCharacterValueHigh1 = "";
           
            if (DataTempStorage.SampleWay1 == "定时采样")
            {
                if (ribbonBar21.Text == "保存数据")
                {

                    OneChannnelCharacterOne.Clear();
                    OneChannnelCharacterTwo.Clear();
                    TwoChannnelCharacterOne.Clear();
                    TwoChannnelCharacterTwo.Clear();
                    ThreeChannnelCharacterOne.Clear();
                    ThreeChannnelCharacterTwo.Clear();
                    FourChannnelCharacterOne.Clear();
                    FourChannnelCharacterTwo.Clear();

                    if ((DataTempStorage.FirstSet.Count - DataTempStorage.CurrentForwardWheelNumber)==0)
                    {
                        MessageBox.Show("轮对测量结束");
                    }
                    else
                    {
                        isDisplayCharacterValue = true;
                        TotalTimeCount.Visible = false;
                        SaveTimeCount.Visible = false;
                        ribbonBar21.Text = "停止保存";
                        SaveCharacterValue = true;
                        realMonitorCollection.ProgressBarSave.Text = "正在保存";
                        Real_DataSave.Image = global::ruishen.Properties.Resources.保存数据点击;
                        
                        realMonitorCollection.RMC_ProgressBar.Visible = true;
                        realMonitorCollection.ProgressBarSave.Visible = true;
                        realMonitorCollection.RMC_ProgressBar.Value = 0;
                        realMonitorCollection.RMC_ProgressBar.Maximum = (int)DataTempStorage.SampleTime1;
                        realMonitorCollection.RMC_Time.Visible = true;
                        //清空图表展示区，重新绘制
                        realMonitorCollection.waveformGraph1.ClearData();
                        realMonitorCollection.waveformGraph2.ClearData();
                        realMonitorCollection.waveformGraph3.ClearData();
                        realMonitorCollection.waveformGraph4.ClearData();
                        realMonitorCollection.waveformGraph5.ClearData();
                        realMonitorCollection.waveformGraph6.ClearData();
                        realMonitorCollection.waveformGraph7.ClearData();
                        realMonitorCollection.waveformGraph8.ClearData();

                        starTime = DateTime.Now;
                        DataTempStorage.StartTime = DateTime.Now;
                        //定时采集数据
                        timer2.Enabled = true;

                        Control.CheckForIllegalCrossThreadCalls = false;
                        timeThread = new Thread(TimeStatistical);
                        timeThread.Start();
                    }
                    
                    
                }
                else
                {
                    timeThread.Abort();
                    timer2.Enabled = false;
                    
                    DataTempStorage.IsEndSave = true;//数据结束存储
                    DataTempStorage.IsSaveData = false;//
                    SaveCharacterValue = false;//保存特征值结束
                    endTime = DateTime.Now;//记录当前结束时间
                    DataTempStorage.EndTime = DateTime.Now;
                    string insert_Index = "insert into diagnosis_ttb_dataindex values(@Id,@Title,@StartTime,@EndTime,@WheelStyleOne,@WheelStyleTwo,@WheelSetSerialNumberOne,@WheelSetSerialNumberTwo,@User,@TestBench,@Factory,@Comment,@SampleFrequency)";//插入数据配套索引
                    my = new MysqlHelper();
                    if (ProductStyle.SelectedWheel1 == "1号轮对")
                    {
                        ProductStyle.WheelSetSerialNumber11 = DataTempStorage.FirstSet.ElementAt(DataTempStorage.CurrentForwardWheelNumber).ToString();
                    }
                    else if (ProductStyle.SelectedWheel1 == "2号轮对")
                    {
                        ProductStyle.WheelSetSerialNumber21 = DataTempStorage.SecondSet.ElementAt(DataTempStorage.CurrentBehindWheelNumber).ToString();
                    }
                    else
                    {
                        ProductStyle.WheelSetSerialNumber11 = DataTempStorage.FirstSet.ElementAt(DataTempStorage.CurrentForwardWheelNumber).ToString();
                        ProductStyle.WheelSetSerialNumber21 = DataTempStorage.SecondSet.ElementAt(DataTempStorage.CurrentBehindWheelNumber).ToString();
                    }
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("@Title", ProductStyle.Title1);
                    dic.Add("@StartTime", starTime);
                    dic.Add("@EndTime", endTime);
                    dic.Add("@WheelStyleOne", ProductStyle.WheelModel11);
                    dic.Add("@WheelStyleTwo", ProductStyle.WheelModel21);
                    dic.Add("@WheelSetSerialNumberOne", ProductStyle.WheelSetSerialNumber11);
                    dic.Add("@WheelSetSerialNumberTwo", ProductStyle.WheelSetSerialNumber21);
                   
                    dic.Add("@User", ProductStyle.User1);
                    dic.Add("@TestBench", ProductStyle.TestBench1);
                    dic.Add("@Factory", ProductStyle.FactoryNumber1);
                    dic.Add("@Comment", ProductStyle.Comment1);
                    dic.Add("@SampleFrequency", channelParameterConfig.SampleRate1);
                    
                    if (!my.MySqlPour(insert_Index, dic))
                    {
                        MessageBox.Show("插入失败！");
                    }
                   
                    Thread.Sleep(1000);
                    Real_DataSave.Image = global::ruishen.Properties.Resources.保存数据;
                    ribbonBar21.Text = "保存数据";
                    realMonitorCollection.ProgressBarSave.Text = "保存完成";
                    MessageBox.Show("保存完成");
                   

                }
            }
            else if (DataTempStorage.SampleWay1 == "连续采样")
            {
                if (ribbonBar21.Text == "保存数据")
                {
                    continuesSaveTime = 1;
                    starTime = DateTime.Now;
                    DataTempStorage.StartTime = DateTime.Now;
                    TotalTimeCount.Visible = true;
                    SaveTimeCount.Visible = true;
                    ContinuousSave.Enabled = true;
                    SaveCharacterValue = true;
                    DataTempStorage.IsSaveData = true;
                    ribbonBar21.Text = "停止保存";
                    realMonitorCollection.ProgressBarSave.Text = "正在保存";
                    Real_DataSave.Image = global::ruishen.Properties.Resources.保存数据点击;
                }

                else 
                { 
                    if(ribbonBar21.Text=="停止保存")
                    {
                        try
                        {
                            DataTempStorage.IsEndSave = true;
                            DataTempStorage.IsSaveData = false;
                            SaveCharacterValue = false;
                            Real_DataSave.Image = global::ruishen.Properties.Resources.保存数据;
                            endTime = DateTime.Now;
                            DataTempStorage.EndTime = DateTime.Now;
                            string insert_Index = "insert into diagnosis_ttb_dataindex values(@Id,@Title,@StartTime,@EndTime,@WheelStyleOne,@WheelStyleTwo,@WheelSetSerialNumberOne,@WheelSetSerialNumberTwo,@User,@TestBench,@Factory,@Comment,@SampleFrequency)";

                            if (ProductStyle.SelectedWheel1 == "1号轮对")
                            {
                                ProductStyle.WheelSetSerialNumber11 = DataTempStorage.FirstSet.ElementAt(DataTempStorage.CurrentForwardWheelNumber).ToString();
                            }
                            else if (ProductStyle.SelectedWheel1 == "2号轮对")
                            {
                                ProductStyle.WheelSetSerialNumber21 = DataTempStorage.SecondSet.ElementAt(DataTempStorage.CurrentBehindWheelNumber).ToString();
                            }
                            else
                            {
                                ProductStyle.WheelSetSerialNumber11 = DataTempStorage.FirstSet.ElementAt(DataTempStorage.CurrentForwardWheelNumber).ToString();
                                ProductStyle.WheelSetSerialNumber21 = DataTempStorage.SecondSet.ElementAt(DataTempStorage.CurrentBehindWheelNumber).ToString();
                            }

                            my = new MysqlHelper();
                            Dictionary<string, object> dic = new Dictionary<string, object>();
                            dic.Add("@Title", ProductStyle.Title1);
                            dic.Add("@StartTime", starTime);
                            dic.Add("@EndTime", endTime);
                            dic.Add("@WheelStyleOne", ProductStyle.WheelModel11);
                            dic.Add("@WheelStyleTwo", ProductStyle.WheelModel21);
                            dic.Add("@WheelSetSerialNumberOne", ProductStyle.WheelSetSerialNumber11);
                            dic.Add("@WheelSetSerialNumberTwo", ProductStyle.WheelSetSerialNumber21);
                           
                            dic.Add("@User", ProductStyle.User1);
                            dic.Add("@TestBench", ProductStyle.TestBench1);
                            dic.Add("@Factory", ProductStyle.FactoryNumber1);
                            dic.Add("@Comment", ProductStyle.Comment1);
                            dic.Add("@SampleFrequency", channelParameterConfig.SampleRate1);
                           
                            if (!my.MySqlPour(insert_Index, dic))
                            {
                                MessageBox.Show("插入失败！");
                            }
                           
                            ContinuousSave.Enabled = false;
                            MessageBox.Show("保存完成");
                            Real_DataSave.Image = global::ruishen.Properties.Resources.保存数据;
                            ribbonBar21.Text = "保存数据";
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("");
                        }
                    }
                }
                
            }

        }
        
        private byte[] DataSource(string find_sql)
        {
            byte[] buffer = new byte[1];
            conn = new MySqlConnection(constr);
            conn.Open();
            command = new MySqlCommand(find_sql, conn);
            sdr = command.ExecuteReader();
            sdr.Read();
            buffer = new Byte[sdr.GetBytes(0, 0, null, 0, int.MaxValue)];
            sdr.GetBytes(0, 0, buffer, 0, buffer.Length);
            sdr.Dispose();
            sdr.Close();
            conn.Dispose();
            conn.Close();
            return buffer;
        }

        private void Real_GlobalMonitoring_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            realMonitorCollection = GenericSingleton<ruishen.实时监测.RealMonitorCollection>.CreateInstrance();
            realMonitorCollection.Dock = DockStyle.Fill;
            realMonitorCollection.TopLevel = false;
            realMonitorCollection.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Real_GlobalMonitoring.Image = global::ruishen.Properties.Resources.全局监测中;
            Real_NoisyMonitor.Image = global::ruishen.Properties.Resources.声音;
            Real_VibrationMonitor.Image = global::ruishen.Properties.Resources.振动;
            MainPanel.Controls.Add(realMonitorCollection);
        }

        private void buttonItem5_Click_1(object sender, EventArgs e)
        {
            OutputReport small_OR    =  new OutputReport();
            small_OR.Text = "输出报告";
            small_OR.Show();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
           if (MessageBox.Show("关闭运行?", "退出", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)

            {
                Application.Exit();

             }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
          
            realMonitorCollection.RMC_ProgressBar.Value += 1;
            realMonitorCollection.RMC_Time.Text ="时间:"+ realMonitorCollection.RMC_ProgressBar.Value.ToString()+"s";
            if (realMonitorCollection.RMC_ProgressBar.Value > DataTempStorage.SampleTime1-1)
            {
                timer2.Enabled = false;
                realMonitorCollection.ProgressBarSave.Text = "保存完成";
            }
            
        }

        private void SystemCurrentTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = System.DateTime.Now;
            label2.Text = dt.ToString();

        }
        
        private void ContinuousSave_Tick(object sender, EventArgs e)
        {
            TotalTimeCount.Text = (continuesSaveTime++).ToString()+"/s";
        }

      


    }
}
