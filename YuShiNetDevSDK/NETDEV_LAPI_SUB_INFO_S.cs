using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @enum tagNETDEVLapiSubInfo
    * @brief Lapi告警订阅信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_LAPI_SUB_INFO_S
    {
        public UInt32 udwType;                          /* 订阅类型 按位表示参见 NETDEV_ALARM_TYPE_V30_E */
        public UInt32 udwLibIDNum;                      /* 订阅的库ID数目 LibIDNum为0xffff时 表示订阅所有库 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public UInt32[] audwLibIDList;     /* 订阅的库ID列表 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)]
        public byte[] byRes;              /* 保留字段  Reserved */
    }

}
