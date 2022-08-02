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
    public struct T_M_SubLedSetup
    {
        /// <summary>
        /// ICE_U8->unsigned char
        /// </summary>
        public byte ucContentEnable;

        /// <summary>
        /// ICE_U8->unsigned char
        /// </summary>
        public byte ucVehTypeEnable;

        /// <summary>
        /// ICE_U8->unsigned char
        /// </summary>
        public byte ucPlateEnable;

        /// <summary>
        /// ICE_U8->unsigned char
        /// </summary>
        public byte ucLeftDaysEnable;

        /// <summary>
        /// ICE_U8->unsigned char
        /// </summary>
        public byte ucParkPay;

        /// <summary>
        /// ICE_U8->unsigned char
        /// </summary>
        public byte ucParkLastTime;

        /// <summary>
        /// ICE_U8->unsigned char
        /// </summary>
        public byte ucTmpCardColor;

        /// <summary>
        /// ICE_U8->unsigned char
        /// </summary>
        public byte ucMonthCardColor;

        /// <summary>
        /// ICE_U8[64]
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string aucContent;

        /// <summary>
        /// ICE_U8[10]
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string aucReserved;
    }
}
