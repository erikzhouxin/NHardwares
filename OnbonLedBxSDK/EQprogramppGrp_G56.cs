using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQprogramppGrp_G56
    {
        public byte playTimeGrpNum; //播放时间有效组数 0 没有播放时段全天播放 最大值8 
        public EQprogrampTime_G56 timeGrp0;
        public EQprogrampTime_G56 timeGrp1;
        public EQprogrampTime_G56 timeGrp2;
        public EQprogrampTime_G56 timeGrp3;
        public EQprogrampTime_G56 timeGrp4;
        public EQprogrampTime_G56 timeGrp5;
        public EQprogrampTime_G56 timeGrp6;
        public EQprogrampTime_G56 timeGrp7;
    };//播放时段共有8组
}
