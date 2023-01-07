using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct NET_DVR_VIDEO_INTERCOM_EVENT_INFO_UINON
    {
        [FieldOffsetAttribute(0)]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 256, ArraySubType = UnmanagedType.I1)]
        public byte[] byLen;
    }
}
