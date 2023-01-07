using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SNMPCFG
    {
        public uint dwSize;         //结构长度
        public byte byEnable;           //0-禁用SNMP，1-表示启用SNMP
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;           //保留
        public ushort wVersion;     //snmp 版本  v1 = 1, v2 =2, v3 =3，设备目前不支持 v3
        public ushort wServerPort; //snmp消息接收端口，默认 161
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byReadCommunity; //读共同体，最多31,默认"public"
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byWriteCommunity;//写共同体,最多31 字节,默认 "private"
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.DESC_LEN_64, ArraySubType = UnmanagedType.I1)]
        public byte[] byTrapHostIP; //自陷主机ip地址描述，支持IPV4 IPV6和域名描述    
        public ushort wTrapHostPort;   //trap主机端口
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byTrapName;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 70, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;    //保留
    }
}
