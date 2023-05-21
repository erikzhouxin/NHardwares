using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TimingReset
    {
        /// <summary>
        /// 复位模式 0x00 –取消定时复位功能 0x01 –周期复位， 此时 RstInterval 字段有效 0x02 –只在指定时间复位
        /// </summary>
        public byte rstMode;
        /// <summary>
        /// 复位周期， 单位： 分钟如此字段为 0， 不进行复位操作
        /// </summary>
        public uint RstInterval;
        /// <summary>
        /// 小时 0Xff–表示此组无效， 下同
        /// </summary>
        public byte rstHour1;
        /// <summary>
        /// 
        /// </summary>
        public byte rstMin1; 
        /// <summary>
        /// 
        /// </summary>
        public byte rstHour2;
        /// <summary>
        /// 
        /// </summary>
        public byte rstMin2; 
        /// <summary>
        /// 
        /// </summary>
        public byte rstHour3;
        /// <summary>
        /// 
        /// </summary>
        public byte rstMin3;
    }
}
