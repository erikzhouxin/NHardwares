using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*标定样本线目前需要4-8调样本线，以获取摄像机相关参数*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_BEHAVIOR_OUT_CALIBRATION
    {
        public uint dwLineSegNum;          // 样本线个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_LINE_SEG_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_LINE_SEGMENT[] struLineSegment;    // 样本线最大个数
        public NET_DVR_CAMERA_PARAM struCameraParam;    // 摄像机参数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }


}
