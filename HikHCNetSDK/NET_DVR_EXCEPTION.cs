using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //DVR异常参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_EXCEPTION
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_EXCEPTIONNUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_HANDLEEXCEPTION[] struExceptionHandleType;
        /*数组0-盘满,1- 硬盘出错,2-网线断,3-局域网内IP 地址冲突,4-非法访问, 5-输入/输出视频制式不匹配, 6-视频信号异常*/
    }

}
