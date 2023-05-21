using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct BXG6_Time_Counter
    {
        /// <summary>
        /// 长度为1或4；有灰度时是4； 颜色属性；
        /// </summary>
        public byte UnitColor;
        /// <summary>
        /// 1 0x00 计时模式：0x00 –正计时累加 0x01 –倒计时累加 0x02 –正计时不累加 0x03 –倒计时不累加
        /// </summary>
        public byte UnitMode;
        /// <summary>
        /// 2 目标年
        /// </summary>
        public ushort DestYear;
        /// <summary>
        /// 1 目标月
        /// </summary>
        public byte DestMonth;
        /// <summary>
        /// 1 目标日
        /// </summary>
        public byte DestDate;
        /// <summary>
        /// 1 目标时
        /// </summary>
        public byte DestHour;
        /// <summary>
        /// 1 目标分
        /// </summary>
        public byte DestMinute;
        /// <summary>
        /// 1 目标秒
        /// </summary>
        public byte DestSecond;
        /// <summary>
        /// 1 Bit0–天， 1 表示显示， 0表示不显示； Bit1–时； Bit2–分； Bit3–秒； Bit4–天单位，1表示显示，0不显示；Bit5–时 Bit6–分 Bit7–秒
        /// </summary>
        public byte TimerFormat;
        /// <summary>
        /// 1 0x00 单元长度 0x00 –长度由控制器自动计算其它–固定长度
        /// </summary>
        public byte DayLen;
        /// <summary>
        /// 1 0x00 同上
        /// </summary>
        public byte HourLen;
        /// <summary>
        /// 1 0x00 同上
        /// </summary>
        public byte MinuteLen;
        /// <summary>
        /// 1 0x00 同上
        /// </summary>
        public byte SecondLen;
        //Ouint32 Dataoffset;	//4 在数据文件中的偏移量，下面的字模数据放入数据文件中
        //Ouint32 DataLen;	//4 该字模数据长度
        //Ouint8* FontData;	//N 字模数据，具体的字模格式，请参考附录 1字模个数为 14，其顺序依次为： 0, …, 9, 天，时，分，秒
    }
}
