using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVACSPersonList
     * @brief 人员列表
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERSON_LIST_S
    {
        public UInt32 udwNum;                 /* 人员数量 */
        public IntPtr pstPersonInfoList;      /* 员工信息列表 根据udwNum动态申请(NETDEV_ACS_PERSON_INFO_S[])*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;             /* 保留字段 */
    }

}
