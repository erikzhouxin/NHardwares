using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct NETDEV_INFORELEASE_CFG_S
     * @brief 智能业务_名单配置_放行策略
     * @attention 对外接口
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_INFORELEASE_CFG_S
    {
        public Int32 uCtrlMode;                           /**<生效模式 0服务器控制模式 1离线控制模式 2单机控制模式  */
        public Int32 uReleaseTactics;                     /**<识别车辆 0全部放行 1白名单车辆放行 2非黑名单车辆放行  */
        public Int32 uUnidentifiedRelease;                /**<未识别车辆 0不放行 1放行 */
        public Int32 uOutputSwitchID;
    }

}
