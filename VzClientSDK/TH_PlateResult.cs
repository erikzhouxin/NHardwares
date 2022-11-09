using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 车牌结果
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TH_PlateResult
    {
        /// <summary>
        /// 车牌号码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public char[] license;
        /// <summary>
        /// 车牌颜色
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public char[] color;
        /// <summary>
        /// 车牌颜色序号
        /// </summary>
        public int nColor;
        /// <summary>
        /// 车牌类型
        /// </summary>
        public int nType;
        /// <summary>
        /// 车牌可信度
        /// </summary>
        public int nConfidence;
        /// <summary>
        /// 亮度评价
        /// </summary>
        public int nBright;
        /// <summary>
        /// 运动方向，0 unknown, 1 left, 2 right, 3 up , 4 down	
        /// </summary>
        public int nDirection;
        /// <summary>
        /// 车牌位置
        /// </summary>
        public TH_RECT rcLocation;
        /// <summary>
        /// 识别所用时间
        /// </summary>
        public int nTime;
        /// <summary>
        /// 识别时间点
        /// </summary>
        public VZ_TIMEVAL tvPTS;
        /// <summary>
        /// 强制触发结果的类型，见TH_TRIGGER_TYPE_BIT
        /// </summary>
        public uint uBitsTrigType;
        /// <summary>
        /// 车的亮度
        /// </summary>
        public byte nCarBright;
        /// <summary>
        /// 车的颜色
        /// </summary>
        public byte nCarColor;
        /// <summary>
        /// 为了对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public char[] reserved0;
        /// <summary>
        /// 记录的编号
        /// </summary>
        public uint uId;
        /// <summary>
        /// 分解时间
        /// </summary>
        public VzBDTime struBDTime;
        /// <summary>
        /// 车牌是否加密
        /// </summary>
        public byte nIsEncrypt;
        /// <summary>
        /// 车牌的真实宽度，单位cm
        /// </summary>
        public byte nPlateTrueWidth;
        /// <summary>
        /// 车牌距离相机的位置，单位dm(分米)
        /// </summary>
        public byte nPlateDistance;
        /// <summary>
        /// 是否是伪车牌
        /// </summary>
        public byte nIsFakePlate;
        /// <summary>
        /// 车头位置
        /// </summary>
        TH_RECT car_location;
        /// <summary>
        /// 车辆品牌
        /// </summary>
        CarBrand car_brand;
        /// <summary>
        /// 车辆特征码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public char[] featureCode;
        /// <summary>
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
        public char[] reserved;
    }
}
