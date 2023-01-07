using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_ITC_LIGHT_ACCESSPARAM_UNION
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 122, ArraySubType = UnmanagedType.U4)]
        public uint[] uLen;
    }

}
