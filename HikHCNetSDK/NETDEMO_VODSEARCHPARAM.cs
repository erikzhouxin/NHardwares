using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct VODSEARCHPARAM
    {
        public IntPtr sessionHandle;                                    //[in]VOD客户端句柄
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string dvrIP;                                            //	[in]DVR的网络地址
        public uint dvrPort;                                            //	[in]DVR的端口地址
        public uint channelNum;                                         //  [in]DVR的通道号
        public BLOCKTIME startTime;                                     //	[in]查询的开始时间
        public BLOCKTIME stopTime;                                      //	[in]查询的结束时间
        public bool bUseIPServer;                                       //  [in]是否使用IPServer 
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string SerialNumber;                                     //  [in]设备的序列号
    }
}
