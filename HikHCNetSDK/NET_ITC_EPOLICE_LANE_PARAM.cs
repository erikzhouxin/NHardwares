using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_ITC_EPOLICE_LANE_PARAM
    {
        public byte byEnable;
        public byte byRelatedDriveWay;
        public ushort wDistance;
        public byte byRecordEnable;
        public byte byRecordType;
        public byte byPreRecordTime;
        public byte byRecordDelayTime;
        public byte byRecordTimeOut;
        public byte bySignSpeed;
        public byte bySpeedLimit;
        public byte byOverlayDriveWay;
        public NET_ITC_SERIAL_INFO struSerialInfo;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IOOUT_NUM, ArraySubType = UnmanagedType.I1)]
        public byte[] byRelatedIOOut;
        public byte byFlashMode;
        public byte bySerialType;
        public byte byRelatedIOOutEx;
        public byte bySnapPicPreRecord;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_LANEAREA_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_ITC_PLATE_RECOG_REGION_PARAM[] struPlateRecog;
        public byte byBigCarSignSpeed;
        public byte byBigCarSpeedLimit;
        public byte byRedTrafficLightChan;
        public byte byYellowTrafficLightChan;
        public byte byRelaLaneDirectionType;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 11, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;
    }

}
