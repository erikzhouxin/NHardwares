using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ConfigFile
    {
        public byte FileType; //文件类型
        public byte[] ControllerName; // 控制器名称
        ushort Address; //控制器地址
        public byte Baudrate; /* 串口波特率 
						     0x00 –保持原有波特率不变
						     0x01 –强制设置为 9600
						     0x02 –强制设置为 57600*/
        ushort ScreenWidth; //显示屏宽度
        ushort ScreenHeight; // 显示屏高度
        public byte Color; /* 显示屏颜色定义 Bit0 表示红， bit1 表示绿， bit2 表示
					         蓝， 对于每一个 Bit， 0 表示灭， 1 表示亮*/
        public byte MirrorMode; // 0x00 –无镜向 0x01 –镜向
        public byte OEPol; //OE 极性，0x00 – OE 低有效   0x01 – OE 高有效
        public byte DAPol; // 数据极性， 0x00 –数据低有效， 0x01 –数据高有效
        public byte RowOrder; /*行序模式， 该值范围为 0-31
						     0-15 代表正序
						     0 代表从第 0 行开始顺序扫描
						     1 代表从第 1 行开始顺序扫描
						     .....
						     16-31 代表逆序
						     0 代表从第 0 行开始逆序扫描
						     1 代表从第 1 行开始逆序扫描*/
        public byte FreqPar; /*CLK 分频倍数
						    注意： 针对于 AX 系列， 为后级分频
						    数值为 0~15， 共 16 个等级。*/
        public byte OEWidth; // OE 宽度
        public byte OEAngle; // OE 提前角
        public byte FaultProcessMode; /*控制器的错误处理模式
								     0x00 –自动处理
								     0x01 –手动处理(此模式仅供调试人员
								     使用)*/
        public byte CommTimeoutValue; /*通讯超时设置（单位秒）
								     建议值：
								     串口– 2S
								     TCP/IP – 6S
								     GPRS – 30S*/
        public byte RunningMode; /*控制器运行模式， 具体定义如下：
							    0x00 –正常模式
							    0x01 –调试模式*/
        public byte LoggingMode; /*日志记录模式
							    0x00 –无日志
							    0x01 –只对控制器错误及对错误进行
							    的错误进行记录
							    0x02 –对控制器的所有操作进行记
							    录， 包括： 控制器接收的各条指令、
							    发生的错误及错误处理*/
        public byte GrayFlag; /*灰度标志(仅 5Q 卡时有该字节)
						     0x00–无灰度
						     0x01–灰度*/
        public byte CascadeMode; /*级联模式： (仅 5Q 卡时有该字节)
							    0x00–非级联模式
							    0x01–级联模式*/
        public byte Default_brightness; /*AX 系列控制器专用， 表示上电时， 默
								       认的亮度等级值。 根据不同的屏幕类
								       型有所不同。*/
        public byte HUBConfig;  /*HUB 板设置(仅 6E 控制器支持)
						       0x00–HUB512 默认项
						       0x01–HUB256*/
        public byte Language; /*控制器多语言显示区。
						     0x00 ----简体中文显示。
						     0x01 ----非中文显示， 控制器显示图
						     形加英文字符。
						     其他值保留。*/
        public byte Backup; // 备用字节
        ushort CRC16; //整个文件的 CRC16 校验
    }
}
