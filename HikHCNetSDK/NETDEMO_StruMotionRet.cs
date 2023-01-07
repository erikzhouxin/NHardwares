using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct struMotionRet
    {
        public uint dwMotDetNo;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 796, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
