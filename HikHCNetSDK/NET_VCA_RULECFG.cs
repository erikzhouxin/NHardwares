using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //行为分析配置结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_RULECFG
    {
        public uint dwSize;//结构长度
        public byte byPicProType;//报警时图片处理方式 0-不处理 非0-上传
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public NET_DVR_JPEGPARA struPictureParam;//图片规格结构
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_RULE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_ONE_RULE[] struRule;//规则数组
    }

}
