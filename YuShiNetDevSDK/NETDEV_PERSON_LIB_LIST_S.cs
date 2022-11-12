using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVPersonLibList
    * @brief 人员库信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_LIB_LIST_S
    {
        public UInt32 udwNum;                     /* 设备中已创建的库数量 */
        public IntPtr pstLibInfo;                 /* 库列表信息,需动态分配内存（参见NETDEV_LIB_INFO_S） */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                 /* 保留字节 */
    }

}
