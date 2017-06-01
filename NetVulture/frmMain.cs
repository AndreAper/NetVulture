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
using System.Reflection;

namespace NetVulture
{
    public partial class FrmMain : Form
    {
        private List<NvBatch> _batchList;
        private NvBatch _selectedBatch;

        private string _outputDir, _autoImportCsvPath, _deliveryMethod;
        private DateTime _lastExecutionTime, _sendSummaryTime;
        private BackgroundWorker _backWorker;
        private System.Collections.Specialized.StringCollection _addressList;
        private bool _isEmailAlertingEnabled, _isAutoImportEnabled, _isSendSummaryEnabled, _firstCollectPassed;
        private const string LogFile = "Log.log";

        /// <summary>
        /// Write a new line to the local log file.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="src"></param>
        /// <param name="msg"></param>
        public static async void UpdateLogfile(string type, string src, string msg)
        {
            if (!File.Exists(LogFile)) File.Create(LogFile);

            try
            {
                using (FileStream aFile = new FileStream(LogFile, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(aFile))
                    {
                        await sw.WriteLineAsync("Type: " + type + " # Soruce: " + src + " # Time: " + DateTime.Now + " # Message: " + msg);
                    }
                }
            }
            catch (IOException ioEx)
            {
                // The file is locked
            }
        }

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
            _selectedBatch = _batchList.Single(x => x.Name == b.Text);
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
            IEnumerable<NvDevice> failed = _batchList.SelectMany(batch => batch.HostList)
                .Where(device => device.ReplyData != null && device.ReplyData.Status != IPStatus.Success && device.PingAttempts == 10);

            if (failed.Count() > 0)
            {
                if (_deliveryMethod == "SMTP")
                {
                    await NvManagementClass.SendMailAsync(NvManagementClass.GetSummaryReport(_batchList), _addressList.Cast<string>().ToArray());

                    this.Invoke((MethodInvoker)delegate
                    {
                        UpdateLogfile("Message Dispatcher", "void CheckAlert()", "Sending SMTP E-Mail successfully");
                    });

                }
                else if (_deliveryMethod == "Outlook")
                {
                    await NvManagementClass.SendOutlookMailAsync(Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML, NvManagementClass.GetSummaryReport(_batchList), _addressList.Cast<string>().ToArray());

                    this.Invoke((MethodInvoker)delegate
                    {
                        UpdateLogfile("Message Dispatcher", "void CheckAlert()", "Sending E-Mail successfully");
                    });
                }
            }
        }

        /// <summary>
        /// Load local stored batchlist. 
        /// </summary>
        /// <returns></returns>
        private static List<NvBatch> Deserialize()
        {
            if (File.Exists(@"batchlist.xml"))
            {
                try
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<NvBatch>));
                    TextReader reader = new StreamReader(@"batchlist.xml");
                    object obj = deserializer.Deserialize(reader);
                    List<NvBatch> lst = (List<NvBatch>)obj;
                    reader.Close();

                    return lst;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return new List<NvBatch>();
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
                _lblLastBatchExec.Text = "Last batch run:\r\n" + _selectedBatch.LastExecution;
                _chkBtnBatchMaintenanceSwitch.Checked = _selectedBatch.Maintenance;

                if (_selectedBatch.HostList != null && _selectedBatch.HostList.Count > 0)
                {
                    _dgvResults.Rows.Clear();
                    int failedRequests = 0;
                    int successRequests = 0;

                    for (int i = 0; i < _selectedBatch.HostList.Count; i++)
                    {
                        PingReply pr = _selectedBatch.HostList[i].ReplyData;

                        string[] data;

                        if (pr == null)
                        {
                            data = new string[] { _selectedBatch.HostList[i].HostnameOrAddress, "", "", "", "", "", "", "" };
                            failedRequests++;
                        }
                        else
                        {
                            if (pr.Status != IPStatus.Success)
                            {
                                failedRequests++;
                            }
                            else
                            {
                                successRequests++;
                            }

                            data = new string[] { _selectedBatch.HostList[i].HostnameOrAddress, pr.Address.ToString(), _selectedBatch.HostList[i].PhysicalAddress, pr.RoundtripTime.ToString(), _selectedBatch.HostList[i].LastAvailability.ToString(), pr.Status.ToString(), _selectedBatch.HostList[i].PingAttempts.ToString(), _selectedBatch.HostList[i].MaintenanceActivated.ToString() };
                        }

                        _dgvResults.Rows.Add(data);
                    }

                    _lblCountOfFailedRequests.Text = "Failed Requests:\r\n" + failedRequests;
                    _lblCountOfSuccessRequests.Text = "Success Requests:\r\n" + successRequests;
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
        private void SendSummaryReport()
        {
            StringBuilder sbOutput = new StringBuilder();

            sbOutput.Append(
                "<!DOCTYPE html><html><head><style>" +
                "h1 { font-family: arial, sans-serif;font-weight:lighter;background-color:#00324b;color:#ffffff;text-align:center; padding:5px}" +
                "table {font-family: arial, sans-serif;border-collapse: collapse;width: 100%;}" +
                "td, th {border: 1px solid; text-align: left; padding: 8px;}" +
                ".header {background-color: #e3e3e3;}" +
                ".noneAlert {background-color: #8DD454;}" +
                ".warning {background-color: #FE9B33;}" +
                ".alert {color: #ffffff;background-color: #EA0043;}" +
                ".criticalAlert {color: #ffffff;background-color: #7330A4;}" +
                "</style></head><body>" +
                "<h1>IOB MONITORING DAILY SUMMARY</h1><table>" +
                "<tr class='header'><th>Batch Name</th><th>Description</th><th>Maintenance</th><th>Hosts Count</th><th>Hosts Online</th><th>Hosts Offline</th><th style='width: 40%'>Information</th></tr>"
                );

            foreach (NvBatch batch in _batchList)
            {
                if (batch.HostList != null && batch.HostList.Count > 0)
                {
                    IEnumerable<NvDevice> offlineDevices = batch.HostList.Where(x => x.ReplyData != null && x.ReplyData.Status != IPStatus.Success);
                    IEnumerable<NvDevice> onlineDevices = batch.HostList.Where(x => x.ReplyData != null && x.ReplyData.Status == IPStatus.Success);

                    if (offlineDevices.Count() > 0)
                    {
                        StringBuilder sbInfo = new StringBuilder();

                        foreach (NvDevice d in offlineDevices)
                        {
                            sbInfo.Append(string.Format("<p>Hostname: {0}; Last Availability: {1};<br/>Building: {2}; Cabinet {3}; Rack: {4}</p>", d.HostnameOrAddress, d.LastAvailability, d.Building, d.Cabinet, d.Rack));
                        }

                        if (offlineDevices.Any(x => x.PriorityLevel == 0))
                        {
                            sbOutput.Append(string.Format("<tr class='criticalAlert'><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td></tr>",
                                batch.Name, batch.Description, batch.Maintenance, batch.HostList.Count(), onlineDevices.Count(), offlineDevices.Count(), sbInfo.ToString()));
                        }
                        else
                        {
                            sbOutput.Append(string.Format("<tr class='alert'><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td></tr>",
                                batch.Name, batch.Description, batch.Maintenance, batch.HostList.Count(), onlineDevices.Count(), offlineDevices.Count(), sbInfo.ToString()));
                        }
                    }
                    else
                    {
                        if (batch.HostList.Count - onlineDevices.Count() > 0)
                        {
                            sbOutput.Append(string.Format("<tr class='warning'><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td></tr>",
                                batch.Name, batch.Description, batch.Maintenance, batch.HostList.Count(), onlineDevices.Count(), offlineDevices.Count(), "Warning: Batch contains unknown hosts!"));
                        }
                        else
                        {
                            sbOutput.Append(string.Format("<tr class='noneAlert'><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td></tr>",
                                batch.Name, batch.Description, batch.Maintenance, batch.HostList.Count(), onlineDevices.Count(), offlineDevices.Count(), ""));
                        }
                    }
                }
                else
                {
                    sbOutput.Append(string.Format("<tr class='noneAlert'><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td></tr>",
                        batch.Name, batch.Description, batch.Maintenance, batch.HostList.Count(), "", "", "No hosts are added to this batch."));
                }
            }

            sbOutput.Append("</table></body></html>");

            if (_addressList.Count > 0)
            {
                NvManagementClass.SendOutlookMailAsync(Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML, sbOutput.ToString(), _addressList.Cast<string>().ToArray());

                this.Invoke((MethodInvoker)delegate
                {
                    UpdateLogfile("Message Dispatcher", "void SendSummery()", "Sending E-Mail successfully");
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    UpdateLogfile("Message Dispatcher", "void SendSummery()", "Sending E-Mail failed because no recipients added to address list.");
                });
            }
        }

        /// <summary>
        /// Serializing the batch list and write to application root directory.
        /// </summary>
        private void Serialize()
        {
            if (_batchList != null && _batchList.Count > 0)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<NvBatch>));
                    using (TextWriter writer = new StreamWriter(@"batchlist.xml"))
                    {
                        serializer.Serialize(writer, _batchList);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                File.Delete(@"batchlist.xml");
            }
        }

        /// <summary>
        /// Transferring the selected batch instance to the batch list.
        /// </summary>
        private void TransferBatch()
        {
            _batchList[_batchList.IndexOf(_batchList.Single(x => x.Name == _selectedBatch.Name))] = _selectedBatch;
        }

        /// <summary>
        /// Updating batchlist on the left side of the main form.
        /// </summary>
        private void UpdateBatchList()
        {
            //List all Batches to the FlowLayoutPanel.
            if (_batchList != null && _batchList.Count > 0)
            {
                _flpBatchList.Controls.Clear();

                foreach (NvBatch job in _batchList)
                {
                    Button b = new Button();
                    b.BackColor = Color.Transparent;
                    b.TextAlign = ContentAlignment.MiddleLeft;
                    b.Text = job.Name;
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

                    if (job.HostList != null)
                    {
                        if (job.Maintenance)
                        {
                            b.Image = Properties.Resources.Maintenance_32;
                        }
                        else
                        {
                            if (_firstCollectPassed)
                            {
                                if (job.HostList.Any(x => x.ReplyData == null))
                                {
                                    b.Image = Properties.Resources.High_Priority_32_Black;
                                }
                                else
                                {
                                    if (job.HostList.Count(x => x.ReplyData == null || x.ReplyData.Status != IPStatus.Success) > 0)
                                    {
                                        b.Image = Properties.Resources.High_Priority_32_Black;
                                    }
                                    else
                                    {
                                        b.Image = null;
                                    }
                                } 
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
            _sendSummaryTime = Properties.Settings.Default.SendSummeryTime;
            _isSendSummaryEnabled = Properties.Settings.Default.SendSummeryEnabled;
            _deliveryMethod = Properties.Settings.Default.MailDeliveryMethod;

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
            if (_batchList != null && _batchList.Count > 0)
            {
                if (Directory.Exists(_outputDir) == false)
                {
                    Directory.CreateDirectory(_outputDir);
                }

                foreach (NvBatch batch in _batchList)
                {
                    if (!batch.Maintenance)
                    {
                        string csvFile = Path.Combine(_outputDir, batch.Name + ".csv");
                        string csvFileFailed = Path.Combine(_outputDir, batch.Name + "_FailedRequestHistory.csv");
                        string jsFile = Path.Combine(_outputDir, batch.Name + ".js");

                        if (batch.HostList != null && batch.HostList.Count > 0)
                        {
                            //Live CSV output
                            using (StreamWriter swCsv = new StreamWriter(csvFile))
                            {
                                for (int i = 0; i < batch.HostList.Count; i++)
                                {
                                    await swCsv.WriteLineAsync(batch.HostList[i].ToString());
                                }
                            }

                            //History CSV output
                            using (StreamWriter swCsv = new StreamWriter(csvFileFailed, true))
                            {
                                for (int i = 0; i < batch.HostList.Count; i++)
                                {
                                    await swCsv.WriteLineAsync(batch.HostList[i].ToString());
                                }
                            }

                            // Live JS output
                            using (StreamWriter swJs = new StreamWriter(jsFile))
                            {
                                await swJs.WriteAsync(NvManagementClass.ConvertToJsArray(batch));
                            }
                        }  
                    }                  
                }
            }

        }

        public FrmMain()
        {
            InitializeComponent();

            _batchList = Deserialize();

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
                    for (int i = 0; i < _batchList.Count; i++)
                    {
                        if (!_batchList[i].Maintenance)
                        {
                            Task t = _batchList[i].CaptureAsync();
                            t.Wait();
                        }
                    }
                }
                catch (Exception ex)
                {
                    UpdateLogfile("BackgroundWorker", "DoWork()", ex.Message);
                }
            }

            if (arg >= 0)
            {
                try
                {
                    Task t = _batchList[arg].CaptureAsync();
                    t.Wait();
                }
                catch (Exception ex)
                {
                    UpdateLogfile("BackgroundWorker", "DoWork()", ex.Message);
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

            if (frm.ShowDialog() == DialogResult.OK)
            {
                UpdateForm();
            }
        }

        private void _btnAddBatch_Click(object sender, EventArgs e)
        {
            if (_batchList.Any(x => x.Name == "New Batch"))
            {
                DialogResult res = MessageBox.Show($"Batchlist contains a batch with name of >> New Batch <<.\r\nPlease change the name to a unique name.", "Add Batch", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _batchList.Add(new NvBatch());
            _selectedBatch = _batchList.Last();
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
                _batchList.Remove(_selectedBatch);
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
                    _backWorker.RunWorkerAsync(_batchList.IndexOf(_batchList.Single(x => x.Name == _selectedBatch.Name)));
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
                _batchList = NvManagementClass.DeserializeFromCsv(ofd.FileName);
                UpdateBatchList();
            }
        }

        private void _fsw_Changed(object sender, FileSystemEventArgs e)
        {
            if (_isAutoImportEnabled)
            {
                _batchList = NvManagementClass.DeserializeFromCsv(_autoImportCsvPath);
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
                NvManagementClass.SerializeToCsv(sfd.FileName, _batchList);
            }

        }

        private void _lblOutputDir_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", _outputDir);
        }

        private void _btnEditHostList_Click(object sender, EventArgs e)
        {
            FrmManageHosts frm = null;

            if (_selectedBatch.HostList != null)
            {
                frm = new FrmManageHosts(_selectedBatch.HostList);
            }
            else
            {
                frm = new FrmManageHosts();
            }

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _selectedBatch.HostList = frm.HostList;
                TransferBatch();
                DisplayBatch();
            }
        }

        private void _tbxJobDescription_TextChanged(object sender, EventArgs e)
        {
            _selectedBatch.Description = _tbxJobDescription.Text;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Serialize();
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
