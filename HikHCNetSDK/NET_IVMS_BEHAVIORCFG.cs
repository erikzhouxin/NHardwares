using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    // IVMS行为分析配置结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_IVMS_BEHAVIORCFG
    {
        public uint dwSize;
        public byte byPicProType;//报警时图片处理方式 0-不处理 非0-上传
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public NET_DVR_JPEGPARA struPicParam;//图片规格结构
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT, ArraySubType = UnmanagedType.Struct)]
        public NET_IVMS_RULECFG[] struRuleCfg;//每个时间段对应规则
    }
}
