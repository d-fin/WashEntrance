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
        public static bool extraRollerBtn = false;
        public static bool reset = false;
        public static bool carMoving = false;
        public static bool signsChanged = false; 




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

        public static bool CarInPosition(SeaMAX SeaDac_DeviceHandler2, SeaMAX SeaDac_DeviceHandler1, byte[] input2, byte[] input1)
        {
            /* What needs to be accomplished: 
             *      1. Check if vehicle is in sonar.
             *      2. Check if the rear tire has passed the tire eye 
             *      3. If both of those are true then the vehicle is in position
             *      
             *      Need to account for debounce and false triggers. 
             */
            try
            {
                int err;
                int sonar_count = 0;

                err = SeaDac_DeviceHandler2.SM_ReadDigitalInputs(0, 1, input2);
                SD2_input1_sonar = GetBit(input2[0], 0);

                if (SD2_input1_sonar == true)
                {
                    for (int i = 0; i < 50; i++)
                    {
                        err = SeaDac_DeviceHandler2.SM_ReadDigitalInputs(0, 1, input2);
                        SD2_input1_sonar = GetBit(input2[0], 0);

                        if (SD2_input1_sonar == true)
                        {
                            sonar_count++;
                        }

                        Thread.Sleep(10);
                    }

                    if (sonar_count >= 30)
                    {
                        Thread.Sleep(1000);

                        err = SeaDac_DeviceHandler2.SM_ReadDigitalInputs(1, 1, input2);
                        SD2_input2_tireEye = GetBit(input2[0], 1);

                        if (SD2_input2_tireEye == true)
                        {
                            while (true)
                            {
                                err = SeaDac_DeviceHandler2.SM_ReadDigitalInputs(1, 1, input2);
                                SD2_input2_tireEye = GetBit(input2[0], 1);

                                if (SD2_input2_tireEye == false)
                                {
                                    return true; 
                                }
                                else
                                {
                                    Thread.Sleep(10);
                                }
                            }
                        }
                    }
                    else
                    {
                        return false; 
                    }
                }
                else
                {
                    return false; 
                }
            }
            catch (Exception e)
            {
                Logger.WriteLog($"CarInPosition() - Exception: {e}");
                return false;
            }
            return false; 
        }

        public static bool RollerMonitoring(SeaMAX SeaDac_DeviceHandler, byte[] input, byte[] output)
        {
            int rollerCounter = 0;
            bool success = false;
            output[0] = 1;
            try
            {
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
            catch (Exception e)
            {
                Logger.WriteLog($"RollerMonitoring() - Exception: {e}");
                return false;
            }
        }

        public static bool Reset(SeaMAX SeaDac1_DeviceHandler, SeaMAX SeaDac2_DeviceHandler, byte[] input1, byte[] input2, byte[] output1, byte[] output2)
        {
            try
            {
                int err;

                while (true)
                {
                    SD1_input2_pgmCarButton = false;
                    err = SeaDac1_DeviceHandler.SM_ReadDigitalInputs(0, 4, input1);
                    LogErrorInput(err, "Reset");

                    SD1_input1_pgmCar = GetBit(input1[0], 0);
                    SD1_input2_pgmCarButton = GetBit(input1[0], 1);
                    SD1_input3_resetSigns = GetBit(input1[0], 2);

                    if (SD1_input3_resetSigns == true)
                    {
                        Logger.WriteLog($"Reset = {SD1_input3_resetSigns}");
                        Thread.Sleep(1500);
                        output2[0] = 0;
                        err = SeaDac2_DeviceHandler.SM_WriteDigitalOutputs(0, 4, output2);
                        LogErrorOutput(err, "Reset");

                        in_position = false;
                        carProgrammed = false;
                        SD1_input1_pgmCar = false;
                        SD1_input2_pgmCarButton = false;
                        SD1_input3_resetSigns = false;
                        SD2_input1_sonar = false;
                        SD2_input2_tireEye = false;
                        SD2_input3_rollerEye = false;
                        reset = false;
                        carMoving = false;
                        extraRollerBtn = false;

                        //Logger.WriteLog("Returning from Reset");
                        return true;
                    }
                    else if (SD1_input2_pgmCarButton == true)
                    {
                        carMoving = false;
                        bool extraRoller = ExtraRoller(SeaDac1_DeviceHandler, SeaDac2_DeviceHandler, input1, input2, output1, output2);
                    }
                }


            }
            catch (Exception e)
            {
                Logger.WriteLog($"Reset() - Exception: {e}");
                return false;
            }
        }

        public static void LogErrorInput(int err, string function)
        {
            if (err < 0)
            {
                Logger.WriteLog($"{function}() - SM_ReadDigitalInputs() error code: {err}");
            }
        }

        public static void LogErrorOutput(int err, string function)
        {
            if (err < 0)
            {
                Logger.WriteLog($"{function} - SM_ReadDigitalOutputs() error code: {err}");
            }
        }

        public static bool ExtraRoller(SeaMAX SeaDac1_DeviceHandler, SeaMAX SeaDac2_DeviceHandler, byte[] input1, byte[] input2, byte[] output1, byte[] output2)
        {

            try
            {
                carMoving = false;
                reset = false;


                output2[0] = 1;
                int err = SeaDac2_DeviceHandler.SM_WriteDigitalOutputs(0, 1, output2);
                LogErrorOutput(err, "ExtraRoller");
                err = SeaDac2_DeviceHandler.SM_WriteDigitalOutputs(1, 1, output2);
                LogErrorOutput(err, "ExtraRoller");

                if (err >= 0)
                {
                    SD2_output1_audio = true;
                    SD2_output2_signs = true;

                    Thread.Sleep(100);

                    output2[0] = 0;
                    err = SeaDac2_DeviceHandler.SM_WriteDigitalOutputs(0, 1, output2);
                    LogErrorOutput(err, "SeaLevelTask");
                    SD2_output1_audio = false;
                }
                Thread.Sleep(500);

                while (carMoving == false)
                {
                    carMoving = RollerMonitoring(SeaDac2_DeviceHandler, input2, output2);
                }
                while (reset == false)
                {
                    reset = Reset(SeaDac1_DeviceHandler, SeaDac2_DeviceHandler, input1, input2, output1, output2);
                }
                //Logger.WriteLog($"Returning from extra roller");
                return true;
            }
            catch (Exception e)
            {
                Logger.WriteLog($"ExtraRoller() - Exception: {e}");
                return false;
            }
        }

        public static bool ChangeSigns(SeaMAX SeaDac_DeviceHandler, byte[] output)
        {
            try
            {
                int err;

                output[0] = 1;
                err = SeaDac_DeviceHandler.SM_WriteDigitalOutputs(0, 1, output);
                LogErrorOutput(err, "SeaLevelTask");
                err = SeaDac_DeviceHandler.SM_WriteDigitalOutputs(1, 1, output);
                LogErrorOutput(err, "SeaLevelTask");

                if (err >= 0)
                {
                    SD2_output1_audio = true;
                    SD2_output2_signs = true;

                    Thread.Sleep(500);

                    output[0] = 0;
                    err = SeaDac_DeviceHandler.SM_WriteDigitalOutputs(0, 1, output);
                    SD2_output1_audio = false;

                    return true; 
                }
                
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Exception : {ex}");
                return false; 
            }

            return false; 

        }

        public static void MonitorExtraRollerBtn(SeaMAX SeaDac_DeviceHandler)
        {
            int err;
            byte[] input = new byte[1];

            while (true)
            {
                err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(1, 1, input);
                SD1_input2_pgmCarButton = GetBit(input[0], 1);

                Thread.Sleep(100);
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

            int switch_case = -1;
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
                SeaDac2_Output[0] = 0;
                SeaDac1_Output[0] = 0;
                err = SeaDACLite2_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaDac2_Output);
                err = SeaDACLite1_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaDac1_Output);

                Thread extraRollerButton = new Thread(() => MonitorExtraRollerBtn(SeaDACLite1_DeviceHandler));
                extraRollerButton.Start();

                while (true)
                {

                    if (Form1.Shutdown)
                    {
                        SeaDac2_Output[0] = 0;
                        err = SeaDACLite2_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaDac2_Output);
                        SeaDac1_Output[0] = 0;
                        err = SeaDACLite1_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaDac1_Output);

                        SeaDACLite1_DeviceHandler.SM_Close();
                        SeaDACLite2_DeviceHandler.SM_Close();
                        extraRollerButton.Abort();

                        Thread.Sleep(50);
                        Application.ExitThread();
                        break;
                    }

                    // check to see if a car is in the proper loading position. 
                    if (CarInPosition(SeaDACLite2_DeviceHandler, SeaDACLite1_DeviceHandler, SeaDac2_Input, SeaDac1_Input) == true)
                    {
                        in_position = true; 
                        switch_case = 0;

                        if (signsChanged == false)
                        {
                            signsChanged = ChangeSigns(SeaDACLite2_DeviceHandler, SeaDac2_Output);
                        }
                    }
                    // keep an eye on the extra roller button
                    else
                    {
                        if (SD1_input2_pgmCarButton == true)
                        {
                            in_position = true;
                            switch_case = 1;
                            Thread.Sleep(100);
                        }
                    }
                    


                    // if the car is in the proper loading position (or extra roller is sent) do roller monitoring and reset. 
                    if (in_position == true)
                    {
                        while (reset == false)
                        {
                            switch (switch_case)
                            {
                                // if the car pulled in and is in proper loading position. 
                                case 0:
                                    if (carMoving == false)
                                    {
                                        carMoving = RollerMonitoring(SeaDACLite2_DeviceHandler, SeaDac2_Input, SeaDac2_Output);
                                    }
                                    else if (signsChanged == true && carMoving == true)
                                    {
                                        switch_case = 2;
                                        Thread.Sleep(50);
                                    }
                                    else
                                    {
                                        Thread.Sleep(100);
                                    }

                                    break; 
                                
                                // extra roller case 
                                // check if signs have been changed, if not change them. 
                                case 1:
                                    if (SD2_output2_signs == false)
                                    {
                                        signsChanged = ChangeSigns(SeaDACLite2_DeviceHandler, SeaDac2_Output);
                                    }
                                    else if (carMoving == false)
                                    {
                                        carMoving = RollerMonitoring(SeaDACLite2_DeviceHandler, SeaDac2_Input, SeaDac2_Output);
                                    }
                                    else if (signsChanged == true && carMoving == true)
                                    {
                                        switch_case = 2;
                                        Thread.Sleep(50);
                                    }
                                    else
                                    {
                                        Thread.Sleep(100);
                                    }

                                    break;
                                
                                // case for dealing with reset. 
                                case 2:
                                    while (reset == false)
                                    {
                                        reset = Reset(SeaDACLite1_DeviceHandler, SeaDACLite2_DeviceHandler, SeaDac1_Input, SeaDac2_Input, SeaDac1_Output, SeaDac2_Output);

                                        if (reset == false)
                                        {
                                            switch_case = 1;
                                            break; 
                                        }
                                    }

                                    break; 

                                default:
                                    Thread.Sleep(100);
                                    break;
                            }
                        }
                    }
                    Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Exception : {ex}");
            }
        }
    }
}