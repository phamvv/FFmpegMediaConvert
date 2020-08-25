using FFmpegMediaConvert.Buseniss.Audio;
using FFmpegMediaConvert.Buseniss.Video;
using FFmpegMediaConvert.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFmpegMediaConvert.Buseniss
{
  public class FormatType
    {
        /// <summary>
        /// name of format type will be output
        /// </summary>
        public string FormatName { get; set; }
        /// <summary>
        /// media file type
        /// </summary>
        public MediaType mediaType { get; set; }

        /// <summary>
        /// other command option for ffmpeg
        /// </summary>
        public string OptionCommand { get; set; }
    }
}
