using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQareaframeHeader
    {
        public byte AreaFFlag;
        public byte AreaFDispStyle;
        public byte AreaFDispSpeed;
        public byte AreaFMoveStep;
        public byte AreaFWidth;
        public ushort AreaFBackup;
    }
}
