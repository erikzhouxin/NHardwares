using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 预设省份信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPRC_PROVINCE_INFO
    {
        /// <summary>
        /// 所有支持的省份简称构成的字符串
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VzClientSdk.VZ_LPRC_PROVINCE_STR_LEN, ArraySubType = UnmanagedType.I1)]
        public char[] strProvinces;
        /// <summary>
        /// 当前的预设省份的序号，在strProvinces中的，-1为未设置
        /// </summary>
        public int nCurrIndex;
    }
}
