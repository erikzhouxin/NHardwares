using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVPersonVerification
    * @brief 
    * @attention None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_VERIFICATION_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_128)]
        public byte[] szReference;
        public UInt32 udwSeq;
        public UInt32 udwChannelID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] szChannelName;
        public UInt32 udwTimestamp;
        public UInt32 udwNotificationType;
        public UInt32 udwFaceInfoNum;
        public IntPtr pstCtrlFaceInfo;
        public UInt32 udwCardInfoNum;
        public IntPtr pstCtrlCardInfo;
        public UInt32 udwGateInfoNum;
        public IntPtr pstCtrlGateInfo;
        public UInt32 udwLibMatInfoNum;
        public IntPtr pstLibMatchInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
