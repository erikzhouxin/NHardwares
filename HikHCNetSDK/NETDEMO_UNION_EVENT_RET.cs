using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayout(LayoutKind.Explicit)]
    public struct UNION_EVENT_RET
    {
        [FieldOffset(0)]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 800, ArraySubType = UnmanagedType.I1)]
        public byte[] byLen;
    }
}
