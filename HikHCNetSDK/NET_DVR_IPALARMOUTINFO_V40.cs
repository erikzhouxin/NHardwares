using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /* IP报警输出参数 */
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPALARMOUTINFO_V40
    {
        public uint dwIPID;                 /* IP设备ID */
        public uint dwAlarmOut;             /* IP设备ID对应的报警输出号 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;                /* 保留 */
    }

}
