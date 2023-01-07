using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_HDGROUP_CFG_V40
    {
        public uint dwSize;                //结构体大小
        public uint dwMaxHDGroupNum;          //设备支持的最大盘组数-只读
        public uint dwCurHDGroupNum;       /*当前配置的盘组数*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_HD_GROUP, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SINGLE_HDGROUP_V40[] struHDGroupAttr; //硬盘相关操作都需要重启才能生效；
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留
    }
}
