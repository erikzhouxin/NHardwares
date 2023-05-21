using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQprogramHeader
    {
        /// <summary>
        /// 文件类型
        /// 默认：0x00
        /// LOGO文件:0x08
        /// 扫描配置文件:0x02
        /// 日志文件:0x06
        /// 字库文件:0x05
        /// 提示信息库文件: 0x07
        /// </summary>
        public byte FileType;
        /// <summary>
        /// 节目ID
        /// </summary>
        public uint ProgramID;
        /// <summary>
        /// 节目类型
        /// Bit0 –全局节目标志位
        /// Bit1 –动态节目标志位
        /// Bit2 –屏保节目标志位
        /// </summary>
        public byte ProgramStyle;

        /// <summary>
        /// 节目等级
        /// 注:带播放时段的节目优先级为 1，不 带播放时段的节目优先级为 0
        /// </summary>
        public byte ProgramPriority;
        /// <summary>
        /// 节目重播放次数
        /// </summary>
        public byte ProgramPlayTimes;
        /// <summary>
        /// 播放的方式
        /// </summary>
        public ushort ProgramTimeSpan;
        /// <summary>
        /// 节目星期属性
        /// </summary>
        public byte ProgramWeek;
        /// <summary>
        /// 年
        /// </summary>
        public ushort ProgramLifeSpan_sy;
        /// <summary>
        /// 月
        /// </summary>
        public byte ProgramLifeSpan_sm;
        /// <summary>
        /// 日
        /// </summary>
        public byte ProgramLifeSpan_sd;
        /// <summary>
        /// 结束年
        /// </summary>
        public ushort ProgramLifeSpan_ey;
        /// <summary>
        /// 结束日
        /// </summary>
        public byte ProgramLifeSpan_em;
        /// <summary>
        /// 结束天
        /// </summary>
        public byte ProgramLifeSpan_ed;
        ///// <summary>
        ///// 播放时段的组数
        ///// </summary>
        //public byte PlayPeriodGrpNum;
    }
    /// <summary>
    /// 6代节目头模型
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQprogramHeader_G6
    {
        /// <summary>
        /// 文件类型
        /// 默认：0x00
        /// LOGO文件:0x08
        /// 扫描配置文件:0x02
        /// 日志文件:0x06
        /// 字库文件:0x05
        /// 提示信息库文件: 0x07
        /// </summary>
        public byte FileType;
        /// <summary>
        /// 节目ID
        /// </summary>
        public uint ProgramID;
        /// <summary>
        /// 节目类型
        /// Bit0 –全局节目标志位
        /// Bit1 –动态节目标志位
        /// Bit2 –屏保节目标志位
        /// </summary>
        public byte ProgramStyle;
        /// <summary>
        /// 节目等级
        /// 注:带播放时段的节目优先级为 1，不带播放时段的节目优先级为 0
        /// </summary>
        public byte ProgramPriority;
        /// <summary>
        /// 节目重播放次数
        /// </summary>
        public byte ProgramPlayTimes;
        /// <summary>
        /// 播放的方式
        /// </summary>
        public ushort ProgramTimeSpan;
        /// <summary>
        /// 特殊节目标
        /// </summary>
        public byte SpecialFlag;
        /// <summary>
        /// 扩展参数长度，默认为0x00
        /// </summary>
        public byte CommExtendParaLen;
        /// <summary>
        /// 节目调度  
        /// </summary>
        public ushort ScheduNum;
        /// <summary>
        /// 调度规则循环次数
        /// </summary>
        public ushort LoopValue;
        /// <summary>
        /// 调度相关
        /// </summary>
        public byte Intergrate;
        /// <summary>
        /// 时间属性组数
        /// </summary>
        public byte TimeAttributeNum;
        /// <summary>
        /// 第一组时间属性偏移量--目前只支持一组
        /// </summary>
        public ushort TimeAttribute0Offset;
        /// <summary>
        /// 节目星期属性
        /// </summary>
        public byte ProgramWeek;
        /// <summary>
        /// 年
        /// </summary>
        public ushort ProgramLifeSpan_sy;
        /// <summary>
        /// 月
        /// </summary>
        public byte ProgramLifeSpan_sm;
        /// <summary>
        /// 日
        /// </summary>
        public byte ProgramLifeSpan_sd;
        /// <summary>
        /// 结束年
        /// </summary>
        public ushort ProgramLifeSpan_ey;
        /// <summary>
        /// 结束日
        /// </summary>
        public byte ProgramLifeSpan_em;
        /// <summary>
        /// 结束天
        /// </summary>
        public byte ProgramLifeSpan_ed;
        /// <summary>
        /// 播放时段的组数
        /// </summary>
        public byte PlayPeriodGrpNum;
    }
}
