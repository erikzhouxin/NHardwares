using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVCustomValue
     * @brief 自定义属性信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CUSTOM_VALUE_S
    {
        public UInt32 udwID;                                         /* 自定义属性名称序号 从0开始*/
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_FACE_MEMBER_CUSTOM_LEN)]
        public string szValue;        /* 自定义属性值 范围[1,63]*/
        public UInt32 udwModelStatus;                                /* 建模状态，即将人脸图片转为半结构化数据的状态。0：未建模 1：已建模 2：建模失败 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;                                    /* 保留字段  Reserved */
    }

}
