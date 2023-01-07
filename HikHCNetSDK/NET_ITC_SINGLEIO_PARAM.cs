using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_ITC_SINGLEIO_PARAM
    {
        public byte byDefaultStatus;
        public byte byRelatedDriveWay;
        public byte bySnapTimes;
        public byte byRelatedIOOutEx;
        public NET_ITC_INTERVAL_PARAM struInterval;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IOOUT_NUM, ArraySubType = UnmanagedType.I1)]
        public byte[] byRelatedIOOut;
        public byte byFlashMode;
        public byte byEnable;
        public byte byUseageType;
        public byte byRes2;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_LANEAREA_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_ITC_PLATE_RECOG_REGION_PARAM[] struPlateRecog;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
