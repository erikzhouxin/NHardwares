using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @brief 时间段配置 结构体定义 Time Sections Structure definition
    * @attention 无 None
    */
    public struct NETDEV_TIME_SECTION_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public byte[] szBeginTime;                 /* 开始时间  Begin time  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public byte[] szEndTime;                   /* 结束时间  End time  */
        public UInt32 udwArmingType;               /* 布防类型0: 定时 1: 动检 2: 报警 3: 动检和报警 4: 动检或报警5: 无计划10: 事件  Distribution Type 0: Timing 1: Motive Inspection 2: Alarm 3: Motive Inspection and Alarm 4: Motive Inspection or Alarm 5: Unplanned 10: Event*/
    }

}
