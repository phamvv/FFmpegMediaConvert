using FFmpegMediaConvert.Buseniss.Video;
using FFmpegMediaConvert.Enums;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace FFmpegMediaConvert.Controler
{
    /// <summary>
    /// Interaction logic for VideoSelect.xaml
    /// </summary>
    public partial class VideoSelect : UserControl
    {
        private VideoInfo _videoInfo { get; set; }
        private ObservableCollection<VideoInfo> _VideoInforList = new ObservableCollection<VideoInfo>();
        private ObservableCollection<Ratio> _VideoRatioList = new ObservableCollection<Ratio>();
        private ObservableCollection<Encoder> _VideoEncoderList = new ObservableCollection<Encoder>();

        /// <summary>
        /// load all data default to interface
        /// </summary>
        public void LoadData()
        {
            //add default value for Videos  
            _VideoInforList.Add(new VideoInfo { VideoName = "UHD4K:2160p", VideosHight = (Enums.VideoHight)2160, Bitrate = 9000, Code = VideoCode.libx264, FPS = 30, Ratio = VideoRatio.Ratio_16x9 });
            _VideoInforList.Add(new VideoInfo { VideoName = "QHD:1440p", VideosHight = (Enums.VideoHight)1440, Bitrate = 6500, Code = VideoCode.libx264, FPS = 30, Ratio = VideoRatio.Ratio_16x9 });
            _VideoInforList.Add(new VideoInfo { VideoName = "FullHD:1080p", VideosHight = (Enums.VideoHight)1080, Bitrate = 4000, Code = VideoCode.libx264, FPS = 30, Ratio = VideoRatio.Ratio_16x9 });
            _VideoInforList.Add(new VideoInfo { VideoName = "HD:720p", VideosHight = (Enums.VideoHight)720, Bitrate = 3000, Code = VideoCode.libx264, FPS = 30, Ratio = VideoRatio.Ratio_16x9 });
            _VideoInforList.Add(new VideoInfo { VideoName = "DVD:480p", VideosHight = (Enums.VideoHight)480, Bitrate = 1500, Code = VideoCode.libx264, FPS = 30, Ratio = VideoRatio.Ratio_16x9 });
            _VideoInforList.Add(new VideoInfo { VideoName = "VCD:360p", VideosHight = (Enums.VideoHight)360, Bitrate = 900, Code = VideoCode.libx264, FPS = 30, Ratio = VideoRatio.Ratio_16x9 });
            _VideoInforList.Add(new VideoInfo { VideoName = "SGA:240p", VideosHight = (Enums.VideoHight)240, Bitrate = 600, Code = VideoCode.libx264, FPS = 30, Ratio = VideoRatio.Ratio_16x9 });
            cb_VideosSelected.ItemsSource = _VideoInforList;
            cb_VideosSelected.DisplayMemberPath = "VideoName";
            cb_VideosSelected.SelectedIndex = 3;

            //Add videos Ratio
            _VideoRatioList.Add(new Ratio { RatioName = "16:9", VideoRatio = VideoRatio.Ratio_16x9 });
            _VideoRatioList.Add(new Ratio { RatioName = "21:9", VideoRatio = VideoRatio.Ratio_21x9 });
            _VideoRatioList.Add(new Ratio { RatioName = "3:2", VideoRatio = VideoRatio.Ratio_3x2 });
            _VideoRatioList.Add(new Ratio { RatioName = "4:3", VideoRatio = VideoRatio.Ratio_4x3 });
            _VideoRatioList.Add(new Ratio { RatioName = "5:3", VideoRatio = VideoRatio.Ratio_5x3 });
            _VideoRatioList.Add(new Ratio { RatioName = "5:4", VideoRatio = VideoRatio.Ratio_5x4 });
            _VideoRatioList.Add(new Ratio { RatioName = "8:5", VideoRatio = VideoRatio.Ratio_8x5 });
            cb_Ratio.ItemsSource = _VideoRatioList;
            cb_Ratio.DisplayMemberPath = "RatioName";
            cb_Ratio.SelectedIndex = 0;

            //add videos Encoder
            _VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.copy, CoderName = "copy" });
            _VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.libx264, CoderName = "H264" });
            _VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.libopenh264, CoderName = "OPEN_H264" });
            _VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.libx265, CoderName = "H265" });
            _VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.Hap, CoderName = "HAP" });
            _VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.jpeg2000, CoderName = "JPEG_2000" });
            _VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.libaomAV1, CoderName = "AOM_AV1" });
            _VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.libkvazaar, CoderName = "AAR" });
            _VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.librav1e, CoderName = "AV1E" });
            _VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.libtheora, CoderName = "THEORA" });
            _VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.libvpx, CoderName = "VPX" });
            _VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.libwebp, CoderName = "WEBP" });
            _VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.libxavs2, CoderName = "XAVS2" });
            _VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.libxvid, CoderName = "XVID" });
            _VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.mpeg2, CoderName = "MPEG2" });
            _VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.png, CoderName = "PNG" });
            _VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.ProRes, CoderName = "PRORES" });
            cb_Code.ItemsSource = _VideoEncoderList;
            cb_Code.DisplayMemberPath = "CoderName";
            cb_Code.SelectedIndex = 1;
           

        }

        public VideoSelect()
        {
            InitializeComponent();        
        }

        public VideoInfo Value
        {
            get { return _videoInfo; }
            set { _videoInfo = value; }
        }

        private void GetVideosSize()
        {
            var item = ((VideoInfo)cb_VideosSelected.SelectedItem);
            if (item != null)
            {
                txt_Width.Text = item.VideosWidth.ToString();
                txt_Hight.Text = ((int)item.VideosHight).ToString();
                txt_bitRate.Text = item.Bitrate.ToString();
                txt_frameRate.Text = item.FPS.ToString();
            }
        }
        private void SetVideosEncoder(Encoder code)
        {
            foreach(var item in _VideoInforList)
            {
                item.Code = code.VideoCode;
            }    
        }
        private void cb_VideosSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetVideosSize();          
        }

        private void cb_Ratio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (Ratio)cb_Ratio.SelectedItem;
            if(item != null)
            {
                foreach(var m in _VideoInforList)
                {
                    m.Ratio = item.VideoRatio;
                }
                GetVideosSize();
            }    
        }

        private void cb_Code_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (Encoder)cb_Code.SelectedItem;
            if(item != null)
            {
                SetVideosEncoder(item);
            }    
        }
    }
}
