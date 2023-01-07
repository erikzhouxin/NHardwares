using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //本地盘组信息配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SINGLE_HDGROUP
    {
        public uint dwHDGroupNo;/*盘组号(不可设置) 1-MAX_HD_GROUP*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byHDGroupChans;/*盘组对应的录像通道, 0-表示该通道不录象到该盘组，1-表示录象到该盘组*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
