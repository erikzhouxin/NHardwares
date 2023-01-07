using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //Sensor信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SENSOR_PARAM
    {
        public byte bySensorType;//SensorType:0-CCD,1-CMOS
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 31, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public float fHorWidth;//水平宽度 精确到小数点后两位 *10000
        public float fVerWidth;//垂直宽度 精确到小数点后两位 *10000
        public float fFold;//zoom=1没变时的焦距 精确到小数点后两位 *100
    }
}
