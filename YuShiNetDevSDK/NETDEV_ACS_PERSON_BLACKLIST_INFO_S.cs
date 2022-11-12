using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVACSPersonBlacklistInfo
     * @brief 黑名单信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERSON_BLACKLIST_INFO_S
    {
        public UInt32 udwBlackListID;                    /* 黑名单ID */
        public NETDEV_FACE_MEMBER_ID_INFO_S stIdentificationInfo;               /* 身份信息 */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                        /* 保留字段 */
    }

}
