using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ACS_EVENT_INFO_EXTEND
    {
        public int dwFrontSerialNo; //事件流水号，为0无效（若该字段为0，平台根据dwSerialNo判断是否丢失事件；若该字段不为0，平台根据该字段和dwSerialNo字段共同判断是否丢失事件）（主要用于解决报警订阅后导致dwSerialNo不连续的情况）
        public byte byUserType; //人员类型：0-无效，1-普通人（主人），2-来宾（访客），3-禁止名单人，4-管理员
        public byte byCurrentVerifyMode; //读卡器当前验证方式：0-无效，1-休眠，2-刷卡+密码，3-刷卡，4-刷卡或密码，5-指纹，6-指纹+密码，7-指纹或刷卡，8-指纹+刷卡，9-指纹+刷卡+密码，10-人脸或指纹或刷卡或密码，11-人脸+指纹，12-人脸+密码，13-人脸+刷卡，14-人脸，15-工号+密码，16-指纹或密码，17-工号+指纹，18-工号+指纹+密码，19-人脸+指纹+刷卡，20-人脸+密码+指纹，21-工号+人脸，22-人脸或人脸+刷卡，23-指纹或人脸，24-刷卡或人脸或密码，25-刷卡或人脸，26-刷卡或人脸或指纹，27-刷卡或指纹或密码
        public byte byCurrentEvent; //是否为实时事件：0-无效，1-是（实时事件），2-否（离线事件）
        public byte byPurePwdVerifyEnable; //设备是否支持纯密码认证， 0-不支持，1-支持
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NET_SDK_EMPLOYEE_NO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byEmployeeNo; //工号（人员ID）（对于设备来说，如果使用了工号（人员ID）字段，byEmployeeNo一定要传递，如果byEmployeeNo可转换为dwEmployeeNo，那么该字段也要传递；对于上层平台或客户端来说，优先解析byEmployeeNo字段，如该字段为空，再考虑解析dwEmployeeNo字段）
        public byte byAttendanceStatus; //考勤状态：0-未定义,1-上班，2-下班，3-开始休息，4-结束休息，5-开始加班，6-结束加班
        public byte byStatusValue; //考勤状态值
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NET_SDK_UUID_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byUUID; //UUID（该字段仅在对接萤石平台过程中才会使用）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NET_DEV_NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byDeviceName;   //设备序列号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
