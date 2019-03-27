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
    /// Class for testing the main process operation FFmpeg process
    /// </summary>
    class MainProcess
    {
        static void Main(string[] args)
        {
            try
            {
                FFmpegProcess.Instance.Start(DefaultArguments.sPushStreamWindow);

                // Wait 60 seconds
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
