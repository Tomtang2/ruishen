using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ruishen.Entity;

namespace ruishen.公共中间量
{
    public partial class ProductInformationCheckForm : Form
    {
        public ProductInformationCheckForm()
        {
            InitializeComponent();
        }

        private void ConfirmAcquisition_Click(object sender, EventArgs e)
        {
            DataTempStorage.IsCollectData1 = true;
            this.Close();
        }

        private void ProductInformationCheckForm_Load(object sender, EventArgs e)
        {
            try
            {
                WheelModel1.Text = ProductStyle.WheelModel11;
                if (DataTempStorage.FirstSet == null)
                {
                    groupBox1.Visible = false;
                }
                else 
                {
                    label4.Text = DataTempStorage.FirstSet.Count.ToString();
                    if (DataTempStorage.FirstSet.Count<=DataTempStorage.CurrentForwardWheelNumber)
                    {

                    }
                    else
                    {
                        ForwardWheelBearNumber.Text = DataTempStorage.FirstSet.ElementAt(DataTempStorage.CurrentForwardWheelNumber).ToString();
                    }
                   
                }
                if (DataTempStorage.SecondSet == null)
                {
                    groupBox2.Visible = false;
                }
                else
                {
                    groupBox1.Visible = true;
                    groupBox2.Visible = true;
                    label5.Text = DataTempStorage.SecondSet.Count.ToString();
                    if (DataTempStorage.SecondSet.Count <= DataTempStorage.CurrentBehindWheelNumber)
                    {

                    }
                    else
                    {
                        LastWheelBearNumber.Text = DataTempStorage.SecondSet.ElementAt(DataTempStorage.CurrentBehindWheelNumber).ToString();
                    }
                    
                }
                
                WheelModel2.Text = ProductStyle.WheelModel21;
                
                
                if (ProductStyle.WheelModel11 == null && ProductStyle.WheelSetSerialNumber11 == null  && ProductStyle.WheelModel21 == null && ProductStyle.WheelSetSerialNumber21 == null)
                {
                    ConfirmAcquisition.Enabled =false;
                }
                else {
                    ConfirmAcquisition.Enabled =true ;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("请重新配置！");
                ConfirmAcquisition.Enabled = false;
            }

        }

        private void ReturnConfiguration_Click(object sender, EventArgs e)
        {
            this.Close();
            //ruishen.参数配置.ThresholdSetForm thresholdSetForm = GenericSingleton<ruishen.参数配置.ThresholdSetForm>.CreateInstrance();
          
            //thresholdSetForm.TopMost = true;
            //thresholdSetForm.Show();

        }
    }
}
