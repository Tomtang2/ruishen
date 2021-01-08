using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.DAQmx;
using ruishen.数据库公告类;
using System.Collections;
using ruishen.Entity;

namespace ruishen.参数配置
{
    public partial class SampleSetForm : Form
    {
        public SampleSetForm()
        {
            InitializeComponent();
            #region 代码界面初始化
            this.coupling1.Text = "AC";
            this.coupling2.Text = "AC";
            this.coupling3.Text = "AC";
            this.coupling4.Text = "AC";
            this.coupling5.Text = "AC";
            this.coupling6.Text = "AC";
            this.coupling7.Text = "AC";
            this.coupling8.Text = "AC";

            this.Unit1.Text = "mV/g";
            this.Unit2.Text = "mV/g";
            this.Unit3.Text = "mV/g";
            this.Unit4.Text = "mV/g";
            this.Unit5.Text = "mV/g";
            this.Unit6.Text = "mV/g";
            this.Unit7.Text = "mV/g";
            this.Unit8.Text = "mV/g";
            #endregion
            
            //判断硬件检测通道数和软件配置通道数是否匹配：
            int setChannelCount = 8; //预设通道数量
            int ChannelCount = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External).Length;


            if (ChannelCount == 0)
            {
                MessageBox.Show("未连接任何通道！请点击加载按钮加载基本配置！", "错 误", MessageBoxButtons.OK);
            }
            else if (ChannelCount < setChannelCount)//从数据库都出来后已经排序
            {
                MessageBox.Show("实际端口号小于设置端口号！", "错 误", MessageBoxButtons.OK);
            }
            else{
                try
                {
                    PhysicalChannel1.Text = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External)[0];
                    PhysicalChannel2.Text = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External)[1];
                    PhysicalChannel3.Text = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External)[2];
                    PhysicalChannel4.Text = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External)[3];
                    PhysicalChannel5.Text = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External)[4];
                    PhysicalChannel6.Text = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External)[5];
                    PhysicalChannel7.Text = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External)[6];
                    PhysicalChannel8.Text = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External)[7];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("请链接数据采集器");
                }
            }
            
            
        }
        //保存按钮操作，注意：数据库不能为空，数据库必须存在8个数据，因为用的是更新语句
        private void SS_Save_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("仅保留最新配置，确认保存吗？", "配置参数", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                MysqlHelper my = new MysqlHelper();

                string update_sql = "update diagnosis_ttb_parameterconfig set  ChannelNumber=@ChannelNumber, PhysicalChannel=@PhysicalChannel,MinimumValue=@MinimumValue,MaximumValue=@MaximumValue,SampleRate=@SampleRate,SampleNumber=@SampleNumber,Coupling=@Coupling,Sensitivity=@Sensitivity,Unit=@Unit where  ChannelNumber=@ChannelNumber";
                #region 一通道
                Dictionary<string, object> dic1 = new Dictionary<string, object>();
                dic1.Add("@ChannelNumber", (int)1);
                dic1.Add("@PhysicalChannel", PhysicalChannel1.Text);	//将其放入字典（类似JSON，采用键值对的方式传递）
                dic1.Add("@MinimumValu" + "e", (int)Min1.Value);
                dic1.Add("@MaximumValue", (int)Max1.Value);
                dic1.Add("@SampleRate", (int)SampleRate1.Value);
                dic1.Add("@SampleNumber", (int)SampleNumber1.Value);
                dic1.Add("@Coupling", coupling1.Text);
                dic1.Add("@Sensitivity", (double)Sensitivity1.Value);
                dic1.Add("@Unit", Unit1.Text);
                if (!my.MySqlPour(update_sql, dic1)) { MessageBox.Show("一通道失败"); };
                #endregion

                #region 二通道
                Dictionary<string, object> dic2 = new Dictionary<string, object>();
                dic2.Add("@ChannelNumber", (int)2);
                dic2.Add("@PhysicalChannel", PhysicalChannel2.Text);	//将其放入字典（类似JSON，采用键值对的方式传递）
                dic2.Add("@MinimumValu" + "e", (int)Min2.Value);
                dic2.Add("@MaximumValue", (int)Max2.Value);
                dic2.Add("@SampleRate", (int)SampleRate2.Value);
                dic2.Add("@SampleNumber", (int)SampleNumber2.Value);
                dic2.Add("@Coupling", coupling2.Text);
                dic2.Add("@Sensitivity", (double)Sensitivity2.Value);
                dic2.Add("@Unit", Unit2.Text);
                if (!my.MySqlPour(update_sql, dic2)) { MessageBox.Show("二通道失败"); };
                #endregion

                #region 三通道
                Dictionary<string, object> dic3 = new Dictionary<string, object>();
                dic3.Add("@ChannelNumber", (int)3);
                dic3.Add("@PhysicalChannel", PhysicalChannel3.Text);	//将其放入字典（类似JSON，采用键值对的方式传递）
                dic3.Add("@MinimumValu" + "e", (int)Min3.Value);
                dic3.Add("@MaximumValue", (int)Max3.Value);
                dic3.Add("@SampleRate", (int)SampleRate3.Value);
                dic3.Add("@SampleNumber", (int)SampleNumber3.Value);
                dic3.Add("@Coupling", coupling3.Text);
                dic3.Add("@Sensitivity", (double)Sensitivity3.Value);
                dic3.Add("@Unit", Unit3.Text);
                if (!my.MySqlPour(update_sql, dic3)) { MessageBox.Show("二通道失败"); };
                #endregion

                #region 四通道
                Dictionary<string, object> dic4 = new Dictionary<string, object>();
                dic4.Add("@ChannelNumber", (int)4);
                dic4.Add("@PhysicalChannel", PhysicalChannel4.Text);	//将其放入字典（类似JSON，采用键值对的方式传递）
                dic4.Add("@MinimumValu" + "e", (int)Min4.Value);
                dic4.Add("@MaximumValue", (int)Max4.Value);
                dic4.Add("@SampleRate", (int)SampleRate4.Value);
                dic4.Add("@SampleNumber", (int)SampleNumber4.Value);
                dic4.Add("@Coupling", coupling4.Text);
                dic4.Add("@Sensitivity", (double)Sensitivity4.Value);
                dic4.Add("@Unit", Unit4.Text);
                if (!my.MySqlPour(update_sql, dic4)) { MessageBox.Show("二通道失败"); };
                #endregion

                #region 五通道
                Dictionary<string, object> dic5 = new Dictionary<string, object>();
                dic5.Add("@ChannelNumber", (int)5);
                dic5.Add("@PhysicalChannel", PhysicalChannel5.Text);	//将其放入字典（类似JSON，采用键值对的方式传递）
                dic5.Add("@MinimumValu" + "e", (int)Min5.Value);
                dic5.Add("@MaximumValue", (int)Max5.Value);
                dic5.Add("@SampleRate", (int)SampleRate5.Value);
                dic5.Add("@SampleNumber", (int)SampleNumber5.Value);
                dic5.Add("@Coupling", coupling5.Text);
                dic5.Add("@Sensitivity", (double)Sensitivity5.Value);
                dic5.Add("@Unit", Unit5.Text);
                if (!my.MySqlPour(update_sql, dic5)) { MessageBox.Show("二通道失败"); };
                #endregion

                #region 六通道
                Dictionary<string, object> dic6 = new Dictionary<string, object>();
                dic6.Add("@ChannelNumber", (int)6);
                dic6.Add("@PhysicalChannel", PhysicalChannel6.Text);	//将其放入字典（类似JSON，采用键值对的方式传递）
                dic6.Add("@MinimumValu" + "e", (int)Min6.Value);
                dic6.Add("@MaximumValue", (int)Max6.Value);
                dic6.Add("@SampleRate", (int)SampleRate6.Value);
                dic6.Add("@SampleNumber", (int)SampleNumber6.Value);
                dic6.Add("@Coupling", coupling6.Text);
                dic6.Add("@Sensitivity", (double)Sensitivity6.Value);
                dic6.Add("@Unit", Unit6.Text);
                if (!my.MySqlPour(update_sql, dic6)) { MessageBox.Show("二通道失败"); };
                #endregion

                #region 七通道
                Dictionary<string, object> dic7 = new Dictionary<string, object>();
                dic7.Add("@ChannelNumber", (int)7);
                dic7.Add("@PhysicalChannel", PhysicalChannel7.Text);	//将其放入字典（类似JSON，采用键值对的方式传递）
                dic7.Add("@MinimumValu" + "e", (int)Min7.Value);
                dic7.Add("@MaximumValue", (int)Max7.Value);
                dic7.Add("@SampleRate", (int)SampleRate7.Value);
                dic7.Add("@SampleNumber", (int)SampleNumber7.Value);
                dic7.Add("@Coupling", coupling7.Text);
                dic7.Add("@Sensitivity", (double)Sensitivity7.Value);
                dic7.Add("@Unit", Unit7.Text);
                if (!my.MySqlPour(update_sql, dic7)) { MessageBox.Show("二通道失败"); };
                #endregion

                #region 八通道
                Dictionary<string, object> dic8 = new Dictionary<string, object>();
                dic8.Add("@ChannelNumber", (int)8);
                dic8.Add("@PhysicalChannel", PhysicalChannel8.Text);	//将其放入字典（类似JSON，采用键值对的方式传递）
                dic8.Add("@MinimumValu" + "e", (int)Min8.Value);
                dic8.Add("@MaximumValue", (int)Max8.Value);
                dic8.Add("@SampleRate", (int)SampleRate8.Value);
                dic8.Add("@SampleNumber", (int)SampleNumber8.Value);
                dic8.Add("@Coupling", coupling8.Text);
                dic8.Add("@Sensitivity", (double)Sensitivity8.Value);
                dic8.Add("@Unit", Unit8.Text);
                if (!my.MySqlPour(update_sql, dic8)) { MessageBox.Show("二通道失败"); };
                #endregion
            }
           
        }
        //加载按钮操作，加载数据库保存的最近一次的配置
        private void SS_Load_Click(object sender, EventArgs e)
        {
            #region 解决空格无法加载问题，保证所有的框都具有数值
            Min1.Value = 0;
            Max1.Value = 0;
            SampleRate1.Value = 0;
            SampleNumber1.Value = 0;
            Sensitivity1.Value = 0;
            Min2.Value = 0;
            Max2.Value = 0;
            SampleRate2.Value = 0;
            SampleNumber2.Value = 0;
            Sensitivity2.Value = 0;
            Min3.Value = 0;
            Max3.Value = 0;
            SampleRate3.Value = 0;
            SampleNumber3.Value = 0;
            Sensitivity3.Value = 0;
            Min4.Value = 0;
            Max4.Value = 0;
            SampleRate4.Value = 0;
            SampleNumber4.Value = 0;
            Sensitivity4.Value = 0;
            Min5.Value = 0;
            Max5.Value = 0;
            SampleRate5.Value = 0;
            SampleNumber5.Value = 0;
            Sensitivity5.Value = 0;
            Min6.Value = 0;
            Max6.Value = 0;
            SampleRate6.Value = 0;
            SampleNumber6.Value = 0;
            Sensitivity6.Value = 0;
            Min7.Value = 0;
            Max7.Value = 0;
            SampleRate7.Value = 0;
            SampleNumber7.Value = 0;
            Sensitivity7.Value = 0;
            Min8.Value = 0;
            Max8.Value = 0;
            SampleRate8.Value = 0;
            SampleNumber8.Value = 0;
            Sensitivity8.Value = 0;
            #endregion
            MysqlHelper my = new MysqlHelper();
            string find_sql = "select * from diagnosis_ttb_parameterconfig where ChannelNumber=@ChannelNumber";
            #region 一通道
            Dictionary<string, object> dic1 = new Dictionary<string, object>();
            dic1.Add("@ChannelNumber", (int)1);
            ArrayList al = my.SelectInfo(find_sql, dic1);
            ParameterConfig parameterConfig1 = new ParameterConfig();
            foreach(Object[] obj in al){	
	        parameterConfig1.ChannelNumber1 = (int)obj[0];	
            parameterConfig1.PhysicalChannel1=(string)obj[1];
            parameterConfig1.MinimumValue1=(int)obj[2];
            parameterConfig1.MaximumValue1 = (int)obj[3];
            parameterConfig1.SampleRate1 = (int)obj[4];
            parameterConfig1.SampleNumber1 = (int)obj[5];
            parameterConfig1.Coupling1=(string)obj[6];
            parameterConfig1.Sensitivity1 = (double)obj[7];
            parameterConfig1.Unit1 = (string)obj[8];
            }
            PhysicalChannel1.Text = parameterConfig1.PhysicalChannel1;
            Min1.Value = parameterConfig1.MinimumValue1;
            Max1.Value = parameterConfig1.MaximumValue1;
            SampleRate1.Value = parameterConfig1.SampleRate1;
            SampleNumber1.Value = parameterConfig1.SampleNumber1;
            coupling1.Text = parameterConfig1.Coupling1;
            Sensitivity1.Value =(decimal)parameterConfig1.Sensitivity1;
            Unit1.Text = parameterConfig1.Unit1;
            #endregion

            #region 二通道
            Dictionary<string, object> dic2 = new Dictionary<string, object>();
            dic2.Add("@ChannelNumber", (int)2);
            ArrayList a2 = my.SelectInfo(find_sql, dic2);
            ParameterConfig parameterConfig2 = new ParameterConfig();
            foreach (Object[] obj in a2)
            {
                parameterConfig2.ChannelNumber1 = (int)obj[0];
                parameterConfig2.PhysicalChannel1 = (string)obj[1];
                parameterConfig2.MinimumValue1 = (int)obj[2];
                parameterConfig2.MaximumValue1 = (int)obj[3];
                parameterConfig2.SampleRate1 = (int)obj[4];
                parameterConfig2.SampleNumber1 = (int)obj[5];
                parameterConfig2.Coupling1 = (string)obj[6];
                parameterConfig2.Sensitivity1 = (double)obj[7];
                parameterConfig2.Unit1 = (string)obj[8];
            }
            PhysicalChannel2.Text = parameterConfig2.PhysicalChannel1;
            Min2.Value = parameterConfig2.MinimumValue1;
            Max2.Value = parameterConfig2.MaximumValue1;
            SampleRate2.Value = parameterConfig2.SampleRate1;
            SampleNumber2.Value = parameterConfig2.SampleNumber1;
            coupling2.Text = parameterConfig2.Coupling1;
            Sensitivity2.Value = (decimal)parameterConfig2.Sensitivity1;
            Unit2.Text = parameterConfig2.Unit1;
            #endregion

            #region 三通道
            Dictionary<string, object> dic3 = new Dictionary<string, object>();
            dic3.Add("@ChannelNumber", (int)3);
            ArrayList a3 = my.SelectInfo(find_sql, dic3);
            ParameterConfig parameterConfig3 = new ParameterConfig();
            foreach (Object[] obj in a3)
            {
                parameterConfig3.ChannelNumber1 = (int)obj[0];
                parameterConfig3.PhysicalChannel1 = (string)obj[1];
                parameterConfig3.MinimumValue1 = (int)obj[2];
                parameterConfig3.MaximumValue1 = (int)obj[3];
                parameterConfig3.SampleRate1 = (int)obj[4];
                parameterConfig3.SampleNumber1 = (int)obj[5];
                parameterConfig3.Coupling1 = (string)obj[6];
                parameterConfig3.Sensitivity1 = (double)obj[7];
                parameterConfig3.Unit1 = (string)obj[8];
            }
            PhysicalChannel3.Text = parameterConfig3.PhysicalChannel1;
            Min3.Value = parameterConfig3.MinimumValue1;
            Max3.Value = parameterConfig3.MaximumValue1;
            SampleRate3.Value = parameterConfig3.SampleRate1;
            SampleNumber3.Value = parameterConfig3.SampleNumber1;
            coupling3.Text = parameterConfig3.Coupling1;
            Sensitivity3.Value = (decimal)parameterConfig3.Sensitivity1;
            Unit3.Text = parameterConfig3.Unit1;
            #endregion

            #region 四通道
            Dictionary<string, object> dic4 = new Dictionary<string, object>();
            dic4.Add("@ChannelNumber", (int)4);
            ArrayList a4 = my.SelectInfo(find_sql, dic4);
            ParameterConfig parameterConfig4 = new ParameterConfig();
            foreach (Object[] obj in a4)
            {
                parameterConfig4.ChannelNumber1 = (int)obj[0];
                parameterConfig4.PhysicalChannel1 = (string)obj[1];
                parameterConfig4.MinimumValue1 = (int)obj[2];
                parameterConfig4.MaximumValue1 = (int)obj[3];
                parameterConfig4.SampleRate1 = (int)obj[4];
                parameterConfig4.SampleNumber1 = (int)obj[5];
                parameterConfig4.Coupling1 = (string)obj[6];
                parameterConfig4.Sensitivity1 = (double)obj[7];
                parameterConfig4.Unit1 = (string)obj[8];
            }
            PhysicalChannel4.Text = parameterConfig4.PhysicalChannel1;
            Min4.Value = parameterConfig4.MinimumValue1;
            Max4.Value = parameterConfig4.MaximumValue1;
            SampleRate4.Value = parameterConfig4.SampleRate1;
            SampleNumber4.Value = parameterConfig4.SampleNumber1;
            coupling4.Text = parameterConfig4.Coupling1;
            Sensitivity4.Value = (decimal)parameterConfig4.Sensitivity1;
            Unit4.Text = parameterConfig4.Unit1;
            #endregion

            #region 五通道
            Dictionary<string, object> dic5 = new Dictionary<string, object>();
            dic5.Add("@ChannelNumber", (int)5);
            ArrayList a5 = my.SelectInfo(find_sql, dic5);
            ParameterConfig parameterConfig5 = new ParameterConfig();
            foreach (Object[] obj in a5)
            {
                parameterConfig5.ChannelNumber1 = (int)obj[0];
                parameterConfig5.PhysicalChannel1 = (string)obj[1];
                parameterConfig5.MinimumValue1 = (int)obj[2];
                parameterConfig5.MaximumValue1 = (int)obj[3];
                parameterConfig5.SampleRate1 = (int)obj[4];
                parameterConfig5.SampleNumber1 = (int)obj[5];
                parameterConfig5.Coupling1 = (string)obj[6];
                parameterConfig5.Sensitivity1 = (double)obj[7];
                parameterConfig5.Unit1 = (string)obj[8];
            }
            PhysicalChannel5.Text = parameterConfig5.PhysicalChannel1;
            Min5.Value = parameterConfig5.MinimumValue1;
            Max5.Value = parameterConfig5.MaximumValue1;
            SampleRate5.Value = parameterConfig5.SampleRate1;
            SampleNumber5.Value = parameterConfig5.SampleNumber1;
            coupling5.Text = parameterConfig5.Coupling1;
            Sensitivity5.Value = (decimal)parameterConfig5.Sensitivity1;
            Unit5.Text = parameterConfig5.Unit1;
            #endregion

            #region 六通道
            Dictionary<string, object> dic6 = new Dictionary<string, object>();
            dic6.Add("@ChannelNumber", (int)6);
            ArrayList a6 = my.SelectInfo(find_sql, dic6);
            ParameterConfig parameterConfig6 = new ParameterConfig();
            foreach (Object[] obj in a6)
            {
                parameterConfig6.ChannelNumber1 = (int)obj[0];
                parameterConfig6.PhysicalChannel1 = (string)obj[1];
                parameterConfig6.MinimumValue1 = (int)obj[2];
                parameterConfig6.MaximumValue1 = (int)obj[3];
                parameterConfig6.SampleRate1 = (int)obj[4];
                parameterConfig6.SampleNumber1 = (int)obj[5];
                parameterConfig6.Coupling1 = (string)obj[6];
                parameterConfig6.Sensitivity1 = (double)obj[7];
                parameterConfig6.Unit1 = (string)obj[8];
            }
            PhysicalChannel6.Text = parameterConfig6.PhysicalChannel1;
            Min6.Value = parameterConfig6.MinimumValue1;
            Max6.Value = parameterConfig6.MaximumValue1;
            SampleRate6.Value = parameterConfig6.SampleRate1;
            SampleNumber6.Value = parameterConfig6.SampleNumber1;
            coupling6.Text = parameterConfig6.Coupling1;
            Sensitivity6.Value = (decimal)parameterConfig6.Sensitivity1;
            Unit6.Text = parameterConfig6.Unit1;
            #endregion

            #region 七通道
            Dictionary<string, object> dic7 = new Dictionary<string, object>();
            dic7.Add("@ChannelNumber", (int)7);
            ArrayList a7 = my.SelectInfo(find_sql, dic7);
            ParameterConfig parameterConfig7 = new ParameterConfig();
            foreach (Object[] obj in a7)
            {
                parameterConfig7.ChannelNumber1 = (int)obj[0];
                parameterConfig7.PhysicalChannel1 = (string)obj[1];
                parameterConfig7.MinimumValue1 = (int)obj[2];
                parameterConfig7.MaximumValue1 = (int)obj[3];
                parameterConfig7.SampleRate1 = (int)obj[4];
                parameterConfig7.SampleNumber1 = (int)obj[5];
                parameterConfig7.Coupling1 = (string)obj[6];
                parameterConfig7.Sensitivity1 = (double)obj[7];
                parameterConfig7.Unit1 = (string)obj[8];
            }
            PhysicalChannel7.Text = parameterConfig7.PhysicalChannel1;
            Min7.Value = parameterConfig7.MinimumValue1;
            Max7.Value = parameterConfig7.MaximumValue1;
            SampleRate7.Value = parameterConfig7.SampleRate1;
            SampleNumber7.Value = parameterConfig7.SampleNumber1;
            coupling7.Text = parameterConfig7.Coupling1;
            Sensitivity7.Value = (decimal)parameterConfig7.Sensitivity1;
            Unit7.Text = parameterConfig7.Unit1;
            #endregion

            #region 八通道
            Dictionary<string, object> dic8 = new Dictionary<string, object>();
            dic8.Add("@ChannelNumber", (int)8);
            ArrayList a8 = my.SelectInfo(find_sql, dic8);
            ParameterConfig parameterConfig8 = new ParameterConfig();
            foreach (Object[] obj in a8)
            {
                parameterConfig8.ChannelNumber1 = (int)obj[0];
                parameterConfig8.PhysicalChannel1 = (string)obj[1];
                parameterConfig8.MinimumValue1 = (int)obj[2];
                parameterConfig8.MaximumValue1 = (int)obj[3];
                parameterConfig8.SampleRate1 = (int)obj[4];
                parameterConfig8.SampleNumber1 = (int)obj[5];
                parameterConfig8.Coupling1 = (string)obj[6];
                parameterConfig8.Sensitivity1 = (double)obj[7];
                parameterConfig8.Unit1 = (string)obj[8];
            }
            PhysicalChannel8.Text = parameterConfig8.PhysicalChannel1;
            Min8.Value = parameterConfig8.MinimumValue1;
            Max8.Value = parameterConfig8.MaximumValue1;
            SampleRate8.Value = parameterConfig8.SampleRate1;
            SampleNumber8.Value = parameterConfig8.SampleNumber1;
            coupling8.Text = parameterConfig8.Coupling1;
            Sensitivity8.Value = (decimal)parameterConfig8.Sensitivity1;
            Unit8.Text = parameterConfig8.Unit1;
            #endregion

        }

        private void SampleSetForm_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
