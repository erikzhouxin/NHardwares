using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //IPSAN 文件目录查找
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPSAN_SERACH_PARAM
    {
        public NET_DVR_IPADDR struIP;     // IPSAN IP地址
        public ushort wPort;      // IPSAN  端口
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;  // 保留字节
    }
}
