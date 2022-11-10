using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @brief 
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_XW_BATCH_RESULT_WND_S
    {
        public UInt32 udwReqSeq;
        public UInt32 udwResuleCode;
        public UInt32 udwWinID;
    }

}
