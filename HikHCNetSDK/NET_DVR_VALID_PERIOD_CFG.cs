using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VALID_PERIOD_CFG
    {
        public byte byEnable; //使能有效期，0-不使能，1使能
        public byte byBeginTimeFlag;      //是否限制起始时间的标志，0-不限制，1-限制
        public byte byEnableTimeFlag;     //是否限制终止时间的标志，0-不限制，1-限制
        public byte byTimeDurationNo;     //有效期索引,从0开始（时间段通过SDK设置给锁，后续在制卡时，只需要传递有效期索引即可，以减少数据量）
        public NET_DVR_TIME_EX struBeginTime; //有效期起始时间
        public NET_DVR_TIME_EX struEndTime; //有效期结束时间
        public byte byTimeType; //时间类型：0-设备本地时间（默认），1-UTC时间（对于struBeginTime，struEndTime字段有效）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 31, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
