namespace NetVulture
{
    partial class FrmManageHosts
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
            this._btnClose = new System.Windows.Forms.Button();
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
            this._gbxDeviceInfo = new System.Windows.Forms.GroupBox();
            this._nudPrioriyLevel = new System.Windows.Forms.NumericUpDown();
            this._tbxDeviceModel = new System.Windows.Forms.TextBox();
            this._tbxDeviceSerial = new System.Windows.Forms.TextBox();
            this._tbxDeviceVendor = new System.Windows.Forms.TextBox();
            this._tbxAlternativeAddress = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this._tbxComment = new System.Windows.Forms.TextBox();
            this._tbxVlanId = new System.Windows.Forms.TextBox();
            this._tbxConnectedTo = new System.Windows.Forms.TextBox();
            this._tbxPanel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._chkBxIsStatic = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnExport = new System.Windows.Forms.Button();
            this._btnImport = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._gbxDeviceInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudPrioriyLevel)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnClose
            // 
            this._btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnClose.Location = new System.Drawing.Point(571, 26);
            this._btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(106, 34);
            this._btnClose.TabIndex = 120;
            this._btnClose.Text = "Close";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _tbxDnsEntry
            // 
            this._tbxDnsEntry.BackColor = System.Drawing.Color.White;
            this._tbxDnsEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxDnsEntry.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxDnsEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._tbxDnsEntry.Location = new System.Drawing.Point(166, 25);
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
            this.label5.Location = new System.Drawing.Point(2, 441);
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
            this._tbxPhysicalAddress.Location = new System.Drawing.Point(166, 439);
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
            this._tbxHostDescription.Location = new System.Drawing.Point(166, 124);
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
            this.label4.Location = new System.Drawing.Point(2, 27);
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
            this.label2.Location = new System.Drawing.Point(2, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 21);
            this.label2.TabIndex = 22;
            this.label2.Text = "Description";
            // 
            // _chkBxIsMaintenanceActive
            // 
            this._chkBxIsMaintenanceActive.AutoSize = true;
            this._chkBxIsMaintenanceActive.Location = new System.Drawing.Point(166, 475);
            this._chkBxIsMaintenanceActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._chkBxIsMaintenanceActive.Name = "_chkBxIsMaintenanceActive";
            this._chkBxIsMaintenanceActive.Size = new System.Drawing.Size(101, 21);
            this._chkBxIsMaintenanceActive.TabIndex = 60;
            this._chkBxIsMaintenanceActive.Text = "Maintenance";
            this._chkBxIsMaintenanceActive.UseVisualStyleBackColor = true;
            // 
            // _lbxHIs
            // 
            this._lbxHIs.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lbxHIs.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._lbxHIs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._lbxHIs.FormattingEnabled = true;
            this._lbxHIs.ItemHeight = 21;
            this._lbxHIs.Location = new System.Drawing.Point(3, 22);
            this._lbxHIs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._lbxHIs.Name = "_lbxHIs";
            this._lbxHIs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this._lbxHIs.Size = new System.Drawing.Size(324, 597);
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
            this._chkBxAutoFetchMac.Location = new System.Drawing.Point(311, 475);
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
            this._tbxBuilding.Location = new System.Drawing.Point(166, 229);
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
            this.label1.Location = new System.Drawing.Point(2, 230);
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
            this._tbxCabinet.Location = new System.Drawing.Point(166, 264);
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
            this.label3.Location = new System.Drawing.Point(2, 265);
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
            this._tbxRack.Location = new System.Drawing.Point(166, 299);
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
            this.label6.Location = new System.Drawing.Point(2, 301);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 21);
            this.label6.TabIndex = 22;
            this.label6.Text = "Rack";
            // 
            // _gbxDeviceInfo
            // 
            this._gbxDeviceInfo.Controls.Add(this._nudPrioriyLevel);
            this._gbxDeviceInfo.Controls.Add(this._tbxDeviceModel);
            this._gbxDeviceInfo.Controls.Add(this._tbxDeviceSerial);
            this._gbxDeviceInfo.Controls.Add(this._tbxDeviceVendor);
            this._gbxDeviceInfo.Controls.Add(this._tbxAlternativeAddress);
            this._gbxDeviceInfo.Controls.Add(this._tbxDnsEntry);
            this._gbxDeviceInfo.Controls.Add(this.label15);
            this._gbxDeviceInfo.Controls.Add(this.label5);
            this._gbxDeviceInfo.Controls.Add(this._tbxComment);
            this._gbxDeviceInfo.Controls.Add(this._tbxPhysicalAddress);
            this._gbxDeviceInfo.Controls.Add(this._tbxHostDescription);
            this._gbxDeviceInfo.Controls.Add(this._tbxBuilding);
            this._gbxDeviceInfo.Controls.Add(this._tbxCabinet);
            this._gbxDeviceInfo.Controls.Add(this._chkBxAutoFetchMac);
            this._gbxDeviceInfo.Controls.Add(this._tbxVlanId);
            this._gbxDeviceInfo.Controls.Add(this._tbxConnectedTo);
            this._gbxDeviceInfo.Controls.Add(this._tbxPanel);
            this._gbxDeviceInfo.Controls.Add(this._tbxRack);
            this._gbxDeviceInfo.Controls.Add(this.label9);
            this._gbxDeviceInfo.Controls.Add(this.label8);
            this._gbxDeviceInfo.Controls.Add(this.label7);
            this._gbxDeviceInfo.Controls.Add(this._chkBxIsStatic);
            this._gbxDeviceInfo.Controls.Add(this._chkBxIsMaintenanceActive);
            this._gbxDeviceInfo.Controls.Add(this.label12);
            this._gbxDeviceInfo.Controls.Add(this.label11);
            this._gbxDeviceInfo.Controls.Add(this.label4);
            this._gbxDeviceInfo.Controls.Add(this.label10);
            this._gbxDeviceInfo.Controls.Add(this.label13);
            this._gbxDeviceInfo.Controls.Add(this.label14);
            this._gbxDeviceInfo.Controls.Add(this.label2);
            this._gbxDeviceInfo.Controls.Add(this.label6);
            this._gbxDeviceInfo.Controls.Add(this.label1);
            this._gbxDeviceInfo.Controls.Add(this.label3);
            this._gbxDeviceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxDeviceInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this._gbxDeviceInfo.Location = new System.Drawing.Point(339, 4);
            this._gbxDeviceInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._gbxDeviceInfo.Name = "_gbxDeviceInfo";
            this._gbxDeviceInfo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._gbxDeviceInfo.Size = new System.Drawing.Size(692, 543);
            this._gbxDeviceInfo.TabIndex = 72;
            this._gbxDeviceInfo.TabStop = false;
            this._gbxDeviceInfo.Text = "Device Information";
            // 
            // _nudPrioriyLevel
            // 
            this._nudPrioriyLevel.Location = new System.Drawing.Point(166, 95);
            this._nudPrioriyLevel.Name = "_nudPrioriyLevel";
            this._nudPrioriyLevel.Size = new System.Drawing.Size(120, 25);
            this._nudPrioriyLevel.TabIndex = 71;
            // 
            // _tbxDeviceModel
            // 
            this._tbxDeviceModel.BackColor = System.Drawing.Color.White;
            this._tbxDeviceModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxDeviceModel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxDeviceModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._tbxDeviceModel.Location = new System.Drawing.Point(389, 159);
            this._tbxDeviceModel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbxDeviceModel.Name = "_tbxDeviceModel";
            this._tbxDeviceModel.Size = new System.Drawing.Size(176, 29);
            this._tbxDeviceModel.TabIndex = 0;
            // 
            // _tbxDeviceSerial
            // 
            this._tbxDeviceSerial.BackColor = System.Drawing.Color.White;
            this._tbxDeviceSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxDeviceSerial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxDeviceSerial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._tbxDeviceSerial.Location = new System.Drawing.Point(166, 194);
            this._tbxDeviceSerial.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbxDeviceSerial.Name = "_tbxDeviceSerial";
            this._tbxDeviceSerial.Size = new System.Drawing.Size(161, 29);
            this._tbxDeviceSerial.TabIndex = 0;
            // 
            // _tbxDeviceVendor
            // 
            this._tbxDeviceVendor.BackColor = System.Drawing.Color.White;
            this._tbxDeviceVendor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxDeviceVendor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxDeviceVendor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._tbxDeviceVendor.Location = new System.Drawing.Point(166, 159);
            this._tbxDeviceVendor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbxDeviceVendor.Name = "_tbxDeviceVendor";
            this._tbxDeviceVendor.Size = new System.Drawing.Size(161, 29);
            this._tbxDeviceVendor.TabIndex = 0;
            // 
            // _tbxAlternativeAddress
            // 
            this._tbxAlternativeAddress.BackColor = System.Drawing.Color.White;
            this._tbxAlternativeAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxAlternativeAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxAlternativeAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._tbxAlternativeAddress.Location = new System.Drawing.Point(166, 60);
            this._tbxAlternativeAddress.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbxAlternativeAddress.Name = "_tbxAlternativeAddress";
            this._tbxAlternativeAddress.Size = new System.Drawing.Size(399, 29);
            this._tbxAlternativeAddress.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this.label15.Location = new System.Drawing.Point(2, 505);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 21);
            this.label15.TabIndex = 22;
            this.label15.Text = "Comment";
            // 
            // _tbxComment
            // 
            this._tbxComment.BackColor = System.Drawing.Color.White;
            this._tbxComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxComment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._tbxComment.Location = new System.Drawing.Point(166, 503);
            this._tbxComment.Margin = new System.Windows.Forms.Padding(2, 3, 23, 3);
            this._tbxComment.Name = "_tbxComment";
            this._tbxComment.Size = new System.Drawing.Size(399, 29);
            this._tbxComment.TabIndex = 50;
            // 
            // _tbxVlanId
            // 
            this._tbxVlanId.BackColor = System.Drawing.Color.White;
            this._tbxVlanId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxVlanId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxVlanId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._tbxVlanId.Location = new System.Drawing.Point(166, 404);
            this._tbxVlanId.Margin = new System.Windows.Forms.Padding(2, 3, 23, 3);
            this._tbxVlanId.Name = "_tbxVlanId";
            this._tbxVlanId.Size = new System.Drawing.Size(399, 29);
            this._tbxVlanId.TabIndex = 40;
            // 
            // _tbxConnectedTo
            // 
            this._tbxConnectedTo.BackColor = System.Drawing.Color.White;
            this._tbxConnectedTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxConnectedTo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxConnectedTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._tbxConnectedTo.Location = new System.Drawing.Point(166, 369);
            this._tbxConnectedTo.Margin = new System.Windows.Forms.Padding(2, 3, 23, 3);
            this._tbxConnectedTo.Name = "_tbxConnectedTo";
            this._tbxConnectedTo.Size = new System.Drawing.Size(399, 29);
            this._tbxConnectedTo.TabIndex = 40;
            // 
            // _tbxPanel
            // 
            this._tbxPanel.BackColor = System.Drawing.Color.White;
            this._tbxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._tbxPanel.Location = new System.Drawing.Point(166, 334);
            this._tbxPanel.Margin = new System.Windows.Forms.Padding(2, 3, 23, 3);
            this._tbxPanel.Name = "_tbxPanel";
            this._tbxPanel.Size = new System.Drawing.Size(399, 29);
            this._tbxPanel.TabIndex = 40;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this.label9.Location = new System.Drawing.Point(2, 196);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 21);
            this.label9.TabIndex = 22;
            this.label9.Text = "Device Serial";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this.label8.Location = new System.Drawing.Point(331, 161);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 21);
            this.label8.TabIndex = 22;
            this.label8.Text = "Model";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this.label7.Location = new System.Drawing.Point(2, 161);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 21);
            this.label7.TabIndex = 22;
            this.label7.Text = "Device Vendor";
            // 
            // _chkBxIsStatic
            // 
            this._chkBxIsStatic.AutoSize = true;
            this._chkBxIsStatic.Location = new System.Drawing.Point(389, 96);
            this._chkBxIsStatic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._chkBxIsStatic.Name = "_chkBxIsStatic";
            this._chkBxIsStatic.Size = new System.Drawing.Size(123, 21);
            this._chkBxIsStatic.TabIndex = 60;
            this._chkBxIsStatic.Text = "Is Static Address";
            this._chkBxIsStatic.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this.label12.Location = new System.Drawing.Point(2, 62);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(145, 21);
            this.label12.TabIndex = 22;
            this.label12.Text = "Alternative Address";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this.label11.Location = new System.Drawing.Point(2, 406);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 21);
            this.label11.TabIndex = 22;
            this.label11.Text = "Vlan ID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this.label10.Location = new System.Drawing.Point(2, 371);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 21);
            this.label10.TabIndex = 22;
            this.label10.Text = "Connected to";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this.label13.Location = new System.Drawing.Point(2, 336);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 21);
            this.label13.TabIndex = 22;
            this.label13.Text = "Panel";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this.label14.Location = new System.Drawing.Point(2, 94);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 21);
            this.label14.TabIndex = 22;
            this.label14.Text = "Priority Level";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._lbxHIs);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(3, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel.SetRowSpan(this.groupBox2, 2);
            this.groupBox2.Size = new System.Drawing.Size(330, 623);
            this.groupBox2.TabIndex = 73;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registered Hosts";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._btnSave);
            this.groupBox3.Controls.Add(this._btnClose);
            this.groupBox3.Controls.Add(this._btnAddHI);
            this.groupBox3.Controls.Add(this._btnExport);
            this.groupBox3.Controls.Add(this._btnImport);
            this.groupBox3.Controls.Add(this._btnRemoveHI);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.groupBox3.Location = new System.Drawing.Point(339, 555);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(692, 72);
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
            // _btnExport
            // 
            this._btnExport.Location = new System.Drawing.Point(459, 26);
            this._btnExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(106, 34);
            this._btnExport.TabIndex = 90;
            this._btnExport.Text = "Export";
            this._btnExport.UseVisualStyleBackColor = true;
            this._btnExport.Click += new System.EventHandler(this._btnExport_Click);
            // 
            // _btnImport
            // 
            this._btnImport.Location = new System.Drawing.Point(347, 26);
            this._btnImport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnImport.Name = "_btnImport";
            this._btnImport.Size = new System.Drawing.Size(106, 34);
            this._btnImport.TabIndex = 90;
            this._btnImport.Text = "Import";
            this._btnImport.UseVisualStyleBackColor = true;
            this._btnImport.Click += new System.EventHandler(this._btnImport_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.51136F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.48864F));
            this.tableLayoutPanel.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.groupBox3, 1, 1);
            this.tableLayoutPanel.Controls.Add(this._gbxDeviceInfo, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1034, 631);
            this.tableLayoutPanel.TabIndex = 121;
            // 
            // frmManageHosts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1034, 631);
            this.Controls.Add(this.tableLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1050, 670);
            this.Name = "FrmManageHosts";
            this.Text = "Manage Batch Devices";
            this._gbxDeviceInfo.ResumeLayout(false);
            this._gbxDeviceInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudPrioriyLevel)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _btnClose;
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
        private System.Windows.Forms.GroupBox _gbxDeviceInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Button _btnImport;
        private System.Windows.Forms.TextBox _tbxDeviceModel;
        private System.Windows.Forms.TextBox _tbxDeviceVendor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button _btnExport;
        private System.Windows.Forms.TextBox _tbxDeviceSerial;
        private System.Windows.Forms.TextBox _tbxAlternativeAddress;
        private System.Windows.Forms.TextBox _tbxVlanId;
        private System.Windows.Forms.TextBox _tbxConnectedTo;
        private System.Windows.Forms.TextBox _tbxPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox _chkBxIsStatic;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown _nudPrioriyLevel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox _tbxComment;
    }
}