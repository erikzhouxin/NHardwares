using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ORG_FIND_COND_S
    {
        public UInt32 udwOrgType;              /* 组织类型 参见NETDEV_ORG_TYPE_E */
        public UInt32 udwRootOrgID;            /* 根节点组织ID */
        public UInt32 udwFindType;             /* 查找模式，参见NETDEV_ORG_FIND_MODE_E */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    };

}
