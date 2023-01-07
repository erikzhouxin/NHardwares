using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //存储路径设置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_SAVE_PATH_CFG
    {
        public uint dwSize;   //结构大小
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DISKNUM_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_SINGLE_PATH[] struPathInfo; //单个分区
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 40, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留
    }
}
