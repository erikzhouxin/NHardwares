using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //身份证信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ID_CARD_INFO
    {
        public uint dwSize;        //结构长度
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ID_NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byName;   //姓名
        public NET_DVR_DATE struBirth; //出生日期
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ID_ADDR_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byAddr;  //住址
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ID_NUM_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byIDNum;   //身份证号码
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ID_ISSUING_AUTHORITY_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byIssuingAuthority;  //签发机关
        public NET_DVR_DATE struStartDate;  //有效开始日期
        public NET_DVR_DATE struEndDate;  //有效截止日期
        public byte byTermOfValidity;  //是否长期有效， 0-否，1-是（有效截止日期无效）
        public byte bySex;  //性别，1-男，2-女
        public byte byNation;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 101, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
