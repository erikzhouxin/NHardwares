using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQscreenframeHeader
    {
        public byte FrameDispFlag;
        public byte FrameDispStyle;
        public byte FrameDispSpeed;
        public byte FrameMoveStep;
        public byte FrameWidth;
        public ushort FrameBackup;
    }
}
