using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //警戒事件参数
    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct NET_VCA_EVENT_UNION
    {
        [FieldOffsetAttribute(0)]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 23, ArraySubType = UnmanagedType.U4)]
        public uint[] uLen;//参数

        //[FieldOffsetAttribute(0)]
        //public NET_VCA_TRAVERSE_PLANE struTraversePlane;//穿越警戒面参数 
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_AREA struArea;//进入/离开区域参数
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_INTRUSION struIntrusion;//入侵参数
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_LOITER struLoiter;//徘徊参数
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_TAKE_LEFT struTakeTeft;//丢包/捡包参数
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_PARKING struParking;//停车参数
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_RUN struRun;//奔跑参数
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_HIGH_DENSITY struHighDensity;//人员聚集参数  
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_VIOLENT_MOTION struViolentMotion;	//剧烈运动
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_REACH_HIGHT struReachHight;      //攀高
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_GET_UP struGetUp;           //起床
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_LEFT struLeft;            //物品遗留
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_TAKE struTake;            // 物品拿取
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_HUMAN_ENTER struHumanEnter;      //人员进入
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_OVER_TIME struOvertime;        //操作超时
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_STICK_UP struStickUp;//贴纸条
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_SCANNER struScanner;//读卡器参数
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_LEAVE_POSITION struLeavePos;        //离岗参数
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_TRAIL struTrail;           //尾随参数
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_FALL_DOWN struFallDown;        //倒地参数
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_AUDIO_ABNORMAL struAudioAbnormal;   //声强突变
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_ADV_REACH_HEIGHT struReachHeight;     //折线攀高参数
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_TOILET_TARRY struToiletTarry;     //如厕超时参数
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_YARD_TARRY struYardTarry;       //放风场滞留参数
        //[FieldOffsetAttribute(0)]
        //public NET_VCA_ADV_TRAVERSE_PLANE struAdvTraversePlane;//折线警戒面参数            
    }

}
