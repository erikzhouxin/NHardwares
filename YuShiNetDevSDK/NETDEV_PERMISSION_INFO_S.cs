using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct NETDEVPermissionInfo
     * @brief 权限信息 结构体定义 
    * @attention 无 None
    */
    public struct NETDEV_PERMISSION_INFO_S
    {
        public UInt32 udwMajorPermission;          /* 一级权限 #NETDEV_MAJOR_RIGHT_E */
        public UInt32 udwMinorPermission;          /* 二级权限 #NETDEV_MINOR_RIGHT_XXXX_E */
        public UInt32 udwOrgNum;                   /* 组织数量 */
        public IntPtr pudwOrgList;                 /* 组织ID列表 需要Malloc申请内存 (UINT32 *)*/
        public UInt32 udwChlNum;                   /* 通道数量 */
        public IntPtr pudwChlList;                 /* 通道列表 需要Malloc申请内存 (UINT32 *)*/
        public UInt32 udwTvwallNum;                /* 电视墙数量 */
        public IntPtr pudwTvwallIDList;            /* 电视墙信息列表 需要Malloc申请内存 (UINT32 *) */
        public IntPtr pstTVwallCodeList;           /* 电视墙编码信息列表 需要Malloc申请内存，NETDEV_TVWALL_CODE_S */
        public UInt32 udwEntranceNum;              /* 出入口数量 */
        public IntPtr pudwEntranceIDList;          /* 出入口信息列表 需要Malloc申请内存 (UINT32 *) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 492)]
        public byte[] byRes;                      /* 保留字节 */
    }

}
