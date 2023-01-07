using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /********************************接口参数结构(begin)*********************************/

    //NET_DVR_Login()参数结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DEVICEINFO
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sSerialNumber;//序列号
        public byte byAlarmInPortNum;//DVR报警输入个数
        public byte byAlarmOutPortNum;//DVR报警输出个数
        public byte byDiskNum;//DVR硬盘个数
        public byte byDVRType;//DVR类型, 1:DVR 2:ATM DVR 3:DVS ......
        public byte byChanNum;//DVR 通道个数
        public byte byStartChan;//起始通道号,例如DVS-1,DVR - 1
    }

}
