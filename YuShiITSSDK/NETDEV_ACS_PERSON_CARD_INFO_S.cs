using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagACSPersonCard
     * @brief
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERSON_CARD_INFO_S
    {
        public UInt32 udwCardID;
        public UInt32 udwCardType;
        public UInt32 udwCardStatus;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szCardNo;
        public UInt32 udwReqSeq;
        public NETDEV_ACS_TIME_SECTION_S stValidTime;


        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;
    }

}
