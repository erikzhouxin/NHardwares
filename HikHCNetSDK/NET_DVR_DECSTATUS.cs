using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DECSTATUS
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DECNUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_DECCHANSTATUS[] struTransPortInfo;
    }
}
