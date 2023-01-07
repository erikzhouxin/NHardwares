using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SADPINFO_LIST
    {
        public uint dwSize;   //  结构大小
        public ushort wSadpNum;   // 搜索到设备数目
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;   // 保留字节
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_SADP_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SADPINFO[] struSadpInfo; // 搜索
    }
}
