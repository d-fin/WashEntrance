using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WashEntrance_V1
{
    public partial class Form1 : Form
    {
        public static bool Shutdown = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void tmrUpdateForm_Tick(object sender, EventArgs e)
        {
            if (SeaLevelThread.SC_Input1) { radRollerCall.Checked = true; }
            else { radRollerCall.Checked = false; }

            if (SeaLevelThread.SC_Input4) { radRollerEye.Checked = true; }
            else { radRollerEye.Checked = false; }

            if (SeaLevelThread.ForkUpBool) { radFork.Checked = true; }
            else { radFork.Checked = false; }

            /*if (SeaLevelThread.audio) { radAudio.Checked = true; }
            else { radAudio.Checked = false; }

            if (SeaLevelThread.sign_go) { radGo.Checked = true; }
            else { radGo.Checked = false; }

            if (SeaLevelThread.sign_stop) { radStop.Checked = true; }
            else { radStop.Checked = false; }

            if (SeaLevelThread.sign_trigger) { radSignTrigger.Checked = true; }
            else { radSignTrigger.Checked = false; }*/

            if (SeaLevelThread.seaDAC) 
            { 
                radSeaDACLite0.Checked = true;
                radSeaDACLite0.BackColor = Color.Green;
            }
            else 
            { 
                radSeaDACLite0.Checked = false; 
                radSeaDACLite0.BackColor = Color.Red;
            }

            if (SeaLevelThread.seaConnect) 
            { 
                radSeaConnect.Checked = true; 
                radSeaConnect.BackColor = Color.Green;
            }
            else
            { 
                radSeaConnect.Checked= false;
                radSeaConnect.BackColor= Color.Red;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Shutdown = true;
            Thread.Sleep(1000);
            Application.Exit();
        }

        private void deleteLogs_Click(object sender, EventArgs e)
        {
            Logger.DeleteOldLines();
        }
    }
}
