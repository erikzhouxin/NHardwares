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
    public struct T_OsdInfoCfg
    {
        /// <summary>
        /// 
        /// </summary>
        public int iEnable;
        /// <summary>
        /// 
        /// </summary>
        public int iLocation;
        /// <summary>
        /// 
        /// </summary>
        public int iType;
        /// <summary>
        /// 
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.U1)]
        public byte[] acCustomInfo;
        /// <summary>
        /// 
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string acResrv;
    }
}
