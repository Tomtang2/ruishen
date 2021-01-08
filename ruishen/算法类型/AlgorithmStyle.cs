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
using MySql.Data.MySqlClient;
using ruishen.数据库公告类;
using System.Collections;
using ruishen.Entity;
using ruishen.公共中间量;


namespace ruishen.算法类型
{
    public partial class AlgorithmStyle : Form
    {
        MysqlHelper my;
        ArrayList al = new ArrayList();
        ArrayList tickedCharacter = new ArrayList();
        DataTable DataTable1= new DataTable();
       // string insert_sql = "insert into diagnosis_ttb_algorithm values(@ParameterClassify,@ParameterName,@IsDisplay,@IsStandard,@ThresholdConfig) ";
        string insert_sql = "insert into diagnosis_ttb_algorithm values(@ParameterClassify,@ParameterName) ";
        string delete_sql = "delete from diagnosis_ttb_algorithm";
        string find_sql = "select distinct * from diagnosis_ttb_algorithm  ";
        ThresholdSetWindows1 thresholdSetWindows = null;
        public AlgorithmStyle()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }
        public void QueryAlgorithmInit( string query) {
          
                my = new MysqlHelper();
                al = my.SelectInfo(query, null);
              
                DataTable1.Columns.Add("参数类型");
                DataTable1.Columns.Add("参数名称");


                dataGridView1.DataSource = DataTable1;
                DataGridViewCheckBoxColumn checkboxIsDisplay = new DataGridViewCheckBoxColumn();
                checkboxIsDisplay.HeaderText = "前端显示";
                checkboxIsDisplay.Name = "isDisplay";
                checkboxIsDisplay.FlatStyle = FlatStyle.Standard;
                checkboxIsDisplay.ReadOnly = false;
               
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.UseColumnTextForButtonValue = true;
                buttonColumn.HeaderText = "阈值";
                buttonColumn.Text = "设置阈值";
                buttonColumn.Name = "setThreshold";

                if (al != null)
                {
                    foreach (object[] b in al)
                    {
                        DataTable1.Rows.Add(b);
                        switch (b[1].ToString())
                        {
                            case "上四分位": UpQ3.CheckState = CheckState.Checked;  break;
                            case "下四分位": DownQ1.CheckState = CheckState.Checked; break;
                            case "中位数": MiddleQ2.CheckState = CheckState.Checked; break;
                            case "四分位距": IQR.CheckState = CheckState.Checked; break;
                            case "上界": UpThreshold.CheckState = CheckState.Checked; break;
                            case "下界": DownThreshold.CheckState = CheckState.Checked; break;
                            case "均值": Mean.CheckState = CheckState.Checked; break;
                            case "方差": Variance.CheckState = CheckState.Checked; break;
                            case "均方根值": RMS.CheckState = CheckState.Checked; break;
                            case "歪度": Skewness.CheckState = CheckState.Checked; break;
                            case "峭度": Kurtosis.CheckState = CheckState.Checked; break;
                            case "峰度": Peak.CheckState = CheckState.Checked; break;
                            case "频率幅值": FrequencyA.CheckState = CheckState.Checked; break;
                        //    case "频率重心": FrequencyGravity.CheckState = CheckState.Checked; break;
                            case "峰值频率": PeakFrequency.CheckState = CheckState.Checked; break;
                            case "中心频率": CenterFrequency.CheckState = CheckState.Checked; break;

                        }

                    }
                }

            tickedCharacter = my.SelectInfo("select * from diagnosis_ttb_isticked", null);
            ArrayList list = new ArrayList();
            if(tickedCharacter!=null)
            {
                foreach (object[] b in tickedCharacter)
                {

                    switch (b[1].ToString())
                    {
                        case "上四分位": ThresholdUpDownValue.UpQuartile_Up = (double)b[2]; ThresholdUpDownValue.UpQuartile_Down = (double)b[3];break;
                        case "下四分位": ThresholdUpDownValue.DownQuartile_Up = (double)b[2]; ThresholdUpDownValue.DownQuartile_Down = (double)b[3]; break;
                        case "中位数": ThresholdUpDownValue.Median_Up1 = (double)b[2]; ThresholdUpDownValue.Median_Up1 = (double)b[3]; break;
                        case "四分位距": ThresholdUpDownValue.DistanceQuartile_Up = (double)b[2]; ThresholdUpDownValue.DistanceQuartile_Down = (double)b[3]; break;
                        case "上界": ThresholdUpDownValue.Upperbound_Up = (double)b[2]; ThresholdUpDownValue.Upperbound_Down = (double)b[3]; break;
                        case "下界": ThresholdUpDownValue.Downbound_Up = (double)b[2]; ThresholdUpDownValue.Downbound_Down = (double)b[3]; break;
                        case "均值": ThresholdUpDownValue.Average_Up = (double)b[2]; ThresholdUpDownValue.Average_Down = (double)b[3]; break;
                        case "方差": ThresholdUpDownValue.Variance_Up = (double)b[2]; ThresholdUpDownValue.Variance_Down = (double)b[3]; break;
                        case "均方根值": ThresholdUpDownValue.RMS_Value_Up1 = (double)b[2]; ThresholdUpDownValue.RMS_Value_Down1 = (double)b[3]; break;
                        case "歪度": ThresholdUpDownValue.Skewness_Up = (double)b[2]; ThresholdUpDownValue.Skewness_Down = (double)b[3]; break;
                        case "峭度": ThresholdUpDownValue.Kurtosis_Up = (double)b[2]; ThresholdUpDownValue.Kurtosis_Down = (double)b[3]; break;
                        case "峰度": ThresholdUpDownValue.Peak_Up = (double)b[2]; ThresholdUpDownValue.Peak_Down = (double)b[3]; break;
                        case "频率幅值": ThresholdUpDownValue.FrequencyA_Up = (double)b[2]; ThresholdUpDownValue.FrequencyA_Down = (double)b[3]; break;
                       
                        case "峰值频率": ThresholdUpDownValue.Frequency_Up = (double)b[2]; ThresholdUpDownValue.Frequency_Down = (double)b[3]; break;
                        case "中心频率": ThresholdUpDownValue.OctaveValue_Up = (double)b[2]; ThresholdUpDownValue.OctaveValue_Down = (double)b[3]; break;
                    }
                    list.Add(b[1].ToString());
                }
            }


            

                this.dataGridView1.Columns.Add(checkboxIsDisplay);
                this.dataGridView1.Columns.Add(buttonColumn);
                
               
             
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                for (int i = 0; i < DataTable1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                    dataGridView1.Visible = true;

                    if (list != null&&list.Count!=0)
                    {
                        DataTempStorage.AlgorithmList1 = list;
                        if (list.Count == 1)
                        {
                            for (int i = 0; i < al.Count; i++)
                            {

                                if (DataTable1.Rows[i]["参数名称"].ToString() == list[0].ToString())
                                {
                                    ((DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0]).Value = true;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < al.Count; i++)
                            {

                                if (DataTable1.Rows[i]["参数名称"].ToString() == list[0].ToString())
                                {
                                    ((DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0]).Value = true;
                                }
                                if (DataTable1.Rows[i]["参数名称"].ToString() == list[1].ToString())
                                {
                                    ((DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0]).Value = true;
                                }
                            }
                        }

                    }
            

        }

        public void QueryAlgorithm(string query)
        {
            DataTable1.Clear();
            my = new MysqlHelper();
            al = my.SelectInfo(query, null);
   
            if (al != null)
            {
                foreach (object[] b in al)
                {
                    DataTable1.Rows.Add(b);

                }
                dataGridView1.DataSource = DataTable1;
           
            }
            dataGridView1.Visible = true;

        }
       private string ParameterClassify;//参数类型
       private string ParameterName;//参数名称
      
        private void Save_Click(object sender, EventArgs e)
        {
            my = new MysqlHelper();
            my.MySqlPour(delete_sql,null);
            if (UpQ3.Checked)
            {
                ParameterClassify = label1.Text;
                ParameterName = UpQ3.Text;
                my = new MysqlHelper();
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@ParameterClassify", ParameterClassify);
                dic.Add("@ParameterName", ParameterName);
             
                if (!my.MySqlPour(insert_sql, dic)) { MessageBox.Show("失败"); }
            }
            if (DownQ1.Checked)
            {
                ParameterClassify = label1.Text;
                ParameterName = DownQ1.Text;
                my = new MysqlHelper();
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@ParameterClassify", ParameterClassify);
                dic.Add("@ParameterName", ParameterName);
              
                if (!my.MySqlPour(insert_sql, dic)) { MessageBox.Show("失败"); }
            }

            if (MiddleQ2.Checked)
            {
                ParameterClassify = label1.Text;
                ParameterName = MiddleQ2.Text;
                my = new MysqlHelper();
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@ParameterClassify", ParameterClassify);
                dic.Add("@ParameterName", ParameterName);
               
                if (!my.MySqlPour(insert_sql, dic)) { MessageBox.Show("失败"); }
            }


            if (IQR.Checked)
            {
                ParameterClassify = label1.Text;
                ParameterName = IQR.Text;
                my = new MysqlHelper();
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@ParameterClassify", ParameterClassify);
                dic.Add("@ParameterName", ParameterName);

                if (!my.MySqlPour(insert_sql, dic)) { MessageBox.Show("失败"); }
            }

            if (UpThreshold.Checked)
            {
                ParameterClassify = label1.Text;
                ParameterName = UpThreshold.Text;
                my = new MysqlHelper();
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@ParameterClassify", ParameterClassify);
                dic.Add("@ParameterName", ParameterName);

                if (!my.MySqlPour(insert_sql, dic)) { MessageBox.Show("失败"); }
            }

            if (DownThreshold.Checked)
            {
                ParameterClassify = label1.Text;
                ParameterName = DownThreshold.Text;
                my = new MysqlHelper();
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@ParameterClassify", ParameterClassify);
                dic.Add("@ParameterName", ParameterName);

                if (!my.MySqlPour(insert_sql, dic)) { MessageBox.Show("失败"); }
            }

            if (Mean.Checked)
            {
                ParameterClassify = label2.Text;
                ParameterName = Mean.Text;
                my = new MysqlHelper();
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@ParameterClassify", ParameterClassify);
                dic.Add("@ParameterName", ParameterName);

                if (!my.MySqlPour(insert_sql, dic)) { MessageBox.Show("失败"); }
            }

            if (Variance.Checked)
            {
                ParameterClassify = label2.Text;
                ParameterName = Variance.Text;
                my = new MysqlHelper();
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@ParameterClassify", ParameterClassify);
                dic.Add("@ParameterName", ParameterName);

                if (!my.MySqlPour(insert_sql, dic)) { MessageBox.Show("失败"); }
            }

            if (RMS.Checked)
            {
                ParameterClassify = label2.Text;
                ParameterName = RMS.Text;
                my = new MysqlHelper();
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@ParameterClassify", ParameterClassify);
                dic.Add("@ParameterName", ParameterName);

                if (!my.MySqlPour(insert_sql, dic)) { MessageBox.Show("失败"); }
            }

            if (Skewness.Checked)
            {
                ParameterClassify = label2.Text;
                ParameterName = Skewness.Text;
                my = new MysqlHelper();
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@ParameterClassify", ParameterClassify);
                dic.Add("@ParameterName", ParameterName);

                if (!my.MySqlPour(insert_sql, dic)) { MessageBox.Show("失败"); }
            }

            if (Kurtosis.Checked)
            {
                ParameterClassify = label2.Text;
                ParameterName = Kurtosis.Text;
                my = new MysqlHelper();
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@ParameterClassify", ParameterClassify);
                dic.Add("@ParameterName", ParameterName);

                if (!my.MySqlPour(insert_sql, dic)) { MessageBox.Show("失败"); }
            }

            if (Peak.Checked)
            {
                ParameterClassify = label2.Text;
                ParameterName = Peak.Text;
                my = new MysqlHelper();
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@ParameterClassify", ParameterClassify);
                dic.Add("@ParameterName", ParameterName);

                if (!my.MySqlPour(insert_sql, dic)) { MessageBox.Show("失败"); }
            }

            if (FrequencyA.Checked)
            {
                ParameterClassify = label3.Text;
                ParameterName = FrequencyA.Text;
                my = new MysqlHelper();
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@ParameterClassify", ParameterClassify);
                dic.Add("@ParameterName", ParameterName);

                if (!my.MySqlPour(insert_sql, dic)) { MessageBox.Show("失败"); }
            }

            if (FrequencyGravity.Checked)
            {
                ParameterClassify = label3.Text;
                ParameterName = FrequencyGravity.Text;
                my = new MysqlHelper();
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@ParameterClassify", ParameterClassify);
                dic.Add("@ParameterName", ParameterName);

                if (!my.MySqlPour(insert_sql, dic)) { MessageBox.Show("失败"); }
            }

            if (PeakFrequency.Checked)
            {
                ParameterClassify = label3.Text;
                ParameterName = PeakFrequency.Text;
                my = new MysqlHelper();
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@ParameterClassify", ParameterClassify);
                dic.Add("@ParameterName", ParameterName);

                if (!my.MySqlPour(insert_sql, dic)) { MessageBox.Show("失败"); }
            }

            if (CenterFrequency.Checked)
            {
                ParameterClassify = label4.Text;
                ParameterName = CenterFrequency.Text;
                my = new MysqlHelper();
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@ParameterClassify", ParameterClassify);
                dic.Add("@ParameterName", ParameterName);

                if (!my.MySqlPour(insert_sql, dic)) { MessageBox.Show("失败"); }
            }
            QueryAlgorithm(find_sql);
        }
        string insert_isticked = "insert into diagnosis_ttb_isticked values(@Id,@ParameterNameTicked,@UpThresholdTicked,@DownThresholdTicked)";
        private void MakeSure_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("保存？", "算法类型", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dr==DialogResult.OK){
             ArrayList list = new ArrayList();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if ((bool)dataGridView1.Rows[i].Cells[0].EditedFormattedValue == true)
                {
                  list.Add( DataTable1.Rows[i][1].ToString());
                }
            }
            if (list.Count >= 3)
            {
                MessageBox.Show("实时数据显示最大为2，请去除超出的数据！");
            }
            else 
            {
                my.MySqlPour("truncate table diagnosis_ttb_isticked", null);
                for (int i = 0; i < list.Count;i++ )
                {
                    Dictionary<string, object> dic2 = new Dictionary<string, object>();
                    switch (list[i].ToString())
                    {
                        case "上四分位": dic2.Add("@ParameterNameTicked", list[i].ToString()); dic2.Add("@UpThresholdTicked", ThresholdUpDownValue.UpQuartile_Up); dic2.Add("@DownThresholdTicked", ThresholdUpDownValue.UpQuartile_Down); my.MySqlPour(insert_isticked, dic2); break;
                        case "下四分位": dic2.Add("@ParameterNameTicked", list[i].ToString()); dic2.Add("@UpThresholdTicked", ThresholdUpDownValue.DownQuartile_Up); dic2.Add("@DownThresholdTicked", ThresholdUpDownValue.DownQuartile_Down); my.MySqlPour(insert_isticked, dic2); break;
                        case "中位数": dic2.Add("@ParameterNameTicked", list[i].ToString()); dic2.Add("@UpThresholdTicked", ThresholdUpDownValue.Median_Up1); dic2.Add("@DownThresholdTicked", ThresholdUpDownValue.Median_Down1); my.MySqlPour(insert_isticked, dic2); break;
                        case "四分位距": dic2.Add("@ParameterNameTicked", list[i].ToString()); dic2.Add("@UpThresholdTicked", ThresholdUpDownValue.DistanceQuartile_Up); dic2.Add("@DownThresholdTicked", ThresholdUpDownValue.DistanceQuartile_Down); my.MySqlPour(insert_isticked, dic2); break;
                        case "上界": dic2.Add("@ParameterNameTicked", list[i].ToString()); dic2.Add("@UpThresholdTicked", ThresholdUpDownValue.Upperbound_Up); dic2.Add("@DownThresholdTicked", ThresholdUpDownValue.Upperbound_Down); my.MySqlPour(insert_isticked, dic2); break;
                        case "下界": dic2.Add("@ParameterNameTicked", list[i].ToString()); dic2.Add("@UpThresholdTicked", ThresholdUpDownValue.Downbound_Up); dic2.Add("@DownThresholdTicked", ThresholdUpDownValue.Downbound_Down); my.MySqlPour(insert_isticked, dic2); break;
                        case "均值": dic2.Add("@ParameterNameTicked", list[i].ToString()); dic2.Add("@UpThresholdTicked", ThresholdUpDownValue.Average_Up); dic2.Add("@DownThresholdTicked", ThresholdUpDownValue.Average_Down); my.MySqlPour(insert_isticked, dic2); break;
                        case "方差": dic2.Add("@ParameterNameTicked", list[i].ToString()); dic2.Add("@UpThresholdTicked", ThresholdUpDownValue.Variance_Up); dic2.Add("@DownThresholdTicked", ThresholdUpDownValue.Variance_Down); my.MySqlPour(insert_isticked, dic2); break;
                        case "均方根值": dic2.Add("@ParameterNameTicked", list[i].ToString()); dic2.Add("@UpThresholdTicked", ThresholdUpDownValue.RMS_Value_Up1); dic2.Add("@DownThresholdTicked", ThresholdUpDownValue.RMS_Value_Down1); my.MySqlPour(insert_isticked, dic2); break;
                        case "歪度": dic2.Add("@ParameterNameTicked", list[i].ToString()); dic2.Add("@UpThresholdTicked", ThresholdUpDownValue.Skewness_Up); dic2.Add("@DownThresholdTicked", ThresholdUpDownValue.Skewness_Down); my.MySqlPour(insert_isticked, dic2); break;
                        case "峭度": dic2.Add("@ParameterNameTicked", list[i].ToString()); dic2.Add("@UpThresholdTicked", ThresholdUpDownValue.Kurtosis_Up); dic2.Add("@DownThresholdTicked", ThresholdUpDownValue.Kurtosis_Down); my.MySqlPour(insert_isticked, dic2); break;
                        case "峰度": dic2.Add("@ParameterNameTicked", list[i].ToString()); dic2.Add("@UpThresholdTicked", ThresholdUpDownValue.Peak_Up); dic2.Add("@DownThresholdTicked", ThresholdUpDownValue.Peak_Down); my.MySqlPour(insert_isticked, dic2); break;
                        case "峰值频率": dic2.Add("@ParameterNameTicked", list[i].ToString()); dic2.Add("@UpThresholdTicked", ThresholdUpDownValue.Frequency_Up); dic2.Add("@DownThresholdTicked", ThresholdUpDownValue.Frequency_Down); my.MySqlPour(insert_isticked, dic2); break;
                        case "频率幅值": dic2.Add("@ParameterNameTicked", list[i].ToString()); dic2.Add("@UpThresholdTicked", ThresholdUpDownValue.FrequencyA_Up); dic2.Add("@DownThresholdTicked", ThresholdUpDownValue.FrequencyA_Down); my.MySqlPour(insert_isticked, dic2); break;
                        case "中心频率": dic2.Add("@ParameterNameTicked", list[i].ToString()); dic2.Add("@UpThresholdTicked", ThresholdUpDownValue.OctaveValue_Up); dic2.Add("@DownThresholdTicked", ThresholdUpDownValue.OctaveValue_Down); my.MySqlPour(insert_isticked, dic2); break;
                    }
               
                }
                
                DataTempStorage.AlgorithmList1 = list;
                DataTempStorage.CenterFrequency1 =Convert.ToDouble(ComboBoxCenterFrequency.Text);
                DataTempStorage.FrequencyAmplitude1 = Convert.ToDouble(TextFrequencyA.Text);
                this.Visible=false;
            }
           
                }

            
            
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "setThreshold")
            {
                thresholdSetWindows = GenericSingleton<ThresholdSetWindows1>.CreateInstrance();
                thresholdSetWindows.TopLevel = true;
                thresholdSetWindows.Text = DataTable1.Rows[e.RowIndex][1].ToString();
                thresholdSetWindows.ShowDialog();
            }
           
            //MessageBox.Show("行: " + e.RowIndex.ToString() + ", 列: " + e.ColumnIndex.ToString() + "; 被点击了");
            
        }

        private void AlgorithmStyle_Load(object sender, EventArgs e)
        {
            QueryAlgorithmInit(find_sql);
        }
    }
}
