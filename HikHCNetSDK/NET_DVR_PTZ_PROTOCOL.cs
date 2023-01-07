using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //云台协议表结构配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PTZ_PROTOCOL
    {
        public uint dwType;/*解码器类型值，从1开始连续递增*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.DESC_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byDescribe;/*解码器的描述符，和8000中的一致*/
    }
}
