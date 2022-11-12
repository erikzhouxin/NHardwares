using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @enum tagNETDEVCtrlGateInfo
    * @brief 闸机信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CTRL_GATE_INFO_S
    {
        public UInt32 udwID;                /* 记录ID */
        public UInt32 udwTimestamp;         /* 采集时间 */
        public UInt32 udwCapSrc;            /* 采集来源 详见 NETDEV_CAP_SRC_E GateInfo选择4 */
        public UInt32 udwInPersonCnt;       /* 进入人员计数 */
        public UInt32 udwOutPersonCnt;      /* 离开人员计数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                /* 保留字节 */
    }

}
