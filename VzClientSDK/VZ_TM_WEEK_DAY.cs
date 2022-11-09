using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 工作日
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_TM_WEEK_DAY
    {
        /// <summary>
        /// 周日
        /// </summary>
        public byte bSun;
        /// <summary>
        /// 周一
        /// </summary>
        public byte bMon;
        /// <summary>
        /// 周二
        /// </summary>
        public byte bTue;
        /// <summary>
        /// 周三
        /// </summary>
        public byte bWed;
        /// <summary>
        /// 周四
        /// </summary>
        public byte bThur;
        /// <summary>
        /// 周五
        /// </summary>
        public byte bFri;
        /// <summary>
        /// 周六
        /// </summary>
        public byte bSat;
        /// <summary>
        /// 保留
        /// </summary>
        public byte reserved;
    }
}
