using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //智能分析仪参数配置结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_IVMS_STREAMCFG
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT, ArraySubType = UnmanagedType.Struct)]
        public NET_IVMS_DEVSCHED[] struDevSched;//按时间段配置前端取流以及规则信息
    }
}
