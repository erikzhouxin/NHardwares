using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 分解时间
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VzBDTime
    {
        /// <summary>
        /// 秒，取值范围[0,59]
        /// </summary>
        public byte bdt_sec;
        /// <summary>
        /// 分，取值范围[0,59]
        /// </summary>
        public byte bdt_min;
        /// <summary>
        /// 时，取值范围[0,23]
        /// </summary>
        public byte bdt_hour;
        /// <summary>
        /// 一个月中的日期，取值范围[1,31]
        /// </summary>
        public byte bdt_mday;
        /// <summary>
        /// 月份，取值范围[1,12]
        /// </summary>
        public byte bdt_mon;
        /// <summary>
        /// 预留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] res1;
        /// <summary>
        /// 年份
        /// </summary>
        public uint bdt_year;
        /// <summary>
        /// 预留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] res2;     
    }   //broken-down time
}
