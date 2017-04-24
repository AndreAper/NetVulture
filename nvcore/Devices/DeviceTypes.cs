using System.Xml.Serialization;

namespace nvcore.Devices
{
    public enum DeviceTypes
    {
        [XmlEnum(Name = "Servers")]
        Servers,

        [XmlEnum(Name = "Switches")]
        Switches,

        [XmlEnum(Name = "AccessPoints")]
        AccessPoints,

        [XmlEnum(Name = "TimeRecordingDevices")]
        TimeRecordingDevices,

        [XmlEnum(Name = "Printers")]
        Printers,

        [XmlEnum(Name = "MobileDevices")]
        MobileDevices,

        [XmlEnum(Name = "SensitiveDevices")]
        SensitiveDevices,

        [XmlEnum(Name = "Routers")]
        Routers,

        [XmlEnum(Name = "Firewalls")]
        Firewalls,

        [XmlEnum(Name = "Telephones")]
        Telephones,

        [XmlEnum(Name = "Other")]
        Other,

        [XmlEnum(Name = "Unknown")]
        Unknown
    }
}
