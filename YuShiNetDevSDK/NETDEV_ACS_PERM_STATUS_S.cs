using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVACSPermStatus
    * @brief 权限组门禁通道人员授权状态
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERM_STATUS_S
    {
        public UInt32 udwPersonID;                                    /* 人员ID,查询条件为通道时必选 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szPersonName;                   /* 人员姓名,查询条件为通道时必选 字符串长度范围[1, 63] */
        public UInt32 udwDepartmentID;                                /* 部门ID,查询条件为通道时必选 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szDepartmentName;               /* 部门名称,查询条件为通道时必选 字符串长度范围[1, 63] */
        public UInt32 udwDoorID;                                      /* 门禁通道ID,查询条件为人员时必选 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szDoorName;                     /* 门禁通道名称,查询条件为人员时必选 字符串长度范围[1, 63] */
        public UInt32 udwDeviceID;                                    /* 门禁通道所属设备ID,查询条件为人员时必选 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szDeviceName;                   /* 门禁通道所属设备名称,查询条件为人员时必选 字符串长度范围[1, 63] */
        public UInt32 udwStatus;                                      /* 人员下发到速通门状态 详见 NETDEV_PERSON_RESULT_CODE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                     /* 保留字段 */
    }

}
