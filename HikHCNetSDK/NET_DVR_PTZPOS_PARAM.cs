using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //球机位置信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PTZPOS_PARAM
    {
        public float fPanPos;//水平参数，精确到小数点后1位
        public float fTiltPos;//垂直参数，精确到小数点后1位
        public float fZoomPos;//变倍参数，精确到小数点后1位
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
