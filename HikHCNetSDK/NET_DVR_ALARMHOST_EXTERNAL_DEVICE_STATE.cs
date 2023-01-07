using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARMHOST_EXTERNAL_DEVICE_STATE
    {
        public uint dwSize;
        public byte byDevType;    //1-UPS，2-开关电源，3-气体检测系统，4-温湿度传感器，5-空调，6-电量表，7-变电器状态, 8-水位传感器、9-扬尘噪声传感器、10-环境采集仪、11-风速传感器状态、12-通用扩展输出模块状态、13-浸水传感器状态、14-太阳能控制器状态、15-SF6报警主机状态、16-称重仪状态、17-气象采集系统状态、18-水质检测仪状态、19-燃气监测系统状态、20-消防主机状态
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_EXTERNAL_DEVICE_STATE_UNION struDevState;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
