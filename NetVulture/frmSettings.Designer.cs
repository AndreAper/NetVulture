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
            this._chkBxAutoStartTimer = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._gbxSmsSettings = new System.Windows.Forms.GroupBox();
            this._tbxSmsGatewayPassword = new System.Windows.Forms.TextBox();
            this._tbxSmsGatewayUser = new System.Windows.Forms.TextBox();
            this._tbxSmsGatewayAddress = new System.Windows.Forms.TextBox();
            this._btnSendTestSms = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this._cbxBxSmsAlertingEnabled = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this._tbxMobileNumbers = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this._gbxSmsSettings.SuspendLayout();
            this._gbxEmailSettings.SuspendLayout();
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
            this._btnSelectDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSelectDir.Location = new System.Drawing.Point(654, 18);
            this._btnSelectDir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnSelectDir.Name = "_btnSelectDir";
            this._btnSelectDir.Size = new System.Drawing.Size(34, 38);
            this._btnSelectDir.TabIndex = 4;
            this._btnSelectDir.Text = "...";
            this._btnSelectDir.UseVisualStyleBackColor = false;
            this._btnSelectDir.Click += new System.EventHandler(this._btnSelectDir_Click);
            // 
            // _btnClose
            // 
            this._btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnClose.Location = new System.Drawing.Point(964, 464);
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
            this.label2.Location = new System.Drawing.Point(9, 26);
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
            this._tbxInterval.Location = new System.Drawing.Point(126, 24);
            this._tbxInterval.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbxInterval.Name = "_tbxInterval";
            this._tbxInterval.Size = new System.Drawing.Size(81, 29);
            this._tbxInterval.TabIndex = 20;
            this._tbxInterval.Text = "60000";
            this._tbxInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _chkBxAutoStartTimer
            // 
            this._chkBxAutoStartTimer.AutoSize = true;
            this._chkBxAutoStartTimer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._chkBxAutoStartTimer.Location = new System.Drawing.Point(212, 25);
            this._chkBxAutoStartTimer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._chkBxAutoStartTimer.Name = "_chkBxAutoStartTimer";
            this._chkBxAutoStartTimer.Size = new System.Drawing.Size(142, 25);
            this._chkBxAutoStartTimer.TabIndex = 30;
            this._chkBxAutoStartTimer.Text = "Auto Start Timer";
            this._chkBxAutoStartTimer.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._tbxOutputDir);
            this.groupBox1.Controls.Add(this._btnSelectDir);
            this.groupBox1.Location = new System.Drawing.Point(376, 13);
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
            this.groupBox2.Controls.Add(this._chkBxAutoStartTimer);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(358, 77);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Timer";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._gbxSmsSettings);
            this.groupBox3.Controls.Add(this._gbxEmailSettings);
            this.groupBox3.Controls.Add(this._chkBxAlertingEnabled);
            this.groupBox3.Location = new System.Drawing.Point(12, 98);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(1065, 358);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Alerting service";
            // 
            // _gbxSmsSettings
            // 
            this._gbxSmsSettings.Controls.Add(this._tbxSmsGatewayPassword);
            this._gbxSmsSettings.Controls.Add(this._tbxSmsGatewayUser);
            this._gbxSmsSettings.Controls.Add(this._tbxSmsGatewayAddress);
            this._gbxSmsSettings.Controls.Add(this._btnSendTestSms);
            this._gbxSmsSettings.Controls.Add(this.label9);
            this._gbxSmsSettings.Controls.Add(this._cbxBxSmsAlertingEnabled);
            this._gbxSmsSettings.Controls.Add(this.label8);
            this._gbxSmsSettings.Controls.Add(this._tbxMobileNumbers);
            this._gbxSmsSettings.Controls.Add(this.label7);
            this._gbxSmsSettings.Controls.Add(this.label3);
            this._gbxSmsSettings.Controls.Add(this.label6);
            this._gbxSmsSettings.Location = new System.Drawing.Point(532, 57);
            this._gbxSmsSettings.Name = "_gbxSmsSettings";
            this._gbxSmsSettings.Size = new System.Drawing.Size(520, 289);
            this._gbxSmsSettings.TabIndex = 9;
            this._gbxSmsSettings.TabStop = false;
            this._gbxSmsSettings.Text = "SMS";
            // 
            // _tbxSmsGatewayPassword
            // 
            this._tbxSmsGatewayPassword.Location = new System.Drawing.Point(158, 113);
            this._tbxSmsGatewayPassword.Name = "_tbxSmsGatewayPassword";
            this._tbxSmsGatewayPassword.PasswordChar = '#';
            this._tbxSmsGatewayPassword.Size = new System.Drawing.Size(356, 25);
            this._tbxSmsGatewayPassword.TabIndex = 100;
            // 
            // _tbxSmsGatewayUser
            // 
            this._tbxSmsGatewayUser.Location = new System.Drawing.Point(158, 82);
            this._tbxSmsGatewayUser.Name = "_tbxSmsGatewayUser";
            this._tbxSmsGatewayUser.Size = new System.Drawing.Size(356, 25);
            this._tbxSmsGatewayUser.TabIndex = 90;
            // 
            // _tbxSmsGatewayAddress
            // 
            this._tbxSmsGatewayAddress.Location = new System.Drawing.Point(158, 51);
            this._tbxSmsGatewayAddress.Name = "_tbxSmsGatewayAddress";
            this._tbxSmsGatewayAddress.Size = new System.Drawing.Size(356, 25);
            this._tbxSmsGatewayAddress.TabIndex = 80;
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
            this.label9.Location = new System.Drawing.Point(2, 113);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 21);
            this.label9.TabIndex = 2;
            this.label9.Text = "Gateway password";
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
            this.label8.Location = new System.Drawing.Point(2, 82);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 21);
            this.label8.TabIndex = 2;
            this.label8.Text = "Gateway user";
            // 
            // _tbxMobileNumbers
            // 
            this._tbxMobileNumbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxMobileNumbers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxMobileNumbers.Location = new System.Drawing.Point(158, 144);
            this._tbxMobileNumbers.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbxMobileNumbers.Multiline = true;
            this._tbxMobileNumbers.Name = "_tbxMobileNumbers";
            this._tbxMobileNumbers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._tbxMobileNumbers.Size = new System.Drawing.Size(357, 100);
            this._tbxMobileNumbers.TabIndex = 110;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(2, 51);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 21);
            this.label7.TabIndex = 2;
            this.label7.Text = "Gateway address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 146);
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
            this.label6.Location = new System.Drawing.Point(3, 170);
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
            this._gbxEmailSettings.Location = new System.Drawing.Point(6, 57);
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
            this._chkBxAlertingEnabled.Location = new System.Drawing.Point(12, 25);
            this._chkBxAlertingEnabled.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._chkBxAlertingEnabled.Name = "_chkBxAlertingEnabled";
            this._chkBxAlertingEnabled.Size = new System.Drawing.Size(143, 25);
            this._chkBxAlertingEnabled.TabIndex = 40;
            this._chkBxAlertingEnabled.Text = "Alerting Enabled";
            this._chkBxAlertingEnabled.UseVisualStyleBackColor = true;
            this._chkBxAlertingEnabled.CheckedChanged += new System.EventHandler(this._chkBxAlertingEnabled_CheckedChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 507);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this._gbxSmsSettings.ResumeLayout(false);
            this._gbxSmsSettings.PerformLayout();
            this._gbxEmailSettings.ResumeLayout(false);
            this._gbxEmailSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox _tbxOutputDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnSelectDir;
        private System.Windows.Forms.Button _btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _tbxInterval;
        private System.Windows.Forms.CheckBox _chkBxAutoStartTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _tbxSmsGatewayAddress;
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
    }
}