using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ORG_INFO_S
    {
        public Int32 dwOrgID;
        public Int32 dwParentID;
        public Int32 dwType;                               /*  see NETDEV_ORG_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_NAME_MAX_LEN)]
        public byte[] szNodeName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_DESCRIBE_MAX_LEN)]
        public string szDesc;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    };

}
