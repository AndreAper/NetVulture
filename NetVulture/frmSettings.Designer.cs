namespace NetVulture
{
    partial class frmSettings
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
            this._tbxOutputDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._btnSelectDir = new System.Windows.Forms.Button();
            this._btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._tbxInterval = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._gbxEmailSettings = new System.Windows.Forms.GroupBox();
            this._chkBxEmailAlertingEnabled = new System.Windows.Forms.CheckBox();
            this._tbxMailServerPort = new System.Windows.Forms.TextBox();
            this._tbxMailPassword = new System.Windows.Forms.TextBox();
            this._tbxTargetAddresses = new System.Windows.Forms.TextBox();
            this._tbxMailServer = new System.Windows.Forms.TextBox();
            this._btnSendTestMail = new System.Windows.Forms.Button();
            this._tbxMailUser = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this._chkBxDailySummeryEnabled = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this._dtpSendSummeryTime = new System.Windows.Forms.DateTimePicker();
            this._lnkLblCopyHeader = new System.Windows.Forms.LinkLabel();
            this._rtbxCsvHeader = new System.Windows.Forms.RichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this._tbxBatchlistCsvPath = new System.Windows.Forms.TextBox();
            this._chkBxEnableAutoImportBatchlist = new System.Windows.Forms.CheckBox();
            this._btnSelectBatchlistCsv = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rBtnSmtp = new System.Windows.Forms.RadioButton();
            this.rBtnOutlook = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this._gbxEmailSettings.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tbxOutputDir
            // 
            this._tbxOutputDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxOutputDir.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this._tbxOutputDir.Location = new System.Drawing.Point(157, 22);
            this._tbxOutputDir.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbxOutputDir.Name = "_tbxOutputDir";
            this._tbxOutputDir.Size = new System.Drawing.Size(302, 25);
            this._tbxOutputDir.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Output Directory";
            // 
            // _btnSelectDir
            // 
            this._btnSelectDir.BackColor = System.Drawing.Color.Gainsboro;
            this._btnSelectDir.FlatAppearance.BorderSize = 0;
            this._btnSelectDir.Location = new System.Drawing.Point(464, 21);
            this._btnSelectDir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnSelectDir.Name = "_btnSelectDir";
            this._btnSelectDir.Size = new System.Drawing.Size(34, 26);
            this._btnSelectDir.TabIndex = 4;
            this._btnSelectDir.Text = "...";
            this._btnSelectDir.UseVisualStyleBackColor = false;
            this._btnSelectDir.Click += new System.EventHandler(this._btnSelectDir_Click);
            // 
            // _btnClose
            // 
            this._btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnClose.Location = new System.Drawing.Point(630, 593);
            this._btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(113, 30);
            this._btnClose.TabIndex = 9999999;
            this._btnClose.Text = "Close";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this._btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.Location = new System.Drawing.Point(5, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Collect Interval";
            // 
            // _tbxInterval
            // 
            this._tbxInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxInterval.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this._tbxInterval.Location = new System.Drawing.Point(102, 20);
            this._tbxInterval.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbxInterval.Name = "_tbxInterval";
            this._tbxInterval.Size = new System.Drawing.Size(81, 25);
            this._tbxInterval.TabIndex = 20;
            this._tbxInterval.Text = "60000";
            this._tbxInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._tbxOutputDir);
            this.groupBox1.Controls.Add(this._btnSelectDir);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(507, 57);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data output";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._tbxInterval);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(525, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(218, 57);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Timer";
            // 
            // _gbxEmailSettings
            // 
            this._gbxEmailSettings.Controls.Add(this.rBtnOutlook);
            this._gbxEmailSettings.Controls.Add(this.rBtnSmtp);
            this._gbxEmailSettings.Controls.Add(this._chkBxEmailAlertingEnabled);
            this._gbxEmailSettings.Controls.Add(this._tbxMailServerPort);
            this._gbxEmailSettings.Controls.Add(this._tbxMailPassword);
            this._gbxEmailSettings.Controls.Add(this._tbxTargetAddresses);
            this._gbxEmailSettings.Controls.Add(this._tbxMailServer);
            this._gbxEmailSettings.Controls.Add(this._btnSendTestMail);
            this._gbxEmailSettings.Controls.Add(this._tbxMailUser);
            this._gbxEmailSettings.Controls.Add(this.label6);
            this._gbxEmailSettings.Controls.Add(this.label12);
            this._gbxEmailSettings.Controls.Add(this.label5);
            this._gbxEmailSettings.Controls.Add(this.label13);
            this._gbxEmailSettings.Controls.Add(this.label4);
            this._gbxEmailSettings.Controls.Add(this.label10);
            this._gbxEmailSettings.Controls.Add(this.label11);
            this._gbxEmailSettings.Location = new System.Drawing.Point(12, 167);
            this._gbxEmailSettings.Name = "_gbxEmailSettings";
            this._gbxEmailSettings.Size = new System.Drawing.Size(731, 221);
            this._gbxEmailSettings.TabIndex = 8;
            this._gbxEmailSettings.TabStop = false;
            this._gbxEmailSettings.Text = "E-mail Alerting";
            // 
            // _chkBxEmailAlertingEnabled
            // 
            this._chkBxEmailAlertingEnabled.AutoSize = true;
            this._chkBxEmailAlertingEnabled.Location = new System.Drawing.Point(11, 24);
            this._chkBxEmailAlertingEnabled.Name = "_chkBxEmailAlertingEnabled";
            this._chkBxEmailAlertingEnabled.Size = new System.Drawing.Size(74, 21);
            this._chkBxEmailAlertingEnabled.TabIndex = 50;
            this._chkBxEmailAlertingEnabled.Text = "Enabled";
            this._chkBxEmailAlertingEnabled.UseVisualStyleBackColor = true;
            this._chkBxEmailAlertingEnabled.CheckedChanged += new System.EventHandler(this._chkBxEmailAlertingEnabled_CheckedChanged);
            // 
            // _tbxMailServerPort
            // 
            this._tbxMailServerPort.Enabled = false;
            this._tbxMailServerPort.Location = new System.Drawing.Point(418, 76);
            this._tbxMailServerPort.Name = "_tbxMailServerPort";
            this._tbxMailServerPort.Size = new System.Drawing.Size(63, 25);
            this._tbxMailServerPort.TabIndex = 100;
            // 
            // _tbxMailPassword
            // 
            this._tbxMailPassword.Enabled = false;
            this._tbxMailPassword.Location = new System.Drawing.Point(418, 107);
            this._tbxMailPassword.Name = "_tbxMailPassword";
            this._tbxMailPassword.PasswordChar = '#';
            this._tbxMailPassword.Size = new System.Drawing.Size(169, 25);
            this._tbxMailPassword.TabIndex = 90;
            // 
            // _tbxTargetAddresses
            // 
            this._tbxTargetAddresses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxTargetAddresses.Enabled = false;
            this._tbxTargetAddresses.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this._tbxTargetAddresses.Location = new System.Drawing.Point(157, 138);
            this._tbxTargetAddresses.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbxTargetAddresses.Multiline = true;
            this._tbxTargetAddresses.Name = "_tbxTargetAddresses";
            this._tbxTargetAddresses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._tbxTargetAddresses.Size = new System.Drawing.Size(250, 70);
            this._tbxTargetAddresses.TabIndex = 60;
            // 
            // _tbxMailServer
            // 
            this._tbxMailServer.Enabled = false;
            this._tbxMailServer.Location = new System.Drawing.Point(157, 76);
            this._tbxMailServer.Name = "_tbxMailServer";
            this._tbxMailServer.Size = new System.Drawing.Size(169, 25);
            this._tbxMailServer.TabIndex = 100;
            // 
            // _btnSendTestMail
            // 
            this._btnSendTestMail.Enabled = false;
            this._btnSendTestMail.Location = new System.Drawing.Point(418, 138);
            this._btnSendTestMail.Name = "_btnSendTestMail";
            this._btnSendTestMail.Size = new System.Drawing.Size(169, 32);
            this._btnSendTestMail.TabIndex = 120;
            this._btnSendTestMail.Text = "Send Test Mail";
            this._btnSendTestMail.UseVisualStyleBackColor = true;
            this._btnSendTestMail.Click += new System.EventHandler(this._btnSendTestMail_Click);
            // 
            // _tbxMailUser
            // 
            this._tbxMailUser.Enabled = false;
            this._tbxMailUser.Location = new System.Drawing.Point(157, 107);
            this._tbxMailUser.Name = "_tbxMailUser";
            this._tbxMailUser.Size = new System.Drawing.Size(169, 25);
            this._tbxMailUser.TabIndex = 80;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label12.Location = new System.Drawing.Point(8, 79);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 17);
            this.label12.TabIndex = 2;
            this.label12.Text = "Server Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(10, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "One address per line";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label13.Location = new System.Drawing.Point(337, 79);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 17);
            this.label13.TabIndex = 2;
            this.label13.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label4.Location = new System.Drawing.Point(8, 138);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Target addresses";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label10.Location = new System.Drawing.Point(8, 110);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "User";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label11.Location = new System.Drawing.Point(337, 110);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 17);
            this.label11.TabIndex = 2;
            this.label11.Text = "Password";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this._chkBxDailySummeryEnabled);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this._dtpSendSummeryTime);
            this.groupBox3.Location = new System.Drawing.Point(12, 77);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(731, 84);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Daily Summery";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label18.Location = new System.Drawing.Point(154, 25);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(538, 17);
            this.label18.TabIndex = 15;
            this.label18.Text = "NOTE: To send daily reports you need to configure mail service in the alerting se" +
    "rvice area.";
            // 
            // _chkBxDailySummeryEnabled
            // 
            this._chkBxDailySummeryEnabled.AutoSize = true;
            this._chkBxDailySummeryEnabled.Location = new System.Drawing.Point(11, 24);
            this._chkBxDailySummeryEnabled.Name = "_chkBxDailySummeryEnabled";
            this._chkBxDailySummeryEnabled.Size = new System.Drawing.Size(74, 21);
            this._chkBxDailySummeryEnabled.TabIndex = 3;
            this._chkBxDailySummeryEnabled.Text = "Enabled";
            this._chkBxDailySummeryEnabled.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label17.Location = new System.Drawing.Point(8, 55);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 17);
            this.label17.TabIndex = 2;
            this.label17.Text = "Time";
            // 
            // _dtpSendSummeryTime
            // 
            this._dtpSendSummeryTime.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this._dtpSendSummeryTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this._dtpSendSummeryTime.Location = new System.Drawing.Point(157, 49);
            this._dtpSendSummeryTime.Name = "_dtpSendSummeryTime";
            this._dtpSendSummeryTime.ShowUpDown = true;
            this._dtpSendSummeryTime.Size = new System.Drawing.Size(103, 25);
            this._dtpSendSummeryTime.TabIndex = 0;
            // 
            // _lnkLblCopyHeader
            // 
            this._lnkLblCopyHeader.AutoSize = true;
            this._lnkLblCopyHeader.Location = new System.Drawing.Point(137, 164);
            this._lnkLblCopyHeader.Name = "_lnkLblCopyHeader";
            this._lnkLblCopyHeader.Size = new System.Drawing.Size(38, 17);
            this._lnkLblCopyHeader.TabIndex = 43;
            this._lnkLblCopyHeader.TabStop = true;
            this._lnkLblCopyHeader.Text = "Copy";
            this._lnkLblCopyHeader.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._lnkLblCopyHeader_LinkClicked);
            // 
            // _rtbxCsvHeader
            // 
            this._rtbxCsvHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this._rtbxCsvHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._rtbxCsvHeader.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._rtbxCsvHeader.Location = new System.Drawing.Point(140, 95);
            this._rtbxCsvHeader.Name = "_rtbxCsvHeader";
            this._rtbxCsvHeader.Size = new System.Drawing.Size(556, 66);
            this._rtbxCsvHeader.TabIndex = 42;
            this._rtbxCsvHeader.Text = "BatchName;BatchDescription;HostnameOrAddress;HostDescription;Building;Cabinet;Rac" +
    "k;PhysicalAddress;Maintenance;AutoFetchPhysicalAddress";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(137, 75);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(540, 17);
            this.label16.TabIndex = 14;
            this.label16.Text = "ATTENTION: It is required that csv file contains the header line that shown in th" +
    "e box below.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(137, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(518, 17);
            this.label15.TabIndex = 14;
            this.label15.Text = "NOTE: The application load the selected csv file automaticaly after the file was " +
    "changed.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label14.Location = new System.Drawing.Point(9, 48);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 17);
            this.label14.TabIndex = 11;
            this.label14.Text = "Directory";
            // 
            // _tbxBatchlistCsvPath
            // 
            this._tbxBatchlistCsvPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxBatchlistCsvPath.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this._tbxBatchlistCsvPath.Location = new System.Drawing.Point(140, 46);
            this._tbxBatchlistCsvPath.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbxBatchlistCsvPath.Name = "_tbxBatchlistCsvPath";
            this._tbxBatchlistCsvPath.Size = new System.Drawing.Size(430, 25);
            this._tbxBatchlistCsvPath.TabIndex = 13;
            // 
            // _chkBxEnableAutoImportBatchlist
            // 
            this._chkBxEnableAutoImportBatchlist.AutoSize = true;
            this._chkBxEnableAutoImportBatchlist.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this._chkBxEnableAutoImportBatchlist.Location = new System.Drawing.Point(11, 25);
            this._chkBxEnableAutoImportBatchlist.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._chkBxEnableAutoImportBatchlist.Name = "_chkBxEnableAutoImportBatchlist";
            this._chkBxEnableAutoImportBatchlist.Size = new System.Drawing.Size(74, 21);
            this._chkBxEnableAutoImportBatchlist.TabIndex = 41;
            this._chkBxEnableAutoImportBatchlist.Text = "Enabled";
            this._chkBxEnableAutoImportBatchlist.UseVisualStyleBackColor = true;
            // 
            // _btnSelectBatchlistCsv
            // 
            this._btnSelectBatchlistCsv.BackColor = System.Drawing.Color.Gainsboro;
            this._btnSelectBatchlistCsv.FlatAppearance.BorderSize = 0;
            this._btnSelectBatchlistCsv.Location = new System.Drawing.Point(575, 46);
            this._btnSelectBatchlistCsv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnSelectBatchlistCsv.Name = "_btnSelectBatchlistCsv";
            this._btnSelectBatchlistCsv.Size = new System.Drawing.Size(34, 25);
            this._btnSelectBatchlistCsv.TabIndex = 12;
            this._btnSelectBatchlistCsv.Text = "...";
            this._btnSelectBatchlistCsv.UseVisualStyleBackColor = false;
            this._btnSelectBatchlistCsv.Click += new System.EventHandler(this._btnSelectBatchlistCsv_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.Location = new System.Drawing.Point(187, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "ms";
            // 
            // rBtnSmtp
            // 
            this.rBtnSmtp.AutoSize = true;
            this.rBtnSmtp.Enabled = false;
            this.rBtnSmtp.Location = new System.Drawing.Point(157, 49);
            this.rBtnSmtp.Name = "rBtnSmtp";
            this.rBtnSmtp.Size = new System.Drawing.Size(59, 21);
            this.rBtnSmtp.TabIndex = 121;
            this.rBtnSmtp.TabStop = true;
            this.rBtnSmtp.Text = "SMTP";
            this.rBtnSmtp.UseVisualStyleBackColor = true;
            this.rBtnSmtp.CheckedChanged += new System.EventHandler(this.rBtnSmtp_CheckedChanged);
            // 
            // rBtnOutlook
            // 
            this.rBtnOutlook.AutoSize = true;
            this.rBtnOutlook.Enabled = false;
            this.rBtnOutlook.Location = new System.Drawing.Point(222, 49);
            this.rBtnOutlook.Name = "rBtnOutlook";
            this.rBtnOutlook.Size = new System.Drawing.Size(72, 21);
            this.rBtnOutlook.TabIndex = 121;
            this.rBtnOutlook.TabStop = true;
            this.rBtnOutlook.Text = "Outlook";
            this.rBtnOutlook.UseVisualStyleBackColor = true;
            this.rBtnOutlook.CheckedChanged += new System.EventHandler(this.rBtnOutlook_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label6.Location = new System.Drawing.Point(8, 51);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Delivery Method";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._lnkLblCopyHeader);
            this.groupBox4.Controls.Add(this._chkBxEnableAutoImportBatchlist);
            this.groupBox4.Controls.Add(this._rtbxCsvHeader);
            this.groupBox4.Controls.Add(this._btnSelectBatchlistCsv);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this._tbxBatchlistCsvPath);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(12, 394);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(731, 192);
            this.groupBox4.TabIndex = 10000001;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Auto Import Batchlist";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(751, 630);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this._gbxEmailSettings);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this._gbxEmailSettings.ResumeLayout(false);
            this._gbxEmailSettings.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox _tbxOutputDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnSelectDir;
        private System.Windows.Forms.Button _btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _tbxInterval;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox _tbxTargetAddresses;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox _gbxEmailSettings;
        private System.Windows.Forms.CheckBox _chkBxEmailAlertingEnabled;
        private System.Windows.Forms.TextBox _tbxMailServer;
        private System.Windows.Forms.TextBox _tbxMailPassword;
        private System.Windows.Forms.TextBox _tbxMailUser;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button _btnSendTestMail;
        private System.Windows.Forms.TextBox _tbxMailServerPort;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox _chkBxEnableAutoImportBatchlist;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox _tbxBatchlistCsvPath;
        private System.Windows.Forms.Button _btnSelectBatchlistCsv;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RichTextBox _rtbxCsvHeader;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.LinkLabel _lnkLblCopyHeader;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker _dtpSendSummeryTime;
        private System.Windows.Forms.CheckBox _chkBxDailySummeryEnabled;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rBtnOutlook;
        private System.Windows.Forms.RadioButton rBtnSmtp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}