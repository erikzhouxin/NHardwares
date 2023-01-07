using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_ADV_REACH_HEIGHT
    {
        public NET_VCA_POLYGON struRegion; //攀高折线
        public uint dwCrossDirection;   //跨越方向(详见VCA_CROSS_DIRECTION): 0-双向，1-从左到右2-从右到左
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;            // 保留字节
    }

}
