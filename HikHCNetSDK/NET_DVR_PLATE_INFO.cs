using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //车牌识别结果子结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PLATE_INFO
    {
        public byte byPlateType; //车牌类型
        public byte byColor; //车牌颜色
        public byte byBright; //车牌亮度
        public byte byLicenseLen;   //车牌字符个数
        public byte byEntireBelieve;//整个车牌的置信度，0-100
        public byte byRegion;                       // 区域索引值 0-保留，1-欧洲(EU)，2-俄语区域(ER)，3-欧洲&俄罗斯(EU&CIS) ,4-中东(ME),0xff-所有
        public byte byCountry;                      // 国家索引值，参照枚举COUNTRY_INDEX（不支持"COUNTRY_ALL = 0xff, //ALL  全部"）
        public byte byArea;                         //区域（省份），各国家内部区域枚举，阿联酋参照 EMI_AREA
        public byte byPlateSize;                    //车牌尺寸，0~未知，1~long, 2~short(中东车牌使用)
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 15, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;                       //保留
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CATEGORY_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPlateCategory;//车牌附加信息, 即中东车牌中车牌号码旁边的小字信息，(目前只有中东地区支持)
        public uint dwXmlLen;                        //XML报警信息长度
        public IntPtr pXmlBuf;                      // XML报警信息指针,报警类型为 COMM_ITS_PLATE_RESUL时有效，其XML对应到EventNotificationAlert XML Block
        public NET_VCA_RECT struPlateRect;  //车牌位置
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_LICENSE_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sLicense; //车牌号码 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_LICENSE_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byBelieve; //各个识别字符的置信度，如检测到车牌"浙A12345", 置信度为,20,30,40,50,60,70，则表示"浙"字正确的可能性只有%，"A"字的正确的可能性是%
    }



}
