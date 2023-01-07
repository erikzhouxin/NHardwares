using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_INQUEST_CDRW_CFG
    {
        public uint dwSize;
        public uint dwNum;                       //刻录机的数量
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.U4)]
        public uint[] dwRwSelectPara;// 是否选中该光驱
        public uint dwModeSelect;                //0表示循环刻录模式  1表示并行刻录模式(默认模式)
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;                   //保留
        public uint dwStartCDRW;                 //DVR 本地已经开始刻录
        public uint dwHdExcp;                    //硬盘有异 常
        public uint dwInterval;                  //时间间隔，10分钟(0)、20分钟(1)、30分钟(2)
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] sLable;                  //光盘名称
    }
}
