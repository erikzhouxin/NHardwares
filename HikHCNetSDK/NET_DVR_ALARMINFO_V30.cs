using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //上传报警信息(9000扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARMINFO_V30
    {
        public uint dwAlarmType;/*0-信号量报警,1-硬盘满,2-信号丢失,3－移动侦测,4－硬盘未格式化,5-读写硬盘出错,6-遮挡报警,7-制式不匹配, 8-非法访问, 0xa-GPS定位信息(车载定制)*/
        public uint dwAlarmInputNumber;/*报警输入端口*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALARMOUT_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byAlarmOutputNumber;/*触发的输出端口，为1表示对应输出*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byAlarmRelateChannel;/*触发的录像通道，为1表示对应录像, dwAlarmRelateChannel[0]对应第1个通道*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byChannel;/*dwAlarmType为2或3,6时，表示哪个通道，dwChannel[0]对应第1个通道*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DISKNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byDiskNumber;/*dwAlarmType为1,4,5时,表示哪个硬盘, dwDiskNumber[0]对应第1个硬盘*/
        public void Init()
        {
            dwAlarmType = 0;
            dwAlarmInputNumber = 0;
            byAlarmRelateChannel = new byte[HikHCNetSdk.MAX_CHANNUM_V30];
            byChannel = new byte[HikHCNetSdk.MAX_CHANNUM_V30];
            byAlarmOutputNumber = new byte[HikHCNetSdk.MAX_ALARMOUT_V30];
            byDiskNumber = new byte[HikHCNetSdk.MAX_DISKNUM_V30];
            for (int i = 0; i < HikHCNetSdk.MAX_CHANNUM_V30; i++)
            {
                byAlarmRelateChannel[i] = Convert.ToByte(0);
                byChannel[i] = Convert.ToByte(0);
            }
            for (int i = 0; i < HikHCNetSdk.MAX_ALARMOUT_V30; i++)
            {
                byAlarmOutputNumber[i] = Convert.ToByte(0);
            }
            for (int i = 0; i < HikHCNetSdk.MAX_DISKNUM_V30; i++)
            {
                byDiskNumber[i] = Convert.ToByte(0);
            }
        }
        public void Reset()
        {
            dwAlarmType = 0;
            dwAlarmInputNumber = 0;

            for (int i = 0; i < HikHCNetSdk.MAX_CHANNUM_V30; i++)
            {
                byAlarmRelateChannel[i] = Convert.ToByte(0);
                byChannel[i] = Convert.ToByte(0);
            }
            for (int i = 0; i < HikHCNetSdk.MAX_ALARMOUT_V30; i++)
            {
                byAlarmOutputNumber[i] = Convert.ToByte(0);
            }
            for (int i = 0; i < HikHCNetSdk.MAX_DISKNUM_V30; i++)
            {
                byDiskNumber[i] = Convert.ToByte(0);
            }
        }
    }

}
