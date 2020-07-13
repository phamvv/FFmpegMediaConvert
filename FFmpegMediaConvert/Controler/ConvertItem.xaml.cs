using FFmpegMediaConvert.Buseniss;
using FFmpegMediaConvert.Buseniss.Audio;
using FFmpegMediaConvert.Buseniss.Video;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FFmpegMediaConvert.Controler
{
    /// <summary>
    /// Interaction logic for ConvertItem.xaml
    /// </summary>
    public partial class ConvertItem : UserControl
    {
        private string _inputFile;
        private string _outputFile;
        private VideoInfo _VideoFormat;
        private AudioInfo _AudioFormat;
        private bool _converting { get; set; } = false;
        private bool _Complete { get; set; } = false;

        public ConvertItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// if 'True' is converting, if 'False' is not convert
        /// </summary>
        public bool Converting
        {
            get { return _converting; }
            set
            {
                _converting = value;
                if (_converting == true)
                {
                    StartConvert();
                }
                else
                {
                    StopConvert();
                }

            }
        }

        /// <summary>
        /// get the converted status: if convert complete will return True.
        /// </summary>
        public bool Complete
        {
            get { return _Complete; }
        }

        /// <summary>
        /// set the outputs format will convert to
        /// </summary>
        /// <param name="inputFile">input file with full file path</param>
        /// <param name="OutputFile">output file with full file path</param>
        /// <param name="VideoFormatInfo"></param>
        /// <param name="audioFormatInfo"></param>
        public void SetOutputFormat(string inputFile, string OutputFile, VideoInfo VideoFormatInfo, AudioInfo audioFormatInfo)
        {
            _inputFile = inputFile;
            _outputFile = OutputFile;
            _VideoFormat = VideoFormatInfo;
            _AudioFormat = audioFormatInfo;
        }
        private void StopConvert()
        {
           
        }

        private void StartConvert()
        {
            _converting = true;
            _Complete = false;
            FileInfo file = new FileInfo(_inputFile);
            //  File.Copy(inPut, bien.filetam, true); // copy vào file tạm     
           // convertToMp4(inPut, Path.Combine(outPut, file.Name.Replace(file.Extension, ".mp4")), "libx265", VideoSize, _videoBitrate, _frameRate, _audioBitrate, cpu);

        }
    }
}
