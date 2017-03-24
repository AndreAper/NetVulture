using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Collections.Specialized;

namespace NetVulture
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();

            _tbxOutputDir.Text = Properties.Settings.Default.OutputDir;
            _tbxInterval.Text = Properties.Settings.Default.Interval.ToString();
            _chkBxAlertingEnabled.Checked = Properties.Settings.Default.AlertingEnabled;
            _cbxBxSmsAlertingEnabled.Checked = Properties.Settings.Default.SmsAlertingEnabled;
            _chkBxEmailAlertingEnabled.Checked = Properties.Settings.Default.EmailAlertingEnabled;
            _tbxBatchlistCsvPath.Text = Properties.Settings.Default.AutoloadCsvPath;
            _chkBxEnableAutoImportBatchlist.Checked = Properties.Settings.Default.AutoloadCsvEnabled;
            _chkBxDailySummeryEnabled.Checked = Properties.Settings.Default.SendSummeryEnabled;
            _dtpSendSummeryTime.Value = Properties.Settings.Default.SendSummeryTime;

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

                _tbxAccountRef.Text = Properties.Settings.Default.GatewayAccountRef;
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
            Properties.Settings.Default.SendSummeryEnabled = _chkBxDailySummeryEnabled.Checked;
            Properties.Settings.Default.SendSummeryTime = _dtpSendSummeryTime.Value;
            Properties.Settings.Default.Interval = Convert.ToInt32(_tbxInterval.Text);
            Properties.Settings.Default.AlertingEnabled = _chkBxAlertingEnabled.Checked;
            Properties.Settings.Default.SmsAlertingEnabled = _cbxBxSmsAlertingEnabled.Checked;
            Properties.Settings.Default.EmailAlertingEnabled = _chkBxEmailAlertingEnabled.Checked;
            Properties.Settings.Default.AutoloadCsvPath = _tbxBatchlistCsvPath.Text;
            Properties.Settings.Default.AutoloadCsvEnabled = _chkBxEnableAutoImportBatchlist.Checked;

            if (_chkBxAlertingEnabled.Checked && _chkBxEmailAlertingEnabled.Checked)
            {
                StringCollection scEmail = new StringCollection();

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
                Properties.Settings.Default.GatewayAccountRef = _tbxAccountRef.Text;
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
                Properties.Settings.Default.GatewayAccountRef = _tbxAccountRef.Text;
                Properties.Settings.Default.GatewayUser = _tbxSmsGatewayUser.Text;
                Properties.Settings.Default.GatewayPassword = _tbxSmsGatewayPassword.Text;
                Properties.Settings.Default.Save();

                //Throw a exception if no internet access
                //Throw a exception if no internet access
                if (new Ping().Send("www.google.de").Status != IPStatus.Success)
                {
                    MessageBox.Show("No internet access", "Send sms", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _btnSendTestSms.Enabled = false;
                _btnSendTestSms.Text = "Send messages...";

                Task task = Task.Run(() => NVManagementClass.SendMultipleShortMessage("NetVulture Test Message", _tbxMobileNumbers.Lines));

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
                StringCollection scEmail = new StringCollection();

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

                Properties.Settings.Default.Save();

                _btnSendTestMail.Enabled = false;
                _btnSendTestMail.Text = "Send messages...";

                Task task = Task.Run(() => NVManagementClass.SendMailAsync("This is a test message!", _tbxTargetAddresses.Lines));

                task.ContinueWith((t) =>
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        _btnSendTestMail.Enabled = true;
                        _btnSendTestMail.Text = "Send Test Mail";
                    });
                });
            }
            else
            {
                MessageBox.Show("No targets defined", "Send mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _btnSelectBatchlistCsv_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv files (*.csv)|*.csv";
            ofd.FilterIndex = 1;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _tbxBatchlistCsvPath.Text = ofd.FileName;
            }
        }

        private void _lnkLblCopyHeader_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(_rtbxCsvHeader.Text);
        }
    }
}
