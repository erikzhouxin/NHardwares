using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQareaHeader
    {
        /*
         字库区域:0x01
         透明文本：0x06

         时间区:0x02

         图文字幕:0x00

         战斗时间：0x09
         噪声区：0x05
         温度区：0x03
         霓虹区：0x08
         湿度区：0x04
         */
        public byte AreaType; //区域类型

        public ushort AreaX; //区域X坐标
        public ushort AreaY; //区域Y坐标
        public ushort AreaWidth; //区域宽
        public ushort AreaHeight;//区域高
    }
}
