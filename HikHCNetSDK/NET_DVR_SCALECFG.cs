using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //配置缩放参数的结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SCALECFG
    {
        public uint dwSize;
        public uint dwMajorScale;/* 主显示 0-不缩放，1-缩放*/
        public uint dwMinorScale;/* 辅显示 0-不缩放，1-缩放*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.U4)]
        public uint[] dwRes;
    }

}
