using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    // 标定配置结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CALIBRATION_CFG
    {
        public uint dwSize;               //标定结构大小
        public byte byEnable;           // 是否启用标定
        public byte byCalibrationType;    // 标定类型 根据不同类型在联合体类选择不同的标定 参考CALIBRATE_TYPE
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_CALIBRATION_PRARM_UNION uCalibrateParam;  // 标定参数联合体
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }


}
