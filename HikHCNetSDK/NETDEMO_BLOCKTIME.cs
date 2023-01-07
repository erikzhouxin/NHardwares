using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct BLOCKTIME
    {
        public ushort wYear;
        public byte bMonth;
        public byte bDay;
        public byte bHour;
        public byte bMinute;
        public byte bSecond;
    }
}
