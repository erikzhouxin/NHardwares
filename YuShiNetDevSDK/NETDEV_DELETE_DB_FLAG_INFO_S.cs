using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVDeleteDBFlagInfo
     * @brief 删除库信息标志位
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DELETE_DB_FLAG_INFO_S
    {
        public Int32 bIsDeleteMember;       /* 是否删除库下里面的成员信息：0:不删除 1:删除 */
        public UInt32 udwDevID;             /* 设备ID(仅VMS删除人脸库支持) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;            /* 保留字段  Reserved */
    }

}
