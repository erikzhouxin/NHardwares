using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    // 压缩参数能力列表
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_COMPRESSIONCFG_ABILITY
    {
        public uint dwSize;            //结构长度
        public uint dwAbilityNum;       //能力类型个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ABILITYTYPE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_ABILITY_LIST[] struAbilityNode; //描述参数  
    }
}
