using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagstNETDEVSmartInfo
     * @brief
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SMART_INFO_S
    {
        public Int32 dwChannelID;
        public UInt32 udwSubscribeID;
        public UInt32 udwSubscribeType;
        public UInt32 udwCurrrntTime;
        public UInt32 udwEndTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;
    }

}
