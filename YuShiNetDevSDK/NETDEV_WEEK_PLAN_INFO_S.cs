using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @brief 计划（周）配置 结构体定义 Play (Week) Structure definition
    * @attention 无 None
    */
    public struct NETDEV_WEEK_PLAN_INFO_S
    {
        public Int32 bEnabled;                       /*使能,仅IPC支持  Enabling,IPC only*/
        public UInt32 udwNum;                         /* 计划天数，NVR最大为8(一周七天和假日)IPC最大为7(一周七天)  Planned days, NVR up to 8(7 days a week and holidays) IPC up to 7(7 days a week)*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_MAX_DAY_NUM)]
        public NETDEV_DAY_PLAN_INFO_S[] astDayPlanInfo;                 /* 一周内每天的布防计划列表  List of deployment plans for each day of the week*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] byRes;                              /* 保留字段  */
    }

}
