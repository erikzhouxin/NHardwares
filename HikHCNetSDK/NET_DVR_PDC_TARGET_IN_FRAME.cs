using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PDC_TARGET_IN_FRAME
    {
        public byte byTargetNum;                   //目标个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] yRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_TARGET_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_PDC_TARGET_INFO[] struTargetInfo;   //目标信息数组
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;                  // 保留字节
    }


}
