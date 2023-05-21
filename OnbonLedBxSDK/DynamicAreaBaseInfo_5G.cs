using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct DynamicAreaBaseInfo_5G
    {
        /// <summary>
        /// nType=1:文本； nType=2:图片；
        /// </summary>
        public byte nType;
        //PageStyle begin---------------
        /// <summary>
        /// 
        /// </summary>
        public byte DisplayMode;
        /// <summary>
        /// 
        /// </summary>
        public byte ClearMode;
        /// <summary>
        /// 
        /// </summary>
        public byte Speed;
        /// <summary>
        /// 
        /// </summary>
        public ushort StayTime;
        /// <summary>
        /// 
        /// </summary>
        public byte RepeatTime;
        //PageStyle End.
        //文本显示内容和字体格式 begin---------
        /// <summary>
        /// 
        /// </summary>
        public EQfontData oFont;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr fontName;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr strAreaTxtContent;
        //end.
        /// <summary>
        /// 图片路径
        /// </summary>
        public IntPtr filePath;
    }
}
