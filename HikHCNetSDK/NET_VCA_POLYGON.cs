using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //该结构会导致xaml界面出不来！！！！！！！！！？？问题暂时还没有找到  
    //暂时屏蔽结构先
    //多边型结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_POLYGON
    {
        /// DWORD->unsigned int
        public uint dwPointNum;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.VCA_MAX_POLYGON_POINT_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_POINT[] struPos;
    }

}
