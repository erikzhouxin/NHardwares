using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct BxAreaFrmae_Dynamic_G6
    {
        /// <summary>
        /// 1 0x00 区域边框标志位;
        /// </summary>
        public byte AreaFFlag;
        /// <summary>
        /// 
        /// </summary>
        public EQscreenframeHeader_G6 oAreaFrame;
        /// <summary>
        /// 
        /// </summary>
        public byte[] pStrFramePathFile;
    };
}
