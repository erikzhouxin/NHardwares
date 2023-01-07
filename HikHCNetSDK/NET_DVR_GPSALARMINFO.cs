using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //GPS报警信息结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_GPSALARMINFO
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byDeviceID;/*设备的ID串*/
        public NET_DVR_TIME_EX struGpsTime;    /*GPS上传的时间*/
        public uint dwLongitude;    /* 经度*/
        public uint dwLatitude;  /* 纬度*/
        public int iTimeZone; /*时区，用分钟数表示，+60代表东1区，+480代表东8区，-60代表西区，-480代表西8区，该字段和GPSTime构成一个完整的时间描述*/
        public uint dwDirection; /*车辆方向=实际方向（以度为单位，正北方向为，顺时针方向计算）*100*/
        public ushort wSatellites; /*卫星数量*/
        public ushort wPrecision; /*精度*/
        public uint dwHeight; /*高度:厘米，预留*/
        public uint dwGPSSeq; /*GPS序号，GPS补传时要用到*/
        public ushort wSpeed;//速度，单位，km/h
        /* direction[0]:'E'or'W'(东经/西经), direction[1]:'N'or'S'(北纬/南纬)*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] sDirection;
        public byte byLocateMode;/*定位模式(初值0)，1,自主定位,2,差分3,估算,4,数据无效，65,有效定位，78，无效定位*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
