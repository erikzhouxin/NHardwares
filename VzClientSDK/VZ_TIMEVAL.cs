﻿using System.Data.Extter;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 时间值
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_TIMEVAL
    {
        /// <summary>
        /// 秒数
        /// </summary>
        public uint uTVSec;
        /// <summary>
        /// 微秒
        /// </summary>
        public uint uTVUSec;
    }
}
