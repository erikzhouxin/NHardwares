using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVFacePassRecordInfo
    * @brief 
    * @attention None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_PASS_RECORD_INFO_S
    {
        public UInt32 udwRecordID;
        public UInt32 udwType;
        public Int64 tPassingTime;
        public UInt32 udwChannelID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_128)]
        public byte[] szChlName;
        public NETDEV_PERSON_COMPARE_INFO_S stCompareInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;
    }

}
