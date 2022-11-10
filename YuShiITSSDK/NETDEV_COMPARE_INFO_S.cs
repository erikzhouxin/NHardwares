using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVCompareInfo
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_COMPARE_INFO_S
    {
        public NETDEV_FILE_INFO_S stPersonImage;
        public NETDEV_FILE_INFO_S stSnapshotImage;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
