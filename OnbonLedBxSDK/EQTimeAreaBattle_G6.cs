using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 时间分区战斗时间
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQTimeAreaBattle_G6
    {
        /// <summary>
        /// 起始年份（BCD格式，下同）
        /// </summary>
        public ushort BattleStartYear;
        /// <summary>
        /// 起始月份
        /// </summary>
        public byte BattleStartMonth;
        /// <summary>
        /// 起始日期
        /// </summary>
        public byte BattleStartDate;
        /// <summary>
        /// 起始小时
        /// </summary>
        public byte BattleStartHour;
        /// <summary>
        /// 起始分钟
        /// </summary>
        public byte BattleStartMinute;
        /// <summary>
        /// 起始秒钟
        /// </summary>
        public byte BattleStartSecond;
        /// <summary>
        /// 起始星期值
        /// </summary>
        public byte BattleStartWeek;
        /// <summary>
        /// 启动模式
        /// </summary>
        public byte StartUpMode;
    }
}
