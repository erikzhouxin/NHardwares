using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ControllerStatus_G56
    {
        public byte onoffStatus; // 开关机状态 Bit 0 –开机/关机， 0 表示关机， 1 表示开机
        public byte timingOnOff; // 定时开关机状态 0 表示无定时开关机， 1 表示有定时开关机
        public byte brightnessAdjMode; //亮度模式 0x00 –手动调亮 0x01 –定时调亮 0x02 –自动调亮
        public byte brightness;// 当前亮度值
        public short programeNumber;// 控制器上已有节目个数
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] currentProgram;//当前节目名
        public byte screenLockStatus;//是否屏幕锁定，0 –无屏幕锁定， 1 –屏幕锁定
        public byte programLockStatus; //是否节目锁定， 0 –无节目锁定，1 –节目锁定
        public byte runningMode;//控制器运行模式
        public byte RTCStatus;//RTC 状态0x00 – RTC 异常 0x01 – RTC 正常
        public short RTCYear;//年
        public byte RTCMonth;//月
        public byte RTCDate;//日
        public byte RTCHour;//时
        public byte RTCMinute;//分
        public byte RTCSecond;//秒
        public byte RTCWeek;//星期 1--7
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] temperature1;//温度1传感器当前值
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] temperature2;//温度2传感器当前值
        public short humidity;//湿度传感器当前值
        public short noise;//噪声传感器当前值
        public byte switchStatus; //测试按钮状态 0 –打开 1 –闭合
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] CustomID; //用户自定义 ID，作为网络 ID 的前半部分，便于用户识别其控制卡
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] BarCode; //条形码，作为网络 ID 的后半部分，用以实现网络 ID 的唯一性
    }
}
