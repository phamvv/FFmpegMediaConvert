using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FFmpegMediaConvert.Buseniss
{
    public static class PathFFMPEG
    {
        /// <summary>
        /// get full path of ffmpeg file
        /// </summary>
        public static string FFmpegPath
        {
            get
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dll\x64\ffmpeg.exe");
                }
                else
                    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Dll\x86\ffmpeg.exe");
            }
        }

        /// <summary>
        /// get full path of FFprobe file
        /// </summary>
        public static string FFprobePath
        {
            get
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"x64\ffprobe.exe");
                }
                else
                    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"x86\ffprobe.exe");
            }
        }
    }
}
