using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVBatchOperateBasicInfo
     * @brief Device information Structure definition
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_BATCH_OPERATE_BASIC_S
    {
        public UInt32 udwTotal;
        public UInt32 udwOffset;
        public UInt32 udwNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;     /*  Reserved */
    }

}
