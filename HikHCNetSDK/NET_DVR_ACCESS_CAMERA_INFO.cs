using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //91系列HD-SDI高清DVR 相机信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ACCESS_CAMERA_INFO
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string sCameraInfo;      // 前端相机信息
        public byte byInterfaceType;        // 前端接入接口类型，1:VGA, 2:HDMI, 3:YPbPr 4:SDI 5:FC
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwChannel;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
