using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SYNCHRONOUS_IPC
    {
        public uint dwSize;    //结构体大小
        public byte byEnable;  //是否启用：为前端IPC同步设备参数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;  //保留
    }
}
