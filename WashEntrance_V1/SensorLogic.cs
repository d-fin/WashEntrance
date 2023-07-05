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

            int err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(0, 2, input);
            if (err < 0)
            {
                Logger.WriteLog("Error reading sonar and tire eye inputs");
                return false;
            }
            else
            {
                // if both of these variables are true then the car is in position 
                SD2_input1_sonar = GetBit(input[0], 0);
                SD2_input2_tireEye = GetBit(input[0], 1);

                if (SD2_input1_sonar == true && SD2_input2_tireEye == true)
                {
                    return true;
                }
            }
            return false;

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
                    Thread.Sleep(1300); // changed from 1500 
                    if (rollerCounter == 2)
                    {
                        // below is what is currently being used - switching to new system. - look for input of first two rollers then look for the third and drop 
                        //                                                           the fork when the third is sensed. (sensor is ~5 feet before fork)
                        //                                                           this is an attempt to prevent any roller jams. 


                        /*Thread.Sleep(1500);
                        err = -1;
                        while (err < 0)
                        {
                            output[0] = 0;
                            err = SeaDac_DeviceHandler.SM_WriteDigitalOutputs(2, 1, output);
                            if (err >= 0)
                            {
                                SD2_output3_forkSolenoid = false;
                            }
                        }*/

                        // new functionality. 
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
        public static bool Reset(SeaMAX SeaDac_DeviceHandler, byte[] input, byte[] output)
        {
            int err; 
            while (true)
            {
                //err = SeaDACLite1_DeviceHandler.SM_ReadDigitalInputs(3, 1, SeaDac1_Input);
                err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(0, 4, input);
                SD1_input1_pgmCar = GetBit(input[0], 0);
                SD1_input2_pgmCarButton = GetBit(input[0], 1);
                SD1_input3_resetSigns = GetBit(input[0], 2);
                Logger.WriteLog($"{SD1_input1_pgmCar}, {SD1_input2_pgmCarButton}, {SD1_input3_resetSigns}");
                if (SD1_input3_resetSigns == true)
                {
                    output[0] = 0;
                    err = SeaDac_DeviceHandler.SM_WriteDigitalOutputs(1, 1, output);
                    if (err < 0)
                    {
                        return true; 
                    }
                }
                else if (SD1_input2_pgmCarButton == true)
                {
                    if (RollerMonitoring(SeaDac_DeviceHandler, input, output) == true)
                    {
                        Logger.WriteLog("Extra set of rollers sent.");
                    }
                    else
                    {
                        Logger.WriteLog("Error outputting rollers.");
                    }
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
                            if (SD1_input1_pgmCar == true || SD1_input2_pgmCarButton == true)
                            {
                                // this means a car is ready to be programmed, now we need to make sure the car is in position. 
                                carProgrammed = true;
                                //int attempts = 0;
                                while (in_position == false)
                                {
                                    in_position = CarInPosition(SeaDACLite2_DeviceHandler, SeaDac2_Input);
                                    err = SeaDACLite2_DeviceHandler.SM_ReadDigitalInputs(0, 4, SeaDac2_Input);
                                    /*attempts++;
                                    if (attempts > 100)
                                    {
                                        // there is an error reading the inputs which means there is a sensor issue or a device issue. 
                                        Logger.WriteLog("There has been 100 attempts at reading the input.");
                                    }*/
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
                                        //bool carMoving = RollerMonitoring(SeaDACLite2_DeviceHandler, SeaDac2_Input, SeaDac2_Output);
                                        //if (carMoving == true)
                                        Thread.Sleep(1200);
                                        bool carMoving = false;
                                        while (carMoving == false)
                                        {
                                            carMoving = RollerMonitoring(SeaDACLite2_DeviceHandler, SeaDac2_Input, SeaDac2_Output);
                                        }

                                        // wait for reset sign to be true. 
                                        // We want to ignore all inputs when the a car is programmed (we dont want to program another car too early). 
                                        // 
                                        // NOTE:
                                        // Having issues with ResetLights coming from TW5 box - currently using a 6000ms sleep in its place. 
                                        // once I get ResetSign working then I dont want to flip sign until the signal comes through
                                        // (this means a vehicle is not in motion and new set of rollers need to be sent manually from extra roller button) 
                                        //bool reset = false;
                                        /*bool reset = Reset(SeaDACLite1_DeviceHandler, SeaDac1_Input, SeaDac1_Output);
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
                                        }*/
                                        /*if (RollerMonitoring(SeaDACLite2_DeviceHandler, SeaDac2_Input, SeaDac2_Output) == true)
                                        {
                                            Logger.WriteLog("Rollers outputted and car is moving.");
                                        }
                                        else
                                        {
                                            Logger.WriteLog("Error outputting rollers.");
                                        }*/
                                    }
                                }

                                if (carProgrammed == true)
                                {
                                    Thread.Sleep(6200);
                                    bool temp = true;
                                    if (temp == true)
                                    {
                                        SeaDac2_Output[0] = 0;
                                        err = SeaDACLite2_DeviceHandler.SM_WriteDigitalOutputs(1, 1, SeaDac2_Output);
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
                                // wait for reset sign to be true. 
                                // We want to ignore all inputs when the a car is programmed (we dont want to program another car too early). 
                                // 
                                // NOTE:
                                // Having issues with ResetLights coming from TW5 box - currently using a 6000ms sleep in its place. 
                                // once I get ResetSign working then I dont want to flip sign until the signal comes through
                                // (this means a vehicle is not in motion and new set of rollers need to be sent manually from extra roller button) 
                                
                                /*if (carProgrammed == true)
                                {
                                    //Thread.Sleep(5000);
                                    while (true)
                                    {
                                        //err = SeaDACLite1_DeviceHandler.SM_ReadDigitalInputs(3, 1, SeaDac1_Input);
                                        err = SeaDACLite1_DeviceHandler.SM_ReadDigitalInputs(0, 4, SeaDac1_Input);
                                        SD1_input1_pgmCar = GetBit(SeaDac1_Input[0], 0);
                                        SD1_input2_pgmCarButton = GetBit(SeaDac1_Input[0], 1);
                                        SD1_input3_resetSigns = GetBit(SeaDac1_Input[0], 2);

                                        Thread.Sleep(6000);
                                        bool temp = true; 
                                        
                                        if (SD1_input3_resetSigns == true)
                                        //if (temp == true)
                                        {
                                            SeaDac2_Output[0] = 0;
                                            err = SeaDACLite2_DeviceHandler.SM_WriteDigitalOutputs(1, 1, SeaDac2_Output);
                                            break;
                                        }
                                        else if (SD1_input2_pgmCarButton == true)
                                        {
                                            if (RollerMonitoring(SeaDACLite2_DeviceHandler, SeaDac2_Input, SeaDac2_Output) == true)
                                            {
                                                Logger.WriteLog("Extra set of rollers sent.");
                                            }
                                            else
                                            {
                                                Logger.WriteLog("Error outputting rollers.");
                                            }
                                        }
                                    }

                                    SeaDac2_Output[0] = 0;
                                    err = SeaDACLite2_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaDac2_Output);
                                    in_position = false;
                                    carProgrammed = false; 
                                }*/
                            }
                        }
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