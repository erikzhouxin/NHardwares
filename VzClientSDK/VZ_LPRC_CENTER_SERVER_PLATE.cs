using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 中心服务器网络车牌
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPRC_CENTER_SERVER_PLATE
    {
        /// <summary>
        /// 中心服务器车牌地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VzClientSdk.URLLENGTH)]
        public string url;
        /// <summary>
        /// 中心服务器车牌推送使能
        /// </summary>
        public Byte enable;
        /// <summary>
        /// 中心服务器车牌内容详细等级 0:全部 1:较详细 2:较简略 3:简略
        /// </summary>
        public Byte contentLevel;
        /// <summary>
        /// 中心服务器车牌是否发送大图片
        /// </summary>
        public Byte sendLargeImage;
        /// <summary>
        /// 中心服务器车牌是否发送小图片
        /// </summary>
        public Byte sendSmallImage;
    }
}
