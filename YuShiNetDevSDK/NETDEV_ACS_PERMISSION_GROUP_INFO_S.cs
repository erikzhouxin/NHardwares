using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVACSPermissionGroupInfo
     * @brief 权限组信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERMISSION_GROUP_INFO_S
    {
        public UInt32 udwPermissionGroupID;                  /* 权限组ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szPermissionGroupName;  /* 权限组名称 */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                             /* 保留字段 */
    }

}
