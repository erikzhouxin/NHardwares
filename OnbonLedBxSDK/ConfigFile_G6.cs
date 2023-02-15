using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ConfigFile_G6
    {
        public byte FileType; //文件类型
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] ControllerName; // 控制器名称
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        byte[] ScreenAddress; //屏幕安装地址限制为 24个字节长度
        ushort Address; //控制器地址
        public byte Baudrate; /* 串口波特率 
						     0x00 –保持原有波特率不变
						     0x01 –强制设置为 9600
						     0x02 –强制设置为 57600*/
        ushort ScreenWidth; //显示屏宽度
        ushort ScreenHeight; // 显示屏高度
        public byte Color; /* 显示屏颜色定义 Bit0 表示红， bit1 表示绿， bit2 表示
					         蓝， 对于每一个 Bit， 0 表示灭， 1 表示亮*/
        public byte modeofdisp; // 6Q 系列显示模式： 0为888, 1为565，对其余控制卡该字节为0
        public byte TipLanguage; //0 表示上位机软件是中文版，底层固件在显示提示信息时需调用内置的中文提示信息
                                 //1 表示上位机软件是英文版，底层固件在显示提示信息时需调用内置的英文提示信息
                                 //255 表示上位机软件是其他语言版，底层固件在显示提示信息时需调用自定义提示信息
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] Reserved; // 5个备用字节
        public byte FaultProcessMode; /*控制器的错误处理模式
0x00 –自动处理
0x01 –手动处理(此模式仅供调试人员使用)*/
        public byte CommTimeoutValue; /*通讯超时设置（单位秒）
建议值：
串口– 2S
TCP/IP – 6S
GPRS – 30S*/
        public byte RunningMode; /* 控制器运行模式，具体定义如下：
0x00 –正常模式
0x01 –调试模式*/
        public byte LoggingMode; /*日志记录模式
0x00 –无日志
0x01 –只对控制器错误及对错误进行
的错误进行记录
0x02 –对控制器的所有操作进行记
录， 包括： 控制器接收的各条指令、
发生的错误及错误处理*/
        public byte DevideScreenMode; /*针对 6Q2 卡的分屏模式
对其余的卡为保留字节 0*/
        public byte Reserved2; //备用字节
        public byte Default_brightness;  /*AX 系列控制器专用，表示上电时，默
认的亮度等级值。其余的控制卡该字
节为保留字 0*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] Backup; // 备用值字节
        public ushort CRC16; //整个文件的 CRC16 校验
    };
}
