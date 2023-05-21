using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQareaHeader
    {
        /// <summary>
        /// 区域类型
        /// 字库区域:0x01
        /// 透明文本：0x06
        /// 时间区:0x02
        /// 图文字幕:0x00
        /// 战斗时间：0x09
        /// 噪声区：0x05
        /// 温度区：0x03
        /// 霓虹区：0x08
        /// 湿度区：0x04
        /// </summary>
        public byte AreaType; 
        /// <summary>
        /// 区域X坐标
        /// </summary>
        public ushort AreaX; 
        /// <summary>
        /// 区域Y坐标
        /// </summary>
        public ushort AreaY; 
        /// <summary>
        /// 区域宽
        /// </summary>
        public ushort AreaWidth; 
        /// <summary>
        /// 区域高
        /// </summary>
        public ushort AreaHeight;
    }
    /// <summary>
    /// 6代区域头
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQareaHeader_G6
    {
        /// <summary>
        /// 区域类型
        /// </summary>
        public byte AreaType;
        /// <summary>
        /// 区域左上角横坐标
        /// </summary>
        public ushort AreaX;
        /// <summary>
        /// 区域左上角纵坐标
        /// </summary>
        public ushort AreaY;
        /// <summary>
        /// 区域宽度
        /// </summary>
        public ushort AreaWidth;
        /// <summary>
        /// 区域高度
        /// </summary>
        public ushort AreaHeight;
        /// <summary>
        /// 是否有背景
        /// </summary>
        public byte BackGroundFlag;
        /// <summary>
        /// 透明度
        /// </summary>
        public byte Transparency;
        /// <summary>
        /// 前景、背景区域大小是否相同
        /// </summary>
        public byte AreaEqual;
        /// <summary>
        /// 语音内容
        /// 使用语音功能时：部分卡需要配置串口为语音模式！！！
        /// </summary>
        public EQSound_6G stSoundData;
    }
}
