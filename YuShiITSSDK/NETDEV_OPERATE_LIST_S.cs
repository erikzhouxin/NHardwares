using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagstNETDEVOperateList
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OPERATE_LIST_S
    {
        public Int32 dwSize;
        public IntPtr pstOperateInfo;
    }

}
