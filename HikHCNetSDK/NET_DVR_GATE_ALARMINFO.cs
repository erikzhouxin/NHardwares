using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_GATE_ALARMINFO
    {
        public uint dwSize;
        //0x1车辆非法侵入报警
        //0x2道闸超时未关报警
        //0x3车辆压线圈超时报警
        //0x4发卡报警（无卡）
        //0x5发卡报警（少卡）
        //0x6发卡报警（发卡异常）
        public byte byAlarmType;
        public byte byExternalDevType;//外接设备类型(EXTERNAL_DEVICES_TYPE)
        public byte byExternalDevStatus;//外接设备类型(EXTERNAL_DEVICES_STATUS)
        public byte byRes;
        public NET_DVR_TIME_V30 struAlarmTime;//报警时间
        public UNION_GATE_INFO uAlarmInfo;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2; //预留
    }
}
