using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct GetPageData
    {
        /// <summary>
        /// 
        /// </summary>
        public ushort allPageNub;
        /// <summary>
        /// 
        /// </summary>
        public uint pageLen;
        /// <summary>
        /// 
        /// </summary>
        public byte[] fileAddre;
    }
}
