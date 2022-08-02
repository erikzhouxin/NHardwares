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
    public struct T_SubLedSetup
    {

        /// <summary>
        /// ICE_U8->unsigned char
        /// </summary>
        public byte ucContentEnable;

        /// <summary>
        /// ICE_U8->unsigned char
        /// </summary>
        public byte ucTimeEnable;

        /// <summary>
        /// ICE_U8->unsigned char
        /// </summary>
        public byte ucInterval;

        /// <summary>
        /// ICE_U8[64]
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string aucContent;

        /// <summary>
        /// ICE_U8->unsigned char
        /// </summary>
        public byte ucColor;

        /// <summary>
        /// ICE_U8->unsigned char
        /// </summary>
        public byte ucLeftVehEnable;

        /// <summary>
        /// ICE_U8[9]
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string aucReserved;
    }
}
