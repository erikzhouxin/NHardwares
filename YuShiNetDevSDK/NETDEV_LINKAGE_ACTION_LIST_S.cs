using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVLinkageActionList
     * @brief 布控任务联动动作列表 结构体定义
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_LINKAGE_ACTION_LIST_S
    {
        public UInt32 udwNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_MAX_LINK_ACTION_NUM)]
        public NETDEV_LINKAGE_ACTION_INFO_S[] stActionInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;         /* 保留字段 */
    }

}
