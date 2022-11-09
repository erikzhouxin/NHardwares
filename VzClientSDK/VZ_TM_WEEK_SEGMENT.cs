using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 部分
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_TM_WEEK_SEGMENT
    {
        /// <summary>
        /// 启用
        /// </summary>
        public uint uEnable;

        /// <summary>
        /// VZ_TM_WEEK_DAY->Anonymous_a54d933b_d2e6_4eba_97b3_61ea9b47dd3b
        /// 星期
        /// </summary>
        public VZ_TM_WEEK_DAY struDaySelect;

        /// VZ_TM_DAY->Anonymous_2bafa8b8_e11f_4cdc_a109_eb09791f91d6
        public VZ_TM_DAY struDayTimeStart;

        /// VZ_TM_DAY->Anonymous_2bafa8b8_e11f_4cdc_a109_eb09791f91d6
        public VZ_TM_DAY struDayTimeEnd;
    }
}
