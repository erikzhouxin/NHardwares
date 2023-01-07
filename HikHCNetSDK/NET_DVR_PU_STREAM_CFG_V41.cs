using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PU_STREAM_CFG_V41
    {
        public uint dwSize;
        public byte byStreamMode;//取流模式：0- 无效，1- 通过IP或域名取流，2- 通过URL取流，3- 通过动态域名解析向设备取流
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_DEC_STREAM_MODE uDecStreamMode;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
