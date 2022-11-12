using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVACSPermissionInfo
     * @brief 授权信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERMISSION_INFO_S
    {
        public UInt32 udwPermissionID;                   /* 权限ID     */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szPermissionName;  /* 权限名称 */
        public UInt32 udwPermissionType;                 /* 权限类型：0表示员工权限组，1表示访客权限组 */
        public NETDEV_OPERATE_LIST_S stPersonList;                      /* 人员ID列表，其中dwSize为人员个数*/
        public UInt32 udwTemplateID;                     /* 时间模板ID */
        public NETDEV_ACS_TIME_SECTION_S stValidTime;                       /* 有效时间 */
        public NETDEV_OPERATE_LIST_S stDoorList;                        /* 门通道列表, 其中dwSize为门通道个数*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                      /* 保留字段 */
    }

}
