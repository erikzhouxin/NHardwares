using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQscreenframeHeader
    {
        /// <summary>
        /// 
        /// </summary>
        public byte FrameDispFlag;
        /// <summary>
        /// 
        /// </summary>
        public byte FrameDispStyle;
        /// <summary>
        /// 
        /// </summary>
        public byte FrameDispSpeed;
        /// <summary>
        /// 
        /// </summary>
        public byte FrameMoveStep;
        /// <summary>
        /// 
        /// </summary>
        public byte FrameWidth;
        /// <summary>
        /// 
        /// </summary>
        public ushort FrameBackup;
    }
    /// <summary>
    /// 6代屏幕边框帧头
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQscreenframeHeader_G6
    {
        /// <summary>
        /// 边框显示方式
        /// 0x00 –闪烁 
        /// 0x01 –顺时针转动 
        /// 0x02 –逆时针转动 
        /// 0x03 –闪烁加顺时针转动 
        /// 0x04 –闪烁加逆时针转动 
        /// 0x05 –红绿交替闪烁 
        /// 0x06 –红绿交替转动 
        /// 0x07 –静止打出
        /// </summary>
        public byte FrameDispStype;
        /// <summary>
        /// 边框显示速度
        /// </summary>
        public byte FrameDispSpeed;
        /// <summary>
        /// 边框移动步长
        /// </summary>
        public byte FrameMoveStep;
        /// <summary>
        /// 边框组元长度
        /// </summary>
        public byte FrameUnitLength;
        /// <summary>
        /// 边框组元宽度
        /// </summary>
        public byte FrameUnitWidth;
        /// <summary>
        /// 上下左右边框显示标志位，目前只支持6QX-M卡
        /// </summary>
        public byte FrameDirectDispBit;
    }
}
