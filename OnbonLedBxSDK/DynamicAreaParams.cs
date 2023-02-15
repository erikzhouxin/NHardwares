using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct DynamicAreaParams
    {
        public byte uAreaId;
        public EQareaHeader_G6 oAreaHeader_G6;
        public EQpageHeader_G6 stPageHeader;
        public IntPtr fontName;
        public IntPtr strAreaTxtContent;
    }
}
