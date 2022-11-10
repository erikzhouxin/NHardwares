using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVVehicleRecordExtern
     * @brief 名单项extern参数 Vehicle blacklist/whitelist info
     * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PARK_VEHICLE_RECORD_EXTERN_S
    {
        public Int32 dwListType;                   /* 名单类型 0:白名单 1:黑名单, List type. 0: whitelist 1: blacklist */
        public Int32 dwDBOperateType;              /* 名单操作类型  NETDEV_DB_OPERATE_E, List records configuration. See #NETDEV_DB_OPERATE_E */
        public NETDEV_PARK_VEHICLE_RECORD_LIST_S stVehicleRecordList;          /*名单项配置 */
    };

}
