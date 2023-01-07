using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //标定参数配置结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TRACK_CALIBRATION_PARAM
    {
        public byte byPointNum;         //有效标定点个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CALIB_PT, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_CB_POINT[] struCBPoint; //标定点组
    }
}
