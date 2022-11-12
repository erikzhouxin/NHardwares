using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVExceptionInfo
    * @brief 布控任务例外计划
    * @attention 无 None
    */
    public struct NETDEV_EXCEPTION_INFO_S
    {
        public Int32 bEnabled;                      /* 例外日期是否使能 0:不使能 1：使能 */
        public UInt32 udwNum;                        /* 例外日期个数 [0, 16] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public NETDEV_EXCEPTION_DAY_INFO_S[] astExceptionDayInfo;           /* 每天的布防计划具体信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                         /* 保留字段  */
    }

}
