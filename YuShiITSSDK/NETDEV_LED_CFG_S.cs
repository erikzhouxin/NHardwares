using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVLed
     * @brief    出入口设备Led屏显示配置
     * @attention
     */
    public struct NETDEV_LED_CFG_S
    {
        public Int32 dwEnabled;                                                   /*是否启用，0-不启用，1启用*/
        public Int32 dwSceneType;                                                 /*场景类型 参见：NETDEV_PARK_LED_SCENE_TYPE_E*/
        public Int32 dwScreenLineNum;                                             /*屏配置行数，固定行数：4*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_4)]
        public NETDEV_LED_LINE_CFG_S[] stuContextList;                            /*行配置内容*/
    }

}
