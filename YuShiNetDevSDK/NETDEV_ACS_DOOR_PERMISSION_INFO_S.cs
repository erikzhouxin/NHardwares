using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVACSDoorPermissionInfo
     * @brief 门授权信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_DOOR_PERMISSION_INFO_S
    {
        public UInt32 udwPermissionNum;                  /* 权限组个数 */
        public NETDEV_ACS_TIME_SECTION_S stValidTime;                       /* 有效时间 */
        public IntPtr pstPermissionGroupList;            /* 权限组信息列表.Num数为0时可选(NETDEV_ACS_PERMISSION_GROUP_INFO_S[]) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                         /* 保留字段 */
    }

}
