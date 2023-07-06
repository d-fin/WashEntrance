using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Sealevel;

namespace WashEntrance_V1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Logger.WriteLog("Starting Wash Entrance Controller");

            Task seaLevelTask = SeaLevelThread.SeaLevelTask();

            Application.Run(new Form1());

            await seaLevelTask;

            Logger.WriteLog("Ending Wash Entrance Controller");
        }
    }
}
