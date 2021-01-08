using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ruishen.公共中间量;




namespace ruishen.声音算法代码
{
    class WavGenerate
    {
        struct WaveHeader
        {
            public string sGroupID; // RIFF
            public uint dwFileLength; // total file length minus 8, which is taken up by RIFF
            public string sRiffType; // always WAVE
        };

        struct WaveFormatChunk
        {
            public string sChunkID;         // Four bytes: "fmt "
            public uint dwChunkSize;        // Length of header in bytes
            public ushort wFormatTag;       // 1 (MS PCM)
            public ushort wChannels;        // Number of channels
            public uint dwSamplesPerSec;    // Frequency of the audio in Hz... 44100
            public uint dwAvgBytesPerSec;   // for estimating RAM allocation
            public ushort wBlockAlign;      // sample frame size, in bytes
            public ushort wBitsPerSample;    // bits per sample
        };

        struct WaveDataChunk
        {
            public string sChunkID;     // "data"
            public uint dwChunkSize;    // Length of header in bytes
            public double[] shortArray;  // 8-bit audio
        };
        /// <summary>
        /// 生产wav文件
        /// </summary>
        /// <param name="signal">输入信号数组</param>
        /// <param name="filePath">文件路径</param>
        /// <returns>静态的wav数组</returns>
        public static double[] WaveGenerate(double[] signal,String filePath,double SamplesPerSec)
        {
            double maxNumber = signal.Max();
            #region 数据初始化
            WaveHeader header = new WaveHeader { };
            header.dwFileLength = 0;
            header.sGroupID = "RIFF";
            header.sRiffType = "WAVE";
            WaveFormatChunk format = new WaveFormatChunk { };
            format.sChunkID = "fmt ";
            format.dwChunkSize = 16;
            format.wFormatTag = 1;
            format.wChannels = 2;
          //  format.dwSamplesPerSec =(uint)20480;//女声是谱线数*2.5*1.2;男声是谱线数*2.5
            format.dwSamplesPerSec = (uint)(SamplesPerSec*1.3);
            format.wBitsPerSample = 16;
            format.wBlockAlign = (ushort)(format.wChannels * (format.wBitsPerSample / 8));
            format.dwAvgBytesPerSec = format.dwSamplesPerSec * format.wBlockAlign;
            WaveDataChunk data = new WaveDataChunk { };
            data.shortArray = new double[0];
            data.dwChunkSize = 0;
            data.sChunkID = "data";
            #endregion

            #region 数据填充
            uint numSamples = format.dwSamplesPerSec * format.wChannels;
            data.shortArray = new double[signal.Length];


            int amplitude = 32760;
           // double freq = 204.8f;
            double freq = 102.4f;
           
            double t = (Math.PI * 2 * freq) / (format.dwSamplesPerSec * format.wChannels);
            double cc = 20000 / (maxNumber * t * amplitude);
           // double t = 0.3;
            
            for (uint i = 0; i <signal.Length-1; i++)
            {
                 //Fill with a simple sine wave at max amplitude
                for (int channel = 0; channel < format.wChannels; channel++)
                {
                    double temp=cc*t*signal[i];
                    if (temp > 1) temp = 1;
                   data.shortArray[i + channel] = Convert.ToInt32(temp*amplitude);
                   // data.shortArray[i + channel] = Convert.ToInt32(amplitude *  signal[i]/maxNumber);
                    //data.shortArray[i ] = amplitude * signal[i];
                }
            }

            //data.shortArray[i] = amplitude * signal[i] * Math.Sin(t * i);

            data.dwChunkSize = (uint)(data.shortArray.Length * (format.wBitsPerSample / 8));
            #endregion

            #region 文件保存
            // Create a file (it always overwrites)
            FileStream fileStream = new FileStream(filePath, FileMode.Create);

            // Use BinaryWriter to write the bytes to the file
            BinaryWriter writer = new BinaryWriter(fileStream);

            // Write the header
            writer.Write(header.sGroupID.ToCharArray());
            writer.Write(header.dwFileLength);
            writer.Write(header.sRiffType.ToCharArray());

            // Write the format chunk
            writer.Write(format.sChunkID.ToCharArray());
            writer.Write(format.dwChunkSize);
            writer.Write(format.wFormatTag);
            writer.Write(format.wChannels);
            writer.Write(format.dwSamplesPerSec);
            writer.Write(format.dwAvgBytesPerSec);
            writer.Write(format.wBlockAlign);
            writer.Write(format.wBitsPerSample);

            // Write the data chunk
            writer.Write(data.sChunkID.ToCharArray());
            writer.Write(data.dwChunkSize);
            foreach (short dataPoint in data.shortArray)
            {
                writer.Write(dataPoint);
            }

            writer.Seek(4, SeekOrigin.Begin);
            uint filesize = (uint)writer.BaseStream.Length;
            writer.Write(filesize - 8);

            // Clean up
            writer.Close();
            fileStream.Close();
            return data.shortArray;
            #endregion
        }
    }
}
