using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TMS_CAR_PLATE_XML_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_TMS_CAR_PLATE_CAMID_LEN)]
        public byte[] szCamID;                                          /* 卡口相机编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_TMS_CAR_PLATE_RECORDID_LEN)]
        public byte[] szRecordID;                                       /* 记录ID号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_TMS_CAR_PLATE_TOLLGATE_LEN)]
        public byte[] szTollgateID;                                     /* 卡口编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_TMS_CAR_PLATE_PASSTIME_LEN)]
        public byte[] szPassTime;                                       /* 经过时刻 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_TMS_CAR_PLATE_LANEID_LEN)]
        public byte[] szLaneID;                                         /* 经过时刻 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_TMS_CAR_PLATE_CARPLATE_LEN)]
        public byte[] szCarPlate;                                       /* 车牌号码 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_IPV4_LEN_MAX)]
        public byte[] szIPAddr;                                         /* 设备IP */
        public Int32 dwCarPlateColor;                                   /* 号牌颜色，参见枚举NETDEV_TMS_CAR_PLATE_COLOR_E*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 492)]
        public byte[] byRes;                                            /*   Reserved field*/
    };

}
