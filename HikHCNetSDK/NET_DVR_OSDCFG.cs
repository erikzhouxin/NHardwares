using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_OSDCFG
    {
        public uint dwSize;
        public byte byValid;    /*是否有效 0无效 1有效*/
        public byte byDispMode;  //显示模式，1-透明，2-半透明，3-覆盖三种模式
        public byte byFontColorY; /*字体颜色Y,0-255*/
        public byte byFontColorU; /*字体颜色U,0-255*/
        public byte byFontColorV; /*字体颜色V,0-255*/
        public byte byBackColorY; /*背景颜色Y,0-255*/
        public byte byBackColorU; /*背景颜色U,0-255*/
        public byte byBackColorV; /*背景颜色V,0-255*/
        public ushort wXCoordinate;   /*OSD在屏幕左上角位置x*/
        public ushort wYCoordinate;   /*OSD在屏幕左上角位置y*/
        public ushort wWidth;       /*OSD宽度*/
        public ushort wHeight;      /*OSD高度*/
        public uint dwCharCnt;     /*字符的个数*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_OSDCHAR_NUM, ArraySubType = UnmanagedType.U2)]
        public ushort[] wOSDChar;       /*OSD字符内容*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
