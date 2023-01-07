using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //SMART IR(防过曝)配置参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SMARTIR_PARAM
    {
        public byte byMode;//0～手动，1～自动
        public byte byIRDistance;//红外距离等级(等级，距离正比例)level:1~100 默认:50（手动模式下增加）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
