using FFmpegMediaConvert.Buseniss;
using FFmpegMediaConvert.Buseniss.Video;
using FFmpegMediaConvert.Enums;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace FFmpegMediaConvert.Controler
{
    /// <summary>
    /// Interaction logic for VideoSelect.xaml
    /// </summary>
    public partial class VideoSelect : UserControl
    {
        private VideoInfo _videoInfo { get; set; }


        private string command = "";

        /// <summary>
        /// load all data default to interface
        /// </summary>
        public void LoadData()
        {
            //add default value for Videos format 
            cb_VideoSize.ItemsSource = DefaultCode.listVideoInfo;
            cb_VideoSize.DisplayMemberPath = "VideoName";
            cb_VideoSize.SelectedIndex = 3;

            //Add videos Ratio            
            cb_Ratio.ItemsSource = DefaultCode.VideoRatioList;
            cb_Ratio.DisplayMemberPath = "RatioName";
            cb_Ratio.SelectedIndex = 0;

            cb_Code.ItemsSource = DefaultCode.VideoEncoderList;
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
            set
            {
                _videoInfo = value;
                cb_Code.SelectedItem = DefaultCode.VideoEncoderList.Where(s => s.VideoCode == _videoInfo.Code).FirstOrDefault();

            }
        }

        public string GetCommand
        {
            get { return getCommandString(); }
        }

        private string getCommandString()
        {
            var code = (Encoder)cb_Code.SelectedItem;
            if (code != null)
            {
                if (code.VideoCode == VideoCode.copy)
                {
                    command = " -c:v copy ";
                }
                else
                {
                    switch (code.VideoCode)
                    {
                        case VideoCode.Hap: { command = " -c:v hap "; }; break;
                        case VideoCode.jpeg2000: { command = " -c:v jpeg2000 "; }; break;
                        case VideoCode.libaomAV1: { command = " -c:v libaomAV1 "; }; break;
                        case VideoCode.libkvazaar: { command = " -c:v libkvazaar "; }; break;
                        case VideoCode.librav1e: { command = " -c:v librav1e "; }; break;
                        case VideoCode.libtheora: { command = " -c:v libtheora "; }; break;
                        case VideoCode.libvpx: { command = " -c:v libvpx "; }; break;
                        case VideoCode.libwebp: { command = " -c:v libwebp "; }; break;
                        case VideoCode.libx264: { command = " -c:v libx264 "; }; break;
                        case VideoCode.libx265: { command = " -c:v libx265 "; }; break;
                        case VideoCode.libxavs2: { command = " -c:v libxavs2 "; }; break;
                        case VideoCode.libxvid: { command = " -c:v libxvid "; }; break;
                        case VideoCode.mpeg2: { command = " -c:v mpeg2 "; }; break;
                        case VideoCode.png: { command = " -c:v png "; }; break;
                        case VideoCode.ProRes: { command = " -c:v ProRes "; }; break;
                        case VideoCode.vp9:
                            {
                                //detail information: https://developers.google.com/media/vp9/settings/vod
                                var videoInfo = ((VideoInfo)cb_VideoSize.SelectedItem);
                                string crf = "32";
                                if (int.Parse(txt_Hight.Text) <= 480)
                                    crf = "34";
                                else if (int.Parse(txt_Hight.Text) <= 720)
                                    crf = "32";
                                else if (int.Parse(txt_Hight.Text) <= 1080)
                                    crf = "31";
                                else if (int.Parse(txt_Hight.Text) <= 1440)
                                    crf = "24";
                                else if (int.Parse(txt_Hight.Text) <= 2160)
                                    crf = "18";

                                command = " -c:v libvpx-vp9 ";
                                command += " -minrate " + (int.Parse(txt_bitRate.Text) / 2).ToString() + "k -maxrate " +
                                    (int.Parse(txt_bitRate.Text) / 2 + int.Parse(txt_bitRate.Text)).ToString() + "k -g 240 " +
                                    " -quality good -crf " + crf + " -speed 4 ";
                            }; break;
                    }
                    if(((VideoInfo)cb_VideoSize.SelectedItem).VideosHight == VideoHight.Original)
                    {
                        command += " -b:v " + txt_bitRate.Text + "k ";
                    }    
                    else
                    {
                        if (((Ratio)cb_Ratio.SelectedItem).VideoRatio == VideoRatio.Original)
                            command += " -b:v " + txt_bitRate.Text + "k " + " -vf scale=-1:" + txt_Hight.Text + " -r " + txt_frameRate.Text;
                        else
                            command += " -b:v " + txt_bitRate.Text + "k " + " -vf scale=" + txt_Width.Text + ":" + txt_Hight.Text + " -r " + txt_frameRate.Text;
                    }

                }
            }
            return command.Replace("  ", " ");
        }

        private void GetVideosSize()
        {
            var item = ((VideoInfo)cb_VideoSize.SelectedItem);
            if (item != null)
            {
                if(item.VideosHight == VideoHight.Original)
                {
                    txt_Width.Text = "Original";
                    txt_Hight.Text = "Original";
                    txt_bitRate.Text = item.Bitrate.ToString();
                    txt_frameRate.Text = "Original";
                }    
                else
                {
                    var ratio = (Ratio)cb_Ratio.SelectedItem;
                    if(ratio != null)
                    {
                        if (ratio.VideoRatio == VideoRatio.Original)
                        {
                            txt_Width.Text = "-1";
                            txt_Hight.Text = ((int)item.VideosHight).ToString();
                            txt_bitRate.Text = item.Bitrate.ToString();
                            txt_frameRate.Text = item.FPS.ToString();
                        }
                        else
                        {
                            txt_Width.Text = item.VideosWidth.ToString();
                            txt_Hight.Text = ((int)item.VideosHight).ToString();
                            txt_bitRate.Text = item.Bitrate.ToString();
                            txt_frameRate.Text = item.FPS.ToString();
                        }
                    }   
                   
                }    
                
            }
        }
        private void SetVideosEncoder(Encoder code)
        {
            foreach (var item in DefaultCode.listVideoInfo)
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
            if (item != null)
            {
                foreach (var m in DefaultCode.listVideoInfo)
                {
                    m.Ratio = item.VideoRatio;
                }
                GetVideosSize();
            }
        }

        private void cb_Code_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (Encoder)cb_Code.SelectedItem;
            if (item != null)
            {
                SetVideosEncoder(item);
                if (item.VideoCode == VideoCode.copy)
                {
                    showControl(false);
                }
                else
                {
                    showControl(true);
                }
            }
        }

        private void showControl(bool v)
        {
            cb_VideoSize.IsEnabled = v;
            cb_Ratio.IsEnabled = v;
            txt_Width.IsEnabled = v;
            txt_Hight.IsEnabled = v;
            txt_bitRate.IsEnabled = v;
            txt_frameRate.IsEnabled = v;
        }
    }
}
