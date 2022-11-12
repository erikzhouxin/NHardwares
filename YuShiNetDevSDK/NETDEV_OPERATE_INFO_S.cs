using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /*multi traffic statistics*/
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OPERATE_INFO_S
    {
        public Int32 dwID;                 /* ID */
        public Int32 dwReturnCode;         /* Return Code */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;               /* Reserved */
    }

    //     /**
    //      * @struct tagstNETDEVOperateInfo
    //      * @brief 单个操作信息
    //      * @attention dwID为入参，dwReturnCode为出参
    //      */
    //     [StructLayout(LayoutKind.Sequential)]
    //     public struct NETDEV_OPERATE_INFO_S
    //     {
    //         public Int32 dwID;                   /* ID */
    //         public Int32 dwReturnCode;           /* 返回码*/
    //         [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
    //         public byte[] byRes;              /* 保留字段  Reserved field */
    //     }

}
