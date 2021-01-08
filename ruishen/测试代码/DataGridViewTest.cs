using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ruishen.测试代码
{
    public partial class DataGridViewTest : Form
    {
        public DataGridViewTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  DataTable table = new DataTable();
          //  DataGridViewTextBoxColumn acCode = new DataGridViewTextBoxColumn();
          //  acCode.Name = "acCode";
          //  acCode.DataPropertyName = "acCode";
          //  acCode.HeaderText = "A/C Code";
          ////  table.Columns.Add(acCode);
          // // dataGridView1.Columns.Add(acCode);

          //  DataGridViewCheckBoxColumn checkboxIsDisplay = new DataGridViewCheckBoxColumn();
          //  checkboxIsDisplay.HeaderText = "前端显示";
          //  checkboxIsDisplay.Name = "isDisplay";
          //  checkboxIsDisplay.FlatStyle = FlatStyle.Standard;
          //  checkboxIsDisplay.ReadOnly = false;
          //  dataGridView1.Columns.Add(checkboxIsDisplay);
          // // dgvVouchers.Columns.Add(acCode);
            DataGridViewRow dr = new DataGridViewRow();
            dr.CreateCells(dataGridView1);
            dr.Cells[0].Value = "h1";
            dr.Cells[1].Value = "cc";
            dataGridView1.Rows.Insert(0, dr);　　　　　//插入的数据作为第一行显示
            ((DataGridViewCheckBoxCell)dataGridView1.Rows[0].Cells[2]).Value = true;
            //dgv.Rows.Add(dr);      
        }

        private void DataGridViewTest_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AllowUserToAddRows = false;
        }
    }
}
