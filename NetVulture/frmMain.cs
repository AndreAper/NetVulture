using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using nvcore;

namespace NetVulture
{
    public partial class FrmMain : Form
    {
        private List<Batch> batchList;
        private Batch _selectedBatch;

        private string _outputDir, _autoImportCsvPath;
        private DateTime _lastExecutionTime, _sendSummaryTime;
        private BackgroundWorker _backWorker;
        private System.Collections.Specialized.StringCollection _addressList;
        private bool _isEmailAlertingEnabled, _isAutoImportEnabled, _isSendSummaryEnabled, _firstCollectPassed;

        /// <summary>
        /// Event that raised if the user click on a item in the batchlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BatchList_Click(object sender, EventArgs e)
        {
            foreach (Button btn in _flpBatchList.Controls.Cast<Button>())
            {
                btn.BackColor = Color.Transparent;
            }

            Button b = (Button)sender;
            b.BackColor = Color.FromArgb(205, 215, 220);
            _selectedBatch = batchList.Single(x => x.Name == b.Text);
            DisplayBatch();

            _btnRunSelectedBatch.Enabled = true;
            _btnEditHostList.Enabled = true;
            _btnRemoveSelectedBatch.Enabled = true;
            _chkBtnBatchMaintenanceSwitch.Enabled = true;
        }

        /// <summary>
        /// Checking response send alerting messages
        /// </summary>
        protected async Task CheckAlertAsync()
        {
            IEnumerable<Batch> failedBatches = batchList.Where(x => x.EndPointList.Any(y => y.Status != IPStatus.Success && y.PingAttempts == 10));

            if (failedBatches.Count() > 0)
            {
                foreach (Batch b in failedBatches)
                {
                    if (b.EnableAlerting)
                    {
                        await EMail.SendHtmlMailAsync(Properties.Settings.Default.SmtpServer, Properties.Settings.Default.SmtpPort, Summary.CreateAlertingMessage(b), Properties.Settings.Default.SmtpUser, _addressList.Cast<string>().ToArray()); 
                    }
                }

                this.Invoke((MethodInvoker)delegate
                {
                    LogFile.UpdateLogfile("Log.log", "Message Dispatcher", "CheckAlert", "Sending SMTP E-Mail successfully");
                });
            }
        }

        /// <summary>
        /// Show the batch that selcted from main batch list.
        /// </summary>
        private void DisplayBatch()
        {
            if (_selectedBatch != null)
            {
                _tbxJobName.Text = _selectedBatch.Name;
                _tbxJobDescription.Text = _selectedBatch.Description;
                _chkBxEnableAlerting.Checked = _selectedBatch.EnableAlerting;
                _lblLastBatchExec.Text = "Last batch run:\r\n" + _selectedBatch.LastExecution;
                _chkBtnBatchMaintenanceSwitch.Checked = _selectedBatch.Maintenance;

                if (_selectedBatch.EndPointList != null && _selectedBatch.EndPointList.Count > 0)
                {
                    _dgvResults.Rows.Clear();

                    for (int i = 0; i < _selectedBatch.EndPointList.Count; i++)
                    {
                        _dgvResults.Rows.Add(_selectedBatch.EndPointList[i].PrimaryAddress, 
                            _selectedBatch.EndPointList[i].ReplyAddress, 
                            _selectedBatch.EndPointList[i].PhysicalAddress, 
                            _selectedBatch.EndPointList[i].RoundtripTime, 
                            _selectedBatch.EndPointList[i].LastAvailability.ToString(), 
                            _selectedBatch.EndPointList[i].Status.ToString(), 
                            _selectedBatch.EndPointList[i].PingAttempts.ToString(), 
                            _selectedBatch.EndPointList[i].MaintenanceActivated.ToString());
                    }

                    _lblCountOfFailedRequests.Text = "Failed Requests:\r\n" + _selectedBatch.EndPointList.Count(x => x.Status != IPStatus.Success);
                    _lblCountOfSuccessRequests.Text = "Success Requests:\r\n" + _selectedBatch.EndPointList.Count(x => x.Status == IPStatus.Success);
                }
                else
                {
                    _dgvResults.Rows.Clear();
                }

                if (_collectTimer.Enabled)
                {
                    _pnlSubMenuBatch.Enabled = false;
                    _tbxJobName.Enabled = false;
                    _tbxJobDescription.Enabled = false;
                }
                else
                {
                    if (_isAutoImportEnabled == false)
                    {
                        _pnlSubMenuBatch.Enabled = true;
                        _tbxJobName.Enabled = true;
                        _tbxJobDescription.Enabled = true;
                    }
                }
            }
            else
            {
                _pnlSubMenuBatch.Enabled = false;
                _tbxJobName.Enabled = false;
                _tbxJobDescription.Enabled = false;

                _dgvResults.Rows.Clear();
            }
        }

        /// <summary>
        /// Send a daily summer to all mail recipients.
        /// </summary>
        /// <returns></returns>
        private async Task SendSummaryReport()
        {
            await EMail.SendHtmlMailAsync(Properties.Settings.Default.SmtpServer, Properties.Settings.Default.SmtpPort, Summary.Create(batchList), Properties.Settings.Default.SmtpUser, _addressList.Cast<string>().ToArray());

            this.Invoke((MethodInvoker)delegate
            {
                LogFile.UpdateLogfile("Log.log", "Message Dispatcher", "CheckAlert", "Sending SMTP E-Mail successfully");
            });
        }

        /// <summary>
        /// Transferring the selected batch instance to the batch list.
        /// </summary>
        private void TransferBatch()
        {
            batchList[batchList.IndexOf(batchList.Single(x => x.Name == _selectedBatch.Name))] = _selectedBatch;
        }

        /// <summary>
        /// Updating batchlist on the left side of the main form.
        /// </summary>
        private void UpdateBatchList()
        {
            //List all Batches to the FlowLayoutPanel.
            if (batchList != null && batchList.Count > 0)
            {
                _flpBatchList.Controls.Clear();

                foreach (Batch batch in batchList)
                {
                    Button b = new Button();
                    b.BackColor = Color.Transparent;
                    b.TextAlign = ContentAlignment.MiddleLeft;
                    b.Text = batch.Name;
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(205, 215, 220);
                    b.Font = new Font("Segoe UI Light", 12);
                    b.ForeColor = Color.FromArgb(0, 50, 75);
                    b.ImageAlign = ContentAlignment.MiddleRight;
                    b.Margin = new Padding(0);
                    b.Width = _flpBatchList.Width;
                    b.Height = 40;
                    b.UseVisualStyleBackColor = false;
                    b.TextImageRelation = TextImageRelation.Overlay;
                    b.Click += BatchList_Click;

                    if (batch.EndPointList != null)
                    {
                        if (batch.Maintenance)
                        {
                            b.Image = Properties.Resources.Maintenance_32;
                        }
                        else
                        {
                            if (batch.EndPointList.Any(x => x.Status != IPStatus.Success))
                            {
                                b.Image = Properties.Resources.High_Priority_32_Black;
                            }
                            else
                            {
                                b.Image = null;
                            }
                        }
                    }

                    _flpBatchList.Controls.Add(b);
                }

                DisplayBatch();
            }
            else
            {
                _flpBatchList.Controls.Clear();

                _pnlSubMenuBatch.Enabled = false;
                _tbxJobName.Text = "";
                _tbxJobName.Enabled = false;
                _tbxJobDescription.Enabled = false;
                _dgvResults.Enabled = false;
                _dgvResults.Rows.Clear();

                _lblLastBatchExec.Text = "Last execution:\r\n";
                _lblCountOfFailedRequests.Text = "Failed Requests:\r\n";
                _lblCountOfSuccessRequests.Text = "Success Requests:\r\n";
            }

        }

        /// <summary>
        /// Updating main form.
        /// </summary>
        private void UpdateForm()
        {
            _lblAppTitle.Text = $"NetVulture v{Application.ProductVersion}";
            this.Text = $"NetVulture v{Application.ProductVersion}";

            //Get the saved settings from configuration file
            _outputDir = Properties.Settings.Default.OutputDir;
            _lblOutputDir.Text = "Output: " + Environment.NewLine + _outputDir;
            _isEmailAlertingEnabled = Properties.Settings.Default.EmailAlertingEnabled;
            _isAutoImportEnabled = Properties.Settings.Default.AutoloadCsvEnabled;
            _autoImportCsvPath = Properties.Settings.Default.AutoloadCsvPath;
            _sendSummaryTime = Properties.Settings.Default.SendSummaryTime;
            _isSendSummaryEnabled = Properties.Settings.Default.SendSummaryEnabled;

            if (_isEmailAlertingEnabled)
            {
                _lblEmailAlertingStatus.Text = "Email Alerting Status:" + Environment.NewLine + "Enabled";
                _addressList = Properties.Settings.Default.TargetAddresses;
            }
            else
            {
                _lblEmailAlertingStatus.Text = "Email Alerting Status:" + Environment.NewLine + "Disabled";
            }

            if (_isAutoImportEnabled)
            {
                _chkBtnTimerEnabled.Enabled = false;
                _btnAddBatch.Enabled = false;
                _btnCollect.Enabled = false;
                _pnlSubMenuBatch.Enabled = false;
                _tbxJobName.Enabled = false;
                _tbxJobDescription.Enabled = false;
                _chkBtnTimerEnabled.Checked = true;
            }
            else
            {
                _chkBtnTimerEnabled.Enabled = true;
                _btnAddBatch.Enabled = true;
                _btnCollect.Enabled = true;
                _pnlSubMenuBatch.Enabled = true;
                _tbxJobName.Enabled = true;
                _tbxJobDescription.Enabled = true;
                _lblNoChangesPossible.Visible = false;
            }
        }

        /// <summary>
        /// Writing collected data to csv and js files.
        /// </summary>
        /// <returns></returns>
        private async Task WriteOutput()
        {
            if (batchList != null && batchList.Count > 0)
            {
                if (Directory.Exists(_outputDir) == false)
                {
                    Directory.CreateDirectory(_outputDir);
                }

                foreach (Batch batch in batchList)
                {
                    if (!batch.Maintenance)
                    {
                        string csvFile = Path.Combine(_outputDir, batch.Name + ".csv");
                        string csvFileFailed = Path.Combine(_outputDir, batch.Name + "_FailedRequestHistory.csv");
                        string jsFile = Path.Combine(_outputDir, batch.Name + ".js");

                        if (batch.EndPointList != null && batch.EndPointList.Count > 0)
                        {
                            await FileIO.CsvBatchWriterAsync(csvFile, batch, true);

                            //History CSV output
                            using (StreamWriter swCsv = new StreamWriter(csvFileFailed, true))
                            {
                                IEnumerable<nvcore.EndPoint> offlineDevices = batch.EndPointList.Where(x => x.Status != IPStatus.Success);

                                for (int i = 0; i < offlineDevices.Count(); i++)
                                {
                                    await swCsv.WriteLineAsync(offlineDevices.ElementAt(i).ToString());
                                }
                            }

                            await FileIO.JsArrayWriterBatchAsync(jsFile, batch);
                        }  
                    }                  
                }
            }

        }

        public FrmMain()
        {
            InitializeComponent();

            batchList = FileIO.XmlReader();

            _backWorker = new BackgroundWorker();
            _backWorker.DoWork += _backWorker_DoWork;
            _backWorker.RunWorkerCompleted += _backWorker_RunWorkerCompleted;

            _firstCollectPassed = false;

            UpdateBatchList();
            UpdateForm();
        }

        private async void _backWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            await WriteOutput();
            await CheckAlertAsync();

            _lblLastCollect.Text = "Last Overall Execution: " + Environment.NewLine + _lastExecutionTime.ToString();
            _btnCollect.Enabled = true;
            _btnCollect.BackColor = Color.FromArgb(0, 50, 75);
            _lastExecutionTime = DateTime.Now;
            _pnlSubMenuBatch.Enabled = true;

            if (_firstCollectPassed == false)
            {
                _firstCollectPassed = true;
            }

            UpdateForm();
            UpdateBatchList();
            DisplayBatch();
        }

        private void _backWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int arg = (int)e.Argument;

            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    _btnCollect.BackColor = Color.FromArgb(255, 155, 50);
                });
            }

            if (arg == -1)
            {
                try
                {
                    Task[] workingBees = new Task[batchList.Count];

                    for (int i = 0; i < batchList.Count; i++)
                    {
                        int index = i;
                        workingBees[index] = Task.Factory.StartNew(() => batchList[index].SendAll());
                    }

                    Task.WaitAll(workingBees);
                }
                catch (Exception ex)
                {
                    LogFile.UpdateLogfile("Log.log", "BackgroundWorker", "DoWork()", ex.Message);
                }
            }

            if (arg >= 0)
            {
                try
                {
                    Task t = Task.Factory.StartNew(() => batchList[arg].SendAll());
                    t.Wait();
                }
                catch (Exception ex)
                {
                    LogFile.UpdateLogfile("Log.log", "BackgroundWorker", "DoWork()", ex.Message);
                }
            }
        }

        private void _btnCollect_Click(object sender, EventArgs e)
        {
            if (_backWorker.IsBusy)
            {
                MessageBox.Show("The collect process is already running...");
                return;
            }
            else
            {
                if (String.IsNullOrEmpty(_outputDir))
                {
                    MessageBox.Show("No output directory selcted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _backWorker.RunWorkerAsync(-1);
                }
            }
        }

        private void _btnOpenSettings_Click(object sender, EventArgs e)
        {
            FrmSettings frm = new FrmSettings();

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                UpdateForm();
            }
        }

        private void _btnAddBatch_Click(object sender, EventArgs e)
        {
            if (batchList.Any(x => x.Name == "New Batch"))
            {
                DialogResult res = MessageBox.Show($"Batchlist contains a batch with name of >> New Batch <<.\r\nPlease change the name to a unique name.", "Add Batch", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            batchList.Add(new Batch());
            _selectedBatch = batchList.Last();
            UpdateBatchList();

            BatchList_Click((Button)_flpBatchList.Controls[_flpBatchList.Controls.Count - 1], null);
        }

        private void _tbxJobName_TextChanged(object sender, EventArgs e)
        {
            _selectedBatch.Name = _tbxJobName.Text;
        }

        private void _tbxJobDescription_Leave(object ender, EventArgs e)
        {
            TransferBatch();
            UpdateBatchList();
        }

        private void _RemoveSelectedBatch_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"Do you want to remove batch >> {_selectedBatch.Name} << ?", "Remove Batch", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                batchList.Remove(_selectedBatch);
                UpdateBatchList();
            }
        }

        private void _btnRunSelectedBatch_Click(object sender, EventArgs e)
        {
            if (_backWorker.IsBusy)
            {
                MessageBox.Show("The collect process is already running...");
                return;
            }
            else
            {
                if (String.IsNullOrEmpty(_outputDir))
                {
                    MessageBox.Show("No output directory selcted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _backWorker.RunWorkerAsync(batchList.IndexOf(batchList.Single(x => x.Name == _selectedBatch.Name)));
                }
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            foreach (Button btn in _flpBatchList.Controls.Cast<Button>())
            {
                btn.Width = _flpBatchList.Width;
            }
        }

        private void _chkBtnBatchMaintenanceSwitch_CheckedChanged(object sender, EventArgs e)
        {
            _selectedBatch.Maintenance = _chkBtnBatchMaintenanceSwitch.Checked;
            TransferBatch();
            UpdateForm();
            DisplayBatch();
        }

        private void _btnImportCsv_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv files (*.csv)|*.csv";
            ofd.FilterIndex = 1;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                batchList = FileIO.CsvReader(ofd.FileName);
                UpdateBatchList();
            }
        }

        private void _btnExportCsv_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "csv files (*.csv)|*.csv";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileIO.CsvWriter(sfd.FileName, batchList, true);
            }

        }

        private void _lblOutputDir_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", _outputDir);
        }

        private void _btnEditHostList_Click(object sender, EventArgs e)
        {
            FrmManageHosts frm = null;

            if (_selectedBatch.EndPointList != null)
            {
                frm = new FrmManageHosts(_selectedBatch.EndPointList);
            }
            else
            {
                frm = new FrmManageHosts();
            }

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _selectedBatch.EndPointList = frm.HostList;
                TransferBatch();
                DisplayBatch();
            }
        }

        private void _tbxJobDescription_TextChanged(object sender, EventArgs e)
        {
            _selectedBatch.Description = _tbxJobDescription.Text;
        }

        private void btnResetAllAttempts_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"Do you want to reset all ping aatempts of all batches?", "Remove Batch", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                foreach (Batch b in batchList)
                {
                    b.EndPointList.ForEach(x => x.PingAttempts = 0);
                    UpdateBatchList();
                    DisplayBatch();
                }
            }
        }

        private void _chkBxEnableAlerting_CheckedChanged(object sender, EventArgs e)
        {
            _selectedBatch.EnableAlerting = _chkBxEnableAlerting.Checked;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            nvcore.FileIO.XmlWriter(batchList);
        }

        private void _collectTimer_Tick(object sender, EventArgs e)
        {
            if (_backWorker.IsBusy)
            {
                return;
            }

            _backWorker.RunWorkerAsync(-1);
        }

        private void _chkBtnTimerEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _collectTimer.Enabled = _chkBtnTimerEnabled.Checked;
            _lblNoChangesPossible.Visible = _chkBtnTimerEnabled.Checked;

            if (_chkBtnTimerEnabled.Checked)
            {
                _chkBtnTimerEnabled.Text = "Timer Enabled";

                if (String.IsNullOrEmpty(_outputDir))
                {
                    _outputDir = "output";
                }
            }
            else
            {
                _chkBtnTimerEnabled.Text = "Timer Disabled";
            }

            DisplayBatch();
        }

        private void _tbxJobName_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_tbxJobName.Text))
            {
                TransferBatch();
                UpdateBatchList();
                UpdateForm(); 
            }
        }

        private void _clock_Tick(object sender, EventArgs e)
        {
            _lblClock.Text = "Systemtime\r\n" + DateTime.Now.ToString();

            if (_isSendSummaryEnabled)
            {
                if (_sendSummaryTime.ToString("HH:mm:ss") == DateTime.Now.ToString("HH:mm:ss"))
                {
                    SendSummaryReport();
                } 
            }
        }
    }
}
