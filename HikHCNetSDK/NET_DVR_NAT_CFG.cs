using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //端口映射配置结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_NAT_CFG
    {
        public uint dwSize;
        public ushort wEnableUpnp;
        public ushort wEnableNat;
        public NET_DVR_IPADDR struIpAddr;//夏时制停止时间
        public NET_DVR_NAT_PORT struHttpPort;//夏时制停止时间
        public NET_DVR_NAT_PORT struCmdPort;//夏时制停止时间
        public NET_DVR_NAT_PORT struRtspPort;//夏时制停止时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byFriendName;
        public byte byNatType;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_NAT_PORT struHttpsPort;//夏时制停止时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 76, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
