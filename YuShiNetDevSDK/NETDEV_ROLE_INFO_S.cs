using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct NETDEVRoleInfo
    * @brief 角色信息 结构体定义 
    * @attention 无 None
    */
    public struct NETDEV_ROLE_INFO_S
    {
        public UInt32 udwRoleID;                  /* 角色ID 添加角色可选*/
        public UInt32 udwLevel;                   /* 角色等级 [0,99] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szRoleName;                 /* 角色名称 [1,64] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_1024)]
        public byte[] szDesc;                      /* 描述长度 [0,256] */
        public UInt32 udwOrgID;                   /* 组织ID */
        public UInt32 udwPermissionsNum;          /* 权限数量 */
        public IntPtr pstPermissionList;          /* 权限列表 获取角色列表不返回 需要Malloc申请内存 详见NETDEVPermissionInfo*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                        /* 保留字节 */
    }

}
