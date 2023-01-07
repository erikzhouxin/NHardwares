using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //交通事件规则(扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_AID_RULECFG_V41
    {
        public uint dwSize;                     // 结构体大小 
        public byte byPicProType;               // 报警时图片处理方式 0-不处理 非0-上传
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;                  // 保留字节
        public NET_DVR_JPEGPARA struPictureParam;   // 图片规格结构
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_AID_RULE, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_ONE_AID_RULE_V41[] struAIDRule;  //规则数组
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;                //保留
    }



}
