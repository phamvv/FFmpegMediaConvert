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
        private string command = "";

        public AudioSelect()
        {
            InitializeComponent();
        }

        private string setCommand()
        {
            var item = (AudioInfo)cb_AudioCode.SelectedItem;
            if (item != null)
            {
                if(item.AudioCode == AudioCode.copy)
                {
                    command = " -c:a copy ";

                }    
                else
                {
                    switch (item.AudioCode)
                    {
                        case AudioCode.aac: command = " -c:a aac "; break;
                        case AudioCode.ac3: command = " -c:a ac3 "; break;
                        case AudioCode.flac: command = " -c:a flac "; break;
                        case AudioCode.mp3: command = " -c:a mp3 "; break;
                        case AudioCode.opus: command = " -c:a libopus "; break;
                    }

                    var chanel = (AudioChannel)cb_channel.SelectedItem;
                    if (chanel != null)
                    {
                        if (chanel == AudioChannel.Stereo)
                            command += " -ac 2 ";
                        else if (chanel == AudioChannel.Mono)
                        {
                            command += " -ac 1 ";
                        }
                    }

                    command += " -b:a " + txt_BitRate.Text + "k " + " -ar " + txt_SampleRate.Text;
                }    
               
            }
            return command.Replace("  "," ");
        }

        public void LoadData()
        {
            //add default audio info in to combobox
            _AudioInfoList.Add(new AudioInfo { AudioName = "Copy", AudioCode = AudioCode.copy, AudioBitRate = 320, AudioChanel = AudioChannel.Stereo, AudioSampleRate = 44100 });
            _AudioInfoList.Add(new AudioInfo { AudioName = "AAC", AudioCode = AudioCode.aac, AudioBitRate = 224, AudioChanel = AudioChannel.Stereo, AudioSampleRate = 48000 });
            _AudioInfoList.Add(new AudioInfo { AudioName = "AC3", AudioCode = AudioCode.ac3, AudioBitRate = 224, AudioChanel = AudioChannel.Stereo, AudioSampleRate = 48000 });
            _AudioInfoList.Add(new AudioInfo { AudioName = "FLAC", AudioCode = AudioCode.flac, AudioBitRate = 320, AudioChanel = AudioChannel.Stereo, AudioSampleRate = 48000 });
            _AudioInfoList.Add(new AudioInfo { AudioName = "MP3", AudioCode = AudioCode.mp3, AudioBitRate = 224, AudioChanel = AudioChannel.Stereo, AudioSampleRate = 48000 });
            _AudioInfoList.Add(new AudioInfo { AudioName = "OPUS", AudioCode = AudioCode.opus, AudioBitRate = 320, AudioChanel = AudioChannel.Stereo, AudioSampleRate = 48000 });
            cb_AudioCode.ItemsSource = _AudioInfoList;
            cb_AudioCode.DisplayMemberPath = "AudioName";
            cb_AudioCode.SelectionChanged += Cb_AudioCode_SelectionChanged;
            cb_AudioCode.SelectedIndex = 0;

            //add default channel value in to combobox chennel
            cb_channel.Items.Add(AudioChannel.Mono);
            cb_channel.Items.Add(AudioChannel.Stereo);
            cb_channel.SelectionChanged += Cb_channel_SelectionChanged;
            cb_channel.SelectedIndex = 1;
        }

        private void Cb_channel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var channel = (AudioChannel)cb_channel.SelectedItem;
            foreach (var item in _AudioInfoList)
            {
                if (item == (AudioInfo)cb_AudioCode.SelectedItem)
                {
                    item.AudioChanel = channel;
                }
            }
        }

        private void Cb_AudioCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (AudioInfo)cb_AudioCode.SelectedItem;
            if (item != null)
            {
                txt_BitRate.Text = item.AudioBitRate.ToString();
                txt_SampleRate.Text = item.AudioSampleRate.ToString();
                cb_channel.SelectedItem = item.AudioChanel;
                if (item.AudioCode == AudioCode.copy)
                {
                    command = " -c:a copy ";
                    txt_BitRate.IsEnabled = false;
                    txt_SampleRate.IsEnabled = false;
                    cb_channel.IsEnabled = false;
                }
                else
                {
                    command = " -c:a " + item.AudioName;
                    txt_BitRate.IsEnabled = true;
                    txt_SampleRate.IsEnabled = true;
                    cb_channel.IsEnabled = true;
                }
            }
        }

        /// <summary>
        /// get or set the Audio info value
        /// </summary>
        public AudioInfo Value
        {
            get
            {
                var item = (AudioInfo)cb_AudioCode.SelectedItem;
                if (item != null)
                {
                    _audio = item;
                    return _audio;
                }
                else
                    return null;

            }
            set
            {
                _audio = value;
                cb_AudioCode.Text = _audio.AudioName;
                txt_BitRate.Text = _audio.AudioBitRate.ToString();
                txt_SampleRate.Text = _audio.AudioSampleRate.ToString();
                cb_channel.SelectedItem = _audio.AudioChanel;

            }
        }
        /// <summary>
        /// get the command string for ffmpeg with audio
        /// </summary>
        public string getCommand
        {
            get 
            {
                return setCommand();
            }
        }
    }
}
