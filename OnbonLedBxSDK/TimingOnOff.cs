using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TimingOnOff
    {
        public byte onHour;   // 开机小时
        public byte onMinute; // 开机分钟
        public byte offHour;  // 关机小时
        public byte offMinute; // 关机分钟
    }
}
