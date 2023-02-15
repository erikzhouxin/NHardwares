using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQscreenframeHeader_G6
    {
        public byte FrameDispStype;    //边框显示方式
        public byte FrameDispSpeed;    //边框显示速度
        public byte FrameMoveStep;     //边框移动步长
        public byte FrameUnitLength;   //边框组元长度
        public byte FrameUnitWidth;    //边框组元宽度
        public byte FrameDirectDispBit;//上下左右边框显示标志位，目前只支持6QX-M卡    
    }
}
