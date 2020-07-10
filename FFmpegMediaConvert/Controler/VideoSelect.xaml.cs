using FFmpegMediaConvert.Buseniss;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for VideoSelect.xaml
    /// </summary>
    public partial class VideoSelect : UserControl
    {
        private VideoInfo _videoInfo { get; set; }
        private ObservableCollection<VideoInfo> _VideosizeList = new ObservableCollection<VideoInfo>();

        /// <summary>
        /// load all data default to interface
        /// </summary>
        public void LoadData()
        {
            //add video infor default 
            VideoInfo V4K = new VideoInfo { VideoName = "UHD4K:2160p", VideosSize = "3840x2160", Bitrate = 9000, FPS = 30 };         
            VideoInfo QHD = new VideoInfo { VideoName = "QHD:1440p", VideosSize = "2560x1440", Bitrate = 6500, FPS = 30 };
            VideoInfo FullHD = new VideoInfo { VideoName = "FullHD:1080p", VideosSize = "1920x1080", Bitrate = 4000, FPS = 30 };
            VideoInfo HD = new VideoInfo { VideoName = "HD:720p", VideosSize = "1280x720", Bitrate = 3000, FPS = 30 };
            VideoInfo DVD = new VideoInfo { VideoName = "DVD:480p", VideosSize = "854x480", Bitrate = 1500, FPS = 30 };
            VideoInfo VCD = new VideoInfo { VideoName = "VCD:360p", VideosSize = "640x360", Bitrate = 900, FPS = 30 };
            VideoInfo SD = new VideoInfo { VideoName = ":240p", VideosSize = "426x240", Bitrate = 600, FPS = 30 };
            _VideosizeList.Add(V4K);
            _VideosizeList.Add(QHD);
            _VideosizeList.Add(FullHD);
            _VideosizeList.Add(HD);
            _VideosizeList.Add(DVD);
            _VideosizeList.Add(VCD);
            _VideosizeList.Add(SD);
            cb_VideosSelected.ItemsSource = _VideosizeList;
            cb_VideosSelected.DisplayMemberPath = "VideoName";
        }

        public VideoSelect()
        {
            InitializeComponent();
            // cb_VideosSelected.ItemsSource = _VideosizeList;
        }

        public VideoInfo Value
        {
            get { return _videoInfo; }
            set { _videoInfo = value; }
        }
        private void cb_VideosSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
