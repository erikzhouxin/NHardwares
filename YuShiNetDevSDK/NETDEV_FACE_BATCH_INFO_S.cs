using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVFaceBatchInfo
     * @brief 人脸识别模块批量操作信息 结构体定义 Device information Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_BATCH_INFO_S
    {
        public UInt32 udwReqSeq;         /* 请求数据序号 */
        public UInt32 udwResultCode;     /* 返回错误码 */
        public UInt32 udwID;             /* 编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;         /* 保留字段  Reserved */
    }

}
