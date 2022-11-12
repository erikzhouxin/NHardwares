using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagstNETDEVSmartInfo
     * @brief 智能事件信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SMART_INFO_S
    {
        public Int32 dwChannelID;         /* 通道ID */
        public UInt32 udwSubscribeID;      /* 订阅ID */
        public UInt32 udwSubscribeType;      /* 订阅类型 */
        public UInt32 udwCurrrntTime;      /* 当前时间，UTC格式，单位秒 */
        public UInt32 udwEndTime;          /* 结束时间，UTC格式，单位秒 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;              /* 保留字段  Reserved */
    }

}
