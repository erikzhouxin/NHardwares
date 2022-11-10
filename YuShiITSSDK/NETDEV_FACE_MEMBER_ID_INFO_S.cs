using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVFaceMemberIDInfo
     * @brief 
     * @attention  None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_MEMBER_ID_INFO_S
    {
        public UInt32 udwType;                                       /*See #NETDEV_FACE_MEMBER_ID_TYPE_E */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_FACE_IDNUMBER_LEN)]
        public string szNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                     /* Reserved */
    }

}
