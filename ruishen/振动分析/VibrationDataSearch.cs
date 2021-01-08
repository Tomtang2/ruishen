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
using System.Threading;

namespace ruishen.振动分析
{
    public partial class VibrationDataSearch : Form
    {
        MysqlHelper mysql = null;
        ArrayList al ;
        ArrayList temp_data = new ArrayList();
        private MySqlConnection conn = null;
        private MySqlCommand command;
        private MySqlDataReader sdr;
        DataTable dtInfo=null;
       
        public static  int LoadId;
        string constr = "server=localhost;database=faultdiagnosis;uid=root;pwd=ttb1996;charset=utf8;Allow User Variables=True";
        DataDisplay display = null;

        /// <summary>
        /// 分页操作基础设置
        /// </summary>
        int pageSize = 0;     //每页显示行数
        int nMax = 0;         //总记录数
        int pageCount = 0;    //页数＝总记录数/每页显示行数
        int pageCurrent = 0;   //当前页号
        int nCurrent = 0;      //当前记录行
        DataSet ds = new DataSet();
    
        public VibrationDataSearch()
        {
            InitializeComponent();
        }

        private void DataSearch_Load(object sender, EventArgs e)
        {
            this.DS_StartTime.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day);//系统当前月份第一天
            this.DS_EndTime.Value = DateTime.Now.AddDays(1);//系统当前天+1
        }
        //查询按钮
        private void DS_Query_Click(object sender, EventArgs e)
        {
            try {
                mysql = new MysqlHelper();
                al = new ArrayList();
                DateTime start = DS_StartTime.Value;
                DateTime end = DS_EndTime.Value;
                Dictionary<string, object> dic = new Dictionary<string, object>();
                String find_sql = "select id,title,starttime,endtime,WheelSetSerialNumberOne,WheelSetSerialNumberTwo,user,TestBench,Factory,SampleFrequency,Comment from diagnosis_ttb_dataindex where  StartTime >= @start and StartTime <= @end ";
                dic.Add("@start", start);
                dic.Add("@end", end);
                //if (!mysql.SelectInfo(find_sql, dic))
                //{
                //    MessageBox.Show("查询失败");
                //}
                al = mysql.SelectInfo(find_sql, dic);
                dtInfo = new DataTable();
                dtInfo.Columns.Add("序号");
                dtInfo.Columns.Add("标题");
                dtInfo.Columns.Add("开始时间");
                dtInfo.Columns.Add("结束时间");
                dtInfo.Columns.Add("前轮轴号");
                dtInfo.Columns.Add("后轮轴号");
                dtInfo.Columns.Add("操作员");
                dtInfo.Columns.Add("试验台");
                dtInfo.Columns.Add("工厂");
                dtInfo.Columns.Add("采样频率");
                dtInfo.Columns.Add("备注");
                //dtInfo.Columns.Add("测点");
                //dtInfo.Columns.Add("采样频率");
                //dtInfo.Columns.Add("数据状态");
                //dtInfo.Columns.Add("时间");
                foreach (object[] b in al)
                {
                    dtInfo.Rows.Add(b);

                }

                //DataSearchDataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                for (int i = 0; i < dtInfo.Columns.Count; i++)
                {
                    //DataSearchDataGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.dtInfo.Columns[i].ReadOnly = true;
                   
                }
                InitDataSet();
                this.DataSearchDataGrid.Visible = true;
                this.bdnInfo.Visible = true;
                
            }catch(Exception ex)
            {
                MessageBox.Show("失败");
            }
           
           
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


        private void DataSearch_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        #region 保持勾选框单选
        private void DataSearchDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
        #endregion

        private void DS_Load_Click(object sender, EventArgs e)
        {
          
            VibrationDataQuery();
        }

      /// <summary>
      /// 查询数据库振动数据
      /// </summary>
        public void VibrationDataQuery() 
        {
            foreach (DataGridViewRow rowview in DataSearchDataGrid.Rows)
            {
                DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)rowview.Cells[0];

                if ((Convert.ToInt32(check.Value)) == 1)//如果被选中
                {
                    try
                    {
                        //假设把每一行的id放在第二列
                        LoadId = Convert.ToInt32(rowview.Cells[1].Value);
                     
                        //String find_sampleFrequency = "select SampleFrequency from  diagnosis_ttb_of1d1_vibration where id=" + LoadId.ToString();
                        //ArrayList SampleFreList = new ArrayList();
                        //SampleFreList = mysql.SelectInfo(find_sampleFrequency, null);
                        //foreach (object[] b in SampleFreList)
                        //{
                        //    DataTempStorage.TempVibrationSampleFrequency1 = (int)b[0];
                        //}
                        DateTime startSampleTime=DateTime.Now;
                        DateTime endSampleTime=DateTime.Now;
                        String find_sql = "select StartTime,EndTime,SampleFrequency from  diagnosis_ttb_dataindex where id=" + LoadId.ToString();
                        ArrayList StartAndEndTime = new ArrayList();
                        StartAndEndTime = mysql.SelectInfo(find_sql, null);
                        foreach (object[] b in StartAndEndTime)
                        {
                            startSampleTime = (DateTime)b[0];
                            endSampleTime = (DateTime)b[1];
                            DataTempStorage.TempVibrationSampleFrequency1=(int)b[2];
                        }
                        string channalNumber = "channelone";
                        switch (comboBox1.Text.Substring(0,1))
                        {
                            case "1": channalNumber = "channelone"; break;
                            case "2": channalNumber = "channeltwo"; break;
                            case "3": channalNumber = "channelthree"; break;
                            case "4": channalNumber = "channelfour"; break;
                            case "5": channalNumber = "channelfive"; break;
                            case "6": channalNumber = "channelsix"; break;
                            case "7": channalNumber = "channelseven"; break;
                            case "8": channalNumber = "channeleight"; break;
                        }
                        string finddata_sql = "select "+channalNumber+" from diagnosis_ttb_originvalue where sampletime>=@startSampleTime and sampletime<=@endSampleTime";
                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        dic.Add("@startSampleTime", startSampleTime);
                        dic.Add("@endSampleTime", endSampleTime);
                        ArrayList channelData = new ArrayList();
                        channelData= mysql.SelectInfo(finddata_sql,dic);
                        List<double[]> list=new List<double[]>();
                        foreach (object[] b in channelData)
                        {
                           list.Add((double[])Serialization.DeserializeObject((byte[])(b[0])));
                        }
                        double []tempData=new double[list.Count*list[0].Length];
                        int count = 0;
                        for (int i = 0; i < list.Count;i++ )
                        {
                            for (int j = 0; j < list[0].Length;j++ )
                            {
                                tempData[count++] = list[i][j];
                            }
                        }
                        DataTempStorage.TempVibrationData1 =tempData;
                       // MessageBox.Show(mm.Length.ToString());
                        //DataTempStorage.TempVibrationData1 = (double[])Serialization.DeserializeObject(DataSource(find_sql));//读取数据进行反序列化
                        display = GenericSingleton<DataDisplay>.CreateInstrance();
                        display.TopMost = true;
                        double dt = 1 / Convert.ToDouble(DataTempStorage.TempVibrationSampleFrequency1);
                        display.waveformGraph1.Caption = "振动数据";
                        display.waveformGraph1.PlotY(DataTempStorage.TempVibrationData1, 0, dt);
                        display.waveformGraph1.YAxes[0].Caption = "Acceleration/g";
                        display.Show();
                    } 
                    catch (Exception ex)
                    {
                        MessageBox.Show("失败");
                    }
                }
            }//遍历Gridview中的每一行 

        }
        /// <summary>
        /// 读取blob数据并进行数据处理
        /// </summary>
        /// <param name="find_sql">执行的查询语句</param>
        /// <returns>字节数组</returns>
        private byte[] DataSource(string find_sql) {
            byte[] buffer = new byte[1];
            conn = new MySqlConnection(constr);
            conn.Open();
            command = new MySqlCommand(find_sql,conn);
            sdr = command.ExecuteReader();
            sdr.Read();
            buffer=new Byte[sdr.GetBytes(0,0,null,0,int.MaxValue)];
            sdr.GetBytes(0,0,buffer,0,buffer.Length);
            sdr.Dispose();
            sdr.Close();
            conn.Dispose();
            conn.Close();
            return buffer;
        }

        private void bdnInfo_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
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

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {

        }

        private void bdnInfo_RefreshItems(object sender, EventArgs e)
        {

        }
       
    }
}
