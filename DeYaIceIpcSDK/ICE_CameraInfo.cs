using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.DeYaIceIpcSDK
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ICE_CameraInfo
    {

        /// <summary>
        /// char[128]相机app版本
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szAppVersion;

        /// <summary>
        /// char[256]相机算法版本
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szAlgoVersion;

        /// <summary>
        /// int相机是否加密
        /// </summary>
        public int szIsEnc;

        /// <summary>
        /// char[16]版本时间
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string szAppTime;

        /// <summary>
        /// char[1024]预留
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string szReserved;
    }
}
