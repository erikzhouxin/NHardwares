using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //通道工作模式参数结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CHANNEL_WORKMODE
    {
        public uint dwSize;        //结构体大小
        public byte byWorkMode;    //工作模式，参见CHAN_WORKMODE_ENUM
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 63, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;     //保留
    }
}
