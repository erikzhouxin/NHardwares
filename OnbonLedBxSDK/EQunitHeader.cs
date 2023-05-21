using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQunitHeader
    {
        /// <summary>
        /// 
        /// </summary>
        public ushort UnitX;
        /// <summary>
        /// 
        /// </summary>
        public ushort UnitY;
        /// <summary>
        /// 
        /// </summary>
        public byte UnitType;
        /// <summary>
        /// 
        /// </summary>
        public byte Align;
        /// <summary>
        /// 
        /// </summary>
        public byte UnitColor;
        /// <summary>
        /// 
        /// </summary>
        public byte UnitMode;
    }
}
