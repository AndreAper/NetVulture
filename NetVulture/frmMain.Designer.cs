namespace NetVulture
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this._tlpBody = new System.Windows.Forms.TableLayoutPanel();
            this._chkBtnTimerEnabled = new System.Windows.Forms.CheckBox();
            this._btnCollect = new System.Windows.Forms.Button();
            this._btnAddBatch = new System.Windows.Forms.Button();
            this._dgvResults = new System.Windows.Forms.DataGridView();
            this.Target = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoundTrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attempts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._tbxJobDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._btnShowReport = new System.Windows.Forms.Button();
            this._lblAppTitle = new System.Windows.Forms.Label();
            this._btnOpenSettings = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._tbxJobName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._pnlUnderlineMainMenu = new System.Windows.Forms.Panel();
            this._flpBatchList = new System.Windows.Forms.FlowLayoutPanel();
            this._pnlSubMenuBatch = new System.Windows.Forms.Panel();
            this._btnEditHostList = new System.Windows.Forms.Button();
            this._btnRunSelectedBatch = new System.Windows.Forms.Button();
            this._RemoveSelectedBatch = new System.Windows.Forms.Button();
            this._pnlUnderlinSubmenuForBatch = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this._lblCountOfFailedRequests = new System.Windows.Forms.Label();
            this._lblCountOfSuccessRequests = new System.Windows.Forms.Label();
            this._lblLastBatchExec = new System.Windows.Forms.Label();
            this._lblLastCollect = new System.Windows.Forms.Label();
            this._lblEmailAlertingStatus = new System.Windows.Forms.Label();
            this._lblSmsAlertingStatus = new System.Windows.Forms.Label();
            this._lblClock = new System.Windows.Forms.Label();
            this._lblOutputDir = new System.Windows.Forms.Label();
            this._collectTimer = new System.Windows.Forms.Timer(this.components);
            this._clock = new System.Windows.Forms.Timer(this.components);
            this._tlpBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvResults)).BeginInit();
            this._pnlSubMenuBatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tlpBody
            // 
            this._tlpBody.BackColor = System.Drawing.Color.White;
            this._tlpBody.ColumnCount = 7;
            this._tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this._tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this._tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this._tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this._tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this._tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this._tlpBody.Controls.Add(this._chkBtnTimerEnabled, 1, 0);
            this._tlpBody.Controls.Add(this._btnCollect, 4, 0);
            this._tlpBody.Controls.Add(this._btnAddBatch, 2, 0);
            this._tlpBody.Controls.Add(this._dgvResults, 2, 5);
            this._tlpBody.Controls.Add(this.label4, 1, 5);
            this._tlpBody.Controls.Add(this._btnShowReport, 3, 0);
            this._tlpBody.Controls.Add(this._lblAppTitle, 0, 0);
            this._tlpBody.Controls.Add(this._btnOpenSettings, 5, 0);
            this._tlpBody.Controls.Add(this._tbxJobName, 2, 4);
            this._tlpBody.Controls.Add(this.label1, 1, 4);
            this._tlpBody.Controls.Add(this._pnlUnderlineMainMenu, 0, 1);
            this._tlpBody.Controls.Add(this._flpBatchList, 0, 2);
            this._tlpBody.Controls.Add(this._pnlSubMenuBatch, 1, 2);
            this._tlpBody.Controls.Add(this._pnlUnderlinSubmenuForBatch, 1, 3);
            this._tlpBody.Controls.Add(this.panel1, 6, 0);
            this._tlpBody.Controls.Add(this._lblCountOfFailedRequests, 4, 8);
            this._tlpBody.Controls.Add(this._lblCountOfSuccessRequests, 3, 8);
            this._tlpBody.Controls.Add(this._lblLastBatchExec, 2, 8);
            this._tlpBody.Controls.Add(this._lblLastCollect, 1, 9);
            this._tlpBody.Controls.Add(this._lblEmailAlertingStatus, 2, 9);
            this._tlpBody.Controls.Add(this._lblSmsAlertingStatus, 3, 9);
            this._tlpBody.Controls.Add(this._lblClock, 4, 9);
            this._tlpBody.Controls.Add(this._lblOutputDir, 6, 9);
            this._tlpBody.Controls.Add(this.label2, 4, 4);
            this._tlpBody.Controls.Add(this._tbxJobDescription, 5, 4);
            this._tlpBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpBody.Location = new System.Drawing.Point(0, 0);
            this._tlpBody.Name = "_tlpBody";
            this._tlpBody.RowCount = 10;
            this._tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this._tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this._tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this._tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this._tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this._tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.01295F));
            this._tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.45106F));
            this._tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.53599F));
            this._tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this._tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tlpBody.Size = new System.Drawing.Size(1408, 709);
            this._tlpBody.TabIndex = 0;
            // 
            // _chkBtnTimerEnabled
            // 
            this._chkBtnTimerEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._chkBtnTimerEnabled.Appearance = System.Windows.Forms.Appearance.Button;
            this._chkBtnTimerEnabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(60)))));
            this._chkBtnTimerEnabled.FlatAppearance.BorderSize = 0;
            this._chkBtnTimerEnabled.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(185)))), ((int)(((byte)(40)))));
            this._chkBtnTimerEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._chkBtnTimerEnabled.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this._chkBtnTimerEnabled.ForeColor = System.Drawing.Color.White;
            this._chkBtnTimerEnabled.Image = global::NetVulture.Properties.Resources.Clock_32;
            this._chkBtnTimerEnabled.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._chkBtnTimerEnabled.Location = new System.Drawing.Point(164, 0);
            this._chkBtnTimerEnabled.Margin = new System.Windows.Forms.Padding(0);
            this._chkBtnTimerEnabled.Name = "_chkBtnTimerEnabled";
            this._chkBtnTimerEnabled.Size = new System.Drawing.Size(150, 40);
            this._chkBtnTimerEnabled.TabIndex = 61;
            this._chkBtnTimerEnabled.Text = "Timer Disabled";
            this._chkBtnTimerEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._chkBtnTimerEnabled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._chkBtnTimerEnabled.UseVisualStyleBackColor = false;
            this._chkBtnTimerEnabled.CheckedChanged += new System.EventHandler(this._chkBtnTimerEnabled_CheckedChanged);
            // 
            // _btnCollect
            // 
            this._btnCollect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCollect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._btnCollect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._btnCollect.FlatAppearance.BorderSize = 0;
            this._btnCollect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCollect.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this._btnCollect.ForeColor = System.Drawing.Color.White;
            this._btnCollect.Image = global::NetVulture.Properties.Resources.Collect_32;
            this._btnCollect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnCollect.Location = new System.Drawing.Point(614, 0);
            this._btnCollect.Margin = new System.Windows.Forms.Padding(0);
            this._btnCollect.Name = "_btnCollect";
            this._btnCollect.Size = new System.Drawing.Size(150, 40);
            this._btnCollect.TabIndex = 5;
            this._btnCollect.Text = "Collect";
            this._btnCollect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._btnCollect.UseVisualStyleBackColor = false;
            this._btnCollect.Click += new System.EventHandler(this._btnCollect_Click);
            // 
            // _btnAddBatch
            // 
            this._btnAddBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAddBatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._btnAddBatch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._btnAddBatch.FlatAppearance.BorderSize = 0;
            this._btnAddBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAddBatch.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this._btnAddBatch.ForeColor = System.Drawing.Color.White;
            this._btnAddBatch.Image = global::NetVulture.Properties.Resources.Plus_32;
            this._btnAddBatch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnAddBatch.Location = new System.Drawing.Point(314, 0);
            this._btnAddBatch.Margin = new System.Windows.Forms.Padding(0);
            this._btnAddBatch.Name = "_btnAddBatch";
            this._btnAddBatch.Size = new System.Drawing.Size(150, 40);
            this._btnAddBatch.TabIndex = 5;
            this._btnAddBatch.Text = "Add Batch";
            this._btnAddBatch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._btnAddBatch.UseVisualStyleBackColor = false;
            this._btnAddBatch.Click += new System.EventHandler(this._btnAddBatch_Click);
            // 
            // _dgvResults
            // 
            this._dgvResults.AllowUserToAddRows = false;
            this._dgvResults.AllowUserToDeleteRows = false;
            this._dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvResults.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Target,
            this.Address,
            this.RoundTrip,
            this.Time,
            this.Status,
            this.Attempts});
            this._tlpBody.SetColumnSpan(this._dgvResults, 5);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(90)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvResults.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvResults.Enabled = false;
            this._dgvResults.Location = new System.Drawing.Point(317, 148);
            this._dgvResults.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this._dgvResults.Name = "_dgvResults";
            this._dgvResults.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvResults.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this._tlpBody.SetRowSpan(this._dgvResults, 3);
            this._dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvResults.Size = new System.Drawing.Size(1071, 443);
            this._dgvResults.TabIndex = 4;
            // 
            // Target
            // 
            this.Target.HeaderText = "Target";
            this.Target.Name = "Target";
            this.Target.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // RoundTrip
            // 
            this.RoundTrip.HeaderText = "RoundTrip (ms)";
            this.RoundTrip.Name = "RoundTrip";
            this.RoundTrip.ReadOnly = true;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Attempts
            // 
            this.Attempts.HeaderText = "Attempts";
            this.Attempts.Name = "Attempts";
            this.Attempts.ReadOnly = true;
            // 
            // _tbxJobDescription
            // 
            this._tbxJobDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._tbxJobDescription.BackColor = System.Drawing.Color.White;
            this._tbxJobDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tlpBody.SetColumnSpan(this._tbxJobDescription, 2);
            this._tbxJobDescription.Enabled = false;
            this._tbxJobDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxJobDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._tbxJobDescription.Location = new System.Drawing.Point(766, 105);
            this._tbxJobDescription.Margin = new System.Windows.Forms.Padding(2, 2, 20, 2);
            this._tbxJobDescription.Name = "_tbxJobDescription";
            this._tbxJobDescription.Size = new System.Drawing.Size(622, 29);
            this._tbxJobDescription.TabIndex = 20;
            this._tbxJobDescription.TextChanged += new System.EventHandler(this._tbxJobDescription_TextChanged);
            this._tbxJobDescription.Leave += new System.EventHandler(this._tbxJobDescription_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this.label4.Location = new System.Drawing.Point(166, 147);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Output";
            // 
            // _btnShowReport
            // 
            this._btnShowReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._btnShowReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._btnShowReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._btnShowReport.FlatAppearance.BorderSize = 0;
            this._btnShowReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnShowReport.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this._btnShowReport.ForeColor = System.Drawing.Color.White;
            this._btnShowReport.Image = global::NetVulture.Properties.Resources.Details_32;
            this._btnShowReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnShowReport.Location = new System.Drawing.Point(464, 0);
            this._btnShowReport.Margin = new System.Windows.Forms.Padding(0);
            this._btnShowReport.Name = "_btnShowReport";
            this._btnShowReport.Size = new System.Drawing.Size(150, 40);
            this._btnShowReport.TabIndex = 5;
            this._btnShowReport.Text = "Report";
            this._btnShowReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._btnShowReport.UseVisualStyleBackColor = false;
            this._btnShowReport.Click += new System.EventHandler(this._btnShowReport_Click);
            // 
            // _lblAppTitle
            // 
            this._lblAppTitle.AutoSize = true;
            this._lblAppTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._lblAppTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblAppTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblAppTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this._lblAppTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._lblAppTitle.Location = new System.Drawing.Point(0, 0);
            this._lblAppTitle.Margin = new System.Windows.Forms.Padding(0);
            this._lblAppTitle.Name = "_lblAppTitle";
            this._lblAppTitle.Size = new System.Drawing.Size(164, 40);
            this._lblAppTitle.TabIndex = 2;
            this._lblAppTitle.Text = "NetVulture";
            this._lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _btnOpenSettings
            // 
            this._btnOpenSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOpenSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._btnOpenSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._btnOpenSettings.FlatAppearance.BorderSize = 0;
            this._btnOpenSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnOpenSettings.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._btnOpenSettings.ForeColor = System.Drawing.Color.White;
            this._btnOpenSettings.Image = global::NetVulture.Properties.Resources.Settings_32;
            this._btnOpenSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnOpenSettings.Location = new System.Drawing.Point(764, 0);
            this._btnOpenSettings.Margin = new System.Windows.Forms.Padding(0);
            this._btnOpenSettings.Name = "_btnOpenSettings";
            this._btnOpenSettings.Size = new System.Drawing.Size(150, 40);
            this._btnOpenSettings.TabIndex = 5;
            this._btnOpenSettings.Text = "Settings";
            this._btnOpenSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._btnOpenSettings.UseVisualStyleBackColor = false;
            this._btnOpenSettings.Click += new System.EventHandler(this._btnOpenSettings_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this.label2.Location = new System.Drawing.Point(616, 109);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Description";
            // 
            // _tbxJobName
            // 
            this._tbxJobName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._tbxJobName.BackColor = System.Drawing.Color.White;
            this._tbxJobName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tlpBody.SetColumnSpan(this._tbxJobName, 2);
            this._tbxJobName.Enabled = false;
            this._tbxJobName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxJobName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._tbxJobName.Location = new System.Drawing.Point(316, 105);
            this._tbxJobName.Margin = new System.Windows.Forms.Padding(2);
            this._tbxJobName.Name = "_tbxJobName";
            this._tbxJobName.Size = new System.Drawing.Size(296, 29);
            this._tbxJobName.TabIndex = 10;
            this._tbxJobName.TextChanged += new System.EventHandler(this._tbxJobName_TextChanged);
            this._tbxJobName.Leave += new System.EventHandler(this._tbxJobName_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this.label1.Location = new System.Drawing.Point(166, 109);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // _pnlUnderlineMainMenu
            // 
            this._pnlUnderlineMainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlUnderlineMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(120)))));
            this._tlpBody.SetColumnSpan(this._pnlUnderlineMainMenu, 7);
            this._pnlUnderlineMainMenu.Location = new System.Drawing.Point(0, 40);
            this._pnlUnderlineMainMenu.Margin = new System.Windows.Forms.Padding(0);
            this._pnlUnderlineMainMenu.Name = "_pnlUnderlineMainMenu";
            this._pnlUnderlineMainMenu.Size = new System.Drawing.Size(1408, 5);
            this._pnlUnderlineMainMenu.TabIndex = 62;
            // 
            // _flpBatchList
            // 
            this._flpBatchList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this._flpBatchList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpBatchList.Location = new System.Drawing.Point(0, 45);
            this._flpBatchList.Margin = new System.Windows.Forms.Padding(0);
            this._flpBatchList.Name = "_flpBatchList";
            this._tlpBody.SetRowSpan(this._flpBatchList, 8);
            this._flpBatchList.Size = new System.Drawing.Size(164, 664);
            this._flpBatchList.TabIndex = 64;
            // 
            // _pnlSubMenuBatch
            // 
            this._pnlSubMenuBatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this._tlpBody.SetColumnSpan(this._pnlSubMenuBatch, 6);
            this._pnlSubMenuBatch.Controls.Add(this._btnEditHostList);
            this._pnlSubMenuBatch.Controls.Add(this._btnRunSelectedBatch);
            this._pnlSubMenuBatch.Controls.Add(this._RemoveSelectedBatch);
            this._pnlSubMenuBatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlSubMenuBatch.Enabled = false;
            this._pnlSubMenuBatch.Location = new System.Drawing.Point(164, 45);
            this._pnlSubMenuBatch.Margin = new System.Windows.Forms.Padding(0);
            this._pnlSubMenuBatch.Name = "_pnlSubMenuBatch";
            this._pnlSubMenuBatch.Size = new System.Drawing.Size(1244, 40);
            this._pnlSubMenuBatch.TabIndex = 32;
            // 
            // _btnEditHostList
            // 
            this._btnEditHostList.BackColor = System.Drawing.Color.Transparent;
            this._btnEditHostList.FlatAppearance.BorderSize = 0;
            this._btnEditHostList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnEditHostList.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this._btnEditHostList.Image = global::NetVulture.Properties.Resources.Todo_List_32;
            this._btnEditHostList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnEditHostList.Location = new System.Drawing.Point(150, 0);
            this._btnEditHostList.Margin = new System.Windows.Forms.Padding(0);
            this._btnEditHostList.Name = "_btnEditHostList";
            this._btnEditHostList.Size = new System.Drawing.Size(150, 40);
            this._btnEditHostList.TabIndex = 31;
            this._btnEditHostList.Text = "Edit Hostlist";
            this._btnEditHostList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._btnEditHostList.UseVisualStyleBackColor = false;
            this._btnEditHostList.Click += new System.EventHandler(this._btnEditHostList_Click);
            // 
            // _btnRunSelectedBatch
            // 
            this._btnRunSelectedBatch.BackColor = System.Drawing.Color.Transparent;
            this._btnRunSelectedBatch.FlatAppearance.BorderSize = 0;
            this._btnRunSelectedBatch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(185)))), ((int)(((byte)(40)))));
            this._btnRunSelectedBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnRunSelectedBatch.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this._btnRunSelectedBatch.Image = global::NetVulture.Properties.Resources.Running_321;
            this._btnRunSelectedBatch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnRunSelectedBatch.Location = new System.Drawing.Point(0, 0);
            this._btnRunSelectedBatch.Margin = new System.Windows.Forms.Padding(0);
            this._btnRunSelectedBatch.Name = "_btnRunSelectedBatch";
            this._btnRunSelectedBatch.Size = new System.Drawing.Size(150, 40);
            this._btnRunSelectedBatch.TabIndex = 31;
            this._btnRunSelectedBatch.Text = "Run Batch";
            this._btnRunSelectedBatch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._btnRunSelectedBatch.UseVisualStyleBackColor = false;
            this._btnRunSelectedBatch.Click += new System.EventHandler(this._btnRunSelectedBatch_Click);
            // 
            // _RemoveSelectedBatch
            // 
            this._RemoveSelectedBatch.BackColor = System.Drawing.Color.Transparent;
            this._RemoveSelectedBatch.FlatAppearance.BorderSize = 0;
            this._RemoveSelectedBatch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(60)))));
            this._RemoveSelectedBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._RemoveSelectedBatch.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this._RemoveSelectedBatch.ForeColor = System.Drawing.Color.Black;
            this._RemoveSelectedBatch.Image = global::NetVulture.Properties.Resources.Delete_32;
            this._RemoveSelectedBatch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._RemoveSelectedBatch.Location = new System.Drawing.Point(300, 0);
            this._RemoveSelectedBatch.Margin = new System.Windows.Forms.Padding(0);
            this._RemoveSelectedBatch.Name = "_RemoveSelectedBatch";
            this._RemoveSelectedBatch.Size = new System.Drawing.Size(150, 40);
            this._RemoveSelectedBatch.TabIndex = 31;
            this._RemoveSelectedBatch.Text = "Remove";
            this._RemoveSelectedBatch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._RemoveSelectedBatch.UseVisualStyleBackColor = false;
            this._RemoveSelectedBatch.Click += new System.EventHandler(this._RemoveSelectedBatch_Click);
            // 
            // _pnlUnderlinSubmenuForBatch
            // 
            this._pnlUnderlinSubmenuForBatch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlUnderlinSubmenuForBatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this._tlpBody.SetColumnSpan(this._pnlUnderlinSubmenuForBatch, 6);
            this._pnlUnderlinSubmenuForBatch.Location = new System.Drawing.Point(164, 85);
            this._pnlUnderlinSubmenuForBatch.Margin = new System.Windows.Forms.Padding(0);
            this._pnlUnderlinSubmenuForBatch.Name = "_pnlUnderlinSubmenuForBatch";
            this._pnlUnderlinSubmenuForBatch.Size = new System.Drawing.Size(1244, 2);
            this._pnlUnderlinSubmenuForBatch.TabIndex = 62;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(914, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 40);
            this.panel1.TabIndex = 65;
            // 
            // _lblCountOfFailedRequests
            // 
            this._lblCountOfFailedRequests.AutoSize = true;
            this._lblCountOfFailedRequests.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._lblCountOfFailedRequests.ForeColor = System.Drawing.Color.Crimson;
            this._lblCountOfFailedRequests.Location = new System.Drawing.Point(616, 596);
            this._lblCountOfFailedRequests.Margin = new System.Windows.Forms.Padding(2);
            this._lblCountOfFailedRequests.Name = "_lblCountOfFailedRequests";
            this._lblCountOfFailedRequests.Size = new System.Drawing.Size(120, 21);
            this._lblCountOfFailedRequests.TabIndex = 0;
            this._lblCountOfFailedRequests.Text = "Failed Requests:";
            // 
            // _lblCountOfSuccessRequests
            // 
            this._lblCountOfSuccessRequests.AutoSize = true;
            this._lblCountOfSuccessRequests.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._lblCountOfSuccessRequests.ForeColor = System.Drawing.Color.OliveDrab;
            this._lblCountOfSuccessRequests.Location = new System.Drawing.Point(466, 596);
            this._lblCountOfSuccessRequests.Margin = new System.Windows.Forms.Padding(2);
            this._lblCountOfSuccessRequests.Name = "_lblCountOfSuccessRequests";
            this._lblCountOfSuccessRequests.Size = new System.Drawing.Size(134, 21);
            this._lblCountOfSuccessRequests.TabIndex = 0;
            this._lblCountOfSuccessRequests.Text = "Success Requests:";
            // 
            // _lblLastBatchExec
            // 
            this._lblLastBatchExec.AutoSize = true;
            this._lblLastBatchExec.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._lblLastBatchExec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._lblLastBatchExec.Location = new System.Drawing.Point(316, 596);
            this._lblLastBatchExec.Margin = new System.Windows.Forms.Padding(2);
            this._lblLastBatchExec.Name = "_lblLastBatchExec";
            this._lblLastBatchExec.Size = new System.Drawing.Size(115, 21);
            this._lblLastBatchExec.TabIndex = 0;
            this._lblLastBatchExec.Text = "Last execution: ";
            // 
            // _lblLastCollect
            // 
            this._lblLastCollect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lblLastCollect.AutoSize = true;
            this._lblLastCollect.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblLastCollect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._lblLastCollect.Location = new System.Drawing.Point(166, 669);
            this._lblLastCollect.Margin = new System.Windows.Forms.Padding(2);
            this._lblLastCollect.Name = "_lblLastCollect";
            this._lblLastCollect.Size = new System.Drawing.Size(146, 38);
            this._lblLastCollect.TabIndex = 0;
            this._lblLastCollect.Text = "Last Execution: ";
            // 
            // _lblEmailAlertingStatus
            // 
            this._lblEmailAlertingStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lblEmailAlertingStatus.AutoSize = true;
            this._lblEmailAlertingStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmailAlertingStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._lblEmailAlertingStatus.Location = new System.Drawing.Point(316, 669);
            this._lblEmailAlertingStatus.Margin = new System.Windows.Forms.Padding(2);
            this._lblEmailAlertingStatus.Name = "_lblEmailAlertingStatus";
            this._lblEmailAlertingStatus.Size = new System.Drawing.Size(146, 38);
            this._lblEmailAlertingStatus.TabIndex = 0;
            this._lblEmailAlertingStatus.Text = "Email Alerting Status:";
            // 
            // _lblSmsAlertingStatus
            // 
            this._lblSmsAlertingStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lblSmsAlertingStatus.AutoSize = true;
            this._lblSmsAlertingStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblSmsAlertingStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._lblSmsAlertingStatus.Location = new System.Drawing.Point(466, 669);
            this._lblSmsAlertingStatus.Margin = new System.Windows.Forms.Padding(2);
            this._lblSmsAlertingStatus.Name = "_lblSmsAlertingStatus";
            this._lblSmsAlertingStatus.Size = new System.Drawing.Size(146, 38);
            this._lblSmsAlertingStatus.TabIndex = 0;
            this._lblSmsAlertingStatus.Text = "SMS Alerting Status:";
            // 
            // _lblClock
            // 
            this._lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lblClock.AutoSize = true;
            this._lblClock.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this._lblClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._lblClock.Location = new System.Drawing.Point(616, 667);
            this._lblClock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._lblClock.Name = "_lblClock";
            this._lblClock.Size = new System.Drawing.Size(146, 42);
            this._lblClock.TabIndex = 61;
            this._lblClock.Text = "Systemtime";
            // 
            // _lblOutputDir
            // 
            this._lblOutputDir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lblOutputDir.AutoSize = true;
            this._lblOutputDir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblOutputDir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this._lblOutputDir.Location = new System.Drawing.Point(916, 669);
            this._lblOutputDir.Margin = new System.Windows.Forms.Padding(2);
            this._lblOutputDir.Name = "_lblOutputDir";
            this._lblOutputDir.Size = new System.Drawing.Size(490, 38);
            this._lblOutputDir.TabIndex = 0;
            this._lblOutputDir.Text = "Output: ";
            this._lblOutputDir.Click += new System.EventHandler(this._lblOutputDir_Click);
            // 
            // _collectTimer
            // 
            this._collectTimer.Interval = 60000;
            this._collectTimer.Tick += new System.EventHandler(this._collectTimer_Tick);
            // 
            // _clock
            // 
            this._clock.Enabled = true;
            this._clock.Interval = 1000;
            this._clock.Tick += new System.EventHandler(this._clock_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 709);
            this.Controls.Add(this._tlpBody);
            this.MinimumSize = new System.Drawing.Size(1000, 575);
            this.Name = "frmMain";
            this.Text = "NetVulture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this._tlpBody.ResumeLayout(false);
            this._tlpBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvResults)).EndInit();
            this._pnlSubMenuBatch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tlpBody;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbxJobName;
        private System.Windows.Forms.TextBox _tbxJobDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView _dgvResults;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label _lblAppTitle;
        private System.Windows.Forms.Button _btnCollect;
        private System.Windows.Forms.Button _btnOpenSettings;
        private System.Windows.Forms.Label _lblOutputDir;
        private System.Windows.Forms.Button _btnAddBatch;
        private System.Windows.Forms.Timer _collectTimer;
        private System.Windows.Forms.Label _lblLastCollect;
        private System.Windows.Forms.CheckBox _chkBtnTimerEnabled;
        private System.Windows.Forms.Label _lblLastBatchExec;
        private System.Windows.Forms.Label _lblClock;
        private System.Windows.Forms.Timer _clock;
        private System.Windows.Forms.Label _lblCountOfFailedRequests;
        private System.Windows.Forms.Label _lblSmsAlertingStatus;
        private System.Windows.Forms.Label _lblEmailAlertingStatus;
        private System.Windows.Forms.Label _lblCountOfSuccessRequests;
        private System.Windows.Forms.Button _btnShowReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Target;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoundTrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attempts;
        private System.Windows.Forms.Panel _pnlUnderlineMainMenu;
        private System.Windows.Forms.FlowLayoutPanel _flpBatchList;
        private System.Windows.Forms.Button _btnRunSelectedBatch;
        private System.Windows.Forms.Panel _pnlSubMenuBatch;
        private System.Windows.Forms.Button _RemoveSelectedBatch;
        private System.Windows.Forms.Button _btnEditHostList;
        private System.Windows.Forms.Panel _pnlUnderlinSubmenuForBatch;
        private System.Windows.Forms.Panel panel1;
    }
}

