using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ruishen.公共中间量;

namespace ruishen.实时监测
{
    public partial class VibrationStatistical : Form
    {
        public VibrationStatistical()
        {
            InitializeComponent();
        }

        private void ChannelSound8_Click(object sender, EventArgs e)
        {
            if (ChannelSound8.Text == "播放")
            {
                ChannelSound8.Text = "停止";
                SoundPlayPointer.PlaySound = 4;
            }
            else
            {
                ChannelSound8.Text = "播放";
                SoundPlayPointer.PlaySound = 0;
            }
        }

        private void ChannelSound5_Click(object sender, EventArgs e)
        {
            if (ChannelSound5.Text == "播放")
            {
                ChannelSound5.Text = "停止";
                SoundPlayPointer.PlaySound = 1;
            }
            else
            {
                ChannelSound5.Text = "播放";
                SoundPlayPointer.PlaySound = 0;
            }
        }

        private void ChannelSound6_Click(object sender, EventArgs e)
        {
            if (ChannelSound6.Text == "播放")
            {
                ChannelSound6.Text = "停止";
                SoundPlayPointer.PlaySound = 2;
            }
            else
            {
                ChannelSound6.Text = "播放";
                SoundPlayPointer.PlaySound = 0;
            }
        }

        private void ChannelSound7_Click(object sender, EventArgs e)
        {
            if (ChannelSound7.Text == "播放")
            {
                ChannelSound7.Text = "停止";
                SoundPlayPointer.PlaySound = 3;
            }
            else
            {
                ChannelSound7.Text = "播放";
                SoundPlayPointer.PlaySound = 0;
            }
        }
    }
}
