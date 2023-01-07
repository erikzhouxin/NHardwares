using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //异常参数配置扩展结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_EXCEPTION_V40
    {
        public uint dwSize;             //结构体大小
        public uint dwMaxGroupNum;    //设备支持的最大组数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_EXCEPTIONNUM_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_HANDLEEXCEPTION_V41[] struExceptionHandle;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;          //保留
    }

}
