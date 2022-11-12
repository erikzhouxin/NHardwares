using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagstVehicleEventInfo
    * @brief 车辆比对报警信息
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEHICLE_EVENT_INFO_S
    {
        public UInt32 udwID;                                              /* 通知记录ID */
        public UInt32 udwTimestamp;                                       /* 通知上报时间，UTC格式，单位秒 */
        public UInt32 udwNotificationType;                                /* 通知类型 详见 NETDEV_NOTIFICATION_TYPE_E*/
        public UInt32 udwVehicleInfoNum;                                  /* 车辆信息数目 [0, 1] */
        public IntPtr pstVehicleRecordInfo;       /* 车辆信息列表(NETDEV_VEHICLE_RECORD_INFO_S[]) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                       /* 保留字段  Reserved */
    }

}
