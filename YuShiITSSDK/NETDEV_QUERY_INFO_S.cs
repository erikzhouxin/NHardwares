using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagstNETDEVAlarmLogCond
     * @brief 
     * @attention 
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_QUERY_INFO_S
    {
        public Int32 dwQueryType;                                /* See# NETDEV_QUERYCOND_TYPE_E */
        public Int32 dwLogicFlag;                                /* See# NETDEV_QUERYCOND_LOGICTYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_CODE_STR_MAX_LEN)]
        public byte[] szConditionData;
    }

}
