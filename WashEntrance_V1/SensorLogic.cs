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

        //SeaLevel Method 
        public static void SeaLevelTask()
        {
            #region Sealevel Device

            ///
            /// Open Sealevel Interface
            /// 

            //create the instance of the SeaMAX API   
            SeaMAX SeaMAX_DeviceHandler = new SeaMAX();
            byte[] SeaMAXData = new byte[1];
            byte[] SeaMaxOut = new byte[1];
            int errnum;

            //start of the main error handler section
            // The below try catch is just starting and connecting to the SeaLevel device
            try
            {
            //reference point for return on device disconnection
            RestartConnection:

                //Loop to handle load/reload of SeaLevel Device upon USB connect/disconnect
                do
                {
                    //open the connection 
                    int errno = SeaMAX_DeviceHandler.SM_Open("192.168.0.145");

                    //exit loop if device loads successfully
                    if (errno == 0)
                    {
                        Logger.WriteLog("Successfully Connected to SeaLevel Device");
                        break;
                    }

                    if (errno < 0)
                    {
                        // ERROR # -10070 IS A SOCKET ERROR 
                        // LOG AND RESTART SEALEVEL DEVICE!
                        switch (errno)
                        {
                            case -20:
                                //MessageBox.Show("SeaLevel Device Not Connected! ", "SeaLevel Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Logger.WriteLog($"Error # : {errno} - Ethernet - Could not resolve Host address.");
                                break;
                            case -21:
                                Logger.WriteLog($"Error # : {errno} - Ethernet - Host refused or unavailable.");
                                break;
                            case -22:
                                Logger.WriteLog($"Error # : {errno} - Ethernet - Could not acquire free socket.");
                                break;
                            default:
                                //MessageBox.Show("Sealevel Device Error Number: " + errno.ToString(), "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Logger.WriteLog($"Error # : {errno}");
                                break;
                        }
                    }
                    //thread sleep 5 seconds
                    Thread.Sleep(5000);
                } while (true);

                //set all outputs to off at initial load
                SeaMaxOut[0] = 0;
                errnum = SeaMAX_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaMaxOut);


                //Sealevel Device Active monitoring Loop
                do
                {
                    //handle closing Sealevel Handle on Exit
                    if (Form1.Shutdown)
                    {
                        //set all outputs to off at initial load
                        SeaMaxOut[0] = 0;
                        errnum = SeaMAX_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaMaxOut);

                        int errno = SeaMAX_DeviceHandler.SM_Close();
                        Logger.WriteLog($"Exiting Application - Killing thread {Thread.CurrentThread}");
                        Thread.Sleep(50);
                        Application.ExitThread();
                        break;
                    }
                    //read sealevel inputs status
                    errnum = SeaMAX_DeviceHandler.SM_ReadDigitalInputs(0, 4, SeaMAXData);

                    //handle sealevel device error
                    if (errnum < 0)
                    {
                        MessageBox.Show("Sealevel Device Error Number: " + errnum.ToString(), "Startup Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    //RollerCase
                    switch (RollerCase)
                    {
                        case 1:
                            //Wait for Roller Call signal from TunnelWatch + 24VAC Relay energized in TunnelWatch Box feeding power to fork circuit
                            if (SLInput1Status)
                            {
                                //change variables
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
                                //increment counter
                                RollerCounter = RollerCounter + 1;
                            }
                            break;

                        case 3:
                            //Wait for RollerReady Signal
                            if (RollerReady)
                            {
                                //check fork position and raise if necessary
                                if (!ForkUpBool)
                                {
                                    //Fork Up
                                    //configure Output control variable to set input 1 state to ON
                                    SeaMaxOut[0] = 1;

                                    //send output control command
                                    errnum = SeaMAX_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaMaxOut);
                                    ForkUpBool = true;
                                    // this is where voice will go if not wired into something different 
                                }
                                //change case
                                RollerCase = 4;
                            }
                            break;

                        case 4:
                            //Wait for change in RollerReady
                            if (!RollerReady)
                            {
                                //check if more rollers are armed
                                if (RollersLeft > 0)
                                {
                                    //adjust counters
                                    RollersUp = RollersUp + 1;
                                    RollersLeft = RollersLeft - 1;

                                    //change case
                                    RollerCase = 3;
                                }
                                else
                                {
                                    //Fork Down
                                    //set all outputs to off at initial load
                                    SeaMaxOut[0] = 0;
                                    errnum = SeaMAX_DeviceHandler.SM_WriteDigitalOutputs(0, 4, SeaMaxOut);
                                    ForkUpBool = false;
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
                            //end of roller control case select
                    }


                    //
                    //Roller Monitor Eye Management Section
                    //

                    //MonitorCase
                    //1 - waiting for roller monitor signal
                    //2 - debounce signal and if true arm RollerReady
                    //3 - pause and wait until roller is right at fork(based on timing)
                    //4 - Ensure that roller is past light(could still be in eye if conveyor is stopped) then disarm RollerReady and reset


                    //Monitor Case
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
                            //increment counter
                            MonitorCounter = MonitorCounter + 1;

                            //ensure roller is a true signal debounce ~50ms
                            if (MonitorCounter > 5)
                            {
                                //Ensure it is a positive trigger for a roller
                                if (SLInput4Status)
                                {
                                    //change case and reset counter
                                    MonitorCase = 3;
                                    MonitorCounter = 0;

                                    //Arm Roller Ready Boolean
                                    RollerReady = true;
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
