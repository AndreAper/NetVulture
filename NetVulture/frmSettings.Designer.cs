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
            this._chkBxAlertingEnabled = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this._tbxSenderAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._tbxTargetAddresses = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tbxOutputDir
            // 
            this._tbxOutputDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxOutputDir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxOutputDir.Location = new System.Drawing.Point(171, 24);
            this._tbxOutputDir.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbxOutputDir.Name = "_tbxOutputDir";
            this._tbxOutputDir.Size = new System.Drawing.Size(483, 29);
            this._tbxOutputDir.TabIndex = 3;
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
            this._btnSelectDir.Location = new System.Drawing.Point(660, 24);
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
            this._btnClose.Location = new System.Drawing.Point(602, 409);
            this._btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(113, 30);
            this._btnClose.TabIndex = 5;
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
            this._tbxInterval.Location = new System.Drawing.Point(171, 24);
            this._tbxInterval.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbxInterval.Name = "_tbxInterval";
            this._tbxInterval.Size = new System.Drawing.Size(310, 29);
            this._tbxInterval.TabIndex = 3;
            this._tbxInterval.Text = "60000";
            // 
            // _chkBxAutoStartTimer
            // 
            this._chkBxAutoStartTimer.AutoSize = true;
            this._chkBxAutoStartTimer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._chkBxAutoStartTimer.Location = new System.Drawing.Point(492, 25);
            this._chkBxAutoStartTimer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._chkBxAutoStartTimer.Name = "_chkBxAutoStartTimer";
            this._chkBxAutoStartTimer.Size = new System.Drawing.Size(142, 25);
            this._chkBxAutoStartTimer.TabIndex = 6;
            this._chkBxAutoStartTimer.Text = "Auto Start Timer";
            this._chkBxAutoStartTimer.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._tbxOutputDir);
            this.groupBox1.Controls.Add(this._btnSelectDir);
            this.groupBox1.Location = new System.Drawing.Point(14, 16);
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
            this.groupBox2.Location = new System.Drawing.Point(14, 101);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(701, 77);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Timer";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this._tbxTargetAddresses);
            this.groupBox3.Controls.Add(this._tbxSenderAddress);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this._chkBxAlertingEnabled);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(14, 186);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(701, 215);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Alerting service";
            // 
            // _chkBxAlertingEnabled
            // 
            this._chkBxAlertingEnabled.AutoSize = true;
            this._chkBxAlertingEnabled.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._chkBxAlertingEnabled.Location = new System.Drawing.Point(14, 25);
            this._chkBxAlertingEnabled.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._chkBxAlertingEnabled.Name = "_chkBxAlertingEnabled";
            this._chkBxAlertingEnabled.Size = new System.Drawing.Size(143, 25);
            this._chkBxAlertingEnabled.TabIndex = 6;
            this._chkBxAlertingEnabled.Text = "Alerting Enabled";
            this._chkBxAlertingEnabled.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sender address";
            // 
            // _tbxSenderAddress
            // 
            this._tbxSenderAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxSenderAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxSenderAddress.Location = new System.Drawing.Point(171, 58);
            this._tbxSenderAddress.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbxSenderAddress.Name = "_tbxSenderAddress";
            this._tbxSenderAddress.Size = new System.Drawing.Size(310, 29);
            this._tbxSenderAddress.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 95);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "Target addresses";
            // 
            // _tbxTargetAddresses
            // 
            this._tbxTargetAddresses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxTargetAddresses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxTargetAddresses.Location = new System.Drawing.Point(171, 93);
            this._tbxTargetAddresses.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbxTargetAddresses.Multiline = true;
            this._tbxTargetAddresses.Name = "_tbxTargetAddresses";
            this._tbxTargetAddresses.Size = new System.Drawing.Size(310, 104);
            this._tbxTargetAddresses.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(11, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "One address per line";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 452);
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
        private System.Windows.Forms.TextBox _tbxSenderAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox _chkBxAlertingEnabled;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}