using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @brief 批量开窗场景窗口返回信息列表
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_XW_BATCH_RESULT_LIST_S
    {
        public UInt32 udwSize;            /* 窗口数量 */
        public UInt32 udwLastChange;      /* 摘要字 */
        public IntPtr pstResultInfo;      /* 窗口信息,根据窗口数量动态申请内存(NETDEV_XW_BATCH_RESULT_WND_S[]) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byRes;          /* 保留字段 */
    }

}
