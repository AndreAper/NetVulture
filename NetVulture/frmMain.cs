

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

namespace NetVulture
{
    public partial class frmMain : Form
    {
        private List<NVBatch> _batchList;
        private string _outputDir;
        private DateTime _lastExecutionTime;
        private BackgroundWorker _backWorker;

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

                    System.Diagnostics.Debug.Print("Write Batch with name : " + job.Name);

                    if (job.Results != null && job.Results.Count > 0)
                    {
                        using (StreamWriter swCsv = new StreamWriter(csvFile))
                        {
                            System.Diagnostics.Debug.Print("If job.Results null? : " + (job.Results == null).ToString());
                            System.Diagnostics.Debug.Print("Count of elements in job.Results sequence : " + job.Results.Count.ToString());
                            System.Diagnostics.Debug.Print("Count of elements in job.HostList sequence : " + job.HostList.Count.ToString());

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

                                System.Diagnostics.Debug.Print("Write pingreply object " + i.ToString() + " of " + job.Results.Count.ToString() + " with data " + string.Join(",", data));
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

                            await swJs.WriteAsync("var " + job.Name + "[" + string.Join(",", jsArrayElements) + "];");
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
                _lblLastCollect.Text = "Last Execution: " + _lastExecutionTime.ToString();
                _btnCollect.Enabled = true;
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
                    _btnExecBatch.Enabled = false;               
                });
            } 

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
                                    }
                                    catch (Exception ex)
                                    {
                                        if (ex is System.Net.Sockets.SocketException)
                                        {
                                            _batchList[i].Results.Add(pr);
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
                _backWorker.RunWorkerAsync(-1);
            }
            else
            {
                _chkBtnTimerEnabled.Text = "Timer Disabled";
            }

            ShowJobInfo();
        }

        private void _btnHome_Click(object sender, EventArgs e)
        {
            _lbxJobs.SelectedIndex = -1;
        }

        private void _clock_Tick(object sender, EventArgs e)
        {
            _lblClock.Text = DateTime.Now.ToString();
        }

        private void _chkBtnTimerEnabled_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_outputDir))
            {
                _chkBtnTimerEnabled.Checked = false;
            }
            else
            {
                if (_backWorker.IsBusy == false)
                {
                    _chkBtnTimerEnabled.Checked = true;
                    _backWorker.RunWorkerAsync(-1);
                }
                else
                {
                    _chkBtnTimerEnabled.Checked = false;
                }
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
