using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @brief 批量开窗场景窗口返回信息
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_XW_BATCH_RESULT_WND_S
    {
        public UInt32 udwReqSeq;      /* 请求数据序号 */
        public UInt32 udwResuleCode;  /* 返回错误码 */
        public UInt32 udwWinID;       /* 窗口ID */
    }

}
