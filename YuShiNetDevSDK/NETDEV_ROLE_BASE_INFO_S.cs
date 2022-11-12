using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVRoleBaseInfo
    * @brief 角色信息 结构体定义 
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ROLE_BASE_INFO_S
    {
        public UInt32 udwRoleID;                    /* 角色ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szRoleName;                   /* 角色名称  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                        /* 保留字段  */
    }

}
