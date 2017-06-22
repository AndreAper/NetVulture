using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using nvcore;
using System.Net;

namespace NetVulture
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();

            _tbxOutputDir.Text = Properties.Settings.Default.OutputDir;
            _tbxInterval.Text = Properties.Settings.Default.Interval.ToString();
            _chkBxEmailAlertingEnabled.Checked = Properties.Settings.Default.EmailAlertingEnabled;
            _tbxBatchlistCsvPath.Text = Properties.Settings.Default.AutoloadCsvPath;
            _chkBxEnableAutoImportBatchlist.Checked = Properties.Settings.Default.AutoloadCsvEnabled;
            _chkBxDailySummeryEnabled.Checked = Properties.Settings.Default.SendSummaryEnabled;
            _dtpSendSummeryTime.Value = Properties.Settings.Default.SendSummaryTime;

            if (_chkBxEmailAlertingEnabled.Checked)
            {
                _tbxMailServer.Enabled = true;
                _tbxMailServerPort.Enabled = true;
                _tbxMailUser.Enabled = true;
                _tbxMailPassword.Enabled = true;

                StringCollection scTargetCollection = Properties.Settings.Default.TargetAddresses;

                if (scTargetCollection != null && scTargetCollection.Count > 0)
                {
                    _tbxTargetAddresses.Lines = Properties.Settings.Default.TargetAddresses.Cast<string>().ToArray();
                }

                _tbxMailUser.Text = Properties.Settings.Default.SmtpUser;
                _tbxMailPassword.Text = Properties.Settings.Default.SmtpPassword;
                _tbxMailServer.Text = Properties.Settings.Default.SmtpServer;
                _tbxMailServerPort.Text = Properties.Settings.Default.SmtpPort.ToString();
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
            Properties.Settings.Default.SendSummaryEnabled = _chkBxDailySummeryEnabled.Checked;
            Properties.Settings.Default.SendSummaryTime = _dtpSendSummeryTime.Value;
            Properties.Settings.Default.Interval = Convert.ToInt32(_tbxInterval.Text);
            Properties.Settings.Default.EmailAlertingEnabled = _chkBxEmailAlertingEnabled.Checked;
            Properties.Settings.Default.AutoloadCsvPath = _tbxBatchlistCsvPath.Text;
            Properties.Settings.Default.AutoloadCsvEnabled = _chkBxEnableAutoImportBatchlist.Checked;

            if (_chkBxEmailAlertingEnabled.Checked)
            {
                StringCollection scEmail = new StringCollection();

                foreach (string line in _tbxTargetAddresses.Lines)
                {
                    scEmail.Add(line);
                }

                Properties.Settings.Default.TargetAddresses = scEmail;
                Properties.Settings.Default.SmtpUser = _tbxMailUser.Text;
                Properties.Settings.Default.SmtpPassword = _tbxMailPassword.Text;
                Properties.Settings.Default.SmtpServer = _tbxMailServer.Text;

                if (_tbxMailServerPort.Text.Length > 0)
                {
                    Properties.Settings.Default.SmtpPort = Convert.ToInt32(_tbxMailServerPort.Text); 
                }
                else
                {
                    Properties.Settings.Default.SmtpPort = 0;
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
                Properties.Settings.Default.SmtpUser = _tbxMailUser.Text;
                Properties.Settings.Default.SmtpPassword = _tbxMailPassword.Text;
                Properties.Settings.Default.SmtpServer = _tbxMailServer.Text;


                if (_tbxMailServerPort.Text.Length > 0)
                {
                    Properties.Settings.Default.SmtpPort = Convert.ToInt32(_tbxMailServerPort.Text);
                }
                else
                {
                    Properties.Settings.Default.SmtpPort = 0;
                }

                Properties.Settings.Default.Save();

                if (String.IsNullOrEmpty(_tbxMailPassword.Text))
                {
                    Task task = Task.Run(() => EMail.SendMail(
                    Properties.Settings.Default.SmtpServer,
                    Properties.Settings.Default.SmtpPort,
                    "Hello World",
                    Properties.Settings.Default.SmtpUser,
                    _tbxTargetAddresses.Lines));

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
                    Task task = Task.Run(() => EMail.SendMail(
                        Properties.Settings.Default.SmtpServer,
                        Properties.Settings.Default.SmtpPort,
                        Properties.Settings.Default.SmtpUser,
                        Properties.Settings.Default.SmtpPassword,
                        "Hello World",
                        Properties.Settings.Default.SmtpUser,
                        _tbxTargetAddresses.Lines));

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

        private void _chkBxEmailAlertingEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _tbxMailServer.Enabled = _chkBxEmailAlertingEnabled.Checked;
            _tbxMailServerPort.Enabled = _chkBxEmailAlertingEnabled.Checked;
            _tbxMailUser.Enabled = _chkBxEmailAlertingEnabled.Checked;
            _tbxMailPassword.Enabled = _chkBxEmailAlertingEnabled.Checked;
            _tbxTargetAddresses.Enabled = _chkBxEmailAlertingEnabled.Checked;
            _btnSendTestMail.Enabled = _chkBxEmailAlertingEnabled.Checked;
        }

        private void linkLblSendSummaryNow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_tbxTargetAddresses.Lines.Count() > 0)
            {
                if (String.IsNullOrEmpty(_tbxMailPassword.Text))
                {
                    Task task = Task.Run(() => EMail.SendHtmlMail(
                    Properties.Settings.Default.SmtpServer,
                    Properties.Settings.Default.SmtpPort,
                    Summary.Create(FileIO.XmlReader()),
                    Properties.Settings.Default.SmtpUser,
                    _tbxTargetAddresses.Lines));
                    task.Wait();
                }
                else
                {
                    Task task = Task.Run(() => EMail.SendHtmlMail(
                        Properties.Settings.Default.SmtpServer,
                        Properties.Settings.Default.SmtpPort,
                        Properties.Settings.Default.SmtpUser,
                        Properties.Settings.Default.SmtpPassword,
                        Summary.Create(FileIO.XmlReader()),
                        Properties.Settings.Default.SmtpUser,
                        _tbxTargetAddresses.Lines));
                    task.Wait();
                }
            }
            else
            {
                MessageBox.Show("No targets defined", "Send mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
