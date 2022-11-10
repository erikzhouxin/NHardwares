using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVFaceBatchInfo
     * @brief Device information Structure definition
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_BATCH_INFO_S
    {
        public UInt32 udwReqSeq;
        public UInt32 udwResultCode;
        public UInt32 udwID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;         /* Reserved */
    }

}
