using System.Diagnostics;
using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 网络搜索结果
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct NetSearchCmdRet_Web
    {
        ///// <summary>
        ///// 1 0xA4 命令组 
        ///// </summary>
        //public byte CmdGroup;
        ///// <summary>
        ///// 1 0x83 命令编号
        ///// </summary>
        //public byte Cmd;
        ///// <summary>
        ///// 2 控制器状态
        ///// </summary>
        //public byte Status;
        ///// <summary>
        ///// 2 错误状态寄存器
        ///// </summary>
        //public ushort Error;
        ///// <summary>
        ///// 2 0xA4 数据长度
        ///// </summary>
        //public ushort DataLen;
        /// <summary>
        /// 6 Mac 地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] Mac = new byte[6];
        /// <summary>
        /// 4 控制器 IP 地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] IP = new byte[4];
        /// <summary>
        /// 4 子网掩码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] SubNetMask = new byte[4];
        /// <summary>
        /// 4 网关
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Gate = new byte[4];
        /// <summary>
        /// 2 端口
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Port = new byte[2];
        /// <summary>
        /// 1 1 表示 DHCP 2 表示手动设置
        /// </summary>
        public byte IPMode;
        /// <summary>
        /// 1 0 表示 IP 设置失败 1 表示 IP 设置成功
        /// </summary>
        public byte IPStatus;
        /// <summary>
        /// 1 0 Bit[0]表示服务器模式是否使能：1 –使能，0 –禁止 Bit[1]表示服务器模式：1 –web 模式，0 –普通模式
        /// </summary>
        public byte ServerMode;
        /// <summary>
        /// 4 服务器 IP 地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] ServerIPAddress = new byte[4];
        /// <summary>
        /// 2 服务器端口号
        /// </summary>
        public ushort ServerPort;
        /// <summary>
        /// 8 服务器访问密码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] ServerAccessPassword = new byte[8];
        /// <summary>
        /// 2 20S 心跳时间间隔（单位：秒）
        /// </summary>
        public ushort HeartBeatInterval;
        /// <summary>
        /// 12 用户自定义 ID，作为网络 ID 的前半部分，便于用户识别其控制卡
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] CustomID = new byte[12];
        //  Web 模式下返回下述 5 项的实际值，否则不上传下述 5 项
        /// <summary>
        /// 128 0 WEB 平台用户 id
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] WebUserID = new byte[128];
        /// <summary>
        /// 4 0 屏幕组号
        /// </summary>
        public int GroupNum;
        /// <summary>
        /// 1 0 域名标志 0 - 无域名，1—域名
        /// </summary>
        public byte DomainFlag;
        /// <summary>
        /// 128 域名名称 当 DomainFlag 为 1 时下发
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] DomainName = new byte[128];
        /// <summary>
        /// 128 LED00001 WEB 平台控制器名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] WebControllerName = new byte[128];
        //Web 模式下返回下述 5 项 结束 ###################
        /// <summary>
        /// 16 条形码，作为网络 ID 的后半部分，用以实现网络 ID 的唯一性
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] BarCode = new byte[16];
        /// <summary>
        /// 2 其中低位字节表示设备系列，而高位字节表示设备编号，例如 BX - 6Q2 应表示为[0x66, 0x02]，其它型号依此类推。
        /// </summary>
        public ushort ControllerType;
        /// <summary>
        /// 8 Firmware 版本号
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] FirmwareVersion = new byte[8];
        /// <summary>
        /// 1 控制器参数文件状态 
        /// 0x00 –控制器中没有参数配置文件，以下返回的是控制器的默认参数。此时，PC软件应提示用户必须先加载屏参。
        /// 0x01 –控制器中有参数配置文件
        /// </summary>
        public byte ScreenParaStatus;
        /// <summary>
        /// 2 0x0001 控制器地址控制器出厂默认地址为 
        /// 0x0001(0x0000 地址将保留)控制除了对发送给自身地址的数据包进行处理外，还需对广播数据包进行处理。
        /// </summary>
        public ushort Address;
        /// <summary>
        /// 1 0x00 波特率 
        /// 0x00 –保持原有波特率不变 
        /// 0x01 –强制设置为 9600 
        /// 0x02 –强制设置为 57600
        /// </summary>
        public byte Baudrate;
        /// <summary>
        /// 2 192 显示屏宽度
        /// </summary>
        public ushort ScreenWidth;
        /// <summary>
        /// 2 96 显示屏高度
        /// </summary>
        public ushort ScreenHeight;
        /// <summary>
        /// 1 0x01 对于无灰度系统，
        /// 单色时返回 1，
        /// 双色时返回 3，
        /// 三色时返回 7；
        /// 对于有灰度系统，返回 255
        /// </summary>
        public byte Color;
        /// <summary>
        /// 1 调亮模式 
        /// 0x00 –手动调亮 
        /// 0x01 –定时调亮 
        /// 0x02 –自动调亮
        /// </summary>
        public byte BrightnessAdjMode;
        /// <summary>
        /// 1 当前亮度值
        /// </summary>
        public byte CurrentBrigtness;
        /// <summary>
        /// 1 Bit0 –定时开关机状态，
        /// 0 表示无定时开关机，
        /// 1 表示有定时开关机
        /// </summary>
        public byte TimingOnOff;
        /// <summary>
        /// 1 开关机状态
        /// </summary>
        public byte CurrentOnOffStatus;
        /// <summary>
        /// 2 扫描配置编号
        /// </summary>
        public ushort ScanConfNumber;
        /// <summary>
        /// 1 一路数据带几行
        /// </summary>
        public byte RowsPerChanel;
        /// <summary>
        /// 1 对于无灰度系统，返回 0；对于有灰度系
        /// </summary>
        public byte GrayFlag;
        /// <summary>
        /// 2 最小单元宽度
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] UnitWidth = new byte[2];
        /// <summary>
        /// 1 6Q 显示模式 : 0 为 888, 1 为 565，其余卡为 0
        /// </summary>
        public byte modeofdisp;
        /// <summary>
        /// 1 当该字节为 0 时，网口通讯使用老的模式，即 UDP 和 TCP 均根据下面的PackageMode 字节确定包长，
        /// 并且 UDP通讯时，将大包分为小包，每发送一小包做一下延时当该字节不为 0 时，网口通讯使用新的模式，
        /// 即 UDP 的包长等于UDPPackageMode * 8KBYTE，且不再分为小包，将整包数据丢给协议栈TCP 的包长等于 PackageMode * 16KBYTE
        /// </summary>
        public byte NetTranMode;
        /// <summary>
        /// 1 包模式。0 小包模式，分包 600 byte。1 大包模式，分包 16K byte。
        /// </summary>
        public byte PackageMode;
        /// <summary>
        /// 1 是否设置了条码 ID如果设置了，该字节第 0 位为 1，否则为0
        /// </summary>
        public byte BarcodeFlag;
        /// <summary>
        /// 2 控制器上已有节目个数
        /// </summary>
        public ushort ProgramNumber;
        /// <summary>
        /// 4 当前节目名
        /// </summary>
        public int CurrentProgram;
        /// <summary>
        /// 1 Bit0 –是否屏幕锁定，1b’0 –无屏幕锁定，1b’1 –屏幕锁定
        /// </summary>
        public byte ScreenLockStatus;
        /// <summary>
        /// 1 Bit0 –是否节目锁定，1b’0 –无节目锁定，1’b1 –节目锁定
        /// </summary>
        public byte ProgramLockStatus;
        /// <summary>
        /// 1 控制器运行模式
        /// </summary>
        public byte RunningMode;
        /// <summary>
        /// 1 RTC 状态 0x00 – RTC 异常 0x01 – RTC 正常
        /// </summary>
        public byte RTCStatus;
        /// <summary>
        /// 2 年
        /// </summary>
        public ushort RTCYear;
        /// <summary>
        /// 1 月
        /// </summary>
        public byte RTCMonth;
        /// <summary>
        /// 1 日
        /// </summary>
        public byte RTCDate;
        /// <summary>
        /// 1 小时
        /// </summary>
        public byte RTCHour;
        /// <summary>
        /// 1 分钟
        /// </summary>
        public byte RTCMinute;
        /// <summary>
        /// 1 秒
        /// </summary>
        public byte RTCSecond;
        /// <summary>
        /// 1 星期，范围为 1~7，7 表示周日
        /// </summary>
        public byte RTCWeek;
        /// <summary>
        /// 3 温度传感器当前值
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Temperature1 = new byte[3];
        /// <summary>
        /// 3 温度传感器当前值
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Temperature2 = new byte[3];
        /// <summary>
        /// 2 湿度传感器当前值
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Humidity = new byte[2];
        /// <summary>
        /// 2 噪声传感器当前值(除以 10 为当前值)针对 BX - ZS(485) 0xffff 时无效
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Noise = new byte[2];
        /// <summary>
        /// 1 保留字节
        /// </summary>
        public byte Reserved;
        /// <summary>
        /// 1 0：表示未设置 Logo 节目 1：表示设置了 Logo 节目
        /// </summary>
        public byte LogoFlag;
        /// <summary>
        /// 2 0：未设置开机延时 1：开机延时时长
        /// </summary>
        public ushort PowerOnDelay;
        /// <summary>
        /// 2 风速(除以 10 为当前值) 0xfffff 时无效
        /// </summary>
        public ushort WindSpeed;
        /// <summary>
        /// 2 风向(当前值) 0xfffff 时无效
        /// </summary>
        public ushort WindDirction;
        /// <summary>
        /// 2 PM2.5 值(当前值)0xfffff 时无效
        /// </summary>
        public ushort PM2_5;
        /// <summary>
        /// 2 PM10 值(当前值)0xfffff 时无效
        /// </summary>
        public ushort PM10;
        //byte Reserved2[24];	//24 保留字
        /// <summary>
        /// 2 0x40 扩展参数长度
        /// </summary>
        public ushort ExtendParaLen;
        /// <summary>
        /// 16 LEDCON01 控制器名称限制为 16 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] ControllerName = new byte[16];
        /// <summary>
        /// 44 0 屏幕安装地址限制为 44 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 44)]
        public byte[] ScreenLocation = new byte[44];
        /// <summary>
        /// 4 控制器和屏幕安装地址共 60 个字节的CRC32 校验值，该值是为了便于上位机区分此处 64 个字节是表示控制器名称还是用来表示控制器名称和屏幕安装地址，进而采取不同的处理策略为了保持兼容，下位机不对该值进行验证
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] NameLocalationCRC32 = new byte[4];
        /// <summary>
        /// 构造
        /// </summary>
        public NetSearchCmdRet_Web()
        {
        }
    }
}
