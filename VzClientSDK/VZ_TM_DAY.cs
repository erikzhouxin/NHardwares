using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 时间日期
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_TM_DAY
    {
        /// <summary>
        /// 时
        /// </summary>
        public short nHour;
        /// <summary>
        /// 分
        /// </summary>
        public short nMin;
        /// <summary>
        /// 秒
        /// </summary>
        public short nSec;
        /// <summary>
        /// 保留
        /// </summary>
        public short reserved;
    }
}
