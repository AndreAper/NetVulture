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
        /// <summary>
        /// Sending short messages to each registered mobile number.
        /// </summary>
        private async void SendSms(string msg)
        {
            if (_cbxBxSmsAlertingEnabled.Checked)
            {
                SshClient client = null;
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
                    using (client = new SshClient(_tbxSmsGatewayAddress.Text, _tbxSmsGatewayUser.Text, _tbxSmsGatewayPassword.Text))
                    {
                        //Start the connection
                        client.Connect();

                        //TEST: Unterstützt das RPI asynchrones ausführen der shell kommandos???????
                        foreach (string nr in _tbxMobileNumbers.Lines)
                        {
                            SshCommand cmd = client.RunCommand("echo " + _tbxSmsGatewayPassword.Text + " | sudo -S echo \"" + msg + "\" | sudo gammu sendsms TEXT \"" + nr + "\"");
#if DEBUG
                            Debug.Print("Execute Command : " + cmd.CommandText);
#endif
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

        private void SendSmsCompleted()
        {
            //TODO: Feedback für erfolgreiches absend
            MessageBox.Show("SMS successfull send.", "Send sms", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SendSms("WARNING: This is a test message!"); 
            }
            else
            {
                MessageBox.Show("No targets defined", "Send sms", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
