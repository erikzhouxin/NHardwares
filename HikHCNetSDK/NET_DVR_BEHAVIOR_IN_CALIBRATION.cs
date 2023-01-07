using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_BEHAVIOR_IN_CALIBRATION
    {
        public uint dwCalSampleNum;      //  标定样本个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_SAMPLE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IN_CAL_SAMPLE[] struCalSample; // 标定样本最大个数
        public NET_DVR_CAMERA_PARAM struCameraParam;    // 摄像机参数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }


}
