using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.DeYaIceIpcSDK
{
    /// <summary>
    /// 车牌识别数据结构体，由于只使用车辆特征码结构体指针，其余内容都用数组代替
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ICE_VDC_PICTRUE_INFO_S
    {
#if VERSION32
        /// <summary>
        /// 预留（考虑到64位指针长度比32位时指针长度大4，所以32位的预留数组长度比64位大4）
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 132)]
        public string cFileName;           
#else
        /// <summary>
        /// 预留（考虑到64位指针长度比32位时指针长度大4，所以32位的预留数组长度比64位大4）
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string cFileName;
#endif
        /// <summary>
        /// ICE_VBR_RESULT_S* 车辆特征码结构体指针
        /// </summary>
        public IntPtr pstVbrResult;
        /// <summary>
        /// 
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 232)]
        public string data;
        /// <summary>
        /// 车牌信息
        /// </summary>
        public ICE_VLPR_OUTPUT_S stPlateInfo;
        /// <summary>
        /// 
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 12)]
        public string data2;
    }
}
