using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace nvcore.Devices
{
    public class Switch : IDevice
    {
        public string PrimaryTargetAddress { get; set; }
        public string SecondaryTargetAddress { get; set; }
        public int PriorityLevel { get; set; }
        public bool IsStaticIp { get; set; }
        public string Description { get; set; }
        public string DeviceVendor { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceSerial { get; set; }
        public string Building { get; set; }
        public string Cabinet { get; set; }
        public string Rack { get; set; }
        public string Panel { get; set; }
        public string ConnectedTo { get; set; }
        public string VlanId { get; set; }
        public string PhysicalAddress { get; set; }
        public bool MaintenanceActivated { get; set; }
        public bool AutoFetchPhysicalAddress { get; set; }
        public string Comment { get; set; }
        public DateTime LastRequest { get; set; }
        public List<DateTime> FailedRequests { get; set; }
        public int PingAttempts { get; set; }
        public PingReply ReplyData { get; set; }
        public DeviceTypes DeviceType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void SendRequest()
        {
            throw new NotImplementedException();
        }

        public Task SendRequestAsync()
        {
            throw new NotImplementedException();
        }
    }
}
