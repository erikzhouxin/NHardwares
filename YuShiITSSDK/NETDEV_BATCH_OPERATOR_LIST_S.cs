using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVBatchOperateList
     * @brief 
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_BATCH_OPERATOR_LIST_S
    {
        public UInt32 udwNum;
        public UInt32 udwStatus;
        public IntPtr pstBatchList;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;     /* Reserved */
    }

}
