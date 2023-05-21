using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 表盘颜色
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ClockColor_G56
    {
        /// <summary>
        /// 369点颜色
        /// </summary>
        public uint Color369;
        /// <summary>
        /// 点颜色
        /// </summary>
        public uint ColorDot;
        /// <summary>
        /// 表盘外圈颜色 模式没有圈泽此颜色无效
        /// </summary>
        public uint ColorBG;
    }
}
