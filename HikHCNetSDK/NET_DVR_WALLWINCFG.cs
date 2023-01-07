using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*窗口信息*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_WALLWINCFG
    {
        public uint dwSize;
        public byte byEnable;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwWinNum;//窗口号
        public uint dwLayerIndex;//窗口相对应的图层号
        public NET_DVR_RECTCFG struWinPosition;//目的窗口(相对显示墙)
        public uint dwDeviceIndex;//分布式大屏控制器设备序号
        public ushort wInputIndex;//输入信号源
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 14, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
