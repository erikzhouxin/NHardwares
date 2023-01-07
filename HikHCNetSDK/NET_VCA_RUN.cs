using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //奔跑参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_RUN
    {
        public NET_VCA_POLYGON struRegion;//区域范围
        public float fRunDistance;//人奔跑最大距离, 范围: [0.1, 1.00]
        public byte byRes1;             // 保留字节
        public byte byMode;             // 0 像素模式  1 实际模式
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
