using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVVehicleRecordList
    * @brief 名单项List, Blacklist and whitelist records list
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PARK_VEHICLE_RECORD_LIST_S
    {
        public Int32 dwNum;                       /* 名单项数目, Number of list records */
        public IntPtr pastVehicleRecord;          /* 名单项配置, List records configuration. See #NETDEV_ITS_VEHICLE_RECORD_S*/
    };

}
