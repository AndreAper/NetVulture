/*
 * TODO: Alle nicht erfolgreichen Echo-Anfragen in einer History speichern.
 * TODO: Icon für Fails von allen batches
 * TODO: Form für Ausgabe der Fails als liste.
 * TODO: DNS auslesen über IP
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
        private string _outputDir, _smsGwAddress, _smsGwUser, _smsGwPassword, _mailUser, _mailPw, _mailServer;
        private DateTime _lastExecutionTime;
        private BackgroundWorker _backWorker;
        private System.Collections.Specialized.StringCollection _addressList, _mobileNumberList;
        private int _mailServerPort;
        private bool _isEmailAlertingEnabled, _isSmsAlertingEnabled;

        private void CheckAndAlert()
        {
            StringBuilder sbMail = new StringBuilder("ATTENTION: The followed hosts are not available.");
            bool _allowSendingMail = false;

            if (_batchList.Any(x => x.FailedHosts.Count > 0))
            {
                _lblAppTitle.Image = Properties.Resources.High_Priority_32;
            }
            else
            {
                _lblAppTitle.Image = null;
            }

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

                        MessageBox.Show("Sending sms...");
                        //SendSms(sbSms.ToString());
                    }


                }
            }


            if (_allowSendingMail)
            {
                MessageBox.Show("Sending mail...");
                //SendEmail(sbMail.ToString());
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
            int slctdBatch = _lbxJobs.SelectedIndex;

            _lbxJobs.Items.Clear();

            if (_batchList != null && _batchList.Count > 0)
            {
                foreach (NVBatch job in _batchList)
                {
                    if (String.IsNullOrEmpty(job.Name))
                    {
                        job.Name = "- Unsaved Batch -";
                    }

                    _lbxJobs.Items.Add(job.Name);
                }
                _lbxJobs.SelectedIndex = slctdBatch;
            }
            else
            {
                _pnlJobInfo.Visible = false;
            }
            _outputDir = Properties.Settings.Default.OutputDir;
            _lblOutputDir.Text = "Output: " + Environment.NewLine + _outputDir;
            _lblClock.Text = "Systemtime\r\n" + DateTime.Now.ToString();

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

                        //TEST: Unterstützt das RPI asynchrones ausführen der shell kommandos???????
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

        private void ShowJobInfo()
        {
            if (_lbxJobs.SelectedIndex != -1)
            {
                _pnlJobInfo.Visible = true;

                NVBatch job = _batchList.ElementAt(_lbxJobs.SelectedIndex);

                _tbxJobName.Text = job.Name;
                _tbxJobDescription.Text = job.Description;
                _tbxTimeOut.Text = job.Timeout.ToString();
                _tbxBufferSize.Text = job.Buffersize.ToString();
                _lblLastBatchExec.Text = "Last execution: " + job.LastExecution.ToString();

                if (job.HostList != null && job.HostList.Count > 0)
                {
                    _lbxHostList.Items.Clear();
                    _lbxHostList.Items.AddRange(job.HostList.ToArray());
                    _btnExecBatch.Enabled = true;

                    if (job.Results != null && job.Results.Count > 0)
                    {
                        dgvResults.Rows.Clear();

                        for (int i = 0; i < job.Results.Count; i++)
                        {
                            PingReply pr = job.Results[i];

                            string[] data;

                            if (pr.Address == null)
                            {
                                data = new string[] { job.HostList[i], "0.0.0.0", "0", job.LastExecution.ToString(), pr.Status.ToString(), "-1"};
                            }
                            else
                            {
                                int attempts = 0;

                                if (pr.Status != IPStatus.Success)
                                {
                                    attempts = job.FailedHosts[pr.Address.ToString()];
                                }
                                data = new string[] { job.HostList[i], pr.Address.ToString(), pr.RoundtripTime.ToString(), job.LastExecution.ToString(), pr.Status.ToString(), attempts.ToString() };
                            }

                            dgvResults.Rows.Add(data);
                        }
                    }
                    else
                    {
                        dgvResults.Rows.Clear();
                    }

                    if (job.FailedHosts.Count == 0)
                    {
                        _lblCountOfFailedRequests.Text = "Failed Requests: 0";
                        _lblCountOfSuccessRequests.Text = "Success Requests: 0";
                    }
                    else
                    {
                        _lblCountOfFailedRequests.Text = "Failed Requests: " + job.Results.Where(x => x.Status != IPStatus.Success).Count().ToString();
                        _lblCountOfSuccessRequests.Text = "Success Requests: " + job.Results.Where(x => x.Status == IPStatus.Success).Count().ToString();
                    }
                }
                else
                {
                    _lbxHostList.Items.Clear();
                    _btnExecBatch.Enabled = false;
                }
            }
            else
            {
                _pnlJobInfo.Visible = false;
            }
        }

        private void UpdateResultsOutput()
        {
            if (_lbxJobs.SelectedIndex != -1)
            {
                NVBatch job = _batchList.ElementAt(_lbxJobs.SelectedIndex);

                if (job.Results != null)
                {
                    if (job.Results.Count > 0)
                    {
                        dgvResults.Rows.Clear();

                        for (int i = 0; i < job.Results.Count; i++)
                        {
                            PingReply pr = job.Results[i];

                            string[] data;

                            if (pr.Address == null)
                            {
                                data = new string[] { job.HostList[i], "0.0.0.0", "0", job.LastExecution.ToString(), pr.Status.ToString(), "-1" };
                            }
                            else
                            {
                                
                                data = new string[] { job.HostList[i], pr.Address.ToString(), pr.RoundtripTime.ToString(), job.LastExecution.ToString(), pr.Status.ToString(), "1"};
                            }

                            dgvResults.Rows.Add(data);
                        }
                    }
                }
                else
                {
                    dgvResults.Rows.Clear();
                } 
            }
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
            CheckAndAlert();

            _lblLastCollect.Text = "Last Execution: " + Environment.NewLine + _lastExecutionTime.ToString();
            _btnCollect.Enabled = true;
            _btnCollect.BackColor = Color.Transparent;
            _btnExecBatch.Enabled = true;
            _pnlJobInfo.Enabled = true;
            _lastExecutionTime = DateTime.Now;

            ShowJobInfo();
        }

        private void _backWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int arg = (int)e.Argument;

            if (this.InvokeRequired) { this.Invoke((MethodInvoker) delegate {
                    _pnlJobInfo.Enabled = false;
                    _btnCollect.Enabled = false;
                    _btnCollect.BackColor = Color.DodgerBlue;
                    _btnExecBatch.Enabled = false;               
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

        private void _lbxJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowJobInfo();
        }

        private void _lnkLblChangeHostList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_lbxJobs.SelectedIndex != -1)
            {
                frmManageHosts frm = null;

                if (_batchList[_lbxJobs.SelectedIndex].HostList != null)
                {
                    frm = new frmManageHosts(_batchList[_lbxJobs.SelectedIndex].HostList);
                }
                else
                {
                    frm = new frmManageHosts();
                }

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _batchList[_lbxJobs.SelectedIndex].HostList = frm.HostList;
                    ShowJobInfo();
                }
            }
        }

        private void _btnExecBatch_Click(object sender, EventArgs e)
        {
            if (_lbxJobs.SelectedIndex != -1)
            {
                if (String.IsNullOrEmpty(_outputDir))
                {
                    MessageBox.Show("No output directory selcted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _backWorker.RunWorkerAsync(_lbxJobs.SelectedIndex);
                    ShowJobInfo();
                }
            }
        }

        private void _btnCollect_Click(object sender, EventArgs e)
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
            _lbxJobs.SelectedIndex = (_lbxJobs.Items.Count - 1);
        }

        private void _tbxJobName_TextChanged(object sender, EventArgs e)
        {
            if (_lbxJobs.SelectedIndex != -1)
            {
                _batchList[_lbxJobs.SelectedIndex].Name = _tbxJobName.Text;
            }
        }

        private void _tbxJobDescription_TextChanged(object sender, EventArgs e)
        {
            if (_lbxJobs.SelectedIndex != -1)
            {
                _batchList[_lbxJobs.SelectedIndex].Description = _tbxJobDescription.Text;
            }
        }

        private void _tbxTimeOut_TextChanged(object sender, EventArgs e)
        {
            if (_lbxJobs.SelectedIndex != -1)
            {
                _batchList[_lbxJobs.SelectedIndex].Timeout = Convert.ToInt32(_tbxTimeOut.Text);
            }
        }

        private void _tbxBufferSize_TextChanged(object sender, EventArgs e)
        {
            if (_lbxJobs.SelectedIndex != -1)
            {
                _batchList[_lbxJobs.SelectedIndex].Buffersize = Convert.ToInt32(_tbxBufferSize.Text);
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

            ShowJobInfo();
        }

        private void _tbxJobName_Leave(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void _clock_Tick(object sender, EventArgs e)
        {
            _lblClock.Text = "Systemtime\r\n" + DateTime.Now.ToString();
        }

        private void _btnRemoveBatch_Click(object sender, EventArgs e)
        {
            if (_lbxJobs.SelectedIndex != -1)
            {
                DialogResult res = MessageBox.Show("Do you want to remove this batch?", "Remove Batch", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    _batchList.RemoveAt(_lbxJobs.SelectedIndex); 
                    UpdateForm();
                }
            }
        }
    }
}
