using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace NetVulture
{
    public partial class frmSettings : Form
    {
        string deliveryMethod;

        public frmSettings()
        {
            InitializeComponent();

            _tbxOutputDir.Text = Properties.Settings.Default.OutputDir;
            _tbxInterval.Text = Properties.Settings.Default.Interval.ToString();
            _chkBxEmailAlertingEnabled.Checked = Properties.Settings.Default.EmailAlertingEnabled;
            _tbxBatchlistCsvPath.Text = Properties.Settings.Default.AutoloadCsvPath;
            _chkBxEnableAutoImportBatchlist.Checked = Properties.Settings.Default.AutoloadCsvEnabled;
            _chkBxDailySummeryEnabled.Checked = Properties.Settings.Default.SendSummeryEnabled;
            _dtpSendSummeryTime.Value = Properties.Settings.Default.SendSummeryTime;

            if (_chkBxEmailAlertingEnabled.Checked)
            {
                deliveryMethod = Properties.Settings.Default.MailDeliveryMethod;

                if (!string.IsNullOrEmpty(deliveryMethod))
                {
                    RadioButton rbtn = (RadioButton)_gbxEmailSettings.Controls["rBtn" + deliveryMethod];
                    rbtn.Checked = true;

                    if (rbtn.Text == "SMTP")
                    {
                        _tbxMailServer.Enabled = true;
                        _tbxMailServerPort.Enabled = true;
                        _tbxMailUser.Enabled = true;
                        _tbxMailPassword.Enabled = true;
                    }
                }

                StringCollection _scTargetCollection = Properties.Settings.Default.TargetAddresses;

                if (_scTargetCollection != null && _scTargetCollection.Count > 0)
                {
                    _tbxTargetAddresses.Lines = Properties.Settings.Default.TargetAddresses.Cast<string>().ToArray();
                }

                _tbxMailUser.Text = Properties.Settings.Default.MailUser;
                _tbxMailPassword.Text = Properties.Settings.Default.MailPassword;
                _tbxMailServer.Text = Properties.Settings.Default.MailServer;
                _tbxMailServerPort.Text = Properties.Settings.Default.MailServerPort.ToString();
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
            Properties.Settings.Default.EmailAlertingEnabled = _chkBxEmailAlertingEnabled.Checked;
            Properties.Settings.Default.AutoloadCsvPath = _tbxBatchlistCsvPath.Text;
            Properties.Settings.Default.AutoloadCsvEnabled = _chkBxEnableAutoImportBatchlist.Checked;
            Properties.Settings.Default.MailDeliveryMethod = deliveryMethod;

            if (_chkBxEmailAlertingEnabled.Checked)
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

            Properties.Settings.Default.Save();
        }

        private void _chkBxAlertingEnabled_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void _btnSendTestMail_Click(object sender, EventArgs e)
        {
            if (_tbxTargetAddresses.Lines.Count() > 0)
            {
                _btnSendTestMail.Enabled = false;
                _btnSendTestMail.Text = "Send messages...";

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

                if (rBtnSmtp.Checked)
                {
                    Task task = Task.Run(() => NVManagementClass.SendMailAsync("Test Message from IOB Monitoring successfull sended at " + DateTime.Now.ToString(), _tbxTargetAddresses.Lines));

                    task.ContinueWith((t) =>
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            _btnSendTestMail.Enabled = true;
                            _btnSendTestMail.Text = "Send Test Mail";
                        });
                    });
                }

                if (rBtnOutlook.Checked)
                {
                    Task task = Task.Run(() => NVManagementClass.SendOutlookMail("Test Message from IOB Monitoring successfull sended at " + DateTime.Now.ToString(), _tbxTargetAddresses.Lines));

                    task.ContinueWith((t) =>
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            _btnSendTestMail.Enabled = true;
                            _btnSendTestMail.Text = "Send Test Mail";
                        });
                    });
                }
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

        private void rBtnSmtp_CheckedChanged(object sender, EventArgs e)
        {
            deliveryMethod = rBtnSmtp.Text;

            _tbxMailServer.Enabled = true;
            _tbxMailServerPort.Enabled = true;
            _tbxMailUser.Enabled = true;
            _tbxMailPassword.Enabled = true;
        }

        private void rBtnOutlook_CheckedChanged(object sender, EventArgs e)
        {
            deliveryMethod = rBtnOutlook.Text;

            _tbxMailServer.Enabled = false;
            _tbxMailServerPort.Enabled = false;
            _tbxMailUser.Enabled = false;
            _tbxMailPassword.Enabled = false;
        }

        private void _chkBxEmailAlertingEnabled_CheckedChanged(object sender, EventArgs e)
        {
            rBtnSmtp.Enabled = _chkBxEmailAlertingEnabled.Checked;
            rBtnOutlook.Enabled = _chkBxEmailAlertingEnabled.Checked;

            if (!string.IsNullOrEmpty(deliveryMethod))
            {
                RadioButton rbtn = (RadioButton)_gbxEmailSettings.Controls["rBtn" + deliveryMethod];
                rbtn.Checked = true; 
            }

            if (deliveryMethod == "SMTP")
            {
                _tbxMailServer.Enabled = _chkBxEmailAlertingEnabled.Checked;
                _tbxMailServerPort.Enabled = _chkBxEmailAlertingEnabled.Checked;
                _tbxMailUser.Enabled = _chkBxEmailAlertingEnabled.Checked;
                _tbxMailPassword.Enabled = _chkBxEmailAlertingEnabled.Checked;
            }

            _tbxTargetAddresses.Enabled = _chkBxEmailAlertingEnabled.Checked;
            _btnSendTestMail.Enabled = _chkBxEmailAlertingEnabled.Checked;
        }
    }
}
