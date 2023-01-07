using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //为CVR扩展的报警类型
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARMINFO_DEV
    {
        public uint dwAlarmType;  //0-编码器(通道)信号量报警；1-私有卷二损坏；2- NVR服务退出；
                                  //3-编码器状态异常；4-系统时钟异常；5-录像卷剩余容量过低；
                                  //6-编码器(通道)移动侦测报警；7-编码器(通道)遮挡报警。
        public NET_DVR_TIME struTime;     //报警时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;    //保留
        public uint dwNumber;     //数目
        public IntPtr pNO;  //dwNumber个WORD; 每个WORD表示一个通道号，或者磁盘号, 无效时为0
    }

}
