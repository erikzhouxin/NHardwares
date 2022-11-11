using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @enum tagNETDEVSubscribeSuccInfo
    * @brief 
    * @attention None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SUBSCRIBE_SUCC_INFO_S
    {
        public UInt32 udwID;
        public UInt32 udwCurrrntTime;
        public UInt32 udwTerminationTime;
        public UInt32 udwSupportAlarmType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_260)]
        public byte[] szReference;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;
    }

}
