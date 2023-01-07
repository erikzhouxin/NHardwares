using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_THERMOMETRY_COND
    {
        public uint dwSize;
        public uint dwChannel;
        public ushort wPresetNo;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 62, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
