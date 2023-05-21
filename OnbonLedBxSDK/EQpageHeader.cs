using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 请参考协议 图文字幕区数据格式
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQpageHeader
    {
        /// <summary>
        /// 数据页类型
        /// </summary>
        public byte PageStyle;
        /// <summary>
        /// 显示方式 （特效）
        /// </summary>
        public byte DisplayMode;
        /// <summary>
        /// 退出方式/清屏方式
        /// </summary>
        public byte ClearMode;
        /// <summary>
        /// 速度等级/背景速度等级
        /// </summary>
        public byte Speed;
        /// <summary>
        /// 停留时间， 单位为 10ms
        /// </summary>
        public ushort StayTime;
        /// <summary>
        /// 重复次数/背景拼接步长(左右拼接下为宽度， 上下拼接为高度)
        /// </summary>
        public byte RepeatTime;
        /// <summary>
        /// 用法比较复杂请参考协议
        /// </summary>
        public ushort ValidLen;
        /// <summary>
        /// 排列方式--单行多行
        /// </summary>
        public E_arrMode arrMode;
        /// <summary>
        /// 字体大小
        /// </summary>
        public ushort fontSize;
        /// <summary>
        /// 字体颜色
        /// </summary>
        public uint color;
        /// <summary>
        /// 是否为粗体
        /// </summary>
        public byte fontBold;
        /// <summary>
        /// 是否为斜体
        /// </summary>
        public byte fontItalic;
        /// <summary>
        /// 文字方向
        /// </summary>
        public E_txtDirection tdirection;
        /// <summary>
        /// 文字间隔  
        /// </summary>
        public ushort txtSpace;
        /// <summary>
        /// 
        /// </summary>
        public byte Valign;
        /// <summary>
        /// 
        /// </summary>
        public byte Halign;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQpageHeader_G6
    {
        /// <summary>
        /// 数据页类型
        /// </summary>
        public byte PageStyle;
        /// <summary>
        /// 显示方式
        /// 0x00 –随机显示
        /// 0x01 –静止显示
        /// 0x02 –快速打出
        /// 0x03 –向左移动
        /// 0x04 –向左连移
        /// 0x05 –向上移动
        /// 0x06 –向上连移
        /// 0x07 –闪烁
        /// 0x08 –飘雪
        /// 0x09 –冒泡
        /// 0x0a –中间移出
        /// 0x0b –左右移入
        /// 0x0c –左右交叉移入
        /// 0x0d –上下交叉移入
        /// 0x0e –画卷闭合
        /// 0x0f –画卷打开
        /// 0x10 –向左拉伸
        /// 0x11 –向右拉伸
        /// 0x12 –向上拉伸
        /// 0x13 –向下拉伸
        /// 0x14 –向左镭射
        /// 0x15 –向右镭射
        /// 0x16 –向上镭射
        /// 0x17 –向下镭射
        /// 0x18 –左右交叉拉幕
        /// 0x19 –上下交叉拉幕
        /// 0x1a –分散左拉
        /// 0x1b –水平百页
        /// 0x1c –垂直百页
        /// 0x1d –向左拉幕
        /// 0x1e –向右拉幕
        /// 0x1f –向上拉幕
        /// 0x20 –向下拉幕
        /// 0x21 –左右闭合
        /// 0x22 –左右对开
        /// 0x23 –上下闭合
        /// 0x24 –上下对开
        /// 0x25 –向右移动
        /// 0x26 –向右连移
        /// 0x27 –向下移动
        /// 0x28 –向下连移
        /// 0x29 –45 度左旋
        /// 0x2a–180 度左旋
        /// 0x2b–90 度左旋
        /// 0x2c–45 度右旋
        /// 0x2d–180 度右旋
        /// 0x2e–90 度右旋
        /// 0x2f –菱形打开
        /// 0x30–菱形闭合
        /// <see cref="E_DisplayMode"/>
        /// </summary>
        public byte DisplayMode;
        /// <summary>
        /// 退出方式/清屏方式
        /// </summary>
        public byte ClearMode;
        /// <summary>
        /// 速度等级
        /// </summary>
        public byte Speed;
        /// <summary>
        /// 停留时间
        /// </summary>
        public ushort StayTime;
        /// <summary>
        /// 重复次数
        /// </summary>
        public byte RepeatTime;
        /// <summary>
        /// 此字段只在左移右移方式下有效
        /// </summary>
        public ushort ValidLen;
        /// <summary>
        /// 特技为动画方式时，该值代表其帧率
        /// </summary>
        public byte CartoonFrameRate;
        /// <summary>
        /// 背景无效标志
        /// </summary>
        public byte BackNotValidFlag;
        /// <summary>
        /// 排列方式--单行多行
        /// </summary>
        public E_arrMode arrMode;
        /// <summary>
        /// 字体大小
        /// </summary>
        public ushort fontSize;
        /// <summary>
        /// 字体颜色
        /// </summary>
        public uint color;
        /// <summary>
        /// 是否为粗体 0:false 1:true
        /// </summary>
        public byte fontBold;
        /// <summary>
        /// 是否为斜体
        /// </summary>
        public byte fontItalic;
        /// <summary>
        /// 文字方向
        /// </summary>
        public E_txtDirection tdirection;
        /// <summary>
        /// 文字间隔  
        /// </summary>
        public ushort txtSpace;
        /// <summary>
        /// 
        /// </summary>
        public byte Valign;
        /// <summary>
        /// 
        /// </summary>
        public byte Halign;
    }
}
