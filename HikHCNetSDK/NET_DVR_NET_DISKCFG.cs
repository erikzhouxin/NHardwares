using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_NET_DISKCFG
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_NET_DISK, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SINGLE_NET_DISK_INFO[] struNetDiskParam;
    }

}
