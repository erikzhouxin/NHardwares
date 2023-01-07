using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ATM_PACKAGE_TIME
    {
        public NET_DVR_PACKAGE_LOCATION location;
        public NET_DVRT_TIME_FORMAT struTimeForm;
        public NET_DVR_OSD_POSITION struOsdPosition;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
