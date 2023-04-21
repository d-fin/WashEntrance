using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread SeaLevelBackground = new Thread(SeaLevelThread.SeaLevelTask);
            SeaLevelBackground.IsBackground = true;
            SeaLevelBackground.Start();

            Application.Run(new Form1());
        }
    }
}
