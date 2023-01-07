using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //liscense plate result
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PLATE_RET
    {
        public uint dwSize;//结构长度
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PLATE_NUM_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byPlateNum;//车牌号
        public byte byVehicleType;// 车类型
        public byte byTrafficLight;//0-绿灯；1-红灯
        public byte byPlateColor;//车牌颜色
        public byte byDriveChan;//触发车道号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byTimeInfo;/*时间信息*///plate_172.6.113.64_20090724155526948_197170484 
                                         //目前是17位，精确到ms:20090724155526948
        public byte byCarSpeed;/*单位km/h*/
        public byte byCarSpeedH;/*cm/s高8位*/
        public byte byCarSpeedL;/*cm/s低8位*/
        public byte byRes;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PLATE_INFO_LEN - 36, ArraySubType = UnmanagedType.I1)]
        public byte[] byInfo;
        public uint dwPicLen;
    }
}
