using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_ITC_VIDEO_TRIGGER_PARAM_UNION
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 1150, ArraySubType = UnmanagedType.U4)]
        public uint[] uLen;
    }

}
