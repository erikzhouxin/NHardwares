using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //尺寸过滤策略
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_FILTER_STRATEGY
    {
        public byte byStrategy;      //尺寸过滤策略 0 - 不启用 1-高度和宽度过滤,2-面积过滤
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 11, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;       //保留
    }

}
