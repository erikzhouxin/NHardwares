using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_POSTION_INFO_S
    {
        public Int32 udwChannelId;                          /* 通道ID */
        public NETDEV_POINT_S stPoint;                      /* 火点中心位置在通道中的坐标信息,图像中火点位置坐标万分比表示,范围[0,9999) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                /* 保留字段 */
    }

}
