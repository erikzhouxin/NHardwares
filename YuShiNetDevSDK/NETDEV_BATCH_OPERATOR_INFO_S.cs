using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVBatchOperatorInfo
     * @brief 批量操作信息 结构体定义 Device information Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_BATCH_OPERATOR_INFO_S
    {
        public UInt32 udwReqSeq;                          /* 请求数据序号 */
        public UInt32 udwResultCode;                      /* 返回错误码,人脸布控操作结果详见# NETDEV_PERSON_MONITOR_OPT_RES_CODE_E */
        public UInt32 udwID;                              /* 编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szName;             /* 成员名称，长度范围[1,63] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;             /* 保留字段  Reserved */
    }

}
