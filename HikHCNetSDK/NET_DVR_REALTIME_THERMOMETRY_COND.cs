using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //实时温度检测条件结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_REALTIME_THERMOMETRY_COND
    {
        public uint dwSize;
        public uint dwChan;//通道号，从1开始，0xffffffff代表获取全部通道
        public byte byRuleID; //规则ID 0-代表获取全部规则，具体规则ID从1开始 
        /*
         * 1-定时模式：设备每隔一秒上传各个规则测温数据的最高温、最低温和平均温度值、温差
         * 2-温差模式：若上一秒与下一秒的最高温或者最低温或者平均温或者温差值的温差大于等于2摄氏度，则上传最高温、最低温和平均温度值。若大于等于一个小时温差值均小于2摄氏度，则上传最高温、最低温、平均温和温差值
         */
        public byte byMode; //长连接模式， 0-保留（为兼容老设备），1-定时模式，2-温差模式
        public ushort wInterval; //上传间隔，仅温差模式支持，1~3600S，填0则默认3600S上传一次
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 60, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留
    }
}
