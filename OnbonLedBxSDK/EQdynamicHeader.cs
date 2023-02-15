using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQdynamicHeader
    {
        public byte RunMode;
        ushort Timeout;
        public byte ImmePlay;
        public byte AreaType;
        ushort AreaX;
        ushort AreaY;
        ushort AreaWidth;
        ushort AreaHeight;
    }
}
