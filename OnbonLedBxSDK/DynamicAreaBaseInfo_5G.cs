using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct DynamicAreaBaseInfo_5G
    {
        public byte nType; // nType=1:文本； nType=2:图片；
                           //PageStyle begin---------------
        public byte DisplayMode;
        public byte ClearMode;
        public byte Speed;
        public ushort StayTime;
        public byte RepeatTime;
        //PageStyle End.
        //文本显示内容和字体格式 begin---------
        public EQfontData oFont;
        public IntPtr fontName;
        public IntPtr strAreaTxtContent;
        //end.
        //图片路径 begin---------
        public IntPtr filePath;
        //end.
    }
}
