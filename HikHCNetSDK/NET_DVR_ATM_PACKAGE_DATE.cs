using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ATM_PACKAGE_DATE
    {
        public NET_DVR_PACKAGE_LOCATION struPackageLocation;
        public NET_DVR_DATE_FORMAT struDateForm;
        public NET_DVR_OSD_POSITION struOsdPosition;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] res;
    }
}
