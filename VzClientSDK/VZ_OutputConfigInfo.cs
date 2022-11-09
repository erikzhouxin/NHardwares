using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 输出配置信息
    /// </summary>
    public struct VZ_OutputConfigInfo
    {
        /// <summary>
        /// 多个输出配置输出的消息
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VzClientSdk.MAX_OutputConfig_Len, ArraySubType = UnmanagedType.I1)]
        public VZ_LPRC_OutputConfig[] oConfigInfo;
    };
}
