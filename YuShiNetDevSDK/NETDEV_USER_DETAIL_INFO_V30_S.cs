using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVUserDetailInfo
    * @brief 用户详细信息 结构体定义 
    * @attention 无 None
    */
    public struct NETDEV_USER_DETAIL_INFO_V30_S
    {
        public UInt32 udwUserID;                              /* 用户ID Get必选 仅VMS支持 */
        public UInt32 udwLevel;                               /* 用户等级 Post Put必选 仅NVR支持 见 #NETDEV_USER_LEVEL_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szUserName;                             /* 用户名称[1,64]  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szPassword;                             /* 用户密码 Post Put必选[0,256]  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szOldPassword;                          /* 用户旧密码 仅NVR支持修改密码 Put必选[0,256]  */
        public NETDEV_TIME_TEMPLATE_S stTimeTemplateInfo;                     /* 时间模板信息 Get返回ID、名称 Post Put必选ID 描述不返回 仅VMS支持 */
        public NETDEV_TIME_S stValidBeginTime;                       /* 用户有效期开始时间 精确到日 Get Post Put必选 仅VMS支持 */
        public NETDEV_TIME_S stValidEndTime;                         /* 用户有效期结束时间 精确到日 Get Post Put必选 仅VMS支持 */
        public NETDEV_USER_EXTEND_INFO_S stUserExtendInfo;                       /* 用户扩展信息 Post Put必选 仅VMS支持  */
        public UInt32 udwOrgID;                               /* 组织ID 仅IPM支持 不支持修改 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
        public byte[] byRes;                             /* 保留字段  */
    }

}
