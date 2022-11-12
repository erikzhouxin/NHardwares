using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagstNETDEVFaceAlarmLogResultInfo
     * @brief 告警记录返回信息（人脸识别和车牌识别）
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SMART_ALARM_LOG_RESULT_INFO_S
    {
        public UInt32 udwTotal;                     /* 告警记录总数 */
        public UInt32 udwOffset;                    /* 记录偏移量 */
        public UInt32 udwNum;                       /* 此次返回告警记录个数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                   /* 保留字段  Reserved */
    }

}
