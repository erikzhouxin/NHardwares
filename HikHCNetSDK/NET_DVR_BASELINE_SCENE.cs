using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //基准场景参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_BASELINE_SCENE
    {
        public uint dwSize;     //结构体大小
        public byte byEnable;   //0-不启用，1-启用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 63, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;  //保留
    }
}
