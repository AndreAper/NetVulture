using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;

namespace NetVulture
{
    public partial class frmReport : Form
    {
        List<NVBatch> _batchList;

        private async Task<PingReply> PingRequest(int index)
        {
            DataGridViewRow newDataRow = dataGridView.Rows[index];
            NVBatch batch = _batchList.Single(b => b.Name == dataGridView[0, index].Value.ToString());
            string address = batch.HostList.FirstOrDefault(h => h == dataGridView[1, index].Value.ToString());

            Ping p = new Ping();
            PingReply pr = null;

            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IcmpV4Statistics statistics = properties.GetIcmpV4Statistics();
            System.Diagnostics.Debug.Print("  TimeExceeded ........................ Sent: {0,-10}   Received: {1,-10}", statistics.TimeExceededMessagesSent, statistics.TimeExceededMessagesReceived);

            try
            {
                pr = await p.SendPingAsync(address, 1000);

                if (pr.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    IPAddress addr = System.Net.IPAddress.Parse(pr.Address.ToString());
                    IPHostEntry entry = Dns.GetHostEntry(addr);

                    newDataRow.Cells[0].Value = batch.Name;
                    newDataRow.Cells[1].Value = address;
                    newDataRow.Cells[2].Value = pr.Address;
                    newDataRow.Cells[3].Value = entry.HostName;
                    newDataRow.Cells[4].Value = pr.Status.ToString();
                    newDataRow.Cells[5].Value = pr.RoundtripTime.ToString();
                    newDataRow.Cells[6].Value = "-1";
                    newDataRow.Cells[7].Value = DateTime.Now.ToString();

                }
                else
                {
                    newDataRow.Cells[0].Value = batch.Name;
                    newDataRow.Cells[1].Value = address;
                    newDataRow.Cells[2].Value = "";
                    newDataRow.Cells[3].Value = "";
                    newDataRow.Cells[4].Value = pr.Status.ToString();
                    newDataRow.Cells[5].Value = "";
                    newDataRow.Cells[6].Value = "-1";
                    newDataRow.Cells[7].Value = DateTime.Now.ToString();
                    newDataRow.DefaultCellStyle.BackColor = Color.Salmon;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                p.Dispose();
            }

            return pr;
        }

        private void UpdateDGV()
        {
            dataGridView.Rows.Clear();

            if (_batchList.Count > 0)
            {
                for (int j = 0; j < _batchList.Count; j++)
                {
                    for (int i = 0; i < _batchList[j].HostList.Count; i++)
                    {
                        DataGridViewRow row = dataGridView.Rows[dataGridView.Rows.Add()];

                        row.Cells[0].Value = _batchList[j].Name;
                        row.Cells[1].Value = _batchList[j].HostList[i];

                        string dns = "";
                        string ipAddress = "";
                        string ipStatus = "";
                        string roundTrip = "";

                        if (_batchList[j].Results.Count > 0)
                        {
                            ipAddress = _batchList[j].Results[i].Address.ToString();


                            ipStatus = _batchList[j].Results[i].Status.ToString();

                            if (_batchList[j].Results[i].Status != System.Net.NetworkInformation.IPStatus.Success)
                            {
                                row.DefaultCellStyle.BackColor = Color.Salmon;
                            }

                            roundTrip = _batchList[j].Results[i].RoundtripTime.ToString();

                            if (ipAddress != "0.0.0.0")
                            {
                                IPAddress addr = System.Net.IPAddress.Parse(ipAddress);

                                try
                                {
                                    IPHostEntry entry = Dns.GetHostEntry(addr);
                                    dns = entry.HostName;

                                }
                                catch (System.Net.Sockets.SocketException)
                                {
                                    dns = "";
                                }
                            }
                        }

                        string pingAttempts = "0";
                        if (_batchList[j].FailedHosts.Count > 0)
                        {
                            if (_batchList[j].FailedHosts.ContainsKey(_batchList[j].Results[i].Address.ToString()))
                            {
                                pingAttempts = _batchList[j].FailedHosts[_batchList[j].Results[i].Address.ToString()].ToString();
                            }
                        }


                        row.Cells[2].Value = ipAddress;
                        row.Cells[3].Value = dns;
                        row.Cells[4].Value = ipStatus;
                        row.Cells[5].Value = roundTrip;
                        row.Cells[6].Value = "-1";
                        row.Cells[7].Value = DateTime.Now.ToString();
                        row.Cells[8].Value = "Ping";

                        //BatchName, Host, IPAddress, DNS, IPStatus, Roundtrip, Attempts, Last Execution, PingButton
                        //dataGridView.Rows.Add(_batchList[j].Name, _batchList[j].HostList[i], ipAddress, dns, ipStatus, roundTrip, pingAttempts, _batchList[j].LastExecution.ToString(), "Ping");

                    }
                }
            }

        }

        public frmReport(List<NVBatch> batchList)
        {
            InitializeComponent();
            _batchList = batchList;

            dataGridView.CellClick += new DataGridViewCellEventHandler(dataGridView_CellClick);

            if (_batchList != null)
            {
                UpdateDGV(); 
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                Task t = Task.Factory.StartNew(() => PingRequest(e.RowIndex));
                t.Wait();
            }
        }

        private void _btnPingAll_Click(object sender, EventArgs e)
        {
            if (_batchList.Count > 0)
            {
                List<Task> tasks = new List<Task>();

                _batchList.ForEach((batch) =>
                {
                    tasks.Add(Task.Factory.StartNew(() => batch.Capture()));
                });

                Task.WhenAll(tasks);
                UpdateDGV();
            }
        }

        private void _btnExportCsv_Click(object sender, EventArgs e)
        {

        }
    }
}
