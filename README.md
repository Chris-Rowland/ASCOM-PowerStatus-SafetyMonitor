# ASCOM-PowerStatus-SafetyMonitor

This is an ASCOM driver that implements the Safety Monitor functionality using the .NET SystemInformation.PowerStatus class.
Computers with a battery - laptops - use this to keep track of the mains and battery states.
The driver checks a combination of the LinePower, BatteryStatus, Battery percent remaining and battery time remaning parameters and
sets the ASCOM SafetyMonitor.IsSafe property to false when any one of the limits is exceeded.  The user can set the limits as required.

This will be useful for people with observatories who wish to monitor the power state so that their application software can initiate
a close down, rendering the obseevatory safe, when there is a power failure.

It doesn't seem to work with systems with a UPS because the UPSs don't seem to use the same class to report the power state.

The code should build on a system using Visual Studio 2013 or better.  It also needs Inno setup.  See the ASCOM developer's documentation
for details on using these and the ASCOM driver development process.

Chris Rowland, June 2019
