using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //动态域名参数配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DEV_DDNS_INFO
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.MAX_DOMAIN_NAME)]
        public string byDevAddress;         //设备域名(IPServer或hiDDNS时可填设备序列号或者别名) 
        public byte byTransProtocol;        //传输协议类型：0- TCP，1- UDP，2- 多播
        public byte byTransMode;            //传输码流模式 0－主码流 1－子码流
        public byte byDdnsType;             //域名服务器类型：0- IPServer，1- Dyndns，2- PeanutHull(花生壳)，3- NO-IP，4- hiDDNS
        public byte byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.MAX_DOMAIN_NAME)]
        public string byDdnsAddress;        //DDNS服务器地址
        public ushort wDdnsPort;            //DDNS服务器端口号
        public byte byChanType;             //通道类型：0-普通通道，1-零通道，2-流ID
        public byte byFactoryType;          //前端设备厂家类型,通过接口NET_DVR_GetIPCProtoList获取
        public uint dwChannel;              //通道号
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.STREAM_ID_LEN)]
        public string byStreamId;           // 流ID，通道类型 byChanType 为 2 时有效
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.NAME_LEN)]
        public string sUserName;            //监控主机登陆帐号
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.PASSWD_LEN)]
        public string sPassword;            //监控主机密码
        public ushort wDevPort;             //设备端口号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
