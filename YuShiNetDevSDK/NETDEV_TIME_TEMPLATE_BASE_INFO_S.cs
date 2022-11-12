using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVTimeTemplateBaseInfo
    * @brief 时间模板 结构体定义
    * @attention 无 None
    */
    public struct NETDEV_TIME_TEMPLATE_BASE_INFO_S
    {
        public UInt32 udwTemplateID;                  /* 模板ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szTemplateName;                 /* 模板名称  */
        public UInt32 udwLastChange;                  /* 最后的修改时间 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                          /* 保留字段  */
    }

}
