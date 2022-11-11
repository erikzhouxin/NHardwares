using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagstNETDEVTimeTemplateList
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_TEMPLATE_LIST_S
    {
        public Int32 dwSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_TIME_TEMPLATE_NUM)]
        public NETDEV_TIME_TEMPLATE_S[] astTimeTemplate;
    }

}
