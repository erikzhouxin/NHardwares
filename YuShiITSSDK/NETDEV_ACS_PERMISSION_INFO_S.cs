using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVACSPermissionInfo
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERMISSION_INFO_S
    {
        public UInt32 udwPermissionID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szPermissionName;
        public UInt32 udwPermissionType;
        public NETDEV_OPERATE_LIST_S stPersonList;
        public UInt32 udwTemplateID;
        public NETDEV_ACS_TIME_SECTION_S stValidTime;
        public NETDEV_OPERATE_LIST_S stDoorList;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;
    }

}
