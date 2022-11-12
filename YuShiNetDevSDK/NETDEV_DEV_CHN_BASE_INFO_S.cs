using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEV_CHN_BASE_INFO_S
    {
        public Int32 dwChannelID;                                      /* 通道ID */
        public Int32 dwDevID;                                          /* 设备ID */
        public Int32 dwOrgID;                                          /* 组织ID */
        public Int32 dwChnType;                                        /* 通道类型，参见 NETDEV_CHN_TYPE_E */
        public Int32 dwChnStatus;                                      /* 通道状态, 参见 NETDEV_CHN_STATUS_E */
        public Int32 dwChnIndex;                                       /* 通道索引 */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szChnName;                    /* 通道名称 */
        public UInt32 udwRight;                                        /* 通道权限 */
        public UInt32 udwAbnormalReason;                               /* 视频通道异常的原因 参见 NETDEV_CHN_OFFLINE_REASON_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;
    };

}
