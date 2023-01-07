using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct UNION_NOTVIDEOPLATFORM_V40
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 160, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
