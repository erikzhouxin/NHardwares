using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /******************************车牌识别 end******************************************/

    /******************************抓拍机*******************************************/
    //IO输入配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IO_INCFG
    {
        public uint dwSize;
        public byte byIoInStatus;//输入的IO口状态，0-下降沿，1-上升沿，2-上升沿和下降沿，3-高电平，4-低电平
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留字节
    }



}
