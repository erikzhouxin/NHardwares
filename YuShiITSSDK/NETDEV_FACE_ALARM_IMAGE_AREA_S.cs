using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagstNETDEVFaceAlarmImageArea
     * @brief
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_ALARM_IMAGE_AREA_S
    {
        public UInt32 udwLeft;
        public UInt32 udwTop;
        public UInt32 udwRight;
        public UInt32 udwButtom;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                 /* Reserved */
    }

}
