using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 配置文件
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ConfigFile
    {
        /// <summary>
        /// 文件类型
        /// </summary>
        public byte FileType;
        /// <summary>
        /// 控制器名称
        /// </summary>
        public byte[] ControllerName;
        /// <summary>
        /// 控制器地址
        /// </summary>
        public ushort Address;
        /// <summary>
        /// 串口波特率 
        /// 0x00 –保持原有波特率不变
        /// 0x01 –强制设置为 9600
        /// 0x02 –强制设置为 57600
        /// </summary>
        public byte Baudrate;
        /// <summary>
        /// 显示屏宽度
        /// </summary>
        public ushort ScreenWidth;
        /// <summary>
        /// 显示屏高度
        /// </summary>
        public ushort ScreenHeight;
        /// <summary>
        /// 显示屏颜色定义 Bit0 表示红， bit1 表示绿， bit2 表示蓝， 对于每一个 Bit， 0 表示灭， 1 表示亮
        /// </summary>
        public byte Color;
        /// <summary>
        /// 0x00 –无镜向 0x01 –镜向
        /// </summary>
        public byte MirrorMode;
        /// <summary>
        /// OE 极性，0x00 – OE 低有效   0x01 – OE 高有效
        /// </summary>
        public byte OEPol;
        /// <summary>
        /// 数据极性， 0x00 –数据低有效， 0x01 –数据高有效
        /// </summary>
        public byte DAPol;
        /// <summary>
        /// 行序模式， 该值范围为 0-31
        /// 0-15 代表正序
        /// 0 代表从第 0 行开始顺序扫描
        /// 1 代表从第 1 行开始顺序扫描
        /// .....
        /// 16-31 代表逆序
        /// 0 代表从第 0 行开始逆序扫描
        /// 1 代表从第 1 行开始逆序扫描
        /// </summary>
        public byte RowOrder;
        /// <summary>
        /// CLK 分频倍数
        /// 注意： 针对于 AX 系列， 为后级分频数值为 0~15， 共 16 个等级。
        /// </summary>
        public byte FreqPar;
        /// <summary>
        /// OE 宽度
        /// </summary>
        public byte OEWidth;
        /// <summary>
        /// OE 提前角
        /// </summary>
        public byte OEAngle;
        /// <summary>
        /// 控制器的错误处理模式
        /// 0x00 –自动处理
        /// 0x01 –手动处理(此模式仅供调试人员使用)
        /// </summary>
        public byte FaultProcessMode;
        /// <summary>
        /// 通讯超时设置（单位秒）
        /// 建议值：
        /// 串口– 2S
        /// TCP/IP – 6S
        /// GPRS – 30S
        /// </summary>
        public byte CommTimeoutValue;
        /// <summary>
        /// 控制器运行模式， 具体定义如下：
		/// 0x00 –正常模式
		/// 0x01 –调试模式
        /// </summary>
        public byte RunningMode;
        /// <summary>
        /// 日志记录模式
        /// 0x00 –无日志
        /// 0x01 –只对控制器错误及对错误进行的错误进行记录
        /// 0x02 –对控制器的所有操作进行记录， 包括： 控制器接收的各条指令、发生的错误及错误处理
        /// </summary>
        public byte LoggingMode;
        /// <summary>
        /// 灰度标志(仅 5Q 卡时有该字节)
        /// 0x00–无灰度
        /// 0x01–灰度
        /// </summary>
        public byte GrayFlag;
        /// <summary>
        /// 级联模式： (仅 5Q 卡时有该字节)
        /// 0x00–非级联模式
        /// 0x01–级联模式
        /// </summary>
        public byte CascadeMode;
        /// <summary>
        /// AX 系列控制器专用， 表示上电时， 默认的亮度等级值。 
        /// 根据不同的屏幕类型有所不同。
        /// </summary>
        public byte Default_brightness;
        /// <summary>
        /// HUB 板设置(仅 6E 控制器支持)
        /// 0x00–HUB512 默认项
        /// 0x01–HUB256
        /// </summary>
        public byte HUBConfig;
        /// <summary>
        /// 控制器多语言显示区。
        /// 0x00 ----简体中文显示。
        /// 0x01 ----非中文显示， 控制器显示图形加英文字符。
        /// 其他值保留。
        /// </summary>
        public byte Language;
        /// <summary>
        /// 备用字节
        /// </summary>
        public byte Backup;
        /// <summary>
        /// 整个文件的 CRC16 校验
        /// </summary>
        public ushort CRC16;
    }
    /// <summary>
    /// 配置文件
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ConfigFile_G6
    {
        /// <summary>
        /// 文件类型
        /// </summary>
        public byte FileType;
        /// <summary>
        /// 控制器名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] ControllerName;
        /// <summary>
        /// 屏幕安装地址限制为 24个字节长度
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        byte[] ScreenAddress;
        /// <summary>
        /// 控制器地址
        /// </summary>
        ushort Address;
        /// <summary>
        /// 串口波特率 
        /// 0x00 –保持原有波特率不变
        /// 0x01 –强制设置为 9600
        /// 0x02 –强制设置为 57600
        /// </summary>
        public byte Baudrate;
        /// <summary>
        /// 显示屏宽度
        /// </summary>
        ushort ScreenWidth;
        /// <summary>
        /// 显示屏高度
        /// </summary>
        ushort ScreenHeight;
        /// <summary>
        /// 显示屏颜色定义 Bit0 表示红， bit1 表示绿， bit2 表示蓝， 对于每一个 Bit， 0 表示灭， 1 表示亮
        /// </summary>
        public byte Color;
        /// <summary>
        /// 6Q 系列显示模式： 0为888, 1为565，对其余控制卡该字节为0
        /// </summary>
        public byte modeofdisp;
        /// <summary>
        /// 0 表示上位机软件是中文版，底层固件在显示提示信息时需调用内置的中文提示信息
        /// 1 表示上位机软件是英文版，底层固件在显示提示信息时需调用内置的英文提示信息
        /// 255 表示上位机软件是其他语言版，底层固件在显示提示信息时需调用自定义提示信息
        /// </summary>
        public byte TipLanguage;
        /// <summary>
        /// 5个备用字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] Reserved;
        /// <summary>
        /// 控制器的错误处理模式
        /// 0x00 –自动处理
        /// 0x01 –手动处理(此模式仅供调试人员使用)
        /// </summary>
        public byte FaultProcessMode;
        /// <summary>
        /// 通讯超时设置（单位秒）
        /// 建议值：
        /// 串口– 2S
        /// TCP/IP – 6S
        /// GPRS – 30S
        /// </summary>
        public byte CommTimeoutValue;
        /// <summary>
        /// 控制器运行模式，具体定义如下：
        /// 0x00 –正常模式
        /// 0x01 –调试模式
        /// </summary>
        public byte RunningMode;
        /// <summary>
        /// 日志记录模式
        /// 0x00 –无日志
        /// 0x01 –只对控制器错误及对错误进行的错误进行记录
        /// 0x02 –对控制器的所有操作进行记录， 包括： 控制器接收的各条指令、发生的错误及错误处理
        /// </summary>
        public byte LoggingMode;
        /// <summary>
        /// 针对 6Q2 卡的分屏模式
        /// 对其余的卡为保留字节0
        /// </summary>
        public byte DevideScreenMode;
        /// <summary>
        /// 备用字节
        /// </summary>
        public byte Reserved2;
        /// <summary>
        /// AX 系列控制器专用，表示上电时，默认的亮度等级值。其余的控制卡该字节为保留字 0
        /// </summary>
        public byte Default_brightness;
        /// <summary>
        /// 备用值字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] Backup;
        /// <summary>
        /// 整个文件的 CRC16 校验
        /// </summary>
        public ushort CRC16;
    };
}
