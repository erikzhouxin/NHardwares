using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ONE_LINK
    {
        public NET_DVR_IPADDR struIP;     // 客户端IP
        public int lChannel;   // 通道号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;  // 保留字节
    }
}
