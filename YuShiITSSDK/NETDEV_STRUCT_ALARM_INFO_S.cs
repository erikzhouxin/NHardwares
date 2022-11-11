using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVStructAlarmInfo
     * @brief 
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_STRUCT_ALARM_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_260)]
        public byte[] szReference;
        public UInt32 udwTimeStamp;
        public UInt32 udwSeq;
        public UInt32 udwSrcID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_260)]
        public byte[] szSrcName;
        public UInt32 udwNotificationType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
