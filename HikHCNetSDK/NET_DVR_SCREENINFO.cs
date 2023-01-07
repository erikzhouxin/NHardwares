using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //大屏拼接信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SCREENINFO
    {
        public byte bySupportBigScreenNums;//最多大屏拼接数量
        public byte byStartBigScreenNum;//大屏拼接起始号
        public byte byMaxScreenX;//大屏拼接模式
        public byte byMaxScreenY;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
