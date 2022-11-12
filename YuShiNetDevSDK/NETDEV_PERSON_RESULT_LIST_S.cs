using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVPersonResultList
    * @brief 人员信息结果列表
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_RESULT_LIST_S
    {
        public UInt32 udwNum;                                          /* 人员个数 */
        public IntPtr pstPersonList;                   /* 人员信息执行结果列表,需动态分配内存 malloc by caller（参见NETDEV_PERSON_LIST_S） */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                      /* 保留字节 */
    }

}
