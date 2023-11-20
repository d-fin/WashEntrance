using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sealevel;
using System.IO;


namespace WashEntrance_V1
{
    public partial class Form1 : Form
    {
        public static bool Shutdown = false;
        public static bool testing = false;
        public static bool resetButton = false;

        SeaMAX seaLevelDevice1 = new SeaMAX();
        SeaMAX seaLevelDevice2 = new SeaMAX();
        byte[] input = new byte[1];
        byte[] output = new byte[1];

        bool extraRollerBtn = false;
        bool goSign = true;
        bool stopSign = false;
        bool forkSolenoid = false;
        bool audio = false;

        private Thread SeaLevelBackground;
        private int password = 5680;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            extraRollerTestBtn.Visible = false; 
            forkTestBtn.Visible = false;
            AudioTestBtn.Visible= false;
            changeSignsTestBtn.Visible= false;
            logTxtBox.Visible = false;

            testBtn.Enabled = false; 

            runBtn.PerformClick();
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
            DialogResult exit = MessageBox.Show("Exiting will terminate the Wash Entrance Controller application, are you sure?",
                                                                    "WARNING",
                                                                    MessageBoxButtons.YesNo);
            if (exit == DialogResult.Yes)
            {
                Shutdown = true;

                while (true)
                {
                    Logger.LogThreadTermination(SeaLevelBackground);
                    bool joined = SeaLevelBackground.Join(2000);

                    if (joined == true)
                    {
                        break;
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                }
                try
                {
                    if (SeaLevelBackground.ThreadState != ThreadState.Stopped)
                    {
                        SeaLevelBackground.Abort();
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLog($"Exception : SeaLevelBackground.Abort() - Error aborting thread.");
                }
                
                Application.Exit();
            }
        }

        private void deleteLogs_Click(object sender, EventArgs e)
        {
            Logger.DeleteOldLines();
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void resetBtn_MouseLeave(object sender, EventArgs e)
        {
            resetBtn.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            Logger.WriteLog("Running....");
            testBtn.BackColor = Color.FromArgb(24, 30, 54);
            runBtn.BackColor = Color.FromArgb(46, 51, 73);
            extraRollerTestBtn.Visible = false;
            forkTestBtn.Visible = false;
            AudioTestBtn.Visible = false;
            changeSignsTestBtn.Visible = false;
            resetButton = false; 

            if (SeaLevelBackground == null || !SeaLevelBackground.IsAlive)
            {
                try
                {
                    SeaLevelBackground = new Thread(SeaLevelThread.SeaLevelTask);
                    SeaLevelBackground.Start();
                    SeaLevelBackground.Name = "SeaLevelBackgroundThread";
                    Logger.LogThreadCreation(SeaLevelBackground);
                }
                catch (Exception ex) 
                {
                    Logger.WriteLog($"Error creating SeaLevelBackground Thread - {ex}");
                }
            }
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            Logger.WriteLog("Testing Mode....");
            runBtn.BackColor = Color.FromArgb(24, 30, 54);
            testBtn.BackColor = Color.FromArgb(46, 51, 73);
            extraRollerTestBtn.Visible = true;
            forkTestBtn.Visible = true;
            AudioTestBtn.Visible = true;
            changeSignsTestBtn.Visible = true;

            testing = true;

            int err = seaLevelDevice1.SM_Open("SeaDAC Lite 0");
            err = seaLevelDevice2.SM_Open("SeaDAC Lite 0");

            output[0] = 0;
            err = seaLevelDevice1.SM_WriteDigitalOutputs(0, 4, output);
            Logger.WriteLog($"SD1 WriteDigitalOutputs() - {err}");
            err = seaLevelDevice2.SM_WriteDigitalOutputs(0, 4, output); 
            Logger.WriteLog($"SD2 WriteDigitalOutputs() - {err}"); 
        }

        private void forkTestBtn_Click(object sender, EventArgs e)
        {
            try
            {
                output[0] = 1;
                int err = seaLevelDevice2.SM_WriteDigitalOutputs(2, 1, output);
                if (err >= 0)
                {
                    forkSolenoid = true;
                    Logger.WriteLog("Fork Up");
                }
                else
                {
                    Logger.WriteLog($"Error - {err}");
                }
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show($"Exception : {ex}",
                "Error",
                MessageBoxButtons.OK);
            }
        }

        private void changeSignsTestBtn_Click(object sender, EventArgs e)
        {
            try
            {
                output[0] = 1;
                int err = seaLevelDevice2.SM_WriteDigitalOutputs(1, 1, output);
                if (err >= 0)
                {
                    stopSign = true;
                    goSign = false; 
                    Logger.WriteLog("Signs Flipped.");
                }
                else 
                {
                    Logger.WriteLog($"Error - {err}");
                }
            }
            catch (Exception ex)
            {
               DialogResult result = MessageBox.Show($"Exception : {ex}",
               "Error",
               MessageBoxButtons.OK);
            }
        }

        private void AudioTestBtn_Click(object sender, EventArgs e)
        {
            try
            {
                output[0] = 1;
                int err = seaLevelDevice2.SM_WriteDigitalOutputs(0, 1, output);
                if (err >= 0)
                {
                    audio = true;
                    Logger.WriteLog("Audio Played");
                }
                else 
                {
                    Logger.WriteLog($"Error - {err}");
                }
            }
            catch (Exception ex)
            {
               DialogResult result = MessageBox.Show($"Exception : {ex}",
               "Error",
               MessageBoxButtons.OK);
            }
        }

        private void extraRollerTestBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int rollerCounter = 0;
                bool success = false;
                output[0] = 1;
                int err;


                while (!success)
                {
                    while (true)
                    {
                        err = seaLevelDevice2.SM_ReadDigitalInputs(0, 4, input);

                        bool one = SeaLevelThread.GetBit(input[0], 0);
                        bool two = SeaLevelThread.GetBit(input[0], 1);
                        bool three = SeaLevelThread.GetBit(input[0], 2);
                        bool four = SeaLevelThread.GetBit(input[0], 3);

                        if (three == true)
                        {
                            err = seaLevelDevice2.SM_WriteDigitalOutputs(2, 1, output);
                            if (err < 0)
                            {

                            }
                            else
                            {
                                forkSolenoid = SeaLevelThread.GetBit(output[0], 2);
                                success = true;
                                break;
                            }
                        }
                    }
                }


                while (true)
                {
                    err = seaLevelDevice2.SM_ReadDigitalInputs(0, 4, input);

                    bool one = SeaLevelThread.GetBit(input[0], 0);
                    bool two = SeaLevelThread.GetBit(input[0], 1);
                    bool three = SeaLevelThread.GetBit(input[0], 2);
                    bool four = SeaLevelThread.GetBit(input[0], 3);

                    if (three == true)
                    {
                        three = false;
                        rollerCounter++;
                        Thread.Sleep(100 * 13);
                        if (rollerCounter == 2)
                        {
                            while (true)
                            {
                                err = seaLevelDevice2.SM_ReadDigitalInputs(0, 4, input);

                                three = SeaLevelThread.GetBit(input[0], 2);

                                if (three == true)
                                {
                                    output[0] = 0;
                                    err = seaLevelDevice2.SM_WriteDigitalOutputs(2, 1, output);

                                    if (err >= 0)
                                    {
                                        forkSolenoid = false;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               DialogResult result = MessageBox.Show($"Exception : {ex}",
               "Error",
               MessageBoxButtons.OK);
            }
        }

        private void runBtn_Leave(object sender, EventArgs e)
        {
            runBtn.BackColor = Color.FromArgb(24, 30, 54); 
            Logger.WriteLog("Exiting run....");
        }

        private void testBtn_Leave(object sender, EventArgs e)
        {
            runBtn.BackColor = Color.FromArgb(24, 30, 54);
            Logger.WriteLog("Exiting test....");
        }

        private void resetBtn_MouseHover(object sender, EventArgs e)
        {
            resetBtn.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            if (SeaLevelBackground != null && SeaLevelBackground.IsAlive)
            {
                resetButton = true;
                Logger.WriteLog("Ending SeaLevelBackground Thread....");
                int timeout = 0;
                bool joined = false; 

                while (joined == false)
                {
                    if (SeaLevelBackground.ThreadState == ThreadState.Stopped)
                    {
                        Logger.LogThreadTermination(SeaLevelBackground);
                        joined = SeaLevelBackground.Join(500);
                    }

                    if (joined)
                    {
                        Logger.WriteLog("SeaLevelBackground Thread ended....");
                        break;
                    }
                    else if (timeout == 100)
                    {
                        DialogResult exit = MessageBox.Show("Error Resetting, exit the application and restart.",
                                                                    "Reset Error",
                                                                    MessageBoxButtons.OK);
                        if (exit == DialogResult.OK)
                        {
                            Thread.Sleep(2000);
                            btnExit.PerformClick();
                        }
                        //Thread.Sleep(5000);
                        //btnExit.PerformClick();
                    }
                    else
                    {
                        Logger.WriteLog("Attempting to end SeaLevelBackGround Thread....");
                        timeout++;
                        Thread.Sleep(500);
                    }
                }
            }
            Logger.WriteLog("Resetting....");
            runBtn.PerformClick();
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void logBtn_Click(object sender, EventArgs e)
        {
            radAudio.Visible = false; 
            radBtnExtraRoller.Visible = false;
            radFork.Visible = false;
            radGoSign.Visible = false;
            radPgmCar.Visible = false;
            radResetSigns.Visible = false;
            radRollerEye.Visible = false;
            radStop.Visible = false; 
            radSonar.Visible = false;
            radTireEye.Visible = false;
            inputsLabel.Visible = false;
            outputsLabel.Visible = false;
            logTxtBox.Visible = true;

            string logPath = Logger.GetLogFilePathFromConfig();

            try
            {
                string[] lines = ReadFileLines(logPath);
                Array.Reverse(lines);
                logTxtBox.Lines = lines;
                logTxtBox.Height = 750;
            }
            catch (FileNotFoundException)
            {
                DialogResult result = MessageBox.Show($"The file could not be found",
                                                        "File Not Found",
                                                        MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show($"Exception : {ex}",
                                                        "Error",
                                                        MessageBoxButtons.OK);
            }
        }

        static string[] ReadFileLines(string filePath)
        {
            List<string> lines = new List<string>();

            lock (Logger.lock_File)
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }

            return lines.ToArray();
        }

        private void logBtn_Leave(object sender, EventArgs e)
        {
            radAudio.Visible = true;
            radBtnExtraRoller.Visible = true;
            radFork.Visible = true;
            radGoSign.Visible = true;
            radPgmCar.Visible = true;
            radResetSigns.Visible = true;
            radRollerEye.Visible = true;
            radStop.Visible = true;
            radSonar.Visible = true;
            radTireEye.Visible = true;
            inputsLabel.Visible = true;
            outputsLabel.Visible = true;

            logTxtBox.Text = string.Empty;
            logTxtBox.Visible = false;
        }
    }
}
