using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 亮度
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct Brightness
    {
        /// <summary>
        /// 0x00 –手动调亮
        /// 0x01 –定时调亮 注:以下的亮度值表，在定时调亮和手 动调亮时控制器才需处理。但在协议上 不论什么模式，此表都需要发送给控制器
        /// 0x00 –手动调亮
        /// 0x01 –定时调亮 注:以下的亮度值表，在定时调亮和手 动调亮时控制器才需处理。但在协议上 不论什么模式，此表都需要发送给控制器
        /// </summary>
        public byte BrightnessMode;
        /// <summary>
        /// 00:00 – 00:29 的亮度值， 0x00 – 0x0f
        /// </summary>
        public byte HalfHourValue0;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue1;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue2;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue3;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue4;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue5;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue6;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue7;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue8;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue9;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue10;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue11;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue12;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue13;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue14;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue15;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue16;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue17;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue18;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue19;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue20;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue21;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue22;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue23;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue24;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue25;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue26;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue27;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue28;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue29;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue30;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue31;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue32;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue33;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue34;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue35;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue36;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue37;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue38;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue39;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue40;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue41;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue42;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue43;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue44;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue45;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue46;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue47;
    }
}
