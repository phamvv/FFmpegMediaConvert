using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFmpegMediaConvert.Buseniss
{
   public class VideoInfo
    {
        public string VideoName { get; set; }
        public string VideosSize { get; set; }
        public int Bitrate { get; set; }
        public string Code { get; set; }
        public int FPS { get; set; }
        public string Ratio { get; set; }
    }
}
