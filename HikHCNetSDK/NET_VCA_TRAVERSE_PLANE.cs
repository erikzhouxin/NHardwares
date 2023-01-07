using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_TRAVERSE_PLANE
    {
        public NET_VCA_LINE struPlaneBottom;//警戒面底边
        public uint dwCrossDirection;//穿越方向: 0-双向，1-从左到右，2-从右到左
        public byte bySensitivity;//灵敏度，取值范围：[1,5] （对于Smart IPC，取值范围为[1,100]） 
        public byte byPlaneHeight;//警戒面高度
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 38, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;

        //             public void Init()
        //             {
        //                 struPlaneBottom = new NET_VCA_LINE();
        //                 struPlaneBottom.Init();
        //                 byRes2 = new byte[38];
        //             }
    }

}
