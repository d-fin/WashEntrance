using Sealevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WashEntrance_V1
{
    public static class SeaLevelThread
    {
        //variable declarations 

        public static bool seaDAC1 = false;
        public static bool seaDAC2 = false;

        // all inputs are 10 - 24 VDC 
        public static bool SD2_input1_sonar = false;  // sonar
        public static bool SD2_input2_tireEye = false;  // tire eye 
        public static bool SD2_input3_rollerEye = false;  // roller eye 
        public static bool SD2_input4_resetSigns = false;  // reset signs

        public static bool SD1_input1_pgmCar = false;  // program car
        public static bool SD1_input2 = false;  
        public static bool SD1_input3 = false;
        public static bool SD1_input4 = false;

        // outputs are Form C Relays, voltage output is 10-24 VDC from common. 
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
       

        

        //bit value retrieval method
        public static bool GetBit(this byte b, int bitNumber)
        {
            return (b & (1 << bitNumber)) != 0;
        }

        public static bool SeaDACLiteConnect(SeaMAX SeaMAX_DeviceHandler)
        {
            // connect to SeaDAC Lite 
            try
            {
                do
                {
                    int errno = SeaMAX_DeviceHandler.SM_Open("SeaDAC Lite 0");
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

        private static bool CarInPosition(SeaMAX SeaDac_DeviceHandler, byte[] input)
        {
            bool sonar = false;
            bool tire_eye = false; 

            while (true)
            {
                int err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(0, 2, input);
                if (err < 0)
                {
                    Logger.WriteLog("Error reading sonar and tire eye inputs");
                    return false; 
                }
                else
                {
                    // if both of these variables are true then the car is in position 
                    sonar = GetBit(input[0], 0);
                    tire_eye = GetBit(input[0], 1);

                    if (sonar == true && tire_eye == true)
                    {
                        return true; 
                    }
                }
            } 
        }

        private static bool RollerMonitoring(SeaMAX SeaDac_DeviceHandler, byte[] input, byte[] output)
        {
            int rollerCounter = 0;
            bool rollerEye = false; 
            int err = -1;
            output[0] = 1;

            // write to the fork solenoid relay to lift the fork.
            while (true)
            {
                err = SeaDac_DeviceHandler.SM_WriteDigitalOutputs(2, 1, output);
                if (err < 0)
                {
                    Logger.WriteLog("Error outputting to fork solenoid.");
                }
                else
                {
                    SD2_output3_forkSolenoid = true;
                    break;
                }
            }

            while (true)
            {
                err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(2, 1, input);
                if (err > 0)
                {
                    SD2_input3_rollerEye = true;
                }
                rollerEye = GetBit(input[0], 0);
                if (rollerEye == true)
                {
                    rollerCounter++;
                    if (rollerCounter == 5)
                    {
                        err = -1; 
                        while (err < 0)
                        {
                            output[0] = 0;
                            err = SeaDac_DeviceHandler.SM_WriteDigitalOutputs(2, 1, output);
                            if (err > 0)
                            {
                                SD2_output3_forkSolenoid = true;
                            }
                        }
                        return true;
                    }
                }
            }
        }

        // Main SeaLevel Task
        public static void SeaLevelTask()
        {
            SeaMAX SeaDACLite1_DeviceHandler = new SeaMAX();
            SeaMAX SeaDACLite2_DeviceHandler = new SeaMAX();
            byte[] SeaDac1_Input = new byte[1];
            byte[] SeaDac2_Input = new byte[1];
            byte[] SeaDac1_Output = new byte[1];
            byte[] SeaDac2_Output = new byte[1];
            int err;

            while (true)
            {
                seaDAC1 = SeaDACLiteConnect(SeaDACLite1_DeviceHandler);
                seaDAC2 = SeaDACLiteConnect(SeaDACLite2_DeviceHandler);
                if (seaDAC1 && seaDAC2) { break; }
            }

            try
            {
                while (true)
                {
                    if (Form1.Shutdown)
                    {
                        SeaDac1_Output[0] = 0;
                        SeaDac2_Output[0] = 0;
                        err = SeaDACLite1_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaDac1_Output);
                        err = SeaDACLite2_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaDac2_Output);
                        Thread.Sleep(50);
                        Application.ExitThread();
                        break;
                    }


                    while (true)
                    {
                        err = SeaDACLite1_DeviceHandler.SM_ReadDigitalInputs(0, 1, SeaDac1_Input);

                        if (err < 0)
                        {
                            Logger.WriteLog("Error reading input 1 of device 2.");
                        }
                        else
                        {
                            SD1_input1_pgmCar = GetBit(SeaDac1_Input[0], 0);
                            if (SD1_input1_pgmCar == true)
                            {
                                // this means a car is ready to be programmed, now we need to make sure the car is in position. 
                                carProgrammed = true;
                                int attempts = 0;
                                while (in_position == false)
                                {
                                    in_position = CarInPosition(SeaDACLite2_DeviceHandler, SeaDac2_Input);
                                    attempts++; 
                                    if (attempts > 100)
                                    {
                                        // there is an error reading the inputs which means there is a sensor issue or a device issue. 
                                    }
                                    if (in_position == true)
                                    {
                                        // below is firing the signs and audio relays 
                                        // the result is : Please Pull Forward sign (N/C) is turned off. 
                                        //                 Stop sign (N/O) is turned on 
                                        //                 Audio is played - audio is a dry contact off of the N/O device relay. 
                                        SeaDac2_Output[0] = 1;
                                        err = SeaDACLite2_DeviceHandler.SM_WriteDigitalOutputs(0, 1, SeaDac2_Output);
                                        if (err >= 0)
                                        {
                                            SD2_output1_audio = true;
                                            Thread.Sleep(3000);
                                            SeaDac2_Output[0] = 0;
                                            err = SeaDACLite2_DeviceHandler.SM_WriteDigitalOutputs(0, 1, SeaDac2_Output);
                                            SD2_output1_audio = false; 
                                        }

                                        SeaDac2_Output[0] = 1;
                                        err = SeaDACLite2_DeviceHandler.SM_WriteDigitalOutputs(1, 1, SeaDac2_Output);
                                        if (err >= 0)
                                        {
                                            SD2_output2_signs = true; 
                                        }

                                        // the fork solenoid also needs to be fired but function is defined for that since we are implementing roller monitoring. (done in function)
                                        bool carMoving = RollerMonitoring(SeaDACLite2_DeviceHandler, SeaDac2_Input, SeaDac2_Output);
                                        if (carMoving == true)
                                        {
                                            Logger.WriteLog("Rollers outputted and car is moving.");
                                        }
                                        else
                                        {
                                            Logger.WriteLog("Error outputting rollers.");
                                        }
                                    }
                                }

                                // wait for reset sign to be true. 
                                // We want to ignore all inputs when the a car is programmed (we dont want to program another car too early). 
                                // 

                                if (carProgrammed == true)
                                {
                                    while (true)
                                    {
                                        err = SeaDACLite2_DeviceHandler.SM_ReadDigitalInputs(3, 1, SeaDac2_Input);
                                        SD2_input4_resetSigns = GetBit(SeaDac2_Input[0], 1);

                                        if (SD2_input4_resetSigns == true)
                                        {
                                            SeaDac2_Output[0] = 0;
                                            err = SeaDACLite2_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaDac2_Output);
                                            carProgrammed = false;
                                            in_position = false;
                                            SD2_output1_audio = GetBit(SeaDac2_Output[0], 0);
                                            SD2_output2_signs = GetBit(SeaDac2_Output[0], 1);
                                            SD2_output3_forkSolenoid = GetBit(SeaDac2_Output[0], 2);

                                            err = SeaDACLite2_DeviceHandler.SM_ReadDigitalInputs(0, 4, SeaDac2_Input);
                                            SD2_input1_sonar = GetBit(SeaDac2_Input[0], 0);
                                            SD2_input2_tireEye = GetBit(SeaDac2_Input[0], 1);
                                            SD2_input3_rollerEye = GetBit(SeaDac2_Input[0], 2);
                                            SD2_input4_resetSigns = GetBit(SeaDac2_Input[0], 3);

                                            break;
                                        }
                                    }
                                }
                            }
                        }
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
