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
        public static bool GetBit(this byte b, int bitNumber)
        {
            return (b & (1 << bitNumber)) != 0;
        }

        /*
         SeaDACLiteConnect connects to the SeaLevel devices. 
         */
        public static bool SeaDACLiteConnect(SeaMAX SeaMAX_DeviceHandler, int num)
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
                    Thread.Sleep(5000);
                } while (true);
            }
            catch (Exception e)
            {
                Logger.WriteLog($"SeaDAC Lite connection failed. Exception: {e}");
                return false;
            }

            return true;
        }

        /*
         CarInPosition uses the sonar and the tire eye to determine if the vehicle is in the proper loading position. 
         */
        public static bool CarInPosition(SeaMAX SeaDac_DeviceHandler, byte[] input)
        {
            Logger.WriteLog("Entering CarInPosition()");
            while (true)
            {
                int err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(0, 1, input);

                SD2_input1_sonar = GetBit(input[0], 0);
                if (SD2_input1_sonar == true)
                {
                    err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(1, 1, input);
                    SD2_input2_tireEye = GetBit(input[0], 1);
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

        public static Tuple<bool, bool, bool, bool> GetInputs(SeaMAX SeaDac_DeviceHandler, byte[] input)
        {
            int err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(0, 4, input);
            SD2_input1_sonar = GetBit(input[0], 0);
            SD2_input2_tireEye = GetBit(input[0], 1);
            SD2_input3_rollerEye = GetBit(input[0], 2);
            SD2_input4 = GetBit(input[0], 3);

            return Tuple.Create(SD2_input1_sonar, SD2_input2_tireEye, SD2_input3_rollerEye, SD2_input4);
        }

        /*
        RollerMonitoring monitors rollers once the vehicle is in position this function handles firing the fork solenoid and monitoring the rollers. 
        When two rollers are sent then the fork solenoid is turned off.
         */
        public static bool RollerMonitoring(SeaMAX SeaDac_DeviceHandler, byte[] input, byte[] output)
        {
            int rollerCounter = 0;
            bool success = false;
            output[0] = 1;

            // COMMENT ON BELOW WHILE LOOP 
            // this may be bad practice to try and constantly lift the fork 
            // should switch to attempt > sleep > attempt. Also need to add a check to make sure a roller isn't right in front of the door.
            // best way to do that is lift the fork when a roller is breaking the roller eye sensor - this will result in the fork 
            // being lifted when there is for sure no roller at the door and the same technique for dropping the fork. 

            // NOTE
            // rollermonitoring V2 in prod works miles better. 


            // Write to the fork solenoid relay to lift the fork.
            while (!success)
            {
                while (true)
                {
                    int err2 = SeaDac_DeviceHandler.SM_ReadDigitalInputs(0, 4, input);
                    bool one = GetBit(input[0], 0);
                    bool two = GetBit(input[0], 1);
                    bool three = GetBit(input[0], 2);
                    bool four = GetBit(input[0], 3);
                    if (three == true)
                    {
                        int errr = SeaDac_DeviceHandler.SM_WriteDigitalOutputs(2, 1, output);
                        if (errr < 0)
                        {
                            Logger.WriteLog("Error outputting to fork solenoid.");
                        }
                        else
                        {
                            SD2_output3_forkSolenoid = GetBit(output[0], 2);
                            success = true;
                            break;
                        }
                    }
                }

            }


            while (true)
            {
                int err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(0, 4, input);
                bool one = GetBit(input[0], 0);
                bool two = GetBit(input[0], 1);
                bool three = GetBit(input[0], 2);
                bool four = GetBit(input[0], 3);

                if (three == true)
                {
                    three = false;
                    rollerCounter++;
                    Thread.Sleep(1300); 
                    if (rollerCounter == 2)
                    {
                        while (true)
                        {
                            err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(0, 4, input);
                            //one = GetBit(input[0], 0);
                            //two = GetBit(input[0], 1);
                            three = GetBit(input[0], 2);
                            //four = GetBit(input[0], 3);

                            // if three is true then a third roller is at the roller eye. 
                            if (three == true)
                            {
                                output[0] = 0;
                                err = SeaDac_DeviceHandler.SM_WriteDigitalOutputs(2, 1, output);
                                if (err >= 0)
                                {
                                    SD2_output3_forkSolenoid = false;
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
        }

        /*
         Reset awaits the Reset flag from the TW5 box, the reset flag tells us that the vehicle is in motion and we can work on programming the next vehicle. 
        
        */
        public static bool Reset(SeaMAX SeaDac_DeviceHandler, SeaMAX SeaDac_DeviceHandler2, byte[] input, byte[] input2, byte[] output, byte[] output2)
        {
            int err;
            Logger.WriteLog("Starting Reset()");

            while (true)
            {
                err = SeaDac_DeviceHandler2.SM_ReadDigitalInputs(0, 1, input2);
                bool vehicleInSonar = GetBit(input2[0], 0);

                if (vehicleInSonar == true)
                {
                    // if the vehicle is still in the sonars beam then we dont want the "Stop" sign to change, this is to prevent user error if the wash were to be stopped while 
                    // they are still in the loading bay. It is also to mitigate error if the user doesn't properly load and the rollers go past the vehicle, then we need to send 
                    // an extra set of rollers. 
                    Thread.Sleep(100);
                    err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(1, 1, input);  
                    SD1_input2_pgmCarButton = GetBit(input[0], 1);

                    if (SD1_input2_pgmCarButton == true)
                    {
                        if (RollerMonitoring(SeaDac_DeviceHandler2, input2, output2) == true)
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
                    Thread.Sleep(1000);
                    return true;
                }
            }
        }

        /*
         Main Function
         */
        public static void SeaLevelTask()
        {
            // local variables 
            SeaMAX SeaDACLite1_DeviceHandler = new SeaMAX();
            SeaMAX SeaDACLite2_DeviceHandler = new SeaMAX();

            byte[] SeaDac1_Input = new byte[1];
            byte[] SeaDac2_Input = new byte[1];

            byte[] SeaDac1_Output = new byte[1];
            byte[] SeaDac2_Output = new byte[1];

            int err;
            int i = 0;

            // make sure the two SeaLevel devices are connected if not keep attempting and do nothing. 
            while (true)
            {
                seaDAC1 = SeaDACLiteConnect(SeaDACLite1_DeviceHandler, 0);
                seaDAC2 = SeaDACLiteConnect(SeaDACLite2_DeviceHandler, 0);
                if (seaDAC1 && seaDAC2)
                {
                    break;
                }
            }

            try
            {
                while (true)
                {
                    if (Form1.Shutdown)
                    {
                        SeaDac2_Output[0] = 0;
                        err = SeaDACLite2_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaDac2_Output);
                        Thread.Sleep(50);
                        Application.ExitThread();
                        break;
                    }
                    if (i == 2000)
                    {
                        Logger.DeleteOldLines();
                        i = 0;
                    }

                    SeaDac2_Output[0] = 0;
                    err = SeaDACLite2_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaDac2_Output);

                    while (true)
                    {
                        // Look to see if the TW box is signaling for a vehicle to be programmed or if the manual programming button is pressed (extra roller btn)
                        // do nothing until either one of these are true!!!!             
                        err = SeaDACLite1_DeviceHandler.SM_ReadDigitalInputs(0, 2, SeaDac1_Input);
                        SD1_input1_pgmCar = GetBit(SeaDac1_Input[0], 0);
                        SD1_input2_pgmCarButton = GetBit(SeaDac1_Input[0], 1);
                        if (err < 0)
                        {
                            Logger.WriteLog("Error reading input 1 of device 1.");
                        }
                        else
                        {
                            //SD1_input1_pgmCar = true;
                            //Logger.WriteLog($"pgmCar - {SD1_input1_pgmCar} : extra roller button - {SD1_input2_pgmCarButton}");
                            if (SD1_input1_pgmCar == true || SD1_input2_pgmCarButton == true)
                            {
                                // this means a car is ready to be programmed, now we need to make sure the car is in position. 
                                carProgrammed = true;
                                //int attempts = 0;
                                while (in_position == false)
                                {
                                    if (SD1_input2_pgmCarButton == true)
                                    {
                                        in_position = true;
                                    }
                                    else
                                    {
                                        in_position = CarInPosition(SeaDACLite2_DeviceHandler, SeaDac2_Input);
                                    }
                                    err = SeaDACLite2_DeviceHandler.SM_ReadDigitalInputs(0, 4, SeaDac2_Input);
                                    if (in_position == true)
                                    {
                                        // below is firing the signs and audio relays 
                                        // the result is : Please Pull Forward sign (N/C) is turned off. 
                                        //                 Stop sign (N/O) is turned on 
                                        //                 Audio is played - audio is a dry contact off of the N/O device relay. 

                                        SeaDac2_Output[0] = 1;
                                        err = SeaDACLite2_DeviceHandler.SM_WriteDigitalOutputs(0, 1, SeaDac2_Output);
                                        err = SeaDACLite2_DeviceHandler.SM_WriteDigitalOutputs(1, 1, SeaDac2_Output);
                                        if (err >= 0)
                                        {
                                            SD2_output1_audio = true;
                                            SD2_output2_signs = true;

                                            // signs have been changed and audio played, sleep for 2000 ms to let everything settle and enough time for the audio to have played. 
                                            Thread.Sleep(100);

                                            // turn off the audio relay (its just a dry contact so it needs voltage for a few seconds)
                                            SeaDac2_Output[0] = 0;
                                            err = SeaDACLite2_DeviceHandler.SM_WriteDigitalOutputs(0, 1, SeaDac2_Output);
                                            SD2_output1_audio = false;
                                        }

                                        // the fork solenoid also needs to be fired but function is defined for that since we are implementing roller monitoring. (done in function)
                                        Thread.Sleep(1500);
                                        bool carMoving = false;
                                        while (carMoving == false)
                                        {
                                            carMoving = RollerMonitoring(SeaDACLite2_DeviceHandler, SeaDac2_Input, SeaDac2_Output);
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

                                Thread.Sleep(1000);
                                bool reset = Reset(SeaDACLite1_DeviceHandler, SeaDACLite2_DeviceHandler, SeaDac1_Input, SeaDac2_Input, SeaDac1_Output, SeaDac2_Output);
                                if (reset == true)
                                {
                                    SeaDac2_Output[0] = 0;
                                    err = SeaDACLite2_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaDac2_Output);
                                    in_position = false;
                                    carProgrammed = false;
                                    SD1_input1_pgmCar = false;
                                    SD1_input2_pgmCarButton = false;
                                    SD1_input3_resetSigns = false;
                                    break;
                                }
                            }
                        }
                        i++;
                        Thread.Sleep(3000);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Exception : {ex}");
            }
        }
    }
}