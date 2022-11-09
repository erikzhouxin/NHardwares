using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 时间
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_TM
    {
        /// <summary>
        /// 年
        /// </summary>
        public short nYear;
        /// <summary>
        /// 月
        /// </summary>
        public short nMonth;
        /// <summary>
        /// 日
        /// </summary>
        public short nMDay;
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
    }
}
