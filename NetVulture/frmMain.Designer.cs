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
            this._tlpBody = new System.Windows.Forms.TableLayoutPanel();
            this._lbxJobs = new System.Windows.Forms.ListBox();
            this._pnlJobInfo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this._lblCountOfFailedRequests = new System.Windows.Forms.Label();
            this._lblFirstAlertTime = new System.Windows.Forms.Label();
            this._lblSecondAlertTime = new System.Windows.Forms.Label();
            this._lblOverallPingAttempts = new System.Windows.Forms.Label();
            this._lnkLblResetAttemptCounter = new System.Windows.Forms.LinkLabel();
            this._lblLastBatchExec = new System.Windows.Forms.Label();
            this._btnRemoveBatch = new System.Windows.Forms.Button();
            this._btnExecBatch = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this._lnkLblChangeHostList = new System.Windows.Forms.LinkLabel();
            this._lbxHostList = new System.Windows.Forms.ListBox();
            this._tbxJobDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._tbxBufferSize = new System.Windows.Forms.TextBox();
            this._tbxTimeOut = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._tbxJobName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._pnlTopMenu = new System.Windows.Forms.Panel();
            this._lblClock = new System.Windows.Forms.Label();
            this._chkBtnTimerEnabled = new System.Windows.Forms.CheckBox();
            this._btnOpenSettings = new System.Windows.Forms.Button();
            this._btnAddBatch = new System.Windows.Forms.Button();
            this._btnCollect = new System.Windows.Forms.Button();
            this._pnlButtom = new System.Windows.Forms.Panel();
            this._lblLastCollect = new System.Windows.Forms.Label();
            this._lblOutputDir = new System.Windows.Forms.Label();
            this._collectTimer = new System.Windows.Forms.Timer(this.components);
            this._clock = new System.Windows.Forms.Timer(this.components);
            this.Target = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoundTrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._tlpBody.SuspendLayout();
            this._pnlJobInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this._pnlTopMenu.SuspendLayout();
            this._pnlButtom.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tlpBody
            // 
            this._tlpBody.BackColor = System.Drawing.Color.WhiteSmoke;
            this._tlpBody.ColumnCount = 2;
            this._tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this._tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpBody.Controls.Add(this._lbxJobs, 0, 1);
            this._tlpBody.Controls.Add(this._pnlJobInfo, 1, 1);
            this._tlpBody.Controls.Add(this.label5, 0, 0);
            this._tlpBody.Controls.Add(this._pnlTopMenu, 1, 0);
            this._tlpBody.Controls.Add(this._pnlButtom, 1, 2);
            this._tlpBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpBody.Location = new System.Drawing.Point(0, 0);
            this._tlpBody.Name = "_tlpBody";
            this._tlpBody.RowCount = 3;
            this._tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this._tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this._tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tlpBody.Size = new System.Drawing.Size(942, 528);
            this._tlpBody.TabIndex = 0;
            // 
            // _lbxJobs
            // 
            this._lbxJobs.BackColor = System.Drawing.Color.Gray;
            this._lbxJobs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._lbxJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lbxJobs.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbxJobs.ForeColor = System.Drawing.Color.WhiteSmoke;
            this._lbxJobs.FormattingEnabled = true;
            this._lbxJobs.ItemHeight = 25;
            this._lbxJobs.Items.AddRange(new object[] {
            "Host 1",
            "Host 2"});
            this._lbxJobs.Location = new System.Drawing.Point(0, 41);
            this._lbxJobs.Margin = new System.Windows.Forms.Padding(0);
            this._lbxJobs.Name = "_lbxJobs";
            this._tlpBody.SetRowSpan(this._lbxJobs, 2);
            this._lbxJobs.Size = new System.Drawing.Size(178, 487);
            this._lbxJobs.TabIndex = 0;
            this._lbxJobs.SelectedIndexChanged += new System.EventHandler(this._lbxJobs_SelectedIndexChanged);
            // 
            // _pnlJobInfo
            // 
            this._pnlJobInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this._pnlJobInfo.Controls.Add(this.panel1);
            this._pnlJobInfo.Controls.Add(this._lnkLblResetAttemptCounter);
            this._pnlJobInfo.Controls.Add(this._lblLastBatchExec);
            this._pnlJobInfo.Controls.Add(this._btnRemoveBatch);
            this._pnlJobInfo.Controls.Add(this._btnExecBatch);
            this._pnlJobInfo.Controls.Add(this.dgvResults);
            this._pnlJobInfo.Controls.Add(this._lnkLblChangeHostList);
            this._pnlJobInfo.Controls.Add(this._lbxHostList);
            this._pnlJobInfo.Controls.Add(this._tbxJobDescription);
            this._pnlJobInfo.Controls.Add(this.label4);
            this._pnlJobInfo.Controls.Add(this.label3);
            this._pnlJobInfo.Controls.Add(this.label2);
            this._pnlJobInfo.Controls.Add(this._tbxBufferSize);
            this._pnlJobInfo.Controls.Add(this._tbxTimeOut);
            this._pnlJobInfo.Controls.Add(this.label7);
            this._pnlJobInfo.Controls.Add(this.label6);
            this._pnlJobInfo.Controls.Add(this.label8);
            this._pnlJobInfo.Controls.Add(this._tbxJobName);
            this._pnlJobInfo.Controls.Add(this.label1);
            this._pnlJobInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlJobInfo.Location = new System.Drawing.Point(178, 41);
            this._pnlJobInfo.Margin = new System.Windows.Forms.Padding(0);
            this._pnlJobInfo.Name = "_pnlJobInfo";
            this._pnlJobInfo.Size = new System.Drawing.Size(764, 439);
            this._pnlJobInfo.TabIndex = 1;
            this._pnlJobInfo.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this._lblCountOfFailedRequests);
            this.panel1.Controls.Add(this._lblFirstAlertTime);
            this.panel1.Controls.Add(this._lblSecondAlertTime);
            this.panel1.Controls.Add(this._lblOverallPingAttempts);
            this.panel1.Location = new System.Drawing.Point(471, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 127);
            this.panel1.TabIndex = 62;
            // 
            // _lblCountOfFailedRequests
            // 
            this._lblCountOfFailedRequests.AutoSize = true;
            this._lblCountOfFailedRequests.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblCountOfFailedRequests.ForeColor = System.Drawing.Color.Black;
            this._lblCountOfFailedRequests.Location = new System.Drawing.Point(2, 2);
            this._lblCountOfFailedRequests.Margin = new System.Windows.Forms.Padding(2);
            this._lblCountOfFailedRequests.Name = "_lblCountOfFailedRequests";
            this._lblCountOfFailedRequests.Size = new System.Drawing.Size(133, 21);
            this._lblCountOfFailedRequests.TabIndex = 0;
            this._lblCountOfFailedRequests.Text = "Failed Requests: 0";
            // 
            // _lblFirstAlertTime
            // 
            this._lblFirstAlertTime.AutoSize = true;
            this._lblFirstAlertTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblFirstAlertTime.ForeColor = System.Drawing.Color.Black;
            this._lblFirstAlertTime.Location = new System.Drawing.Point(2, 27);
            this._lblFirstAlertTime.Margin = new System.Windows.Forms.Padding(2);
            this._lblFirstAlertTime.Name = "_lblFirstAlertTime";
            this._lblFirstAlertTime.Size = new System.Drawing.Size(114, 21);
            this._lblFirstAlertTime.TabIndex = 0;
            this._lblFirstAlertTime.Text = "First Alert Pass:";
            // 
            // _lblSecondAlertTime
            // 
            this._lblSecondAlertTime.AutoSize = true;
            this._lblSecondAlertTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblSecondAlertTime.ForeColor = System.Drawing.Color.Black;
            this._lblSecondAlertTime.Location = new System.Drawing.Point(2, 52);
            this._lblSecondAlertTime.Margin = new System.Windows.Forms.Padding(2);
            this._lblSecondAlertTime.Name = "_lblSecondAlertTime";
            this._lblSecondAlertTime.Size = new System.Drawing.Size(135, 21);
            this._lblSecondAlertTime.TabIndex = 0;
            this._lblSecondAlertTime.Text = "Second Alert Pass:";
            // 
            // _lblOverallPingAttempts
            // 
            this._lblOverallPingAttempts.AutoSize = true;
            this._lblOverallPingAttempts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblOverallPingAttempts.ForeColor = System.Drawing.Color.Black;
            this._lblOverallPingAttempts.Location = new System.Drawing.Point(2, 77);
            this._lblOverallPingAttempts.Margin = new System.Windows.Forms.Padding(2);
            this._lblOverallPingAttempts.Name = "_lblOverallPingAttempts";
            this._lblOverallPingAttempts.Size = new System.Drawing.Size(143, 21);
            this._lblOverallPingAttempts.TabIndex = 0;
            this._lblOverallPingAttempts.Text = "Overall Attempts: 0";
            // 
            // _lnkLblResetAttemptCounter
            // 
            this._lnkLblResetAttemptCounter.AutoSize = true;
            this._lnkLblResetAttemptCounter.Location = new System.Drawing.Point(430, 209);
            this._lnkLblResetAttemptCounter.Name = "_lnkLblResetAttemptCounter";
            this._lnkLblResetAttemptCounter.Size = new System.Drawing.Size(35, 13);
            this._lnkLblResetAttemptCounter.TabIndex = 61;
            this._lnkLblResetAttemptCounter.TabStop = true;
            this._lnkLblResetAttemptCounter.Text = "Reset";
            this._lnkLblResetAttemptCounter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._lnkLblResetAttemptCounter_LinkClicked);
            // 
            // _lblLastBatchExec
            // 
            this._lblLastBatchExec.AutoSize = true;
            this._lblLastBatchExec.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblLastBatchExec.ForeColor = System.Drawing.Color.DarkGray;
            this._lblLastBatchExec.Location = new System.Drawing.Point(195, 404);
            this._lblLastBatchExec.Margin = new System.Windows.Forms.Padding(2);
            this._lblLastBatchExec.Name = "_lblLastBatchExec";
            this._lblLastBatchExec.Size = new System.Drawing.Size(194, 17);
            this._lblLastBatchExec.TabIndex = 0;
            this._lblLastBatchExec.Text = "Last execution of current batch: ";
            // 
            // _btnRemoveBatch
            // 
            this._btnRemoveBatch.BackColor = System.Drawing.Color.Tomato;
            this._btnRemoveBatch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._btnRemoveBatch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this._btnRemoveBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnRemoveBatch.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnRemoveBatch.ForeColor = System.Drawing.Color.Black;
            this._btnRemoveBatch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnRemoveBatch.Location = new System.Drawing.Point(654, 397);
            this._btnRemoveBatch.Margin = new System.Windows.Forms.Padding(0);
            this._btnRemoveBatch.Name = "_btnRemoveBatch";
            this._btnRemoveBatch.Size = new System.Drawing.Size(98, 29);
            this._btnRemoveBatch.TabIndex = 5;
            this._btnRemoveBatch.Text = "Remove";
            this._btnRemoveBatch.UseVisualStyleBackColor = false;
            this._btnRemoveBatch.Click += new System.EventHandler(this._btnRemoveBatch_Click);
            // 
            // _btnExecBatch
            // 
            this._btnExecBatch.BackColor = System.Drawing.Color.Gainsboro;
            this._btnExecBatch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._btnExecBatch.Enabled = false;
            this._btnExecBatch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this._btnExecBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnExecBatch.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnExecBatch.ForeColor = System.Drawing.Color.Black;
            this._btnExecBatch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnExecBatch.Location = new System.Drawing.Point(95, 397);
            this._btnExecBatch.Margin = new System.Windows.Forms.Padding(0);
            this._btnExecBatch.Name = "_btnExecBatch";
            this._btnExecBatch.Size = new System.Drawing.Size(98, 29);
            this._btnExecBatch.TabIndex = 5;
            this._btnExecBatch.Text = "Execute Batch";
            this._btnExecBatch.UseVisualStyleBackColor = false;
            this._btnExecBatch.Click += new System.EventHandler(this._btnExecBatch_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.BackgroundColor = System.Drawing.Color.White;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Target,
            this.Address,
            this.RoundTrip,
            this.Time,
            this.Status});
            this.dgvResults.Location = new System.Drawing.Point(95, 236);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(657, 150);
            this.dgvResults.TabIndex = 4;
            // 
            // _lnkLblChangeHostList
            // 
            this._lnkLblChangeHostList.AutoSize = true;
            this._lnkLblChangeHostList.Location = new System.Drawing.Point(47, 209);
            this._lnkLblChangeHostList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._lnkLblChangeHostList.Name = "_lnkLblChangeHostList";
            this._lnkLblChangeHostList.Size = new System.Drawing.Size(44, 13);
            this._lnkLblChangeHostList.TabIndex = 30;
            this._lnkLblChangeHostList.TabStop = true;
            this._lnkLblChangeHostList.Text = "Change";
            this._lnkLblChangeHostList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._lnkLblChangeHostList_LinkClicked);
            // 
            // _lbxHostList
            // 
            this._lbxHostList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbxHostList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbxHostList.FormattingEnabled = true;
            this._lbxHostList.ItemHeight = 21;
            this._lbxHostList.Location = new System.Drawing.Point(95, 94);
            this._lbxHostList.Margin = new System.Windows.Forms.Padding(2);
            this._lbxHostList.Name = "_lbxHostList";
            this._lbxHostList.Size = new System.Drawing.Size(266, 128);
            this._lbxHostList.TabIndex = 2;
            this._lbxHostList.TabStop = false;
            // 
            // _tbxJobDescription
            // 
            this._tbxJobDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxJobDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxJobDescription.Location = new System.Drawing.Point(95, 61);
            this._tbxJobDescription.Margin = new System.Windows.Forms.Padding(2);
            this._tbxJobDescription.Name = "_tbxJobDescription";
            this._tbxJobDescription.Size = new System.Drawing.Size(266, 29);
            this._tbxJobDescription.TabIndex = 20;
            this._tbxJobDescription.TextChanged += new System.EventHandler(this._tbxJobDescription_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 236);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Results";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Host List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Description";
            // 
            // _tbxBufferSize
            // 
            this._tbxBufferSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxBufferSize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxBufferSize.Location = new System.Drawing.Point(471, 61);
            this._tbxBufferSize.Margin = new System.Windows.Forms.Padding(2);
            this._tbxBufferSize.Name = "_tbxBufferSize";
            this._tbxBufferSize.Size = new System.Drawing.Size(281, 29);
            this._tbxBufferSize.TabIndex = 60;
            this._tbxBufferSize.TextChanged += new System.EventHandler(this._tbxBufferSize_TextChanged);
            // 
            // _tbxTimeOut
            // 
            this._tbxTimeOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxTimeOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxTimeOut.Location = new System.Drawing.Point(471, 28);
            this._tbxTimeOut.Margin = new System.Windows.Forms.Padding(2);
            this._tbxTimeOut.Name = "_tbxTimeOut";
            this._tbxTimeOut.Size = new System.Drawing.Size(281, 29);
            this._tbxTimeOut.TabIndex = 50;
            this._tbxTimeOut.TextChanged += new System.EventHandler(this._tbxTimeOut_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(365, 30);
            this.label7.Margin = new System.Windows.Forms.Padding(2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "Timeout (ms)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(365, 94);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 42);
            this.label6.TabIndex = 0;
            this.label6.Text = "Alerting \r\nService";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(365, 63);
            this.label8.Margin = new System.Windows.Forms.Padding(2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "Buffer Size";
            // 
            // _tbxJobName
            // 
            this._tbxJobName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbxJobName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbxJobName.Location = new System.Drawing.Point(95, 28);
            this._tbxJobName.Margin = new System.Windows.Forms.Padding(2);
            this._tbxJobName.Name = "_tbxJobName";
            this._tbxJobName.Size = new System.Drawing.Size(266, 29);
            this._tbxJobName.TabIndex = 10;
            this._tbxJobName.TextChanged += new System.EventHandler(this._tbxJobName_TextChanged);
            this._tbxJobName.Leave += new System.EventHandler(this._tbxJobName_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 41);
            this.label5.TabIndex = 2;
            this.label5.Text = "NetVulture";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _pnlTopMenu
            // 
            this._pnlTopMenu.BackColor = System.Drawing.Color.DimGray;
            this._pnlTopMenu.Controls.Add(this._lblClock);
            this._pnlTopMenu.Controls.Add(this._chkBtnTimerEnabled);
            this._pnlTopMenu.Controls.Add(this._btnOpenSettings);
            this._pnlTopMenu.Controls.Add(this._btnAddBatch);
            this._pnlTopMenu.Controls.Add(this._btnCollect);
            this._pnlTopMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlTopMenu.Location = new System.Drawing.Point(178, 0);
            this._pnlTopMenu.Margin = new System.Windows.Forms.Padding(0);
            this._pnlTopMenu.Name = "_pnlTopMenu";
            this._pnlTopMenu.Size = new System.Drawing.Size(764, 41);
            this._pnlTopMenu.TabIndex = 3;
            // 
            // _lblClock
            // 
            this._lblClock.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblClock.ForeColor = System.Drawing.Color.White;
            this._lblClock.Location = new System.Drawing.Point(471, 0);
            this._lblClock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._lblClock.Name = "_lblClock";
            this._lblClock.Size = new System.Drawing.Size(253, 41);
            this._lblClock.TabIndex = 61;
            this._lblClock.Text = "DD.MM.YYYY HH:MM:SS";
            this._lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _chkBtnTimerEnabled
            // 
            this._chkBtnTimerEnabled.Appearance = System.Windows.Forms.Appearance.Button;
            this._chkBtnTimerEnabled.BackColor = System.Drawing.Color.Tomato;
            this._chkBtnTimerEnabled.FlatAppearance.BorderSize = 0;
            this._chkBtnTimerEnabled.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this._chkBtnTimerEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._chkBtnTimerEnabled.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this._chkBtnTimerEnabled.ForeColor = System.Drawing.Color.WhiteSmoke;
            this._chkBtnTimerEnabled.Image = global::NetVulture.Properties.Resources.Clock_32;
            this._chkBtnTimerEnabled.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._chkBtnTimerEnabled.Location = new System.Drawing.Point(0, 0);
            this._chkBtnTimerEnabled.Margin = new System.Windows.Forms.Padding(0);
            this._chkBtnTimerEnabled.Name = "_chkBtnTimerEnabled";
            this._chkBtnTimerEnabled.Size = new System.Drawing.Size(150, 41);
            this._chkBtnTimerEnabled.TabIndex = 61;
            this._chkBtnTimerEnabled.Text = "Timer Disabled";
            this._chkBtnTimerEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._chkBtnTimerEnabled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._chkBtnTimerEnabled.UseVisualStyleBackColor = false;
            this._chkBtnTimerEnabled.CheckedChanged += new System.EventHandler(this._chkBtnTimerEnabled_CheckedChanged);
            // 
            // _btnOpenSettings
            // 
            this._btnOpenSettings.BackColor = System.Drawing.Color.DimGray;
            this._btnOpenSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._btnOpenSettings.FlatAppearance.BorderSize = 0;
            this._btnOpenSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnOpenSettings.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this._btnOpenSettings.ForeColor = System.Drawing.Color.WhiteSmoke;
            this._btnOpenSettings.Image = global::NetVulture.Properties.Resources.Settings_32;
            this._btnOpenSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnOpenSettings.Location = new System.Drawing.Point(377, 1);
            this._btnOpenSettings.Margin = new System.Windows.Forms.Padding(0);
            this._btnOpenSettings.Name = "_btnOpenSettings";
            this._btnOpenSettings.Size = new System.Drawing.Size(104, 41);
            this._btnOpenSettings.TabIndex = 5;
            this._btnOpenSettings.Text = "Settings";
            this._btnOpenSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._btnOpenSettings.UseVisualStyleBackColor = false;
            this._btnOpenSettings.Click += new System.EventHandler(this._btnOpenSettings_Click);
            // 
            // _btnAddBatch
            // 
            this._btnAddBatch.BackColor = System.Drawing.Color.DimGray;
            this._btnAddBatch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._btnAddBatch.FlatAppearance.BorderSize = 0;
            this._btnAddBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAddBatch.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnAddBatch.ForeColor = System.Drawing.Color.WhiteSmoke;
            this._btnAddBatch.Image = global::NetVulture.Properties.Resources.Plus_32;
            this._btnAddBatch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnAddBatch.Location = new System.Drawing.Point(150, 0);
            this._btnAddBatch.Margin = new System.Windows.Forms.Padding(0);
            this._btnAddBatch.Name = "_btnAddBatch";
            this._btnAddBatch.Size = new System.Drawing.Size(123, 41);
            this._btnAddBatch.TabIndex = 5;
            this._btnAddBatch.Text = "Add Batch";
            this._btnAddBatch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._btnAddBatch.UseVisualStyleBackColor = false;
            this._btnAddBatch.Click += new System.EventHandler(this._btnAddBatch_Click);
            // 
            // _btnCollect
            // 
            this._btnCollect.BackColor = System.Drawing.Color.DimGray;
            this._btnCollect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._btnCollect.FlatAppearance.BorderSize = 0;
            this._btnCollect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCollect.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnCollect.ForeColor = System.Drawing.Color.WhiteSmoke;
            this._btnCollect.Image = global::NetVulture.Properties.Resources.Collect_32;
            this._btnCollect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnCollect.Location = new System.Drawing.Point(273, 0);
            this._btnCollect.Margin = new System.Windows.Forms.Padding(0);
            this._btnCollect.Name = "_btnCollect";
            this._btnCollect.Size = new System.Drawing.Size(104, 41);
            this._btnCollect.TabIndex = 5;
            this._btnCollect.Text = "Collect";
            this._btnCollect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._btnCollect.UseVisualStyleBackColor = false;
            this._btnCollect.Click += new System.EventHandler(this._btnCollect_Click);
            // 
            // _pnlButtom
            // 
            this._pnlButtom.Controls.Add(this._lblLastCollect);
            this._pnlButtom.Controls.Add(this._lblOutputDir);
            this._pnlButtom.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlButtom.Location = new System.Drawing.Point(178, 480);
            this._pnlButtom.Margin = new System.Windows.Forms.Padding(0);
            this._pnlButtom.Name = "_pnlButtom";
            this._pnlButtom.Size = new System.Drawing.Size(764, 48);
            this._pnlButtom.TabIndex = 4;
            // 
            // _lblLastCollect
            // 
            this._lblLastCollect.AutoSize = true;
            this._lblLastCollect.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblLastCollect.ForeColor = System.Drawing.Color.DarkGray;
            this._lblLastCollect.Location = new System.Drawing.Point(2, 20);
            this._lblLastCollect.Margin = new System.Windows.Forms.Padding(2);
            this._lblLastCollect.Name = "_lblLastCollect";
            this._lblLastCollect.Size = new System.Drawing.Size(97, 17);
            this._lblLastCollect.TabIndex = 0;
            this._lblLastCollect.Text = "Last Execution: ";
            // 
            // _lblOutputDir
            // 
            this._lblOutputDir.AutoSize = true;
            this._lblOutputDir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblOutputDir.ForeColor = System.Drawing.Color.DarkGray;
            this._lblOutputDir.Location = new System.Drawing.Point(3, 2);
            this._lblOutputDir.Margin = new System.Windows.Forms.Padding(2);
            this._lblOutputDir.Name = "_lblOutputDir";
            this._lblOutputDir.Size = new System.Drawing.Size(55, 17);
            this._lblOutputDir.TabIndex = 0;
            this._lblOutputDir.Text = "Output: ";
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 528);
            this.Controls.Add(this._tlpBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "NetVulture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this._tlpBody.ResumeLayout(false);
            this._tlpBody.PerformLayout();
            this._pnlJobInfo.ResumeLayout(false);
            this._pnlJobInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this._pnlTopMenu.ResumeLayout(false);
            this._pnlButtom.ResumeLayout(false);
            this._pnlButtom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tlpBody;
        private System.Windows.Forms.ListBox _lbxJobs;
        private System.Windows.Forms.Panel _pnlJobInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbxJobName;
        private System.Windows.Forms.TextBox _tbxJobDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox _lbxHostList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel _lnkLblChangeHostList;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel _pnlTopMenu;
        private System.Windows.Forms.Button _btnCollect;
        private System.Windows.Forms.Button _btnOpenSettings;
        private System.Windows.Forms.Panel _pnlButtom;
        private System.Windows.Forms.Label _lblOutputDir;
        private System.Windows.Forms.Button _btnAddBatch;
        private System.Windows.Forms.Button _btnExecBatch;
        private System.Windows.Forms.TextBox _tbxTimeOut;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _tbxBufferSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer _collectTimer;
        private System.Windows.Forms.Label _lblLastCollect;
        private System.Windows.Forms.CheckBox _chkBtnTimerEnabled;
        private System.Windows.Forms.Label _lblLastBatchExec;
        private System.Windows.Forms.Label _lblClock;
        private System.Windows.Forms.Timer _clock;
        private System.Windows.Forms.Button _btnRemoveBatch;
        private System.Windows.Forms.Label _lblSecondAlertTime;
        private System.Windows.Forms.Label _lblFirstAlertTime;
        private System.Windows.Forms.Label _lblCountOfFailedRequests;
        private System.Windows.Forms.Label _lblOverallPingAttempts;
        private System.Windows.Forms.LinkLabel _lnkLblResetAttemptCounter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Target;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoundTrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}

