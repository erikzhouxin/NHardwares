using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVPersonLibCapList
     * @brief 
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_LIB_CAP_LIST_S
    {
        public UInt32 udwMaxPerpleMun;
        public UInt32 udwFreePerpleNum;
        public UInt32 udwMaxLibNum;
        public UInt32 udwFreeLibNum;
        public UInt32 udwNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public NETDEV_PERSON_LIB_CAP_INFO_S[] stLibCapInfoList;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;
    }

}
