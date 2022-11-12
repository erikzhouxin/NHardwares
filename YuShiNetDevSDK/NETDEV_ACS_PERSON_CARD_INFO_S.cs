using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagACSPersonCard
     * @brief 人员所持门禁卡信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERSON_CARD_INFO_S
    {
        public UInt32 udwCardID;                      /* 绑定ID */
        public UInt32 udwCardType;                    /* 卡片类型 */
        public UInt32 udwCardStatus;                  /* 卡片状态  0:空白 1:激活 2:冻结 3:注销  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szCardNo;        /* 卡号 */
        public UInt32 udwReqSeq;                      /* 序号 */
        public NETDEV_ACS_TIME_SECTION_S stValidTime;                    /* 有效时间 */


        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                     /* 保留字段 */
    }

}
