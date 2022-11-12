using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVSystemTimeTemplate
    @brief 时间模板配置(PTS VMS)
    * @attention 无 None
    */
    public struct NETDEV_SYSTEM_TIME_TEMPLATE_S
    {
        public UInt32 udwTemplateID;                           /* 时间模板ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szTemplateName;                          /*  时间模板名称 [1, 63]  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_512)]
        public byte[] szTemplateDesc;                         /* 时间模板描述 [1, 128]  */
        public UInt32 udwLastChange;                           /* 时间模板最后修改时间 */
        public NETDEV_WEEK_PLAN_INFO_S stWeekPlanInfo;                          /* 布控任务布防计划 */
        public NETDEV_EXCEPTION_INFO_S stExceptionInfo;                         /* 布控任务例外计划 */
        public Int32 bIsBuiltin;                              /* 是否为内置时间模板 仅VMS支持 1:是 0:否 */
        public UInt32 udwTemplateType;                         /* 时间模板类型 仅VMS支持 0:录像时间模板 1:报警时间模板 2:用户时间模板 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                          /* 保留字段  */
    }

}
