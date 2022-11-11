using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVLinkageActionList
     * @brief 
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_LINKAGE_ACTION_LIST_S
    {
        public UInt32 udwNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_MAX_LINK_ACTION_NUM)]
        public NETDEV_LINKAGE_ACTION_INFO_S[] stActionInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;
    }

}
