using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @enum tagNETDEVLapiSubInfo
    * @brief 
    * @attention None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_LAPI_SUB_INFO_S
    {
        public UInt32 udwType;
        public UInt32 udwLibIDNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public UInt32[] audwLibIDList;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)]
        public byte[] byRes;
    }

}
