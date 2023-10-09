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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Logger.DeleteOldLines();
            DialogResult result = MessageBox.Show("Select yes to run tests or no to run the application.", 
                "Test or Run",
                MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                Logger.WriteLog("Starting Test Form");

                Application.Run(new TestForm());

                Logger.WriteLog("Ending Test Form");
            }
            else if (result == DialogResult.No)
            {
                Logger.WriteLog("Starting Wash Entrance Controller");

                Thread SeaLevelBackground = new Thread(SeaLevelThread.SeaLevelTask);
                SeaLevelBackground.IsBackground = true;
                SeaLevelBackground.Start();

                Application.Run(new Form1());
                Logger.WriteLog("Ending Wash Entrance Controller");
            }
            else
            {
                Logger.WriteLog("Ending Application");
            }
            
        }
    }
}
