using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ITS_CALIBRATION
    {
        public uint dwPointNum; //标定点数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.CALIB_PT_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_POINT[] struPoint; //图像坐标
        public float fWidth;
        public float fHeight;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 100, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;        // 保留字节
    }


}
