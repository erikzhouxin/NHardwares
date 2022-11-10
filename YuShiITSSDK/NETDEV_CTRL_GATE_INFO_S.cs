using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @enum tagNETDEVCtrlGateInfo
    * @brief 
    * @attention None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CTRL_GATE_INFO_S
    {
        public UInt32 udwID;
        public UInt32 udwTimestamp;
        public UInt32 udwCapSrc;
        public UInt32 udwInPersonCnt;
        public UInt32 udwOutPersonCnt;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
