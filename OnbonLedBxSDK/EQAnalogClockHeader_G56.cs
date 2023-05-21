using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQAnalogClockHeader_G56
    {
        /// <summary>
        /// 原点横坐标
        /// </summary>
        public ushort OrignPointX;
        /// <summary>
        /// 原点纵坐标
        /// </summary>
        public ushort OrignPointY;
        /// <summary>
        /// 表针模式
        /// </summary>
        public byte UnitMode;
        /// <summary>
        /// 时针宽度
        /// </summary>
        public byte HourHandWidth;
        /// <summary>
        /// 时针长度
        /// </summary>
        public byte HourHandLen;
        /// <summary>
        /// 时针颜色
        /// </summary>
        public uint HourHandColor;
        /// <summary>
        /// 分针宽度
        /// </summary>
        public byte MinHandWidth;
        /// <summary>
        /// 分针长度
        /// </summary>
        public byte MinHandLen;
        /// <summary>
        /// 分针颜色
        /// </summary>
        public uint MinHandColor;
        /// <summary>
        /// 秒针宽度
        /// </summary>
        public byte SecHandWidth;
        /// <summary>
        /// 秒针长度
        /// </summary>
        public byte SecHandLen;
        /// <summary>
        /// 秒针颜色
        /// </summary>
        public uint SecHandColor;
    }
}
