using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetVulture
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();

            _tbxOutputDir.Text = Properties.Settings.Default.OutputDir;
            _tbxInterval.Text = Properties.Settings.Default.Interval.ToString();
            _chkBxAutoStartTimer.Checked = Properties.Settings.Default.AutoStartTimer;
            _chkBxAlertingEnabled.Checked = Properties.Settings.Default.AlertingEnabled;

            System.Collections.Specialized.StringCollection _scTargetCollection = Properties.Settings.Default.TargetAddresses;

            if (_scTargetCollection != null && _scTargetCollection.Count > 0)
            {
                foreach (string str in Properties.Settings.Default.TargetAddresses)
                {
                    _tbxTargetAddresses.Text += str;
                }
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

            System.Collections.Specialized.StringCollection sc = new System.Collections.Specialized.StringCollection();
            foreach (string line in _tbxTargetAddresses.Lines)
            {
                sc.Add(line);
            }

            Properties.Settings.Default.TargetAddresses = sc;
            Properties.Settings.Default.Save();
        }
    }
}
