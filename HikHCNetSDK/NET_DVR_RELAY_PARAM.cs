using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //继电器关联配置
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_RELAY_PARAM
    {
        public byte byAccessDevInfo;//0-不接入设备，1-开道闸、2-关道闸、3-停道闸、4-报警信号、5-常亮灯
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
