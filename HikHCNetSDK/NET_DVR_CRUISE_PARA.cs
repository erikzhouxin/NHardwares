using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*DVR实现巡航数据结构*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CRUISE_PARA
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.CRUISE_MAX_PRESET_NUMS, ArraySubType = UnmanagedType.I1)]
        public byte[] byPresetNo;/* 预置点号 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.CRUISE_MAX_PRESET_NUMS, ArraySubType = UnmanagedType.I1)]
        public byte[] byCruiseSpeed;/* 巡航速度 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.CRUISE_MAX_PRESET_NUMS, ArraySubType = UnmanagedType.U2)]
        public ushort[] wDwellTime;/* 停留时间 */
        public byte byEnableThisCruise;/* 是否启用 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 15, ArraySubType = UnmanagedType.I1)]
        public byte[] res;
    }
}
