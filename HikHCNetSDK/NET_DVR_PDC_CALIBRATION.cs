using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    // PDC 标定参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PDC_CALIBRATION
    {
        public NET_DVR_RECT_LIST struRectList;       // 标定矩形框列表
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 120, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;       // 保留字节 
    }


}
