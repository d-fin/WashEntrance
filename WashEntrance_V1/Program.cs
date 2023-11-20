using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Sealevel;
using System.Security.Cryptography;

namespace WashEntrance_V1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew;
            using (Mutex mutex = new Mutex(true, "WashEntMutex", out createdNew))
            {
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    if (!Logger.DoesLogPathExist())
                    {
                        string logPath = Logger.PromptForLogFilePath();
                        Logger.UpdateLogPathInConfig(logPath);
                    }
                    Logger.DeleteOldLines();
                    Logger.WriteLog("Starting Wash Entrance Controller");
                    Application.Run(new Form1());
                    Logger.WriteLog("Ending Wash Entrance Controller");
                }
                else
                {
                    MessageBox.Show("Error, The application already has threads running in the background, restart the computer!",
                                    "Startup Error",
                                    MessageBoxButtons.OK);
                    Logger.WriteLog("Error starting application. Another instance is already running.");
                }
            }
        }
    }
}
