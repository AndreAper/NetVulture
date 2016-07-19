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
            this.SuspendLayout();
            // 
            // _tbxOutputDir
            // 
            this._tbxOutputDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxOutputDir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxOutputDir.Location = new System.Drawing.Point(148, 11);
            this._tbxOutputDir.Margin = new System.Windows.Forms.Padding(2);
            this._tbxOutputDir.Name = "_tbxOutputDir";
            this._tbxOutputDir.Size = new System.Drawing.Size(266, 29);
            this._tbxOutputDir.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
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
            this._btnSelectDir.Location = new System.Drawing.Point(419, 11);
            this._btnSelectDir.Name = "_btnSelectDir";
            this._btnSelectDir.Size = new System.Drawing.Size(29, 29);
            this._btnSelectDir.TabIndex = 4;
            this._btnSelectDir.Text = "...";
            this._btnSelectDir.UseVisualStyleBackColor = false;
            this._btnSelectDir.Click += new System.EventHandler(this._btnSelectDir_Click);
            // 
            // _btnClose
            // 
            this._btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnClose.Location = new System.Drawing.Point(351, 169);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(97, 23);
            this._btnClose.TabIndex = 5;
            this._btnClose.Text = "Close";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this._btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Collect Interval";
            // 
            // _tbxInterval
            // 
            this._tbxInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxInterval.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxInterval.Location = new System.Drawing.Point(148, 44);
            this._tbxInterval.Margin = new System.Windows.Forms.Padding(2);
            this._tbxInterval.Name = "_tbxInterval";
            this._tbxInterval.Size = new System.Drawing.Size(266, 29);
            this._tbxInterval.TabIndex = 3;
            this._tbxInterval.Text = "60000";
            // 
            // _chkBxAutoStartTimer
            // 
            this._chkBxAutoStartTimer.AutoSize = true;
            this._chkBxAutoStartTimer.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._chkBxAutoStartTimer.Location = new System.Drawing.Point(148, 88);
            this._chkBxAutoStartTimer.Name = "_chkBxAutoStartTimer";
            this._chkBxAutoStartTimer.Size = new System.Drawing.Size(139, 25);
            this._chkBxAutoStartTimer.TabIndex = 6;
            this._chkBxAutoStartTimer.Text = "Auto Start Timer";
            this._chkBxAutoStartTimer.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 204);
            this.Controls.Add(this._chkBxAutoStartTimer);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._btnSelectDir);
            this.Controls.Add(this._tbxInterval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._tbxOutputDir);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _tbxOutputDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnSelectDir;
        private System.Windows.Forms.Button _btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _tbxInterval;
        private System.Windows.Forms.CheckBox _chkBxAutoStartTimer;
    }
}