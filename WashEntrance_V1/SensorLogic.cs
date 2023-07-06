using Sealevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;


namespace WashEntrance_V1
{
    public static class SeaLevelThread
    {
        //variable declarations 

        public static bool seaDAC1 = false;
        public static bool seaDAC2 = false;

        // all inputs are 10 - 24 VDC 
        public static bool SD2_input1_sonar = false;  // sonar - 24VDC
        public static bool SD2_input2_tireEye = false;  // tire eye - 24VDC 
        public static bool SD2_input3_rollerEye = false;  // roller eye - 24VDC 
        public static bool SD2_input4 = false;
        //public static bool SD2_input4_resetSigns = false;  // reset signs - 24VAC

        public static bool SD1_input1_pgmCar = false;  // program car - 24 VAC
        public static bool SD1_input2_pgmCarButton = false; // extra roller button inside store - 24VAC
        public static bool SD1_input3_resetSigns = false; // reset flag / hold - 24VAC
        public static bool SD1_input4 = false;

        // outputs are Form C Relays, voltage output is 10-24 VDC from common, except fork solenoid is 120VAC
        public static bool SD2_output1_audio = false; // audio
        public static bool SD2_output2_signs = false; // stop sign & go sign (N/O = closed, N/C = go)
        public static bool SD2_output3_forkSolenoid = false; // fork solenoid
        public static bool SD2_output4 = false;

        public static bool SD1_output1 = false;
        public static bool SD1_output2 = false;
        public static bool SD1_output3 = false;
        public static bool SD1_output4 = false;

        // Non-device related variables

        public static bool carProgrammed = false;
        public static bool in_position = false;




        /*
         GetBit converts input, a byte array, to booleans
         */
        public static Func<byte, int, bool> GetBit = (b, bitNumber) => (b & (1 << bitNumber)) != 0;
        
        // get inputs from SeaLevel Devices
        public static Func<SeaMAX, int, bool> GetInput = (deviceHandler, bitNum) =>
        {
            byte[] input = new byte[1];
            int err =  deviceHandler.SM_ReadDigitalInputs(0, 4, input);
            return GetBit(input[0], bitNum);
        };

        // write output to SeaLevel devices
        public static Func<SeaMAX, int, int, bool, int> WriteOutput = (DeviceHandler, start, numberOfOutputs, on_off) =>
        {
            byte[] output = new byte[1];

            if (on_off == true) 
            { 
                output[0] = 1; 
            }
            else if (on_off == false) 
            { 
                output[0] = 0; 
            }

            return DeviceHandler.SM_WriteDigitalOutputs(start, numberOfOutputs, output);
        };


        /*
         SeaDACLiteConnect connects to the SeaLevel devices. 
         */
        public static async Task<bool> SeaDACLiteConnect(SeaMAX SeaMAX_DeviceHandler, int num)
        {
            // connect to SeaDAC Lite 
            try
            {
                do
                {
                    int errno = SeaMAX_DeviceHandler.SM_Open("SeaDAC Lite " + num.ToString());
                    if (errno == 0)
                    {
                        Logger.WriteLog("Successfully Connected to SeaDAC Lite 0");
                        break;
                    }

                    if (errno < 0)
                    {
                        switch (errno)
                        {
                            case -20:
                                Logger.WriteLog($"SeaDAC Lite Error # : {errno} - Ethernet - Could not resolve Host address. (IP Address incorrect)");
                                break;
                            case -21:
                                Logger.WriteLog($"SeaDAC Lite Error # : {errno} - Ethernet - Host refused or unavailable. SeaLevel Device Restart Required.");
                                break;
                            case -22:
                                Logger.WriteLog($"SeaDAC Lite Error # : {errno} - Ethernet - Could not acquire free socket.");
                                break;
                            default:
                                Logger.WriteLog($"SeaDAC Lite Error # : {errno}");
                                break;
                        }
                    }
                    await Task.Delay(5000);
                } while (true);
            }
            catch (Exception e)
            {
                Logger.WriteLog($"SeaDAC Lite connection failed. Exception: {e}");
                return false;
            }

            return true;
        }

        
        public static async Task<bool> CarInPosition(SeaMAX SeaDac_DeviceHandler)
        {
            Logger.WriteLog("Entering CarInPosition()");
            while (true)
            {
                SD2_input1_sonar = GetInput(SeaDac_DeviceHandler, 0);
                if (SD2_input1_sonar == true)
                {
                    await Task.Delay(100);
                    SD2_input2_tireEye = GetInput(SeaDac_DeviceHandler, 1);

                    Logger.WriteLog($"Sonar - {SD2_input1_sonar} : Tire Eye - {SD2_input2_tireEye}");

                    if (SD2_input2_tireEye == true && SD2_input1_sonar == true)
                    {
                        return true;
                    }
                    else if (SD2_input2_tireEye == false)
                    {
                        SD2_input1_sonar = false;
                    }
                }
            }
        }
        /*
        RollerMonitoring monitors rollers once the vehicle is in position this function handles firing the fork solenoid and monitoring the rollers. 
        When two rollers are sent then the fork solenoid is turned off.
         */
        public static async Task<bool> RollerMonitoring(SeaMAX SeaDac_DeviceHandler)
        {
            int rollerCounter = 0;
            bool success = false;

            // NOTE
            // rollermonitoring V2 in prod works miles better. 
            // Write to the fork solenoid relay to lift the fork.
            while (!success)
            {
                while (true)
                {
                    // check when next roller is at roller eye, if it is that means fork is clear of any rollers.
                    SD2_input3_rollerEye = GetInput(SeaDac_DeviceHandler, 2);
                    if (SD2_input3_rollerEye == true)
                    {
                        int err = WriteOutput(SeaDac_DeviceHandler, 2, 1, true);
                        if (err < 0)
                        {
                            Logger.WriteLog("Error outputting to fork solenoid.");
                        }
                        else
                        {
                            success = true;
                            break;
                        }
                    }
                    await Task.Delay(50);
                }
            }


            while (true)
            {
                SD2_input3_rollerEye = GetInput(SeaDac_DeviceHandler, 2);
                if (SD2_input3_rollerEye == true)
                {
                    rollerCounter++;
                    await Task.Delay(1300);

                    if (rollerCounter == 2)
                    {
                        while (true)
                        {
                            SD2_input3_rollerEye = GetInput(SeaDac_DeviceHandler, 2);

                            // if true that means roller is at roller eye, safe to drop the fork. 
                            if (SD2_input3_rollerEye == true)
                            {
                                //output[0] = 0;
                                //err = SeaDac_DeviceHandler.SM_WriteDigitalOutputs(2, 1, output);
                                int err = WriteOutput(SeaDac_DeviceHandler, 2, 1, false);
                                if (err >= 0)
                                {
                                    SD2_output3_forkSolenoid = false;
                                    return true;
                                }
                            }
                            await Task.Delay(50);
                        }
                    }
                }
            }
        }

        /*
         Reset awaits the Reset flag from the TW5 box, the reset flag tells us that the vehicle is in motion and we can work on programming the next vehicle. 
        
        */
        public static async Task<bool> Reset(SeaMAX SeaDac_DeviceHandler, SeaMAX SeaDac_DeviceHandler2)
        {
            Logger.WriteLog("Starting Reset()");

            while (true)
            {
                bool vehicleInSonar = GetInput(SeaDac_DeviceHandler2, 0);
                if (vehicleInSonar == true)
                {
                    await Task.Delay(100);

                    SD1_input1_pgmCar = GetInput(SeaDac_DeviceHandler, 1);

                    if (SD1_input2_pgmCarButton == true)
                    {
                        if (await RollerMonitoring(SeaDac_DeviceHandler2) == true)
                        {
                            Logger.WriteLog("Extra set of rollers sent.");
                        }
                        else
                        {
                            Logger.WriteLog("Error outputting rollers.");
                        }
                    }
                }
                else
                {
                    await Task.Delay(1000);
                    return true;
                }
            }
        }

        /*
         Main Function
         */
        public static async Task SeaLevelTask()
        {
            // local variables 
            SeaMAX SeaDACLite1_DeviceHandler = new SeaMAX();
            SeaMAX SeaDACLite2_DeviceHandler = new SeaMAX();
            int err;

            // make sure the two SeaLevel devices are connected if not keep attempting and do nothing. 
            while (true)
            {
                seaDAC1 = await SeaDACLiteConnect(SeaDACLite1_DeviceHandler, 0);
                seaDAC2 = await SeaDACLiteConnect(SeaDACLite2_DeviceHandler, 0);
                if (seaDAC1 && seaDAC2)
                {
                    break;
                }
            }

            try
            {
                DateTime startTime = DateTime.Today.AddHours(9); 
                DateTime endTime = DateTime.Today.AddHours(18);

                while (true)
                {
                    if (Form1.Shutdown)
                    {
                        err = WriteOutput(SeaDACLite2_DeviceHandler, 0, 4, false);
                        await Task.Delay(50);
                        Environment.Exit(0);
                    }

                    // make sure all outputs are off 
                    err = WriteOutput(SeaDACLite2_DeviceHandler, 0, 4, false);

                    while (true)
                    {
                        // check if any input on pgmCar
                        SD1_input1_pgmCar = GetInput(SeaDACLite1_DeviceHandler, 0);
                        // check if any input on extra roller button
                        SD1_input2_pgmCarButton = GetInput(SeaDACLite1_DeviceHandler, 1);

                        if (err < 0)
                        {
                            Logger.WriteLog("Error reading input 1 of device 1.");
                        }
                        else
                        {
                            if (SD1_input1_pgmCar == true || SD1_input2_pgmCarButton == true)
                            {
                                // this means a car is ready to be programmed, now we need to make sure the car is in position. 
                                carProgrammed = true;

                                while (in_position == false)
                                {
                                    if (SD1_input2_pgmCarButton == true)
                                    {
                                        in_position = true;
                                    }
                                    else
                                    {
                                        in_position = await CarInPosition(SeaDACLite2_DeviceHandler);
                                    }

                                    if (in_position == true)
                                    {
                                        // below is firing the signs and audio relays 
                                        // the result is : Please Pull Forward sign (N/C) is turned off. 
                                        //                 Stop sign (N/O) is turned on 
                                        //                 Audio is played - audio is a dry contact off of the N/O device relay. 

                                        // change signs and play audio
                                        err = WriteOutput(SeaDACLite2_DeviceHandler, 0, 1, true);
                                        err = WriteOutput(SeaDACLite2_DeviceHandler, 1, 1, true);
                                        if (err >= 0)
                                        {
                                            SD2_output1_audio = true;
                                            SD2_output2_signs = true;

                                            // signs have been changed and audio played, sleep for 2000 ms to let everything settle and enough time for the audio to have played. 
                                            await Task.Delay(100);

                                            // turn off the audio relay (its just a dry contact so it needs voltage for a second)
                                            err = WriteOutput(SeaDACLite2_DeviceHandler, 0, 1, false);
                                            SD2_output1_audio = false;
                                        }

                                        // the fork solenoid also needs to be fired but function is defined for that since we are implementing roller monitoring. (done in function)
                                        await Task.Delay(1500);

                                        bool carMoving = false;
                                        
                                        while (carMoving == false)
                                        {
                                            carMoving = await RollerMonitoring(SeaDACLite2_DeviceHandler);
                                        }
                                    }
                                }
                                // wait for reset sign to be true. 
                                // We want to ignore all inputs when the a car is programmed (we dont want to program another car too early). 
                                // 
                                // NOTE:
                                // Having issues with ResetLights coming from TW5 box - currently using a 6000ms sleep in its place. 
                                // once I get ResetSign working then I dont want to flip sign until the signal comes through
                                // (this means a vehicle is not in motion and new set of rollers need to be sent manually from extra roller button) 

                                await Task.Delay(1000);

                                bool reset = await Reset(SeaDACLite1_DeviceHandler, SeaDACLite2_DeviceHandler);

                                if (reset == true)
                                {
                                    // turn off all outputs
                                    err = WriteOutput(SeaDACLite2_DeviceHandler, 0, 4, false);
                                    in_position = false;
                                    carProgrammed = false;
                                    SD1_input1_pgmCar = false;
                                    SD1_input2_pgmCarButton = false;
                                    SD1_input3_resetSigns = false;
                                    break;
                                }
                            }
                        }

                        await Task .Delay(3000);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Exception : {ex}");
            }

            //return Task.CompletedTask;
        }
    }
}