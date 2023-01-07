using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //交通参数统计规则配置结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TPS_RULECFG
    {
        public uint dwSize;              // 结构大小
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_TPS_RULE, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_ONE_TPS_RULE[] struOneTpsRule; // 下标对应交通参数ID
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 40, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;         // 保留字节
    }



}
