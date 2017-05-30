using System;
using System.Net.NetworkInformation;
using System.Net;
using System.Xml.Serialization;
using System.Text;

namespace NetVulture
{
    public class NvDevice
    {
        /// <summary>
        /// Get or set the dns name or ipv4 address of the device.
        /// </summary>
        [XmlElement(ElementName = "HostnameOrAddress")]
        public string HostnameOrAddress { get; set; }

        /// <summary>
        /// Get or set the alternative address that can be use for secondary ping if the primary address not available.
        /// </summary>
        [XmlElement(ElementName = "AlternativeAddress")]
        public string AlternativeAddress { get; set; }

        /// <summary>
        /// Get or set the priority level of the device.
        /// </summary>
        [XmlElement(ElementName = "PriorityLevel")]
        public int PriorityLevel { get; set; }

        /// <summary>
        /// True if the device has a static ip address.
        /// </summary>
        [XmlElement(ElementName = "IsStaticIp")]
        public bool IsStaticIp { get; set; }

        /// <summary>
        /// Get or set a description of the device.
        /// </summary>
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Get or set the vendor of the device.
        /// </summary>
        [XmlElement(ElementName = "DeviceVendor")]
        public string DeviceVendor { get; set; }

        /// <summary>
        /// Get or set the model of the device.
        /// </summary>
        [XmlElement(ElementName = "DeviceModel")]
        public string DeviceModel { get; set; }

        /// <summary>
        /// Get or set the serial number of the device.
        /// </summary>
        [XmlElement(ElementName = "DeviceSerial")]
        public string DeviceSerial { get; set; }

        /// <summary>
        /// Get or set the name of the building was installed the device.
        /// </summary>
        [XmlElement(ElementName = "Building")]
        public string Building { get; set; }

        /// <summary>
        /// Get or set the name of the cabinet was installed the device.
        /// </summary>
        [XmlElement(ElementName = "Cabinet")]
        public string Cabinet { get; set; }

        /// <summary>
        /// Get or set the name of the rack was installed the device.
        /// </summary>
        [XmlElement(ElementName = "Rack")]
        public string Rack { get; set; }

        /// <summary>
        /// Get or set the number of the panel was installed the device.
        /// </summary>
        [XmlElement(ElementName = "Panel")]
        public string Panel { get; set; }

        /// <summary>
        /// Get or set the information of device that connected to other network device. E.g. BSA123/Fe1, BSA234/Gi2
        /// </summary>
        [XmlElement(ElementName = "ConnectedTo")]
        public string ConnectedTo { get; set; }

        /// <summary>
        /// Get or set the vlan id of the device that connected to.
        /// </summary>
        [XmlElement(ElementName = "VlanId")]
        public string VlanId { get; set; }

        /// <summary>
        /// Get or set the physical address of the device.
        /// </summary>
        [XmlElement(ElementName = "PhysicalAddress")]
        public string PhysicalAddress { get; set; }

        /// <summary>
        /// True if the device is currently in maintenance
        /// </summary>
        [XmlElement(ElementName = "MaintenanceActivated")]
        public bool MaintenanceActivated { get; set; }

        /// <summary>
        /// True to send a arp request to the device to receive the physical address of the device.
        /// </summary>
        [XmlElement(ElementName = "AutoFetchPhysicalAddress")]
        public bool AutoFetchPhysicalAddress { get; set; }

        /// <summary>
        /// Get or set a custom comment to this host.
        /// </summary>
        [XmlElement(ElementName = "Comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Get or set the last availability of the device.
        /// </summary>
        [XmlElement(ElementName = "LastAvailability")]
        public DateTime LastAvailability { get; set; }

        /// <summary>
        /// Get or set the attemptations to ping of the device.
        /// </summary>
        [XmlElement(ElementName = "PingAttempts")]
        public int PingAttempts { get; set; }

        /// <summary>
        /// Get or set the data of the response of the ping request.
        /// </summary>
        [XmlIgnore]
        public PingReply ReplyData { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(HostnameOrAddress + ";");
            sb.Append(AlternativeAddress + ";");
            sb.Append(PriorityLevel + ";");
            sb.Append(IsStaticIp + ";");
            sb.Append(Description + ";");
            sb.Append(DeviceVendor + ";");
            sb.Append(DeviceModel + ";");
            sb.Append(DeviceSerial + ";");
            sb.Append(Building + ";");
            sb.Append(Rack + ";");
            sb.Append(Panel + ";");
            sb.Append(ConnectedTo + ";");
            sb.Append(VlanId);
            sb.Append(PhysicalAddress + ";");
            sb.Append(MaintenanceActivated + ";");
            sb.Append(AutoFetchPhysicalAddress + ";");
            sb.Append(Comment + ";");
            sb.Append(LastAvailability + ";");
            sb.Append(PingAttempts + ";");

            if (this.ReplyData == null)
            {
                sb.Append("UNKNOWN_STATUS;");
                sb.Append("UNKNOWN_ROUNDTRIPTIME;");
                sb.Append("UNKNOWN_RETURNED_ADDRESS;");
            }
            else
            {
                sb.Append(this.ReplyData.Status + ";");
                sb.Append(this.ReplyData.RoundtripTime + ";");
                sb.Append(this.ReplyData.Address + ";");
            }
                
            return sb.ToString();
        }
    }
}
