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
    public struct ice_uart
    {
        /// <summary>
        /// 
        /// </summary>
        public int uartEn;
        /// <summary>
        /// 
        /// </summary>
        public int uartWorkMode;
        /// <summary>
        /// 
        /// </summary>
        public int baudRate;
        /// <summary>
        /// 
        /// </summary>
        public int dataBits;
        /// <summary>
        /// 
        /// </summary>
        public int parity;
        /// <summary>
        /// 
        /// </summary>
        public int stopBits;
        /// <summary>
        /// 
        /// </summary>
        public int flowControl;
        /// <summary>
        /// 
        /// </summary>
        public int LEDControlCardType;
        /// <summary>
        /// 
        /// </summary>
        public int LEDBusinessType;
        /// <summary>
        /// 
        /// </summary>
        public int u32UartProcOneReSendCnt;
        /// <summary>
        /// 
        /// </summary>
        public byte screen_mode;
        /// <summary>
        /// 
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string as32Reserved;
    }
}
