using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /* 报警输入参数 */
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPALARMININFO
    {
        public byte byIPID;/* IP设备ID取值1- MAX_IP_DEVICE */
        public byte byAlarmIn;/* 报警输入号 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 18, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;/* 保留 */
    }

}
