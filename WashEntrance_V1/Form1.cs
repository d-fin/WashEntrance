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
using Sealevel;
using IWshRuntimeLibrary;
using System.IO;

namespace WashEntrance_V1
{
    public partial class Form1 : Form
    {
        public static bool Shutdown = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string shortcutName = "Wash Entrance Controller.lnk";
            string targetPath = Application.ExecutablePath;
            string iconPath = "C:/Users/dfinl/OneDrive/Desktop/WashEntrance_V1/WashEntrance_V1/Logo.ico";

            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Path.Combine(shortcutPath, shortcutName));
            shortcut.TargetPath = targetPath;
            shortcut.IconLocation = iconPath; 
            shortcut.Save();
        }

        private void tmrUpdateForm_Tick(object sender, EventArgs e)
        {


            // SeaLevel Device 2 inputs
            if (SeaLevelThread.SD2_input1_sonar) { radSonar.Checked = true; }
            else { radSonar.Checked = false; }

            if (SeaLevelThread.SD2_input2_tireEye) { radTireEye.Checked = true; }
            else { radTireEye.Checked = false; }

            if (SeaLevelThread.SD2_input3_rollerEye) { radRollerEye.Checked = true; }
            else { radRollerEye.Checked = false; }

            //SeaLevel Device 1 inputs
            if (SeaLevelThread.SD1_input1_pgmCar) { radPgmCar.Checked = true; }
            else { radPgmCar.Checked = false; }

            if (SeaLevelThread.SD1_input2_pgmCarButton) { radBtnExtraRoller.Checked = true; }
            else { radBtnExtraRoller.Checked = false; }

            if (SeaLevelThread.SD1_input3_resetSigns) { radResetSigns.Checked = true; }
            else { radResetSigns.Checked = false; }

            //SeaLevel Device 2 outputs
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
            
            // SeaLevel Devices online/offline
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

        private void buttonForkSolTest_Click(object sender, EventArgs e)
        {
            SeaMAX SeaLevelDevice = new SeaMAX();
            byte[] output = new byte[1];

            output[0] = 1;
            int err = SeaLevelDevice.SM_WriteDigitalOutputs(2, 1, output);

            if (err < 0)
            {
                Logger.WriteLog($"Error # {err} - Test Button Fork Solenoid");
            }
            else
            {
                Logger.WriteLog($"Success - Test Button Fork Solenoid");
                Thread.Sleep(10000);
                output[0] = 0;
                err = SeaLevelDevice.SM_WriteDigitalOutputs(2, 1, output);
            }
        }

        private void buttonAudioTest_Click(object sender, EventArgs e)
        {
            SeaMAX SeaLevelDevice = new SeaMAX();
            byte[] output = new byte[1];

            output[0] = 1;
            int err = SeaLevelDevice.SM_WriteDigitalOutputs(0, 1, output);

            if (err < 0)
            {
                Logger.WriteLog($"Error # {err} - Test Button Audio");
            }
            else
            {
                Logger.WriteLog($"Success - Test Button Audio");
                Thread.Sleep(10000);
                output[0] = 0;
                err = SeaLevelDevice.SM_WriteDigitalOutputs(0, 1, output);
            }
        }

        private void buttonSignFlipTest_Click(object sender, EventArgs e)
        {
            SeaMAX SeaLevelDevice = new SeaMAX();
            byte[] output = new byte[1];

            output[0] = 1;
            int err = SeaLevelDevice.SM_WriteDigitalOutputs(1, 1, output);

            if (err < 0)
            {
                Logger.WriteLog($"Error # {err} - Test Button Signs");
            }
            else
            {
                Logger.WriteLog($"Success - Test Button Signs");
                Thread.Sleep(10000);
                output[0] = 0;
                err = SeaLevelDevice.SM_WriteDigitalOutputs(1, 1, output);
            }
        }
    }
}
