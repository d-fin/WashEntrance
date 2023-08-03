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

        public static bool SD1_input1_pgmCar = false;  // program car - 24 VAC
        public static bool SD1_input2_pgmCarButton = false; // extra roller button inside store - 24VAC
        public static bool SD1_input3_resetSigns = false; // reset flag / hold - 24VAC

        // outputs are Form C Relays, voltage output is 10-24 VDC from common, except fork solenoid is 120VAC
        public static bool SD2_output1_audio = false; // audio
        public static bool SD2_output2_signs = false; // stop sign & go sign (N/O = closed, N/C = go)
        public static bool SD2_output3_forkSolenoid = false; // fork solenoid


        // Non-device related variables

        private static bool carProgrammed = false;
        private static bool in_position = false;
        private static bool extraRollerBtn = false;
        private static bool reset = false;
        private static bool carMoving = false;
        private static bool signsChanged = false;

        private const int SLEEP_DURATION_MS = 100;
        private const int DEBOUNCE_MS = 50;
        private static readonly object lockObj = new object();


        /*
         GetBit converts input, a byte array, to booleans
         */
        private static bool GetBit(this byte b, int bitNumber)
        {
            return (b & (1 << bitNumber)) != 0;
        }

        private static bool SeaDACLiteConnect(SeaMAX SeaMAX_DeviceHandler)
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

        private static bool isDetectedBySonar(SeaMAX SeaDac_DeviceHandler, byte[] input)
        {
            try
            {
                int err;
                int sonarCount = 0;

                while (sonarCount < 50)
                {
                    err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(0, 1, input);
                    SD2_input1_sonar = GetBit(input[0], 0);

                    if (SD2_input1_sonar == true)
                    {
                        sonarCount++;
                        Thread.Sleep(DEBOUNCE_MS);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Logger.WriteLog($"isDetectedBySonar() - Exception {e}");
                return false;
            }

            return true;
        }

        private static bool isDetectedByTireEye(SeaMAX SeadDac_DeviceHandler, byte[] input)
        {
            try
            {
                int err = SeadDac_DeviceHandler.SM_ReadDigitalInputs(1, 1, input);
                SD2_input2_tireEye = GetBit(input[0], 1);

                if (SD2_input2_tireEye == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Logger.WriteLog($"isDetectedByTireEye() - Exception {e}");
                return false;
            }
        }

        private static bool CarInPosition(SeaMAX SeaDac_DeviceHandler, byte[] input)
        {
            try
            {
                bool inSonar = false;
                bool inTireEye = false;

                while (inSonar == false)
                {
                    inSonar = isDetectedBySonar(SeaDac_DeviceHandler, input);
                }

                Thread.Sleep(SLEEP_DURATION_MS * 10);

                while (inTireEye == false)
                {
                    inTireEye = isDetectedByTireEye(SeaDac_DeviceHandler, input);
                }

                if (inSonar == true && inTireEye == true)
                {
                    return true;
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
        }

        private static bool RollerMonitoring(SeaMAX SeaDac_DeviceHandler, byte[] input, byte[] output)
        {
            try
            {
                int err;
                int rollerCounter = 0;
                bool success = false;
                output[0] = 1;

                while (!success)
                {
                    while (true)
                    {
                        err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(2, 1, input);
                        SD2_input3_rollerEye = GetBit(input[0], 2);

                        if (SD2_input3_rollerEye == true)
                        {
                            err = SeaDac_DeviceHandler.SM_WriteDigitalOutputs(2, 1, output);
                            if (err < 0)
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
                    err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(2, 1, input);
                    SD2_input3_rollerEye = GetBit(input[0], 2);

                    if (SD2_input3_rollerEye == true)
                    {
                        SD2_input3_rollerEye = false;
                        rollerCounter++;
                        Thread.Sleep(SLEEP_DURATION_MS * 10);

                        if (rollerCounter == 2)
                        {
                            while (true)
                            {
                                err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(2, 1, input);
                                SD2_input3_rollerEye = GetBit(input[0], 2);

                                if (SD2_input3_rollerEye == true)
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

        private static bool Reset(SeaMAX SeaDac1_DeviceHandler, SeaMAX SeaDac2_DeviceHandler, byte[] input1, byte[] input2, byte[] output1, byte[] output2)
        {
            try
            {
                int err;

                while (true)
                {
                    
                    err = SeaDac1_DeviceHandler.SM_ReadDigitalInputs(1, 2, input1);
                    LogErrorInput(err, "Reset");
               
                    SD1_input3_resetSigns = GetBit(input1[0], 2);

                    lock (lockObj)
                    {
                        SD1_input2_pgmCarButton = GetBit(input1[0], 1);

                    }

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
                }
            }
            catch (Exception e)
            {
                Logger.WriteLog($"Reset() - Exception: {e}");
                return false;
            }
        }

        private static void LogErrorInput(int err, string function)
        {
            if (err < 0)
            {
                Logger.WriteLog($"{function}() - SM_ReadDigitalInputs() error code: {err}");
            }
        }

        private static void LogErrorOutput(int err, string function)
        {
            if (err < 0)
            {
                Logger.WriteLog($"{function} - SM_ReadDigitalOutputs() error code: {err}");
            }
        }

        private static bool ChangeSigns(SeaMAX SeaDac_DeviceHandler, byte[] output)
        {
            try
            {
                output[0] = 1;

                if (SeaDac_DeviceHandler.SM_WriteDigitalOutputs(0, 1, output) > 0)
                {
                    SD2_output1_audio = true;
                    SD2_output2_signs = true;

                    Thread.Sleep(100);

                    output[0] = 0;
                    SeaDac_DeviceHandler.SM_WriteDigitalOutputs(1, 1, output);
                    SD2_output1_audio = false;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Exception : {ex}");
                return false;
            }

            return true;
        }

        private static void MonitorExtraRollerBtn(SeaMAX SeaDac_DeviceHandler)
        {
            int err;
            byte[] input = new byte[1];

            while (true)
            {
                err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(1, 1, input);

                lock (lockObj)
                {
                    SD1_input2_pgmCarButton = GetBit(input[0], 1);
                }

                Thread.Sleep(SLEEP_DURATION_MS);
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
                seaDAC1 = SeaDACLiteConnect(SeaDACLite1_DeviceHandler);
                seaDAC2 = SeaDACLiteConnect(SeaDACLite2_DeviceHandler);
                if (seaDAC1 && seaDAC2)
                {
                    break;
                }
            }

            Thread extraRollerButton = new Thread(() => MonitorExtraRollerBtn(SeaDACLite1_DeviceHandler));
            extraRollerButton.Start();

            try
            {
                SeaDac2_Output[0] = 0;
                SeaDac1_Output[0] = 0;
                err = SeaDACLite2_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaDac2_Output);
                err = SeaDACLite1_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaDac1_Output);

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

                        Thread.Sleep(50);
                        Application.ExitThread();
                        break;
                    }

                    // check to see if a car is in the proper loading position. 
                    while (true)
                    {
                        if (CarInPosition(SeaDACLite1_DeviceHandler, SeaDac1_Input) == true)
                        {
                            in_position = true;
                            switch_case = 0;

                            if (signsChanged == false)
                            {
                                signsChanged = ChangeSigns(SeaDACLite2_DeviceHandler, SeaDac2_Output);
                            }

                            break; 
                        }
                        else
                        {
                            err = SeaDACLite1_DeviceHandler.SM_ReadDigitalInputs(1, 1, SeaDac2_Input);

                            lock (lockObj)
                            {
                                SD1_input2_pgmCarButton = GetBit(SeaDac1_Input[0], 1);
                            }

                            if (SD1_input2_pgmCarButton == true)
                            {
                                in_position = true;
                                switch_case = 0;

                                if (SD2_output2_signs == false)
                                {
                                    signsChanged = ChangeSigns(SeaDACLite2_DeviceHandler, SeaDac2_Output);
                                }

                                break;
                            }
                          
                            Thread.Sleep(SLEEP_DURATION_MS);
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
                                        switch_case = 1;
                                        Thread.Sleep(SLEEP_DURATION_MS);
                                    }
                                    else
                                    {
                                        Thread.Sleep(SLEEP_DURATION_MS);
                                    }

                                    break;

                                // case for dealing with reset. 
                                case 1:
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
                                    Thread.Sleep(SLEEP_DURATION_MS);
                                    break;
                            }
                        }
                    }

                    Thread.Sleep(SLEEP_DURATION_MS * 20);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Exception : {ex}");
            }
        }
    }
}