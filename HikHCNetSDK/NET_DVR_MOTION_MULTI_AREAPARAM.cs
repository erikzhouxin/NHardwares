using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_MOTION_MULTI_AREAPARAM
    {
        public byte byAreaNo;//区域编号(IPC- 1~8)
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public NET_VCA_RECT struRect;//单个区域的坐标信息(矩形) size = 16;
        public NET_DVR_DNMODE struDayNightDisable;//关闭模式
        public NET_DVR_DNMODE struDayModeParam;//白天模式
        public NET_DVR_DNMODE struNightModeParam;//夜晚模式
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
    }
}
