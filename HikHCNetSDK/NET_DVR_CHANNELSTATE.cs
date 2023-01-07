using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //通道状态
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CHANNELSTATE
    {
        public byte byRecordStatic;//通道是否在录像,0-不录像,1-录像
        public byte bySignalStatic;//连接的信号状态,0-正常,1-信号丢失
        public byte byHardwareStatic;//通道硬件状态,0-正常,1-异常,例如DSP死掉
        public byte reservedData;//保留
        public uint dwBitRate;//实际码率
        public uint dwLinkNum;//客户端连接的个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_LINK, ArraySubType = UnmanagedType.U4)]
        public uint[] dwClientIP;//客户端的IP地址
    }

}
