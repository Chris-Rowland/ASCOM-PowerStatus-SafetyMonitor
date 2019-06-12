//tabs=4
// --------------------------------------------------------------------------------
//
// ASCOM SafetyMonitor driver for PowerStatus
//
// Description:	This driver uses the System Information PowerStatus information to
//              set the safety state. Options are to check for mains power, battery low or
//              critical states, the percentage of battery power remaining or the battery
//              time remaining.
//
// Implements:	ASCOM SafetyMonitor interface version: <To be completed by driver developer>
// Author:		(CDR) Chris Rowland <chris.rowland@cherryfield.me.uk>
//
// Edit Log:
//
// Date			Who	Vers	Description
// -----------	---	-----	-------------------------------------------------------
// 11-Jun-2019	XXX	6.4.x	Initial edit, created from ASCOM driver template
// --------------------------------------------------------------------------------
//


// This is used to define code in the template that is specific to one class implementation
// unused code canbe deleted and this definition removed.
#define SafetyMonitor

using ASCOM.DeviceInterface;
using ASCOM.Utilities;
using System;
using System.Collections;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ASCOM.PowerStatus
{
    //
    // Your driver's DeviceID is ASCOM.PowerStatus.SafetyMonitor
    //
    // The Guid attribute sets the CLSID for ASCOM.PowerStatus.SafetyMonitor
    // The ClassInterface/None addribute prevents an empty interface called
    // _PowerStatus from being created and used as the [default] interface
    //
    //

    /// <summary>
    /// ASCOM SafetyMonitor Driver for PowerStatus.
    /// </summary>
    [Guid("1a114b34-66bd-49bb-b17a-7be602211a40")]
    [ClassInterface(ClassInterfaceType.None)]
    public class SafetyMonitor : ISafetyMonitor
    {
        /// <summary>
        /// ASCOM DeviceID (COM ProgID) for this driver.
        /// The DeviceID is used by ASCOM applications to load the driver at runtime.
        /// </summary>
        internal static string driverID = "ASCOM.PowerStatus.SafetyMonitor";
        // TODO Change the descriptive string for your driver then remove this line
        /// <summary>
        /// Driver description that displays in the ASCOM Chooser.
        /// </summary>
        private static string driverDescription = "PowerStatus SafetyMonitor Driver.";

        internal static string traceStateProfileName = "Trace Level";
        internal static string traceStateDefault = "false";

        /// <summary>
        /// Private variable to hold the connected state
        /// </summary>
        private bool connectedState;

        /// <summary>
        /// Variable to hold the trace logger object (creates a diagnostic log file with information that you specify)
        /// </summary>
        internal static TraceLogger tl;

        internal static bool usePowerStatus;
        internal static bool useBatteryLowOrCritical;
        internal static float minBatteryPercent;
        internal static int minBatteryLife;

        /// <summary>
        /// Initializes a new instance of the <see cref="PowerStatus"/> class.
        /// Must be public for COM registration.
        /// </summary>
        public SafetyMonitor()
        {
            tl = new TraceLogger("", "PowerStatus");
            ReadProfile(); // Read device configuration from the ASCOM Profile store

            tl.LogMessage("SafetyMonitor", "Starting initialisation");

            connectedState = false; // Initialise connected to false
            tl.LogMessage("SafetyMonitor", "Completed initialisation");
        }


        //
        // PUBLIC COM INTERFACE ISafetyMonitor IMPLEMENTATION
        //

        #region Common properties and methods.

        /// <summary>
        /// Displays the Setup Dialog form.
        /// If the user clicks the OK button to dismiss the form, then
        /// the new settings are saved, otherwise the old values are reloaded.
        /// THIS IS THE ONLY PLACE WHERE SHOWING USER INTERFACE IS ALLOWED!
        /// </summary>
        public void SetupDialog()
        {
            // consider only showing the setup dialog if not connected
            // or call a different dialog if connected
            //if (connectedState)
            //    System.Windows.Forms.MessageBox.Show("Already connected, just press OK");

            using (SetupDialogForm F = new SetupDialogForm())
            {
                var result = F.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    WriteProfile(); // Persist device configuration values to the ASCOM Profile store
                }
            }
        }

        public ArrayList SupportedActions
        {
            get
            {
                tl.LogMessage("SupportedActions Get", "Returning empty arraylist");
                return new ArrayList();
            }
        }

        public string Action(string actionName, string actionParameters)
        {
            LogMessage("", "Action {0}, parameters {1} not implemented", actionName, actionParameters);
            throw new ASCOM.ActionNotImplementedException("Action " + actionName + " is not implemented by this driver");
        }

        public void CommandBlind(string command, bool raw)
        {
            throw new ASCOM.MethodNotImplementedException("CommandBlind");
        }

        public bool CommandBool(string command, bool raw)
        {
            throw new ASCOM.MethodNotImplementedException("CommandBool");
        }

        public string CommandString(string command, bool raw)
        {
            throw new ASCOM.MethodNotImplementedException("CommandString");
        }

        public void Dispose()
        {
            // Clean up the tracelogger and util objects
            tl.Enabled = false;
            tl.Dispose();
            tl = null;
        }

        public bool Connected
        {
            get
            {
                //LogMessage("Connected", "Get {0}", IsConnected);
                return connectedState;
            }
            set
            {
                // all this does is set the connectedstate
                tl.LogMessage("Connected", "Set {0}", value);
                if (value == connectedState)
                    return;

                connectedState = value;
            }
        }

        public string Description
        {
            get
            {
                tl.LogMessage("Description Get", driverDescription);
                return driverDescription;
            }
        }

        public string DriverInfo
        {
            get
            {
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                // TODO customise this driver description
                string driverInfo = "PowerStatus SafetyMonitor, Version: " + String.Format(CultureInfo.InvariantCulture, "{0}.{1}", version.Major, version.Minor);
                tl.LogMessage("DriverInfo Get", driverInfo);
                return driverInfo;
            }
        }

        public string DriverVersion
        {
            get
            {
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                string driverVersion = String.Format(CultureInfo.InvariantCulture, "{0}.{1}", version.Major, version.Minor);
                tl.LogMessage("DriverVersion Get", driverVersion);
                return driverVersion;
            }
        }

        public short InterfaceVersion
        {
            // set by the driver wizard
            get
            {
                LogMessage("InterfaceVersion Get", "1");
                return Convert.ToInt16("1");
            }
        }

        public string Name
        {
            get
            {
                string name = "PowerStatus SafetyMonitor";
                tl.LogMessage("Name Get", name);
                return name;
            }
        }

        #endregion

        #region ISafetyMonitor Implementation

        public bool IsSafe
        {
            get
            {
                if (!connectedState)
                {
                    LogMessage("IsSafe", "not connected so IsSafe -> false");
                    return false;
                }
                var ps = SystemInformation.PowerStatus;
                LogMessage("IsSafe", "PowerLineStatus {0}, batteryChargeStatus {1}, BatteryFullLifetime {2},  BatteryLifePercent {3}, BatteryLifeRemaining {4}",
                    ps.PowerLineStatus, ps.BatteryChargeStatus, ps.BatteryFullLifetime, ps.BatteryLifePercent, ps.BatteryLifeRemaining);

                // make a series of decisions depending on the Power Status
                if (usePowerStatus && ps.PowerLineStatus == PowerLineStatus.Offline)
                    return false;       // not running on AC power

                // these ignore the charging status, when charging they will return false until there is sufficient charge.
                if (useBatteryLowOrCritical && (ps.BatteryChargeStatus.HasFlag(BatteryChargeStatus.Critical) || ps.BatteryChargeStatus.HasFlag(BatteryChargeStatus.Low)))
                    return false;       // low or critical battery status
                if (ps.BatteryLifePercent >= 0 && ps.BatteryLifePercent < minBatteryPercent / 100)
                    return false;       // battery life percent less than 80%
                if (ps.BatteryLifeRemaining >= 0 && ps.BatteryLifeRemaining < minBatteryLife * 60)
                    return false;       // less than 10 minutes, unknown (-1) is true

                // all is well
                return true;
            }
        }

        #endregion

        #region Private properties and methods
        // here are some useful properties and methods that can be used as required
        // to help with driver development

        #region ASCOM Registration

        // Register or unregister driver for ASCOM. This is harmless if already
        // registered or unregistered. 
        //
        /// <summary>
        /// Register or unregister the driver with the ASCOM Platform.
        /// This is harmless if the driver is already registered/unregistered.
        /// </summary>
        /// <param name="bRegister">If <c>true</c>, registers the driver, otherwise unregisters it.</param>
        private static void RegUnregASCOM(bool bRegister)
        {
            using (var P = new ASCOM.Utilities.Profile())
            {
                P.DeviceType = "SafetyMonitor";
                if (bRegister)
                {
                    P.Register(driverID, driverDescription);
                }
                else
                {
                    P.Unregister(driverID);
                }
            }
        }

        /// <summary>
        /// This function registers the driver with the ASCOM Chooser and
        /// is called automatically whenever this class is registered for COM Interop.
        /// </summary>
        /// <param name="t">Type of the class being registered, not used.</param>
        /// <remarks>
        /// This method typically runs in two distinct situations:
        /// <list type="numbered">
        /// <item>
        /// In Visual Studio, when the project is successfully built.
        /// For this to work correctly, the option <c>Register for COM Interop</c>
        /// must be enabled in the project settings.
        /// </item>
        /// <item>During setup, when the installer registers the assembly for COM Interop.</item>
        /// </list>
        /// This technique should mean that it is never necessary to manually register a driver with ASCOM.
        /// </remarks>
        [ComRegisterFunction]
        public static void RegisterASCOM(Type t)
        {
            RegUnregASCOM(true);
        }

        /// <summary>
        /// This function unregisters the driver from the ASCOM Chooser and
        /// is called automatically whenever this class is unregistered from COM Interop.
        /// </summary>
        /// <param name="t">Type of the class being registered, not used.</param>
        /// <remarks>
        /// This method typically runs in two distinct situations:
        /// <list type="numbered">
        /// <item>
        /// In Visual Studio, when the project is cleaned or prior to rebuilding.
        /// For this to work correctly, the option <c>Register for COM Interop</c>
        /// must be enabled in the project settings.
        /// </item>
        /// <item>During uninstall, when the installer unregisters the assembly from COM Interop.</item>
        /// </list>
        /// This technique should mean that it is never necessary to manually unregister a driver from ASCOM.
        /// </remarks>
        [ComUnregisterFunction]
        public static void UnregisterASCOM(Type t)
        {
            RegUnregASCOM(false);
        }

        #endregion

        /// <summary>
        /// Read the device configuration from the ASCOM Profile store
        /// </summary>
        internal void ReadProfile()
        {
            using (Profile driverProfile = new Profile())
            {
                driverProfile.DeviceType = "SafetyMonitor";
                tl.Enabled = Convert.ToBoolean(driverProfile.GetValue(driverID, traceStateProfileName, string.Empty, traceStateDefault));
                usePowerStatus = Convert.ToBoolean(driverProfile.GetValue(driverID, "UsePowerStatus", string.Empty, bool.FalseString));
                useBatteryLowOrCritical = Convert.ToBoolean(driverProfile.GetValue(driverID, "UseBatteryLowOrCritical", string.Empty, bool.TrueString));
                minBatteryPercent = (float)Convert.ToDouble(driverProfile.GetValue(driverID, "MinBatteryPercent", string.Empty, "80"));
                minBatteryLife = Convert.ToInt32(driverProfile.GetValue(driverID, "MinBatteryLife", string.Empty, "10"));
            }
        }

        /// <summary>
        /// Write the device configuration to the  ASCOM  Profile store
        /// </summary>
        internal void WriteProfile()
        {
            using (Profile driverProfile = new Profile())
            {
                driverProfile.DeviceType = "SafetyMonitor";
                driverProfile.WriteValue(driverID, traceStateProfileName, tl.Enabled.ToString());
                driverProfile.WriteValue(driverID, "UsePowerStatus", usePowerStatus.ToString());
                driverProfile.WriteValue(driverID, "UseBatteryLowOrCritical", useBatteryLowOrCritical.ToString());
                driverProfile.WriteValue(driverID, "MinBatteryPercent", minBatteryPercent.ToString());
                driverProfile.WriteValue(driverID, "MinBatteryLife", minBatteryLife.ToString());
            }
        }

        /// <summary>
        /// Log helper function that takes formatted strings and arguments
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        internal static void LogMessage(string identifier, string message, params object[] args)
        {
            var msg = string.Format(message, args);
            tl.LogMessage(identifier, msg);
        }
        #endregion
    }
}
