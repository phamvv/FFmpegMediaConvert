using FFmpegMediaConvert.Buseniss;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Controls;

namespace FFmpegMediaConvert.Controler
{
    /// <summary>
    /// Interaction logic for ConvertItem.xaml
    /// </summary>
    public partial class ConvertItem : UserControl
    {
        private Thread thread;
        private string _FileName;
        private string _inputFile;
        private string _outputFolder;
        private string _VideoOutputFormat;
        private string _AudioOutputFormat;
        private bool _converting { get; set; } = false;
        private bool _Complete { get; set; } = false;

        public ConvertItem()
        {
            InitializeComponent();
        }

        private void ConvertFile(string inputFile, string outputFile)
        {
            thread = new Thread(new ThreadStart(() =>
            {
                using (Process proc = new Process())
                {
                    proc.StartInfo.FileName = PathFFMPEG.FFmpegPath;
                    if (File.Exists(outputFile)) File.Delete(outputFile);
                    proc.StartInfo.Arguments = "-i \"" + inputFile + "\" " + _VideoOutputFormat + " " + _AudioOutputFormat + " -map 0:v -map 0:a? -y \"" + outputFile + "\"";
                    Console.WriteLine(proc.StartInfo.Arguments);
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.RedirectStandardError = true;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.OutputDataReceived += Proc_OutputDataReceived;
                    proc.ErrorDataReceived += Proc_ErrorDataReceived;
                    proc.Start();
                    proc.BeginOutputReadLine();
                    proc.BeginErrorReadLine();
                    proc.WaitForExit();
                    proc.Close();
                    _Complete = true;
                }

            }));
            thread.IsBackground = true;
            thread.Start();
        }

        private void Proc_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)// if ffmpeg.exe exit , ReadLine would return null
                UpdateProgress(e.Data);
        }

        private void Proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)// if ffmpeg.exe exit , ReadLine would return null
                UpdateProgress(e.Data);
        }

        private void UpdateProgress(string line)
        {
            line = line.Replace(" ", "").Replace("fps=", "; FPS=").Replace("q=", "; Q=").Replace("size=", "; Size=").Replace("time=", "; Time=").Replace("bitrate=", "; Bitrate=").Replace("dup=", "; Dup=").Replace("drop=", "; Drop=").Replace("speed=", "; Speed=").ToLower();
           // Console.WriteLine(line);
            this.Dispatcher.Invoke(new UpdateTextCallback(this.UpdateInterface), new object[] { line.ToString() });           
        }

        public delegate void UpdateTextCallback(string message);

        private void UpdateInterface(string message)
        {            
            if (message.StartsWith("frame=", StringComparison.InvariantCulture))
            {
                txt_message.Text = message;             
                string[] chuoi = message.Split(';')[4].Split('=')[1].Split(':');
               progressBar.Value = (int.Parse(chuoi[0]) * 3600) + (int.Parse(chuoi[1]) * 60) + (int.Parse(chuoi[2].Split('.')[0]));
            }
            else if (message.Contains("duration:") == true && message.Contains("start:") == true && message.Contains("bitrate:") == true)
            {
                txt_message.Text = message;
                string[] chuoi = message.Split(',')[0].Split(':');
                progressBar.Maximum = (int.Parse(chuoi[1]) * 3600) + (int.Parse(chuoi[2]) * 60) + (int.Parse(chuoi[3].Split('.')[0]));
            }
        }

        public void AddFile(string file, string fileName)
        {
            _inputFile = file;
            txt_fileName.Text = fileName;
            progressBar.Value = 0;
        }

        /// <summary>
        /// get the converted status: if convert complete will return True.
        /// </summary>
        public bool Complete
        {
            get { return _Complete; }
        }

        public bool Converting
        {
            get { return _converting; }
        }

        public string GetFileName
        {
            get { return _FileName; }
        }

        /// <summary>
        /// set the outputs format will convert to
        /// </summary>
        /// <param name="inputFile">input file with full file path</param>
        /// <param name="OutputFile">output file with full file path</param>
        /// <param name="VideoFormatInfo"></param>
        /// <param name="audioFormatInfo"></param>
        public void SetOutputFile(string OutputFolder, string VideoOutputConvertInfo, string AudioOutputConvertInfo)
        {
            _outputFolder = OutputFolder;
            _VideoOutputFormat = VideoOutputConvertInfo;
            _AudioOutputFormat = AudioOutputConvertInfo;
        }

        public void StartConvert(string extendsion)
        {
            _converting = true;
            FileInfo file = new FileInfo(_inputFile);
            _FileName = file.Name;
            ConvertFile(_inputFile, Path.Combine(_outputFolder, file.Name.Replace(file.Extension, "."+ extendsion.Replace(".",""))));

        }

    }
}
