﻿using Sealevel;
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

        // Devices connected
        public static bool seaDAC1 = false;
        public static bool seaDAC2 = false;

        // inputs
        public static bool SD2_input1_sonar = false;  // sonar - 24VDC
        public static bool SD2_input2_tireEye = false;  // tire eye - 24VDC 
        public static bool SD2_input3_rollerEye = false;  // roller eye - 24VDC 

        //public static bool SD1_input1_pgmCar = false;  // program car - 24 VAC NO LONGER BEING USED
        public static bool SD1_input1_pgmCarTW = false; 
        public static bool SD1_input2_pgmCarButton = false; // extra roller button inside store - 24VAC
        public static bool SD1_input3_resetSigns = false; // reset flag / hold - 24VAC
        public static bool SD1_input4_is_Service = false; // only program a car if SW is sending a service to TW 


        // outputs (Form C Relays)
        public static bool SD2_output1_audio = false; // audio
        public static bool SD2_output2_signs = false; // stop sign & go sign (N/O = closed, N/C = go)
        public static bool SD2_output3_forkSolenoid = false; // fork solenoid

        public static bool SD1_output4_requestCar = false; // 24VDC

        // Non-device related variables
        private static bool in_position = false;
        private static bool reset = false;
        private static bool carMoving = false;
        private static bool signsChanged = false;

        // Thread.Sleep() durations.
        private const int SLEEP_DURATION_MS = 100;
        private const int DEBOUNCE_MS = 50;

        // lock objects used for multithreading. 
        private static readonly object lockObj_extraRollerBtn = new object();
        private static readonly object lockObj_Reset = new object();
        private static readonly object lockObj_isConnected = new object();
        private static bool endThreads = false;
        private static bool resetTriggered = false;
        private static bool exiting = false;


        private static Dictionary<int, string> readInputErrorCodes = new Dictionary<int, string>
        {
            { -1, "Invalid SeaMAX Handle." },
            { -20, "SeaDAC Lite: Invalid model number." },
            { -21, "SeaDAC Lite: Invalid addressing." },
            { -22, "SeaDAC Lite: Error reading the device." }
        };

        private static Dictionary<int, string> writeOutputErrorCodes = new Dictionary<int, string>
        {
            { -1, "Invalid SeaMAX handle." },
            { -20, "SeaDAC Lite: Invalid model number." },
            { -21, "SeaDAC Lite: Invalid addressing." },
            { -22, "SeaDAC Lite: Error writing to the device." }
        };

        /*
            GetBit converts input, a byte array, to booleans
         */
        public static bool GetBit(this byte b, int bitNumber)
        {
            return (b & (1 << bitNumber)) != 0;
        }

        /*
            Function made to read the digital inputs then return a specific inputs state. 
        */
        private static bool ReadInputs(SeaMAX SeaDac_DeviceHandler, int inputNum)
        {
            byte[] input = new byte[1];
            Dictionary<int, bool> inputDict = new Dictionary<int, bool>();

            int err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(0, 4, input);
            LogErrorInput(err, "ReadInputs");

            inputDict.Add(1, GetBit(input[0], 0));
            inputDict.Add(2, GetBit(input[0], 1));
            inputDict.Add(3, GetBit(input[0], 2));
            inputDict.Add(4, GetBit(input[0], 3));

            return inputDict[inputNum];
        }

        /*
            Connect to the SeaDAC Lite Devices. 
        */
        private static bool SeaDACLiteConnect(SeaMAX SeaMAX_DeviceHandler)
        {
            try
            {

                int errno = SeaMAX_DeviceHandler.SM_Open("SeaDAC Lite 0");
                if (errno == 0)
                {
                    Logger.WriteLog("Successfully Connected to SeaDAC Lite 0");
                    return true;
                }

                else if (errno < 0)
                {
                    switch (errno)
                    {
                        case -1:
                            Logger.WriteLog($"SeaDAC Lite Error # : {errno} - Parameter Connection is null. ");
                            break;
                        case -2:
                            Logger.WriteLog($"SeaDAC Lite Error # : {errno} - Could not determine connection type.");
                            break;
                        case -3:
                            Logger.WriteLog($"SeaDAC Lite Error # : {errno} - Invalid connection string.");
                            break;
                        case -30:
                            Logger.WriteLog($"SeaDAC Lite Error # : {errno} - SeaDAC Lite: Invalid or unavailable port.");
                            break;
                        case -31:
                            Logger.WriteLog($"SeaDAC Lite Error # : {errno} - SeaDAC Lite: Unable to acquire a valid mutex handle.");
                            break;
                        case -32:
                            Logger.WriteLog($"SeaDAC Lite Error # : {errno} - SeaDAC Lite: Invalid device number (should be zero or greater). Object invalid.");
                            break;
                        case -33:
                            Logger.WriteLog($"SeaDAC Lite Error # : {errno} - SeaDAC Lite: Could not read vendor ID.");
                            break;
                        case -34:
                            Logger.WriteLog($"SeaDAC Lite Error # : {errno} - SeaDAC Lite: Could not read Product ID.");
                            break;
                        default:
                            Logger.WriteLog($"SeaDAC Lite Error # : {errno}");
                            break;
                    }
                }
                return false; 
            }
            catch (Exception e)
            {
                Logger.WriteLog($"SeaDAC Lite connection failed. Exception: {e}");
                return false;
            }
        }

        /*
            Check if a vehicle is in the sonar - SeaDAC device # 2, input 1.
            
            return true if detected else return false. 
        */
        private static bool isDetectedBySonar(SeaMAX SeaDac_DeviceHandler, byte[] input)
        {
            try
            {
                int err;

                err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(0, 1, input);
                LogErrorInput(err, "isDetectedBySonar");
                SD2_input1_sonar = GetBit(input[0], 0);

                if (SD2_input1_sonar == true)
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
                Logger.WriteLog($"isDetectedBySonar() - Exception {e}");
                return false;
            }
        }

        /*
            Check if vehicle has tripped the tire eye - SeaDAC device # 2, input 2.
            
            return true if detected else false. 
        */
        public static bool isDetectedByTireEye(SeaMAX SeadDac_DeviceHandler, byte[] input)
        {
            try
            {
                int err = SeadDac_DeviceHandler.SM_ReadDigitalInputs(0, 2, input);
                LogErrorInput(err, "isDetectedByTireEye");
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

        /*
            This function is called to determine if the vehicle is in the proper loading position. 
            
            proper loading position is: Sonar is tripped and tire eye is tripped. 
                                        The sonar has to be tripped first before the tire eye, the sonar detects front of vehicle and the tire 
                                            eye detects rear tire.

            return true if in proper loading position else false. 
        */
        public static bool CarInPosition(SeaMAX SeaDac_DeviceHandler, byte[] input)
        {
            try
            {
                bool inSonar = false;
                bool inTireEye = false;

                inSonar = isDetectedBySonar(SeaDac_DeviceHandler, input);
                Thread.Sleep(SLEEP_DURATION_MS);
                inTireEye = isDetectedByTireEye(SeaDac_DeviceHandler, input);

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

        /*
            RollerMonitoring uses the roller eye to determine if rollers are safe and ready to be lifted. 

            Steps: 
                1. Lift fork when a roller is in the tire eye. - the tire eye is 2 feet before door, only lift fork when you know there is not a roller there (prevents jams).
                2. Once fork is lifted, leave up until two rollers are outputted. 
                3. Lower fork when the roller eye senses third roller, again to prevent jams. 
        */
        public static bool RollerMonitoring(SeaMAX SeaDac_DeviceHandler, byte[] input, byte[] output)
        {
            int rollerCounter = 0;
            bool success = false;
            output[0] = 1;
            int err;

            try
            {
                while (!success)
                {
                    while (true)
                    {
                        err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(0, 4, input);
                        LogErrorInput(err, "RollerMonitoring");

                        bool one = GetBit(input[0], 0);
                        bool two = GetBit(input[0], 1);
                        bool three = GetBit(input[0], 2);
                        bool four = GetBit(input[0], 3);

                        if (three == true)
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
                    err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(0, 4, input);
                    LogErrorInput(err, "RollerMonitoring");

                    bool one = GetBit(input[0], 0);
                    bool two = GetBit(input[0], 1);
                    bool three = GetBit(input[0], 2);
                    bool four = GetBit(input[0], 3);

                    if (three == true)
                    {
                        three = false;
                        rollerCounter++;
                        Thread.Sleep(SLEEP_DURATION_MS * 13);
                        if (rollerCounter == 2)
                        {
                            while (true)
                            {
                                err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(0, 4, input);
                                LogErrorInput(err, "RollerMonitoring");

                                three = GetBit(input[0], 2);

                                if (three == true)
                                {
                                    output[0] = 0;
                                    err = SeaDac_DeviceHandler.SM_WriteDigitalOutputs(2, 1, output);
                                    LogErrorOutput(err, "RollerMonitoring");

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

        /*
            Reset waits for a flag from the TunnelWatch Box. The reset is triggered 4 feet after the front of the vehicle trips the head switch.
            Once the flag is triggered, all variables are reset and all form C relays are turned off. (means a vehicle may pull in now that the vehicle in front is safely moving through wash). 
        */
        private static bool Reset(SeaMAX SeaDac2_DeviceHandler)
        {
            try
            {
                byte[] output = new byte[1];
                Thread.Sleep(SLEEP_DURATION_MS * 10);

                output[0] = 0;

                int err = SeaDac2_DeviceHandler.SM_WriteDigitalOutputs(0, 4, output);
                LogErrorOutput(err, "Reset");

                in_position = false;
                //SD1_input1_pgmCar = false;
                SD1_input2_pgmCarButton = false;
                SD1_input3_resetSigns = false;
                //SD1_input4_is_Service = false; 
                SD2_input1_sonar = false;
                SD2_input2_tireEye = false;
                SD2_input3_rollerEye = false;
                SD2_output2_signs = false;
                SD2_output1_audio = false;
                SD2_output3_forkSolenoid = false;
                carMoving = false;
                in_position = false;
                signsChanged = false;

                return true;
            }
            catch (Exception e)
            {
                Logger.WriteLog($"Reset() - Exception: {e}");
                return false;
            }

        }

        private static void LogErrorInput(int err, string function)
        {
            try 
            { 
                if (err < 0)
                {
                    if (readInputErrorCodes.TryGetValue(err, out string errorMessage))
                    {
                        Logger.WriteLog($"{function}() - SM_ReadDigitalInputs() error code: {err}, error message: {errorMessage}");
                    }
                    else
                    {
                        Logger.WriteLog($"{function}() - SM_ReadDigitalInputs() error code: {err}");
                    }
                }
            }
            catch (Exception) { }
        }

        private static void LogErrorOutput(int err, string function)
        {
            try
            {
                if (err < 0)
                {
                    if (writeOutputErrorCodes.TryGetValue(err, out string errorMessage))
                    {
                        Logger.WriteLog($"{function} - SM_WriteDigitalOutputs() error code: {err}, error message: {errorMessage}");
                    }
                    else
                    {
                        Logger.WriteLog($"{function} - SM_WriteDigitalOutputs() error code: {err}");
                    }
                }
            }
            catch (Exception) { }
            
        }

        private static void Log(string message)
        {
            Logger.WriteLog(message);
        }

        /*
            Changes the "Please Pull Forward" sign to "Stop Car in Neutral". 
            Also plays Audio. 

            output 1 to audio then sleep for 100MS then output 0 or else it will loop the audio. 
        */
        private static bool ChangeSigns(SeaMAX SeaDac_DeviceHandler, byte[] output)
        {
            try
            {
                output[0] = 1;
                int err;

                err = SeaDac_DeviceHandler.SM_WriteDigitalOutputs(0, 1, output);
                LogErrorOutput(err, "ChangeSigns");
                err = SeaDac_DeviceHandler.SM_WriteDigitalOutputs(1, 1, output);
                LogErrorOutput(err, "ChangeSigns");

                if (err >= 0)
                {
                    SD2_output1_audio = true;
                    SD2_output2_signs = true;

                    Thread.Sleep(SLEEP_DURATION_MS);

                    output[0] = 0;
                    SeaDac_DeviceHandler.SM_WriteDigitalOutputs(0, 1, output);
                    LogErrorOutput(err, "ChangeSigns");
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

        /*
            Monitor extra roller button. This is a manual button pressed by an employee. 
            
            If the button is pressed then there was an issue where the vehicle didn't program through getting in the proper laoding position. 
            Generally used for user error. 
        */
        private static void MonitorExtraRollerBtn(SeaMAX SeaDac_DeviceHandler)
        {
            byte[] input = new byte[1];

            while (endThreads == false)
            {
                int err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(0, 4, input);
                LogErrorInput(err, "MonitorExtraRollerBtn");
                lock (lockObj_extraRollerBtn)
                {
                    SD1_input1_pgmCarTW = GetBit(input[0], 0);
                    if (SD1_input1_pgmCarTW == true)
                    {
                        SD1_input2_pgmCarButton = true;
                        Log("Extra Roller from TW");
                    }

                    SD1_input2_pgmCarButton = GetBit(input[0], 1);
                }

                Thread.Sleep(SLEEP_DURATION_MS);
            }
        }

        /*
            Used to look for the reset flag. 
            
            Converted this to a thread because of user error. If a user drove to far into the headswitch the reset flag would trigger too early, 
                causing an infinite loop. 
        */
        private static void MonitorReset(SeaMAX SeaDac_DeviceHandler)
        {
            byte[] input = new byte[1];

            while (endThreads == false)
            {
                int err = SeaDac_DeviceHandler.SM_ReadDigitalInputs(0, 4, input);
                LogErrorInput(err, "MonitorReset");

                lock (lockObj_Reset)
                {
                    SD1_input3_resetSigns = GetBit(input[0], 2);
                    if (SD1_input3_resetSigns == true)
                    {
                        resetTriggered = true;
                    }
                }
            }
        }

        /*
            Monitor to make sure the SeaDAC devices are constantly connected, if not then reconnect.  
        */
        private static void MonitorSeaDACConnection(SeaMAX SeaDacLite1_DeviceHandler, SeaMAX SeaDacLite2_DeviceHandler)
        {
            try
            {
                lock (lockObj_isConnected)
                {
                    if (!seaDAC1)
                    {
                        seaDAC1 = SeaDACLiteConnect(SeaDacLite1_DeviceHandler);
                    }
                    else if (!seaDAC2)
                    {
                        seaDAC2 = SeaDACLiteConnect(SeaDacLite2_DeviceHandler);
                    }
                    else
                    {
                        Thread.Sleep(SLEEP_DURATION_MS * 20);
                    }
                }
            }
            catch (Exception e)
            {
                Logger.WriteLog($"MonitorSeaDACConnection() - Exception {e}");
            }
        }

        private static void ExitThreads(SeaMAX SD1_DeviceHandler, SeaMAX SD2_DeviceHandler, Thread extraRollerButton, Thread resetMonitor)
        {
            byte[] output = new byte[1];
            int err;
            output[0] = 0;

            try
            {
                bool reset = Reset(SD2_DeviceHandler);
                endThreads = true;
                exiting = true;
                err = SD2_DeviceHandler.SM_WriteDigitalOutputs(0, 4, output);
                LogErrorOutput(err, "SeaLevelThread");
            
                err = SD1_DeviceHandler.SM_WriteDigitalOutputs(0, 4, output);
                LogErrorOutput(err, "SeaLevelThread");

                err = SD1_DeviceHandler.SM_Close();
                if (err == 0)
                {
                    Logger.WriteLog($"SeaDAC Lite 1 Closed succesfully.");
                    seaDAC1 = false; 
                }
                else 
                {
                    Logger.WriteLog($"Error closing SeaDAC Lite 1");
                }
            
                err = SD2_DeviceHandler.SM_Close();
                if (err == 0)
                {
                    Logger.WriteLog($"SeaDAC Lite 2 Closed succesfully.");
                    seaDAC2 = false; 
                }
                else 
                {
                    Logger.WriteLog($"Error closing SeaDAC Lite 2");
                }

                Logger.WriteLog("Attempting to end extra roller and reset threads....");

                bool threadsJoined = false; 
                while (threadsJoined == false)
                {
                    if (extraRollerButton.ThreadState == ThreadState.Stopped && resetMonitor.ThreadState == ThreadState.Stopped)
                    {
                        Logger.LogThreadTermination(resetMonitor);
                        Logger.LogThreadTermination(extraRollerButton);
                        bool x = extraRollerButton.Join(500);
                        bool y = resetMonitor.Join(500);
                        if (x == true && y == true)
                        {
                            threadsJoined = true;
                            Logger.WriteLog("extra roller and reset threads joined.");
                        }
                        else if (x == true)
                        {
                            Logger.WriteLog("extra roller thread joined.");
                        }
                        else if (y == true)
                        {
                            Logger.WriteLog("reset thread joined.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Exit Threads Exception - {ex}");
            }
        }

        /*
            Main thread that houses all of the sensor logic.  
        */
        public static void SeaLevelTask()
        {
            // local variables 
            SeaMAX SD1_DeviceHandler = new SeaMAX();
            SeaMAX SD2_DeviceHandler = new SeaMAX();

            byte[] input = new byte[1];
            byte[] output = new byte[1];

            int switch_case = -1;
            int err;
            exiting = false; 
            endThreads = false;

            while (true)
            {
                seaDAC1 = SeaDACLiteConnect(SD1_DeviceHandler);
                seaDAC2 = SeaDACLiteConnect(SD2_DeviceHandler);
               
                if (seaDAC1 && seaDAC2)
                {
                    break;
                }
                else if (Form1.Shutdown == true)
                {
                    Application.Exit();
                }
            }

            /*
                Threads below are used for monitoring the extra roller button, looking for the reset flag from TW box, and making sure the SeaDACs are always connected. 
            */

            Thread extraRollerButton = new Thread(() => MonitorExtraRollerBtn(SD1_DeviceHandler));
            Thread resetMonitor = new Thread(() => MonitorReset(SD1_DeviceHandler));

            extraRollerButton.Start();
            resetMonitor.Start();

            extraRollerButton.Name = "ExtraRollerBtnThread";
            resetMonitor.Name = "MonitorResetThread";

            Logger.LogThreadCreation(extraRollerButton);
            Logger.LogThreadCreation(resetMonitor);


            try
            {
                output[0] = 0;
                err = SD2_DeviceHandler.SM_WriteDigitalOutputs(0, 4, output);
                LogErrorOutput(err, "SeaLevelThread");
                err = SD1_DeviceHandler.SM_WriteDigitalOutputs(0, 4, output);
                LogErrorOutput(err, "SeaLevelThread");

                while (exiting == false)
                {
                    switch_case = -1;
                    reset = false;
                    resetTriggered = false;

                    if (Form1.Shutdown == true || Form1.testing == true)
                    {
                        ExitThreads(SD1_DeviceHandler, SD2_DeviceHandler, extraRollerButton, resetMonitor);
                    }

                    if (!seaDAC1 || !seaDAC2)
                    {
                        while (true)
                        {
                            seaDAC1 = SeaDACLiteConnect(SD1_DeviceHandler);
                            seaDAC2 = SeaDACLiteConnect(SD2_DeviceHandler);
                            if (seaDAC1 && seaDAC2)
                            {
                                break;
                            }
                        }
                    }

                    // check to see if a car is in the proper loading position. 
                    while (exiting == false)
                    {
                        bool reqCar = false;
                        bool manualPgm = false;

                        err = SD2_DeviceHandler.SM_ReadDigitalInputs(0, 2, input);
                        LogErrorOutput(err, "SeaLevelThread");
                        reqCar = GetBit(input[0], 1);

                        lock (lockObj_extraRollerBtn)
                        {
                            if (SD1_input2_pgmCarButton == true)
                            {
                                reqCar = true;
                                manualPgm = true;
                                SD1_input2_pgmCarButton = false;
                            }
                        }

                        if (Form1.Shutdown == true || Form1.testing == true || Form1.resetButton == true)
                        {
                            ExitThreads(SD1_DeviceHandler, SD2_DeviceHandler, extraRollerButton, resetMonitor);
                        }

                        // here is where im going to want to add the isService var to make sure there is an actual service. 
                        if (reqCar == true)
                        {
                            while (true)
                            {
                               
                                output[0] = 1;
                                err = SD1_DeviceHandler.SM_WriteDigitalOutputs(3, 1, output);
                                LogErrorOutput(err, "SeaLevelThread");
                                
                                lock (lockObj_extraRollerBtn)
                                {
                                    if (SD1_input2_pgmCarButton == true)
                                    {
                                        manualPgm = true;
                                        Log("Extra Roller Sent");
                                    }
                                }

                                if (CarInPosition(SD2_DeviceHandler, input) == true)
                                {
                                    in_position = true;
                                    switch_case = 0;
                                    Thread.Sleep(SLEEP_DURATION_MS * 2);
                                    break;
                                }
                                else if (manualPgm == true)
                                {
                                    in_position = true;
                                    switch_case = 0;
                                    Thread.Sleep(SLEEP_DURATION_MS * 2);
                                    break;
                                }
                                else if (Form1.Shutdown == true || Form1.testing == true || Form1.resetButton == true)
                                {
                                    break;
                                }
                            }

                            break;
                        }
                    }

                    // if the car is in the proper loading position (or extra roller is sent) do roller monitoring and reset. 
                    if (in_position == true)
                    {
                        while (reset == false)
                        {
                            lock (lockObj_extraRollerBtn)
                            {
                                if (SD1_input2_pgmCarButton == true)
                                {
                                    carMoving = false;
                                    SD1_input2_pgmCarButton = false;
                                    switch_case = 0;
                                }
                            }

                            if (SD2_output2_signs == false)
                            {
                                signsChanged = ChangeSigns(SD2_DeviceHandler, output);
                                Thread.Sleep(SLEEP_DURATION_MS * 20);
                            }

                            if (Form1.Shutdown == true || Form1.resetButton == true)
                            {
                                break;
                            }

                            switch (switch_case)
                            {
                                case 0:
                                    if (carMoving == false)
                                    {
                                        carMoving = RollerMonitoring(SD2_DeviceHandler, input, output);
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

                                case 1:
                                    output[0] = 0;
                                    err = SD1_DeviceHandler.SM_WriteDigitalOutputs(3, 1, output);
                                    LogErrorOutput(err, "SeaLevelThread");

                                    if (resetTriggered == true)
                                    {
                                        reset = Reset(SD2_DeviceHandler);
                                    }

                                    lock (lockObj_extraRollerBtn)
                                    {
                                        if (SD1_input2_pgmCarButton == true)
                                        {
                                            SD1_input2_pgmCarButton = false;
                                            carMoving = false;
                                            switch_case = 0;
                                        }
                                    }
                                    break;

                                default:
                                    Thread.Sleep(SLEEP_DURATION_MS);
                                    break;
                            }
                        }
                    }
                    Thread.Sleep(SLEEP_DURATION_MS * 50);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Exception : {ex}");
            }
        }
    }
}