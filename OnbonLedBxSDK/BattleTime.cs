using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 战斗时间
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct BattleTime
    {
        /// <summary>
        /// 年
        /// </summary>
        public short BattleRTCYear;
        /// <summary>
        /// 月
        /// </summary>
        public byte BattleRTCMonth;
        /// <summary>
        /// 日
        /// </summary>
        public byte BattleRTCDate;
        /// <summary>
        /// 时
        /// </summary>
        public byte BattleRTCHour;
        /// <summary>
        /// 分
        /// </summary>
        public byte BattleRTCMinute;
        /// <summary>
        /// 秒
        /// </summary>
        public byte BattleRTCSecond;
        /// <summary>
        /// 星期
        /// </summary>
        public byte BattleRTCWeek;
    }
}
