using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ASCOM.PowerStatus
{
    [ComVisible(false)]					// Form not registered for COM!
    public partial class SetupDialogForm : Form
    {
        public SetupDialogForm()
        {
            InitializeComponent();
            // Initialise current values of user settings from the ASCOM Profile
            InitUI();
        }

        private void cmdOK_Click(object sender, EventArgs e) // OK button event handler
        {
            // Update the state variables with results from the dialogue
            SafetyMonitor.usePowerStatus = checkBoxUsePowerStatus.Checked;
            SafetyMonitor.useBatteryLowOrCritical = checkBoxUseBatteryLowOrCritical.Checked;
            SafetyMonitor.minBatteryPercent = (float)numericUpDownMinBatteryPercent.Value;
            SafetyMonitor.minBatteryLife = (int)numericUpDownMinBatteryLife.Value;

            SafetyMonitor.tl.Enabled = chkTrace.Checked;
            timer1.Enabled = false;
        }

        private void cmdCancel_Click(object sender, EventArgs e) // Cancel button event handler
        {
            Close();
        }

        private void BrowseToAscom(object sender, EventArgs e) // Click on ASCOM logo event handler
        {
            try
            {
                System.Diagnostics.Process.Start("http://ascom-standards.org/");
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void InitUI()
        {
            // set up UI
            chkTrace.Checked = SafetyMonitor.tl.Enabled;
            checkBoxUsePowerStatus.Checked = SafetyMonitor.usePowerStatus;
            checkBoxUseBatteryLowOrCritical.Checked = SafetyMonitor.useBatteryLowOrCritical;
            numericUpDownMinBatteryPercent.Value = (decimal)SafetyMonitor.minBatteryPercent;
            numericUpDownMinBatteryLife.Value = SafetyMonitor.minBatteryLife;
            timer1.Enabled = true;

            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var ps = SystemInformation.PowerStatus;
            labelPowerLineStatus.Text = ps.PowerLineStatus.ToString();
            labelBatteryChargeStatus.Text = ps.BatteryChargeStatus.ToString();
            labelBatteryLifePercent.Text = (ps.BatteryLifePercent * 100).ToString();
            labelBatteryLifeRemaining.Text = ps.BatteryLifeRemaining == -1 ? "unknown" : (ps.BatteryLifeRemaining / 60).ToString();

            bool isSafe = true;
            // make a series of decisions depending on the Power Status
            if (checkBoxUsePowerStatus.Checked && ps.PowerLineStatus == PowerLineStatus.Offline)
                isSafe = false;       // not running on AC power

            // these ignore the charging status, when charging they will return false until there is sufficient charge.
            if (checkBoxUseBatteryLowOrCritical.Checked && (ps.BatteryChargeStatus.HasFlag(BatteryChargeStatus.Critical) || ps.BatteryChargeStatus.HasFlag(BatteryChargeStatus.Low)))
                isSafe = false;       // low or critical battery status
            if (ps.BatteryLifePercent >= 0 && ps.BatteryLifePercent < (float)numericUpDownMinBatteryPercent.Value / 100)
                isSafe = false;       // battery life percent less than 80%
            if (ps.BatteryLifeRemaining >= 0 && ps.BatteryLifeRemaining < numericUpDownMinBatteryLife.Value * 60)
                isSafe = false;       // less than 10 minutes, unknown (-1) is true

            if (isSafe)
            {
                labelIsSafe.Text = "Safe";
                labelIsSafe.ForeColor = System.Drawing.Color.LimeGreen;
            }
            else
            {
                labelIsSafe.Text = "Unsafe";
                labelIsSafe.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            try
            {
                System.Reflection.Assembly assem = System.Reflection.Assembly.GetExecutingAssembly();
                var loc = Path.GetDirectoryName(assem.Location);
                // shell the help file
                System.Diagnostics.Process.Start(Path.Combine(loc, "PowerStatusHelp.pdf"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to show help file PowerStatusHelp.pdf, error: " + ex.ToString());
            }
        }

        private void SetupDialogForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            buttonHelp_Click(sender, null);
        }

        private void SetupDialogForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            buttonHelp_Click(sender, null);
        }

        private void SetupDialogForm_Load(object sender, EventArgs e)
        {
            // forces the window to the front
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

    }
}