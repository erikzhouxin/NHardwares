using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 控制器状态
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ControllerStatus_G56
    {
        /// <summary>
        /// 开关机状态 Bit 0 –开机/关机， 0 表示关机， 1 表示开机
        /// </summary>
        public byte onoffStatus;
        /// <summary>
        /// 定时开关机状态 0 表示无定时开关机， 1 表示有定时开关机
        /// </summary>
        public byte timingOnOff;
        /// <summary>
        /// 亮度模式 0x00 –手动调亮 0x01 –定时调亮 0x02 –自动调亮
        /// </summary>
        public byte brightnessAdjMode;
        /// <summary>
        /// 当前亮度值
        /// </summary>
        public byte brightness;
        /// <summary>
        /// 控制器上已有节目个数
        /// </summary>
        public short programeNumber;
        /// <summary>
        /// 当前节目名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] currentProgram;
        /// <summary>
        /// 是否屏幕锁定，0 –无屏幕锁定， 1 –屏幕锁定
        /// </summary>
        public byte screenLockStatus;
        /// <summary>
        /// 是否节目锁定， 0 –无节目锁定，1 –节目锁定
        /// </summary>
        public byte programLockStatus;
        /// <summary>
        /// 控制器运行模式
        /// </summary>
        public byte runningMode;
        /// <summary>
        /// RTC 状态0x00 – RTC 异常 0x01 – RTC 正常
        /// </summary>
        public byte RTCStatus;
        /// <summary>
        /// 年
        /// </summary>
        public short RTCYear;
        /// <summary>
        /// 月
        /// </summary>
        public byte RTCMonth;
        /// <summary>
        /// 日
        /// </summary>
        public byte RTCDate;
        /// <summary>
        /// 时
        /// </summary>
        public byte RTCHour;
        /// <summary>
        /// 分
        /// </summary>
        public byte RTCMinute;
        /// <summary>
        /// 秒
        /// </summary>
        public byte RTCSecond;
        /// <summary>
        /// 星期 1--7
        /// </summary>
        public byte RTCWeek;
        /// <summary>
        /// 温度1传感器当前值
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] temperature1;
        /// <summary>
        /// 温度2传感器当前值
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] temperature2;
        /// <summary>
        /// 湿度传感器当前值
        /// </summary>
        public short humidity;
        /// <summary>
        /// 噪声传感器当前值
        /// </summary>
        public short noise;
        /// <summary>
        /// 测试按钮状态 0 –打开 1 –闭合
        /// </summary>
        public byte switchStatus;
        /// <summary>
        /// 用户自定义 ID，作为网络 ID 的前半部分，便于用户识别其控制卡
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] CustomID;
        /// <summary>
        /// 条形码，作为网络 ID 的后半部分，用以实现网络 ID 的唯一性
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] BarCode;
    }
}
