using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayout(LayoutKind.Explicit)]
    public struct NET_DVR_GET_STREAM_UNION
    {
        [FieldOffset(0)]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 492, ArraySubType = UnmanagedType.I1)]
        public byte[] byUnion;
        public void Init()
        {
            byUnion = new byte[492];
        }
    }

}
