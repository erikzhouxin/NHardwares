using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ORG_INFO_S
    {
        public Int32 dwOrgID;                              /* 组织ID */
        public Int32 dwParentID;                           /* 组织父节点ID */
        public Int32 dwType;                               /*  see NETDEV_ORG_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_NAME_MAX_LEN)]
        public byte[] szNodeName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_DESCRIBE_MAX_LEN)]
        public string szDesc;
        public Int32 udwTime;                               /* 创建时间，UTC时间 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szUserName;                           /* 创建人 [1,64] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
        public byte[] byRes;
    };

}
