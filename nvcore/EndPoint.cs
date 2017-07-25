using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Net.NetworkInformation;
using System.Reflection;

namespace nvcore
{
    public class EndPoint
    {
        /// <summary>
        /// Get or set the primary dns name or ipv4 address of the device.
        /// </summary>
        [XmlElement(ElementName = "PrimaryAddress")]
        public string PrimaryAddress;

        /// <summary>
        /// Get or set the secondary dns name or ipv4 address of the device.
        /// </summary>
        [XmlElement(ElementName = "SecondaryAddress")]
        public string SecondaryAddress;

        /// <summary>
        /// Get or set the priority level of the device. 0 is the highest priority.
        /// </summary>
        [XmlElement(ElementName = "PriorityLevel")]
        public int PriorityLevel;

        /// <summary>
        /// True if the device has a static ip address.
        /// </summary>
        [XmlElement(ElementName = "IsStaticIp")]
        public bool IsStaticIp;

        /// <summary>
        /// Get or set a description of the device.
        /// </summary>
        [XmlElement(ElementName = "Description")]
        public string Description;

        /// <summary>
        /// Get or set the type of the device.
        /// </summary>
        [XmlElement(ElementName = "DeviceType")]
        public DeviceTypes DeviceType;

        /// <summary>
        /// Get or set the vendor of the device.
        /// </summary>
        [XmlElement(ElementName = "DeviceVendor")]
        public string DeviceVendor;

        /// <summary>
        /// Get or set the model of the device.
        /// </summary>
        [XmlElement(ElementName = "DeviceModel")]
        public string DeviceModel;

        /// <summary>
        /// Get or set the serial number of the device.
        /// </summary>
        [XmlElement(ElementName = "DeviceSerial")]
        public string DeviceSerial;

        /// <summary>
        /// Get or set the name of the building was installed the device.
        /// </summary>
        [XmlElement(ElementName = "Building")]
        public string Building;

        /// <summary>
        /// Get or set the name of the cabinet was installed the device.
        /// </summary>
        [XmlElement(ElementName = "Cabinet")]
        public string Cabinet;

        /// <summary>
        /// Get or set the name of the rack was installed the device.
        /// </summary>
        [XmlElement(ElementName = "Rack")]
        public string Rack;

        /// <summary>
        /// Get or set the number of the panel was installed the device.
        /// </summary>
        [XmlElement(ElementName = "Panel")]
        public string Panel;

        /// <summary>
        /// Get or set the information of device that connected to other network device. E.g. BSA123/Fe1, BSA234/Gi2
        /// </summary>
        [XmlElement(ElementName = "ConnectedTo")]
        public string ConnectedTo;

        /// <summary>
        /// Get or set the vlan id of the device that connected to.
        /// </summary>
        [XmlElement(ElementName = "VlanId")]
        public string VlanId;

        /// <summary>
        /// Get or set the physical address of the device.
        /// </summary>
        [XmlElement(ElementName = "PhysicalAddress")]
        public string PhysicalAddress;

        /// <summary>
        /// True if the device is currently in maintenance
        /// </summary>
        [XmlElement(ElementName = "MaintenanceActivated")]
        public bool MaintenanceActivated;

        /// <summary>
        /// True to send a arp request to the device to receive the physical address of the device.
        /// </summary>
        [XmlElement(ElementName = "AutoFetchPhysicalAddress")]
        public bool AutoFetchPhysicalAddress;

        /// <summary>
        /// Get or set a custom comment to this host.
        /// </summary>
        [XmlElement(ElementName = "Comment")]
        public string Comment;

        /// <summary>
        /// Get or set the last availability of the device.
        /// </summary>
        [XmlElement(ElementName = "LastAvailability")]
        public DateTime LastAvailability;

        /// <summary>
        /// Get a list of all failed requests to the devices.
        /// </summary>
        [XmlElement(ElementName = "FailedRequests")]
        public List<DateTime> FailedRequests { get; set; }

        /// <summary>
        /// Get or set the attemptations to ping of the device.
        /// </summary>
        [XmlElement(ElementName = "PingAttempts")]
        public int PingAttempts;

        /// <summary>
        /// Gets the address of the host that sends the reply.
        /// </summary>
        [XmlElement(ElementName = "ReplyAddress")]
        public string ReplyAddress;

        /// <summary>
        /// Gets the status of an attempt to send an ping request and receive the corresponding ICMP echo reply message.
        /// </summary>
        [XmlElement(ElementName = "Status")]
        public IPStatus Status;

        /// <summary>
        /// Gets the number of milliseconds taken to send an ping request and receive the corresponding ICMP echo reply message.
        /// </summary>
        [XmlElement(ElementName = "RoundtripTime")]
        public long RoundtripTime;

        /// <summary>
        /// Gets the address of the host that sends the reply.
        /// </summary>
        [XmlElement(ElementName = "ReplyMessage")]
        public string ReplyMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="EndPoint"/>.
        /// </summary>
        public EndPoint()
        {
            this.Status = IPStatus.Unknown;
            this.LastAvailability = new DateTime();
            this.PingAttempts = 0;
            this.ReplyMessage = "Not requested";
        }

        /// <summary>
        /// Returns a string that represents the current instanc of <see cref="EndPoint"/>.
        /// </summary>
        /// <returns>A string that represents the current instanc of <see cref="EndPoint".</returns>
        public override string ToString()
        {
            // Get the type handle of a specified class.
            Type type = typeof(EndPoint);

            // Get the fields of the specified class.
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            string[] data = new string[fields.Length];

            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i].GetValue(this) != null)
                {
                    data[i] = fields[i].GetValue(this).ToString();
                }
                else
                {
                    data[i] = "";
                }
            }

            return string.Join(";", data);
        }
    }
}
