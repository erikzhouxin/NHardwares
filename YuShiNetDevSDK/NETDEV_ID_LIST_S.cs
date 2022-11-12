using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVIDList
    * @brief 通用ID列表 结构体定义 
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ID_LIST_S
    {
        public UInt32 udwNum;                     /* 数量 */
        public IntPtr pudwIDs;                    /* ID列表 Malloc申请内存(UINT32 *) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                      /* 保留字段  */
    }

}
