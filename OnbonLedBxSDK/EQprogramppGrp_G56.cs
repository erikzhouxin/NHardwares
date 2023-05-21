using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 播放时段共有8组
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQprogramppGrp_G56
    {
        /// <summary>
        /// 播放时间有效组数 0 没有播放时段全天播放 最大值8 
        /// </summary>
        public byte playTimeGrpNum; 
        /// <summary>
        /// 
        /// </summary>
        public EQprogrampTime_G56 timeGrp0;
        /// <summary>
        /// 
        /// </summary>
        public EQprogrampTime_G56 timeGrp1;
        /// <summary>
        /// 
        /// </summary>
        public EQprogrampTime_G56 timeGrp2;
        /// <summary>
        /// 
        /// </summary>
        public EQprogrampTime_G56 timeGrp3;
        /// <summary>
        /// 
        /// </summary>
        public EQprogrampTime_G56 timeGrp4;
        /// <summary>
        /// 
        /// </summary>
        public EQprogrampTime_G56 timeGrp5;
        /// <summary>
        /// 
        /// </summary>
        public EQprogrampTime_G56 timeGrp6;
        /// <summary>
        /// 
        /// </summary>
        public EQprogrampTime_G56 timeGrp7;
    }
}
