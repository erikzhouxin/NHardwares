using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVMonitorResultInfo
     * @brief 添加布控返回的布控信息 Device information Structure definition
     * @attention  None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_RESULT_INFO_S
    {
        public UInt32 udwChannelNum;                  /* 布控添加成功的实际通道数 需赋值标明内存申请大小*/
        public IntPtr pstMonitorChlInfos;             /* 布控返回信息列表 内存由上层申请 不应小于下发的通道数量 malloc by caller （参见NETDEV_MONITION_CHL_INFO_S）*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 250)]
        public byte[] byRes;                     /* 保留字段  Reserved */
    }

}
