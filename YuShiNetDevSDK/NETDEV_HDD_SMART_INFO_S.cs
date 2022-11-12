using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_HDD_SMART_INFO_S
    {
        public Int32 udwID;                                         /* IN 存储容器编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szManufacturer;                               /* 厂商名称 */
        public Int32 udwTemperature;                                /* 温度(℃) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szDeviceModel;                                /* 硬盘型号 */
        public Int32 udwUsedDays;                                   /* 使用天数 */
        public Int32 udwHealthAssessment;                           /* 整体评估结果 参见枚举#NETDEV_HDD_HEALTH_ASSESSMENT_STATUS_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szFirmware;                                   /* 硬盘固件版本 */
        public Int32 udwSmartNum;                                  /* Smart详情项数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_DISK_SMART_MAX_NUM)]
        public NETDEV_HDD_SMART_DETAILS_INFO_S[] SmartDetailsInfoList;          /* Smart详情项列表 */
        public Int32 bCheckResult;                                 /* 自我评估结果, 1 通过，0 未通过 */
        public Int32 udwCheckPrograss;                             /* 检测进度 [0,100] */
        public Int32 udwCheckStatus;                               /* 检测状态 参见枚举#NETDEV_HDD_SMART_CHECK_STATUS_E */
        public Int32 udwCheckType;                                 /* 检测类型 参见枚举#NETDEV_HDD_SMART_CHECK_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                                    /* Reserved */
    }

}
