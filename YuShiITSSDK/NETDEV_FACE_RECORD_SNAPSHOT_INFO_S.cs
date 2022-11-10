using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagstNETDEVFaceRecordSnapshotInfo
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_RECORD_SNAPSHOT_INFO_S
    {
        public UInt32 udwRecordID;
        public UInt32 udwRecordType;                                     /* See# NETDEV_FACE_PASS_RECORD_TYPE_E */
        public UInt32 udwPassTime;
        public UInt32 udwEventType;
        public UInt32 udwChannelID;
        public UInt32 udwMonitorRuleID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szChannelName;
        public NETDEV_FACE_ALARM_CMP_INFO_S stCompareInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;                                        /*Reserved */
    }

}
