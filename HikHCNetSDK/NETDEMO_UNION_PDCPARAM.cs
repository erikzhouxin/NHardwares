using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct UNION_PDCPARAM
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 140, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }


}
