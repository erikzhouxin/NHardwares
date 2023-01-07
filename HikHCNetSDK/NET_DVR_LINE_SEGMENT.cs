using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*当fValue表示目标高度的时候，struStartPoint和struEndPoint分别表示目标头部点和脚部点。
     * 当fValue表示线段长度的时候，struStartPoint和struEndPoint分别表示线段起始点和终点，
     * mode表示当前样本线表示高度线还是长度线。*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_LINE_SEGMENT
    {
        public byte byLineMode;     // 参照 LINE_MODE
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;       // 保留字节 
        public NET_VCA_POINT struStartPoint;
        public NET_VCA_POINT struEndPoint;
        public float fValue;
    }


}
