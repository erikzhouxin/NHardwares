using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 图文分区播放语音
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQPicAreaSoundHeader_G6
    {
        public byte SoundPerson;           //发音人，范围0～5，共6种选择
        public byte SoundVolum;            //音量，范围0～10
        public byte SoundSpeed;            //语速，范围0～10
        public byte SoundDataMode;         //语音数据的编码格式
        public uint SoundReplayTimes;      //重播次数
        public uint SoundReplayDelay;      //重播时间间隔
        public byte SoundReservedParaLen;  //语音参数保留参数长度，默认0x03
        public byte Soundnumdeal;          //详情见协议
        public byte Soundlanguages;        //详情见协议
        public byte Soundwordstyle;        //详情见协议
    }
}
