using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVPersonList
    * @brief 
    * @attention None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_LIST_S
    {
        public UInt32 udwPersonID;
        public UInt32 udwFaceNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_8)]
        public NETDEV_FACE_INFO_S[] stFaceInfo;
        public UInt32 udwReqseq;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
