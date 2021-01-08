using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruishen.Entity
{
    class BearingConfig
    {
        #region 轴承字段

        private int Id;//主键
        private string BearingDesignation;//轴承型号
        private string NewDomesticModel;//国内新型号
        private string OldDomesticModel;//国内旧型号
        private int InnerDiameter;//轴承内径
        private int OuterDiameter;//轴承外径
        private int Width;//轴承宽度
        private double Cr;//轴承基本额定动载荷
        private double Cor;//轴承基本额定静载荷
        private int Oil;//轴承油润滑转速
        private int Grease;//轴承脂润脂转速
        private double Mass;//轴承质量
        #endregion
        public int Id1
        {
            get { return Id; }
            set { Id = value; }
        }
        

        public string BearingDesignation1
        {
            get { return BearingDesignation; }
            set { BearingDesignation = value; }
        }
        

        public string NewDomesticModel1
        {
            get { return NewDomesticModel; }
            set { NewDomesticModel = value; }
        }
        

        public string OldDomesticModel1
        {
            get { return OldDomesticModel; }
            set { OldDomesticModel = value; }
        }
        

        public int InnerDiameter1
        {
            get { return InnerDiameter; }
            set { InnerDiameter = value; }
        }
        

        public int OuterDiameter1
        {
            get { return OuterDiameter; }
            set { OuterDiameter = value; }
        }
        

        public int Width1
        {
            get { return Width; }
            set { Width = value; }
        }
       

        public double Cr1
        {
            get { return Cr; }
            set { Cr = value; }
        }
       

        public double Cor1
        {
            get { return Cor; }
            set { Cor = value; }
        }
       

        public int Grease1
        {
            get { return Grease; }
            set { Grease = value; }
        }
        

        public int Oil1
        {
            get { return Oil; }
            set { Oil = value; }
        }
       

        public double Mass1
        {
            get { return Mass; }
            set { Mass = value; }
        }
      
    }
}
