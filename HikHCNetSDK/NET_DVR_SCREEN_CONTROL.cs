using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SCREEN_CONTROL
    {
        public uint dwSize;
        public uint dwCommand;      /* 控制方法 1-开 2-关 3-屏幕输入源选择 4-显示单元颜色控制 5-显示单元位置控制*/
        public byte byProtocol;      //串口协议类型,1:LCD-S1,2:LCD-S2
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_SCREEN_CONTROL_PARAM struControlParam;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 52, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
