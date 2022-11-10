using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagstVehicleEventInfo
    * @brief 
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEHICLE_EVENT_INFO_S
    {
        public UInt32 udwID;
        public UInt32 udwTimestamp;
        public UInt32 udwNotificationType;
        public UInt32 udwVehicleInfoNum;
        public IntPtr pstVehicleRecordInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;
    }

}
