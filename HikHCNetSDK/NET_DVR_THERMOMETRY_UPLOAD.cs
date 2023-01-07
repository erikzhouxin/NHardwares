using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_THERMOMETRY_UPLOAD
    {
        public uint dwSize;
        public uint dwRelativeTime;     // 相对时标
        public uint dwAbsTime;            // 绝对时标
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] szRuleName;//规则名称
        public byte byRuleID;//规则ID号
        public byte byRuleCalibType;//规则标定类型 0-点，1-框，2-线
        public ushort wPresetNo; //预置点号
        public NET_DVR_POINT_THERM_CFG struPointThermCfg;
        public NET_DVR_LINEPOLYGON_THERM_CFG struLinePolygonThermCfg;
        public byte byThermometryUnit;//测温单位: 0-摄氏度（℃），1-华氏度（℉），2-开尔文(K)
        public byte byDataType;//数据状态类型:0-检测中，1-开始，2-结束
        public byte byRes1;
        /*
            bit0-中心点测温：0-不支持，1-支持；
            bit1-最高点测温：0-不支持，1-支持；
            bit2-最低点测温：0-不支持，1-支持；
        */
        public byte bySpecialPointThermType;// 是否支持特殊点测温
        public float fCenterPointTemperature;//中心点温度,精确到小数点后一位(-40-1500),（浮点数+100）*10 （由bySpecialPointThermType判断是否支持中心点）
        public float fHighestPointTemperature;//最高点温度,精确到小数点后一位(-40-1500),（浮点数+100）*10（由bySpecialPointThermType判断是否支持最高点）
        public float fLowestPointTemperature;//最低点温度,精确到小数点后一位(-40-1500),（浮点数+100）*10（由bySpecialPointThermType判断是否支持最低点）
        public NET_VCA_POINT struHighestPoint;//线、框测温最高温度位置坐标（当规则标定类型为线、框的时候生效）
        public NET_VCA_POINT struLowestPoint;//线、框测温最低温度位置坐标（当规则标定类型为线、框的时候生效）
        public byte yIsFreezedata;//是否数据冻结 0-否 1-是
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        public uint dwChan; //通道号，查询条件中通道号为0xffffffff时该字段生效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 88, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
