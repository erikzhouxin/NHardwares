using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //车牌识别结果子结构
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_VCA_PLATE_INFO
    {
        public VCA_RECOGNIZE_RESULT eResultFlag;//识别结果标志 
        public VCA_PLATE_TYPE ePlateType;//车牌类型
        public VCA_PLATE_COLOR ePlateColor;//车牌颜色
        public NET_VCA_RECT struPlateRect;//车牌位置
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
        public uint[] dwRes;//保留，设置为0 
        public uint dwLicenseLen;//车牌长度
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.MAX_LICENSE_LEN)]
        public string sLicense;//车牌号码 
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.MAX_LICENSE_LEN)]
        public string sBelieve;//各个识别字符的置信度，如检测到车牌"浙A12345", 置信度为10,20,30,40,50,60,70，则表示"浙"字正确的可能性只有10%，"A"字的正确的可能性是20%
    }
}
