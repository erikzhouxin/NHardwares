using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //起床参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_GET_UP
    {
        public NET_VCA_POLYGON struRegion; //区域范围
        public ushort wDuration;            //触发起床报警阈值1-100 秒
        public byte byMode;             //起身检测模式,0-大床通铺模式,1-高低铺模式,2-大床通铺坐立起身模式
        public byte bySensitivity;      //灵敏度参数，范围[1,10]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;            //保留字节
    }

}
