using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Ping_data
    {
        // 控制器类型
        //小端存储低位在前高位在后， 比如 0x254 反着取，低位表示系列，高位编号  [0x54, 0x02] 【系列，编号】
        public ushort ControllerType;
        // 固件版本号            
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] FirmwareVersion;
        // 控制器参数文件状态 0x00 –控制器中没有参数配置文件，以下返回的是控制器的默认参数。 此时， PC 软件应提示用户必须先加载屏参。0x01 –控制器中有参数配置文件
        public byte ScreenParaStatus;
        // 控制器地址
        public ushort uAddress;
        // 波特率
        public byte Baudrate;
        // 屏宽
        public ushort ScreenWidth;
        // 屏高
        public ushort ScreenHeight;
        // 显示屏颜色定义
        public byte Color;
        //当前亮度值   整数1-16
        public byte CurrentBrigtness;
        // 控制器开关机状态   0 关机  1开机？
        public byte CurrentOnOffStatus;
        // 扫描配置编号
        public ushort ScanConfNumber;
        // 第一个自己一路数据代几行，其他基本用不上，如有需要可参考协议取相应的字节
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public byte[] reversed;
        // 控制器ip地址
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] ipAdder;
    }
}
