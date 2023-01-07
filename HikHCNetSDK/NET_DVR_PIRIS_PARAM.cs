using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //在byIrisMode 为P-Iris1时生效，配置红外光圈大小等级，配置模式
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PIRIS_PARAM
    {
        public byte byMode;//0-自动，1-手动
        public byte byPIrisAperture;//红外光圈大小等级(等级,光圈大小正比例)level:1~100 默认:50（手动模式下增加）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
