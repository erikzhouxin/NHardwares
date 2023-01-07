using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_RECT_LIST
    {
        public byte byRectNum;    // 矩形框的个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 11, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;  //保留字节 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_RECT_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_RECT[] struVcaRect; // 最大为6个Rect 
    }


}
