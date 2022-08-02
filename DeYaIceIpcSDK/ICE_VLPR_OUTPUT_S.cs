using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.DeYaIceIpcSDK
{
    /// <summary>
    /// 车牌识别输出结构
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ICE_VLPR_OUTPUT_S
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string as8PlateNum;
        /// <summary>
        /// 车牌矩形框
        /// </summary>
        public ICE_RECT_S stPlateRect;
        /// <summary>
        /// 车牌字符矩形框
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.Struct)]
        public ICE_RECT_S[] astPlateCharRect;
        /// <summary>
        /// 车牌字符置信度
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.R4)]
        public float[] aflPlateCharConfid;
        /// <summary>
        /// 车牌置信度
        /// </summary>
        public float flConfidence;
        /// <summary>
        /// 车牌亮度
        /// </summary>
        public int s32PlateIntensity;
        /// <summary>
        /// 车牌颜色
        /// </summary>
        public int ePlateColor;
        /// <summary>
        /// 车牌类型
        /// </summary>
        public int ePlateType;
        /// <summary>
        /// 车身颜色
        /// </summary>
        public int eVehicleColor;
        /// <summary>
        /// 车牌水平倾斜角度
        /// </summary>
        public float flPlateAngleH;
        /// <summary>
        /// 车牌竖直倾斜角度
        /// </summary>
        public float flPlateAngleV;
        /// <summary>
        /// 颜色匹配程度
        /// </summary>
        public byte u8PlateColorRate;
        /// <summary>
        /// 预留参数
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 19)]
        public string astReserve;
        /// <summary>
        /// 时间戳ID
        /// </summary>
        public uint u32FrameId;
    }
}
