using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //扩展结构体信息V20
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ACS_EVENT_INFO_EXTEND_V20
    {
        public byte byRemoteCheck; //是否需要远程核验（0-无效，1-不需要（默认），2-需要）
        public byte byThermometryUnit; //测温单位（0-摄氏度（默认），1-华氏度，2-开尔文）
        public byte byIsAbnomalTemperature; //人脸抓拍测温是否温度异常：1-是，0-否
        public byte byRes2;
        public float fCurrTemperature; //人脸温度（精确到小数点后一位）
        public NET_VCA_POINT struRegionCoordinates; //人脸温度坐标
        public ushort dwQRCodeInfoLen; //二维码信息长度，不为0是表示后面带数据
        public ushort dwVisibleLightDataLen; //热成像相机可见光图片长度，不为0是表示后面带数据
        public ushort dwThermalDataLen; //热成像图片长度，不为0是表示后面带数据
        public IntPtr pQRCodeInfo; //二维码信息指针
        public IntPtr pVisibleLightData; //热成像相机可见光图片指针
        public IntPtr pThermalData; //热成像图片指针
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byAttendanceLabel; //考勤自定义名称
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 960, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
