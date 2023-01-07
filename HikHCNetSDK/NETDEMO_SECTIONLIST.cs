using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct SECTIONLIST
    {
        public BLOCKTIME startTime;
        public BLOCKTIME stopTime;
        public byte byRecType;
        public IntPtr pNext;
    }
}
