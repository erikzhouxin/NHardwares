using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVPersonInfoList
    * @brief 人员信息列表
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_INFO_LIST_S
    {
        public UInt32 udwNum;                                          /* 人员库人员个数 */
        public IntPtr pstPersonInfo;      /* 人员信息列表,需动态分配内存（参见NETDEV_PERSON_INFO_S） */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                     /* 保留字节 */
    }

}
