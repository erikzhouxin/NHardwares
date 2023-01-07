using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /* IP报警输入参数 */
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPALARMININFO_V40
    {
        public uint dwIPID;                 /* IP设备ID */
        public uint dwAlarmIn;              /* IP设备ID对应的报警输入号 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;                /* 保留 */
    }

}
