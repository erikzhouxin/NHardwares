using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @brief 计划（天）配置 结构体定义 Play (Day) Structure definition
    * @attention 无 None
    */
    public struct NETDEV_DAY_PLAN_INFO_S
    {
        public UInt32 udwID;                                           /*星期索引1：周一;2：周二；3：周三；4：周四；5：周五；6：周六；7：周日；8：假日；  Weekly Index 1: Monday; 2: Tuesday; 3: Wednesday; 4: Thursday; 5: Friday; 6: Saturday; 7: Sunday; 8: Holidays;*/
        public UInt32 udwNum;                                          /*每天时间段个数 NVR最大为8段；IPC最大为4段  The maximum number of NVRs per day is 8; IPC maximum 4 paragraphs*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_MAX_TIME_SECTION_NUM)]
        public NETDEV_TIME_SECTION_INFO_S[] astTimeSection;                                  /* 时间段配置  Time Sections */
    }

}
