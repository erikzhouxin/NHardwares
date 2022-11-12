using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CONFLAGRATION_ALARM_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szReference;                          /* 订阅者描述信息 */
        public Int32 udwTimeStamp;                          /* 告警时间 UTC时间 单位秒 */
        public Int32 udwAlarmSeq;                           /* 告警序号 */
        public NETDEV_GEOLACATION_INFO_S stPTPosition;      /* 发现火点位置时的云台位置 */
        public float fLensView;                             /* 发现火点位置时的镜头视场角角度，精确到小数点后两位 */
        public Int32 udwNum;                                /* 火点数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public NETDEV_FIRE_POINT_INFO[] stFirePointInfoList;/* 不同火点的位置信息列表，当Num不为0时必选 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                /* 保留字段 */
    };

}
