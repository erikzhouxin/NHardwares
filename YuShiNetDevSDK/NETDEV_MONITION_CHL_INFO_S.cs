using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVMonitorChlInfo
     * @brief 添加布控返回的布控信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITION_CHL_INFO_S
    {
        public UInt32 udwChannelID;                       /* 布控对应通道ID IPC、VMS该字段不返回 */
        public UInt32 udwResultCode;                      /* 人脸处理结果码 NETDEV_PERSON_RESULT_CODE_E */
        public UInt32 udwMonitorID;                       /* 相应通道对应的布控ID */
    }

}
