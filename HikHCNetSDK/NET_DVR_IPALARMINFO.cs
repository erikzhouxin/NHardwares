using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //ipc alarm info
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPALARMINFO
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IP_DEVICE, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPDEVINFO[] struIPDevInfo; /* IP设备 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ANALOG_CHANNUM, ArraySubType = UnmanagedType.I1)]
        public byte[] byAnalogChanEnable; /* 模拟通道是否启用，0-未启用 1-启用 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IP_CHANNEL, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPCHANINFO[] struIPChanInfo;/* IP通道 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IP_ALARMIN, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPALARMININFO[] struIPAlarmInInfo;/* IP报警输入 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IP_ALARMOUT, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPALARMOUTINFO[] struIPAlarmOutInfo;/* IP报警输出 */
    }

}
