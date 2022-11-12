using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ORG_BATCH_DEL_INFO_S
    {
        public Int32 dwStatus;                             /* 响应状态，类型 参见 NETDEV_ORG_RESPONSE_STAUTE_E */
        public Int32 dwNum;                                /* 响应数量 */
        public IntPtr pstResultInfo;      /*批量删除返回信息，根据删除数量动态申请(NETDEV_OPERATE_INFO_S[])*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 68)]
        public byte[] byRes;                            /* 保留字段  Reserved field*/
    }

}
