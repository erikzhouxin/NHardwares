using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //攀高参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_REACH_HIGHT
    {
        public NET_VCA_LINE struVcaLine;   //攀高警戒面
        public ushort wDuration; //触发攀高报警阈值：1-120秒
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;           // 保留字节
    }

}
