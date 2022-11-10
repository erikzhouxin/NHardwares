using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVCtrlFaceInfo
    * @brief 
    * @attention None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CTRL_FACE_INFO_S
    {
        public UInt32 udwID;
        public UInt32 udwTimestamp;
        public UInt32 udwCapSrc;
        public UInt32 udwFeatureNum;
        public IntPtr pstFeatureInfo;
        public NETDEV_FILE_INFO_S stPanoImage;
        public NETDEV_FILE_INFO_S stFaceImage;
        public NETDEV_FACE_POSITION_INFO_S stFaceArea;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
