using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECORD_PLAN_CFG_INFO_S
    {
        public Int32 bPlanEnable;            /* 计划使能 */
        public Int32 bRedundantStorage;      /* 冗余录像使能 */
        public NETDEV_RECORD_RULE_S stRecordRule;           /* 录像计划规则 */
        public NETDEV_VIDEO_WEEK_PLAN_S stWeekPlan;             /* 计划配置 */
        public UInt32 udwChlID;               /* 视频输入通道号 批量获取/添加时使用 */
        public UInt32 udwReqSeq;              /* 请求数据序号 [1, 50] 仅VMS支持 添加录像计划Post必选 */
        public UInt32 udwTamplateID;          /* 时间模板ID 仅VMS支持 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_NAME_MAX_LEN)]
        public byte[] szTamplateName;         /* 时间模板名称 仅VMS支持 Get接口返回 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 116)]
        public byte[] byRes;                  /*   Reserved field*/
    };

}
