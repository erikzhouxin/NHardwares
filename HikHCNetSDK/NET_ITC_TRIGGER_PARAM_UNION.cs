using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_ITC_TRIGGER_PARAM_UNION
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4280, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
