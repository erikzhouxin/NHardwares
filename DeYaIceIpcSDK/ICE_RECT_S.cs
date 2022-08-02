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
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ICE_RECT_S
    {
        /// <summary>
        /// letf x
        /// </summary>
        public short s16Left;
        /// <summary>
        /// top y
        /// </summary>
        public short s16Top;
        /// <summary>
        /// right x
        /// </summary>
        public short s16Right;
        /// <summary>
        /// bottom y
        /// </summary>
        public short s16Bottom;
    }
}
