using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace ruishen.公共中间量
{
    class DataTempStorage
    {
        
        //存储从数据库读取的临时振动数据
        private static double[] TempVibrationData;

        public static double[] TempVibrationData1
        {
            get { return DataTempStorage.TempVibrationData; }
            set { DataTempStorage.TempVibrationData = value; }
        }
        //存储临时振动静态的采样频率
        private static int TempVibrationSampleFrequency;

        public static int TempVibrationSampleFrequency1
        {
            get { return DataTempStorage.TempVibrationSampleFrequency; }
            set { DataTempStorage.TempVibrationSampleFrequency = value; }
        }
        //存储临时噪声静态的采样频率
        private static int TempNoiseSampleFrequency;

        public static int TempNoiseSampleFrequency1
        {
            get { return DataTempStorage.TempNoiseSampleFrequency; }
            set { DataTempStorage.TempNoiseSampleFrequency = value; }
        }

        
        //存储从数据库读取的临时声音数据
        private static double[] TempNoiseData;

        public static double[] TempNoiseData1
        {
            get { return DataTempStorage.TempNoiseData; }
            set { DataTempStorage.TempNoiseData = value; }
        }

        //判断小窗体是否被创建
        private static bool smallFormIsCreated;

        public static bool SmallFormIsCreated
        {
            get { return DataTempStorage.smallFormIsCreated; }
            set { DataTempStorage.smallFormIsCreated = value; }
        }
        //通道编号数
        private static int ChannelNumber;

        public static int ChannelNumber1
        {
            get { return DataTempStorage.ChannelNumber; }
            set { DataTempStorage.ChannelNumber = value; }
        }
        //开始保存数据
        private static bool isSaveData=false;

        public static bool IsSaveData
        {
            get { return DataTempStorage.isSaveData; }
            set { DataTempStorage.isSaveData = value; }
        }

        private static bool isEndSave=false;
        //结束保存数据
        public static bool IsEndSave
        {
            get { return DataTempStorage.isEndSave; }
            set { DataTempStorage.isEndSave = value; }
        }


        private static int CurrentId;//记录最大id

        public static int CurrentId1
        {
            get { return DataTempStorage.CurrentId; }
            set { DataTempStorage.CurrentId = value; }
        }

        private static double SampleTime = 60;//记录采样时间

        public static double SampleTime1
        {
            get { return DataTempStorage.SampleTime; }
            set { DataTempStorage.SampleTime = value; }
        }

       

        private static ArrayList AlgorithmList=null;//记录选择算法

        public static ArrayList AlgorithmList1
        {
            get { return DataTempStorage.AlgorithmList; }
            set { DataTempStorage.AlgorithmList = value; }
        }

        private static string smallFormSelected="";//记录小窗体点击的按钮

        public static string SmallFormSelected
        {
            get { return DataTempStorage.smallFormSelected; }
            set { DataTempStorage.smallFormSelected = value; }
        }

        private static double CenterFrequency;//记录中心频率

        public static double CenterFrequency1
        {
            get { return DataTempStorage.CenterFrequency; }
            set { DataTempStorage.CenterFrequency = value; }
        }

        private static double FrequencyAmplitude;//记录频率幅值

        public static double FrequencyAmplitude1
        {
            get { return DataTempStorage.FrequencyAmplitude; }
            set { DataTempStorage.FrequencyAmplitude = value; }
        }

        private static string AnalysisBandWidth = "";//分析带宽

        public static string AnalysisBandWidth1
        {
            get { return DataTempStorage.AnalysisBandWidth; }
            set { DataTempStorage.AnalysisBandWidth = value; }
        }

        private static string FrequencyGraph;//谱线数

        public static string FrequencyGraph1
        {
            get { return DataTempStorage.FrequencyGraph; }
            set { DataTempStorage.FrequencyGraph = value; }
        }
        private static string Resolutio;//分辨率

        public static string Resolutio1
        {
            get { return DataTempStorage.Resolutio; }
            set { DataTempStorage.Resolutio = value; }
        }

        private static string SampleWay="定时采样";//采样方式（连续采样或定时采样）

        public static string SampleWay1
        {
            get { return DataTempStorage.SampleWay; }
            set { DataTempStorage.SampleWay = value; }
        }

        private static string WindowFunction;//窗函数

        public static string WindowFunction1
        {
            get { return DataTempStorage.WindowFunction; }
            set { DataTempStorage.WindowFunction = value; }
        }

        private static string AverageMode;//平均方式

        public static string AverageMode1
        {
            get { return DataTempStorage.AverageMode; }
            set { DataTempStorage.AverageMode = value; }
        }

        private static int AverageNumber=10;//平均次数

        public static int AverageNumber1
        {
            get { return DataTempStorage.AverageNumber; }
            set { DataTempStorage.AverageNumber = value; }
        }

        private static double AcquisitionTime=0;//采样时间

        public static double AcquisitionTime1
        {
            get { return DataTempStorage.AcquisitionTime; }
            set { DataTempStorage.AcquisitionTime = value; }
        }

        private static int MusicLoadId;//声音id

        public static int MusicLoadId1
        {
            get { return DataTempStorage.MusicLoadId; }
            set { DataTempStorage.MusicLoadId = value; }
        }

        private static double timespan;//时间差

        public static double Timespan
        {
            get { return DataTempStorage.timespan; }
            set { DataTempStorage.timespan = value; }
        }

        private static int Recallcount = 0;//判断声音回听被点击几次；

        public static int Recallcount1
        {
            get { return DataTempStorage.Recallcount; }
            set { DataTempStorage.Recallcount = value; }
        }

        private static Boolean IsCollectData=false;//确认采集数据

        public static Boolean IsCollectData1
        {
            get { return DataTempStorage.IsCollectData; }
            set { DataTempStorage.IsCollectData = value; }
        }

      #region 通道特征值阈值最终结果保存
        private static double firstChannelCharacterOneResult;//一通道特征值1结果

        public static double FirstChannelCharacterOneResult
        {
            get { return DataTempStorage.firstChannelCharacterOneResult; }
            set { DataTempStorage.firstChannelCharacterOneResult = value; }
        }

        private static double secondChannelCharacterOneResult;//二通道特征值1结果

        public static double SecondChannelCharacterOneResult
        {
            get { return DataTempStorage.secondChannelCharacterOneResult; }
            set { DataTempStorage.secondChannelCharacterOneResult = value; }
        }

        private static double threeChannelCharacterOneResult;//三通道特征值1结果

        public static double ThreeChannelCharacterOneResult
        {
            get { return DataTempStorage.threeChannelCharacterOneResult; }
            set { DataTempStorage.threeChannelCharacterOneResult = value; }
        }

        private static double fourChannelCharacterOneResult;//四通道特征值1结果

        public static double FourChannelCharacterOneResult
        {
            get { return DataTempStorage.fourChannelCharacterOneResult; }
            set { DataTempStorage.fourChannelCharacterOneResult = value; }
        }

        private static double firstChannelCharacterTwoResult;//一通道特征值2结果

        public static double FirstChannelCharacterTwoResult
        {
            get { return DataTempStorage.firstChannelCharacterTwoResult; }
            set { DataTempStorage.firstChannelCharacterTwoResult = value; }
        }

        private static double secondChannelCharacterTwoResult;//二通道特征值2结果

        public static double SecondChannelCharacterTwoResult
        {
            get { return DataTempStorage.secondChannelCharacterTwoResult; }
            set { DataTempStorage.secondChannelCharacterTwoResult = value; }
        }

        private static double threeChannelCharacterTwoResult;//三通道特征值2结果

        public static double ThreeChannelCharacterTwoResult
        {
            get { return DataTempStorage.threeChannelCharacterTwoResult; }
            set { DataTempStorage.threeChannelCharacterTwoResult = value; }
        }

        private static double fourChannelCharacterTwoResult;//四通道特征值2结果

        public static double FourChannelCharacterTwoResult
        {
            get { return DataTempStorage.fourChannelCharacterTwoResult; }
            set { DataTempStorage.fourChannelCharacterTwoResult = value; }
        }
      #endregion

        private static DateTime startTime=DateTime.Now;//开始时间

        public static DateTime StartTime
        {
            get { return DataTempStorage.startTime; }
            set { DataTempStorage.startTime = value; }
        }
        private static DateTime endTime = DateTime.Now;//结束时间

        public static DateTime EndTime
        {
            get { return DataTempStorage.endTime; }
            set { DataTempStorage.endTime = value; }
        }
        private static HashSet<string> firstSet;

        public static HashSet<string> FirstSet//存储前轮对所有轮对轴号
        {
            get { return DataTempStorage.firstSet; }
            set { DataTempStorage.firstSet = value; }
        }

        private static HashSet<string> secondSet;//存储后轮对所有轮对轴号

        public static HashSet<string> SecondSet
        {
            get { return DataTempStorage.secondSet; }
            set { DataTempStorage.secondSet = value; }
        }

        private static int currentForwardWheelNumber = 0;//当前前轮数

        public static int CurrentForwardWheelNumber
        {
            get { return DataTempStorage.currentForwardWheelNumber; }
            set { DataTempStorage.currentForwardWheelNumber = value; }
        }

        private static int currentBehindWheelNumber = 0;//当前后轮数

        public static int CurrentBehindWheelNumber
        {
            get { return DataTempStorage.currentBehindWheelNumber; }
            set { DataTempStorage.currentBehindWheelNumber = value; }
        }

        

        //private static int currentWheelNUmber=0;//当前轮对号

        //public static int CurrentWheelNUmber
        //{
        //    get { return DataTempStorage.currentWheelNUmber; }
        //    set { DataTempStorage.currentWheelNUmber = value; }
        //}
        private static Dictionary<string, int> isJudge=new Dictionary<string,int>();//是否作为判据

        public static Dictionary<string, int> IsJudge
        {
            get { return DataTempStorage.isJudge; }
            set { DataTempStorage.isJudge = value; }
        }
    }
}
