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
using nvcore;

namespace NetVulture
{
    public partial class FrmManageHosts : Form
    {

        public List<EndPoint> HostList { get { return _lst; } }
        private List<EndPoint> _lst = null;

        private void UpdateLbx()
        {
            _lbxHIs.Items.Clear();

            foreach (EndPoint hi in _lst)
            {
                _lbxHIs.Items.Add(hi.PrimaryAddress);
            }
        }

        public FrmManageHosts()
        {
            InitializeComponent();
            _lst = new List<EndPoint>();
        }

        public FrmManageHosts(List<EndPoint> lst)
        {
            InitializeComponent();
            _lst = lst;

            UpdateLbx();
        }

        private void _btnOk_Click(object sender, EventArgs e){}

        private void _btnAddHI_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_tbxDnsEntry.Text))
            {
                MessageBox.Show("Hostname or address is required");
                return;
            }
            else
            {
                if (_lst.Any(x => x.PrimaryAddress == _tbxDnsEntry.Text))
                {
                    MessageBox.Show("Hostname or address is already exist.");
                    return;
                }

                EndPoint hi = new EndPoint();
                hi.PrimaryAddress = _tbxDnsEntry.Text;
                hi.SecondaryAddress = _tbxAlternativeAddress.Text;
                hi.PriorityLevel = Convert.ToInt32(_nudPrioriyLevel.Value);
                hi.IsStaticIp = _chkBxIsStatic.Checked;
                hi.Description = _tbxHostDescription.Text;
                hi.DeviceVendor = _tbxDeviceVendor.Text;
                hi.DeviceModel = _tbxDeviceModel.Text;
                hi.DeviceSerial = _tbxDeviceSerial.Text;
                hi.Building = _tbxBuilding.Text;
                hi.Cabinet = _tbxCabinet.Text;
                hi.Rack = _tbxRack.Text;
                hi.Panel = _tbxPanel.Text;
                hi.ConnectedTo = _tbxConnectedTo.Text;
                hi.VlanId = _tbxVlanId.Text;
                hi.PhysicalAddress = _tbxPhysicalAddress.Text;
                hi.MaintenanceActivated = _chkBxIsMaintenanceActive.Checked;
                hi.AutoFetchPhysicalAddress = _chkBxAutoFetchMac.Checked;
                hi.Comment = _tbxComment.Text;

                _lst.Add(hi);
                UpdateLbx();

                Action<Control.ControlCollection> func = null;

                func = (controls) =>
                {
                    foreach (Control control in controls)
                        if (control is TextBox)
                            (control as TextBox).Clear();
                        else
                            func(control.Controls);
                };

                func(Controls);

                _nudPrioriyLevel.Value = 0;
                _chkBxIsStatic.Checked = false;
                _chkBxIsMaintenanceActive.Checked = false;
                _chkBxAutoFetchMac.Checked = false;

            }
        }

        private void _lbxHIs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lbxHIs.SelectedIndex != -1)
            {
                EndPoint hi = _lst.ElementAt(_lbxHIs.SelectedIndex);

                _tbxDnsEntry.Text = hi.PrimaryAddress;
                _tbxAlternativeAddress.Text = hi.SecondaryAddress;
                _nudPrioriyLevel.Value = hi.PriorityLevel;
                _chkBxIsStatic.Checked = hi.IsStaticIp;
                _tbxHostDescription.Text = hi.Description;
                _tbxDeviceVendor.Text = hi.DeviceVendor;
                _tbxDeviceModel.Text = hi.DeviceModel;
                _tbxDeviceSerial.Text = hi.DeviceSerial;
                _tbxBuilding.Text = hi.Building;
                _tbxCabinet.Text = hi.Cabinet;
                _tbxRack.Text = hi.Rack;
                _tbxPanel.Text = hi.Panel;
                _tbxConnectedTo.Text = hi.ConnectedTo;
                _tbxVlanId.Text = hi.VlanId;
                _tbxPhysicalAddress.Text = hi.PhysicalAddress;
                _chkBxIsMaintenanceActive.Checked = hi.MaintenanceActivated;
                _chkBxAutoFetchMac.Checked = hi.AutoFetchPhysicalAddress;
                _tbxComment.Text = hi.Comment;

                _btnSave.Enabled = true;
            }
        }

        private void _btnRemoveHI_Click(object sender, EventArgs e)
        {
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
                _lst[_lbxHIs.SelectedIndex].PrimaryAddress = _tbxDnsEntry.Text;
                _lst[_lbxHIs.SelectedIndex].SecondaryAddress = _tbxAlternativeAddress.Text;
                _lst[_lbxHIs.SelectedIndex].PriorityLevel = Convert.ToInt32(_nudPrioriyLevel.Value);
                _lst[_lbxHIs.SelectedIndex].IsStaticIp = _chkBxIsStatic.Checked;
                _lst[_lbxHIs.SelectedIndex].Description = _tbxHostDescription.Text;
                _lst[_lbxHIs.SelectedIndex].DeviceVendor = _tbxDeviceVendor.Text;
                _lst[_lbxHIs.SelectedIndex].DeviceModel = _tbxDeviceModel.Text;
                _lst[_lbxHIs.SelectedIndex].DeviceSerial = _tbxDeviceSerial.Text;
                _lst[_lbxHIs.SelectedIndex].Building = _tbxBuilding.Text;
                _lst[_lbxHIs.SelectedIndex].Cabinet = _tbxCabinet.Text;
                _lst[_lbxHIs.SelectedIndex].Rack = _tbxRack.Text;
                _lst[_lbxHIs.SelectedIndex].Panel = _tbxPanel.Text;
                _lst[_lbxHIs.SelectedIndex].ConnectedTo = _tbxConnectedTo.Text;
                _lst[_lbxHIs.SelectedIndex].VlanId = _tbxVlanId.Text;
                _lst[_lbxHIs.SelectedIndex].PhysicalAddress = _tbxPhysicalAddress.Text;
                _lst[_lbxHIs.SelectedIndex].MaintenanceActivated = _chkBxIsMaintenanceActive.Checked;
                _lst[_lbxHIs.SelectedIndex].AutoFetchPhysicalAddress = _chkBxAutoFetchMac.Checked;
                _lst[_lbxHIs.SelectedIndex].Comment = _tbxComment.Text;

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

                _lst = new List<EndPoint>();

                foreach (string line in lines)
                {
                    string[] elements = line.Split(';');

                    EndPoint hi = new EndPoint();
                    hi.PrimaryAddress = elements[0];
                    hi.SecondaryAddress = elements[1];
                    hi.PriorityLevel = int.Parse(elements[2]);
                    hi.IsStaticIp = bool.Parse(elements[3]);
                    hi.Description = elements[4];
                    hi.DeviceVendor = elements[5];
                    hi.DeviceModel = elements[6];
                    hi.DeviceSerial = elements[7];
                    hi.Building = elements[8];
                    hi.Cabinet = elements[9];
                    hi.Rack = elements[10];
                    hi.Panel = elements[11];
                    hi.ConnectedTo = elements[12];
                    hi.VlanId = elements[13];
                    hi.PhysicalAddress = elements[14];
                    hi.MaintenanceActivated = bool.Parse(elements[15]);
                    hi.AutoFetchPhysicalAddress = bool.Parse(elements[16]);
                    hi.Comment = elements[17];
                    hi.LastAvailability = DateTime.MinValue;
                    hi.PingAttempts = int.Parse(elements[19]);

                    _lst.Add(hi);
                }
            }

            UpdateLbx();
        }

        private void _btnExport_Click(object sender, EventArgs e)
        {

        }
    }
}
