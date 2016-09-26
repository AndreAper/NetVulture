namespace NetVulture
{
    partial class frmReport
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this._btnPingAll = new System.Windows.Forms.Button();
            this._btnExportCsv = new System.Windows.Forms.Button();
            this.BatchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostnameOrAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhysicalAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Roundtrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attempts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastExecution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ping = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._btnPingAll, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._btnExportCsv, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1373, 680);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BatchName,
            this.HostnameOrAddress,
            this.IPAddress,
            this.PhysicalAddress,
            this.IPStatus,
            this.Roundtrip,
            this.Attempts,
            this.LastExecution,
            this.Ping});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView, 6);
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView.Location = new System.Drawing.Point(3, 44);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView.RowHeadersWidth = 50;
            this.dataGridView.RowTemplate.Height = 30;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.Size = new System.Drawing.Size(1367, 606);
            this.dataGridView.TabIndex = 0;
            // 
            // _btnPingAll
            // 
            this._btnPingAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._btnPingAll.BackColor = System.Drawing.Color.DimGray;
            this._btnPingAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._btnPingAll.FlatAppearance.BorderSize = 0;
            this._btnPingAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnPingAll.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this._btnPingAll.ForeColor = System.Drawing.Color.WhiteSmoke;
            this._btnPingAll.Image = global::NetVulture.Properties.Resources.Refresh_32;
            this._btnPingAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnPingAll.Location = new System.Drawing.Point(0, 0);
            this._btnPingAll.Margin = new System.Windows.Forms.Padding(0);
            this._btnPingAll.Name = "_btnPingAll";
            this._btnPingAll.Size = new System.Drawing.Size(150, 40);
            this._btnPingAll.TabIndex = 6;
            this._btnPingAll.Text = "Ping All";
            this._btnPingAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._btnPingAll.UseVisualStyleBackColor = false;
            this._btnPingAll.Click += new System.EventHandler(this._btnPingAll_Click);
            // 
            // _btnExportCsv
            // 
            this._btnExportCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._btnExportCsv.BackColor = System.Drawing.Color.DimGray;
            this._btnExportCsv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._btnExportCsv.FlatAppearance.BorderSize = 0;
            this._btnExportCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnExportCsv.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this._btnExportCsv.ForeColor = System.Drawing.Color.WhiteSmoke;
            this._btnExportCsv.Image = global::NetVulture.Properties.Resources.CSV_32;
            this._btnExportCsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnExportCsv.Location = new System.Drawing.Point(150, 0);
            this._btnExportCsv.Margin = new System.Windows.Forms.Padding(0);
            this._btnExportCsv.Name = "_btnExportCsv";
            this._btnExportCsv.Size = new System.Drawing.Size(150, 40);
            this._btnExportCsv.TabIndex = 6;
            this._btnExportCsv.Text = "Export";
            this._btnExportCsv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._btnExportCsv.UseVisualStyleBackColor = false;
            this._btnExportCsv.Click += new System.EventHandler(this._btnExportCsv_Click);
            // 
            // BatchName
            // 
            this.BatchName.HeaderText = "Batch Name";
            this.BatchName.Name = "BatchName";
            // 
            // HostnameOrAddress
            // 
            this.HostnameOrAddress.HeaderText = "Hostname or Address";
            this.HostnameOrAddress.Name = "HostnameOrAddress";
            // 
            // IPAddress
            // 
            this.IPAddress.HeaderText = "IPAddress";
            this.IPAddress.Name = "IPAddress";
            // 
            // PhysicalAddress
            // 
            this.PhysicalAddress.HeaderText = "Physical Address";
            this.PhysicalAddress.Name = "PhysicalAddress";
            // 
            // IPStatus
            // 
            this.IPStatus.HeaderText = "IPStatus";
            this.IPStatus.Name = "IPStatus";
            // 
            // Roundtrip
            // 
            this.Roundtrip.HeaderText = "Roundtrip";
            this.Roundtrip.Name = "Roundtrip";
            // 
            // Attempts
            // 
            this.Attempts.HeaderText = "Attempts";
            this.Attempts.Name = "Attempts";
            // 
            // LastExecution
            // 
            this.LastExecution.HeaderText = "Last Execution";
            this.LastExecution.Name = "LastExecution";
            // 
            // Ping
            // 
            this.Ping.HeaderText = "Ping";
            this.Ping.Name = "Ping";
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1373, 680);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmReport";
            this.Text = "NetVulture";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button _btnPingAll;
        private System.Windows.Forms.Button _btnExportCsv;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchName;
        private System.Windows.Forms.DataGridViewTextBoxColumn HostnameOrAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhysicalAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Roundtrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attempts;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastExecution;
        private System.Windows.Forms.DataGridViewButtonColumn Ping;
    }
}