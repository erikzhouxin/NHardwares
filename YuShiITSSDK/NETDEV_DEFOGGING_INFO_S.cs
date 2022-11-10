using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 透雾信息 Defogging info
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEFOGGING_INFO_S
    {
        public Int32 dwDefoggingMode;              /*除雾模式 Defogging mode (0:On 1:Off) */
        public float fDefoggingLevel;              /*除雾等级 Defogging level (0.0, 1.0) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;                            /*保留字段 Reserved */
    }

}
