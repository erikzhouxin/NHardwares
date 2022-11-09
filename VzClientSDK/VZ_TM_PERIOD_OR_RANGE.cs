using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 周期范围
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_TM_PERIOD_OR_RANGE
    {
        /// <summary>
        /// 启用
        /// </summary>
        public uint uEnable;
        /// <summary>
        /// 周段
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.Struct)]
        public VZ_TM_WEEK_SEGMENT[] struWeekSeg;
    }
}
