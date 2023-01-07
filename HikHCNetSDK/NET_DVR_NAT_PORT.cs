using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //端口映射配置结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_NAT_PORT
    {
        public ushort wEnable;
        public ushort wExtPort;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
