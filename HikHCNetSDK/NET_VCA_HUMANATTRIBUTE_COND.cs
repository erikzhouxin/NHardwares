using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_HUMANATTRIBUTE_COND
    {
        public byte bySex; //性别：0-不启用，1-男，2-女
        public byte byCertificateType; //证件类型：0-不启用，1-身份证，2-警官证
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_HUMAN_BIRTHDATE_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byStartBirthDate; //起始出生年月，如：201106
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_HUMAN_BIRTHDATE_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byEndBirthDate; //截止出生年月，如201106
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byName; //姓名
        public NET_DVR_AREAINFOCFG struNativePlace; //籍贯参数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byCertificateNumber;  //证件号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
