using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVPlateAttr
     * @brief 车牌属性信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PLATE_ATTR_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szPlateNo;                      /* 车牌号码 */
        public UInt32 udwColor;                                      /* 车牌颜色 详见 NETDEV_PLATE_COLOR_E */
        public UInt32 udwType;                                       /* 车牌类型 详见 NETDEV_PLATE_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                    /* 保留字段 */
    }

}
