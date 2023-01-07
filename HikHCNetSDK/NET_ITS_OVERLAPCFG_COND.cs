using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //字符叠加配置条件参数结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_ITS_OVERLAPCFG_COND
    {
        public uint dwSize;
        public uint dwChannel;//通道号 
        public uint dwConfigMode;//配置模式：0- 终端，1- 前端(直连前端或终端接前端)
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留
    }
}
