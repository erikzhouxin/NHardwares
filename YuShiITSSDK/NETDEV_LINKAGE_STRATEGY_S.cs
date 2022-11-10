using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagLinkageStrategy
     * @brief 
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_LINKAGE_STRATEGY_S
    {
        public UInt32 udwType;
        public NETDEV_LINKAGE_ACTION_LIST_S stLintageActions;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] byRes;
    }

}
