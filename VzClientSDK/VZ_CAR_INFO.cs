using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 车辆信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_CAR_INFO
    {
        /// <summary>
        /// 徽标ID
        /// </summary>
        public int logo_id;
        /// <summary>
        /// 车辆徽标
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public char[] car_logo;
        /// <summary>
        /// 序号标识
        /// </summary>
        public int series_id;
        /// <summary>
        /// 车辆序号
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public char[] car_series;
        /// <summary>
        /// 样式标识
        /// </summary>
        public int style_id;
        /// <summary>
        /// 车辆样式
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public char[] car_style;
        /// <summary>
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
        public char[] reserved;
    }
}
