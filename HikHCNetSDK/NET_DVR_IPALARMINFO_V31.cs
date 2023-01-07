using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //ipc配置改变报警信息扩展 9000_1.1
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPALARMINFO_V31
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IP_DEVICE, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPDEVINFO_V31[] struIPDevInfo; /* IP设备 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ANALOG_CHANNUM, ArraySubType = UnmanagedType.I1)]
        public byte[] byAnalogChanEnable;/* 模拟通道是否启用，0-未启用 1-启用 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IP_CHANNEL, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPCHANINFO[] struIPChanInfo;/* IP通道 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IP_ALARMIN, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPALARMININFO[] struIPAlarmInInfo; /* IP报警输入 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IP_ALARMOUT, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPALARMOUTINFO[] struIPAlarmOutInfo;/* IP报警输出 */
    }

}
