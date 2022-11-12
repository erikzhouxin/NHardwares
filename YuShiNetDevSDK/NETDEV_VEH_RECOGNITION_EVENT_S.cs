using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagstNETDEVVehRecognitionEvent
    * @brief 车辆识别事件
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEH_RECOGNITION_EVENT_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_480)]
        public byte[] szReference;                        /* 订阅者描述信息 */
        public UInt32 udwSrcID;                                           /* 告警源ID */
        public NETDEV_VEHICLE_EVENT_INFO_S stVehicleEventInfo;            /* 车辆比对报警信息 需动态申请内存 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                       /* 保留字段  Reserved */
    }

}
