using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_ITS_GATE_VEHICLE
    {
        public uint dwSize;
        public uint dwMatchNo;
        public byte byGroupNum;
        public byte byPicNo;
        public byte bySecondCam;

        public byte byRes;
        public ushort wLaneid;
        public byte byCamLaneId;
        public byte byRes1;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byAlarmReason;

        public ushort wBackList;
        public ushort wSpeedLimit;
        public uint dwChanIndex;


        public NET_DVR_PLATE_INFO struPlateInfo;

        public NET_DVR_VEHICLE_INFO struVehicleInfo;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] byMonitoringSiteID;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] byDeviceID;


        public byte byDir;
        public byte byDetectType;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byRes2;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] byCardNo;

        public uint dwPicNum;

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
        public NET_ITS_PICTURE_INFO[] struPicInfo;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] bySwipeTime;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 224)]
        public byte[] byRes3;
    }
}
