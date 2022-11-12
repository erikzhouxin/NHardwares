using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @enum tagNETDEVSubscribeSuccInfo
    * @brief 订阅信息成功返回信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SUBSCRIBE_SUCC_INFO_S
    {
        public UInt32 udwID;                      /* 订阅ID */
        public UInt32 udwCurrrntTime;             /* 当前时间，UTC格式，从1970年1月1日0点开始的秒数 */
        public UInt32 udwTerminationTime;         /* 结束时间，UTC格式，从1970年1月1日0点开始的秒数 */
        public UInt32 udwSupportAlarmType;        /* 请求消息携带订阅告警类型时返回值需携带此参数，返回0说明响应未携带该数据 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szReference;/* 订阅者描述信息 以URL格式体现 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;              /* 保留字段  Reserved */
    }

}
