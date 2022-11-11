using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVVehicleRecord
     * @brief 名单项配置, Blacklist and whitelist records
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PARK_VEHICLE_RECORD_S
    {
        public Int32 dwId;                         /* 名单中的索引, Index in the list*/
        public Int32 dwEnableType;                 /* 下发车牌号码编码格式，0：UTF-8编码格式，1：GBK编码格式, Encoding format of the configured vehicle plate number: UTF-8 and GBK*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_32)]
        public byte[] szPlateNo;                    /* 车牌号码，可做为检索条件 UTF-8编码格式, Vehicle plate number, can be used as search criteria, encoded in UTF-8*/
        public Int64 dwEffectiveTime;               /* 生效时间 从1970/01/01 00:00:00到现在的秒数, Effective time, which is the seconds that have elapsed since 1970/01/01 00:00:00 */
        public Int64 dwExpirationTime;              /* 过期时间 从1970/01/01 00:00:00到现在的秒数, Expiry time, which is the seconds that have elapsed since 1970/01/01 00:00:00 */
    };

}
