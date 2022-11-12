using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVPersonLibCapList
     * @brief 所有人员库的容量信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_LIB_CAP_LIST_S
    {
        public UInt32 udwMaxPerpleMun;                         /* 总库容量，单位：K人 */
        public UInt32 udwFreePerpleNum;                        /* 剩余容量，单位：人 */
        public UInt32 udwMaxLibNum;                            /* 最大可建库容量 */
        public UInt32 udwFreeLibNum;                           /* 剩余可建库容量 */
        public UInt32 udwNum;                                  /* 已建库个数 库个数范围:[0, 16] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public NETDEV_PERSON_LIB_CAP_INFO_S[] stLibCapInfoList;         /* 单库容量信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                              /* 保留字段 */
    }

}
