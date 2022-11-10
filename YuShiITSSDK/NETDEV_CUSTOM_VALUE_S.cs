using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVCustomValue
     * @brief
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CUSTOM_VALUE_S
    {
        public UInt32 udwID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_FACE_MEMBER_CUSTOM_LEN)]
        public string szValue;
        public UInt32 udwModelStatus;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;                                    /*  Reserved */
    }

}
