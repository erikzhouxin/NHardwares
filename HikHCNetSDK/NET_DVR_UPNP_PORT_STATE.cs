using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //Upnp端口映射状态结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_UPNP_PORT_STATE
    {
        public uint dwEnabled;//该端口是否被使能映射
        public ushort wInternalPort;//映射前的端口
        public ushort wExternalPort;//映射后的端口
        public uint dwStatus;//端口映射状态：0- 未生效；1- 未生效：映射源端口与目的端口需一致；2- 未生效：映射端口号已被使用；3- 生效
        public NET_DVR_IPADDR struNatExternalIp;//映射后的外部地址
        public NET_DVR_IPADDR struNatInternalIp;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留
    }
}
