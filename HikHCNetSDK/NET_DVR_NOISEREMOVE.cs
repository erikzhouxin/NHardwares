using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //数字降噪功能
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_NOISEREMOVE
    {
        public byte byDigitalNoiseRemoveEnable; /*0-不启用，1-普通模式数字降噪，2-专家模式数字降噪*/
        public byte byDigitalNoiseRemoveLevel; /*普通模式数字降噪级别：0x0-0xF*/
        public byte bySpectralLevel;       /*专家模式下空域强度：0-100*/
        public byte byTemporalLevel;   /*专家模式下时域强度：0-100*/
        public byte byDigitalNoiseRemove2DEnable;         /* 抓拍帧2D降噪，0-不启用，1-启用 */
        public byte byDigitalNoiseRemove2DLevel;            /* 抓拍帧2D降噪级别，0-100 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
