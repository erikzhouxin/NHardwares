using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQdynamicHeader
    {
        /// <summary>
        /// 
        /// </summary>
        public byte RunMode;
        /// <summary>
        /// 
        /// </summary>
        ushort Timeout;
        /// <summary>
        /// 
        /// </summary>
        public byte ImmePlay;
        /// <summary>
        /// 
        /// </summary>
        public byte AreaType;
        /// <summary>
        /// 
        /// </summary>
        public ushort AreaX;
        /// <summary>
        /// 
        /// </summary>
        public ushort AreaY;
        /// <summary>
        /// 
        /// </summary>
        public ushort AreaWidth;
        /// <summary>
        /// 
        /// </summary>
        public ushort AreaHeight;
    }
}
