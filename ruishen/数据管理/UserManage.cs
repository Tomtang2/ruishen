using MySql.Data.MySqlClient;
using ruishen.数据库公告类;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ruishen.数据管理
{
    public partial class UserManage : Form
    {
        MysqlHelper mysql = null;
        ArrayList al = new ArrayList();
        //ArrayList temp_data = new ArrayList();
        private MySqlConnection conn = null;
        private MySqlCommand command;
        //private MySqlDataReader sdr;
        DataTable dtInfo = null;
        

        public UserManage()
        {
            InitializeComponent();
        }

        private void UserManage_refrush_Click(object sender, EventArgs e)
        {
            Register register = GenericSingleton<Register>.CreateInstrance();
            register.ShowDialog();

        }

        private void UserManage_find_Click(object sender, EventArgs e)
        {

            mysql = new MysqlHelper();
            String find_sql = "select id, username, password  from diagnosis_ttb_user ; ";
            Dictionary<string, object> dic = new Dictionary<string, object>();
           // dic.Add("@startTime", startTime.ToString());
            //dic.Add("@endTime", endTime.ToString());
            if (!mysql.MySqlPour(find_sql, dic))
            {
                MessageBox.Show("查询失败！");
            }
            al = mysql.SelectInfo(find_sql, dic);
            dtInfo = new DataTable();
            dtInfo.Columns.Add("序号");
            dtInfo.Columns.Add("账号");
            dtInfo.Columns.Add("密码");
            
            try
            {
                foreach (object[] b in al)
                {
                    dtInfo.Rows.Add(b);

                }

                #region datatable 样式
                UserManage_DataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                for (int i = 0; i < dtInfo.Columns.Count; i++)
                {
                    UserManage_DataGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                #endregion

            }
            catch (Exception ex)
            {
                
            }
           
            UserManage_DataGrid.DataSource = dtInfo;
            this.UserManage_DataGrid.Visible = true;



        }

        private void UserManage_delete_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow rowview in UserManage_DataGrid.Rows)
            {
                DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)rowview.Cells[0];

                if ((Convert.ToInt32(check.Value)) == 1)//如果被选中
                {
                    try
                    {
                        if (MessageBox.Show("确定要删除选中的行吗？", "小心", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            
                            //假设把每一行的id放在第二列
                            int LoadId = Convert.ToInt32(rowview.Cells[1].Value);
                            //LoadSampleRate = Convert.ToInt32(rowview.Cells[5].Value);
                            //DataTempStorage.TempNoiseSampleFrequency1 = LoadSampleRate;
                            String find_sql = "delete  from   diagnosis_ttb_user  where id=" + LoadId.ToString();

                            string constr = "server=localhost;database=faultdiagnosis;uid=root;pwd=ttb1996;charset=utf8;Allow User Variables=True;";
                            conn = new MySqlConnection(constr);
                            conn.Open();
                            command = new MySqlCommand(find_sql, conn);
                            command.ExecuteNonQuery();
                            conn.Close();

                            UserManage_find.PerformClick();
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("数据未删除");
                    }

                }
            }//遍历Gridview中的每一行 




        }
    }
}
