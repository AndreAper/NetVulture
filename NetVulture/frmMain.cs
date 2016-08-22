/*
 * TODO: Alle nicht erfolgreichen Echo-Anfragen in einer History speichern.
 * TODO: Report nach csv exportieren.
 * TODO: SendSMS und SendMail in frmMain implementieren.
 * TODO: Reportbutton bei aktiver Pingausführen weil die ResultList nicht übergeben werden kann da sie NULL ist.
 * TODO: Enumeration "HostMode" implermentieren mit den elementen "Active, Maintenance, Fault, AwaitNewReply"
 * TODO: Vor senden der Email via SSH die Internetverbindung auf dem Gateway aktivieren und Google.com anpingen. 
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
using System.Net.Mail;
using System.Net;
using System.Diagnostics;
using Renci.SshNet;
using System.Threading;

namespace NetVulture
{
    public partial class frmMain : Form
    {
        private List<NVBatch> _batchList;
        private NVBatch _selectedBatch;

        private string _outputDir, _smsGwAddress, _smsGwUser, _smsGwPassword, _mailUser, _mailPw, _mailServer;
        private DateTime _lastExecutionTime;
        private BackgroundWorker _backWorker;
        private System.Collections.Specialized.StringCollection _addressList, _mobileNumberList;
        private int _mailServerPort;
        private bool _isEmailAlertingEnabled, _isSmsAlertingEnabled;

        private void CheckAlert()
        {
            StringBuilder sbMail = new StringBuilder("ATTENTION: The followed hosts are not available.");
            bool _allowSendingMail = false;

            foreach (NVBatch batch in _batchList)
            {
                if (batch.FailedHosts.Count > 0)
                {
                    if (batch.FailedHosts.Any(x => x.Value == 10))
                    {
                        IEnumerable<KeyValuePair<string, int>> firstPass = batch.FailedHosts.Where(x => x.Value == 10);

                        if (firstPass.Count() > 0)
                        {
                            sbMail.AppendLine(Environment.NewLine);

                            foreach (string failedAddress in batch.FailedHosts.Keys)
                            {
                                //{BATCHNAME}       {TARGTE_DNS_IP}     {STAUS} 
                                sbMail.AppendLine(batch.Name + "\t\t" + failedAddress);
                                sbMail.AppendLine(Environment.NewLine);
                            }

                            sbMail.AppendLine(Environment.NewLine);
                            _allowSendingMail = true;
                        }
                    }

                    if (batch.FailedHosts.Any(x => x.Value == 20))
                    {
                        StringBuilder sbSms = new StringBuilder("ATTENTION:");

                        IEnumerable<KeyValuePair<string, int>> secondPass = batch.FailedHosts.Where(x => x.Value == 20);

                        if (secondPass.Count() > 0)
                        {
                            sbSms.Append(secondPass.Count() + " of " + batch.HostList.Count + "hosts from batch: " + batch.Name + " are not available after 20 attemps to ping.");
                        }

                        Task.Run(()=> WriteError("Message Dispatcher", "void CheckAlert()", "Sending SMS successfully"));
                        SendSms(sbSms.ToString());
                    }

                }
            }


            if (_allowSendingMail)
            {
                Task.Run(() => WriteError("Message Dispatcher", "void CheckAlert()", "Sending E-Mail successfully"));
                SendEmail(sbMail.ToString());
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

        private void UpdateForm()
        {
            //Get the saved settings from configuration file
            _outputDir = Properties.Settings.Default.OutputDir;
            _lblOutputDir.Text = "Output: " + Environment.NewLine + _outputDir;
            _isEmailAlertingEnabled = Properties.Settings.Default.EmailAlertingEnabled;

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

                    if (job.FailedHosts.Count > 0)
                    {
                        b.Image = Properties.Resources.High_Priority_32_Black;
                    }
                    else
                    {
                        b.Image = null;
                    }

                    _flpBatchList.Controls.Add(b);
                }

                //TODO: Von hier aus noch ShowBatch() aufrufen? Zum anzeigen des zu letzt gewählte Batch??????
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
                _lblLastBatchExec.Text = "Last execution:\r\n" + _selectedBatch.LastExecution.ToString();

                if (_selectedBatch.HostList != null && _selectedBatch.HostList.Count > 0)
                {
                    if (_selectedBatch.Results != null && _selectedBatch.Results.Count > 0)
                    {
                        _dgvResults.Rows.Clear();

                        for (int i = 0; i < _selectedBatch.Results.Count; i++)
                        {
                            PingReply pr = _selectedBatch.Results[i];

                            string[] data;

                            if (pr == null)
                            {
                                data = new string[] { _selectedBatch.HostList[i], "", "", _selectedBatch.LastExecution.ToString(), "Unknown", "" };
                            }
                            else
                            {
                                int attempts = 0;

                                if (pr.Status != IPStatus.Success)
                                {
                                    attempts = _selectedBatch.FailedHosts[_selectedBatch.HostList[i]];
                                }

                                data = new string[] { _selectedBatch.HostList[i], pr.Address.ToString(), pr.RoundtripTime.ToString(), _selectedBatch.LastExecution.ToString(), pr.Status.ToString(), attempts.ToString() };
                            }

                            _dgvResults.Rows.Add(data);
                        }
                    }
                    else
                    {
                        _dgvResults.Rows.Clear();

                        for (int i = 0; i < _selectedBatch.HostList.Count; i++)
                        {
                            _dgvResults.Rows.Add(_selectedBatch.HostList[i], "", "", "", "", "");
                        }
                    }

                    if (_selectedBatch.FailedHosts.Count == 0)
                    {
                        _lblCountOfFailedRequests.Text = "Failed Requests:\r\n0";
                        _lblCountOfSuccessRequests.Text = "Success Requests:\r\n0";
                    }
                    else
                    {
                        _lblCountOfFailedRequests.Text = "Failed Requests:\r\n" + _selectedBatch.Results.Where(x => x.Status != IPStatus.Success).Count().ToString();
                        _lblCountOfSuccessRequests.Text = "Success Requests:\r\n" + _selectedBatch.Results.Where(x => x.Status == IPStatus.Success).Count().ToString();
                    }

                    _pnlSubMenuBatch.Enabled = true;
                    _tbxJobName.Enabled = true;
                    _tbxJobDescription.Enabled = true;
                    _dgvResults.Enabled = true;
                }
                else
                {
                    _pnlSubMenuBatch.Enabled = false;
                    _tbxJobName.Enabled = false;
                    _tbxJobDescription.Enabled = false;
                    _dgvResults.Enabled = false;

                    _dgvResults.Rows.Clear();
                } 
            }
        }

        /// <summary>
        /// Sending short messages to each registered mobile number.
        /// </summary>
        private async void SendSms(string msg)
        {
            if (_isSmsAlertingEnabled)
            {
                SshClient client = null;
                List<Task> taskList = new List<Task>();

                Ping p = new Ping();
                PingReply pr = await p.SendPingAsync(_smsGwAddress);

                if (pr.Status != IPStatus.Success)
                {
                    MessageBox.Show("Host is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    //Set up the SSH connection
                    using (client = new SshClient(_smsGwAddress, _smsGwUser, _smsGwPassword))
                    {
                        //Start the connection
                        client.Connect();

                        foreach (string nr in Properties.Settings.Default.MobileNumbers)
                        {
                            SshCommand cmd = client.RunCommand("echo " + _smsGwPassword + " | sudo -S echo \"" + msg + "\" | sudo gammu sendsms TEXT \"" + nr + "\"");
                            StreamReader reader = new StreamReader(cmd.OutputStream);
                            string text = reader.ReadToEnd();
                        }
                    }
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Missing one or more connection parameters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Net.Sockets.SocketException)
                {
                    MessageBox.Show("Host is not available or connection is interrupted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (ObjectDisposedException)
                {

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {

                }
            }
        }

        /// <summary>
        /// Send email using smtp client.
        /// </summary>
        private void SendEmail(string msg)
        {
            /* 
             * E-Mail Address: monitoring.bbs@gmail.com 
             * Username: monitoring.bbs@gmail.com 
             * Password: Moni2015@ 
             *  
             * Server: smtp.gmail.com 
             * Port: 587 
             */

            if (_isEmailAlertingEnabled)
            {
                if (_addressList.Count > 0)
                {
                    SmtpClient client = new SmtpClient(_mailServer, _mailServerPort);
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(_mailUser, _mailPw);

                    MailMessage mm = new MailMessage();
                    mm.From = new MailAddress(_mailUser);

                    foreach (string adr in _addressList)
                    {
                        mm.To.Add(new MailAddress(adr));
                    }


                    mm.Subject = "NetVulture Alterting Service";
                    mm.Body = msg;
                    mm.BodyEncoding = UTF8Encoding.UTF8;
                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;


                    try
                    {
                        client.Send(mm);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else
                {
                    return;
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

                foreach (NVBatch job in _batchList)
                {
                    string csvFile = Path.Combine(_outputDir, job.Name + ".csv");
                    string jsFile = Path.Combine(_outputDir, job.Name + ".js");

                    if (job.Results != null && job.Results.Count > 0)
                    {
                        using (StreamWriter swCsv = new StreamWriter(csvFile))
                        {
                            for (int i = 0; i < job.Results.Count; i++)
                            {
                                PingReply pr = job.Results[i];

                                string[] data;

                                if (pr != null)
                                {
                                    if (pr.Address == null)
                                    {
                                        data = new string[] { job.HostList[i], "0.0.0.0", "0", job.LastExecution.ToString(), pr.Status.ToString() };
                                    }
                                    else
                                    {
                                        data = new string[] { job.HostList[i], pr.Address.ToString(), pr.RoundtripTime.ToString(), job.LastExecution.ToString(), pr.Status.ToString() };
                                    }
                                }
                                else
                                {
                                    data = new string[] { job.HostList[i], "0.0.0.0", "0", job.LastExecution.ToString(), "Unknown" };
                                }

                                await swCsv.WriteLineAsync(string.Join(",", data));
                            }
                        }

                        using (StreamWriter swJs = new StreamWriter(jsFile))
                        {
                            string[] jsArrayElements = new string[job.Results.Count];

                            for (int i = 0; i < job.Results.Count; i++)
                            {
                                PingReply pr = job.Results[i];
                                string[] data;

                                if (pr != null)
                                {
                                    if (pr.Address == null)
                                    {
                                        data = new string[] { job.HostList[i], "0.0.0.0", "0", job.LastExecution.ToString(), IPStatus.Unknown.ToString() };
                                    }
                                    else
                                    {
                                        data = new string[] { job.HostList[i], pr.Address.ToString(), pr.RoundtripTime.ToString(), job.LastExecution.ToString(), pr.Status.ToString() };
                                    }
                                }
                                else
                                {
                                    data = new string[] { job.HostList[i], "0.0.0.0", "0", job.LastExecution.ToString(), IPStatus.Unknown.ToString() };
                                }

                                //['Target Address or Name','ReceivedIp','RoundTrip','ExecutionTime','Status']
                                jsArrayElements[i] = "['" + data[0] + "','" + data[1] + "','" + data[2] + "','" + data[3] + "','" + data[4] + "']";
                            }

                            await swJs.WriteAsync("var " + job.Name + " = [" + string.Join(",", jsArrayElements) + "];");
                        }
                    }                   
                }
            }

        }

        private async Task WriteError(string type, string src, string msg)
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

        public frmMain()
        {
            InitializeComponent();
            _batchList = Deserialize();

            _backWorker = new BackgroundWorker();
            _backWorker.DoWork += _backWorker_DoWork;
            _backWorker.RunWorkerCompleted += _backWorker_RunWorkerCompleted;

            UpdateForm();
        }

        private async void _backWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            await WriteOutput();
            CheckAlert();

            _lblLastCollect.Text = "Last Execution: " + Environment.NewLine + _lastExecutionTime.ToString();
            _btnCollect.Enabled = true;
            _btnCollect.BackColor = Color.FromArgb(0, 50, 75);
            _lastExecutionTime = DateTime.Now;

            UpdateForm();
            DisplayBatch();
        }

        private void _backWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int arg = (int)e.Argument;

            if (this.InvokeRequired) { this.Invoke((MethodInvoker) delegate {
                    _btnCollect.BackColor = Color.FromArgb(255, 155, 50);             
                });
            }

            if (arg == -1)
            {
                for (int i = 0; i < _batchList.Count; i++)
                {
                    Task t = _batchList[i].Capture();
                    t.Wait();
                }
            }

            if (arg >= 0)
            {
                Task t = _batchList[arg].Capture();
                t.Wait();
            }
        }

        private void _btnCollect_Click(object sender, EventArgs e)
        {
            if (_backWorker.IsBusy)
            {
                MessageBox.Show("The collect process is already running...");
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
            UpdateForm();
        }

        private void _tbxJobName_TextChanged(object sender, EventArgs e)
        {
            _selectedBatch.Name = _tbxJobName.Text;
        }

        private void _tbxJobDescription_Leave(object sender, EventArgs e)
        {
            TransferBatch();
            UpdateForm();
        }

        private void _RemoveSelectedBatch_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to remove this batch?", "Remove Batch", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                _batchList.Remove(_selectedBatch);
                UpdateForm();
            }
        }

        private void _btnRunSelectedBatch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_outputDir))
            {
                MessageBox.Show("No output directory selcted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _backWorker.RunWorkerAsync(_batchList.IndexOf(_batchList.Single(x => x.Name == _selectedBatch.Name)));
                DisplayBatch();
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            foreach (Button btn in _flpBatchList.Controls.Cast<Button>())
            {
                btn.Width = _flpBatchList.Width;
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
            _backWorker.RunWorkerAsync(-1);
        }

        private void _chkBtnTimerEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _collectTimer.Enabled = _chkBtnTimerEnabled.Checked;

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
