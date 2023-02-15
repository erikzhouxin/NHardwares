using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQareaHeader_G6
    {
        public byte AreaType;       //区域类型
        public ushort AreaX;            //区域左上角横坐标
        public ushort AreaY;            //区域左上角纵坐标
        public ushort AreaWidth;        //区域宽度
        public ushort AreaHeight;       //区域高度
        public byte BackGroundFlag; //是否有背景
        public byte Transparency;   //透明度
        public byte AreaEqual;      //前景、背景区域大小是否相同

        //语音内容
        //使用语音功能时：部分卡需要配置串口为语音模式！！！
        public EQSound_6G stSoundData;
    }
}
