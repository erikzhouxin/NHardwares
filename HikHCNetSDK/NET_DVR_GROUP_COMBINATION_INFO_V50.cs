using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_GROUP_COMBINATION_INFO_V50
    {
        public byte byEnable; //是否启用该群组组合
        public byte byMemberNum; //刷卡成员数量
        public byte bySequenceNo; //群组刷卡次序号
        public byte byRes;
        public uint dwGroupNo;  //群组编号,0xffffffff表示远程开门，0xfffffffe表示超级密码
    }
}
