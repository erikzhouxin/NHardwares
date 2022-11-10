using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVBatchOperateMemberList
     * @brief Device information Structure definition
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_BATCH_OPERATE_MEMBER_LIST_S
    {
        public UInt32 udwTaskNo;
        public UInt32 udwMemberNum;
        public IntPtr pstMemberIDList;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;             /*Reserved */

    }

}
