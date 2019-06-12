namespace ASCOM.PowerStatus
{
    partial class SetupDialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.picASCOM = new System.Windows.Forms.PictureBox();
            this.chkTrace = new System.Windows.Forms.CheckBox();
            this.labelMinBatteryPercent = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxUsePowerStatus = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBoxUseBatteryLowOrCritical = new System.Windows.Forms.CheckBox();
            this.numericUpDownMinBatteryPercent = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMinBatteryLife = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelPowerLineStatus = new System.Windows.Forms.Label();
            this.labelBatteryChargeStatus = new System.Windows.Forms.Label();
            this.labelBatteryLifePercent = new System.Windows.Forms.Label();
            this.labelBatteryLifeRemaining = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.labelIsSafe = new System.Windows.Forms.Label();
            this.buttonHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinBatteryPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinBatteryLife)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(325, 211);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(59, 24);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.toolTip1.SetToolTip(this.cmdOK, "Saves the current settings and closes the dialog");
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(325, 241);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(59, 25);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.toolTip1.SetToolTip(this.cmdCancel, "Closes the dialog without saving the settings");
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // picASCOM
            // 
            this.picASCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picASCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picASCOM.Image = global::ASCOM.PowerStatus.Properties.Resources.ASCOM;
            this.picASCOM.Location = new System.Drawing.Point(336, 9);
            this.picASCOM.Name = "picASCOM";
            this.picASCOM.Size = new System.Drawing.Size(48, 56);
            this.picASCOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picASCOM.TabIndex = 3;
            this.picASCOM.TabStop = false;
            this.picASCOM.Click += new System.EventHandler(this.BrowseToAscom);
            this.picASCOM.DoubleClick += new System.EventHandler(this.BrowseToAscom);
            // 
            // chkTrace
            // 
            this.chkTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTrace.AutoSize = true;
            this.chkTrace.Location = new System.Drawing.Point(16, 246);
            this.chkTrace.Name = "chkTrace";
            this.chkTrace.Size = new System.Drawing.Size(69, 17);
            this.chkTrace.TabIndex = 6;
            this.chkTrace.Text = "Trace on";
            this.toolTip1.SetToolTip(this.chkTrace, "Check to save log data to file\r\nDocuments\\ASCOM\\PowerStatus.<time>.<number>.txt\r\n" +
        "");
            this.chkTrace.UseVisualStyleBackColor = true;
            // 
            // labelMinBatteryPercent
            // 
            this.labelMinBatteryPercent.AutoSize = true;
            this.labelMinBatteryPercent.Location = new System.Drawing.Point(68, 73);
            this.labelMinBatteryPercent.Name = "labelMinBatteryPercent";
            this.labelMinBatteryPercent.Size = new System.Drawing.Size(128, 13);
            this.labelMinBatteryPercent.TabIndex = 9;
            this.labelMinBatteryPercent.Text = "Min. Battery Life (percent)";
            this.toolTip1.SetToolTip(this.labelMinBatteryPercent, "Report unsafe if the battery life percentage is less than this.");
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(102, 247);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(99, 13);
            this.labelVersion.TabIndex = 13;
            this.labelVersion.Text = "Version: 0.0.0000.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Set the properties and values used to set the state to unsafe";
            // 
            // checkBoxUsePowerStatus
            // 
            this.checkBoxUsePowerStatus.AutoSize = true;
            this.checkBoxUsePowerStatus.Location = new System.Drawing.Point(16, 25);
            this.checkBoxUsePowerStatus.Name = "checkBoxUsePowerStatus";
            this.checkBoxUsePowerStatus.Size = new System.Drawing.Size(158, 17);
            this.checkBoxUsePowerStatus.TabIndex = 15;
            this.checkBoxUsePowerStatus.Text = "Unsafe if mains power  is off";
            this.toolTip1.SetToolTip(this.checkBoxUsePowerStatus, "Check to report unsafe when a laptop is running on battery power.\r\n");
            this.checkBoxUsePowerStatus.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseBatteryLowOrCritical
            // 
            this.checkBoxUseBatteryLowOrCritical.AutoSize = true;
            this.checkBoxUseBatteryLowOrCritical.Location = new System.Drawing.Point(16, 48);
            this.checkBoxUseBatteryLowOrCritical.Name = "checkBoxUseBatteryLowOrCritical";
            this.checkBoxUseBatteryLowOrCritical.Size = new System.Drawing.Size(211, 17);
            this.checkBoxUseBatteryLowOrCritical.TabIndex = 16;
            this.checkBoxUseBatteryLowOrCritical.Text = "Unsafe if Battery Status is low or critical";
            this.toolTip1.SetToolTip(this.checkBoxUseBatteryLowOrCritical, "Check to report unsafe if the battery status is Low or Critical.\r\nIt is recommend" +
        "ed to leave this checked because failure will be\r\nimminent in these states.");
            this.checkBoxUseBatteryLowOrCritical.UseVisualStyleBackColor = true;
            // 
            // numericUpDownMinBatteryPercent
            // 
            this.numericUpDownMinBatteryPercent.Location = new System.Drawing.Point(16, 71);
            this.numericUpDownMinBatteryPercent.Name = "numericUpDownMinBatteryPercent";
            this.numericUpDownMinBatteryPercent.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownMinBatteryPercent.TabIndex = 17;
            this.numericUpDownMinBatteryPercent.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // numericUpDownMinBatteryLife
            // 
            this.numericUpDownMinBatteryLife.Location = new System.Drawing.Point(16, 101);
            this.numericUpDownMinBatteryLife.Name = "numericUpDownMinBatteryLife";
            this.numericUpDownMinBatteryLife.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownMinBatteryLife.TabIndex = 19;
            this.numericUpDownMinBatteryLife.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Min. Battery Life (mins)";
            this.toolTip1.SetToolTip(this.label2, "Repot unsafe if the remaining battery life in minutes is less than this.");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.55405F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.44595F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelPowerLineStatus, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelBatteryChargeStatus, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelBatteryLifePercent, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelBatteryLifeRemaining, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 154);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(296, 80);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Power Line Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Battery Life (percent)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Battery Life (mins)";
            // 
            // labelPowerLineStatus
            // 
            this.labelPowerLineStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPowerLineStatus.Location = new System.Drawing.Point(126, 0);
            this.labelPowerLineStatus.Name = "labelPowerLineStatus";
            this.labelPowerLineStatus.Size = new System.Drawing.Size(167, 20);
            this.labelPowerLineStatus.TabIndex = 4;
            // 
            // labelBatteryChargeStatus
            // 
            this.labelBatteryChargeStatus.AutoSize = true;
            this.labelBatteryChargeStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBatteryChargeStatus.Location = new System.Drawing.Point(126, 20);
            this.labelBatteryChargeStatus.Name = "labelBatteryChargeStatus";
            this.labelBatteryChargeStatus.Size = new System.Drawing.Size(167, 20);
            this.labelBatteryChargeStatus.TabIndex = 5;
            this.labelBatteryChargeStatus.Text = "label8";
            // 
            // labelBatteryLifePercent
            // 
            this.labelBatteryLifePercent.AutoSize = true;
            this.labelBatteryLifePercent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBatteryLifePercent.Location = new System.Drawing.Point(126, 40);
            this.labelBatteryLifePercent.Name = "labelBatteryLifePercent";
            this.labelBatteryLifePercent.Size = new System.Drawing.Size(167, 20);
            this.labelBatteryLifePercent.TabIndex = 6;
            this.labelBatteryLifePercent.Text = "label9";
            // 
            // labelBatteryLifeRemaining
            // 
            this.labelBatteryLifeRemaining.AutoSize = true;
            this.labelBatteryLifeRemaining.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBatteryLifeRemaining.Location = new System.Drawing.Point(126, 60);
            this.labelBatteryLifeRemaining.Name = "labelBatteryLifeRemaining";
            this.labelBatteryLifeRemaining.Size = new System.Drawing.Size(167, 20);
            this.labelBatteryLifeRemaining.TabIndex = 7;
            this.labelBatteryLifeRemaining.Text = "label10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Battery Charge Status";
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Current Power Status values";
            // 
            // labelIsSafe
            // 
            this.labelIsSafe.AutoSize = true;
            this.labelIsSafe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIsSafe.ForeColor = System.Drawing.Color.LimeGreen;
            this.labelIsSafe.Location = new System.Drawing.Point(191, 138);
            this.labelIsSafe.Name = "labelIsSafe";
            this.labelIsSafe.Size = new System.Drawing.Size(47, 13);
            this.labelIsSafe.TabIndex = 22;
            this.labelIsSafe.Text = "Is Safe";
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(325, 181);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(59, 24);
            this.buttonHelp.TabIndex = 23;
            this.buttonHelp.Text = "Help";
            this.toolTip1.SetToolTip(this.buttonHelp, "Click to show the help document");
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // SetupDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 274);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.labelIsSafe);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.numericUpDownMinBatteryLife);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownMinBatteryPercent);
            this.Controls.Add(this.checkBoxUseBatteryLowOrCritical);
            this.Controls.Add(this.checkBoxUsePowerStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelMinBatteryPercent);
            this.Controls.Add(this.chkTrace);
            this.Controls.Add(this.picASCOM);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupDialogForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PowerStatus Safety Setup";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.SetupDialogForm_HelpButtonClicked);
            this.Load += new System.EventHandler(this.SetupDialogForm_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.SetupDialogForm_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinBatteryPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinBatteryLife)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.PictureBox picASCOM;
        private System.Windows.Forms.CheckBox chkTrace;
        private System.Windows.Forms.Label labelMinBatteryPercent;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxUsePowerStatus;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBoxUseBatteryLowOrCritical;
        private System.Windows.Forms.NumericUpDown numericUpDownMinBatteryPercent;
        private System.Windows.Forms.NumericUpDown numericUpDownMinBatteryLife;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelPowerLineStatus;
        private System.Windows.Forms.Label labelBatteryChargeStatus;
        private System.Windows.Forms.Label labelBatteryLifePercent;
        private System.Windows.Forms.Label labelBatteryLifeRemaining;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelIsSafe;
        private System.Windows.Forms.Button buttonHelp;
    }
}