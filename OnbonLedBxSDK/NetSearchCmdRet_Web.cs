using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct NetSearchCmdRet_Web
    {
        byte CmdGroup;      //1 0xA4 命令组 //byte Cmd;		//1 0x83 命令编号 //Oint16 Status;	//2 控制器状态//Oint16 Error;	//2 错误状态寄存器//Oint16 DataLen;	//		2 0xA4 数据长度

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        byte Mac;           //6 Mac 地址
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte IP;           //4 控制器 IP 地址
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte SubNetMask;   //4 子网掩码
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte Gate;         //4 网关
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        byte Port;         //2 端口
        byte IPMode;           //1 1 表示 DHCP 2 表示手动设置
        byte IPStatus;         //1 0 表示 IP 设置失败 1 表示 IP 设置成功
        byte ServerMode;       //1 0 Bit[0]表示服务器模式是否使能：1 –使能，0 –禁止 Bit[1]表示服务器模式：1 –web 模式，0 –普通模式
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte ServerIPAddress;// 4 服务器 IP 地址
        ushort ServerPort;      //2 服务器端口号
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        byte ServerAccessPassword;//	8 服务器访问密码
        public ushort HeartBeatInterval;//2 20S 心跳时间间隔（单位：秒）
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        byte CustomID;     //12 用户自定义 ID，作为网络 ID 的前半部分，便于用户识别其控制卡
                           //Web 模式下返回下述 5 项的实际值，否则不上传下述 5 项
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        byte WebUserID;   //		128 0 WEB 平台用户 id
        public int GroupNum;        //		4 0 屏幕组号
        byte DomainFlag;       //		1 0 域名标志 0 - 无域名，1—域名
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        byte DomainName;  //		128 域名名称 当 DomainFlag 为 1 时下发
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        byte WebControllerName;// 128 LED00001 WEB 平台控制器名称
                               //Web 模式下返回下述 5 项 结束 ###################
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        byte BarCode;      //16 条形码，作为网络 ID 的后半部分，用以实现网络 ID 的唯一性
        ushort ControllerType;  //2 其中低位字节表示设备系列，而高位字节表示设备编号，例如 BX - 6Q2 应表示为[0x66, 0x02]，其它型号依此类推。
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        byte FirmwareVersion;// 8 Firmware 版本号
        byte ScreenParaStatus; //1 控制器参数文件状态 0x00 –控制器中没有参数配置文件，以下返回的是控制器的默认参数。此时，PC软件应提示用户必须先加载屏参。0x01 –控制器中有参数配置文件
        ushort Address;         //2 0x0001 控制器地址控制器出厂默认地址为 0x0001(0x0000 地址将保留)控制除了对发送给自身地址的数据包进行处理外，还需对广播数据包进行处理。
        byte Baudrate;         //1 0x00 波特率 0x00 –保持原有波特率不变 0x01 –强制设置为 9600 0x02 –强制设置为 57600
        ushort ScreenWidth;     //2 192 显示屏宽度
        ushort ScreenHeight;    //2 96 显示屏高度
        byte Color;            //1 0x01 对于无灰度系统，单色时返回 1，双色时返回 3，三色时返回 7；对于有灰度系统，返回 255
        byte BrightnessAdjMode;//1 调亮模式 0x00 –手动调亮 0x01 –定时调亮 0x02 –自动调亮
        byte CurrentBrigtness; //1 当前亮度值
        byte TimingOnOff;      //1 Bit0 –定时开关机状态，0 表示无定时开关机，1 表示有定时开关机
        byte CurrentOnOffStatus;//1 开关机状态
        ushort ScanConfNumber;  //2 扫描配置编号
        byte RowsPerChanel;    //1 一路数据带几行
        byte GrayFlag;         //1 对于无灰度系统，返回 0；对于有灰度系
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        byte UnitWidth;     //2 最小单元宽度
        byte modeofdisp;       //1 6Q 显示模式 : 0 为 888, 1 为 565，其余卡为 0
        byte NetTranMode;      //1 当该字节为 0 时，网口通讯使用老的模式，即 UDP 和 TCP 均根据下面的PackageMode 字节确定包长，并且 UDP通讯时，将大包分为小包，每发送一小包做一下延时当该字节不为 0 时，网口通讯使用新的模式，即 UDP 的包长等于UDPPackageMode * 8KBYTE，且不再分为小包，将整包数据丢给协议栈TCP 的包长等于 PackageMode * 16KBYTE
        byte PackageMode;      //1 包模式。0 小包模式，分包 600 byte。1 大包模式，分包 16K byte。
        byte BarcodeFlag;      //1 是否设置了条码 ID如果设置了，该字节第 0 位为 1，否则为0
        ushort ProgramNumber;   //2 控制器上已有节目个数
        int CurrentProgram;  //4 当前节目名
        byte ScreenLockStatus; //1 Bit0 –是否屏幕锁定，1b’0 –无屏幕锁定，1b’1 –屏幕锁定
        byte ProgramLockStatus;//1 Bit0 –是否节目锁定，1b’0 –无节目锁定，1’b1 –节目锁定
        byte RunningMode;      //1 控制器运行模式
        byte RTCStatus;        //1 RTC 状态 0x00 – RTC 异常 0x01 – RTC 正常
        ushort RTCYear;         //2 年
        byte RTCMonth;         //1 月
        byte RTCDate;          //1 日
        byte RTCHour;          //1 小时
        byte RTCMinute;        //1 分钟
        byte RTCSecond;        //1 秒
        byte RTCWeek;          //1 星期，范围为 1~7，7 表示周日
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        byte Temperature1;  //3 温度传感器当前值
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        byte Temperature2;  //3 温度传感器当前值
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        byte Humidity;      //2 湿度传感器当前值
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        byte Noise;         //2 噪声传感器当前值(除以 10 为当前值)针对 BX - ZS(485) 0xffff 时无效
        byte Reserved;         //1 保留字节
        byte LogoFlag;         //1 0：表示未设置 Logo 节目 1：表示设置了 Logo 节目
        ushort PowerOnDelay;    //2 0：未设置开机延时 1：开机延时时长
        ushort WindSpeed;       //2 风速(除以 10 为当前值) 0xfffff 时无效
        ushort WindDirction;    //2 风向(当前值) 0xfffff 时无效
        ushort PM2_5;           //2 PM2.5 值(当前值)0xfffff 时无效
        ushort PM10;            //2 PM10 值(当前值)0xfffff 时无效
                                //byte Reserved2[24];	//24 保留字
        ushort ExtendParaLen;   // 2 0x40 扩展参数长度
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        byte ControllerName;   // 16 LEDCON01 控制器名称限制为 16 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 44)]
        byte ScreenLocation;   // 44 0 屏幕安装地址限制为 44 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte NameLocalationCRC32;// 4 控制器和屏幕安装地址共 60 个字节的CRC32 校验值，该值是为了便于上位机区分此处 64 个字节是表示控制器名称还是用来表示控制器名称和屏幕安装地址，进而采取不同的处理策略为了保持兼容，下位机不对该值进行验证
    };
}
