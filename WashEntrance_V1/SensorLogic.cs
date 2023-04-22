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
        public static bool SLInput1Status = false;
        public static bool SLInput2Status = false;
        public static bool SLInput3Status = false;
        public static bool SLInput4Status = false;

        public static int RollerCounter = 0;
        public static int VoiceCounter = 0;
        public static int RollerCase = 1;

        public static int ExtraRollCase = 1;
        public static int RollersLeft = 0;
        public static int RollersUp = 0;
        public static bool ForkUpBool = false;
        public static int ExtraRollerCounter = 0;
        public static bool RollerReady = false;
        public static int MonitorCounter = 0;
        public static int MonitorCase = 1;
        public static bool CarPgm = false;

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
            catch(Exception e)
            {
                Logger.WriteLog($"SeaDAC Lite connection failed. Exception: {e}");
                return false;
            }

            return true;
        }

        //Start SeaLevel Device
        public static bool SeaConnect370Connect(SeaMAX SeaMAX_DeviceHandler)
        {
            try
            {
                do
                {
                    int errno = SeaMAX_DeviceHandler.SM_Open("192.168.1.176");

                    //exit loop if device loads successfully
                    if (errno == 0)
                    {
                        Logger.WriteLog("Successfully Connected to SeaConnect 370");
                        break;
                    }

                    if (errno < 0)
                    {
                        switch (errno)
                        {
                            case -20:
                                Logger.WriteLog($"SeaConnect 370 Error # : {errno} - Ethernet - Could not resolve Host address. (IP Address incorrect)");
                                break;
                            case -21:
                                Logger.WriteLog($"SeaConnect 370 Error # : {errno} - Ethernet - Host refused or unavailable. SeaLevel Device Restart Required.");
                                break;
                            case -22:
                                Logger.WriteLog($"SeaConnect 370 Error # : {errno} - Ethernet - Could not acquire free socket.");
                                break;
                            default:
                                Logger.WriteLog($"SeaConnect 370 Error # : {errno}");
                                break;
                        }
                    }
                    Thread.Sleep(5000);
                } while (true);
            }
            catch(Exception e)
            {
                Logger.WriteLog($"SeaConnect 370 connection failed. Exception: {e}");
                return false;  
            }

            return true; 
        }

        // Main SeaLevel Task
        public static void SeaLevelTask()
        {
            #region Sealevel Device

            ///
            /// Open Sealevel Interface
            /// 

            //create the instance of the SeaMAX API for SeaConnect 370  
            SeaMAX SeaConnect370_DeviceHandler = new SeaMAX();
            byte[] SeaMAXData = new byte[1];
            byte[] SeaMaxOut = new byte[1];

            //create the instance of the SeaMAX API for SeaDAC Lite 
            SeaMAX SeaDACLite_DeviceHandler = new SeaMAX();
            byte[] SeaDACData = new byte[1];
            byte[] SeaDACOut = new byte[1];

            int errnum;

            //start of the main error handler section
            // The below try catch is just starting and connecting to the SeaLevel device
            try
            {
            //reference point for return on device disconnection
            RestartConnection:

                while(true)
                {
                    // make sure SeaDAC Lite is connected if not, keep trying to connect
                    bool SeaDAC = SeaDACLiteConnect(SeaDACLite_DeviceHandler);
                    bool SeaConnect = SeaConnect370Connect(SeaConnect370_DeviceHandler);
                    if (SeaDAC && SeaConnect) { break; }
                }
                
                //set all outputs to off at initial load
                SeaMaxOut[0] = 0;
                errnum = SeaConnect370_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaMaxOut);

                //Sealevel Device Active monitoring Loop
                do
                {
                    // check if SeaDAC Lite has input, the function will constantly monitor for input. 
                    // on input change function has a delay parameter (use to ignore input x amount of time)
                    if (SeaDACLite_DeviceHandler.SM_NotifyOnInputChange(0, 4, SeaDACData, 0, 0) == 0)
                    {
                        Logger.WriteLog("SeaDAC Input changed");
                        errnum = SeaDACLite_DeviceHandler.SM_ReadDigitalInputs(0, 4, SeaDACData);
                        bool SeaDacInput1Status = GetBit(SeaDACData[0], 0);
                    }
                    
                   
                    // close device and exit 
                    if (Form1.Shutdown)
                    {
                        //set all outputs to off at initial load
                        SeaMaxOut[0] = 0;
                        errnum = SeaConnect370_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaMaxOut);

                        int errno = SeaConnect370_DeviceHandler.SM_Close();
                        int err = SeaDACLite_DeviceHandler.SM_Close();
                        Logger.WriteLog($"Killing thread - {Thread.CurrentThread}\nSeaConnect370 Error # : {errno}\nSeaDAC Lite Error # :  {err}");
                        Thread.Sleep(50);
                        Application.ExitThread();
                        break;
                    }
                    //read sealevel inputs status
                    errnum = SeaConnect370_DeviceHandler.SM_ReadDigitalInputs(0, 4, SeaMAXData);

                    //handle sealevel device error
                    if (errnum < 0)
                    {
                        Logger.WriteLog($"SeaLevel Device Error {errnum}");
                        break;
                    }

                    //convert input data values to booleans
                    SLInput1Status = GetBit(SeaMAXData[0], 0);
                    SLInput2Status = GetBit(SeaMAXData[0], 1);
                    SLInput3Status = GetBit(SeaMAXData[0], 2);
                    SLInput4Status = GetBit(SeaMAXData[0], 3);


                    /*
                    //Roller Control section
                    //'''''

                    'RollerCase
                    '1 - waiting for roller call
                    '2 - false trigger debounce pause
                    '3 - wait for RollerReady
                    '4 - wait for Roller to reach fork (RollerReady = False) then change case based on roller count
                    '5 - Fork Down/waiting for roller call off or extra roller input
                     * 
                     */

                    switch (RollerCase)
                    {
                        case 1:
                            //Wait for Roller Call signal from TunnelWatch + 24VAC Relay energized in TunnelWatch Box feeding power to fork circuit
                            if (SLInput1Status)
                            {
                                RollerCase = 2;
                                RollerCounter = 0;
                            }
                            break;
                        case 2:
                            //debounce roller call input to ensure no false triggering ~100ms
                            if (RollerCounter > 10)
                            {
                                //change variables based on roller call input
                                if (SLInput1Status)
                                {
                                    //positive trigger signal, set variables and change case
                                    RollerCase = 3;
                                    RollersLeft = 2;
                                    RollersUp = 0;

                                    //set Car Programmed boolean to True
                                    CarPgm = true;
                                }
                                else
                                {
                                    //false trigger so reset 
                                    RollerCase = 1;
                                }
                            }
                            else
                            {
                                RollerCounter = RollerCounter + 1;
                            }
                            break;
                        case 3:
                            if (RollerReady)
                            {
                                //check fork position and raise if necessary
                                if (!ForkUpBool)
                                {
                                    //Fork Up
                                    //configure Output control variable to set input 1 state to ON
                                    SeaMaxOut[0] = 1;

                                    //send output control command
                                    errnum = SeaConnect370_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaMaxOut);
                                    ForkUpBool = true;
                                    Logger.WriteLog("Fork Up");
                                    // this is where voice will go if not wired into something different 
                                }
                                RollerCase = 4;
                            }
                            break;
                        case 4:
                            if (!RollerReady)
                            {
                                //check if more rollers are armed
                                if (RollersLeft > 0)
                                {
                                    //adjust counters
                                    RollersUp = RollersUp + 1;
                                    RollersLeft = RollersLeft - 1;
                                    RollerCase = 3;
                                }
                                else
                                {
                                    //Fork Down
                                    //set all outputs to off at initial load
                                    SeaMaxOut[0] = 0;
                                    errnum = SeaConnect370_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaMaxOut);
                                    ForkUpBool = false;
                                    Logger.WriteLog("Fork Down");
                                    RollerCase = 5;
                                }
                            }
                            break;

                        case 5:
                            //Wait for TunnelWatch to signal Roller Down then return to start of cycle
                            if (!SLInput1Status)
                            {
                                RollerCase = 1;
                            }
                            break;
                    }


                    //
                    //Roller Monitor Eye Management Section
                    //
                    // The switch case below monitors how many rollers to send then drops fork when completed 
                    // or is cancelled. 
                    //1 - waiting for roller monitor signal
                    //2 - debounce signal and if true arm RollerReady
                    //3 - pause and wait until roller is right at fork(based on timing)
                    //4 - Ensure that roller is past light(could still be in eye if conveyor is stopped) then disarm RollerReady and reset

                    switch (MonitorCase)
                    {
                        case 1:
                            //Wait for Roller Monitor Light Signal (Roller in position just before fork)
                            if (SLInput4Status)
                            {
                                MonitorCase = 2;
                                MonitorCounter = 0;
                            }
                            break;

                        case 2:
                            MonitorCounter = MonitorCounter + 1;

                            //ensure roller is a true signal debounce ~50ms
                            if (MonitorCounter > 5)
                            {
                                //Ensure it is a positive trigger for a roller
                                if (SLInput4Status)
                                {
                                    MonitorCase = 3;
                                    MonitorCounter = 0;

                                    //Arm Roller Ready Boolean
                                    RollerReady = true;
                                    Logger.WriteLog("Roller Ready");
                                }
                                else
                                {
                                    //false trigger, reset
                                    MonitorCase = 1;
                                }
                            }
                            break;

                        case 3:
                            //debounce input thru pause to ensure that the off wasn't a hole in roller (ensure that the roller is past eye before looking again) ~500ms
                            //allow rollerready to stay armed for 500ms in case there is a roller call with a roller right in position  Roller time to bad fork position is about 1100ms
                            MonitorCounter = MonitorCounter + 1;

                            if (MonitorCounter > 50)
                            {
                                MonitorCase = 4;
                            }
                            break;

                        case 4:
                            //Ensure Roller is past Eye before resetting Case
                            if (!SLInput4Status)
                            {
                                MonitorCase = 5;
                                MonitorCounter = 0;

                                //Disarm Roller Ready Boolean
                                RollerReady = false;
                                Logger.WriteLog("Roller Not Ready");
                            }
                            break;

                        case 5:
                            //debounce input after off as well in case of bouncing and to ensure roller travel ~500ms
                            MonitorCounter = MonitorCounter + 1;

                            if (MonitorCounter > 50)
                            {
                                MonitorCase = 1;
                            }
                            break;
                    }

                    //thread sleep for 10ms this is counter length approx.
                    Thread.Sleep(10);
                } while (true);

                //thread sleep 5 seconds
                Thread.Sleep(5000);

                //redirect code to connection restart loop as usb is unplugged
                goto RestartConnection;

            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Exception : {ex}");
                //MessageBox.Show("Sealevel Device Error: " + ex.Message, "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
