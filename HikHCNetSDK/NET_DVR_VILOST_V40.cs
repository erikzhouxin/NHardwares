using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //信号丢失报警
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_VILOST_V40
    {
        public uint dwEnableVILostAlarm;                /* 是否启动信号丢失报警 ,0-否,1-是*/
        /* 信号丢失触发报警输出 */
        public uint dwHandleType;        //异常处理,异常处理方式的"或"结果     
        /*0x00: 无响应*/
        /*0x01: 监视器上警告*/
        /*0x02: 声音警告*/
        /*0x04: 上传中心*/
        /*0x08: 触发报警输出*/
        /*0x10: 触发JPRG抓图并上传Email*/
        /*0x20: 无线声光报警器联动*/
        /*0x40: 联动电子地图(目前只有PCNVR支持)*/
        /*0x200: 抓图并上传FTP*/
        public uint dwMaxRelAlarmOutChanNum; //触发的报警输出通道数（只读）最大支持数量
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALARMOUT_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwRelAlarmOut; /*触发报警输出号，按值表示,采用紧凑型排列，从下标0 - dwRelAlarmOut -1有效，如果中间遇到0xffffffff,则后续无效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmTime; /*布防时间*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留
    }
}
