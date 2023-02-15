using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQAnalogClockHeader_G56
    {
        public ushort OrignPointX;    //原点横坐标
        public ushort OrignPointY;    //原点纵坐标
        public byte UnitMode;       //表针模式
        public byte HourHandWidth;  //时针宽度
        public byte HourHandLen;    //时针长度
        public uint HourHandColor;  //时针颜色
        public byte MinHandWidth;   //分针宽度
        public byte MinHandLen;     //分针长度
        public uint MinHandColor;   //分针颜色
        public byte SecHandWidth;   //秒针宽度
        public byte SecHandLen;     //秒针长度
        public uint SecHandColor;   //秒针颜色
    }
}
