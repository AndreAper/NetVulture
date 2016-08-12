using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Net.NetworkInformation;
using System.Net;
using System.Timers;

namespace NetVulture
{
    [XmlRoot(ElementName = "NetVultureBatch")]
    public class NVBatch
    {
        private string _name, _description;
        private List<string> _hostList = null;
        private List<PingReply> _results = null;
        private DateTime _lastExec;
        private int _timeOut = 5000, _bufferSize = 32;

        [XmlElement(ElementName = "Name")]
        public string Name { get { return _name; } set { _name = value; } }

        [XmlElement(ElementName = "Description")]
        public string Description { get { return _description; } set { _description = value; } }

        [XmlElement(ElementName = "HostList")]
        public List<string> HostList { get { return _hostList; } set { _hostList = value; } }

        [XmlIgnore]
        public DateTime LastExecution { get { return _lastExec; } set { _lastExec = value; } }

        [XmlElement(ElementName = "Timeout")]
        public int Timeout { get { return _timeOut; } set { _timeOut = value; } }

        [XmlElement(ElementName = "Buffersize")]
        public int Buffersize { get { return _bufferSize; } set { _bufferSize = value; } }

        [XmlIgnore]
        public List<PingReply> Results { get { return _results; } set { _results = value; } }
    }
}
