using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments;
using NationalInstruments.UI;
using NationalInstruments.UI.WindowsForms;
using System.Threading;

namespace ruishen.公共中间量
{
    public partial class DataAnalysisCommonForm : Form
    {
        public DataAnalysisCommonForm()
        {
            InitializeComponent();
        }

        private void setPositionButton_Click(object sender, EventArgs e)
        {
            MusicPlayProcess.Enabled = false;
            double xPosition = (double)changeXPositionNumericEdit.Value;
            double yPosition = (double)changeYPositionNumericEdit.Value;
            cursor.MoveCursor(xPosition, yPosition);
        }

        private void cursorModeSwitch_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            bool indexControlsEnabled = false;
            if (cursorModeSwitch.Value)
            {
                cursor.SnapMode = CursorSnapMode.ToPlot;
                indexControlsEnabled = true;
            }
            else
            {
                cursor.SnapMode = CursorSnapMode.Floating;
                indexControlsEnabled = false;
            }

            changeCursorIndexNumericEdit.Enabled = indexControlsEnabled;
            cursorMoveBackButton.Enabled = indexControlsEnabled;
            cursorMoveNextButton.Enabled = indexControlsEnabled;
        }

        private void cursor_AfterMove(object sender, AfterMoveXYCursorEventArgs e)
        {
            changeXPositionNumericEdit.Value = cursor.XPosition;
            changeYPositionNumericEdit.Value = cursor.YPosition;
            changeCursorIndexNumericEdit.Value = cursor.GetCurrentIndex();
        }

        private void cursorMoveBackButton_Click(object sender, EventArgs e)
        {
            cursor.MovePrevious();
        }

        private void cursorMoveNextButton_Click(object sender, EventArgs e)
        {
            cursor.MoveNext();
        }

        private void changeCursorIndexNumericEdit_AfterChangeValue(object sender, AfterChangeNumericValueEventArgs e)
        {
            cursor.MoveCursor((int)changeCursorIndexNumericEdit.Value);
        }
       public static double  plt = 1;
        
        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            try
            {
                axWindowsMediaPlayer1.URL = Application.StartupPath + "\\music\\" + DataTempStorage.MusicLoadId1.ToString() + ".wav";
                MusicPlayProcess.Enabled = true;
                plt = axWindowsMediaPlayer1.newMedia(Application.StartupPath + "\\music\\" + DataTempStorage.MusicLoadId1.ToString() + ".wav").duration;
                axWindowsMediaPlayer1.Ctlcontrols.play();
             
            }
            catch (Exception)
            {

                MessageBox.Show("音频！");
            }
        }

       

        private void MusicPlayProcess_Tick(object sender, EventArgs e)
        {
           if (axWindowsMediaPlayer1.playState.ToString() == "1")
                {
                    MusicPlayProcess.Enabled = false;
                }
                cursor.XPosition = DataTempStorage.Timespan * axWindowsMediaPlayer1.Ctlcontrols.currentPosition / plt;
            
           
           
            
        }

        private void DataAnalysisCommonForm_Load(object sender, EventArgs e)
        {
           
           
        }
    }
}
