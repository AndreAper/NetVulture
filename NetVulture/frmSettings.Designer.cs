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
            this._gbxSmsSettings = new System.Windows.Forms.GroupBox();
            this._tbxAccountRef = new System.Windows.Forms.TextBox();
            this._tbxSmsGatewayPassword = new System.Windows.Forms.TextBox();
            this._tbxSmsGatewayUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._btnSendTestSms = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this._cbxBxSmsAlertingEnabled = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this._tbxMobileNumbers = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            this._chkBxAlertingEnabled = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeneralSettings = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this._chkBxDailySummeryEnabled = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this._dtpSendSummeryTime = new System.Windows.Forms.DateTimePicker();
            this.tabPageAlertingService = new System.Windows.Forms.TabPage();
            this.tabPageBatchIO = new System.Windows.Forms.TabPage();
            this._lnkLblCopyHeader = new System.Windows.Forms.LinkLabel();
            this._rtbxCsvHeader = new System.Windows.Forms.RichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this._tbxBatchlistCsvPath = new System.Windows.Forms.TextBox();
            this._chkBxEnableAutoImportBatchlist = new System.Windows.Forms.CheckBox();
            this._btnSelectBatchlistCsv = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this._gbxSmsSettings.SuspendLayout();
            this._gbxEmailSettings.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageGeneralSettings.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPageAlertingService.SuspendLayout();
            this.tabPageBatchIO.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tbxOutputDir
            // 
            this._tbxOutputDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxOutputDir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxOutputDir.Location = new System.Drawing.Point(140, 24);
            this._tbxOutputDir.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbxOutputDir.Name = "_tbxOutputDir";
            this._tbxOutputDir.Size = new System.Drawing.Size(509, 29);
            this._tbxOutputDir.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Output Directory";
            // 
            // _btnSelectDir
            // 
            this._btnSelectDir.BackColor = System.Drawing.Color.Gainsboro;
            this._btnSelectDir.FlatAppearance.BorderSize = 0;
            this._btnSelectDir.Location = new System.Drawing.Point(654, 24);
            this._btnSelectDir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnSelectDir.Name = "_btnSelectDir";
            this._btnSelectDir.Size = new System.Drawing.Size(34, 29);
            this._btnSelectDir.TabIndex = 4;
            this._btnSelectDir.Text = "...";
            this._btnSelectDir.UseVisualStyleBackColor = false;
            this._btnSelectDir.Click += new System.EventHandler(this._btnSelectDir_Click);
            // 
            // _btnClose
            // 
            this._btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnClose.Location = new System.Drawing.Point(956, 372);
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
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Collect Interval";
            // 
            // _tbxInterval
            // 
            this._tbxInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxInterval.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxInterval.Location = new System.Drawing.Point(127, 24);
            this._tbxInterval.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbxInterval.Name = "_tbxInterval";
            this._tbxInterval.Size = new System.Drawing.Size(81, 29);
            this._tbxInterval.TabIndex = 20;
            this._tbxInterval.Text = "60000";
            this._tbxInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._tbxOutputDir);
            this.groupBox1.Controls.Add(this._btnSelectDir);
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(701, 77);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data output";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._tbxInterval);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(715, 7);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(344, 77);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Timer";
            // 
            // _gbxSmsSettings
            // 
            this._gbxSmsSettings.Controls.Add(this._tbxAccountRef);
            this._gbxSmsSettings.Controls.Add(this._tbxSmsGatewayPassword);
            this._gbxSmsSettings.Controls.Add(this._tbxSmsGatewayUser);
            this._gbxSmsSettings.Controls.Add(this.label7);
            this._gbxSmsSettings.Controls.Add(this._btnSendTestSms);
            this._gbxSmsSettings.Controls.Add(this.label9);
            this._gbxSmsSettings.Controls.Add(this._cbxBxSmsAlertingEnabled);
            this._gbxSmsSettings.Controls.Add(this.label8);
            this._gbxSmsSettings.Controls.Add(this._tbxMobileNumbers);
            this._gbxSmsSettings.Controls.Add(this.label3);
            this._gbxSmsSettings.Controls.Add(this.label6);
            this._gbxSmsSettings.Location = new System.Drawing.Point(8, 39);
            this._gbxSmsSettings.Name = "_gbxSmsSettings";
            this._gbxSmsSettings.Size = new System.Drawing.Size(520, 289);
            this._gbxSmsSettings.TabIndex = 9;
            this._gbxSmsSettings.TabStop = false;
            this._gbxSmsSettings.Text = "SMS";
            // 
            // _tbxAccountRef
            // 
            this._tbxAccountRef.Location = new System.Drawing.Point(158, 109);
            this._tbxAccountRef.Name = "_tbxAccountRef";
            this._tbxAccountRef.Size = new System.Drawing.Size(356, 25);
            this._tbxAccountRef.TabIndex = 100;
            // 
            // _tbxSmsGatewayPassword
            // 
            this._tbxSmsGatewayPassword.Location = new System.Drawing.Point(158, 78);
            this._tbxSmsGatewayPassword.Name = "_tbxSmsGatewayPassword";
            this._tbxSmsGatewayPassword.PasswordChar = '#';
            this._tbxSmsGatewayPassword.Size = new System.Drawing.Size(356, 25);
            this._tbxSmsGatewayPassword.TabIndex = 100;
            // 
            // _tbxSmsGatewayUser
            // 
            this._tbxSmsGatewayUser.Location = new System.Drawing.Point(158, 47);
            this._tbxSmsGatewayUser.Name = "_tbxSmsGatewayUser";
            this._tbxSmsGatewayUser.Size = new System.Drawing.Size(356, 25);
            this._tbxSmsGatewayUser.TabIndex = 90;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1, 109);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 21);
            this.label7.TabIndex = 2;
            this.label7.Text = "Account Reference";
            // 
            // _btnSendTestSms
            // 
            this._btnSendTestSms.Location = new System.Drawing.Point(367, 250);
            this._btnSendTestSms.Name = "_btnSendTestSms";
            this._btnSendTestSms.Size = new System.Drawing.Size(147, 32);
            this._btnSendTestSms.TabIndex = 120;
            this._btnSendTestSms.Text = "Send Test SMS";
            this._btnSendTestSms.UseVisualStyleBackColor = true;
            this._btnSendTestSms.Click += new System.EventHandler(this._btnSendTestSms_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(2, 78);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 21);
            this.label9.TabIndex = 2;
            this.label9.Text = "Password";
            // 
            // _cbxBxSmsAlertingEnabled
            // 
            this._cbxBxSmsAlertingEnabled.AutoSize = true;
            this._cbxBxSmsAlertingEnabled.Location = new System.Drawing.Point(6, 20);
            this._cbxBxSmsAlertingEnabled.Name = "_cbxBxSmsAlertingEnabled";
            this._cbxBxSmsAlertingEnabled.Size = new System.Drawing.Size(74, 21);
            this._cbxBxSmsAlertingEnabled.TabIndex = 70;
            this._cbxBxSmsAlertingEnabled.Text = "Enabled";
            this._cbxBxSmsAlertingEnabled.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(2, 47);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 21);
            this.label8.TabIndex = 2;
            this.label8.Text = "Username";
            // 
            // _tbxMobileNumbers
            // 
            this._tbxMobileNumbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxMobileNumbers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxMobileNumbers.Location = new System.Drawing.Point(158, 140);
            this._tbxMobileNumbers.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbxMobileNumbers.Multiline = true;
            this._tbxMobileNumbers.Name = "_tbxMobileNumbers";
            this._tbxMobileNumbers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._tbxMobileNumbers.Size = new System.Drawing.Size(356, 100);
            this._tbxMobileNumbers.TabIndex = 110;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 140);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Target numbers";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(3, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "One number per line";
            // 
            // _gbxEmailSettings
            // 
            this._gbxEmailSettings.Controls.Add(this._chkBxEmailAlertingEnabled);
            this._gbxEmailSettings.Controls.Add(this._tbxMailServerPort);
            this._gbxEmailSettings.Controls.Add(this._tbxMailPassword);
            this._gbxEmailSettings.Controls.Add(this._tbxTargetAddresses);
            this._gbxEmailSettings.Controls.Add(this._tbxMailServer);
            this._gbxEmailSettings.Controls.Add(this._btnSendTestMail);
            this._gbxEmailSettings.Controls.Add(this._tbxMailUser);
            this._gbxEmailSettings.Controls.Add(this.label12);
            this._gbxEmailSettings.Controls.Add(this.label5);
            this._gbxEmailSettings.Controls.Add(this.label13);
            this._gbxEmailSettings.Controls.Add(this.label4);
            this._gbxEmailSettings.Controls.Add(this.label10);
            this._gbxEmailSettings.Controls.Add(this.label11);
            this._gbxEmailSettings.Enabled = false;
            this._gbxEmailSettings.Location = new System.Drawing.Point(534, 39);
            this._gbxEmailSettings.Name = "_gbxEmailSettings";
            this._gbxEmailSettings.Size = new System.Drawing.Size(520, 289);
            this._gbxEmailSettings.TabIndex = 8;
            this._gbxEmailSettings.TabStop = false;
            this._gbxEmailSettings.Text = "E-mail";
            // 
            // _chkBxEmailAlertingEnabled
            // 
            this._chkBxEmailAlertingEnabled.AutoSize = true;
            this._chkBxEmailAlertingEnabled.Location = new System.Drawing.Point(6, 20);
            this._chkBxEmailAlertingEnabled.Name = "_chkBxEmailAlertingEnabled";
            this._chkBxEmailAlertingEnabled.Size = new System.Drawing.Size(74, 21);
            this._chkBxEmailAlertingEnabled.TabIndex = 50;
            this._chkBxEmailAlertingEnabled.Text = "Enabled";
            this._chkBxEmailAlertingEnabled.UseVisualStyleBackColor = true;
            // 
            // _tbxMailServerPort
            // 
            this._tbxMailServerPort.Location = new System.Drawing.Point(451, 47);
            this._tbxMailServerPort.Name = "_tbxMailServerPort";
            this._tbxMailServerPort.Size = new System.Drawing.Size(63, 25);
            this._tbxMailServerPort.TabIndex = 100;
            // 
            // _tbxMailPassword
            // 
            this._tbxMailPassword.Location = new System.Drawing.Point(158, 109);
            this._tbxMailPassword.Name = "_tbxMailPassword";
            this._tbxMailPassword.PasswordChar = '#';
            this._tbxMailPassword.Size = new System.Drawing.Size(356, 25);
            this._tbxMailPassword.TabIndex = 90;
            // 
            // _tbxTargetAddresses
            // 
            this._tbxTargetAddresses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxTargetAddresses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxTargetAddresses.Location = new System.Drawing.Point(158, 144);
            this._tbxTargetAddresses.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbxTargetAddresses.Multiline = true;
            this._tbxTargetAddresses.Name = "_tbxTargetAddresses";
            this._tbxTargetAddresses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._tbxTargetAddresses.Size = new System.Drawing.Size(357, 100);
            this._tbxTargetAddresses.TabIndex = 60;
            // 
            // _tbxMailServer
            // 
            this._tbxMailServer.Location = new System.Drawing.Point(158, 47);
            this._tbxMailServer.Name = "_tbxMailServer";
            this._tbxMailServer.Size = new System.Drawing.Size(245, 25);
            this._tbxMailServer.TabIndex = 100;
            // 
            // _btnSendTestMail
            // 
            this._btnSendTestMail.Location = new System.Drawing.Point(367, 250);
            this._btnSendTestMail.Name = "_btnSendTestMail";
            this._btnSendTestMail.Size = new System.Drawing.Size(147, 32);
            this._btnSendTestMail.TabIndex = 120;
            this._btnSendTestMail.Text = "Send Test Mail";
            this._btnSendTestMail.UseVisualStyleBackColor = true;
            this._btnSendTestMail.Click += new System.EventHandler(this._btnSendTestMail_Click);
            // 
            // _tbxMailUser
            // 
            this._tbxMailUser.Location = new System.Drawing.Point(158, 78);
            this._tbxMailUser.Name = "_tbxMailUser";
            this._tbxMailUser.Size = new System.Drawing.Size(356, 25);
            this._tbxMailUser.TabIndex = 80;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(2, 47);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 21);
            this.label12.TabIndex = 2;
            this.label12.Text = "Server";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(3, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "One address per line";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(408, 47);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 21);
            this.label13.TabIndex = 2;
            this.label13.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 142);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "Target addresses";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(2, 78);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 21);
            this.label10.TabIndex = 2;
            this.label10.Text = "User";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(2, 109);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 21);
            this.label11.TabIndex = 2;
            this.label11.Text = "Password";
            // 
            // _chkBxAlertingEnabled
            // 
            this._chkBxAlertingEnabled.AutoSize = true;
            this._chkBxAlertingEnabled.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._chkBxAlertingEnabled.Location = new System.Drawing.Point(6, 7);
            this._chkBxAlertingEnabled.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._chkBxAlertingEnabled.Name = "_chkBxAlertingEnabled";
            this._chkBxAlertingEnabled.Size = new System.Drawing.Size(143, 25);
            this._chkBxAlertingEnabled.TabIndex = 40;
            this._chkBxAlertingEnabled.Text = "Alerting Enabled";
            this._chkBxAlertingEnabled.UseVisualStyleBackColor = true;
            this._chkBxAlertingEnabled.CheckedChanged += new System.EventHandler(this._chkBxAlertingEnabled_CheckedChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageGeneralSettings);
            this.tabControl.Controls.Add(this.tabPageAlertingService);
            this.tabControl.Controls.Add(this.tabPageBatchIO);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1073, 365);
            this.tabControl.TabIndex = 10000000;
            // 
            // tabPageGeneralSettings
            // 
            this.tabPageGeneralSettings.Controls.Add(this.groupBox3);
            this.tabPageGeneralSettings.Controls.Add(this.groupBox2);
            this.tabPageGeneralSettings.Controls.Add(this.groupBox1);
            this.tabPageGeneralSettings.Location = new System.Drawing.Point(4, 26);
            this.tabPageGeneralSettings.Name = "tabPageGeneralSettings";
            this.tabPageGeneralSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneralSettings.Size = new System.Drawing.Size(1065, 335);
            this.tabPageGeneralSettings.TabIndex = 0;
            this.tabPageGeneralSettings.Text = "General Settings";
            this.tabPageGeneralSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this._chkBxDailySummeryEnabled);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this._dtpSendSummeryTime);
            this.groupBox3.Location = new System.Drawing.Point(8, 91);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(701, 100);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Daily Summery";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label18.Location = new System.Drawing.Point(137, 25);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(538, 17);
            this.label18.TabIndex = 15;
            this.label18.Text = "NOTE: To send daily reports you need to configure mail service in the alerting se" +
    "rvice area.";
            // 
            // _chkBxDailySummeryEnabled
            // 
            this._chkBxDailySummeryEnabled.AutoSize = true;
            this._chkBxDailySummeryEnabled.Location = new System.Drawing.Point(13, 24);
            this._chkBxDailySummeryEnabled.Name = "_chkBxDailySummeryEnabled";
            this._chkBxDailySummeryEnabled.Size = new System.Drawing.Size(74, 21);
            this._chkBxDailySummeryEnabled.TabIndex = 3;
            this._chkBxDailySummeryEnabled.Text = "Enabled";
            this._chkBxDailySummeryEnabled.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(9, 48);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 21);
            this.label17.TabIndex = 2;
            this.label17.Text = "Time";
            // 
            // _dtpSendSummeryTime
            // 
            this._dtpSendSummeryTime.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this._dtpSendSummeryTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this._dtpSendSummeryTime.Location = new System.Drawing.Point(140, 45);
            this._dtpSendSummeryTime.Name = "_dtpSendSummeryTime";
            this._dtpSendSummeryTime.ShowUpDown = true;
            this._dtpSendSummeryTime.Size = new System.Drawing.Size(103, 25);
            this._dtpSendSummeryTime.TabIndex = 0;
            // 
            // tabPageAlertingService
            // 
            this.tabPageAlertingService.Controls.Add(this._gbxSmsSettings);
            this.tabPageAlertingService.Controls.Add(this._gbxEmailSettings);
            this.tabPageAlertingService.Controls.Add(this._chkBxAlertingEnabled);
            this.tabPageAlertingService.Location = new System.Drawing.Point(4, 26);
            this.tabPageAlertingService.Name = "tabPageAlertingService";
            this.tabPageAlertingService.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAlertingService.Size = new System.Drawing.Size(1065, 335);
            this.tabPageAlertingService.TabIndex = 1;
            this.tabPageAlertingService.Text = "Alerting Service";
            this.tabPageAlertingService.UseVisualStyleBackColor = true;
            // 
            // tabPageBatchIO
            // 
            this.tabPageBatchIO.Controls.Add(this._lnkLblCopyHeader);
            this.tabPageBatchIO.Controls.Add(this._rtbxCsvHeader);
            this.tabPageBatchIO.Controls.Add(this.label16);
            this.tabPageBatchIO.Controls.Add(this.label15);
            this.tabPageBatchIO.Controls.Add(this.label14);
            this.tabPageBatchIO.Controls.Add(this._tbxBatchlistCsvPath);
            this.tabPageBatchIO.Controls.Add(this._chkBxEnableAutoImportBatchlist);
            this.tabPageBatchIO.Controls.Add(this._btnSelectBatchlistCsv);
            this.tabPageBatchIO.Location = new System.Drawing.Point(4, 26);
            this.tabPageBatchIO.Name = "tabPageBatchIO";
            this.tabPageBatchIO.Size = new System.Drawing.Size(1065, 335);
            this.tabPageBatchIO.TabIndex = 2;
            this.tabPageBatchIO.Text = "Batchlist I/O";
            this.tabPageBatchIO.UseVisualStyleBackColor = true;
            // 
            // _lnkLblCopyHeader
            // 
            this._lnkLblCopyHeader.AutoSize = true;
            this._lnkLblCopyHeader.Location = new System.Drawing.Point(596, 208);
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
            this._rtbxCsvHeader.Location = new System.Drawing.Point(86, 139);
            this._rtbxCsvHeader.Name = "_rtbxCsvHeader";
            this._rtbxCsvHeader.Size = new System.Drawing.Size(548, 66);
            this._rtbxCsvHeader.TabIndex = 42;
            this._rtbxCsvHeader.Text = "BatchName;BatchDescription;HostnameOrAddress;HostDescription;Building;Cabinet;Rac" +
    "k;PhysicalAddress;Maintenance;AutoFetchPhysicalAddress";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(83, 119);
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
            this.label15.Location = new System.Drawing.Point(83, 75);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(518, 17);
            this.label15.TabIndex = 14;
            this.label15.Text = "NOTE: The application load the selected csv file automaticaly after the file was " +
    "changed.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 45);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 21);
            this.label14.TabIndex = 11;
            this.label14.Text = "Directory";
            // 
            // _tbxBatchlistCsvPath
            // 
            this._tbxBatchlistCsvPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxBatchlistCsvPath.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxBatchlistCsvPath.Location = new System.Drawing.Point(86, 42);
            this._tbxBatchlistCsvPath.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbxBatchlistCsvPath.Name = "_tbxBatchlistCsvPath";
            this._tbxBatchlistCsvPath.Size = new System.Drawing.Size(509, 29);
            this._tbxBatchlistCsvPath.TabIndex = 13;
            // 
            // _chkBxEnableAutoImportBatchlist
            // 
            this._chkBxEnableAutoImportBatchlist.AutoSize = true;
            this._chkBxEnableAutoImportBatchlist.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._chkBxEnableAutoImportBatchlist.Location = new System.Drawing.Point(86, 10);
            this._chkBxEnableAutoImportBatchlist.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._chkBxEnableAutoImportBatchlist.Name = "_chkBxEnableAutoImportBatchlist";
            this._chkBxEnableAutoImportBatchlist.Size = new System.Drawing.Size(225, 25);
            this._chkBxEnableAutoImportBatchlist.TabIndex = 41;
            this._chkBxEnableAutoImportBatchlist.Text = "Enable Auto Import Batchlist";
            this._chkBxEnableAutoImportBatchlist.UseVisualStyleBackColor = true;
            // 
            // _btnSelectBatchlistCsv
            // 
            this._btnSelectBatchlistCsv.BackColor = System.Drawing.Color.Gainsboro;
            this._btnSelectBatchlistCsv.FlatAppearance.BorderSize = 0;
            this._btnSelectBatchlistCsv.Location = new System.Drawing.Point(600, 42);
            this._btnSelectBatchlistCsv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnSelectBatchlistCsv.Name = "_btnSelectBatchlistCsv";
            this._btnSelectBatchlistCsv.Size = new System.Drawing.Size(34, 29);
            this._btnSelectBatchlistCsv.TabIndex = 12;
            this._btnSelectBatchlistCsv.Text = "...";
            this._btnSelectBatchlistCsv.UseVisualStyleBackColor = false;
            this._btnSelectBatchlistCsv.Click += new System.EventHandler(this._btnSelectBatchlistCsv_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 413);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this._btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this._gbxSmsSettings.ResumeLayout(false);
            this._gbxSmsSettings.PerformLayout();
            this._gbxEmailSettings.ResumeLayout(false);
            this._gbxEmailSettings.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageGeneralSettings.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPageAlertingService.ResumeLayout(false);
            this.tabPageAlertingService.PerformLayout();
            this.tabPageBatchIO.ResumeLayout(false);
            this.tabPageBatchIO.PerformLayout();
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
        private System.Windows.Forms.CheckBox _chkBxAlertingEnabled;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox _gbxSmsSettings;
        private System.Windows.Forms.GroupBox _gbxEmailSettings;
        private System.Windows.Forms.CheckBox _chkBxEmailAlertingEnabled;
        private System.Windows.Forms.CheckBox _cbxBxSmsAlertingEnabled;
        private System.Windows.Forms.TextBox _tbxMobileNumbers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button _btnSendTestSms;
        private System.Windows.Forms.TextBox _tbxSmsGatewayPassword;
        private System.Windows.Forms.TextBox _tbxSmsGatewayUser;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _tbxMailServer;
        private System.Windows.Forms.TextBox _tbxMailPassword;
        private System.Windows.Forms.TextBox _tbxMailUser;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button _btnSendTestMail;
        private System.Windows.Forms.TextBox _tbxMailServerPort;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageGeneralSettings;
        private System.Windows.Forms.TabPage tabPageAlertingService;
        private System.Windows.Forms.TabPage tabPageBatchIO;
        private System.Windows.Forms.CheckBox _chkBxEnableAutoImportBatchlist;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox _tbxBatchlistCsvPath;
        private System.Windows.Forms.Button _btnSelectBatchlistCsv;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RichTextBox _rtbxCsvHeader;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.LinkLabel _lnkLblCopyHeader;
        private System.Windows.Forms.TextBox _tbxAccountRef;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker _dtpSendSummeryTime;
        private System.Windows.Forms.CheckBox _chkBxDailySummeryEnabled;
        private System.Windows.Forms.Label label18;
    }
}