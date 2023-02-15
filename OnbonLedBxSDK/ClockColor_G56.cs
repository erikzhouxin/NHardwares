using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ClockColor_G56
    {
        public uint Color369; //369点颜色
        public uint ColorDot; //点颜色
        public uint ColorBG;  //表盘外圈颜色 模式没有圈泽此颜色无效
    }
}
