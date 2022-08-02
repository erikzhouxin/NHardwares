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
    public struct ICE_OFFLINE_LED_CONFIG
    {

        /// <summary>
        /// E_LedScreenType->Anonymous_7fc14953_d8c0_4049_9fe6_366a6d28c45c
        /// </summary>
        public E_LedScreenType sreenType;

        /// <summary>
        /// ICE_U32->unsigned int
        /// </summary>
        public uint screenMode;

        /// <summary>
        /// ICE_U32->unsigned int
        /// </summary>
        public uint cameraType;

        /// <summary>
        /// ICE_U8->unsigned char
        /// </summary>
        public byte ucAudioEnable;

        /// <summary>
        /// ICE_U8[3]
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string ucReserved;

        /// <summary>
        /// T_SubLedSetup[4]
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
        public T_SubLedSetup[] atSubLedInIdle;

        /// <summary>
        /// T_M_SubLedSetup[4]
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
        public T_M_SubLedSetup[] atSubLedInBusy;

        /// <summary>
        /// T_M_AudioLedSetup->Anonymous_3559f5f9_650c_4a60_a408_da1c05ccff7e
        /// </summary>
        public T_M_AudioLedSetup atSubLedInBusyAudio;

        /// <summary>
        /// T_SubLedSetup[4]
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
        public T_SubLedSetup[] atSubLedOutIdle;

        /// <summary>
        /// T_M_SubLedSetup[4]
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
        public T_M_SubLedSetup[] atSubLedOutBusy;

        /// <summary>
        /// T_M_AudioLedSetup->Anonymous_3559f5f9_650c_4a60_a408_da1c05ccff7e
        /// </summary>
        public T_M_AudioLedSetup atSubLedOutBusyAudio;
        /// <summary>
        /// 
        /// </summary>
        public uint uc485ctrlEnable;
        /// <summary>
        /// 
        /// </summary>
        public uint ucLeftVehPlace;
        /// <summary>
        /// 
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 92)]
        public string aucReserved;
    }
}
