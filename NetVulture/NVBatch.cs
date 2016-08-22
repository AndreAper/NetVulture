using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Net.NetworkInformation;
using System.Timers;
using System.Linq;
using System.Threading.Tasks;

namespace NetVulture
{
    [XmlRoot(ElementName = "NetVultureBatch")]
    public class NVBatch
    {
        private string _name;
        private string _description;
        private List<string> _hostList = null;
        private List<PingReply> _results = null;
        private DateTime _lastExec;
        private int _timeOut;
        private int _bufferSize;
        private Dictionary<string, int> _failedHosts;

        /// <summary>
        /// Get or set the name of the batch
        /// </summary>
        [XmlElement(ElementName = "Name")]
        public string Name { get { return _name; } set { _name = value; } }

        /// <summary>
        /// Get or set a optionally description of the batch.
        /// </summary>
        [XmlElement(ElementName = "Description")]
        public string Description { get { return _description; } set { _description = value; } }

        /// <summary>
        /// Get or set the list that contains all hosts to send the icmp echo messages.
        /// </summary>
        [XmlElement(ElementName = "HostList")]
        public List<string> HostList { get { return _hostList; } set { _hostList = value; } }

        /// <summary>
        /// Get the last execution of icmp echo request.
        /// </summary>
        [XmlIgnore]
        public DateTime LastExecution { get { return _lastExec; } }

        /// <summary>
        /// Get or set the time to wait until the icmp package received.
        /// </summary>
        [XmlElement(ElementName = "Timeout")]
        public int Timeout { get { return _timeOut; } set { _timeOut = value; } }

        /// <summary>
        /// Get or set the size of the byte array that contains data to be sent with the ICMP echo message and returned in the ICMP echo reply message.
        /// </summary>
        [XmlElement(ElementName = "Buffersize")]
        public int Buffersize { get { return _bufferSize; } set { _bufferSize = value; } }

        /// <summary>
        /// Get the results of all icmp echo requests.
        /// </summary>
        [XmlIgnore]
        public List<PingReply> Results { get { return _results; } }

        /// <summary>
        /// Get the a list of failed targets.
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, int> FailedHosts { get { return _failedHosts; } }

        /// <summary>
        /// Create a new instance of NetVultureBatch.
        /// </summary>
        public NVBatch()
        {
            _results = new List<PingReply>();
            _failedHosts = new Dictionary<string, int>();
            _name = "New Batch";
            _timeOut = 1000;
            _bufferSize = 32;
        }

        /// <summary>
        /// Sending icmp echo message to each host in the hostlist asynchronous.
        /// </summary>
        public async Task Capture()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                if (_hostList != null && _hostList.Count > 0)
                {
                    _results.Clear();
                    _lastExec = DateTime.Now;

                    for (int j = 0; j < _hostList.Count; j = j+1)
                    {
                        Ping p = new Ping();
                        PingReply pr = null;

                        try
                        {
                            pr = await p.SendPingAsync(_hostList[j], _timeOut, new byte[_bufferSize]);
                            _results.Add(pr);

                            if (pr.Status != IPStatus.Success)
                            {
                                if (_failedHosts.Any(x => x.Key == _hostList[j]))
                                {
                                    _failedHosts[_hostList[j]]++;
                                }
                                else
                                {
                                    _failedHosts.Add(_hostList[j], 0);
                                }
                            }

                        }
                        catch (Exception)
                        {
                            _results.Add(pr);

                            if (_failedHosts.Any(x => x.Key == _hostList[j]))
                            {
                                _failedHosts[_hostList[j]]++;
                            }
                            else
                            {
                                _failedHosts.Add(_hostList[j], 0);
                            }
                        }


                        p.Dispose();
                    }
                }
            }
        }

        public async Task Capture(int timeOut)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                if (_hostList != null && _hostList.Count > 0)
                {
                    _results.Clear();
                    _lastExec = DateTime.Now;

                    for (int j = 0; j < _hostList.Count; j = j + 1)
                    {
                        Ping p = new Ping();
                        PingReply pr = null;

                        try
                        {
                            pr = await p.SendPingAsync(_hostList[j], timeOut, new byte[_bufferSize]);
                            _results.Add(pr);

                            if (pr.Status != IPStatus.Success)
                            {
                                if (_failedHosts.Any(x => x.Key == _hostList[j]))
                                {
                                    _failedHosts[_hostList[j]]++;
                                }
                                else
                                {
                                    _failedHosts.Add(_hostList[j], 0);
                                }
                            }

                        }
                        catch (Exception)
                        {
                            _results.Add(pr);

                            if (_failedHosts.Any(x => x.Key == _hostList[j]))
                            {
                                _failedHosts[_hostList[j]]++;
                            }
                            else
                            {
                                _failedHosts.Add(_hostList[j], 0);
                            }
                        }


                        p.Dispose();
                    }
                }
            }
        }

        public async Task Capture(int timeOut, int bufferSize)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                if (_hostList != null && _hostList.Count > 0)
                {
                    _results.Clear();
                    _lastExec = DateTime.Now;

                    for (int j = 0; j < _hostList.Count; j = j + 1)
                    {
                        Ping p = new Ping();
                        PingReply pr = null;

                        try
                        {
                            pr = await p.SendPingAsync(_hostList[j], timeOut, new byte[bufferSize]);
                            _results.Add(pr);

                            if (pr.Status != IPStatus.Success)
                            {
                                if (_failedHosts.Any(x => x.Key == _hostList[j]))
                                {
                                    _failedHosts[_hostList[j]]++;
                                }
                                else
                                {
                                    _failedHosts.Add(_hostList[j], 0);
                                }
                            }

                        }
                        catch (Exception)
                        {
                            _results.Add(pr);

                            if (_failedHosts.Any(x => x.Key == _hostList[j]))
                            {
                                _failedHosts[_hostList[j]]++;
                            }
                            else
                            {
                                _failedHosts.Add(_hostList[j], 0);
                            }
                        }


                        p.Dispose();
                    }
                }
            }
        }
    }
}
