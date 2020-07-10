using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFmpegMediaConvert.Buseniss
{
   public class AudioInfo
    {
        public string AudioName { get; set; }
        public string AudioCode { get; set; }
        public int AudioSampleRate { get; set; }
        public int AudioBitRate { get; set; } 
        public int AudioChanel { get; set; }
    }
}
