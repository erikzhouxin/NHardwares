using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VEHICLE_INFO
    {
        public uint dwIndex;
        public byte byVehicleType;
        public byte byColorDepth;
        public byte byColor;
        public byte byRadarState;
        public ushort wSpeed;
        public ushort wLength;
        public byte byIllegalType;
        public byte byVehicleLogoRecog; //参考枚举类型 VLR_VEHICLE_CLASS
        public byte byVehicleSubLogoRecog; //车辆品牌子类型识别；参考VSB_VOLKSWAGEN_CLASS等子类型枚举。
        public byte byVehicleModel; //车辆子品牌年款，0-未知，参考"车辆子品牌年款.xlsx"
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byCustomInfo;  //自定义信息
        public ushort wVehicleLogoRecog;  //车辆主品牌，参考"车辆主品牌.xlsx" (该字段兼容byVehicleLogoRecog);
        public byte byIsParking;//是否停车 0-无效，1-停车，2-未停车
        public byte byRes;//保留字节
        public uint dwParkingTime; //停车时间，单位：s
        public byte byBelieve; //byIllegalType置信度，1-100
        public byte byCurrentWorkerNumber;//当前作业人数
        public byte byCurrentGoodsLoadingRate;//当前货物装载率 0-空 1-少 2-中 3-多 4-满
        public byte byDoorsStatus;//车门状态 0-车门关闭 1-车门开启
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;

        public void Init()
        {
            byCustomInfo = new byte[16];
            byRes3 = new byte[4];
        }
    }



}
