using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TimingOnOff
    {
        /// <summary>
        /// 开机小时
        /// </summary>
        public byte onHour;
        /// <summary>
        /// 开机分钟
        /// </summary>
        public byte onMinute;
        /// <summary>
        /// 关机小时
        /// </summary>
        public byte offHour;
        /// <summary>
        /// 关机分钟
        /// </summary>
        public byte offMinute;
    }
}
