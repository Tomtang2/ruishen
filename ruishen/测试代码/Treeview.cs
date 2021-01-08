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
using ruishen.Entity;
using System.Collections;

namespace ruishen.测试代码
{
    public partial class Treeview : Form
    {
        MysqlHelper my;
        ArrayList al=new ArrayList();
        DataTable DataTable1;
        public Treeview()
        {
            InitializeComponent();
            try { 
            string find_sql = "SELECT DISTINCT BearingDesignation FROM diagnosis_ttb_parts_bearing";
            my = new MysqlHelper();
            //Dictionary<string, object> dic = new Dictionary<string, object>();
            al = my.SelectInfo(find_sql, null);
                    foreach (object[] b in al)
                        {
                            treeView1.Nodes[0].Nodes.Add((string)b[0]);
                         }
                   }
            catch(MySqlException ex){
                
            }
            
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
            my = new MysqlHelper();
            TreeNode node = treeView1.SelectedNode;
            if (node == null) return;
            if (node.Level != 1) return;
            string find_sql = "select * from diagnosis_ttb_parts_bearing where BearingDesignation=@BearingDesignation";
            Dictionary<string,object> dic = new Dictionary<string, object>();
            dic.Add("@BearingDesignation", node.Text);
            al = my.SelectInfo(find_sql, dic);
            DataTable1 = new DataTable();
            
            DataTable1.Columns.Add("序号");
            DataTable1.Columns.Add("轴承名称");
            DataTable1.Columns.Add("国内新信号");
            DataTable1.Columns.Add("国内旧型号");
            DataTable1.Columns.Add("轴承内径(mm)");
            DataTable1.Columns.Add("轴承外径(mm)");
            DataTable1.Columns.Add("宽度(mm)");
            DataTable1.Columns.Add("Cr1(kN)");
            DataTable1.Columns.Add("Cor1(kN)");
            DataTable1.Columns.Add("脂润滑转速(r/min)");
            DataTable1.Columns.Add("油润滑转速(r/min)");
            DataTable1.Columns.Add("质量(kg)");
            try { 
                        foreach(object[] b in al){
                                    DataTable1.Rows.Add(b);
              
                                 }
                    dataGridView1.DataSource = DataTable1;
                    dataGridView1.Columns[4].Width = 150;
                    dataGridView1.Columns[5].Width = 150;
                    dataGridView1.Columns[8].Width = 150;
                    dataGridView1.Columns[9].Width = 150;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }catch(Exception ex){
                MessageBox.Show("已不存在数据");
            }
            
        }

        private void Tr_B_delete_Click(object sender, EventArgs e)
        {
          
            string selectedIndex = this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["序号"].Value.ToString();
            string delete_sql = "delete  FROM diagnosis_ttb_parts_bearing where Id="+selectedIndex;
            my = new MysqlHelper();
            if(!my.MySqlPour(delete_sql,null)){
                MessageBox.Show("失败");
            }
          //  DataTable1.Reset();

            dataGridView1.DataSource = DataTable1;
          //  this.Refresh();
        }

        private void Treeview_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
