using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 图文分区播放语音
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQPicAreaSoundHeader_G6
    {
        /// <summary>
        /// 发音人，范围0～5，共6种选择
        /// </summary>
        public byte SoundPerson;
        /// <summary>
        /// 音量，范围0～10
        /// </summary>
        public byte SoundVolum;
        /// <summary>
        /// 语速，范围0～10
        /// </summary>
        public byte SoundSpeed;
        /// <summary>
        /// 语音数据的编码格式
        /// </summary>
        public byte SoundDataMode;
        /// <summary>
        /// 重播次数
        /// </summary>
        public uint SoundReplayTimes;
        /// <summary>
        /// 重播时间间隔
        /// </summary>
        public uint SoundReplayDelay;
        /// <summary>
        /// 语音参数保留参数长度，默认0x03
        /// </summary>
        public byte SoundReservedParaLen;
        /// <summary>
        /// 详情见协议
        /// </summary>
        public byte Soundnumdeal;
        /// <summary>
        /// 详情见协议
        /// </summary>
        public byte Soundlanguages;
        /// <summary>
        /// 详情见协议
        /// </summary>
        public byte Soundwordstyle;
    }
}
