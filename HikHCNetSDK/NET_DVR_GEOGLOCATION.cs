using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_GEOGLOCATION
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.U4)]
        public int[] iRes; /*保留*/
        public uint dwCity; /*城市，详见PROVINCE_CITY_IDX */
    }



}
