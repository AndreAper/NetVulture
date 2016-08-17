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
            _timeOut = 50000;
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

                    for (int j = 0; j < _hostList.Count; j++)
                    {
                        Ping p = new Ping();
                        PingReply pr = null;

                        try
                        {
                            pr = await p.SendPingAsync(_hostList[j]);
                            _results.Add(pr);

                            if (pr.Status != IPStatus.Success)
                            {
                                if (_failedHosts.Any(x => x.Key == pr.Address.ToString()))
                                {
                                    _failedHosts[pr.Address.ToString()] += 1;
                                }
                                else
                                {
                                    _failedHosts.Add(pr.Address.ToString(), 0);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex is System.Net.Sockets.SocketException)
                            {
                                _results.Add(pr);
                            }
                        }
                        finally
                        {
                            p.Dispose();
                        }
                    }
                }
            }
        }
    }
}
