using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 虚拟线圈信息定义
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPRC_VIRTUAL_LOOP
    {
        /// <summary>
        /// 序号
        /// </summary>
        public byte byID;
        /// <summary>
        /// 是否有效
        /// </summary>
        public byte byEnable;
        /// <summary>
        /// 是否绘制
        /// </summary>
        public byte byDraw;
        /// <summary>
        /// 预留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        /// <summary>
        /// 名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VzClientSdk.VZ_LPRC_VIRTUAL_LOOP_NAME_LEN)]
        public string strName;
        /// <summary>
        /// 顶点数组
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VzClientSdk.VZ_LPRC_VIRTUAL_LOOP_VERTEX_NUM)]
        public VZ_LPRC_VERTEX[] struVertex;
        /// <summary>
        /// 穿越方向限制
        /// </summary>
        public uint eCrossDir;
        /// <summary>
        /// 对相同车牌的触发时间间隔的限制，单位为秒
        /// </summary>
        public uint uTriggerTimeGap;
        /// <summary>
        /// 最大车牌尺寸限制
        /// </summary>
        public uint uMaxLPWidth;
        /// <summary>
        /// 最小车牌尺寸限制
        /// </summary>
        public uint uMinLPWidth;
    }
}
