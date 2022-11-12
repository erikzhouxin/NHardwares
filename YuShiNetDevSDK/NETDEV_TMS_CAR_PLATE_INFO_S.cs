using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TMS_CAR_PLATE_INFO_S
    {
        public Int32 udwPicNum;                                           /* 图片个数 Picture Number */
        public NETDEV_TMS_CAR_PLATE_XML_INFO_S stTmsXmlInfo;                                /* XML信息 XML Information */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_TMS_PIC_COMMON_NUM)]
        public NETDEV_TMS_CAR_PLATE_PIC_INFO_S[] stTmsPicInfo;      /* 图片信息 Picture Message */
    };

}
