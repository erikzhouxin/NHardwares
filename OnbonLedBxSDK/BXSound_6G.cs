using System.Runtime.InteropServices;
namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct BXSound_6G
    {
        public byte SoundFlag;        //1 0x00 是否使能语音播放;0 表示不使能语音; 1 表示播放下文中 SoundData 部分内容;
                                      //SoundData 部分内容---------------------------------------------------------------------------------------------------------------------------------------------------
        public byte SoundPerson;      //1 0x00 发音人 该值范围是 0 - 5，共 6 种选择只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 0
        public byte SoundVolum;       //1 0x05 音量该值范围是 0~10，共 11 种，0表示静音只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 5
        public byte SoundSpeed;       //1 0x05 语速该值范围是 0~10，共 11 种只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 5
        public byte SoundDataMode;    //1 0x00 SoundData 的编码格式：该值意义如下：0x00 GB2312; 0x01 GBK; 0x02 BIG5; 0x03 UNICODE只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
        public int SoundReplayTimes;    // 4 0x00000000 重播次数该值为 0，表示播放 1 次该值为 1，表示播放 2 次
                                        //......
                                        //该值为 0xffffffff，表示播放无限次只有 SoundFlag（是否使能语播放）为 1 时才发送该字节，否则不发送该值默认为 0
        public int SoundReplayDelay;// 4 0x00000000 重播时间间隔该值表示两次播放语音的时间间隔，单位为 10ms只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 0
        public byte SoundReservedParaLen;// 1 0x03 语音参数保留参数长度
        public byte Soundnumdeal;     // 1 0 0：自动判断1：数字作号码处理 2：数字作数值处理只有当 SoundFlag 为 1 且SoundReservedParaLen不为 0才发送此参数
        public byte Soundlanguages;   // 1 0 0：自动判断语种1：阿拉伯数字、度量单位、特殊符号等合成为中文2：阿拉伯数字、度量单位、特殊符号等合成为英文只有当 SoundFlag 为 1 且 SoundReservedParaLen不为 0才发送此参数（目前只支持中英文）
        public byte Soundwordstyle;   // 1 0 0：自动判断发音方式1：字母发音方式2：单词发音方式；只有当 SoundFlag 为 1 且SoundReservedParaLen不为 0才发送此参数
        public int SoundDataLen;   // 4 语音数据长度; 只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
        public IntPtr SoundData;      // N 语音数据只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
    };/*这个语音结构体BXSound_6G仅在动态区时使用；图文分区播放语音请使用：EQPicAreaSoundHeader_G6;*/
}
