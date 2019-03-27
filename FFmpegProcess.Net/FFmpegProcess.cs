using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFmpegProcess.Net
{
    /// <summary>
    /// FFmpeg Process
    /// </summary>
    public class FFmpegProcess
    {
        private Process process;

        // Singleton mode
        private static FFmpegProcess instance = new FFmpegProcess();
        public static FFmpegProcess Instance
        {
            get { return instance; }
            private set { }
        }

        private FFmpegProcess()
        {
        }
        
        ~FFmpegProcess()
        {
            Stop();
        }

        /// <summary>
        /// Start executing the FFmpeg process
        /// </summary>
        /// <param name="args">FFmpeg parameters</param>
        public void Start(string args)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();

                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DefaultArguments.sFFmpegFilename);
                startInfo.Arguments = args;
                startInfo.RedirectStandardOutput = true;
                Debug.WriteLine(string.Format("Executing \"{0}\" with arguments \"{1}\".\r\n", startInfo.FileName, startInfo.Arguments));

                if (process == null)
                    process = Process.Start(startInfo);
            }
            catch (Exception e)
            {
                Debug.WriteLine("FFmpegProcess Start Exception: " + e.Message);
            }
        }

        /// <summary>
        /// Terminate the FFmpeg process
        /// </summary>
        public void Stop()
        {
            try
            {
                if (process != null)
                {
                    process.Kill();
                    process = null;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("FFmpegProcess Stop Exception: " + e.Message);
            }
        }
    }
}
