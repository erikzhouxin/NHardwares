using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPALARMINFO_V40
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IP_DEVICE_V40, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPDEVINFO_V31[] struIPDevInfo;           // IP设备
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byAnalogChanEnable;           /* 模拟通道是否启用，0-未启用 1-启用 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPCHANINFO[] struIPChanInfo;         /* IP通道 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IP_ALARMIN, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPALARMININFO[] struIPAlarmInInfo;    /* IP报警输入 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IP_ALARMOUT, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPALARMOUTINFO[] struIPAlarmOutInfo; /* IP报警输出 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;                          // 保留字节
    }

}
