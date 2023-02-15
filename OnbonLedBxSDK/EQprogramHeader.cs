using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQprogramHeader
    {
        /*
         默认：0x00
         LOGO文件:0x08
         扫描配置文件:0x02
         日志文件:0x06
         字库文件:0x05
         提示信息库文件: 0x07
         */
        public byte FileType; //文件类型
        public uint ProgramID;//节目ID

        /*
         Bit0 –全局节目标志位
         Bit1 –动态节目标志位
         Bit2 –屏保节目标志位
         */
        public byte ProgramStyle;//节目类型

        //注:带播放时段的节目优先级为 1，不 带播放时段的节目优先级为 0
        public byte ProgramPriority; //节目等级
        public byte ProgramPlayTimes;//节目重播放次数
        public ushort ProgramTimeSpan; //播放的方式
        public byte ProgramWeek;      //节目星期属性
        public ushort ProgramLifeSpan_sy;//年
        public byte ProgramLifeSpan_sm;//月
        public byte ProgramLifeSpan_sd;//日
        public ushort ProgramLifeSpan_ey;//结束年
        public byte ProgramLifeSpan_em;//结束日
        public byte ProgramLifeSpan_ed;//结束天
                                       //public byte PlayPeriodGrpNum;//播放时段的组数
    }
}
