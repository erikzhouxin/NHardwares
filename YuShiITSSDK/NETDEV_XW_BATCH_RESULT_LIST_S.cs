using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @brief 
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_XW_BATCH_RESULT_LIST_S
    {
        public UInt32 udwSize;
        public UInt32 udwLastChange;
        public IntPtr pstResultInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byRes;
    }

}
