using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //行为分析配置结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_RULECFG_V41
    {
        public uint dwSize;         //结构长度
        public byte byPicProType;   //报警时图片处理方式 0-不处理 非0-上传
        public byte byUpLastAlarm; //2011-04-06 是否先上传最近一次的报警
        public byte byPicRecordEnable;  /*2012-3-1是否启用图片存储, 0-不启用, 1-启用*/
        public byte byRes1;
        public NET_DVR_JPEGPARA struPictureParam;       //图片规格结构	
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_RULE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_ONE_RULE_V41[] struRule;  //规则数组
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
