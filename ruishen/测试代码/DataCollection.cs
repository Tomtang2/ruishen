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

namespace ruishen.测试代码
{
    public partial class DataCollection : Form
    {
        public DataCollection()
        {
            InitializeComponent();
        }
        #region 数据库操作实例
        private void button1_Click(object sender, EventArgs e)
        {
            MysqlHelper my = new MysqlHelper();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            string insert_sql = "insert into diagnosis_ttb_parameterconfig  values(@ChannelNumber, @PhysicalChannel, @MinimumValue, @MaximumValue, @SampleRate, @SampleNumber, @Coupling, @Sensitivity, @Unit)";
            string update_sql = "update diagnosis_ttb_parameterconfig set  ChannelNumber=@ChannelNumber, PhysicalChannel=@PhysicalChannel,MinimumValue=@MinimumValue,MaximumValue=@MaximumValue,SampleRate=@SampleRate,SampleNumber=@SampleNumber,Coupling=@Coupling,Sensitivity=@Sensitivity,Unit=@Unit where  ChannelNumber=@ChannelNumber";
            string delete_sql = "DELETE FROM diagnosis_ttb_parameterconfig where ChannelNumber=1";
            dic.Add("@ChannelNumber", (int)1);
            dic.Add("@PhysicalChannel", "nihao");	//将其放入字典（类似JSON，采用键值对的方式传递）
            dic.Add("@MinimumValu"+"e", (int)-9);
            dic.Add("@MaximumValue",(int) 9);
            dic.Add("@SampleRate", (int)2000);
            dic.Add("@SampleNumber", (int)200000);
            dic.Add("@Coupling", "AC");
            dic.Add("@Sensitivity", (double)50);
            dic.Add("@Unit", "V/g");
            if (!my.MySqlPour(insert_sql, dic)) { MessageBox.Show("失败"); };

        }
        #endregion
    }
}
