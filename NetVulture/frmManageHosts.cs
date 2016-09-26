using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace NetVulture
{
    public partial class frmManageHosts : Form
    {

        public List<HostInformation> HostList { get { return _lst; } }
        private List<HostInformation> _lst = null;

        private void UpdateLbx()
        {
            _lbxHIs.Items.Clear();

            foreach (HostInformation hi in _lst)
            {
                _lbxHIs.Items.Add(hi.HostnameOrAddress);
            }
        }

        public frmManageHosts()
        {
            InitializeComponent();
            _lst = new List<HostInformation>();
        }

        public frmManageHosts(List<HostInformation> lst)
        {
            InitializeComponent();
            _lst = lst;

            UpdateLbx();
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
        }

        private void _btnAddHI_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_tbxDnsEntry.Text))
            {
                MessageBox.Show("Hostname or address is required");
                return;
            }
            else
            {
                if (_lst.Any(x => x.HostnameOrAddress == _tbxDnsEntry.Text))
                {
                    MessageBox.Show("Hostname or address is already exist.");
                    return;
                }

                HostInformation hi = new HostInformation();
                hi.HostnameOrAddress = _tbxDnsEntry.Text;
                hi.Description = _tbxHostDescription.Text;
                hi.Building = _tbxBuilding.Text;
                hi.Cabinet = _tbxCabinet.Text;
                hi.Rack = _tbxRack.Text;
                hi.PhysicalAddress = _tbxPhysicalAddress.Text;
                hi.MaintenanceActivated = _chkBxIsMaintenanceActive.Checked;
                hi.AutoFetchPhysicalAddress = _chkBxAutoFetchMac.Checked;

                _lst.Add(hi);
                UpdateLbx();

                _tbxDnsEntry.Text = "";
                _tbxHostDescription.Text = "";
                _tbxPhysicalAddress.Text = "";
                _tbxBuilding.Text = "";
                _tbxCabinet.Text = "";
                _tbxRack.Text = "";
                _chkBxIsMaintenanceActive.Checked = false;
                _chkBxAutoFetchMac.Checked = false;

            }
        }

        private void _lbxHIs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lbxHIs.SelectedIndex != -1)
            {
                HostInformation hi = _lst.ElementAt(_lbxHIs.SelectedIndex);
                _tbxDnsEntry.Text = hi.HostnameOrAddress;
                _tbxHostDescription.Text = hi.Description;
                _tbxBuilding.Text = hi.Building;
                _tbxCabinet.Text = hi.Cabinet;
                _tbxRack.Text = hi.Rack;
                _tbxPhysicalAddress.Text = hi.PhysicalAddress;
                _chkBxIsMaintenanceActive.Checked = hi.MaintenanceActivated;
                _chkBxAutoFetchMac.Checked = hi.AutoFetchPhysicalAddress;
                _btnSave.Enabled = true;
            }
        }

        private void _btnRemoveHI_Click(object sender, EventArgs e)
        {
            //if (_lbxHIs.SelectedIndex != -1)
            //{
            //    _lst.RemoveAt(_lbxHIs.SelectedIndex);

            //    _tbxDnsEntry.Text = "";
            //    _tbxHostDescription.Text = "";
            //    _tbxPhysicalAddress.Text = "";
            //    _tbxBuilding.Text = "";
            //    _tbxCabinet.Text = "";
            //    _tbxRack.Text = "";
            //    _chkBxIsMaintenanceActive.Checked = false;
            //    _chkBxAutoFetchMac.Checked = false;

            //    UpdateLbx();
            //}

            for (int x = _lbxHIs.SelectedIndices.Count - 1; x >= 0; x--)
            {
                int idx = _lbxHIs.SelectedIndices[x];
                _lst.RemoveAt(idx);
            }

            UpdateLbx();
        }

        private void _btnSave_Click(object sender, EventArgs e)
        {
            if (_lbxHIs.SelectedIndex != -1)
            {
                _lst[_lbxHIs.SelectedIndex].HostnameOrAddress = _tbxDnsEntry.Text;
                _lst[_lbxHIs.SelectedIndex].Description = _tbxHostDescription.Text;
                _lst[_lbxHIs.SelectedIndex].Building = _tbxBuilding.Text;
                _lst[_lbxHIs.SelectedIndex].Cabinet = _tbxCabinet.Text;
                _lst[_lbxHIs.SelectedIndex].Rack = _tbxRack.Text;
                _lst[_lbxHIs.SelectedIndex].PhysicalAddress = _tbxPhysicalAddress.Text;
                _lst[_lbxHIs.SelectedIndex].MaintenanceActivated = _chkBxIsMaintenanceActive.Checked;
                _lst[_lbxHIs.SelectedIndex].AutoFetchPhysicalAddress = _chkBxAutoFetchMac.Checked;

                _lbxHIs.SelectedIndex = -1;
                _btnSave.Enabled = false;

                UpdateLbx();
            }
        }

        private void _btnImport_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv files (*.csv)|*.csv";
            ofd.FilterIndex = 1;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<string> lines = new List<string>(System.IO.File.ReadAllLines(ofd.FileName));

                if (lines.First().Contains("HostnameOrAddress"))
                {
                    lines.RemoveAt(0); 
                }

                _lst = new List<HostInformation>();

                foreach (string line in lines)
                {
                    //HostnameOrAddress [0]
                    //HostDescription [1]
                    //Building [2]
                    //Cabinet [3]
                    //Rack [4]
                    //PhysicalAddress [5]
                    //Maintenance [6]
                    //AutoFetchPhysicalAddress [7]

                    string[] elements = line.Split(';');

                    HostInformation hi = new HostInformation();
                    hi.HostnameOrAddress = elements[0];
                    hi.Description = elements[1];
                    hi.Building = elements[2];
                    hi.Cabinet = elements[3];
                    hi.Rack = elements[4];
                    hi.PhysicalAddress = elements[5];
                    hi.MaintenanceActivated = bool.Parse(elements[6]);
                    hi.AutoFetchPhysicalAddress = bool.Parse(elements[7]);

                    _lst.Add(hi);
                }
            }

            UpdateLbx();
        }
    }
}
