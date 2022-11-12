using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVExceptionDayInfo
    * @brief 每天的布防计划具体信息
    * @attention 无 None
    */
    public struct NETDEV_EXCEPTION_DAY_INFO_S
    {
        public UInt32 udwID;                                      /* 例外日期索引 */
        public Int32 bEnabled;                                   /* 例外日期是否使能 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public byte[] szDate;                                     /* 例外日期 year-month-day  */
        public UInt32 udwNum;                                                           /* 例外时间段个数 NVR最大为8段 IPC/PTS最大为4段*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public NETDEV_TIME_SECTION_INFO_S[] astTimeSectionInfo;                         /* 布防配置具体信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                      /* 保留字段  */
    }

}
