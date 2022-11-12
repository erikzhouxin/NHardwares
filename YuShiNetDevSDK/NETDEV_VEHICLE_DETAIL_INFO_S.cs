using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagstNETDEVVehicleDetailInfo
    * @brief 车辆成员信息
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEHICLE_DETAIL_INFO_S
    {
        public UInt32 udwReqSeq;                         /* 请求数据序列号 */
        public UInt32 udwMemberID;                       /* 人脸成员ID */
        public NETDEV_PLATE_ATTR_INFO_S stPlateAttr;                       /* 车牌信息 */
        public NETDEV_VEHICLE_MEMBER_ATTR_S stVehicleAttr;                     /* 车辆信息 */
        public Int32 bIsMonitored;                      /* 是否已布控 0未布控 1已布控 */
        public UInt32 udwDBNum;                          /* 所属车辆库数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public UInt32[] audwDBIDList;       /* 所属车辆库ID数组 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;              /* 保留字段  Reserved */
    }

}
