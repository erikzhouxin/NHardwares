using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_THERMOMETRY_ALARM
    {
        public uint dwSize;
        public uint dwChannel;//通道号
        public byte byRuleID;//规则ID
        public byte byThermometryUnit;//测温单位: 0-摄氏度（℃），1-华氏度（℉），2-开尔文(K)
        public ushort wPresetNo; //预置点号
        public NET_PTZ_INFO struPtzInfo;//ptz坐标信息
        public byte byAlarmLevel;//0-预警 1-报警
        public byte byAlarmType;/*报警类型 0-最高温度 1-最低温度 2-平均温度 3-温差 4-温度突升 5-温度突降*/
        public byte byAlarmRule;//0-大于，1-小于
        public byte byRuleCalibType;//规则标定类型 0-点，1-框，2线
        public NET_VCA_POINT struPoint;//点测温坐标（当规则标定类型为点的时候生效）
        public NET_VCA_POLYGON struRegion;//区域（当规则标定类型为框的时候生效）
        public float fRuleTemperature;/*配置规则温度,精确到小数点后一位(-40-1000),（浮点数+100） */
        public float fCurrTemperature;/*当前温度,精确到小数点后一位(-40-1000),（浮点数+100） */
        public uint dwPicLen;//可见光图片长度
        public uint dwThermalPicLen;//热成像图片长度
        public uint dwThermalInfoLen;//热成像附加信息长度
        public IntPtr pPicBuff; ///可见光图片指针
        public IntPtr pThermalPicBuff;// 热成像图片指针
        public IntPtr pThermalInfoBuff; //热成像附加信息指针
        public NET_VCA_POINT struHighestPoint;//线、框测温最高温度位置坐标（当规则标定类型为线、框的时候生效）
        public float fToleranceTemperature;/* 容差温度,精确到小数点后一位(-40-1000),（浮点数+100） */
        public uint dwAlertFilteringTime;//温度预警等待时间 单位秒 范围为0-200秒，默认为0秒
        public uint dwAlarmFilteringTime;//温度报警等待时间 单位秒 范围为0-200秒，默认为0秒
        public uint dwTemperatureSuddenChangeCycle;//温度突变记录周期，单位秒
        public float fTemperatureSuddenChangeValue;//温度突变值,精确到小数点后一位(大于0)
        public byte byPicTransType;        //图片数据传输方式: 0-二进制；1-url
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwVisibleChannel; //可见光通道通道号
        public uint dwRelativeTime;     // 相对时标
        public uint dwAbsTime;          // 绝对时标
        public float fAlarmRuleTemperature;/* TMA测温配置规则温度,精确到小数点后一位(-40-1000),（浮点数+100） */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
