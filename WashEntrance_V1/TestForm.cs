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

namespace WashEntrance_V1
{
    public partial class TestForm : Form
    {
        SeaMAX seaLevelDevice1 = new SeaMAX();
        SeaMAX seaLevelDevice2 = new SeaMAX();
        byte[] input = new byte[1];
        byte[] output = new byte[1];

        bool extraRollerBtn = false;
        bool goSign = true;
        bool stopSign = false;
        bool forkSolenoid = false;
        bool audio = false; 

        public TestForm()
        {
            InitializeComponent();
            
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            int err = seaLevelDevice1.SM_Open("SeaDAC Lite 0");
            err = seaLevelDevice2.SM_Open("SeaDAC Lite 0");

            output[0] = 0;
            err = seaLevelDevice1.SM_WriteDigitalOutputs(0, 4, output);
            err = seaLevelDevice2.SM_WriteDigitalOutputs(0, 4, output);
        }

        private void TestSigns_Click(object sender, EventArgs e)
        {
            try
            {
                output[0] = 1;
                int err = seaLevelDevice2.SM_WriteDigitalOutputs(1, 1, output);
                if (err >= 0)
                {
                    stopSign = true;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void TestExtraRollerBtn_Click(object sender, EventArgs e)
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

            }
        }

        private void TestAudio_Click(object sender, EventArgs e)
        {
            try
            {
                output[0] = 1;
                int err = seaLevelDevice2.SM_WriteDigitalOutputs(0, 1, output);
                if (err >= 0)
                {
                    audio = true;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void TestFork_Click(object sender, EventArgs e)
        {
            try
            {
                output[0] = 1;
                int err = seaLevelDevice2.SM_WriteDigitalOutputs(2, 1, output);
                if (err >= 0)
                {
                    audio = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void UpdateForm_Tick(object sender, EventArgs e)
        {
            if (audio == false)
            {
                audioRad.Checked = false;
                audioRad.BackColor = Color.Red;
            }
            else
            {
                audioRad.Checked = true;
                audioRad.BackColor = Color.Green; 
            }

            if (forkSolenoid == false)
            {
                forkRad.Checked = false;
                forkRad.BackColor = Color.Red;
            }
            else
            {
                forkRad.Checked = true;
                forkRad.BackColor = Color.Green; 
            }

            if (extraRollerBtn == false)
            {
                extraRollerBtnRad.Checked = false;
                extraRollerBtnRad.BackColor = Color.Red; 
            }
            else
            {
                extraRollerBtnRad.Checked = true;
                extraRollerBtnRad.BackColor = Color.Green;
            }

            if (goSign == true)
            {
                goRad.Checked = true;
                goRad.BackColor = Color.Green;
                stopRad.Checked = false;
                stopRad.BackColor = Color.Red; 
            }
            else if (stopSign == true)
            {
                goRad.Checked = false;
                goRad.BackColor = Color.Red; 
                stopRad.BackColor = Color.Green;
                stopRad.Checked = true; 
            }
            else
            {
                goRad.Checked = false;
                goRad.BackColor = Color.Red;
                stopRad.BackColor = Color.Red;
                stopRad.Checked = false; 
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            int err;
            output[0] = 0;
            err = seaLevelDevice1.SM_WriteDigitalOutputs(0, 4, output);
            err = seaLevelDevice2.SM_WriteDigitalOutputs(0, 4, output);
            stopSign = false;
            goSign = true;
            forkSolenoid = false;
            extraRollerBtn = false;
            audio = false; 
            
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            int err;
            output[0] = 0;
            err = seaLevelDevice1.SM_WriteDigitalOutputs(0, 4, output);
            err = seaLevelDevice2.SM_WriteDigitalOutputs(0, 4, output);
            seaLevelDevice1.SM_Close();
            seaLevelDevice2.SM_Close();
            Thread.Sleep(1000);
            Application.Exit();
        }

    }
}


