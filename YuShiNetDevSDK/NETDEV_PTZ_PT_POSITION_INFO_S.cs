using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_PT_POSITION_INFO_S
    {
        public float fLongitude;                        /* 云台经度（云台水平移动角度）范围：[0.00, 360.00] */
        public float fLatitude;                         /* 云台纬度（云台上下翻转角度） */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                            /*   Reserved field*/
    };

}
