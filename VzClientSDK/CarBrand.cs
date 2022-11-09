using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 汽车品牌内容
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CarBrand
    {
        /// <summary>
        /// 品牌
        /// </summary>
        public byte brand;
        /// <summary>
        /// 车型
        /// </summary>
        public byte type;
        /// <summary>
        /// 年份
        /// </summary>
        public short year;
    }
}
