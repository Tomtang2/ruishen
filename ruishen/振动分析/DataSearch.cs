using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ruishen.数据库公告类;
using System.Collections;

namespace ruishen.振动分析
{
    public partial class DataSearch : Form
    {
        MysqlHelper mysql = null;
        ArrayList al = new ArrayList();
        DataTable DataTable1=null;
        public DataSearch()
        {
            InitializeComponent();
        }

        private void DataSearch_Load(object sender, EventArgs e)
        {
            this.DS_StartTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.DS_EndTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
           // this.StartTime. == System.DateTime.Now;

        }
        //查询按钮
        private void DS_Query_Click(object sender, EventArgs e)
        {
            mysql = new MysqlHelper();
            string startTime = DS_StartTime.Value.ToString();
            string endTime = DS_EndTime.Value.ToString();
            String find_sql = "select * from  diagnosis_ttb_of1d1 where DataTime between @startTime and @endTime"; 
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@startTime", startTime);
            dic.Add("@endTime", endTime);
            al = mysql.SelectInfo(find_sql, dic);
            DataTable1 = new DataTable();
            DataTable1.Columns.Add("序号");
            DataTable1.Columns.Add("设备名称");
            DataTable1.Columns.Add("工厂编号");
            DataTable1.Columns.Add("测点");
            DataTable1.Columns.Add("采样频率");
            DataTable1.Columns.Add("数据状态");
            DataTable1.Columns.Add("时间");
            DataTable1.Columns.Add("数据");
            try {
                foreach (object[] b in al)
                {
                    DataTable1.Rows.Add(b);

                }

                DataSearchDataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                for (int i = 0; i < DataTable1.Columns.Count; i++)
                {
                    DataSearchDataGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                
            }catch(Exception ex)
            {
            }
            DataSearchDataGrid.DataSource = DataTable1;
            if(mysql.MySqlPour(find_sql,dic)){
                MessageBox.Show("成功");
            }
            //string strcon = "server=localhost;database=faultdiagnosis;uid=root;pwd=ttb1996;charset=utf8";
            //MySqlConnection con = new MySqlConnection(strcon);
            //try {
            //    con.Open();//打开数据库
            //    string sqlSel = "select * from diagnosis_ttb_parameterconfig where id=1";
            //    MySqlCommand com = new MySqlCommand(sqlSel, con);
            //    MySqlDataReader reader = com.ExecuteReader();
            //    //MessageBox.Show((string)reader[0]);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            //}
        }

        private void DataSearch_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
