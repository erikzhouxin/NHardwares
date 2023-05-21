using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 节目的播放时段
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQprogrampTime_G56
    {
        /// <summary>
        /// 
        /// </summary>
        public byte StartHour;              
        /// <summary>
        /// 
        /// </summary>
        public byte StartMinute;            
        /// <summary>
        /// 
        /// </summary>
        public byte StartSecond;            
        /// <summary>
        /// 
        /// </summary>
        public byte EndHour;                
        /// <summary>
        /// 
        /// </summary>
        public byte EndMinute;
        /// <summary>
        /// 
        /// </summary>
        public byte EndSecond;
    }
}
