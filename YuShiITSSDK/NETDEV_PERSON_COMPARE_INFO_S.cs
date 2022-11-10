using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVPersonCompareInfo
    * @brief 
    * @attention None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_COMPARE_INFO_S
    {
        public UInt32 udwSimilarity;
        public NETDEV_PERSON_INFO_S stPersonInfo;
        public NETDEV_FILE_INFO_S stPanoImage;
        public NETDEV_FILE_INFO_S stFaceImage;
        public NETDEV_FACE_POSITION_INFO_S stFaceArea;
        public UInt32 udwCapSrc;
        public UInt32 udwFeatureNum;
        public IntPtr pstFeatureInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 248)]
        public byte[] byRes;
    }

}
