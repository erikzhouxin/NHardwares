using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIX_ABILITY_V41
    {
        public uint dwSize;
        public byte byDspNums;//DSP个数  
        public byte byDecChanNums;//解码通道数
        public byte byStartChan;//起始解码通道
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;

        public NET_DVR_DISPINFO struVgaInfo;//VGA显示通道信息
        public NET_DVR_DISPINFO struBncInfo;//BNC显示通道信息
        public NET_DVR_DISPINFO struHdmiInfo;//HDMI显示通道信息
        public NET_DVR_DISPINFO struDviInfo;//DVI显示通道信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DISPNUM_V41, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_DISPWINDOWMODE[] struDispMode;
        public NET_DVR_SCREENINFO struBigScreenInfo;
        public byte bySupportAutoReboot; //是否支持自动重启，0-不支持，1-支持
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 119, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
