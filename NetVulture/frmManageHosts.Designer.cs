namespace NetVulture
{
    partial class frmManageHosts
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
            this._tbxListInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._btnOk = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _tbxListInput
            // 
            this._tbxListInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxListInput.Location = new System.Drawing.Point(12, 38);
            this._tbxListInput.Multiline = true;
            this._tbxListInput.Name = "_tbxListInput";
            this._tbxListInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._tbxListInput.Size = new System.Drawing.Size(383, 187);
            this._tbxListInput.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Hostname or IPv4 Address to the List. \r\nOne line per host.";
            // 
            // _btnOk
            // 
            this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOk.Location = new System.Drawing.Point(12, 245);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(75, 23);
            this._btnOk.TabIndex = 2;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(93, 245);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 2;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmManageHosts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 284);
            this.ControlBox = false;
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._tbxListInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmManageHosts";
            this.Text = "Manage Hosts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _tbxListInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.Button _btnCancel;
    }
}