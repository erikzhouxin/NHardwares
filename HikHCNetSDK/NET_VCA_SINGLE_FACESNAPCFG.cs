using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //人脸抓拍规则(单条)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_SINGLE_FACESNAPCFG
    {
        public byte byActive;               //是否激活规则：0-否，1-是
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;     //保留
        public NET_VCA_SIZE_FILTER struSizeFilter;   //尺寸过滤器
        public NET_VCA_POLYGON struVcaPolygon;      //人脸识别区域
    }
}
