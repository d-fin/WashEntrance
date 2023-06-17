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
            if (SeaLevelThread.in_position) { radInPosition.Checked = true; }
            else { radInPosition.Checked = false; }

            if (SeaLevelThread.SD2_input1_sonar) { radSonar.Checked = true; }
            else { radSonar.Checked = false; }

            if (SeaLevelThread.SD2_input2_tireEye) { radTireEye.Checked = true; }
            else { radTireEye.Checked = false; }

            if (SeaLevelThread.SD2_input3_rollerEye) { radRollerEye.Checked = true; }
            else { radRollerEye.Checked = false; }

            if (SeaLevelThread.SD2_input4_resetSigns) { radResetSigns.Checked = true; }
            else { radResetSigns.Checked = false; }

            if (SeaLevelThread.SD1_input1_pgmCar) { radPgmCar.Checked = true; }
            else { radPgmCar.Checked = false; }

            if (SeaLevelThread.SD2_output1_audio) { radAudio.Checked = true; }
            else { radAudio.Checked = false; }
            
            if (SeaLevelThread.SD2_output2_signs) {
                radStop.Checked = true;
                radGoSign.Checked = false;
            }
            else 
            { 
                radStop.Checked = false;
                radGoSign.Checked = true; 
            }
            
            if (SeaLevelThread.SD2_output3_forkSolenoid) { radFork.Checked = true; }
            else { radFork.Checked = false; }
            
            

            if (SeaLevelThread.seaDAC1) 
            { 
                radSeaDACLite0.Checked = true;
                radSeaDACLite0.BackColor = Color.Green;
            }
            else 
            { 
                radSeaDACLite0.Checked = false; 
                radSeaDACLite0.BackColor = Color.Red;
            }

            if (SeaLevelThread.seaDAC2) 
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
