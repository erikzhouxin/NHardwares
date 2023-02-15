using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct BattleTime
    {
        public short BattleRTCYear; //年
        public byte BattleRTCMonth;//月
        public byte BattleRTCDate;//日
        public byte BattleRTCHour;//时
        public byte BattleRTCMinute;//分
        public byte BattleRTCSecond;//秒
        public byte BattleRTCWeek;//星期
    }
}
