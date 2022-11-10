using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 图像扩展编码模式 Smart image encoding mode
     * @attention
     */
    public struct NETDEV_SMART_ENCODE_S
    {
        public Int32 udwH264SmartEncodeModeNum;                                              /*支持的H.264图像智能编码模式种类个数 Number of smart image encoding in H.264*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_SMART_ENCODE_MODEL_MAX_NUM)]
        public Int32[] audwH264SmartEncodeModeList;         /*支持的H.265图像智能编码模式种类列表，参见NETDEV_SMART_ENCODE_MODE_E。 List of smart image encoding in H.265. See NETDEV_SMART_ENCODE_MODE_E for reference*/
        public Int32 udwH265SmartEncodeModeNum;             /*支持的H.264图像智能编码模式种类个数 Number of smart image encoding in H.264*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_SMART_ENCODE_MODEL_MAX_NUM)]
        public Int32[] audwH265SmartEncodeModeList;         /* 支持的H.265图像智能编码模式种类列表，参见NETDEV_SMART_ENCODE_MODE_E。 List of smart image encoding in H.265. See NETDEV_SMART_ENCODE_MODE_E for reference */
    }

}
