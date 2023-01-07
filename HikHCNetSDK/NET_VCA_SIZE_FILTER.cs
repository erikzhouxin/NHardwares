using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //尺寸过滤器
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_SIZE_FILTER
    {
        public byte byActive;//是否激活尺寸过滤器 0-否 非0-是
        public byte byMode;//过滤器模式SIZE_FILTER_MODE
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留，置0
        public NET_VCA_RECT struMiniRect;//最小目标框,全0表示不设置
        public NET_VCA_RECT struMaxRect;//最大目标框,全0表示不设置
    }

}
