using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Text;
using System.Net;
using System.Runtime.InteropServices;

namespace NetVulture
{
    [XmlRoot(ElementName = "NetVultureBatch")]
    public class NvBatch
    {
        private string _name;
        private string _description;
        private List<NvDevice> _hostList;
        private DateTime _lastExec;
        private int _timeOut;
        private int _bufferSize;
        private bool _maintenance;

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
        public List<NvDevice> HostList { get { return _hostList; } set { _hostList = value; } }

        /// <summary>
        /// Get the last execution of icmp echo request.
        /// </summary>
        [XmlElement(ElementName = "LastExecution")]
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
        /// Get or set the indicator if maintenance is active or not.
        /// </summary>
        [XmlElement(ElementName = "Maintenance")]
        public bool Maintenance { get { return _maintenance; } set { _maintenance = value; } }

        /// <summary>
        /// Create a new instance of NetVultureBatch.
        /// </summary>
        public NvBatch()
        {
            _name = "New Batch";
            _timeOut = 1000;
            _bufferSize = 32;
        }

        /// <summary>
        /// Sending icmp echo message to each host in the hostlist asynchronous.
        /// </summary>
        public async Task CaptureAsync()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                if (_hostList != null && _hostList.Count > 0)
                {
                    //Last execute of batch
                    _lastExec = DateTime.Now;

                    for (int j = 0; j < _hostList.Count; j = j+1)
                    {
                        if (_hostList[j].MaintenanceActivated == false)
                        {
                            Ping p = new Ping();
                            
                            try
                            {
                                PingReply prPrimaray = await p.SendPingAsync(_hostList[j].HostnameOrAddress, _timeOut, new byte[_bufferSize]);

                                _hostList[j].ReplyData = prPrimaray;

                                if (prPrimaray == null || prPrimaray.Status != IPStatus.Success)
                                {
                                    PingReply prSecondary = await p.SendPingAsync(_hostList[j].AlternativeAddress, _timeOut, new byte[_bufferSize]);

                                    if (prSecondary == null || prSecondary.Status != IPStatus.Success)
                                    {
                                        _hostList[j].PingAttempts++;
                                    }
                                    else
                                    {
                                        _hostList[j].LastAvailability = DateTime.Now;
                                        _hostList[j].PingAttempts = 0;
                                    }
                                }
                                else
                                {
                                    _hostList[j].LastAvailability = DateTime.Now;
                                    _hostList[j].PingAttempts = 0;
                                }

                            }
                            catch (Exception)
                            {
                                _hostList[j].ReplyData = null;
                                _hostList[j].PingAttempts++;
                            }

                            p.Dispose(); 
                        }
                    }
                }
            }
        }

        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        static extern int SendARP(int destIp, int srcIp, byte[] pMacAddr, ref uint phyAddrLen);
        
        // *********************************************************************
        /// <summary>
        /// Gets the MAC address from ARP table in colon (:) separated format.
        /// </summary>
        /// <param name="hostNameOrAddress">Host name or IP address of the
        /// remote host for which MAC address is desired.</param>
        /// <returns>A string containing MAC address; null if MAC address could
        /// not be found.</returns>
        private string GetMacAddressFromArp(string hostNameOrAddress)
        {
            string mac = "00:00:00:00:00:00";

            IPHostEntry hostEntry = Dns.GetHostEntry(hostNameOrAddress);

            if (hostEntry.AddressList.Length == 0) return null;
            byte[] macAddr = new byte[6];
            uint macAddrLen = (uint)macAddr.Length;

#pragma warning disable 0618
            if (SendARP((int)hostEntry.AddressList[0].Address, 0, macAddr, ref macAddrLen) != 0) return null;
#pragma warning restore 0618

            StringBuilder macAddressString = new StringBuilder();
            for (int i = 0; i < macAddr.Length; i++)
            {
                if (macAddressString.Length > 0)
                    macAddressString.Append(":");
                macAddressString.AppendFormat("{0:x2}", macAddr[i]);
            }

            mac = macAddressString.ToString();

            return mac;
        }
    }
}
