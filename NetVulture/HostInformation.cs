using System;
using System.Net.NetworkInformation;
using System.Net;
using System.Xml.Serialization;

namespace NetVulture
{
    public class HostInformation
    {
        [XmlElement(ElementName = "AutoFetchPhysicalAddress")]
        public bool AutoFetchPhysicalAddress { get; set; }

        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "Building")]
        public string Building { get; set; }

        [XmlElement(ElementName = "Cabinet")]
        public string Cabinet { get; set; }

        [XmlElement(ElementName = "Rack")]
        public string Rack { get; set; }

        [XmlElement(ElementName = "HostnameOrAddress")]
        public string HostnameOrAddress { get; set; }

        [XmlElement(ElementName = "LastAvailability")]
        public DateTime LastAvailability { get; set; }

        [XmlElement(ElementName = "PingAttempts")]
        public int PingAttempts { get; set; }

        [XmlIgnore]
        public PingReply ReplyData { get; set; }

        [XmlElement(ElementName = "PhysicalAddress")]
        public string PhysicalAddress { get; set; }

        [XmlElement(ElementName = "MaintenanceActivated")]
        public bool MaintenanceActivated { get; set; }
    }
}
