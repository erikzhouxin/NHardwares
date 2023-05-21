using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct DynamicAreaParams
    {
        /// <summary>
        /// 
        /// </summary>
        public byte uAreaId;
        /// <summary>
        /// 
        /// </summary>
        public EQareaHeader_G6 oAreaHeader_G6;
        /// <summary>
        /// 
        /// </summary>
        public EQpageHeader_G6 stPageHeader;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr fontName;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr strAreaTxtContent;
    }
}
