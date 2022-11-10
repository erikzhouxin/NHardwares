using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVFaceBatchList
     * @brief  
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_BATCH_LIST_S
    {
        public UInt32 udwNum;
        public IntPtr pstBatchList;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;     /* Reserved */
    }

}
