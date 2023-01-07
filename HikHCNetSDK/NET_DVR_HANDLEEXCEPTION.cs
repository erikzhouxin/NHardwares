using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //报警和异常处理结构(子结构)(多处使用)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_HANDLEEXCEPTION
    {
        public uint dwHandleType;/*处理方式,处理方式的"或"结果*/
        /*0x00: 无响应*/
        /*0x01: 监视器上警告*/
        /*0x02: 声音警告*/
        /*0x04: 上传中心*/
        /*0x08: 触发报警输出*/
        /*0x10: Jpeg抓图并上传EMail*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALARMOUT, ArraySubType = UnmanagedType.I1)]
        public byte[] byRelAlarmOut;//报警触发的输出通道,报警触发的输出,为1表示触发该输出
    }
}
