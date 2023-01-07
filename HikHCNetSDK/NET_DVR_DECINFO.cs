using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*每个解码通道的配置*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DECINFO
    {
        public byte byPoolChans;/*每路解码通道上的循环通道数量, 最多4通道 0表示没有解码*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DECPOOLNUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_DECCHANINFO[] struchanConInfo;
        public byte byEnablePoll;/*是否轮巡 0-否 1-是*/
        public byte byPoolTime;/*轮巡时间 0-保留 1-10秒 2-15秒 3-20秒 4-30秒 5-45秒 6-1分钟 7-2分钟 8-5分钟 */
    }
}
