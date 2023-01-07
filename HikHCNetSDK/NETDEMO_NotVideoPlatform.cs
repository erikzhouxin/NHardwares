using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NotVideoPlatform
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 160, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
