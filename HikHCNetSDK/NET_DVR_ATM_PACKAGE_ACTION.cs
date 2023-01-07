using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ATM_PACKAGE_ACTION
    {
        public NET_DVR_PACKAGE_LOCATION struPackageLocation;
        public NET_DVR_OSD_POSITION struOsdPosition;
        public NET_DVR_FRAMETYPECODE struActionCode;/*交易类型等对应的码*/
        public NET_DVR_FRAMETYPECODE struPreCode;/*叠加字符前的字符*/
        public byte byActionCodeMode;/*交易类型等对应的码0,ASCII;1,HEX*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
