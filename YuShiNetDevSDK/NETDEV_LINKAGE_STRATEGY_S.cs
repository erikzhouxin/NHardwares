using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagLinkageStrategy
     * @brief 告警联动配置信息 结构体定义
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_LINKAGE_STRATEGY_S
    {
        public UInt32 udwType;                /* 告警类型,NETDEV_PERSON_COMPARE_RESULT_TYPE_E */
        public NETDEV_LINKAGE_ACTION_LIST_S stLintageActions;       /* 人脸布控任务联动动作 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] byRes;             /* 保留字段 */
    }

}
