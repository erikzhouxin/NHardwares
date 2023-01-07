using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_ITC_EPOLICE_RS485_PARAM
    {
        public byte byRelatedLaneNum;
        public byte byTrafficLightSignalSrc;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_ITC_PLATE_RECOG_PARAM struPlateRecog;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ITC_LANE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_ITC_EPOLICE_LANE_PARAM[] struLane;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
