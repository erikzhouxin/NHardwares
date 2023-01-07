using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //视频电警线结构
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_ITC_LINE
    {
        public NET_VCA_LINE struLine; //线参数
        public byte byLineType; //线类型，详见ITC_LINE_TYPE
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
