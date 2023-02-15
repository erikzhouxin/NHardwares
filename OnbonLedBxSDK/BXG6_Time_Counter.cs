using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct BXG6_Time_Counter
    {
        public byte UnitColor;  //长度为1或4；有灰度时是4； 颜色属性；
        public byte UnitMode;    //1 0x00 计时模式：0x00 –正计时累加 0x01 –倒计时累加 0x02 –正计时不累加 0x03 –倒计时不累加
        public ushort DestYear;   //2 目标年
        public byte DestMonth;   //1 目标月
        public byte DestDate;    //1 目标日
        public byte DestHour;    //1 目标时
        public byte DestMinute;  //1 目标分
        public byte DestSecond;  //1 目标秒
        public byte TimerFormat; //1 Bit0–天， 1 表示显示， 0表示不显示； Bit1–时； Bit2–分； Bit3–秒； Bit4–天单位，1表示显示，0不显示；Bit5–时 Bit6–分 Bit7–秒
        public byte DayLen;      //1 0x00 单元长度 0x00 –长度由控制器自动计算其它–固定长度
        public byte HourLen;     //1 0x00 同上
        public byte MinuteLen;   //1 0x00 同上
        public byte SecondLen;   //1 0x00 同上
                                 //Ouint32 Dataoffset;	//4 在数据文件中的偏移量，下面的字模数据放入数据文件中
                                 //Ouint32 DataLen;	//4 该字模数据长度
                                 //Ouint8* FontData;	//N 字模数据，具体的字模格式，请参考附录 1字模个数为 14，其顺序依次为： 0, …, 9, 天，时，分，秒
    };
}
