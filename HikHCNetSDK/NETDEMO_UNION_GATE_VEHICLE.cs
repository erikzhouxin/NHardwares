using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct UNION_GATE_VEHICLE
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_LICENSE_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sLicense;//车牌号码
        /*车辆类型0-保留 1-固定车，2-临时车，3-预订车，4-联检车，5-授权车*/
        public byte byVehicleType;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 111, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
    }
}
