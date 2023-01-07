using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //2013-07-09 异常处理
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_ITC_HANDLEEXCEPTION
    {
        public uint dwHandleType; //异常处理,异常处理方式的"或"结果
        /*0x00: 无响应*/
        /*0x01: 监视器上警告*/
        /*0x02: 声音警告*/
        /*0x04: 上传中心*/
        /*0x08: 触发报警输出（继电器输出）*/
        /*0x10: 触发JPRG抓图并上传Email*/
        /*0x20: 无线声光报警器联动*/
        /*0x40: 联动电子地图(目前只有PCNVR支持)*/
        /*0x200: 抓图并上传FTP*/
        public byte byEnable; //0～不启用，1～启用
        public byte byRes;
        public ushort wDuration;//持续时间(单位/s)
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ITC_EXCEPTIONOUT, ArraySubType = UnmanagedType.I1)]
        public byte[] byAlarmOutTriggered;//触发输出通道
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
    }



}
