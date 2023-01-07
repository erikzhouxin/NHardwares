using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*IP地址*/
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_IPADDR
    {

        /// char[16]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] sIpV4;

        /// BYTE[128]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
        public byte[] byIPv6;

        public void Init()
        {
            sIpV4 = new byte[16];
            byIPv6 = new byte[128];
        }
    }
}
