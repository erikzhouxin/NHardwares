using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ISCSI_CFG
    {
        public uint dwSize;                   // 结构大小
        public ushort wVrmPort;                  // VRM 监听端口
        public byte byEnable;                  // 是否启用 ISCSI存储
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 69, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;                 // 保留字节
        public NET_DVR_IPADDR struVrmAddr;          // VRM ip地址 16位
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string chNvtIndexCode;        //nvt index Code 
    }
}
