using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagstNETDEVOperateInfo
     * @brief 
     * @attention dwID
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OPERATE_INFO_S
    {
        public Int32 dwID;
        public Int32 dwReturnCode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;              /* Reserved field */
    }

}
