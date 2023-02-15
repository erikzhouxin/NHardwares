using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 设备日期时间参数
    /// </summary>
    public struct VZ_DATE_TIME_INFO
    {
        /// <summary>
        /// 年
        /// </summary>
        public uint uYear;
        /// <summary>
        /// 月
        /// </summary>
        public uint uMonth;
        /// <summary>
        /// 日
        /// </summary>
        public uint uMDay;
        /// <summary>
        /// 时
        /// </summary>
        public uint uHour;
        /// <summary>
        /// 分
        /// </summary>
        public uint uMin;
        /// <summary>
        /// 秒
        /// </summary>
        public uint uSec;
    }
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
        public int bdt_year;
        /// <summary>
        /// 预留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] res2;
    }
}
