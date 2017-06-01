using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NetVulture
{
    class IcmpPing
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct ICMP_OPTIONS
        {
            public byte Ttl;
            public byte Tos;
            public byte Flags;
            public byte OptionsSize;
            public IntPtr OptionsData;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct ICMP_ECHO_REPLY
        {
            public int Address;
            public int Status;
            public int RoundTripTime;
            public short DataSize;
            public short Reserved;
            public IntPtr DataPtr;
            public ICMP_OPTIONS Options;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 250)]
            public string Data;
        }

        [DllImport("Iphlpapi.dll", SetLastError = true)]
        private static extern IntPtr IcmpCreateFile();
        [DllImport("Iphlpapi.dll", SetLastError = true)]
        private static extern bool IcmpCloseHandle(IntPtr handle);
        [DllImport("Iphlpapi.dll", SetLastError = true)]
        private static extern int IcmpSendEcho2Ex(IntPtr icmpHandle, int sourceAddress, int destinationAddress, string requestData, short requestSize, ref ICMP_OPTIONS requestOptions, ref ICMP_ECHO_REPLY replyBuffer, int replySize, int timeout);

        public bool Ping(IPAddress src, IPAddress dest)
        {
            IntPtr icmpHandle = IcmpCreateFile();
            ICMP_OPTIONS icmpOptions = new ICMP_OPTIONS();
            icmpOptions.Ttl = 255;
            ICMP_ECHO_REPLY icmpReply = new ICMP_ECHO_REPLY();
            string sData = "x";

            int iReplies = IcmpSendEcho2Ex(icmpHandle, BitConverter.ToInt32(src.GetAddressBytes(), 0), BitConverter.ToInt32(dest.GetAddressBytes(), 0), sData, (short)sData.Length, ref icmpOptions, ref icmpReply, Marshal.SizeOf(icmpReply), 30);
            IcmpCloseHandle(icmpHandle);
            if (icmpReply.Status == 0)
                return true;
            return false;
        }
    }
}
