using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 车牌识别
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct VZ_LPR_WLIST_VEHICLE
    {
        /// <summary>
        /// 车辆在数据库的ID
        /// </summary>
        public uint uVehicleID;
        /// <summary>
        /// 车牌字符串
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string strPlateID;
        /// <summary>
        /// 客户在数据库的ID
        /// </summary>
        public uint uCustomerID;
        /// <summary>
        /// 该记录有效标记(是否启用)
        /// </summary>
        public uint bEnable;
        /// <summary>
        /// 是否开启生效时间
        /// </summary>
        public uint bEnableTMEnable;
        /// <summary>
        /// 是否开启过期时间
        /// </summary>
        public uint bEnableTMOverdule;
        /// <summary>
        /// 该记录生效时间
        /// </summary>
        public VZ_TM struTMEnable;
        /// <summary>
        /// 该记录过期时间
        /// </summary>
        public VZ_TM struTMOverdule;
        /// <summary>
        /// 是否使用周期时间段
        /// </summary>
        public uint bUsingTimeSeg;
        /// <summary>
        /// VZ_TM_PERIOD_OR_RANGE->Anonymous_6f46bf7e_03f5_450b_84da_e56739a41561
        /// 周期时间段信息
        /// </summary>
        public VZ_TM_PERIOD_OR_RANGE struTimeSegOrRange;
        /// <summary>
        /// 是否触发报警（黑名单记录）
        /// </summary>
        public uint bAlarm;
        /// <summary>
        /// 车辆颜色
        /// </summary>
        public uint iColor;
        /// <summary>
        /// 车牌类型
        /// </summary>
        public uint iPlateType;
        /// <summary>
        /// 车辆编码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string strCode;
        /// <summary>
        /// 车辆描述
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string strComment;
    }
}
