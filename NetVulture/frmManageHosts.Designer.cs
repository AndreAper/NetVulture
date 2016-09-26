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
            this._btnOk = new System.Windows.Forms.Button();
            this._tbxDnsEntry = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._tbxPhysicalAddress = new System.Windows.Forms.TextBox();
            this._tbxHostDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._chkBxIsMaintenanceActive = new System.Windows.Forms.CheckBox();
            this._lbxHIs = new System.Windows.Forms.ListBox();
            this._btnAddHI = new System.Windows.Forms.Button();
            this._btnRemoveHI = new System.Windows.Forms.Button();
            this._chkBxAutoFetchMac = new System.Windows.Forms.CheckBox();
            this._tbxBuilding = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._tbxCabinet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._tbxRack = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnImport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnOk
            // 
            this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOk.Location = new System.Drawing.Point(896, 445);
            this._btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(106, 30);
            this._btnOk.TabIndex = 120;
            this._btnOk.Text = "Close";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _tbxDnsEntry
            // 
            this._tbxDnsEntry.BackColor = System.Drawing.Color.White;
            this._tbxDnsEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxDnsEntry.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxDnsEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._tbxDnsEntry.Location = new System.Drawing.Point(198, 35);
            this._tbxDnsEntry.Margin = new System.Windows.Forms.Padding(2, 3, 23, 3);
            this._tbxDnsEntry.Name = "_tbxDnsEntry";
            this._tbxDnsEntry.Size = new System.Drawing.Size(399, 29);
            this._tbxDnsEntry.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this.label5.Location = new System.Drawing.Point(7, 254);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 21);
            this.label5.TabIndex = 22;
            this.label5.Text = "Physical Address";
            // 
            // _tbxPhysicalAddress
            // 
            this._tbxPhysicalAddress.BackColor = System.Drawing.Color.White;
            this._tbxPhysicalAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxPhysicalAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxPhysicalAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._tbxPhysicalAddress.Location = new System.Drawing.Point(198, 251);
            this._tbxPhysicalAddress.Margin = new System.Windows.Forms.Padding(2, 3, 23, 3);
            this._tbxPhysicalAddress.Name = "_tbxPhysicalAddress";
            this._tbxPhysicalAddress.Size = new System.Drawing.Size(399, 29);
            this._tbxPhysicalAddress.TabIndex = 50;
            // 
            // _tbxHostDescription
            // 
            this._tbxHostDescription.BackColor = System.Drawing.Color.White;
            this._tbxHostDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxHostDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxHostDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._tbxHostDescription.Location = new System.Drawing.Point(198, 78);
            this._tbxHostDescription.Margin = new System.Windows.Forms.Padding(2, 3, 23, 3);
            this._tbxHostDescription.Name = "_tbxHostDescription";
            this._tbxHostDescription.Size = new System.Drawing.Size(399, 29);
            this._tbxHostDescription.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this.label4.Location = new System.Drawing.Point(7, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 21);
            this.label4.TabIndex = 22;
            this.label4.Text = "Hostname or Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this.label2.Location = new System.Drawing.Point(7, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 21);
            this.label2.TabIndex = 22;
            this.label2.Text = "Description";
            // 
            // _chkBxIsMaintenanceActive
            // 
            this._chkBxIsMaintenanceActive.AutoSize = true;
            this._chkBxIsMaintenanceActive.Location = new System.Drawing.Point(198, 296);
            this._chkBxIsMaintenanceActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._chkBxIsMaintenanceActive.Name = "_chkBxIsMaintenanceActive";
            this._chkBxIsMaintenanceActive.Size = new System.Drawing.Size(101, 21);
            this._chkBxIsMaintenanceActive.TabIndex = 60;
            this._chkBxIsMaintenanceActive.Text = "Maintenance";
            this._chkBxIsMaintenanceActive.UseVisualStyleBackColor = true;
            // 
            // _lbxHIs
            // 
            this._lbxHIs.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._lbxHIs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._lbxHIs.FormattingEnabled = true;
            this._lbxHIs.ItemHeight = 21;
            this._lbxHIs.Location = new System.Drawing.Point(7, 31);
            this._lbxHIs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._lbxHIs.Name = "_lbxHIs";
            this._lbxHIs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this._lbxHIs.Size = new System.Drawing.Size(348, 382);
            this._lbxHIs.TabIndex = 27;
            this._lbxHIs.SelectedIndexChanged += new System.EventHandler(this._lbxHIs_SelectedIndexChanged);
            // 
            // _btnAddHI
            // 
            this._btnAddHI.Location = new System.Drawing.Point(11, 26);
            this._btnAddHI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnAddHI.Name = "_btnAddHI";
            this._btnAddHI.Size = new System.Drawing.Size(106, 34);
            this._btnAddHI.TabIndex = 80;
            this._btnAddHI.Text = "Add new";
            this._btnAddHI.UseVisualStyleBackColor = true;
            this._btnAddHI.Click += new System.EventHandler(this._btnAddHI_Click);
            // 
            // _btnRemoveHI
            // 
            this._btnRemoveHI.Location = new System.Drawing.Point(235, 26);
            this._btnRemoveHI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnRemoveHI.Name = "_btnRemoveHI";
            this._btnRemoveHI.Size = new System.Drawing.Size(106, 34);
            this._btnRemoveHI.TabIndex = 90;
            this._btnRemoveHI.Text = "Remove";
            this._btnRemoveHI.UseVisualStyleBackColor = true;
            this._btnRemoveHI.Click += new System.EventHandler(this._btnRemoveHI_Click);
            // 
            // _chkBxAutoFetchMac
            // 
            this._chkBxAutoFetchMac.AutoSize = true;
            this._chkBxAutoFetchMac.Location = new System.Drawing.Point(343, 296);
            this._chkBxAutoFetchMac.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._chkBxAutoFetchMac.Name = "_chkBxAutoFetchMac";
            this._chkBxAutoFetchMac.Size = new System.Drawing.Size(187, 21);
            this._chkBxAutoFetchMac.TabIndex = 70;
            this._chkBxAutoFetchMac.Text = "Auto fetch physical address";
            this._chkBxAutoFetchMac.UseVisualStyleBackColor = true;
            this._chkBxAutoFetchMac.Visible = false;
            // 
            // _tbxBuilding
            // 
            this._tbxBuilding.BackColor = System.Drawing.Color.White;
            this._tbxBuilding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxBuilding.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxBuilding.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._tbxBuilding.Location = new System.Drawing.Point(198, 122);
            this._tbxBuilding.Margin = new System.Windows.Forms.Padding(2, 3, 23, 3);
            this._tbxBuilding.Name = "_tbxBuilding";
            this._tbxBuilding.Size = new System.Drawing.Size(399, 29);
            this._tbxBuilding.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this.label1.Location = new System.Drawing.Point(7, 124);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 21);
            this.label1.TabIndex = 22;
            this.label1.Text = "Building";
            // 
            // _tbxCabinet
            // 
            this._tbxCabinet.BackColor = System.Drawing.Color.White;
            this._tbxCabinet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxCabinet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxCabinet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._tbxCabinet.Location = new System.Drawing.Point(198, 165);
            this._tbxCabinet.Margin = new System.Windows.Forms.Padding(2, 3, 23, 3);
            this._tbxCabinet.Name = "_tbxCabinet";
            this._tbxCabinet.Size = new System.Drawing.Size(399, 29);
            this._tbxCabinet.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this.label3.Location = new System.Drawing.Point(7, 167);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 21);
            this.label3.TabIndex = 22;
            this.label3.Text = "Cabinet";
            // 
            // _tbxRack
            // 
            this._tbxRack.BackColor = System.Drawing.Color.White;
            this._tbxRack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxRack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxRack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._tbxRack.Location = new System.Drawing.Point(198, 208);
            this._tbxRack.Margin = new System.Windows.Forms.Padding(2, 3, 23, 3);
            this._tbxRack.Name = "_tbxRack";
            this._tbxRack.Size = new System.Drawing.Size(399, 29);
            this._tbxRack.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this.label6.Location = new System.Drawing.Point(7, 211);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 21);
            this.label6.TabIndex = 22;
            this.label6.Text = "Rack";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._tbxDnsEntry);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this._tbxPhysicalAddress);
            this.groupBox1.Controls.Add(this._tbxHostDescription);
            this.groupBox1.Controls.Add(this._tbxBuilding);
            this.groupBox1.Controls.Add(this._tbxCabinet);
            this.groupBox1.Controls.Add(this._chkBxAutoFetchMac);
            this.groupBox1.Controls.Add(this._tbxRack);
            this.groupBox1.Controls.Add(this._chkBxIsMaintenanceActive);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(384, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(618, 340);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Host Information";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._lbxHIs);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(14, 16);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(363, 421);
            this.groupBox2.TabIndex = 73;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registered Hosts";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._btnSave);
            this.groupBox3.Controls.Add(this._btnAddHI);
            this.groupBox3.Controls.Add(this._btnImport);
            this.groupBox3.Controls.Add(this._btnRemoveHI);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.groupBox3.Location = new System.Drawing.Point(384, 364);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(618, 73);
            this.groupBox3.TabIndex = 74;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Add/Remove Hosts";
            // 
            // _btnSave
            // 
            this._btnSave.Enabled = false;
            this._btnSave.Location = new System.Drawing.Point(123, 26);
            this._btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(106, 34);
            this._btnSave.TabIndex = 80;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // _btnImport
            // 
            this._btnImport.Location = new System.Drawing.Point(506, 26);
            this._btnImport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnImport.Name = "_btnImport";
            this._btnImport.Size = new System.Drawing.Size(106, 34);
            this._btnImport.TabIndex = 90;
            this._btnImport.Text = "Import";
            this._btnImport.UseVisualStyleBackColor = true;
            this._btnImport.Click += new System.EventHandler(this._btnImport_Click);
            // 
            // frmManageHosts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1014, 487);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._btnOk);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmManageHosts";
            this.Text = "Manage Hosts";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.TextBox _tbxDnsEntry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _tbxPhysicalAddress;
        private System.Windows.Forms.TextBox _tbxHostDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox _chkBxIsMaintenanceActive;
        private System.Windows.Forms.ListBox _lbxHIs;
        private System.Windows.Forms.Button _btnAddHI;
        private System.Windows.Forms.Button _btnRemoveHI;
        private System.Windows.Forms.CheckBox _chkBxAutoFetchMac;
        private System.Windows.Forms.TextBox _tbxBuilding;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbxCabinet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _tbxRack;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Button _btnImport;
    }
}