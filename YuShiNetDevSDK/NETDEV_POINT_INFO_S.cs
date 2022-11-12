using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVPointInfo
     * @brief 检测区域图形顶点坐标信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_POINT_INFO_S
    {
        public UInt32 udwX;                                  /* X轴坐标，范围[0,10000] */
        public UInt32 udwY;                                  /* Y轴坐标，范围[0,10000] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public byte[] byRes;                             /* 保留字段 */
    };

}
