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
        public static readonly string sFFmpegFilename = "ffmpeg.exe";

        // PushStream - https://trac.ffmpeg.org/wiki/Capture/Desktop
        public static readonly string sPushStreamDesktop = @"-f dshow -i video='screen-capture-recorder' -framerate 30 -b:v 3M -f flv rtmp://localhost:1935/live";
        public static readonly string sPushStreamWindow = "-f gdigrab -framerate 30 -i title=Calculator -b:v 3M -f flv rtmp://localhost.213:1935/live";

    }
}
