using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVCtrlLibMatchInfo
    * @brief 库比对信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CTRL_LIB_MATCH_INFO_S
    {
        public UInt32 udwID;                                   /* 记录ID */
        public UInt32 udwLibID;                                /* 库ID */
        public UInt32 udwLibType;                              /* 库类型 */
        public UInt32 udwMatchStatus;                          /* 匹配状态 详见NETDEV_MATCH_STATUS_E */
        public UInt32 udwMatchPersonID;                        /* 匹配人员ID */
        public UInt32 udwMatchFaceID;                          /* 匹配人脸ID */
        public NETDEV_MATCH_PERSON_INFO_S stMatchPersonInfo;   /* 匹配人员信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                              /* 保留字节 */
    }

}
