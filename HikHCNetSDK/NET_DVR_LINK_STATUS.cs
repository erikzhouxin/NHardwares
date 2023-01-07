using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_LINK_STATUS
    {
        public uint dwSize;      // 结构体大小
        public ushort wLinkNum;    // 连接的数目
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;  // 保留字节
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_LINK_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_ONE_LINK[] struOneLink;   // 连接的客户端信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;  // 保留字节
    }
}
