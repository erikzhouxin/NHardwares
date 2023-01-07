using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct UNION_REGION
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 164, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
