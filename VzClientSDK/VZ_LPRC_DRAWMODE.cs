using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 智能视频
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPRC_DRAWMODE
    {
        /// <summary>
        /// dsp叠加报警目标
        /// </summary>
        public byte byDspAddTarget;
        /// <summary>
        /// dsp叠加设置规则
        /// </summary>
        public byte byDspAddRule;
        /// <summary>
        /// dsp叠加轨迹
        /// </summary>
        public byte byDspAddTrajectory;
        /// <summary>
        /// 结果
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] dwRes;
    };
}
