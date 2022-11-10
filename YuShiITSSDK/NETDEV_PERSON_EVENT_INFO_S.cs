using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVPersonEventInfo
    * @brief
    * @attention None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_EVENT_INFO_S
    {
        public UInt32 udwID;
        public UInt32 udwTimestamp;
        public UInt32 udwNotificationType;
        public UInt32 udwFaceInfoNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_2)]
        public NETDEV_FACE_PASS_RECORD_INFO_S[] stCtrlFaceInfo;
        public UInt32 udwFinishFaceNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_40)]
        public UInt32[] audwFinishFaceList;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 92)]
        public byte[] byRes;
    }

}
