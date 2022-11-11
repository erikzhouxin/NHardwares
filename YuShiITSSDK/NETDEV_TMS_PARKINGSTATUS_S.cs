using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct NETDEV_TMS_PARKINGSTATUS_S
    * @brief  车位状态信息（NEW）（车辆驶入驶离车位时状态信息）
    * @attention
    */
    public struct NETDEV_TMS_PARKINGSTATUS_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_32)]
        public byte[] szCamID;                                           /* 相机编码 Device ID: unified ID of collection device or checkpoint camera ID*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_16 + ItsNetDevSdk.NETDEV_LEN_2)]
        public byte[] szSampleTime;                                      /* 采样时间      格式YYYYMMDDHHMMSSMMM*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_32)]
        public byte[] szRecordID;                                        /* 记录ID Vehicle record ID*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_32)]
        public byte[] szTollgateID;                                      /* 卡口编码 Checkpoint ID*/
        public Int32 lParkingLotID;                                      /*车位编码      车位编号从1开始，如两车位即编号1和2*/
        public Int32 lParkingLotStatus;                                  /*车位状态       0-无车，1-有车，2-异常识别*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_32)]
        public byte[] szCarPlate;                                        /*车牌号码 */
        public Int32 lLedColour;                                         /*车位指示灯颜色 1-红色，2黄色，3-绿色*/
        public Int32 lLedStatus;                                         /*车位指示灯状态 0-熄灭，1-长亮，2-快速闪烁，3慢速闪烁*/
        public Int32 lCrossAlarm;                                        /*跨车位告警     0-未跨车位停车，1跨车位停车*/
        public Int32 lLingerAlarm;                                       /*徘徊告警       0-无徘徊人，1-有徘徊人*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_256)]
        public byte[] bRes;                                              /* 保留字段 Reserved */
    };

}
