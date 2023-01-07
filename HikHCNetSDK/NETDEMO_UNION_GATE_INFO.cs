using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct UNION_GATE_INFO
    {
        public UNION_GATE_VEHICLE struVehicleInfo; //当struAlarmType为(0x1车辆非法侵入报警)
    }
}
