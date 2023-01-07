using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //单个分区配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_SINGLE_PATH
    {
        public byte byActive;  // 是否可用,0-否,1-是 
        public byte byType;   //0-存储抓拍，1-存储禁止名单比对报警，2-存储抓拍和禁止名单比对报警，0xff-无效
        public byte bySaveAlarmPic; //是否用于保存断网的报警图片，0-否，1-是
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1; //保留
        public uint dwDiskDriver;   //盘符号，从0开始
        public uint dwLeftSpace;   //预留容量（单位为G）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2; //保留
    }
}
