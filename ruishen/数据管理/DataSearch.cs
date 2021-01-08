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
using ruishen.公共中间量;
using ruishen.序列化和反序列化;
using ruishen.测试代码;

namespace ruishen.数据管理
{
    public partial class DataSearch : Form
    {
        MysqlHelper mysql = null;
        ArrayList al;
        ArrayList temp_data = new ArrayList();
        private MySqlConnection conn = null;
        private MySqlCommand command;
        private MySqlDataReader sdr;
        DataTable dtInfo = new DataTable();
        public static int LoadId, LoadSampleRate;
        string constr = "server=localhost;database=faultdiagnosis;uid=root;pwd=ttb1996;charset=utf8;Allow User Variables=True;";
        public string selectDatabaseName = null;

        /// <summary>
        /// 分页操作基础设置
        /// </summary>
        int pageSize = 0;     //每页显示行数
        int nMax = 0;         //总记录数
        int pageCount = 0;    //页数＝总记录数/每页显示行数
        int pageCurrent = 0;   //当前页号
        int nCurrent = 0;      //当前记录行
        DataSet ds = new DataSet();
        public DataSearch()
        {
            InitializeComponent();
        }

        private void DataSearch_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

      
        private void DS_Query_Click(object sender, EventArgs e)
        {
        
            mysql = new MysqlHelper();
            DateTime startTime = DS_StartTime.Value;
            DateTime endTime = DS_EndTime.Value;
            String find_sql = "select id ,StartTime,WheelSetSerialNumberOne,ResultLeftOne,ResultRightOne,WheelSetSerialNumberTwo,ResultLeftTwo,ResultRightTwo,User,TestBench,Factory from diagnosis_ttb_testresult";
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@start", startTime.ToString());
            dic.Add("@end", endTime.ToString());
            if (!mysql.MySqlPour(find_sql, dic))
            {
                MessageBox.Show("查询失败");
            }
            al = mysql.SelectInfo(find_sql, dic);
            dtInfo = new DataTable();
            dtInfo.Columns.Add("序号");
            dtInfo.Columns.Add("测量时间");
            dtInfo.Columns.Add("前轮轴号");
            dtInfo.Columns.Add("前左轴");
            dtInfo.Columns.Add("前右轴");
            dtInfo.Columns.Add("后轮轴号");
            dtInfo.Columns.Add("后左轴");
            dtInfo.Columns.Add("后右轴");
            dtInfo.Columns.Add("操作员");
            dtInfo.Columns.Add("试验台");
            dtInfo.Columns.Add("工厂");
            try
            {
                foreach (object[] b in al)
                {
                    dtInfo.Rows.Add(b);

                }

                DataSearchDataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                for (int i = 0; i < dtInfo.Columns.Count; i++)
                {
                    DataSearchDataGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

            }
            catch (Exception)
            {
            }
           
            InitDataSet();
            this.DataSearchDataGrid.Visible = true;
            this.bdnInfo.Visible = true;
            
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

        private void DS_Load_Click(object sender, EventArgs e)
        {
            
        }

       

        private void InitDataSet()
        {
            pageSize = 20;      //设置页面行数
            nMax = dtInfo.Rows.Count;

            pageCount = (nMax / pageSize);    //计算出总页数

            if ((nMax % pageSize) > 0) pageCount++;

            pageCurrent = 1;    //当前页数从1开始
            nCurrent = 0;       //当前记录数从0开始

            LoadData();
        }

        private void LoadData()
        {
            int nStartPos = 0;   //当前页面开始记录行
            int nEndPos = 0;     //当前页面结束记录行

            DataTable dtTemp = dtInfo.Clone();   //克隆DataTable结构框架

            if (pageCurrent == pageCount)
                nEndPos = nMax;
            else
                nEndPos = pageSize * pageCurrent;

            nStartPos = nCurrent;

            //bindingNavigatorCountItem.Text = pageCount.ToString();
            // bindingNavigatorPositionItem.Text = Convert.ToString(pageCurrent);

            //从元数据源复制记录行
            for (int i = nStartPos; i < nEndPos; i++)
            {
                dtTemp.ImportRow(dtInfo.Rows[i]);
                nCurrent++;
            }
            bdsInfo.DataSource = dtTemp;
            bdnInfo.BindingSource = bdsInfo;
            DataSearchDataGrid.DataSource = bdsInfo;
            TotalPage.Text = nMax.ToString();
            Page.Text = pageCurrent.ToString();
            toolStripLabelPage.Text = pageCount.ToString();
        }

        private void bdnInfo_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "首页")
            {
                pageCurrent = 2;
                if (pageCurrent <= 0)
                {
                    MessageBox.Show("已经是第一页，请点击“下一页”查看！");
                    return;
                }
                else
                {
                    nCurrent = pageSize * (pageCurrent - 1);
                }

                LoadData();

                pageCurrent--;
                if (pageCurrent <= 0)
                {
                    MessageBox.Show("已经是第一页，请点击“下一页”查看！");
                    return;
                }
                else
                {
                    nCurrent = pageSize * (pageCurrent - 1);
                }

                LoadData();
            }

            if (e.ClickedItem.Text == "上一页")
            {
                pageCurrent--;
                if (pageCurrent <= 0)
                {
                    MessageBox.Show("已经是第一页，请点击“下一页”查看！");
                    return;
                }
                else
                {
                    nCurrent = pageSize * (pageCurrent - 1);
                }

                LoadData();
            }
            if (e.ClickedItem.Text == "下一页")
            {
                pageCurrent++;
                if (pageCurrent > pageCount)
                {
                    MessageBox.Show("已经是最后一页，请点击“上一页”查看！");
                    return;
                }
                else
                {
                    nCurrent = pageSize * (pageCurrent - 1);
                }
                LoadData();
            }

            if (e.ClickedItem.Text == "尾页")
            {
                pageCurrent = pageCount;
                if (pageCurrent > pageCount)
                {
                    MessageBox.Show("已经是最后一页，请点击“上一页”查看！");
                    return;
                }
                else
                {
                    nCurrent = pageSize * (pageCurrent - 1);
                }
                LoadData();
            }

            if (e.ClickedItem.Text == "跳转")
            {
                pageCurrent = Convert.ToInt32(toolStripTextBox1.ToString());
                if (pageCurrent <= 0)
                {
                    MessageBox.Show("已经是第一页，请点击“下一页”查看！");
                    return;
                }
                else if (pageCurrent > pageCount)
                {
                    MessageBox.Show("已经是最后一页，请点击“上一页”查看！");
                    return;
                }
                else
                {
                    nCurrent = pageSize * (pageCurrent - 1);
                }
                LoadData();
            }
        }

        private void DataSearchDataGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int count = DataSearchDataGrid.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)DataSearchDataGrid.Rows[i].Cells[0];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (flag == true)
                {
                    checkCell.Value = false;
                }
                else
                {
                    continue;
                }
            }
        }

        private void DataSearch_Load(object sender, EventArgs e)
        {
            this.DS_StartTime.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day);//系统当前月份第一天
            this.DS_EndTime.Value = DateTime.Now.AddDays(1);//系统当前天+1
           
        }

        private void DS_Delete_Click(object sender, EventArgs e)
        {

            
           
        }

        private void Result_Click(object sender, EventArgs e)
        {
            DataResult dataResult = new DataResult();
            foreach (DataGridViewRow rowview in DataSearchDataGrid.Rows)
            {
                DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)rowview.Cells[0];

                if ((Convert.ToInt32(check.Value)) == 1)//如果被选中
                {

                    LoadId = Convert.ToInt32(rowview.Cells[1].Value);
                    dataResult.WheelOne.Text=DataSearchDataGrid.Rows[(LoadId-1)%pageSize].Cells[3].Value.ToString();
                    dataResult.WheelTwo.Text = DataSearchDataGrid.Rows[(LoadId - 1) % pageSize].Cells[6].Value.ToString();
                    dataResult.LeftForward.Text = DataSearchDataGrid.Rows[(LoadId - 1) % pageSize].Cells[4].Value.ToString();
                    dataResult.RightForward.Text = DataSearchDataGrid.Rows[(LoadId - 1) % pageSize].Cells[5].Value.ToString();
                    dataResult.LeftLast.Text = DataSearchDataGrid.Rows[(LoadId - 1) % pageSize].Cells[7].Value.ToString();
                    dataResult.RightLast.Text = DataSearchDataGrid.Rows[(LoadId - 1) % pageSize].Cells[8].Value.ToString();
                }
            }
            changeBackColor(dataResult.LeftForward, dataResult.LeftForward.Text);
            changeBackColor(dataResult.RightForward, dataResult.RightForward.Text);
            changeBackColor(dataResult.LeftLast, dataResult.LeftLast.Text);
            changeBackColor(dataResult.RightLast, dataResult.RightLast.Text);
            dataResult.Rich_TextBox.Text = "左前轮: " + dataResult.LeftForward.Text + System.Environment.NewLine
                + "右前轮: " + dataResult.RightForward.Text + System.Environment.NewLine
                + "左后轮: " + dataResult.LeftLast.Text + System.Environment.NewLine
                +"右后轮: "+dataResult.RightLast.Text;

            
            dataResult.ShowDialog();
        }
        private void changeBackColor(Label label,string result)
        {
            switch(result)
            {
                case "正常": label.BackColor = Color.Green; label.ForeColor = Color.White; break;
                case "超标": label.BackColor = Color.Red; label.ForeColor = Color.Black; break;
                case "不判断": label.BackColor = Color.Blue; label.ForeColor = Color.Black; break;
            }
        }






    }
}
