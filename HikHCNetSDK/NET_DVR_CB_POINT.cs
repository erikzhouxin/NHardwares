using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //标定点子结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CB_POINT
    {
        public NET_VCA_POINT struPoint;     //标定点，主摄像机（枪机）
        public NET_DVR_PTZPOS struPtzPos;  //球机输入的PTZ坐标
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
