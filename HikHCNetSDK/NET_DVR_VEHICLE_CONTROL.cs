using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //车辆信息管控参数
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_VEHICLE_CONTROL
    {
        public byte byGateOperateType;//操作类型：0- 无操作，1- 开道闸
        public byte byRes1;
        public ushort wAlarmOperateType; //报警处理类型：0- 无操作，bit0- 继电器输出报警，bit1- 布防上传报警，bit3- 告警主机上传，值：0-表示关，1-表示开，可复选
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
