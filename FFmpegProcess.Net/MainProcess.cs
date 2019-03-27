using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FFmpegProcess.Net
{
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
