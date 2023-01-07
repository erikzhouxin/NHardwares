using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*******************************屏幕控制V41*******************************/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SCREEN_CONTROL_V41
    {
        public uint dwSize;
        public byte bySerialNo;     //串口号
        public byte byBeginAddress; //左上角屏幕号，从1开始
        public byte byEndAddress;   //右下角屏幕号，从1开始
        public byte byProtocol;            // 串口协议类型  1-LCD-S1 , 2-LCD-S2 , 3-LCD-L1 ， 4-LCD-DLP， 5-LCD-S3 , 6-LCD-H1 
        public uint dwCommand;      /* 控制方法 1-开 2-关 3-屏幕输入源选择 4-显示单元颜色控制 5-显示单元位置控制*/
        public NET_DVR_SCREEN_CONTROL_PARAM struControlParam;
        public byte byWallNo;       // 电视墙号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 51, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
