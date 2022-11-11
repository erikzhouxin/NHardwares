using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagstNETDEVVehRecognitionEvent
    * @brief 
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEH_RECOGNITION_EVENT_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_480)]
        public byte[] szReference;
        public UInt32 udwSrcID;
        public NETDEV_VEHICLE_EVENT_INFO_S stVehicleEventInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;
    }

}
