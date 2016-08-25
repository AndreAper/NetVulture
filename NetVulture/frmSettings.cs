using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.NetworkInformation;
using System.IO;

namespace NetVulture
{
    public partial class frmSettings : Form
    {
        SshClient _client = null;
        StringBuilder _sbMailAlertingProtocoll;

        private async Task<Boolean> EnableRemoteUmtsInternetConnection(SshClient client)
        {
            bool b = false;

            try
            {
                if (!client.IsConnected)
                {
                    _sbMailAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: EnableRemoteUmtsInternetConnection(): Canceled because ssh client is not connected to the host.");
                    return b;
                }

                _sbMailAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: EnableRemoteUmtsInternetConnection(): Run command nmcli con up id 'Vodafone'");
                SshCommand connectCommand = client.RunCommand("nmcli con up id 'Vodafone'");

                _sbMailAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: EnableRemoteUmtsInternetConnection(): Wait 10 seconds...");
                await Task.Delay(10000);

                string connCmdResults;
                using (StreamReader sr = new StreamReader(connectCommand.ExtendedOutputStream))
                {
                    connCmdResults = await sr.ReadToEndAsync();
                    _sbMailAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: EnableRemoteUmtsInternetConnection(): Results: " + connCmdResults);


                    if (connCmdResults.Contains("Connection successfully activated"))
                    {
                        b = true;
                    }

                    if (connCmdResults.Contains("Error: Connection activation failed."))
                    {
                        b = false;
                    }
                }

                _sbMailAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: EnableRemoteUmtsInternetConnection(): Results: " + connCmdResults);

                _sbMailAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: EnableRemoteUmtsInternetConnection(): Run command ping smt.gmail.com -c 1");
                SshCommand pingCommand = client.RunCommand("ping smt.gmail.com -c 1");

                string pingResults;
                using (StreamReader sr = new StreamReader(pingCommand.ExtendedOutputStream))
                {
                    pingResults = await sr.ReadToEndAsync();
                    _sbMailAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: EnableRemoteUmtsInternetConnection(): Results: " + pingResults);
                }

                if (pingResults.Contains("ping: unknown host smtp.gmail.com"))
                {
                    b = false;
                }
                else
                {
                    b = true;
                }

                return b;
            }
            catch (Exception ex)
            {
                _sbMailAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendMail(): Error " + ex.TargetSite.Name + " has thrown with message: " + ex.Message);
                throw;
            }

        }

        private async Task<Boolean> DisableRemoteUmtsInternetConnection(SshClient client)
        {
            bool b = false;
            Ping p = new Ping();
            PingReply pr = await p.SendPingAsync(_tbxMailServer.Text);

            if (pr.Status != IPStatus.Success)
            {
                b = false;
            }

            try
            {
                if (!client.IsConnected)
                {
                    return b;
                }

                SshCommand connectCommand = client.RunCommand("nmcli con down id 'Vodafone'");
                await Task.Delay(10000);

                string connCmdResults;
                using (StreamReader sr = new StreamReader(connectCommand.ExtendedOutputStream))
                {
                    connCmdResults = await sr.ReadToEndAsync();

                    if (connCmdResults.Contains("Connection 'Vodafone' successfully deactivated"))
                    {
                        b = true;
                    }
                }

                return b;
            }
            catch (Exception)
            {
                return b;
            }

        }

        /// <summary>
        /// Sending short messages to each registered mobile number.
        /// </summary>
        private async Task SendSms(string msg)
        {
            if (_cbxBxSmsAlertingEnabled.Checked)
            {                
                List<Task> taskList = new List<Task>();

                Ping p = new Ping();
                PingReply pr = await p.SendPingAsync(_tbxSmsGatewayAddress.Text);

                if (pr.Status != IPStatus.Success)
                {
                    MessageBox.Show("Host is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    //Set up the SSH connection
                    using (_client = new SshClient(_tbxSmsGatewayAddress.Text, _tbxSmsGatewayUser.Text, _tbxSmsGatewayPassword.Text))
                    {
                        //Start the connection
                        _client.Connect();

                        foreach (string nr in _tbxMobileNumbers.Lines)
                        {
                            SshCommand cmd = _client.RunCommand(string.Format("echo {0} | sudo -S echo '{1}' | sudo gammu sendsms TEXT '{2}'", _tbxSmsGatewayPassword.Text, msg, nr));
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
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Sending mail message to registered address.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private async Task SendMail(string msg)
        {
            if (_chkBxEmailAlertingEnabled.Checked)
            {
                _sbMailAlertingProtocoll = new StringBuilder();
                _sbMailAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendMail(): Begin send mail messages.");

                Ping p = new Ping();
                PingReply pr = await p.SendPingAsync(_tbxMailServer.Text);

                if (pr.Status != IPStatus.Success)
                {
                    MessageBox.Show("Host is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _sbMailAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendMail(): SendMail function canceled because host is not available!");
                    return;
                }

                try
                {
                    _sbMailAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendMail(): Begin send messages to " + _tbxTargetAddresses.Lines.Count() + " participants");

                    if (_client != null || _client.IsConnected)
                    {
                        foreach (string address in _tbxTargetAddresses.Lines)
                        {
                            _sbMailAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendMail(): Run command " + string.Format("echo {0} | sudo -S echo '{1}' | sudo ssmtp -vvv {2}", _tbxMailPassword.Text, msg, address));
                            SshCommand cmd = _client.RunCommand(string.Format("echo {0} | sudo -S echo '{1}' | sudo ssmtp -vvv {2}", _tbxMailPassword.Text, msg, address));

                            using (StreamReader sr = new StreamReader(cmd.ExtendedOutputStream))
                            {
                                _sbMailAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendMail(): Results: " + sr.ReadToEnd());
                            }
                        }
                    }
                    else
                    {
                        //Set up the SSH connection
                        using (_client = new SshClient(_tbxMailServer.Text, _tbxMailUser.Text, _tbxMailPassword.Text))
                        {
                            //Start the connection
                            _client.Connect();

                            foreach (string address in _tbxTargetAddresses.Lines)
                            {
                                //echo Moni2015@ | sudo -S echo 'Test1234' | sudo ssmtp -vvv andre.aper@outlook.com

                                _sbMailAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendMail(): Run command " + string.Format("echo {0} | sudo -S echo '{1}' | sudo ssmtp -vvv {2}", _tbxMailPassword.Text, msg, address));
                                SshCommand cmd = _client.RunCommand(string.Format("echo {0} | sudo -S echo '{1}' | sudo ssmtp -vvv {2}",_tbxMailPassword.Text, msg, address));

                                using (StreamReader sr = new StreamReader(cmd.ExtendedOutputStream))
                                {
                                    _sbMailAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendMail(): Results: " + sr.ReadToEnd());
                                }
                            }
                        }
                    }
                }
                catch (ArgumentException ae)
                {
                    _sbMailAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendMail(): Error ArgumentException has thrown with message: " + ae.Message);
                    MessageBox.Show("Missing one or more connection parameters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Net.Sockets.SocketException se)
                {
                    _sbMailAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendMail(): Error System.Net.Sockets.SocketException has thrown with message: " + se.Message);
                    MessageBox.Show("Host is not available or connection is interrupted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    _sbMailAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendMail(): Error " + ex.StackTrace + " has thrown with message: " + ex.Message);
                    throw;
                }
                finally
                {
                    _sbMailAlertingProtocoll.AppendLine(DateTime.Now.ToString() + " Method: SendMail(): Send messages successfully. Closing connection and disposing client instance.");
                }
            }
        }

        private async void WriteReport()
        {
            string file = Path.Combine(Application.StartupPath, "logs", "MailAlertingProtocoll_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss"));

            if (!Directory.Exists(Path.Combine(Application.StartupPath, "logs")))
            {
                Directory.CreateDirectory(Path.Combine(Application.StartupPath, "logs"));
            }

            using (StreamWriter sw = new StreamWriter(file))
            {
                await sw.WriteAsync(_sbMailAlertingProtocoll.ToString());
            }
        }

        public frmSettings()
        {
            InitializeComponent();

            _tbxOutputDir.Text = Properties.Settings.Default.OutputDir;
            _tbxInterval.Text = Properties.Settings.Default.Interval.ToString();
            _chkBxAutoStartTimer.Checked = Properties.Settings.Default.AutoStartTimer;
            _chkBxAlertingEnabled.Checked = Properties.Settings.Default.AlertingEnabled;
            _cbxBxSmsAlertingEnabled.Checked = Properties.Settings.Default.SmsAlertingEnabled;
            _chkBxEmailAlertingEnabled.Checked = Properties.Settings.Default.EmailAlertingEnabled;

            _gbxEmailSettings.Enabled = _chkBxAlertingEnabled.Checked;
            _gbxSmsSettings.Enabled = _chkBxAlertingEnabled.Checked;

            if (_chkBxAlertingEnabled.Checked && _chkBxEmailAlertingEnabled.Checked)
            {
                System.Collections.Specialized.StringCollection _scTargetCollection = Properties.Settings.Default.TargetAddresses;

                if (_scTargetCollection != null && _scTargetCollection.Count > 0)
                {
                    _tbxTargetAddresses.Lines = Properties.Settings.Default.TargetAddresses.Cast<string>().ToArray();
                }

                _tbxMailUser.Text = Properties.Settings.Default.MailUser;
                _tbxMailPassword.Text = Properties.Settings.Default.MailPassword;
                _tbxMailServer.Text = Properties.Settings.Default.MailServer;
                _tbxMailServerPort.Text = Properties.Settings.Default.MailServerPort.ToString();
            }

            if (_chkBxAlertingEnabled.Checked && _cbxBxSmsAlertingEnabled.Checked)
            {
                System.Collections.Specialized.StringCollection _scMobileNumberCollection = Properties.Settings.Default.MobileNumbers;

                if (_scMobileNumberCollection != null && _scMobileNumberCollection.Count > 0)
                {
                    _tbxMobileNumbers.Lines = Properties.Settings.Default.MobileNumbers.Cast<string>().ToArray();
                }

                _tbxSmsGatewayAddress.Text = Properties.Settings.Default.GatewayAddress;
                _tbxSmsGatewayUser.Text = Properties.Settings.Default.GatewayUser;
                _tbxSmsGatewayPassword.Text = Properties.Settings.Default.GatewayPassword;
            }
        }

        private void _btnSelectDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.Description = "Select main output directory.";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                _tbxOutputDir.Text = fbd.SelectedPath;
            }
        }

        private void _btnClose_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.OutputDir = _tbxOutputDir.Text;
            Properties.Settings.Default.Interval = Convert.ToInt32(_tbxInterval.Text);
            Properties.Settings.Default.AutoStartTimer = _chkBxAutoStartTimer.Checked;
            Properties.Settings.Default.AlertingEnabled = _chkBxAlertingEnabled.Checked;
            Properties.Settings.Default.SmsAlertingEnabled = _cbxBxSmsAlertingEnabled.Checked;
            Properties.Settings.Default.EmailAlertingEnabled = _chkBxEmailAlertingEnabled.Checked;

            if (_chkBxAlertingEnabled.Checked && _chkBxEmailAlertingEnabled.Checked)
            {
                System.Collections.Specialized.StringCollection scEmail = new System.Collections.Specialized.StringCollection();
                foreach (string line in _tbxTargetAddresses.Lines)
                {
                    scEmail.Add(line);
                }

                Properties.Settings.Default.TargetAddresses = scEmail;

                Properties.Settings.Default.MailUser = _tbxMailUser.Text;
                Properties.Settings.Default.MailPassword = _tbxMailPassword.Text;
                Properties.Settings.Default.MailServer = _tbxMailServer.Text;

                if (_tbxMailServerPort.Text.Length > 0)
                {
                    Properties.Settings.Default.MailServerPort = Convert.ToInt32(_tbxMailServerPort.Text); 
                }
                else
                {
                    Properties.Settings.Default.MailServerPort = 0;
                }
            }

            if (_chkBxAlertingEnabled.Checked && _cbxBxSmsAlertingEnabled.Checked)
            {
                System.Collections.Specialized.StringCollection scSms = new System.Collections.Specialized.StringCollection();
                foreach (string line in _tbxMobileNumbers.Lines)
                {
                    scSms.Add(line);
                }

                Properties.Settings.Default.MobileNumbers = scSms;

                Properties.Settings.Default.GatewayAddress = _tbxSmsGatewayAddress.Text;
                Properties.Settings.Default.GatewayUser = _tbxSmsGatewayUser.Text;
                Properties.Settings.Default.GatewayPassword = _tbxSmsGatewayPassword.Text;
            }

            Properties.Settings.Default.Save();
        }

        private void _chkBxAlertingEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _gbxEmailSettings.Enabled = _chkBxAlertingEnabled.Checked;
            _gbxSmsSettings.Enabled = _chkBxAlertingEnabled.Checked;
        }

        private void _btnSendTestSms_Click(object sender, EventArgs e)
        {
            if (_tbxMobileNumbers.Lines.Count() > 0)
            {
                _btnSendTestSms.Enabled = false;
                _btnSendTestSms.Text = "Send messages...";
                Task task = Task.Run(() => SendSms("NetVulture Test Message"));

                task.ContinueWith((t) => {
                    this.Invoke((MethodInvoker)delegate
                    {
                        _btnSendTestSms.Enabled = true;
                        _btnSendTestSms.Text = "Send Test SMS";
                    });
                });
            }
            else
            {
                MessageBox.Show("No targets defined", "Send sms", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _btnSendTestMail_Click(object sender, EventArgs e)
        {
            if (_tbxTargetAddresses.Lines.Count() > 0)
            {
                _btnSendTestMail.Enabled = false;
                _btnSendTestMail.Text = "Send messages...";
                Task task = Task.Run(() => SendMail("This is a test message!"));

                task.ContinueWith((t) => {
                    this.Invoke((MethodInvoker)delegate
                    {
                        _btnSendTestMail.Enabled = true;
                        _btnSendTestMail.Text = "Send Test Mail";
                        WriteReport();
                    });
                });
            }
            else
            {
                MessageBox.Show("No targets defined", "Send mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.OutputDir = _tbxOutputDir.Text;
            Properties.Settings.Default.Interval = Convert.ToInt32(_tbxInterval.Text);
            Properties.Settings.Default.AutoStartTimer = _chkBxAutoStartTimer.Checked;
            Properties.Settings.Default.AlertingEnabled = _chkBxAlertingEnabled.Checked;
            Properties.Settings.Default.SmsAlertingEnabled = _cbxBxSmsAlertingEnabled.Checked;
            Properties.Settings.Default.EmailAlertingEnabled = _chkBxEmailAlertingEnabled.Checked;

            if (_chkBxAlertingEnabled.Checked && _chkBxEmailAlertingEnabled.Checked)
            {
                System.Collections.Specialized.StringCollection scEmail = new System.Collections.Specialized.StringCollection();
                foreach (string line in _tbxTargetAddresses.Lines)
                {
                    scEmail.Add(line);
                }

                Properties.Settings.Default.TargetAddresses = scEmail;

                Properties.Settings.Default.MailUser = _tbxMailUser.Text;
                Properties.Settings.Default.MailPassword = _tbxMailPassword.Text;
                Properties.Settings.Default.MailServer = _tbxMailServer.Text;

                if (_tbxMailServerPort.Text.Length > 0)
                {
                    Properties.Settings.Default.MailServerPort = Convert.ToInt32(_tbxMailServerPort.Text);
                }
                else
                {
                    Properties.Settings.Default.MailServerPort = 0;
                }
            }

            if (_chkBxAlertingEnabled.Checked && _cbxBxSmsAlertingEnabled.Checked)
            {
                System.Collections.Specialized.StringCollection scSms = new System.Collections.Specialized.StringCollection();
                foreach (string line in _tbxMobileNumbers.Lines)
                {
                    scSms.Add(line);
                }

                Properties.Settings.Default.MobileNumbers = scSms;

                Properties.Settings.Default.GatewayAddress = _tbxSmsGatewayAddress.Text;
                Properties.Settings.Default.GatewayUser = _tbxSmsGatewayUser.Text;
                Properties.Settings.Default.GatewayPassword = _tbxSmsGatewayPassword.Text;
            }

            Properties.Settings.Default.Save();
        }
    }
}
