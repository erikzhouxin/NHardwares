using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_ITC_EXCEPTION
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_EXCEPTIONNUM_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_ITC_HANDLEEXCEPTION[] struSnapExceptionType;
        //数组的每个元素都表示一种异常，数组0- 硬盘出错,1-网线断,2-IP 地址冲突, 3-车检器异常, 4-信号灯检测器异常
    }



}
