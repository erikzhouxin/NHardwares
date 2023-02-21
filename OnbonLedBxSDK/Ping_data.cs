using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 屏幕数据
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Ping_data
    {
        /// <summary>
        /// 控制器类型
        /// 小端存储低位在前高位在后， 比如 0x254 反着取，低位表示系列，高位编号  [0x54, 0x02] 【系列，编号】
        /// </summary>
        public ushort ControllerType;
        /// <summary>
        /// 固件版本号
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] FirmwareVersion;
        /// <summary>
        /// 控制器参数文件状态 0x00 –控制器中没有参数配置文件，以下返回的是控制器的默认参数。 此时， PC 软件应提示用户必须先加载屏参。0x01 –控制器中有参数配置文件
        /// </summary>
        public byte ScreenParaStatus;
        /// <summary>
        /// 控制器地址
        /// </summary>
        public ushort uAddress;
        /// <summary>
        /// 波特率
        /// </summary>
        public byte Baudrate;
        /// <summary>
        /// 屏宽
        /// </summary>
        public ushort ScreenWidth;
        /// <summary>
        /// 屏高
        /// </summary>
        public ushort ScreenHeight;
        /// <summary>
        /// 显示屏颜色定义
        /// </summary>
        public byte Color;
        /// <summary>
        /// 当前亮度值   整数1-16
        /// </summary>
        public byte CurrentBrigtness;
        /// <summary>
        /// 控制器开关机状态   0 关机  1开机？
        /// </summary>
        public byte CurrentOnOffStatus;
        /// <summary>
        /// 扫描配置编号
        /// </summary>
        public ushort ScanConfNumber;
        /// <summary>
        /// 第一个自己一路数据代几行，其他基本用不上，如有需要可参考协议取相应的字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public byte[] reversed;
        /// <summary>
        /// 控制器ip地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] ipAdder;
    }
}
