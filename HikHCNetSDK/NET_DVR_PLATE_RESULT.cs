using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PLATE_RESULT
    {
        public uint dwSize;
        public byte byResultType;
        public byte byChanIndex;
        public ushort wAlarmRecordID;   //报警录像ID(用于查询录像，仅当byResultType为2时有效)
        public uint dwRelativeTime;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byAbsTime;
        public uint dwPicLen;
        public uint dwPicPlateLen;
        public uint dwVideoLen;
        public byte byTrafficLight;
        public byte byPicNum;
        public byte byDriveChan;
        public byte byVehicleType; //0- 未知，1- 客车，2- 货车，3- 轿车，4- 面包车，5- 小货车
        public uint dwBinPicLen;
        public uint dwCarPicLen;
        public uint dwFarCarPicLen;
        public IntPtr pBuffer3;
        public IntPtr pBuffer4;
        public IntPtr pBuffer5;
        public byte byRelaLaneDirectionType;
        public byte byCarDirectionType;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;
        public NET_DVR_PLATE_INFO struPlateInfo;
        public NET_DVR_VEHICLE_INFO struVehicleInfo;
        public IntPtr pBuffer1;
        public IntPtr pBuffer2;

        public void Init()
        {
            byAbsTime = new byte[32];
            byRes3 = new byte[6];
        }
    }



}
