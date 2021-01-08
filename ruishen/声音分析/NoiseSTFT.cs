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
using DigitalSignalProcessing;
using NationalInstruments.UI;

namespace ruishen.声音分析
{
    public partial class NoiseSTFT : Form
    {
        public NoiseSTFT()
        {
            InitializeComponent();
        }

        double[,] result;
        double Val;
        double x1, y1;
        double[] Time;
        double[] Frequency;
        double[] data;
        private double Find2DMax(double[,] Wave)
        {
            double Max = 0;
            for (int i = 0; i < Wave.GetLength(0); i++)
                for (int j = 0; j < Wave.GetLength(1); j++)
                    if (Max < Wave[i, j])
                        Max = Wave[i, j];
            return Max;
        }

        private void NoiseSTFT_Load(object sender, EventArgs e)
        {
            try
            {

                data = DataTempStorage.TempNoiseData1;

                result = DigitalSignalProcessing.NiSignalProcessing.STFT(data, DataTempStorage.TempNoiseSampleFrequency1, "海明窗", 256, 20, 0, data.Length - 1, false, out Time, out Frequency);
                Val = Find2DMax(result);
                slide3.Range = new Range(0, Val);
                slide3.Value = Val;
                x1 = Time[Time.Length - 1];
                y1 = Frequency[Frequency.Length - 1];
                slide2.Range = new Range(0, y1);
                slide2.Value = y1;
                slide1.Range = new Range(0, x1);
                slide1.Value = x1;
                intensityGraph2.XAxes[0].Mode = IntensityAxisMode.Fixed;
                intensityGraph2.YAxes[0].Mode = IntensityAxisMode.Fixed;
                intensityGraph2.YAxes[0].Range = new Range(0, y1);
                intensityGraph2.XAxes[0].Range = new Range(0, x1);

                intensityGraph2.Plots[0].PixelInterpolation = true;
                intensityGraph2.ColorScales[0].ColorMap.Clear();
                intensityGraph2.ColorScales[0].Range = new NationalInstruments.UI.Range(0, Val);
                intensityGraph2.ColorScales[0].InterpolateColor = true;
                intensityGraph2.ColorScales[0].ScaleType = ScaleType.Linear;
                intensityGraph2.ColorScales[0].LowColor = Color.Blue;
                intensityGraph2.ColorScales[0].ColorMap.Add(Val * 0.25, Color.Aqua);
                intensityGraph2.ColorScales[0].ColorMap.Add(Val * 0.5, Color.Green);
                intensityGraph2.ColorScales[0].ColorMap.Add(Val * 0.75, Color.Yellow);
                intensityGraph2.ColorScales[0].HighColor = Color.Red;

                intensityGraph2.Plots[0].Plot(result, 0, Time[2] - Time[1], Frequency[0], Frequency[1] - Frequency[0]);//
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据未加载！请先加载数据");
            }
        }

        private void Transfer_Click(object sender, EventArgs e)
        {
            intensityGraph2.XAxes[0].Mode = IntensityAxisMode.Fixed;
            intensityGraph2.YAxes[0].Mode = IntensityAxisMode.Fixed;
            intensityGraph2.YAxes[0].Range = new Range(0, slide2.Value);
            intensityGraph2.XAxes[0].Range = new Range(0, slide1.Value);

            intensityGraph2.ColorScales[0].ColorMap.Clear();
            intensityGraph2.ColorScales[0].Range = new NationalInstruments.UI.Range(0, slide3.Value);
            intensityGraph2.ColorScales[0].InterpolateColor = true;
            intensityGraph2.ColorScales[0].ScaleType = ScaleType.Linear;
            intensityGraph2.ColorScales[0].LowColor = Color.Blue;
            intensityGraph2.ColorScales[0].ColorMap.Add(slide3.Value * 0.25, Color.Aqua);
            intensityGraph2.ColorScales[0].ColorMap.Add(slide3.Value * 0.5, Color.Green);
            intensityGraph2.ColorScales[0].ColorMap.Add(slide3.Value * 0.75, Color.Yellow);
            intensityGraph2.ColorScales[0].HighColor = Color.Red;
            intensityGraph2.Plots[0].ClearData();
            intensityGraph2.Plots[0].Plot(result, 0, Time[2] - Time[1], Frequency[0], Frequency[1] - Frequency[0]);//
        }
    }
}
