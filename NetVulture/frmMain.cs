/*
 * TODO: SMS/Mail wenn das betroffene Gerät wieder Online ist.
 * 
 * 
 * 
 */

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
using Renci.SshNet;

namespace NetVulture
{
    public partial class frmMain : Form
    {
        private List<NVBatch> _batchList;
        private NVBatch _selectedBatch;

        private string _outputDir, _smsGwAddress, _smsGwUser, _smsGwPassword, _mailUser, _mailPw, _mailServer, _autoImportCsvPath;
        private DateTime _lastExecutionTime;
        private BackgroundWorker _backWorker;
        private System.Collections.Specialized.StringCollection _addressList, _mobileNumberList;
        private int _mailServerPort;
        private bool _isEmailAlertingEnabled, _isSmsAlertingEnabled, _isAutoImportEnabled;
        private StringBuilder _sbMailAlertingProtocoll, _sbSmsAlertingProtocoll;

        private void CheckAlert()
        {
            StringBuilder sbMail = new StringBuilder();
            bool _allowSendingMail = false;

            foreach (NVBatch batch in _batchList)
            {
                if (!batch.Maintenance)
                {
                    if (batch.HostList.Any(x => x.ReplyData != null))
                    {
                        IEnumerable<HostInformation> failed = batch.HostList.Where(x => x.ReplyData != null && x.ReplyData.Status != IPStatus.Success);

                        if (failed.Count() > 0)
                        {
                            if (failed.Any(x => x.PingAttempts == 10))
                            {
                                IEnumerable<HostInformation> firstPass = failed.Where(x => x.PingAttempts == 10);

                                //HACK: Uncomment to send html mail.
                                //if (firstPass.Count() > 0)
                                //{
                                //    sbMail.Append("<style type='text/css'>");
                                //    sbMail.Append("h1 { font: 25px consolas, sans-serif; color: #f6f6f6; background-color: #00324b; width: 790px; padding: 10px 5px; text-align:center; }");
                                //    sbMail.Append(".tg { border-collapse: collapse; border-spacing: 0; width: 800px; font: 15px consolas, sans-serif; }");
                                //    sbMail.Append(".tg td { font-weight: bold; padding: 10px 5px; border-style: solid; border-width: 1px; overflow: hidden; word-break: normal; }");
                                //    sbMail.Append(".tg th { font-weight: normal; padding: 10px 15px; border-style: solid; border-width: 1px; overflow: hidden; word-break: normal; color: #4a4a4a; background-color: #f6f6f6; }");
                                //    sbMail.Append(".tg .tg-header { vertical-align: top; color: white; background-color: #e6003c; }");
                                //    sbMail.Append("</style>");
                                //    sbMail.Append("<h1>NetVulture Alerting System</h1>");
                                //    sbMail.Append("<table class='tg'>");
                                //    sbMail.Append("<tr> <th class='tg-header'>Batch</th><th class='tg-header'>Hostname or Address</th><th class='tg-header'>Building</th><th class='tg-header'>Cabinet</th><th class='tg-header'>Rack</th><th class='tg-header'>Last Availability</th><th class='tg-header'>Status</th></tr>");

                                //    foreach (HostInformation hi in firstPass)
                                //    {
                                //        sbMail.Append("<tr><th>" + batch.Name + "</th><th>" + hi.HostnameOrAddress + "</th><th>" + hi.Building + "</th><th>" + hi.Cabinet + "</th><th>" + hi.Rack + "</th><th>" + hi.LastAvailability.ToString() + "</th><th>" + hi.ReplyData.Status.ToString() + "</th></tr>");
                                //    }

                                //    sbMail.Append("</table>");
                                //    _allowSendingMail = true;
                                //}

                                if (firstPass.Count() > 0)
                                {
                                    //Mail
                                    sbMail.AppendLine("NetNulture has detect that hosts are not available from Batch: " + batch.Name);
                                    sbMail.AppendLine(Environment.NewLine);
                                    sbMail.AppendLine("Batch Name: " + batch.Name);
                                    sbMail.AppendLine("Batch Description: " + batch.Description);
                                    sbMail.AppendLine("Hosts Online: " + batch.HostList.Count(x => x.ReplyData.Status == IPStatus.Success).ToString());
                                    sbMail.AppendLine("Hosts Offline: " + firstPass.Count().ToString());
                                    sbMail.AppendLine("Last Execution: " + batch.LastExecution.ToString());
                                    sbMail.AppendLine(Environment.NewLine);

                                    foreach (HostInformation hi in firstPass)
                                    {
                                        sbMail.AppendLine("Host: " + hi.HostnameOrAddress + "\t\tBuilding: " + hi.Building + "\t\tCabinet: " + hi.Cabinet + "\t\tRack: " + hi.Rack + "\t\tLast Availability: " + hi.LastAvailability.ToString() + "\t\tStatus: " + hi.ReplyData.Status.ToString());
                                    }

                                    _allowSendingMail = true;

                                    //SMS
                                    StringBuilder sbSms = new StringBuilder("ATTENTION ");

                                    if (firstPass.Count() > 0)
                                    {
                                        sbSms.Append(firstPass.Count() + " of " + batch.HostList.Count + " hosts from batch " + batch.Name + " are not available after 20 attemps to ping.");
                                    }

                                    Task sender = Task.Run(() => SendSms(sbSms.ToString()));
                                    sender.ContinueWith((t) =>
                                    {
                                        this.Invoke((MethodInvoker)delegate
                                        {
                                            WriteReport();
                                            WriteError("Message Dispatcher", "void CheckAlert()", "Sending SMS successfully");
                                        });
                                    });
                                }
                            }
                        }
                    } 
                }
            }

            if (_allowSendingMail)
            {
                Task task = Task.Run(() => NVManagementClass.SendMail(_mailServer, _mailUser, _mailPw, sbMail.ToString(), _addressList.Cast<string>().ToArray()));
                //Task sender = Task.Run(() => SendMail(sbMail.ToString()));

                task.ContinueWith((t) => {
                    this.Invoke((MethodInvoker)delegate
                    {
                        WriteError("Message Dispatcher", "void CheckAlert()", "Sending E-Mail successfully");
                    });
                });
            }
        }

        private List<NVBatch> Deserialize()
        {
            if (File.Exists(@"batchlist.xml"))
            {
                try
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<NVBatch>));
                    TextReader reader = new StreamReader(@"batchlist.xml");
                    object obj = deserializer.Deserialize(reader);
                    List<NVBatch> lst = (List<NVBatch>)obj;
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
                return new List<NVBatch>();
            }
        }

        private void UpdateBatchList()
        {
            //List all Batches to the FlowLayoutPanel.
            if (_batchList != null && _batchList.Count > 0)
            {
                _flpBatchList.Controls.Clear();

                foreach (NVBatch job in _batchList)
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
                            if (job.HostList.Any(x => x.ReplyData != null))
                            {
                                if (job.HostList.Count(x => x.ReplyData != null && x.ReplyData.Status != IPStatus.Success) > 0)
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

        private void UpdateForm()
        {
            //Get the saved settings from configuration file
            _outputDir = Properties.Settings.Default.OutputDir;
            _lblOutputDir.Text = "Output: " + Environment.NewLine + _outputDir;
            _isEmailAlertingEnabled = Properties.Settings.Default.EmailAlertingEnabled;
            _isAutoImportEnabled = Properties.Settings.Default.AutoloadCsvEnabled;
            _autoImportCsvPath = Properties.Settings.Default.AutoloadCsvPath;

            if (_isEmailAlertingEnabled)
            {
                _lblEmailAlertingStatus.Text = "Email Alerting Status:" + Environment.NewLine + "Enabled";
                _addressList = Properties.Settings.Default.TargetAddresses;

                _mailUser = Properties.Settings.Default.MailUser;
                _mailPw = Properties.Settings.Default.MailPassword;
                _mailServer = Properties.Settings.Default.MailServer;
                _mailServerPort = Properties.Settings.Default.MailServerPort;
            }
            else
            {
                _lblEmailAlertingStatus.Text = "Email Alerting Status:" + Environment.NewLine + "Disabled";
            }

            _isSmsAlertingEnabled = Properties.Settings.Default.SmsAlertingEnabled;

            if (_isSmsAlertingEnabled)
            {
                _lblSmsAlertingStatus.Text = "SMS Alerting Status:" + Environment.NewLine + "Enabled";
                _mobileNumberList = Properties.Settings.Default.MobileNumbers;

                _smsGwAddress = Properties.Settings.Default.GatewayAddress;
                _smsGwUser = Properties.Settings.Default.GatewayUser;
                _smsGwPassword = Properties.Settings.Default.GatewayPassword;
            }
            else
            {
                _lblSmsAlertingStatus.Text = "SMS Alerting Status:" + Environment.NewLine + "Disabled";
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
                _lblLastBatchExec.Text = "Last batch run:\r\n" + _selectedBatch.LastExecution.ToString();
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
                            data = new string[] { _selectedBatch.HostList[i].HostnameOrAddress, "", "", "", "", "", "" };
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

                            data = new string[] { _selectedBatch.HostList[i].HostnameOrAddress, pr.Address.ToString(), _selectedBatch.HostList[i].PhysicalAddress, pr.RoundtripTime.ToString(), _selectedBatch.HostList[i].LastAvailability.ToString(), pr.Status.ToString(), _selectedBatch.HostList[i].PingAttempts.ToString() };
                        }

                        _dgvResults.Rows.Add(data);
                    }

                    _lblCountOfFailedRequests.Text = "Failed Requests:\r\n" + failedRequests.ToString();
                    _lblCountOfSuccessRequests.Text = "Success Requests:\r\n" + successRequests.ToString();
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
        /// Sending short messages to each registered mobile number.
        /// </summary>
        private async Task SendSms(string msg)
        {
            if (_isSmsAlertingEnabled)
            {
                _sbSmsAlertingProtocoll = new StringBuilder();
                _sbSmsAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendSms(): Begin send sms messages.");

                List<Task> taskList = new List<Task>();

                Ping p = new Ping();
                _sbSmsAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendSms(): Ping sms gateway address " + _smsGwAddress);
                PingReply pr = await p.SendPingAsync(_smsGwAddress);

                if (pr.Status != IPStatus.Success)
                {
                    MessageBox.Show("SMS/E-Mail gateway is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _sbSmsAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendSms(): SendSms function canceled because SMS/E-Mail gateway is not available.!");
                    return;
                }

                try
                {
                    _sbSmsAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendSms(): Begin send messages to " + _mobileNumberList.Count + " participants");
                    //Set up the SSH connection
                    using (SshClient _client = new SshClient(_smsGwAddress, _smsGwUser, _smsGwPassword))
                    {
                        //Start the connection
                        _sbSmsAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendSms(): Connecting to ssh server " + _smsGwAddress);
                        _client.Connect();

                        foreach (string nr in _mobileNumberList)
                        {
                            _sbSmsAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendSms(): Run command " + string.Format("echo {0} | sudo -S echo '{1}' | sudo gammu sendsms TEXT '{2}'", "############", msg, nr));
                            SshCommand cmd = _client.RunCommand(string.Format("echo {0} | sudo -S echo '{1}' | sudo gammu sendsms TEXT '{2}'", _smsGwPassword, msg, nr));
                        }
                    }
                }
                catch (ArgumentException aEx)
                {
                    _sbSmsAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendSms(): Error ArgumentException has thrown with message: " + aEx.Message);
                    MessageBox.Show("Missing one or more connection parameters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Net.Sockets.SocketException sEx)
                {
                    _sbSmsAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendSms(): Error System.Net.Sockets.SocketException has thrown with message: " + sEx.Message);
                    MessageBox.Show("Host is not available or connection is interrupted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    _sbSmsAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendSms(): Error " + ex.StackTrace + " has thrown with message: " + ex.Message);
                    throw;
                }
                finally
                {
                    _sbSmsAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendSms(): Send messages successfully. Closing connection and disposing client instance.");
                    WriteReport();
                }
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
                    XmlSerializer serializer = new XmlSerializer(typeof(List<NVBatch>));
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

        private async Task WriteOutput()
        {
            if (_batchList != null && _batchList.Count > 0)
            {
                if (Directory.Exists(_outputDir) == false)
                {
                    Directory.CreateDirectory(_outputDir);
                }

                foreach (NVBatch batch in _batchList)
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
                                    PingReply pr = batch.HostList[i].ReplyData;

                                    string[] data;

                                    if (pr == null)
                                    {
                                        data = new string[] { batch.HostList[i].HostnameOrAddress, "", "", batch.HostList[i].LastAvailability.ToString(), "Unknown", "" };
                                    }
                                    else
                                    {
                                        data = new string[] { batch.HostList[i].HostnameOrAddress, pr.Address.ToString(), pr.RoundtripTime.ToString(), batch.HostList[i].LastAvailability.ToString(), pr.Status.ToString(), batch.HostList[i].PingAttempts.ToString() };
                                    }

                                    await swCsv.WriteLineAsync(string.Join(";", data));
                                }
                            }

                            //History CSV output
                            using (StreamWriter swCsv = new StreamWriter(csvFileFailed, true))
                            {
                                for (int i = 0; i < batch.HostList.Count; i++)
                                {
                                    PingReply pr = batch.HostList[i].ReplyData;

                                    if (pr == null)
                                    {
                                        await swCsv.WriteLineAsync(string.Join(";", batch.HostList[i].HostnameOrAddress, "", "", batch.HostList[i].LastAvailability.ToString(), "", ""));
                                    }
                                    else
                                    {
                                        if (pr.Status != IPStatus.Success)
                                        {
                                            await swCsv.WriteLineAsync(string.Join(";", batch.HostList[i].HostnameOrAddress, pr.Address.ToString(), pr.RoundtripTime.ToString(), batch.HostList[i].LastAvailability.ToString(), pr.Status.ToString(), batch.HostList[i].PingAttempts.ToString())); 
                                        }
                                    }
                                }
                            }

                            // Live JS output
                            using (StreamWriter swJs = new StreamWriter(jsFile))
                            {
                                string[] jsArrayElements = new string[batch.HostList.Count];

                                for (int i = 0; i < batch.HostList.Count; i++)
                                {
                                    PingReply pr = batch.HostList[i].ReplyData;

                                    string[] data;

                                    if (pr == null)
                                    {
                                        data = new string[] { batch.HostList[i].HostnameOrAddress, "", "", batch.HostList[i].LastAvailability.ToString(), "Unknown", "" };
                                    }
                                    else
                                    {
                                        data = new string[] { batch.HostList[i].HostnameOrAddress, pr.Address.ToString(), pr.RoundtripTime.ToString(), batch.HostList[i].LastAvailability.ToString(), pr.Status.ToString(), batch.HostList[i].PingAttempts.ToString() };
                                    }

                                    //['Target Address or Name','ReceivedIp','RoundTrip','ExecutionTime','Status','Attemps']
                                    jsArrayElements[i] = "['" + data[0] + "','" + data[1] + "','" + data[2] + "','" + data[3] + "','" + data[4] + "','" + data[5] + "']";
                                }

                                await swJs.WriteAsync("var " + batch.Name + " = [" + string.Join(",", jsArrayElements) + "];");
                            }
                        }  
                    }                  
                }
            }

        }

        private async void WriteError(string type, string src, string msg)
        {
            try
            {
                string file = "Log.log";

                //Create file if not exists
                if (!File.Exists(file)) File.Create(file);

                using (StreamWriter sw = new StreamWriter(file, true))
                {
                    await sw.WriteLineAsync("Type: " + type + " # Soruce: " + src + " # Time: " + DateTime.Now.ToString() + " # Message: " + msg);
                }

                Debug.Print("Type: " + type + " # Soruce: " + src + " # Time: " + DateTime.Now.ToString() + " # Message: " + msg);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void WriteReport()
        {
            string fileMail = Path.Combine(Application.StartupPath, "logs", "MailAlertingProtocoll_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss" + ".log"));
            string fileSms = Path.Combine(Application.StartupPath, "logs", "SmsAlertingProtocoll_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss" + ".log"));

            if (!Directory.Exists(Path.Combine(Application.StartupPath, "logs")))
            {
                Directory.CreateDirectory(Path.Combine(Application.StartupPath, "logs"));
            }

            if (_sbMailAlertingProtocoll != null)
            {
                using (StreamWriter sw = new StreamWriter(fileMail))
                {
                    await sw.WriteAsync(_sbMailAlertingProtocoll.ToString());
                } 
            }

            if (_sbSmsAlertingProtocoll != null)
            {
                using (StreamWriter sw = new StreamWriter(fileSms))
                {
                    await sw.WriteAsync(_sbSmsAlertingProtocoll.ToString());
                } 
            }
        }

        public frmMain()
        {
            InitializeComponent();
            _batchList = Deserialize();

            _backWorker = new BackgroundWorker();
            _backWorker.DoWork += _backWorker_DoWork;
            _backWorker.RunWorkerCompleted += _backWorker_RunWorkerCompleted;

            UpdateBatchList();
            UpdateForm();
        }

        private async void _backWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            await WriteOutput();
            CheckAlert();

            _lblLastCollect.Text = "Last Overall Execution: " + Environment.NewLine + _lastExecutionTime.ToString();
            _btnCollect.Enabled = true;
            _btnCollect.BackColor = Color.FromArgb(0, 50, 75);
            _lastExecutionTime = DateTime.Now;
            _btnShowReport.Enabled = true;
            _pnlSubMenuBatch.Enabled = true;

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
                    _btnShowReport.Enabled = false;
                });
            }

            if (arg == -1)
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

            if (arg >= 0)
            {
                Task t = _batchList[arg].CaptureAsync();
                t.Wait();
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
            frmSettings frm = new frmSettings();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                UpdateForm();
            }
        }

        private void _btnAddBatch_Click(object sender, EventArgs e)
        {
            _batchList.Add(new NVBatch());
            UpdateBatchList();
        }

        private void _tbxJobName_TextChanged(object sender, EventArgs e)
        {
            _selectedBatch.Name = _tbxJobName.Text;
        }

        private void _tbxJobDescription_Leave(object sender, EventArgs e)
        {
            TransferBatch();
            UpdateBatchList();
        }

        private void _RemoveSelectedBatch_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to remove this batch?", "Remove Batch", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                _batchList = NVManagementClass.DeserializeFromCsv(ofd.FileName);
                UpdateBatchList();
            }
        }

        private void _fsw_Changed(object sender, FileSystemEventArgs e)
        {
            if (_isAutoImportEnabled)
            {
                _batchList = NVManagementClass.DeserializeFromCsv(_autoImportCsvPath);
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
                NVManagementClass.SerializeToCsv(sfd.FileName, _batchList);
            }

        }

        private void _lblOutputDir_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", _outputDir);
        }

        private void _btnEditHostList_Click(object sender, EventArgs e)
        {
            frmManageHosts frm = null;

            if (_selectedBatch.HostList != null)
            {
                frm = new frmManageHosts(_selectedBatch.HostList);
            }
            else
            {
                frm = new frmManageHosts();
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

        private void _btnShowReport_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport(_batchList);

            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
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
            TransferBatch();
            UpdateForm();
            
        }

        private void _clock_Tick(object sender, EventArgs e)
        {
            _lblClock.Text = "Systemtime\r\n" + DateTime.Now.ToString();
        }
    }
}
