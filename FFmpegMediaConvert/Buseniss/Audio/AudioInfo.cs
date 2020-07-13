using FFmpegMediaConvert.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFmpegMediaConvert.Buseniss.Audio
{
   public class AudioInfo
    {
        public string AudioName { get; set; }
        public AudioCode AudioCode { get; set; }
        public int AudioSampleRate { get; set; }
        public int AudioBitRate { get; set; } 
        public AudioChannel AudioChanel { get; set; }
    }
}
