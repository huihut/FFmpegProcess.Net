using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FFmpegProcess.Net
{
    /// <summary>
    /// 用于测试主进程操作 FFmpeg 进程
    /// </summary>
    class MainProcess
    {
        static void Main(string[] args)
        {
            try
            {
                FFmpegProcess.Instance.Start(DefaultArguments.sPushStreamDesktop);

                // 等待 1 分钟
                Thread.Sleep(60000);

                FFmpegProcess.Instance.Stop();
            }
            catch (Exception e)
            {
                Debug.WriteLine("MainProcess Main Exception: " + e.Message);
            }
        }
    }
}
