using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //ntp
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_NTPPARA
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] sNTPServer;/* Domain Name or IP addr of NTP server */
        public ushort wInterval;/* adjust time interval(hours) */
        public byte byEnableNTP;/* enable NPT client 0-no，1-yes*/
        public byte cTimeDifferenceH;/* 与国际标准时间的 小时偏移-12 ... +13 */
        public byte cTimeDifferenceM;/* 与国际标准时间的 分钟偏移0, 30, 45*/
        public byte res1;
        public ushort wNtpPort; /* ntp server port 9000新增 设备默认为123*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] res2;
    }
}
