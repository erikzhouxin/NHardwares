using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVEnabledActParamInfo
     * @brief 使能联动参数
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ENABLED_ACT_PARAM_INFO_S
    {
        public Int32 bEnabled;       /* 使能标记 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;         /* 保留字段 */
    }

}
