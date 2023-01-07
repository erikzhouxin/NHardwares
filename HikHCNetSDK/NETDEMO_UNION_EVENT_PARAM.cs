using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayout(LayoutKind.Explicit)]
    public struct UNION_EVENT_PARAM
    {
        [FieldOffset(0)]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.SEARCH_EVENT_INFO_LEN_V40, ArraySubType = UnmanagedType.I1)]
        public byte[] byLen;
        public void Init()
        {
            byLen = new byte[HikHCNetSdk.SEARCH_EVENT_INFO_LEN_V40];
        }
    }
}
