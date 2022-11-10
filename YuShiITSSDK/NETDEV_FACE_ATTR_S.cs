using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVFaceAttr
     * @brief 
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_ATTR_S
    {
        public UInt32 udwGender;
        public UInt32 udwAgeRange;
        public UInt32 udwEthicCode;
        public UInt32 udwGlassFlag;
        public UInt32 udwGlassesStyle;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
