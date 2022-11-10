using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagstNETDEVFaceAlarmCmpInfo
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_ALARM_CMP_INFO_S
    {
        public UInt32 udwSimilarity;
        public NETDEV_FACE_MEMBER_INFO_S stMemberInfo;
        public NETDEV_FACE_ALARM_SNAP_IMAGE_S stSnapshotImage;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                           /* Reserved */
    }

}
