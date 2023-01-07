using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARMINFO
    {
        public int dwAlarmType;/*0-信号量报警,1-硬盘满,2-信号丢失,3－移动侦测,4－硬盘未格式化,5-读写硬盘出错,6-遮挡报警,7-制式不匹配, 8-非法访问, 9-串口状态, 0xa-GPS定位信息(车载定制)*/
        public int dwAlarmInputNumber;/*报警输入端口, 当报警类型为9时该变量表示串口状态0表示正常， -1表示错误*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALARMOUT, ArraySubType = UnmanagedType.U4)]
        public int[] dwAlarmOutputNumber;/*触发的输出端口，哪一位为1表示对应哪一个输出*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM, ArraySubType = UnmanagedType.U4)]
        public int[] dwAlarmRelateChannel;/*触发的录像通道，哪一位为1表示对应哪一路录像, dwAlarmRelateChannel[0]对应第1个通道*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM, ArraySubType = UnmanagedType.U4)]
        public int[] dwChannel;/*dwAlarmType为2或3,6时，表示哪个通道，dwChannel[0]位对应第1个通道*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DISKNUM, ArraySubType = UnmanagedType.U4)]
        public int[] dwDiskNumber;/*dwAlarmType为1,4,5时,表示哪个硬盘, dwDiskNumber[0]位对应第1个硬盘*/
        public void Init()
        {
            dwAlarmType = 0;
            dwAlarmInputNumber = 0;
            dwAlarmOutputNumber = new int[HikHCNetSdk.MAX_ALARMOUT];
            dwAlarmRelateChannel = new int[HikHCNetSdk.MAX_CHANNUM];
            dwChannel = new int[HikHCNetSdk.MAX_CHANNUM];
            dwDiskNumber = new int[HikHCNetSdk.MAX_DISKNUM];
            for (int i = 0; i < HikHCNetSdk.MAX_ALARMOUT; i++)
            {
                dwAlarmOutputNumber[i] = 0;
            }
            for (int i = 0; i < HikHCNetSdk.MAX_CHANNUM; i++)
            {
                dwAlarmRelateChannel[i] = 0;
                dwChannel[i] = 0;
            }
            for (int i = 0; i < HikHCNetSdk.MAX_DISKNUM; i++)
            {
                dwDiskNumber[i] = 0;
            }
        }
        public void Reset()
        {
            dwAlarmType = 0;
            dwAlarmInputNumber = 0;

            for (int i = 0; i < HikHCNetSdk.MAX_ALARMOUT; i++)
            {
                dwAlarmOutputNumber[i] = 0;
            }
            for (int i = 0; i < HikHCNetSdk.MAX_CHANNUM; i++)
            {
                dwAlarmRelateChannel[i] = 0;
                dwChannel[i] = 0;
            }
            for (int i = 0; i < HikHCNetSdk.MAX_DISKNUM; i++)
            {
                dwDiskNumber[i] = 0;
            }
        }
    }

}
