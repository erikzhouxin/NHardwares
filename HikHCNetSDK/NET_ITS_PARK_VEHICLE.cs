using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_ITS_PARK_VEHICLE
    {
        public uint dwSize;
        public byte byGroupNum;
        public byte byPicNo;
        public byte byLocationNum;
        public byte byParkError;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.MAX_PARKNO_LEN)]
        public string byParkingNo;
        public byte byLocationStatus;
        public byte bylogicalLaneNum;
        public ushort wUpLoadType;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwChanIndex;
        public NET_DVR_PLATE_INFO struPlateInfo;
        public NET_DVR_VEHICLE_INFO struVehicleInfo;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ID_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byMonitoringSiteID;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ID_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byDeviceID;
        public uint dwPicNum;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.Struct)]
        public NET_ITS_PICTURE_INFO[] struPicInfo;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 256, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
