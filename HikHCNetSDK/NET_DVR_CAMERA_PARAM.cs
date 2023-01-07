using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*在设置标定信息的时候，如果相应位设置了使能，并设置相关参数，若没有设置使能，则标定后可以获取相关的摄像机参数*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CAMERA_PARAM
    {
        public byte byEnableHeight;     // 是否使能设置摄像机高度线
        public byte byEnableAngle;      // 是否使能设置摄像机俯仰角度
        public byte byEnableHorizon;    // 是否使能设置摄像机地平线
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;   // 保留字节 
        public float fCameraHeight;    // 摄像机高度
        public float fCameraAngle;     // 摄像机俯仰角度
        public float fHorizon;         // 场景中的地平线
    }


}
