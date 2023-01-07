using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_ITC_LANE_VIDEO_EPOLICE_PARAM
    {
        public byte byLaneNO; //关联的车道号
        public byte bySensitivity; //线圈灵敏度，[1,100]
        public byte byEnableRadar;//启用雷达测试0-不启用，1-启用
                                  //关联车道方向类型，参考ITC_RELA_LANE_DIRECTION_TYPE
                                  //该参数为车道方向参数，与关联车道号对应，确保车道唯一性。
        public byte byRelaLaneDirectionType;
        public NET_ITC_LANE_LOGIC_PARAM struLane; //车道参数
        public NET_ITC_VIOLATION_DETECT_PARAM struVioDetect; //违规检测参数
        public NET_ITC_VIOLATION_DETECT_LINE struLine; //违规检测线
        public NET_ITC_POLYGON struPlateRecog; //牌识区域参数
        public byte byRecordEnable;//闯红灯周期录像标志，0-不录像，1-录像
        public byte byRecordType;//闯红灯录像类型，0-预录，1-延时录像
        public byte byPreRecordTime;//闯红灯录像片段预录时间（默认0），单位：秒
        public byte byRecordDelayTime;//闯红灯录像片段延时时间（默认0），单位：秒
        public byte byRecordTimeOut;//闯红灯周期录像超时时间（秒）
        public byte byCarSpeedLimit; //车速限制值，单位km/h
        public byte byCarSignSpeed;//标志限速，单位km/h
        public byte bySnapPicPreRecord; //抓拍图片预录时间点；0-默认值（第二张图片），1-第一张图片，2-第二张图片，3-第三张图片
        public NET_ITC_INTERVAL_PARAM struInterval;//抓拍间隔参数（20byte）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 36, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
