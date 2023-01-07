using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //增益配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_GAIN
    {
        public byte byGainLevel; /*增益：0-100*/
        public byte byGainUserSet; /*用户自定义增益；0-100，对于抓拍机，是CCD模式下的抓拍增益*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public uint dwMaxGainValue;/*最大增益值，单位dB*/
    }



}
