using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //GIS信息上传
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_GIS_UPLOADINFO
    {
        public uint dwSize;//结构体大小
        public uint dwRelativeTime; //相对时标
        public uint dwAbsTime; //绝对时标
        public NET_VCA_DEV_INFO struDevInfo;//前端设备
        public float fAzimuth;//电子罗盘的方位信息；方位角[0.00°,360.00°)
        public byte byLatitudeType;//纬度类型，0-北纬，1-南纬
        public byte byLongitudeType;// 经度类型，0-东度，1-西度
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_LLI_PARAM struLatitude;     /*纬度*/
        public NET_DVR_LLI_PARAM struLongitude;   /*经度*/
        public float fHorizontalValue;//水平视场角，精确到小数点后面两位
        public float fVerticalValue;//垂直视场角，精确到小数点后面两位
        public float fVisibleRadius;//当前可视半径，精确到小数点后面两位
        public float fMaxViewRadius;//最大可视半径，精确到小数点后面0位（预留处理）
        public NET_DVR_SENSOR_PARAM struSensorParam;//Sensor信息
        public NET_DVR_PTZPOS_PARAM struPtzPos; //ptz坐标
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 256, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
