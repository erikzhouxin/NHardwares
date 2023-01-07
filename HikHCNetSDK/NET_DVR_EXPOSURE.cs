using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //曝光控制
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_EXPOSURE
    {
        public byte byExposureMode; /*0 手动曝光 1自动曝光*/
        public byte byAutoApertureLevel; /* 自动光圈灵敏度, 0-10 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public uint dwVideoExposureSet; /* 自定义视频曝光时间（单位us）*//*注:自动曝光时该值为曝光最慢值 新增20-1s(1000000us)*/
        public uint dwExposureUserSet; /* 自定义曝光时间,在抓拍机上应用时，CCD模式时是抓拍快门速度*/
        public uint dwRes;
    }



}
