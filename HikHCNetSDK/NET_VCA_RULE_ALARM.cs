using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //行为分析结果上报结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_RULE_ALARM
    {
        public uint dwSize;//结构长度
        public uint dwRelativeTime;//相对时标
        public uint dwAbsTime;//绝对时标
        public NET_VCA_RULE_INFO struRuleInfo;//事件规则信息
        public NET_VCA_TARGET_INFO struTargetInfo;//报警目标信息
        public NET_VCA_DEV_INFO struDevInfo;//前端设备信息
        public uint dwPicDataLen;//返回图片的长度 为0表示没有图片，大于0表示该结构后面紧跟图片数据*/
        public byte byPicType; //0-普通图片 1-对比图片            
        public byte byRelAlarmPicNum; //关联通道报警图片数量
        public byte bySmart;//IDS设备返回0(默认值)，Smart Functiom Return 1
        public byte byPicTransType;        //图片数据传输方式: 0-二进制；1-url
        public uint dwAlarmID;     //报警ID，用以标识通道间关联产生的组合报警，0表示无效
        public ushort wDevInfoIvmsChannelEx;     //与NET_VCA_DEV_INFO里的byIvmsChannel含义相同，能表示更大的值。老客户端用byIvmsChannel能继续兼容，但是最大到255。新客户端版本请使用wDevInfoIvmsChannelEx。
        public byte byRelativeTimeFlag;      //dwRelativeTime字段是否有效  0-无效， 1-有效，dwRelativeTime表示UTC时间 
        public byte byAppendInfoUploadEnabled; //附加信息上传使能 0-不上传 1-上传
        public IntPtr pAppendInfo;     //指向附加信息NET_VCA_APPEND_INFO的指针，byAppendInfoUploadEnabled为1时或者byTimeDiffFlag为1时有效
        public IntPtr pImage;//指向图片的指针
    }
}
