using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIX_LOOP_DECINFO_V30
    {
        public uint dwSize;
        public uint dwPoolTime;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CYCLE_CHAN_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_MATRIX_CHAN_INFO_V30[] struchanConInfo;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
