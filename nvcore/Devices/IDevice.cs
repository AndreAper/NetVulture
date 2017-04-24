using System;
using System.Xml.Serialization;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nvcore.Devices
{
    public interface IDevice
    {
        /// <summary>
        /// Get or set the primary dns name or ipv4 address of the device.
        /// </summary>
        [XmlElement(ElementName = "PrimaryTargetAddress")]
        string PrimaryTargetAddress { get; set; }

        /// <summary>
        /// Get or set the secondary dns name or ipv4 address of the device.
        /// </summary>
        [XmlElement(ElementName = "SecondaryTargetAddress")]
        string SecondaryTargetAddress { get; set; }

        /// <summary>
        /// Get or set the priority level of the device. 0 is the highest priority.
        /// </summary>
        [XmlElement(ElementName = "PriorityLevel")]
        int PriorityLevel { get; set; }

        /// <summary>
        /// True if the device has a static ip address.
        /// </summary>
        [XmlElement(ElementName = "IsStaticIp")]
        bool IsStaticIp { get; set; }

        /// <summary>
        /// Get or set a description of the device.
        /// </summary>
        [XmlElement(ElementName = "Description")]
        string Description { get; set; }

        /// <summary>
        /// Get or set the type of the device.
        /// </summary>
        [XmlElement(ElementName = "DeviceType")]
        DeviceTypes DeviceType { get; set; }

        /// <summary>
        /// Get or set the vendor of the device.
        /// </summary>
        [XmlElement(ElementName = "DeviceVendor")]
        string DeviceVendor { get; set; }

        /// <summary>
        /// Get or set the model of the device.
        /// </summary>
        [XmlElement(ElementName = "DeviceModel")]
        string DeviceModel { get; set; }

        /// <summary>
        /// Get or set the serial number of the device.
        /// </summary>
        [XmlElement(ElementName = "DeviceSerial")]
        string DeviceSerial { get; set; }

        /// <summary>
        /// Get or set the name of the building was installed the device.
        /// </summary>
        [XmlElement(ElementName = "Building")]
        string Building { get; set; }

        /// <summary>
        /// Get or set the name of the cabinet was installed the device.
        /// </summary>
        [XmlElement(ElementName = "Cabinet")]
        string Cabinet { get; set; }

        /// <summary>
        /// Get or set the name of the rack was installed the device.
        /// </summary>
        [XmlElement(ElementName = "Rack")]
        string Rack { get; set; }

        /// <summary>
        /// Get or set the number of the panel was installed the device.
        /// </summary>
        [XmlElement(ElementName = "Panel")]
        string Panel { get; set; }

        /// <summary>
        /// Get or set the information of device that connected to other network device. E.g. BSA123/Fe1, BSA234/Gi2
        /// </summary>
        [XmlElement(ElementName = "ConnectedTo")]
        string ConnectedTo { get; set; }

        /// <summary>
        /// Get or set the vlan id of the device that connected to.
        /// </summary>
        [XmlElement(ElementName = "VlanId")]
        string VlanId { get; set; }

        /// <summary>
        /// Get or set the physical address of the device.
        /// </summary>
        [XmlElement(ElementName = "PhysicalAddress")]
        string PhysicalAddress { get; set; }

        /// <summary>
        /// True if the device is currently in maintenance
        /// </summary>
        [XmlElement(ElementName = "MaintenanceActivated")]
        bool MaintenanceActivated { get; set; }

        /// <summary>
        /// True to send a arp request to the device to receive the physical address of the device.
        /// </summary>
        [XmlElement(ElementName = "AutoFetchPhysicalAddress")]
        bool AutoFetchPhysicalAddress { get; set; }

        /// <summary>
        /// Get or set a custom comment to this host.
        /// </summary>
        [XmlElement(ElementName = "Comment")]
        string Comment { get; set; }

        /// <summary>
        /// Get or set the last availability of the device.
        /// </summary>
        [XmlElement(ElementName = "LastAvailability")]
        DateTime LastRequest { get; set; }

        /// <summary>
        /// Get a list of all failed requests to the devices.
        /// </summary>
        List<DateTime> FailedRequests { get; }

        /// <summary>
        /// Get or set the attemptations to ping of the device.
        /// </summary>
        [XmlElement(ElementName = "PingAttempts")]
        int PingAttempts { get; set; }

        /// <summary>
        /// Get or set the data of the response of the ping request.
        /// </summary>
        [XmlIgnore]
        PingReply ReplyData { get; set; }

        /// <summary>
        /// Send a icmp request to the device and store reply to the <see cref="ReplyData"/> Property.
        /// </summary>
        void SendRequest();

        /// <summary>
        /// Send a icmp request asynchronous to the device and store reply to the <see cref="ReplyData"/> Property.
        /// </summary>
        Task SendRequestAsync();
    }
}
