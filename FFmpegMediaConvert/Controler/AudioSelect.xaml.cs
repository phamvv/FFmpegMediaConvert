using FFmpegMediaConvert.Buseniss.Audio;
using FFmpegMediaConvert.Enums;
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
    /// Interaction logic for AudioSelect.xaml
    /// </summary>
    public partial class AudioSelect : UserControl
    {
        private AudioInfo _audio;
        private ObservableCollection<AudioInfo> _AudioInfoList = new ObservableCollection<AudioInfo>();

        public AudioSelect()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            _AudioInfoList.Add(new AudioInfo { AudioName = "Copy", AudioCode = AudioCode.copy, AudioBitRate = 41100, AudioChanel = AudioChannel.Stereo });
            _AudioInfoList.Add(new AudioInfo { AudioName = "AAC", AudioCode = AudioCode.aac, AudioBitRate = 41100, AudioChanel = AudioChannel.Stereo });
            _AudioInfoList.Add(new AudioInfo { AudioName = "AC3", AudioCode = AudioCode.ac3, AudioBitRate = 41100, AudioChanel = AudioChannel.Stereo });
            _AudioInfoList.Add(new AudioInfo { AudioName = "AC3Fixed", AudioCode = AudioCode.ac3_fixed, AudioBitRate = 41100, AudioChanel = AudioChannel.Stereo });
            _AudioInfoList.Add(new AudioInfo { AudioName = "FLAC", AudioCode = AudioCode.flac, AudioBitRate = 41100, AudioChanel = AudioChannel.Stereo });
            _AudioInfoList.Add(new AudioInfo { AudioName = "MP3", AudioCode = AudioCode.mp3, AudioBitRate = 41100, AudioChanel = AudioChannel.Stereo });
            _AudioInfoList.Add(new AudioInfo { AudioName = "OPUS", AudioCode = AudioCode.opus, AudioBitRate = 41100, AudioChanel = AudioChannel.Stereo });
            cb_AudioCode.ItemsSource = _AudioInfoList;
            cb_AudioCode.DisplayMemberPath = "AudioName";
            cb_AudioCode.SelectedIndex = 0;
        }

        /// <summary>
        /// get or set the Audio info value
        /// </summary>
        public AudioInfo Value
        {
            get
            {
                return _audio;
            }
            set
            {
                _audio = value;
            }
        }
    }
}
