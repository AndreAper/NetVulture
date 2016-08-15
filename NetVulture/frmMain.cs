/*
 * TODO: Jeden Host 4 mal anpingen und TimedOut auf 1000ms setzen damit "package lost" berücksichtigt wird.
 * TODO: Alle nicht erfolgreichen Echo-Anfragen in einer History speichern.
 * TODO: E-Mail Parameter einstellbar über frmSettings.
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

        /// <summary>
        /// {Batch Name} {Target DNS or IP} {PingReply}
        /// </summary>
        private List<Tuple<string, string, PingReply>> _failedRequests;
        private string _outputDir, _smsGwAddress, _smsGwUser, _smsGwPassword, _mailUser, _mailPw, _mailServer;
        private DateTime _lastExecutionTime, _timeOfLastFirstAlert, _timeOfLastSecondAlert;
        private BackgroundWorker _backWorker;
        private System.Collections.Specialized.StringCollection _addressList, _mobileNumberList;
        private bool _firstAlertPassed = false, _secondAlertPassed = false;
        private int _overallPingAttempts = 0, _mailServerPort;
        private bool _isEmailAlertingEnabled, _isSmsAlertingEnabled;

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
            }
            else
            {
                _pnlJobInfo.Visible = false;
            }
            _outputDir = Properties.Settings.Default.OutputDir;
            _lblOutputDir.Text = "Output: " + _outputDir;
            _lblClock.Text = DateTime.Now.ToString();

            _isEmailAlertingEnabled = Properties.Settings.Default.EmailAlertingEnabled;

            if (_isEmailAlertingEnabled)
            {
                _lblEmailAlertingStatus.Text = "Email Alerting Status: Enabled";
                _addressList = Properties.Settings.Default.TargetAddresses;

                _mailUser = Properties.Settings.Default.MailUser;
                _mailPw = Properties.Settings.Default.MailPassword;
                _mailServer = Properties.Settings.Default.MailServer;
                _mailServerPort = Properties.Settings.Default.MailServerPort;
            }
            else
            {
                _lblEmailAlertingStatus.Text = "Email Alerting Status: Disabled";
            }

            _isSmsAlertingEnabled = Properties.Settings.Default.SmsAlertingEnabled;

            if (_isSmsAlertingEnabled)
            {
                _lblSmsAlertingStatus.Text = "SMS Alerting Status: Enabled";
                _mobileNumberList = Properties.Settings.Default.MobileNumbers;

                _smsGwAddress = Properties.Settings.Default.GatewayAddress;
                _smsGwUser = Properties.Settings.Default.GatewayUser;
                _smsGwPassword = Properties.Settings.Default.GatewayPassword;
            }
            else
            {
                _lblSmsAlertingStatus.Text = "SMS Alerting Status: Disabled";
            }
        }

        /// <summary>
        /// Send email using smtp client.
        /// </summary>
        private void SendEmail()
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
                if (_failedRequests.Count > 0)
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

                        StringBuilder sbResults = new StringBuilder("WARNING: The followed hosts are not available.");
                        sbResults.AppendLine(Environment.NewLine);


                        foreach (var item in _failedRequests)
                        {
                            //{BATCHNAME}       {TARGTE_DNS_IP}     {STAUS} 
                            sbResults.AppendLine(item.Item1 + "\t\t" + item.Item2 + "\t\t" + item.Item3.Status.ToString());
                            sbResults.AppendLine(Environment.NewLine);
                        }


                        mm.Body = sbResults.ToString();
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
                NVBatch job = _batchList.ElementAt(_lbxJobs.SelectedIndex);

                _tbxJobName.Text = job.Name;
                _tbxJobDescription.Text = job.Description;
                _tbxTimeOut.Text = job.Timeout.ToString();
                _tbxBufferSize.Text = job.Buffersize.ToString();
                _lblLastBatchExec.Text = "Last execution of current batch: " + job.LastExecution.ToString();

                _pnlJobInfo.Visible = true;

                if (job.HostList != null)
                {
                    _lbxHostList.Items.Clear();

                    if (job.HostList.Count > 0)
                    {
                        foreach (string host in job.HostList)
                        {
                            _lbxHostList.Items.Add(host);
                        }

                        _btnExecBatch.Enabled = true;

                        if (_backWorker.IsBusy == false)
                        {
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
                                            data = new string[] { job.HostList[i], "0.0.0.0", "0", job.LastExecution.ToString(), pr.Status.ToString() };
                                        }
                                        else
                                        {
                                            data = new string[] { job.HostList[i], pr.Address.ToString(), pr.RoundtripTime.ToString(), job.LastExecution.ToString(), pr.Status.ToString() };
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
                    else
                    {
                        _lbxHostList.Items.Clear();
                        _btnExecBatch.Enabled = false;
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
                                data = new string[] { job.HostList[i], "0.0.0.0", "0", job.LastExecution.ToString(), pr.Status.ToString() };
                            }
                            else
                            {
                                data = new string[] { job.HostList[i], pr.Address.ToString(), pr.RoundtripTime.ToString(), job.LastExecution.ToString(), pr.Status.ToString() };
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
            if (_backWorker.IsBusy == false)
            {
                await WriteOutput();

                if (_failedRequests.Count == 0)
                {
                    _firstAlertPassed = false;
                    _secondAlertPassed = false;
                    _overallPingAttempts = 0;

                    _lblCountOfFailedRequests.Text = "Failed Requests: none";
                    _lblFirstAlertTime.Text = "First Alert Pass:";
                    _lblSecondAlertTime.Text = "Second Alert Pass:";
                    _lblOverallPingAttempts.Text = "Overall Attempts:";
                }
                else
                {
                    _lblCountOfFailedRequests.Text = "Failed Requests: " + _failedRequests.Count.ToString();

                    _overallPingAttempts++;

                    _lblOverallPingAttempts.Text = "Overall Attempts: " + _overallPingAttempts.ToString();

                    if (_firstAlertPassed == false)
                    {
                        SendEmail();
                        _lblFirstAlertTime.Text = "First Alert Pass: " + DateTime.Now.ToString();
                        _timeOfLastFirstAlert = DateTime.Now;
                        _firstAlertPassed = true;
                    }
                    else
                    {
                        if (_overallPingAttempts == 10)
                        {
                            if (_secondAlertPassed == false)
                            {
                                SendEmail();
                                _secondAlertPassed = true;
                                _timeOfLastSecondAlert = DateTime.Now;
                                _lblSecondAlertTime.Text = "Second Alert Pass: " + DateTime.Now.ToString();
                            }
                        }
                    }
                }

                _lblLastCollect.Text = "Last Execution: " + _lastExecutionTime.ToString();
                _btnCollect.Enabled = true;
                _btnCollect.BackColor = Color.Transparent;
                _btnExecBatch.Enabled = true;
                ShowJobInfo(); 
            }
        }

        private void _backWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int arg = (int)e.Argument;
            if (_btnCollect.InvokeRequired)
            {
                _btnCollect.Invoke((MethodInvoker) delegate 
                {
                    _btnCollect.Enabled = false;
                    _btnCollect.BackColor = Color.DodgerBlue;
                    _btnExecBatch.Enabled = false;               
                });
            }

            _failedRequests = new List<Tuple<string, string, PingReply>>();

            if (arg == -1)
            {
                for (int i = 0; i < _batchList.Count; i++)
                {
                    if (NetworkInterface.GetIsNetworkAvailable())
                    {
                        if (_batchList[i].HostList != null)
                        {
                            if (_batchList[i].HostList.Count > 0)
                            {
                                _batchList[i].Results = new List<PingReply>();
                                _batchList[i].LastExecution = DateTime.Now;

                                for (int j = 0; j < _batchList[i].HostList.Count; j++)
                                {
                                    Ping p = new Ping();
                                    PingReply pr = null;

                                    try
                                    {
                                        pr = p.Send(_batchList[i].HostList[j]);
                                        _batchList[i].Results.Add(pr);

                                        if (pr.Status != IPStatus.Success)
                                        {
                                            _failedRequests.Add(new Tuple<string, string, PingReply>(_batchList[i].Name, _batchList[i].HostList[j], pr));
                                        }

                                        Debug.Print("Ping Task for target " + _batchList[i].HostList[j] + " started.");
                                    }
                                    catch (Exception ex)
                                    {
                                        if (ex is System.Net.Sockets.SocketException)
                                        {
                                            _batchList[i].Results.Add(pr);
                                        }
                                    }
                                    finally
                                    {
                                        if (this.InvokeRequired) this.Invoke(new MethodInvoker(UpdateResultsOutput));
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No hosts defined", "No hosts", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                } 
            }

            _lastExecutionTime = DateTime.Now;

            if (arg >= 0)
            {
                if (_btnCollect.InvokeRequired)
                {
                    _btnCollect.Invoke((MethodInvoker)delegate { _btnExecBatch.Enabled = false; });
                } 

                if (_batchList[arg].HostList != null)
                {
                    if (_batchList[arg].HostList.Count > 0)
                    {
                        _batchList[arg].Results = new List<PingReply>();
                        _batchList[arg].LastExecution = DateTime.Now;

                        for (int j = 0; j < _batchList[arg].HostList.Count; j++)
                        {
                            Ping p = new Ping();
                            PingReply pr = null;

                            try
                            {
                                pr = p.Send(_batchList[arg].HostList[j]);
                                _batchList[arg].Results.Add(pr);

                                if (pr.Status != IPStatus.Success)
                                {
                                    _failedRequests.Add(new Tuple<string, string, PingReply>(_batchList[arg].Name, _batchList[arg].HostList[j], pr));
                                }
                            }
                            catch (Exception ex)
                            {
                                if (ex is System.Net.Sockets.SocketException)
                                {
                                    _batchList[arg].Results.Add(pr);
                                }
                            }
                        }
                    }
                }
                else
                {
                    throw new NullReferenceException("Property HostList is null!");
                }
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

        private void _lnkLblResetAttemptCounter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _firstAlertPassed = false;
            _secondAlertPassed = false;
            _overallPingAttempts = 0;
            _lblOverallPingAttempts.Text = "Overall Attempts: " + _overallPingAttempts.ToString();
            _lblFirstAlertTime.Text = "First Alert Pass: ";
            _lblSecondAlertTime.Text = "Second Alert Pass: ";
        }

        private void _tbxJobName_Leave(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void _btnHome_Click(object sender, EventArgs e)
        {
            _lbxJobs.SelectedIndex = -1;
        }

        private void _clock_Tick(object sender, EventArgs e)
        {
            _lblClock.Text = DateTime.Now.ToString();

            if (_timeOfLastFirstAlert.Day == DateTime.Now.AddDays(-1).Day)
            {
                _firstAlertPassed = false;
                _secondAlertPassed = false;
                _overallPingAttempts = 0;
                _lblOverallPingAttempts.Text = "Overall Attempts: " + _overallPingAttempts.ToString();
                _lblFirstAlertTime.Text = "First Alert Pass: ";
                _lblSecondAlertTime.Text = "Second Alert Pass: ";
            }
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
