using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct BxAreaFrmae_Dynamic_G6
    {

        public byte AreaFFlag;       // 1 0x00 区域边框标志位;
        public EQscreenframeHeader_G6 oAreaFrame;
        public byte[] pStrFramePathFile;
    };
}
