using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //籍贯参数结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_AREAINFOCFG
    {
        public ushort wNationalityID;//国籍
        public ushort wProvinceID;//省
        public ushort wCityID;//市
        public ushort wCountyID;//县
        public uint dwCode;//保留
    }
}
