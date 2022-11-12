using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagstNETDEVTimeTemplateList
     * @brief 时间模板列表
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_TEMPLATE_LIST_S
    {
        public Int32 dwSize;                                                         /* 模板大小 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_TIME_TEMPLATE_NUM)]
        public NETDEV_TIME_TEMPLATE_S[] astTimeTemplate;       /* 时间模板信息 */
    }

}
