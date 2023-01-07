using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /************************************视频综合平台(end)***************************************/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VIDEOPLATFORM_ABILITY
    {
        public uint dwSize;
        public byte byCodeSubSystemNums;//编码子系统数量
        public byte byDecodeSubSystemNums;//解码子系统数量
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
        public byte[] byWindowMode; /*显示通道支持的窗口模式*/
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
        public byte[] byRes;
    }

}
