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
    public struct T_SnapOsdCfg
    {
        /// <summary>
        /// 
        /// </summary>
        public int ibgColorMode;
        /// <summary>
        /// 
        /// </summary>
        public int iDateMode;
        /// <summary>
        /// 
        /// </summary>
        public int iFontSize;
        /// <summary>
        /// 
        /// </summary>
        public int iLineMode;
        /// <summary>
        /// 
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.Struct)]
        public T_OsdInfoCfg[] tOsdInfoCfg;
        /// <summary>
        /// 
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string acResrv;
    }
}
