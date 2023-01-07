using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //2007-11-05 新增每个解码通道的配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIX_LOOP_DECINFO
    {
        public uint dwSize;
        public uint dwPoolTime;/*轮巡时间 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CYCLE_CHAN, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_MATRIX_DECCHANINFO[] struchanConInfo;
    }
}
