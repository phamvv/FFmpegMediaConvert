using FFmpegMediaConvert.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFmpegMediaConvert.Buseniss.Video
{
    public class VideoInfo
    {
        public string VideoName { get; set; }
        public VideoHight VideosHight { get; set; }
        public int Bitrate { get; set; }
        public VideoCode Code { get; set; }
        public int FPS { get; set; }
        public VideoRatio Ratio { get; set; }
        /// <summary>
        /// return videos width
        /// </summary>
        public int VideosWidth
        {
            get
            {
                int width = 320; //defaul is smallest
                switch (Ratio)
                {
                    case VideoRatio.Ratio_16x9: { width = (int)VideosHight * 16 / 9; }; break;
                    case VideoRatio.Ratio_21x9: { width = (int)VideosHight * 21 / 9; }; break;
                    case VideoRatio.Ratio_3x2: { width = (int)VideosHight * 3 / 2; }; break;
                    case VideoRatio.Ratio_4x3: { width = (int)VideosHight * 4 / 3; }; break;
                    case VideoRatio.Ratio_5x3: { width = (int)VideosHight * 5 / 3; } break;
                    case VideoRatio.Ratio_5x4: { width = (int)VideosHight * 5 / 4; } break;
                    case VideoRatio.Ratio_8x5: { width = (int)VideosHight * 8 / 5; } break;
                };
                return width;
            }

        }
    }
}
