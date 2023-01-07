using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //车道属性参数结构
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_ITC_LANE_LOGIC_PARAM
    {
        public byte byUseageType;     //车道用途类型，详见ITC_LANE_USEAGE_TYPE
        public byte byDirectionType;  //车道方向类型，详见ITC_LANE_DIRECTION_TYPE
        public byte byCarDriveDirect; //车辆行驶方向，详见ITC_LANE_CAR_DRIVE_DIRECT 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 33, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;        //保留
    }

}
