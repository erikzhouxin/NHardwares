using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVACSDoorPermissionInfo
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_DOOR_PERMISSION_INFO_S
    {
        public UInt32 udwPermissionNum;
        public NETDEV_ACS_TIME_SECTION_S stValidTime;
        public IntPtr pstPermissionGroupList;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;
    }

}
