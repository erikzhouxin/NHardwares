using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //人员信息结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_HUMAN_ATTRIBUTE
    {
        public byte bySex;//性别：0-男，1-女
        public byte byCertificateType;//证件类型：0-身份证，1-警官证
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_HUMAN_BIRTHDATE_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byBirthDate;//出生年月，如：201106
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byName; //姓名
        public NET_DVR_AREAINFOCFG struNativePlace;//籍贯参数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byCertificateNumber; //证件号
        public uint dwPersonInfoExtendLen;// 人员标签信息扩展长度
        public IntPtr pPersonInfoExtend;  //人员标签信息扩展信息
        public byte byAgeGroup;//年龄段，详见HUMAN_AGE_GROUP_ENUM，如传入0xff表示未知
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 11, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;//保留
    }
}
