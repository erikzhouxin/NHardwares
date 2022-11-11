using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagstNETDEVVehicleDetailInfo
    * @brief 
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEHICLE_DETAIL_INFO_S
    {
        public UInt32 udwReqSeq;
        public UInt32 udwMemberID;
        public NETDEV_PLATE_ATTR_INFO_S stPlateAttr;
        public NETDEV_VEHICLE_MEMBER_ATTR_S stVehicleAttr;
        public Int32 bIsMonitored;
        public UInt32 udwDBNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_16)]
        public UInt32[] audwDBIDList;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;              /*Reserved */
    }

}
