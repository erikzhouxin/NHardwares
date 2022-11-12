using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @enum tagNETDEVPersonTimeTemplateInfo
    * @brief 时间模板相关信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_TIME_TEMPLATE_INFO_S
    {
        public UInt32 udwBeginTime;    /* 时间模板生效起始时间 若未配置，填写0 */
        public UInt32 udwEndTime;      /* 时间模板生效结束时间 若未配置，填写4294967295(0xFFFFFFFF)*/
        public UInt32 udwIndex;        /* 时间模板索引 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;      /* 保留字节 */
    }

}
