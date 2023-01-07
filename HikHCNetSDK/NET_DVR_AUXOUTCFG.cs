using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /* aux video out parameter */
    //辅助输出参数配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_AUXOUTCFG
    {
        public uint dwSize;
        public uint dwAlarmOutChan;/* 选择报警弹出大报警通道切换时间：1画面的输出通道: 0:主输出/1:辅1/2:辅2/3:辅3/4:辅4 */
        public uint dwAlarmChanSwitchTime;/* :1秒 - 10:10秒 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_AUXOUT, ArraySubType = UnmanagedType.U4)]
        public uint[] dwAuxSwitchTime;/* 辅助输出切换时间: 0-不切换,1-5s,2-10s,3-20s,4-30s,5-60s,6-120s,7-300s */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_AUXOUT * HikHCNetSdk.MAX_WINDOW, ArraySubType = UnmanagedType.I1)]
        public byte[] byAuxOrder;/* 辅助输出预览顺序, 0xff表示相应的窗口不预览 */
    }
}
