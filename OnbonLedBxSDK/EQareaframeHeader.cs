using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 区域边框
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQareaframeHeader
    {
        /// <summary>
        /// 区域边框标志位
        /// 注：如果此字段为 0x00，则以下区域边框属性不发送
        /// </summary>
        public byte AreaFFlag;
        /// <summary>
        /// 边框显示方式：
        /// 0x00 –闪烁
        /// 0x01 –顺时针转动
        /// 0x02 –逆时针转动
        /// 0x03 –闪烁加顺时针转动
        /// 0x04 –闪烁加逆时针转动
        /// 0x05 –红绿交替闪烁
        /// 0x06 –红绿交替转动
        /// 0x07 –静止打出
        /// <see cref="E_FrameDisplayMode"/>
        /// </summary>
        public byte AreaFDispStyle;
        /// <summary>
        /// 边框显示速度
        /// </summary>
        public byte AreaFDispSpeed;
        /// <summary>
        /// 边框移动步长，单位为点，此参数范围为 1~16
        /// </summary>
        public byte AreaFMoveStep;
        /// <summary>
        /// 边框组元宽度，此参数范围为 1~8 注：边框组元的长度固定为 16
        /// </summary>
        public byte AreaFWidth;
        /// <summary>
        /// 备用字
        /// </summary>
        public ushort AreaFBackup;
    }
    /// <summary>
    /// 区域头边框
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQareaframeHeader_6G
    {
        /// <summary>
        /// 区域边框标志位
        /// 注：如果此字段为 0x00，则以下区域边框属性不发送
        /// </summary>
        public byte AreaFFlag;
        /// <summary>
        /// 边框显示方式：
        /// 0x00 –闪烁
        /// 0x01 –顺时针转动
        /// 0x02 –逆时针转动
        /// 0x03 –闪烁加顺时针转动
        /// 0x04 –闪烁加逆时针转动
        /// 0x05 –红绿交替闪烁
        /// 0x06 –红绿交替转动
        /// 0x07 –静止打出
        /// <see cref="E_FrameDisplayMode"/>
        /// </summary>
        public byte AreaFDispStyle;
        /// <summary>
        /// 边框显示速度
        /// </summary>
        public byte AreaFDispSpeed;
        /// <summary>
        /// 边框移动步长，单位为点，此参数范围为 1~16
        /// </summary>
        public byte AreaFMoveStep;
        /// <summary>
        /// 边框组员长度
        /// </summary>
        public byte AreaDLength;
        /// <summary>
        /// 边框组元宽度，此参数范围为 1~8 注：边框组元的长度固定为 16
        /// </summary>
        public byte AreaFWidth;
        /// <summary>
        /// 备用字
        /// </summary>
        public ushort AreaFBackup;
        /// <summary>
        /// 边框组员数据，格式同图文区
        /// </summary>
        public byte[] AreaFUnitData;
    }
}
