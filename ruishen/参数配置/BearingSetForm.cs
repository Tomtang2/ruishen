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
using ruishen.Entity;

namespace ruishen.参数配置
{
    public partial class BearingSetForm : Form
    {
        MysqlHelper my;
        ArrayList al = new ArrayList();
        DataTable DataTable1;
        public BearingSetForm()
        {
            InitializeComponent();

            try
            {
                string find_sql = "SELECT DISTINCT BearingDesignation FROM diagnosis_ttb_parts_bearing";
                my = new MysqlHelper();
                //Dictionary<string, object> dic = new Dictionary<string, object>();
                al = my.SelectInfo(find_sql, null);
                foreach (object[] b in al)
                {
                    treeView1.Nodes[0].Nodes.Add((string)b[0]);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("未查询到数据");
            }
        }
        //鼠标双击显示轴承型号加参数
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            my = new MysqlHelper();
            TreeNode node = treeView1.SelectedNode;
            if (node == null) return;
            if (node.Level != 1) return;
            string find_sql = "select * from diagnosis_ttb_parts_bearing where BearingDesignation=@BearingDesignation";
            Dictionary<string, object> dic = new Dictionary<string, object>();
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
            try
            {
                foreach (object[] b in al)
                {
                    DataTable1.Rows.Add(b);

                }
                dataGridView1.DataSource = DataTable1;
               
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                for (int i = 0; i < DataTable1.Columns.Count;i++ )
                {
                    dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("已不存在数据");
            }
            this.dataGridView1.Visible = true;
        }
        //轴承删除
        private void B_BearingDelete_Click(object sender, EventArgs e)
        {
            string selectedIndex = this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["序号"].Value.ToString();//获取当前被选择行的索引
            string delete_sql = "delete  FROM diagnosis_ttb_parts_bearing where Id=" + selectedIndex;//sql删除语句
            my = new MysqlHelper();//实例化数据库对象
            if (!my.MySqlPour(delete_sql, null))//进行数据库删除，如果未删除，弹出失败窗口
            {
                MessageBox.Show("数据删除失败");
            }
            TreeNode node = treeView1.SelectedNode;//获取当前选择的节点数
            string find_sql = "select * from diagnosis_ttb_parts_bearing where BearingDesignation=@BearingDesignation";//根据节点数查询所有符合选择名称的轴承
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@BearingDesignation", node.Text);
            al = my.SelectInfo(find_sql, dic);//查询数据库
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
            try
            {
                foreach (object[] b in al)
                {
                    DataTable1.Rows.Add(b);

                }
                dataGridView1.DataSource = DataTable1;
                //dataGridView1.Columns[1].Width = 150;
                //dataGridView1.Columns[4].Width = 120;
                //dataGridView1.Columns[5].Width = 120;
                //dataGridView1.Columns[7].Width = 80;
                //dataGridView1.Columns[8].Width = 80;
                //dataGridView1.Columns[9].Width = 150;
                //dataGridView1.Columns[10].Width = 150;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//表标题对中
                for (int i = 0; i < DataTable1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//表细胞单元格对中
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("已不存在数据");
            }

            dataGridView1.DataSource = DataTable1;
        }

        private void BearingSetForm_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int count = dataGridView1.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
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
       
    }
}
