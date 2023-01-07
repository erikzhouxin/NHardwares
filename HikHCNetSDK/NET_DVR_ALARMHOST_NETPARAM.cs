using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARMHOST_NETPARAM
    {
        public uint dwSize;
        public NET_DVR_IPADDR struIP;
        public ushort wPort;
        public byte byAddressType;    //0 - 无意义, 1 - ipv4/ipv6地址，2 - 域名
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
        public byte[] byDomainName;
        public byte byReportProtocol;        //1-private 2-NAL2300, 3-Ehome
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ACCOUNTNUM_LEN_32, ArraySubType = UnmanagedType.I1)]
        public byte[] byDevID; //协议为NAL2300时有效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2; //GPRS的域名解析是在固定的服务器上进行的，所以不需要给解析服务器的信息预留一些字段
    }
}
