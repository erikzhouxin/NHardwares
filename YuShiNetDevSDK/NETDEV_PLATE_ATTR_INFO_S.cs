using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagstNETDEVPlateAttrInfo
    * @brief 车牌信息
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PLATE_ATTR_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public byte[] szPlateNo;                        /* 车牌号 */
        public UInt32 udwColor;                                        /* 车牌颜色 参见NETDEV_PLATE_COLOR_E */
        public UInt32 udwType;                                         /* 车牌类型，参见NETDEV_PLATE_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;              /* 保留字段  Reserved */
    }

}
