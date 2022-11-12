using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagstNETDEVFaceAlarmImageArea
     * @brief 区域坐标
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_ALARM_IMAGE_AREA_S
    {
        public UInt32 udwLeft;          /* 左坐标 */
        public UInt32 udwTop;           /* 上坐标 */
        public UInt32 udwRight;         /* 右坐标 */
        public UInt32 udwButtom;        /* 下坐标 */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                 /* 保留字段  Reserved */
    }

}
