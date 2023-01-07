using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //snmpv30
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SNMPCFG_V30
    {
        public uint dwSize;         //结构长度
        public byte byEnableV1;     //0-禁用SNMP V1，1-表示启用SNMP V1
        public byte byEnableV2;     //0-禁用SNMP V2，1-表示启用SNMP V2
        public byte byEnableV3;     //0-禁用SNMP V3，1-表示启用SNMP V3
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public ushort wServerPort;                  //snmp消息接收端口，默认 161
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byReadCommunity;      //读共同体，最多31,默认"public"
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byWriteCommunity;     //写共同体,最多31 字节,默认 "private"
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.DESC_LEN_64, ArraySubType = UnmanagedType.I1)]
        public byte[] byTrapHostIP;     //自陷主机ip地址描述，支持IPV4 IPV6和域名描述    
        public ushort wTrapHostPort;                    // trap主机端口
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        public NET_DVR_SNMPv3_USER struRWUser;    // 读写用户
        public NET_DVR_SNMPv3_USER struROUser;    // 只读用户
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byTrapName;
    }
}
