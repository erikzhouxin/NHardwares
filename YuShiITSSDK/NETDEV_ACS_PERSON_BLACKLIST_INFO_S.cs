using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVACSPersonBlacklistInfo
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERSON_BLACKLIST_INFO_S
    {
        public UInt32 udwBlackListID;
        public NETDEV_FACE_MEMBER_ID_INFO_S stIdentificationInfo;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;
    }

}
