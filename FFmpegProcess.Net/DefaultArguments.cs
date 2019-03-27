using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFmpegProcess.Net
{
    public static class DefaultArguments
    {
        // FFmpeg filename
        public static readonly string sFFmpegFilename = @"FFmpeg\ffmpeg.exe";

        // PushStream - https://trac.ffmpeg.org/wiki/Capture/Desktop
        // Dependencies - https://github.com/rdp/screen-capture-recorder-to-video-windows-free
        public static readonly string sPushStreamDesktop = @"-f dshow -i video='screen-capture-recorder' -framerate 15 -b:v 3M -f flv rtmp://localhost:1935/live";
        public static readonly string sPushStreamWindow = @"-f gdigrab -framerate 15 -i title=Calculator -b:v 3M -f flv rtmp://localhost:1935/live";

    }
}
