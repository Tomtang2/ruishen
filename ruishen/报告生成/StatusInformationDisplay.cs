using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruishen.报告生成
{
    class StatusInformationDisplay
    {
        public enum statusInformation
        
        {
            正常,
            超标,
            信号异常,
            自学习中,
            无阈模式
        }

        private static string FirstWheelLeft="正常";//一号左轮状态

        public static string FirstWheelLeft1
        {
            get { return StatusInformationDisplay.FirstWheelLeft; }
            set { StatusInformationDisplay.FirstWheelLeft = value; }
        }
        private static string FirstWheelRight = "正常";//一号右轮状态

        public static string FirstWheelRight1
        {
            get { return StatusInformationDisplay.FirstWheelRight; }
            set { StatusInformationDisplay.FirstWheelRight = value; }
        }

        private static string SecondWheelLeft = "正常";//二号左轮状态

        public static string SecondWheelLeft1
        {
            get { return StatusInformationDisplay.SecondWheelLeft; }
            set { StatusInformationDisplay.SecondWheelLeft = value; }
        }

        private static string SecondWheelRight = "正常";//二号右轮状态

        public static string SecondWheelRight1
        {
            get { return StatusInformationDisplay.SecondWheelRight; }
            set { StatusInformationDisplay.SecondWheelRight = value; }
        }

        private static string FirstCharacterValueHigh="";//一号特征值超标

        public static string FirstCharacterValueHigh1
        {
            get { return StatusInformationDisplay.FirstCharacterValueHigh; }
            set { StatusInformationDisplay.FirstCharacterValueHigh = value; }
        }

        private static string SecondCharacterValueHigh = "";//二号特征值超标

        public static string SecondCharacterValueHigh1
        {
            get { return StatusInformationDisplay.SecondCharacterValueHigh; }
            set { StatusInformationDisplay.SecondCharacterValueHigh = value; }
        }

        private static string OneChannelOneCharacterValueHigh = "";//1通道1特征值

        public static string OneChannelOneCharacterValueHigh1
        {
            get { return StatusInformationDisplay.OneChannelOneCharacterValueHigh; }
            set { StatusInformationDisplay.OneChannelOneCharacterValueHigh = value; }
        }
        private static string OneChannelTwoCharacterValueHigh = "";//1通道2特征值

        public static string OneChannelTwoCharacterValueHigh1
        {
            get { return StatusInformationDisplay.OneChannelTwoCharacterValueHigh; }
            set { StatusInformationDisplay.OneChannelTwoCharacterValueHigh = value; }
        }
        private static string TwoChannelOneCharacterValueHigh = "";//2通道1特征值

        public static string TwoChannelOneCharacterValueHigh1
        {
            get { return StatusInformationDisplay.TwoChannelOneCharacterValueHigh; }
            set { StatusInformationDisplay.TwoChannelOneCharacterValueHigh = value; }
        }
        private static string TwoChannelTwoCharacterValueHigh = "";//2通道2特征值

        public static string TwoChannelTwoCharacterValueHigh1
        {
            get { return StatusInformationDisplay.TwoChannelTwoCharacterValueHigh; }
            set { StatusInformationDisplay.TwoChannelTwoCharacterValueHigh = value; }
        }
        private static string ThreeChannelOneCharacterValueHigh = "";//3通道1特征值

        public static string ThreeChannelOneCharacterValueHigh1
        {
            get { return StatusInformationDisplay.ThreeChannelOneCharacterValueHigh; }
            set { StatusInformationDisplay.ThreeChannelOneCharacterValueHigh = value; }
        }
        private static string ThreeChannelTwoCharacterValueHigh = "";//3通道2特征值

        public static string ThreeChannelTwoCharacterValueHigh1
        {
            get { return StatusInformationDisplay.ThreeChannelTwoCharacterValueHigh; }
            set { StatusInformationDisplay.ThreeChannelTwoCharacterValueHigh = value; }
        }
        private static string FourChannelOneCharacterValueHigh = "";//4通道1特征值

        public static string FourChannelOneCharacterValueHigh1
        {
            get { return StatusInformationDisplay.FourChannelOneCharacterValueHigh; }
            set { StatusInformationDisplay.FourChannelOneCharacterValueHigh = value; }
        }
        private static string FourChannelTwoCharacterValueHigh = "";//4通道2特征值

        public static string FourChannelTwoCharacterValueHigh1
        {
            get { return StatusInformationDisplay.FourChannelTwoCharacterValueHigh; }
            set { StatusInformationDisplay.FourChannelTwoCharacterValueHigh = value; }
        }
    }
}
