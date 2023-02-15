using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 时间分区战斗时间
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQTimeAreaBattle_G6
    {
        public ushort BattleStartYear;     //起始年份（BCD格式，下同）
        public byte BattleStartMonth;    //起始月份
        public byte BattleStartDate;     //起始日期
        public byte BattleStartHour;     //起始小时
        public byte BattleStartMinute;   //起始分钟
        public byte BattleStartSecond;   //起始秒钟
        public byte BattleStartWeek;     //起始星期值
        public byte StartUpMode;         //启动模式
    } 
}
