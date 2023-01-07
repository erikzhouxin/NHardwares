using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //显示输出参数配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DISPLAYCFG
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DISPLAY_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_DISPLAYPARAM[] struDisplayParam;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
