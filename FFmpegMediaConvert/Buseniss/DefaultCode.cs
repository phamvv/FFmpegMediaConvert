
using FFmpegMediaConvert.Buseniss.Audio;
using FFmpegMediaConvert.Buseniss.Video;
using FFmpegMediaConvert.Enums;
using System.Collections.ObjectModel;
using System.Linq;

namespace FFmpegMediaConvert.Buseniss
{
    public static class DefaultCode
    {
        public static ObservableCollection<FormatType> listFormatType = new ObservableCollection<FormatType>();
        public static ObservableCollection<VideoInfo> listVideoInfo = new ObservableCollection<VideoInfo>();
        public static ObservableCollection<AudioInfo> listAudioInfo = new ObservableCollection<AudioInfo>();
        public static ObservableCollection<Ratio> VideoRatioList = new ObservableCollection<Ratio>();
        public static ObservableCollection<Encoder> VideoEncoderList = new ObservableCollection<Encoder>();

        public static void LoadDefauCode()
        {
            //add Audio default value
            listAudioInfo.Add(new AudioInfo { AudioName = "Copy", AudioCode = AudioCode.copy, AudioBitRate = 196, AudioChanel = AudioChannel.Stereo, AudioSampleRate = 48000 });
            listAudioInfo.Add(new AudioInfo { AudioName = "AAC", AudioCode = AudioCode.aac, AudioBitRate = 224, AudioChanel = AudioChannel.Stereo, AudioSampleRate = 48000 });
            listAudioInfo.Add(new AudioInfo { AudioName = "AC3", AudioCode = AudioCode.ac3, AudioBitRate = 224, AudioChanel = AudioChannel.Stereo, AudioSampleRate = 48000 });
            listAudioInfo.Add(new AudioInfo { AudioName = "FLAC", AudioCode = AudioCode.flac, AudioBitRate = 320, AudioChanel = AudioChannel.Stereo, AudioSampleRate = 48000 });
            listAudioInfo.Add(new AudioInfo { AudioName = "MP3", AudioCode = AudioCode.mp3, AudioBitRate = 224, AudioChanel = AudioChannel.Stereo, AudioSampleRate = 48000 });
            listAudioInfo.Add(new AudioInfo { AudioName = "OPUS", AudioCode = AudioCode.opus, AudioBitRate = 192, AudioChanel = AudioChannel.Stereo, AudioSampleRate = 48000 });

            //add Video default infor 
            listVideoInfo.Add(new VideoInfo { VideoName = "UHD(4K):2160p", VideosHight = VideoHight.UHD4K_2160, Bitrate = 4500, Code = VideoCode.libx264, FPS = 30, Ratio = VideoRatio.Ratio_16x9 });
            listVideoInfo.Add(new VideoInfo { VideoName = "QHD(2K):1440p", VideosHight = VideoHight.WQHD_1440, Bitrate = 3500, Code = VideoCode.libx264, FPS = 30, Ratio = VideoRatio.Ratio_16x9 });
            listVideoInfo.Add(new VideoInfo { VideoName = "FullHD:1080p", VideosHight = VideoHight.UWHD_1080, Bitrate = 1800, Code = VideoCode.libx264, FPS = 30, Ratio = VideoRatio.Ratio_16x9 });
            listVideoInfo.Add(new VideoInfo { VideoName = "HD:720p", VideosHight = VideoHight.HD_720, Bitrate = 1024, Code = VideoCode.libx264, FPS = 30, Ratio = VideoRatio.Ratio_16x9 });
            listVideoInfo.Add(new VideoInfo { VideoName = "DVD:480p", VideosHight = VideoHight.VGA_480, Bitrate = 780, Code = VideoCode.libx264, FPS = 30, Ratio = VideoRatio.Ratio_16x9 });
            listVideoInfo.Add(new VideoInfo { VideoName = "VCD:360p", VideosHight = VideoHight.HVGA_320, Bitrate = 520, Code = VideoCode.libx264, FPS = 30, Ratio = VideoRatio.Ratio_16x9 });
            listVideoInfo.Add(new VideoInfo { VideoName = "SGA:240p", VideosHight = VideoHight.QVGA_240, Bitrate = 200, Code = VideoCode.libx264, FPS = 30, Ratio = VideoRatio.Ratio_16x9 });
            listVideoInfo.Add(new VideoInfo { VideoName = "Original", VideosHight = VideoHight.Original, Bitrate = 2000, Code = VideoCode.libx264, FPS = 30, Ratio = VideoRatio.Ratio_16x9 });

            //add ratio list
            VideoRatioList.Add(new Ratio { RatioName = "Original", VideoRatio = VideoRatio.Original });
            VideoRatioList.Add(new Ratio { RatioName = "16:9", VideoRatio = VideoRatio.Ratio_16x9 });
            VideoRatioList.Add(new Ratio { RatioName = "21:9", VideoRatio = VideoRatio.Ratio_21x9 });
            VideoRatioList.Add(new Ratio { RatioName = "3:2", VideoRatio = VideoRatio.Ratio_3x2 });
            VideoRatioList.Add(new Ratio { RatioName = "4:3", VideoRatio = VideoRatio.Ratio_4x3 });
            VideoRatioList.Add(new Ratio { RatioName = "5:3", VideoRatio = VideoRatio.Ratio_5x3 });
            VideoRatioList.Add(new Ratio { RatioName = "5:4", VideoRatio = VideoRatio.Ratio_5x4 });
            VideoRatioList.Add(new Ratio { RatioName = "8:5", VideoRatio = VideoRatio.Ratio_8x5 });

            //add videos Encoder
            VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.copy, CoderName = "copy" });
            VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.libx264, CoderName = "H264" });
            VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.libx265, CoderName = "H265" });
            VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.vp9, CoderName = "libvpx-vp9" });
            VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.Hap, CoderName = "HAP" });
            VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.jpeg2000, CoderName = "JPEG_2000" });
            VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.libaomAV1, CoderName = "AOM_AV1" });
            VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.libkvazaar, CoderName = "AAR" });
            VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.librav1e, CoderName = "AV1E" });
            VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.libtheora, CoderName = "THEORA" });
            VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.libvpx, CoderName = "VPX" });
            VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.libwebp, CoderName = "WEBP" });
            VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.libxavs2, CoderName = "XAVS2" });
            VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.libxvid, CoderName = "XVID" });
            VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.mpeg2, CoderName = "MPEG2" });
            VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.png, CoderName = "PNG" });
            VideoEncoderList.Add(new Encoder { VideoCode = VideoCode.ProRes, CoderName = "PRORES" });

            //add webm type
            FormatType webm = new FormatType();
            webm.FormatName = "Output WEBM File";
            webm.mediaType = MediaType.WEBM;
            // webm.OptionCommand = "-minrate 512k -maxrate 9000k -g 240 -threads 8 -quality good -crf 32 -speed 4 -y ";
            listFormatType.Add(webm);

            //add mp4 type
            FormatType mp4 = new FormatType();
            mp4.FormatName = "Output MP4 File";
            mp4.mediaType = MediaType.MP4;
            //mp4.OptionCommand = "-minrate 900k -maxrate 2610k -g 240 -threads 8 -quality good -crf 31 -speed 4 -y ";
            listFormatType.Add(mp4);

            //add avi type
            FormatType avi = new FormatType();
            avi.FormatName = "Output AVI File";
            avi.mediaType = MediaType.AVI;
            // avi.OptionCommand = "-minrate 2500k -maxrate 4500k -g 240 -threads 8 -quality good -crf 24 -speed 4 -y ";
            listFormatType.Add(avi);

            //add mkv type
            FormatType mkv = new FormatType();
            mkv.mediaType = MediaType.MKV;
            mkv.FormatName = "Output MKV File";
           // mkv.OptionCommand = "-minrate 4500k -maxrate 8000k -g 240 -threads 8 -quality good -crf 15 -speed 4 -y ";
            listFormatType.Add(mkv);


        }
    }
}
