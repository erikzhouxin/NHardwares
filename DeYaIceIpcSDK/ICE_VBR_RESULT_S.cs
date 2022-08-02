using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.DeYaIceIpcSDK
{
    /// <summary>
    /// 车辆特征码结构体
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ICE_VBR_RESULT_S
    {
        /// <summary>
        /// ICE_S8[20]主品牌
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string szLogName;

        /// <summary>
        /// ICE_S8[88]预留
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 88)]
        public string reserve;

        /// <summary>
        /// ICE_FLOAT[20]特征码，数组长度为20
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.R4)]
        public float[] fResFeature;

        /// <summary>
        /// ICE_U32[4]预留
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
        public uint[] iReserved;
    }
}
