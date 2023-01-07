using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //多边型结构体
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_ITC_POLYGON
    {
        public uint dwPointNum; //有效点 大于等于3，若是3点在一条线上认为是无效区域，线交叉认为是无效区域 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_POINT[] struPos; //多边形边界点,最多20个 
    }

}
