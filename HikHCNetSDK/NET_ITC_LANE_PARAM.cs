using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_ITC_LANE_PARAM
    {
        public byte byEnable;
        public byte byRelatedDriveWay;
        public ushort wDistance;
        public ushort wTrigDelayTime;
        public byte byTrigDelayDistance;
        public byte bySpeedCapEn;
        public byte bySignSpeed;
        public byte bySpeedLimit;
        public byte bySnapTimes;
        public byte byOverlayDriveWay;
        public NET_ITC_INTERVAL_PARAM struInterval;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IOOUT_NUM, ArraySubType = UnmanagedType.I1)]
        public byte[] byRelatedIOOut;
        public byte byFlashMode;
        public byte byCartSignSpeed;
        public byte byCartSpeedLimit;
        public byte byRelatedIOOutEx;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_LANEAREA_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_ITC_PLATE_RECOG_REGION_PARAM[] struPlateRecog;
        public byte byLaneType;
        public byte byUseageType;
        public byte byRelaLaneDirectionType;
        public byte byLowSpeedLimit;
        public byte byBigCarLowSpeedLimit;
        public byte byLowSpeedCapEn;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;

    }

}
