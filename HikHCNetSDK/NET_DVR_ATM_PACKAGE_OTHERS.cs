using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ATM_PACKAGE_OTHERS
    {
        public NET_DVR_PACKAGE_LOCATION struPackageLocation;
        public NET_DVR_PACKAGE_LENGTH struPackageLength;
        public NET_DVR_OSD_POSITION struOsdPosition;
        public NET_DVR_FRAMETYPECODE struPreCode;/*叠加字符前的字符*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] res;
    }
}
