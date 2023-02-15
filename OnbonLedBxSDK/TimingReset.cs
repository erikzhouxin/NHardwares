using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TimingReset
    {
        public byte rstMode; //复位模式 0x00 –取消定时复位功能 0x01 –周期复位， 此时 RstInterval 字段有效 0x02 –只在指定时间复位
        public uint RstInterval;//复位周期， 单位： 分钟如此字段为 0， 不进行复位操作
        public byte rstHour1; //小时 0Xff–表示此组无效， 下同
        public byte rstMin1;
        public byte rstHour2;
        public byte rstMin2;
        public byte rstHour3;
        public byte rstMin3;
    }
}
