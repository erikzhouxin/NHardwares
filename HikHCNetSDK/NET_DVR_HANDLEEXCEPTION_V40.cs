using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_HANDLEEXCEPTION_V40
    {
        public uint dwHandleType;/*处理方式,处理方式的"或"结果*/
        /*0x00: 无响应*/
        /*0x01: 监视器上警告*/
        /*0x02: 声音警告*/
        /*0x04: 上传中心*/
        /*0x08: 触发报警输出*/
        /*0x10: 触发JPRG抓图并上传Email*/
        /*0x20: 无线声光报警器联动*/
        /*0x40: 联动电子地图(目前只有PCNVR支持)*/
        /*0x200: 抓图并上传FTP*/
        public uint dwMaxRelAlarmOutChanNum; //触发的报警输出通道数（只读）最大支持数
        public uint dwRelAlarmOutChanNum; //触发的报警输出通道数 实际支持数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.U4)]
        public uint[] dwRelAlarmOut; //触发报警通道      
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;           //保留
    }
}
