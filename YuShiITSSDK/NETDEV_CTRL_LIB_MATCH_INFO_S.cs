using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVCtrlLibMatchInfo
    * @brief 
    * @attention None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CTRL_LIB_MATCH_INFO_S
    {
        public UInt32 udwID;
        public UInt32 udwLibID;
        public UInt32 udwLibType;
        public UInt32 udwMatchStatus;
        public UInt32 udwMatchPersonID;
        public UInt32 udwMatchFaceID;
        public NETDEV_MATCH_PERSON_INFO_S stMatchPersonInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
