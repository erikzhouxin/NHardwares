using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagstNETDEVVehicleRcordInfo
    * @brief 车辆识别记录信息
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEHICLE_RECORD_INFO_S
    {
        public UInt32 udwRecordID;                                       /* 车辆识别记录ID */
        public UInt32 udwChannelID;                                      /* 通道ID，抓拍推送时有效 */
        public UInt32 udwPassingTime;                                    /* 过车时间，UTC格式，单位秒*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szChannelName;                     /* 卡口相机名称 */
        public NETDEV_PLATE_ATTR_INFO_S stPlateAttr;                    /* 车牌抓拍信息 */
        public NETDEV_VEH_ATTR_S stVehAttr;                      /* 车辆抓拍信息 */
        public NETDEV_FILE_INFO_S stPlateImage;                   /* 车牌抓拍图片 图片加密后大小不超过1M*/
        public NETDEV_FILE_INFO_S stVehicleImage;                 /* 车辆抓拍图片 结构化查询时携带 图片加密后大小不超过1M*/
        public NETDEV_FILE_INFO_S stPanoImage;                    /* 全景图 结构化查询时携带 仅携带图片URL和size，图片数据需要通过/LAPI/V1.0/System/Picture接口获取*/
        public NETDEV_MONITOR_ALARM_INFO_S stMonitorAlarmInfo;             /* 车牌告警布控信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)]
        public byte[] byRes;              /* 保留字段  Reserved */
    }

}
