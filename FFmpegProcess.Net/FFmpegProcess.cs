using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
            process = new Process();
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
                if(process != null)
                {
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DefaultArguments.sFFmpegFilename);
                    process.StartInfo.Arguments = args;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.Start();
                    Debug.WriteLine(string.Format("Executing \"{0}\" with arguments \"{1}\".\r\n", process.StartInfo.FileName, process.StartInfo.Arguments));
                }
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
                    KernelWrapper.AttachConsole(process.Id);
                    KernelWrapper.SetConsoleCtrlHandler(IntPtr.Zero, true);
                    KernelWrapper.GenerateConsoleCtrlEvent(0, 0);

                    // Wait 2 seconds
                    Thread.Sleep(2000);

                    KernelWrapper.SetConsoleCtrlHandler(IntPtr.Zero, false);
                    KernelWrapper.FreeConsole();

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
