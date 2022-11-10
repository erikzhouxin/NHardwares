using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 昼夜模式信息 IrCut filter info
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_IRCUT_FILTER_INFO_S
    {
        public Int32 udwIrCutFilterMode;                   /* 昼夜模式 IrCut Filter mode */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] byRes;                               /* 保留字段 Reserved */
    }

}
