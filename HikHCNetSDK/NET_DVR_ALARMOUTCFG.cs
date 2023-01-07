using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //DVR报警输出
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARMOUTCFG
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sAlarmOutName;/* 名称 */
        public uint dwAlarmOutDelay;/* 输出保持时间(-1为无限，手动关闭) */
        //0-5秒,1-10秒,2-30秒,3-1分钟,4-2分钟,5-5分钟,6-10分钟,7-手动
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmOutTime;/* 报警输出激活时间段 */
    }

}
