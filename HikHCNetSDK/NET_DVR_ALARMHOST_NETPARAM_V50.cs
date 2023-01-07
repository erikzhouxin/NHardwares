using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARMHOST_NETPARAM_V50
    {
        public uint dwSize;
        public NET_DVR_IPADDR struIP;
        public ushort wPort;
        public byte byAddressType;    //0 - 无意义, 1 - ipv4/ipv6地址，2 - 域名
        public byte byEnable; //使能，0-不启用，1-启用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
        public byte[] byDomainName; //域名，GPRS参数配置、网络参数配置时该字段均有效
        public byte byReportProtocol;        //1-private 2-NAL2300, 3-Ehome
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ACCOUNTNUM_LEN_32, ArraySubType = UnmanagedType.I1)]
        public byte[] byDevID; //协议为NAL2300时有效
        public byte byProtocolVersion;            //EHome协议版本，0-无意义,1–v2.0，2–v4.0，3-v5.0
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NET_SDK_EHOME_KEY_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byEHomeKey;            //EHome Key（用于EHome 5.0版本）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 28, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2; //GPRS的域名解析是在固定的服务器上进行的，所以不需要给解析服务器的信息预留一些字段
        public void Init()
        {
            struIP = new NET_DVR_IPADDR();
            byDomainName = new byte[HikHCNetSdk.MAX_DOMAIN_NAME];
            byDevID = new byte[HikHCNetSdk.ACCOUNTNUM_LEN_32];
            byRes1 = new byte[3];
            byEHomeKey = new byte[HikHCNetSdk.NET_SDK_EHOME_KEY_LEN];
            byRes2 = new byte[28];
        }
    }

}
