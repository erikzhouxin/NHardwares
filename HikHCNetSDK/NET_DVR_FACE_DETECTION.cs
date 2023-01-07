using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //人脸侦测报警信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FACE_DETECTION
    {
        public uint dwSize;
        public uint dwRelativeTime;
        public uint dwAbsTime;
        public uint dwBackgroundPicLen;
        public NET_VCA_DEV_INFO struDevInfo;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 30, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_RECT[] struFacePic; //人脸子图区域，归一化值，相对于大图（背景图)的分辨率
        public byte byFacePicNum;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 255, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留
        public IntPtr pBackgroundPicpBuffer;//背景图的图片数据
    }
}
