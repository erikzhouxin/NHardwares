using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct Brightness
    {
        /*
         0x00 –手动调亮
         0x01 –定时调亮 注:以下的亮度值表，在定时调亮和手 动调亮时控制器才需处理。但在协议上 不论什么模式，此表都需要发送给控制 器
         0x00 –手动调亮
         0x01 –定时调亮 注:以下的亮度值表，在定时调亮和手 动调亮时控制器才需处理。但在协议上 不论什么模式，此表都需要发送给控制 器
         */
        public byte BrightnessMode;

        //00:00 – 00:29 的亮度值， 0x00 – 0x0f
        public byte HalfHourValue0;
        public byte HalfHourValue1;
        public byte HalfHourValue2;
        public byte HalfHourValue3;
        public byte HalfHourValue4;
        public byte HalfHourValue5;
        public byte HalfHourValue6;
        public byte HalfHourValue7;
        public byte HalfHourValue8;
        public byte HalfHourValue9;
        public byte HalfHourValue10;
        public byte HalfHourValue11;
        public byte HalfHourValue12;
        public byte HalfHourValue13;
        public byte HalfHourValue14;
        public byte HalfHourValue15;
        public byte HalfHourValue16;
        public byte HalfHourValue17;
        public byte HalfHourValue18;
        public byte HalfHourValue19;
        public byte HalfHourValue20;
        public byte HalfHourValue21;
        public byte HalfHourValue22;
        public byte HalfHourValue23;
        public byte HalfHourValue24;
        public byte HalfHourValue25;
        public byte HalfHourValue26;
        public byte HalfHourValue27;
        public byte HalfHourValue28;
        public byte HalfHourValue29;
        public byte HalfHourValue30;
        public byte HalfHourValue31;
        public byte HalfHourValue32;
        public byte HalfHourValue33;
        public byte HalfHourValue34;
        public byte HalfHourValue35;
        public byte HalfHourValue36;
        public byte HalfHourValue37;
        public byte HalfHourValue38;
        public byte HalfHourValue39;
        public byte HalfHourValue40;
        public byte HalfHourValue41;
        public byte HalfHourValue42;
        public byte HalfHourValue43;
        public byte HalfHourValue44;
        public byte HalfHourValue45;
        public byte HalfHourValue46;
        public byte HalfHourValue47;
    }
}
