using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FIND_PICTURE_PARAM
    {
        public uint dwSize;         // 结构体大小 
        public int lChannel;       // 通道号
        public byte byFileType;
        public byte byNeedCard;     // 是否需要卡号
        public byte byProvince;     //省份索引值
        public byte byEventType;      // 事件类型：0保留，1-交通事件；2-违章取证；3-其他事件
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.CARDNUM_LEN_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] sCardNum;     // 卡号
        public NET_DVR_TIME struStartTime;//查找图片的开始时间
        public NET_DVR_TIME struStopTime;// 查找图片的结束时间
                                         //ITC3.7 新增
        public uint dwTrafficType; //图片检索生效项 参考 VCA_OPERATE _TYPE 
        public uint dwVehicleType; //车辆类型 参考 VCA_VEHICLE_TYPE
                                   //违规检测类型参考 VCA_ILLEGAL_TYPE 当前不支持复选
        public uint dwIllegalType;
        public byte byLaneNo;  //车道号(1~99)
        public byte bySubHvtType;//0-保留,1-机动车(机动车子类型中支持车牌检索，省份检索),2-非机动车,3-行人
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_LICENSE_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sLicense;    //车牌号码
        public byte byRegion;     // 区域索引值 0-保留，1-欧洲(Europe Region)，2-俄语区域(Russian Region)，3-欧洲&俄罗斯(EU&CIS), 4-中东(Middle East),0xff-所有
        public byte byCountry;     // 国家索引值，参照：COUNTRY_INDEX 
        public byte byArea;  //地区
        public byte byISO8601;  //是否是8601的时间格式，即时差字段是否有效0-时差无效，年月日时分秒为设备本地时间 1-时差有效 
        public byte cStartTimeDifferenceH;   //开始时间与UTC的时差（小时），-12 ... +14， 正数表示东时区
        public byte cStartTimeDifferenceM;   //开始时间与UTC的时差（分钟），-30, 0, 30, 45，正数表示东时区
        public byte cStopTimeDifferenceH;    //结束时间与UTC的时差（小时），-12 ... +14，正数表示东时区
        public byte cStopTimeDifferenceM;    //结束时间与UTC的时差（分钟），-30, 0, 30, 45，正数表示东时区
    }
}
