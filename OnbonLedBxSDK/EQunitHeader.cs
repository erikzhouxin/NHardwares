using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQunitHeader
    {
        ushort UnitX;
        ushort UnitY;
        public byte UnitType;
        public byte Align;
        public byte UnitColor;
        public byte UnitMode;
    }
}
