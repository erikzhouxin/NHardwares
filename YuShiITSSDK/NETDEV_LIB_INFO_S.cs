using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVLibInfo
    * @brief 
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_LIB_INFO_S
    {
        public UInt32 udwID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_260)]
        public byte[] szName;
        public UInt32 udwType;                         /* See NETDEV_PEOPLE_LIB_TYPE_E*/
        public UInt32 udwPersonNum;
        public UInt32 udwFaceNum;
        public UInt32 udwMemberNum;
        public UInt32 udwLastChange;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_256)]
        public string szBelongIndex;
        public Int32 bIsMonitored;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
