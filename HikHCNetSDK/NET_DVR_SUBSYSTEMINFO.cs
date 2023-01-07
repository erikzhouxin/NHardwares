using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SUBSYSTEMINFO
    {
        public byte bySubSystemType;//子系统类型，1-解码用子系统，2-编码用子系统，0-NULL（此参数只能获取）
        public byte byChan;//子系统通道数（此参数只能获取）
        public byte byLoginType;//注册类型，1-直连，2-DNS，3-花生壳
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_IPADDR struSubSystemIP;/*IP地址（可修改）*/
        public ushort wSubSystemPort;//子系统端口号（可修改）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        public NET_DVR_IPADDR struSubSystemIPMask;//子网掩码
        public NET_DVR_IPADDR struGatewayIpAddr;    /* 网关地址*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;/* 用户名 （此参数只能获取）*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;/*密码（此参数只能获取）*/
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.MAX_DOMAIN_NAME)]
        public string sDomainName;//域名(可修改)
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.MAX_DOMAIN_NAME)]
        public string sDnsAddress;/*DNS域名或IP地址*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sSerialNumber;//序列号（此参数只能获取）
    }

}
