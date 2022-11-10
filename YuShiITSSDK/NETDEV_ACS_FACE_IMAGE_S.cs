using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
 * @struct tagNETDEVACSFaceImage
 * @brief 
 * @attention
 */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_FACE_IMAGE_S
    {
        public UInt32 udwNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public NETDEV_FILE_INFO_S[] stImageList;
        public UInt32 udwMajorImageIndex;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
