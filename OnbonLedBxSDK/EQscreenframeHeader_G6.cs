using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 6代屏幕边框帧头
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQscreenframeHeader_G6
    {
        /// <summary>
        /// 边框显示方式
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
